--Triggers

create trigger TEAM_CASTY.alta_clientes
ON TEAM_CASTY.vistaClientes
instead of insert
AS
begin

declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error:';

if(exists (select * from TEAM_CASTY.Cliente c,inserted ins where c.Mail=ins.Mail))
begin
set @error=1
set @mensaje=@mensaje + ' Mail repetido.';
end

if(exists (select * from TEAM_CASTY.Cliente c,inserted ins,TEAM_CASTY.Tipo_Documento tdoc where c.Nro_Documento=ins.[Numero Documento] and c.ID_Tipo_Documento=tdoc.ID_Tipo_Documento and ins.[Tipo Documento]=tdoc.Tipo_Documento))
begin
set @error=1
set @mensaje=@mensaje + ' Documento repetido.';
end

if(@error=0)
begin
insert into TEAM_CASTY.Cliente
(Apellido,Nom_Calle,Dto,Fecha_Nacimiento,Localidad,Mail,Nacionalidad,Nombre,Nro_Calle,Nro_Documento,Pais,Piso,Telefono,ID_Tipo_Documento)
select ins.Apellido,ins.Calle,ins.Departamento,ins.[Fecha Nacimiento],UPPER (ins.Localidad),ins.Mail,UPPER (ins.Nacionalidad,UPPER (ins.Nombre)),
ins.[Numero Calle],ins.[Numero Documento],UPPER (ins.Pais),ins.Piso,ins.Telefono,tdoc.ID_Tipo_Documento
from inserted ins, TEAM_CASTY.Tipo_Documento tdoc
where tdoc.Tipo_Documento=UPPER (ins.[Tipo Documento]);
end

else
begin
set @mensaje=@mensaje + ' No se realizó el alta.';
RAISERROR (@mensaje,15,1);
end

end;


create trigger TEAM_CASTY.modificacion_clientes
ON TEAM_CASTY.vistaClientes
instead of insert
AS
begin

declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error:';

if(exists (select * from TEAM_CASTY.Cliente c,inserted ins where c.Mail=ins.Mail))
begin
set @error=1
set @mensaje=@mensaje + ' Mail repetido.';
end

if(exists (select * from TEAM_CASTY.Cliente c,inserted ins,TEAM_CASTY.Tipo_Documento tdoc where c.Nro_Documento=ins.[Numero Documento] and c.ID_Tipo_Documento=tdoc.ID_Tipo_Documento and ins.[Tipo Documento]=tdoc.Tipo_Documento))
begin
set @error=1
set @mensaje=@mensaje + ' Documento repetido.';
end

if(@error=0)
begin
declare @id_tipo_doc numeric(18);
select @id_tipo_doc=td.ID_Tipo_Documento from TEAM_CASTY.Tipo_Documento td, inserted ins where td.Tipo_Documento=UPPER(ins.[Tipo Documento]);
declare @codigo numeric (18);
select @codigo=d.Codigo from deleted d;
update clie
set Apellido=ins.Apellido, Nom_Calle=ins.Calle,Dto=ins.Departamento,Fecha_Nacimiento=ins.[Fecha Nacimiento],
Localidad=UPPER (ins.Localidad),Mail=ins.Mail,Nacionalidad=UPPER (ins.Nacionalidad),
Nombre=UPPER (ins.Nombre),Nro_Calle=ins.[Numero Calle],Nro_Documento=ins.[Numero Documento],
Pais=UPPER (ins.Pais),Piso=ins.Piso,Telefono=ins.Telefono,ID_Tipo_Documento=@id_tipo_doc, Inhabilitado=ins.Inhabilitado
from TEAM_CASTY.Cliente clie, inserted ins
where @codigo=ID_Cliente;
end

else
begin
set @mensaje=@mensaje + ' No se realizó la modificación.';
RAISERROR (@mensaje,15,1);
end

end;


create trigger TEAM_CASTY.baja_clientes
ON TEAM_CASTY.vistaClientes
instead of delete
AS
begin
update clie
set Baja=1
from TEAM_CASTY.Cliente clie, deleted del
where del.Codigo=clie.ID_Cliente;
end;


--create trigger TEAM_CASTY.modif_clientes
--ON TEAM_CASTY.vistaClientes
--instead of update
--AS
--begin

--declare @mensaje varchar(1000);
--declare @error int;
--set @error=0;
--set @mensaje='Error:';

--if(exists (select * from TEAM_CASTY.Cliente c,inserted ins where c.Mail=ins.Mail and ins.Codigo<>c.ID_Cliente))
--begin
--set @error=1
--set @mensaje=@mensaje + ' Mail repetido.';
--end

--if(exists (select * from TEAM_CASTY.Cliente c,inserted ins,TEAM_CASTY.Tipo_Documento tdoc where c.Nro_Documento=ins.[Numero Documento] and tdoc.Tipo_Documento=ins.[Tipo Documento] and c.ID_Tipo_Documento=tdoc.ID_Tipo_Documento and c.ID_Cliente<>ins.Codigo))
--begin
--set @error=1
--set @mensaje=@mensaje + ' Documento repetido.';
--end

--if(@error=0)
--begin
--update c
--set c.Nombre=ins.Nombre,c.Apellido=ins.Apellido,c.Mail=ins.Mail,c.ID_Tipo_Documento=tdoc.ID_Tipo_Documento,
--c.Nro_Documento=ins.[Numero Documento],c.Telefono=ins.Telefono,c.Pais=ins.Pais,c.Localidad=ins.Localidad,
--c.Nom_Calle=ins.Calle,c.Nro_Calle=ins.[Numero Calle],c.Piso=ins.Piso,c.Dto=ins.Departamento,
--c.Nacionalidad=ins.Nacionalidad, c.Fecha_Nacimiento=ins.[Fecha Nacimiento]
--from TEAM_CASTY.Cliente c, inserted ins,TEAM_CASTY.Tipo_Documento tdoc
--where ins.Codigo=c.ID_Cliente and ins.[Tipo Documento] = tdoc.Tipo_Documento
--end

--else
--begin
--set @mensaje=@mensaje + ' No se realizó la modificación.';
--RAISERROR (@mensaje,15,1);
--end

--end;

--GO
-----------------------------------------------------------------------------------------------------------------------
insert into TEAM_CASTY.vistaClientes
(Nombre,Apellido,[Tipo Documento],[Numero Documento],Mail,Telefono,Pais,Localidad,Calle,[Numero Calle],Piso,Departamento,Nacionalidad,[Fecha Nacimiento])
VALUES('leder','casty','PASAPORTE',222,'maaadsdggsailcasty@cascsc',111,'casty','casty','casty',111,2,'SSS','casty',CONVERT(DATETIME,'1979-06-24',111));

delete TEAM_CASTY.vistaClientes
where Nombre='leder' and
Apellido='casty' AND
[Tipo Documento]='PASAPORTE' and
[Numero Documento]=222 and
Mail='maaadsdggsailcasty@cascsc'

update TEAM_CASTY.vistaClientes
set [Numero Documento]=99713572
where Codigo=100741

select * from team_casty.vistaClientes
select * from team_casty.Cliente c

--------------------------------------PUNTO 1---------------------------------------------------------------------------------



create view TEAM_CASTY.vistaRoles
as 
select r.Cod_Rol as Codigo, r.Nombre , r.Activo , f.Descripcion as Funcion
from TEAM_CASTY.Rol r, TEAM_CASTY.FuncionXRol fxr , TEAM_CASTY.Funcion f
where r.Cod_Rol = fxr.Cod_Rol and fxr.Cod_Funcion= f.Cod_Funcion


create trigger TEAM_CASTY.alta_roles
 ON TEAM_CASTY.vistaRoles
instead of insert
as
begin
insert into TEAM_CASTY.Rol (Activo,Nombre) select Activo, Nombre from inserted  

insert into TEAM_CASTY.FuncionXRol select i.Codigo as Cod_Rol , f.Cod_Funcion
                                   from inserted i  join TEAM_CASTY.Funcion f on (i.Funcion = f.Descripcion)
end

create trigger TEAM_CASTY.modificacion_roles 
ON TEAM_CASTY.vistaRoles
instead of update
as
begin
update r set r.Nombre = i.Nombre ,r.Activo = i.Activo
from TEAM_CASTY.Rol r join inserted i on (i.Codigo = r.Cod_Rol)
end


create trigger TEAM_CASTY.baja_roles
ON TEAM_CASTY.vistaRoles
instead of delete
as
begin
update r
set r.Activo=0
from TEAM_CASTY.Rol r, deleted del
where del.Codigo= r.Cod_Rol;
end;


--------------------------------------------------------------------------------------------------------


-----------------------------------------PUNTO 3--------------------------------------------------------


--create view vistaUsuarios
--as
--select u.Cod_Usuario as Codigo, u.Username, u.Contraseña, u.Habilitado
 --from TEAM_CASTY.Usuario u join TEAM_CASTY.RolXUsuarioXHotel rxuxh
 
 
 -----------------------------------------------------------------------------------------------------------
 
 ---------------------------------------PUNTO 5--------------------------------------------------------------
 
--vista hotel OK
--create view TEAM_CASTY.vistaHoteles
--(Codigo,Pais,Nombre,Ciudad,Calle,[Numero Calle],Telefono,Mail,[Fecha Creacion],[Cantidad de estrellas], [Recarga por estrella])
--AS
--select  h.Cod_Hotel, h.Pais,h.Nombre, c.Nombre ,h.Calle,h.Nro_Calle,h.Telefono,h.Mail,h.Fecha_Creacion,h.CantEstrella,re.Recarga  
--from TEAM_CASTY.Hotel h, TEAM_CASTY.Ciudad c , TEAM_CASTY.Recarga_Estrella re
--where h.Cod_Ciudad= c.Cod_Ciudad

--GO

 create trigger TEAM_CASTY.alta_Hotel
 on TEAM_CASTY.vistaHoteles
 instead of insert
 as
 begin
 insert into Team_Casty.Hotel (Nombre,Pais,Cod_Ciudad,Calle,Nro_Calle,Telefono,Mail,CantEstrella,Fecha_Creacion)
            select i.Nombre,i.Pais,c.Cod_Ciudad,i.Calle,i.[Numero Calle] as Nro_Calle,i.Telefono,i.Mail,
            i.[Cantidad de estrellas] as CantEstrella, i.[Fecha Creacion] as Fecha_Creacion
             from inserted i , Team_Casty.Ciudad c where i.Ciudad=c.Nombre   
 end
 go
 
 

 
 
 
 create procedure TEAM_CASTY.agregarRegimenesHotel(@codHotel numeric(18), @codRegimen numeric(18))
 as
 begin
   insert into Team_Casty.RegimenXHotel (Cod_Hotel,Cod_Regimen) values (@codHotel,@codRegimen)
 end
 go
 
 
 
 
 create procedure TEAM_CASTY.agregarAdministradorNuevoHotel(@codHotel numeric(18), @codUsuario numeric(18))
 as
 begin
   insert into Team_Casty.RolXUsuarioXHotel(Cod_Hotel,Cod_Rol,Cod_Usuario) values (@codHotel,1,@codUsuario)
   insert into Team_Casty.RolXUsuarioXHotel(Cod_Hotel,Cod_Rol,Cod_Usuario) values (@codHotel,3,2)
 end
 go
 
 
 
 
 create procedure TEAM_CASTY.baja_hotel(@codHotel numeric(18),@fechaInicio datetime, @fechaFin datetime,@descripcion nvarchar(255))
as
begin
  if not exists (select* from Team_Casty.Reserva res,Team_Casty.HabitacionXReserva hxr,Team_Casty.Habitacion hab
   where hab.Cod_Hotel=@codHotel and hab.Cod_Habitacion=hxr.Cod_Habitacion and hxr.Cod_Reserva= res.Cod_Reserva
   and  periodosSinInterseccion(@fechaInicio,@fechaFin,res.Fecha_Reserva,DATEADD(DAY,res.Cant_Noches,res.Fecha_Reserva))=0 )
   begin
     insert into Team_Casty.Periodo_Inhabilitado (Cod_Hotel,Fecha_Inicio,Fecha_Fin,Descripcion) values(@codHotel ,@fechaInicio, @fechaFin,@descripcion)
   end
   else
   begin
     -- no se puede borrar
   end
end
go


create procedure TEAM_CASTY.baja_regimenHotel(@codHotel numeric(18),@codRegimen numeric(18),@fechaActual)
as
begin
  if not exists (select * from )--- controlar q no haya reservas 
end
go

 
 -------------------------------------------------------------------------
 
 
 -------------------------------------                         
 
 ----------------------------------------PUNTO6-----------------------------------------------------------------
 create view vistaHabitaciones
 as
 select h.Cod_Habitacion as Codigo, h.Numero , h.Piso , h.Frente, h.Descripcion , th.Descripcion as "Tipo de habitacion" , h.Cod_Hotel Hotel
 from TEAM_CASTY.Habitacion h, TEAM_CASTY.Tipo_Habitacion th
 where h.Cod_Tipo = th.Cod_Tipo
 
 create view TEAM_CASTY.vistaRoles
as 
select r.Cod_Rol as Codigo, r.Nombre , r.Activo , f.Descripcion as Funcion
from TEAM_CASTY.Rol r, TEAM_CASTY.FuncionXRol fxr , TEAM_CASTY.Funcion f
where r.Cod_Rol = fxr.Cod_Rol and fxr.Cod_Funcion= f.Cod_Funcion


create trigger TEAM_CASTY.alta_Habitaciones
 ON TEAM_CASTY.vistaHabitaciones
instead of insert
as
begin
insert into TEAM_CASTY.Habitacion (Numero ,Piso ,Descripcion ,Cod_Hotel , Frente , Cod_Tipo ) select i.Numero, i.Piso,i.Descripcion, i.Codigo as Cod_Hotel , i.Frente , th.Cod_Tipo from inserted i , TEAM_CASTY.Tipo_Habitacion th 
                                                                                                                             where i.[Descripcion de tipo] = th.Descripcion  
end

create trigger TEAM_CASTY.modificacion_Habitaciones
ON TEAM_CASTY.vistaHabitaciones
instead of update
as
begin
if not exists (select from inserted i, TEAM_CASTY.Habitacion h  where i.Numero= h.Numero and i.Hotel = h.Cod_Hotel)
 begin
  update h set h.Piso = i.Piso , h.Numero = i.Numero , h.Frente = i.Frente , h.Descripcion = i.Descripcion 
  from TEAM_CASTY.Habitacion h join inserted i on (i.Codigo = h.Cod_Habitacion)


create trigger TEAM_CASTY.baja_Habitaciones
ON TEAM_CASTY.vistaRoles
instead of delete
as
begin
update h set h.Baja=0
from TEAM_CASTY.Habitacion h, deleted del
where del.Codigo= h.Cod_Habitacion
end


----------------------------------------------------------------------------------------------------------------------

-----------------------------------------------------PUNTO 8 -----------------------------------------------------------
create trigger TEAM_CASTY.alta_Reservas
on TEAM_CASTY.vistaReservas
instead of insert
as
begin
if  exists(select from TEAM_CASTY.Periodo_Inhabilitado ph, TEAM_CASTY.Reserva r, inserted i ,TEAM_CASTY.HabitacionXReserva  HxR, TEAM_CASTY.Habitacion Hab
                     where periodosSinInterseccion(i.[Fecha de Inicio], i.[Fecha de Salida],  ph.Fecha_Inicio , ph.Fecha_Fin)
                      and  periodosSinInterseccion(i.[Fecha de Inicio], i.[Fecha de Salida], r.Fecha_Reserva, DATEADD(day, r.Cant_Noches, r.Fecha_Reserva))  
                      and  r.Cod_Reserva = HxR.Cod_Reserva and HxR.Cod_Habitacion = Hab.Cod_Habitacion
                      and(i.Hotel <> Hab.Cod_Hotel and i.Numero <>Hab.Cod_Hotel)
    begin
      insert into Reserva (d)
    end                  
end

create function periodosSinInterseccion(@FechaInicio1 date, @FechaFin1 date, @FechaInicio2 date, @FechaFin2 date)
RETURNS bit
AS 
BEGIN
    if ((@FechaInicio1 > @FechaFin2 or  @FechaInicio2 > @FechaFin1 ))  RETURN 0
   else    RETURN 1
END;
GO


-----------------------------------------------------------------------------------------------------------------

---------------------------------------------------PUNTO 9-------------------------------------------------------

