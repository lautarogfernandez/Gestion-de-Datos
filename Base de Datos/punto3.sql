create procedure Team_Casty.crearUsuario(@username nvarchar(255),@password nvarchar(255),@nombreRol nvarchar(255),
@nombre nvarchar(255),@apellido nvarchar(255), @tipoDocumento nvarchar(255), @numeroDocumento numeric(18), 
@mail nvarchar(255), @telefono nvarchar(50), @direccion nvarchar(255), @fechaNacimiento datetime, @hotel numeric(18))
as
begin
  --------------------------------------------------------------------------------
  if not exists(select * from Team_Casty.Usuario u where u.Username= @username)
    begin
    
    insert into Team_Casty.Usuario (Username,Contraseña) values (@username,@password)
    
    insert into Team_Casty.Empleado (Nombre,Apellido,ID_Tipo_Documento,Nro_Documento,Mail,Telefono,Direccion,Fecha_Nacimiento)
                (select distinct @nombre as Nombre , @apellido as Apellido, tp.ID_Tipo_Documento, @numeroDocumento as Nro_Documento
                , @mail as Mail, @telefono as Telefono, @direccion as Direccion, @fechaNacimiento as Fecha_Nacimiento
                 from  Team_Casty.Tipo_Documento tp where tp.Tipo_Documento= @tipoDocumento)
                 
    insert into Team_Casty.RolXUsuarioXHotel (Cod_Rol,Cod_Usuario,Cod_Hotel)  
                select r.Cod_Rol , u.Cod_Usuario , @hotel as Cod_Hotel
                from Team_Casty.Rol r , Team_Casty.Usuario u 
                where r.Nombre = @nombreRol and u.Username = @username        
    end
    
    else
      begin
      -----condicion si no esta
      end
end  

-----------------------------------------------------------------
create procedure Team_Casty.bajaUsuario(@username nvarchar(255))
as
begin
  update Team_Casty.Usuario set Baja=1 where @username=Username
end
 
 -------------------------------------------------------------------------
create procedure Team_Casty.agregarUsuarioRolHotel(@usuario numeric(18), @rol numeric(18), @hotel numeric(18))
as
begin
  insert into Team_Casty.RolXUsuarioXHotel (Cod_Usuario,Cod_Rol,Cod_Hotel) values (@usuario, @rol, @hotel)
end 
-----------------------------------------------------------------------------------------

create procedure Team_Casty.modificarUsuarioContraseña (@password nvarchar(255),@username nvarchar(255))
as
begin
  update Team_Casty.Usuario set  Contraseña= @password where @username = Username
end

------------------------------------------------------------------------------------

create procedure Team_Casty.habilitarUsuario (@username nvarchar(255))
as
begin
  update Team_Casty.Usuario set Habilitado=1
end