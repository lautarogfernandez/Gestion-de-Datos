CREATE TYPE TEAM_CASTY.t_tablaHotelYRol AS TABLE(
	Cod_Hotel numeric (18),
	Nombre_Rol nvarchar (50));
	
GO

create procedure TEAM_CASTY.crearUsuario
(@username nvarchar(255),@password nvarchar(255),@nombre nvarchar(255),@apellido nvarchar(255),
 @tipoDocumento nvarchar(255), @numeroDocumento numeric(18), @mail nvarchar(255), @telefono nvarchar(50),
 @direccion nvarchar(255), @fechaNacimiento datetime, @tabla TEAM_CASTY.t_tablaHotelYRol readonly)
as
begin

declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error: ';

if (exists(select * from TEAM_CASTY.Usuario u where u.Username= @username))
begin
	set @error=1;
	set @mensaje=' Usuario existente.';
end

if (exists( 
select *
from TEAM_CASTY.Empleado e, TEAM_CASTY.Tipo_Documento td
where e.Nro_Documento=@numeroDocumento and @tipoDocumento=td.Tipo_Documento and e.ID_Tipo_Documento=td.ID_Tipo_Documento))
begin
	set @error=1;
	set @mensaje=' Empleado existente.';
end   

if (not exists( 
select *
from TEAM_CASTY.Tipo_Documento td
where @tipoDocumento=td.Tipo_Documento))
begin
	set @error=1;
	set @mensaje=' Tipo de documneto inexistente.';
end   

if(exists(
select *
from @tabla t
where t.Cod_Hotel not in(select h.Cod_Hotel from TEAM_CASTY.Hotel h)))
begin
	set @error=1;
	set @mensaje=' Hotel inexistente.';
end

if(exists(
select *
from @tabla t
where t.Nombre_Rol not in(select r.Nombre from TEAM_CASTY.Rol r)))
begin
	set @error=1;
	set @mensaje=' Rol inexistente.';
end

if (@error=0)
begin

	insert into TEAM_CASTY.Usuario (Username,Contraseña) values (@username,@password);
	
	declare @cod_usuario numeric (18);
	select @cod_usuario=u.Cod_Usuario
	from TEAM_CASTY.Usuario u
	where @username=u.Username;
	
	declare @id_tipo_documento numeric (18);
	select @id_tipo_documento=td.ID_Tipo_Documento
	from TEAM_CASTY.Tipo_Documento td
	where td.Tipo_Documento=@tipoDocumento;

	insert into TEAM_CASTY.Empleado
	(Nombre,Apellido,ID_Tipo_Documento,Nro_Documento,Mail,Telefono,Direccion,Fecha_Nacimiento,Cod_Usuario)
    values(@nombre,@apellido,@id_tipo_documento,@numeroDocumento,@mail,@telefono,@direccion,@fechaNacimiento,@cod_usuario);
             
	insert into TEAM_CASTY.RolXUsuarioXHotel
	(Cod_Usuario,Cod_Rol,Cod_Hotel)
    select @cod_usuario,r.Cod_Rol,t.Cod_Hotel
    from TEAM_CASTY.Rol r , @tabla t
    where r.Nombre=t.Nombre_Rol;

end

else
begin
  	set @mensaje +=' No se realizó el alta.';
  	RAISERROR (@mensaje,15,1);
end
end;

create procedure TEAM_CASTY.modificarUsuario
(@cod_usuario numeric(18),@username nvarchar(255),@password nvarchar(255),@nombre nvarchar(255),@apellido nvarchar(255),
 @tipoDocumento nvarchar(255), @numeroDocumento numeric(18), @mail nvarchar(255), @telefono nvarchar(50),
 @direccion nvarchar(255), @fechaNacimiento datetime, @tabla TEAM_CASTY.t_tablaHotelYRol readonly,@habilitado numeric (18))
as
begin

declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error: ';

if (not exists(select * from TEAM_CASTY.Usuario u where u.Cod_Usuario= @cod_usuario))
begin
	set @error=1;
	set @mensaje=' Usuario existente.';
end

if (exists( 
select *
from TEAM_CASTY.Empleado e, TEAM_CASTY.Tipo_Documento td
where @cod_usuario<>e.Cod_Usuario and e.Nro_Documento=@numeroDocumento and @tipoDocumento=td.Tipo_Documento and e.ID_Tipo_Documento=td.ID_Tipo_Documento))
begin
	set @error=1;
	set @mensaje=' Documento ya existente.';
end   

if (not exists( 
select *
from TEAM_CASTY.Tipo_Documento td
where @tipoDocumento=td.Tipo_Documento))
begin
	set @error=1;
	set @mensaje=' Tipo de documneto inexistente.';
end   

if(exists(
select *
from @tabla t
where t.Cod_Hotel not in(select h.Cod_Hotel from TEAM_CASTY.Hotel h)))
begin
	set @error=1;
	set @mensaje=' Hotel inexistente.';
end

if(exists(
select *
from @tabla t
where t.Nombre_Rol not in(select r.Nombre from TEAM_CASTY.Rol r)))
begin
	set @error=1;
	set @mensaje=' Rol inexistente.';
end

if (@error=0)
begin

	update TEAM_CASTY.Usuario
	set Username=@username, Contraseña=@password
	where Cod_Usuario=@cod_usuario;
	
	declare @id_tipo_documento numeric (18);
	select @id_tipo_documento=td.ID_Tipo_Documento
	from TEAM_CASTY.Tipo_Documento td
	where td.Tipo_Documento=@tipoDocumento;

	update TEAM_CASTY.Empleado
	set Nombre=@nombre,Apellido=@apellido,ID_Tipo_Documento=@id_tipo_documento,
	Nro_Documento=@numeroDocumento,Mail=@mail,Telefono=@telefono,Direccion=@direccion,
	Fecha_Nacimiento=@fechaNacimiento
    where @cod_usuario=Cod_Usuario;
             
	delete TEAM_CASTY.RolXUsuarioXHotel
	where Cod_Usuario=@cod_usuario;
	
	insert into TEAM_CASTY.RolXUsuarioXHotel
	(Cod_Usuario,Cod_Rol,Cod_Hotel)
    select @cod_usuario,r.Cod_Rol,t.Cod_Hotel
    from TEAM_CASTY.Rol r , @tabla t
    where r.Nombre=t.Nombre_Rol;

end

else
begin
  	set @mensaje +=' No se realizó la modificación.';
  	RAISERROR (@mensaje,15,1);
end
end;

create procedure Team_Casty.bajaUsuario
(@username nvarchar(255))
as
begin
if(exists (
select *
from TEAM_CASTY.Usuario u
where @username=u.Username))
begin
	update Team_Casty.Usuario set Baja=1 where @username=Username;
end
else
begin
  	declare @mensaje nvarchar(100);
  	set @mensaje +='Error: Usuario inexistente. No se realizó la baja.';
  	RAISERROR (@mensaje,15,1);
end  
end;
  
 
-- -------------------------------------------------------------------------
--create procedure Team_Casty.agregarUsuarioRolHotel(@usuario numeric(18), @rol numeric(18), @hotel numeric(18))
--as
--begin
--  insert into Team_Casty.RolXUsuarioXHotel (Cod_Usuario,Cod_Rol,Cod_Hotel) values (@usuario, @rol, @hotel)
--end 
-------------------------------------------------------------------------------------------

--create procedure Team_Casty.modificarUsuarioContraseña (@password nvarchar(255),@username nvarchar(255))
--as
--begin
--  update Team_Casty.Usuario set  Contraseña= @password where @username = Username
--end

--------------------------------------------------------------------------------------

--create procedure Team_Casty.habilitarUsuario (@username nvarchar(255))
--as
--begin
--  update Team_Casty.Usuario set Habilitado=1
--end