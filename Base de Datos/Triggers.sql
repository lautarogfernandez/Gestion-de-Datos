--Triggers
create trigger TEAM_CASTY.alta_clientes
ON TEAM_CASTY.vistaClientes
instead of insert
AS
begin

declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error: ';

if(exists (select * from TEAM_CASTY.Cliente c,inserted ins where c.Mail=ins.Mail))
begin
set @error=1
set @mensaje=@mensaje + 'Mail repetido. ';
end

if(exists (select * from TEAM_CASTY.Cliente c,inserted ins,TEAM_CASTY.Tipo_Documento tdoc where c.Nro_Documento=ins.[Numero Documento] and c.ID_Tipo_Documento=tdoc.ID_Tipo_Documento and ins.[Tipo Documento]=tdoc.Tipo_Documento))
begin
set @error=1
set @mensaje=@mensaje + 'Documento repetido. ';
end

if(@error=0)
begin
insert into TEAM_CASTY.Cliente
(Apellido,Nom_Calle,Dto,Fecha_Nacimiento,Localidad,Mail,Nacionalidad,Nombre,Nro_Calle,Nro_Documento,Pais,Piso,Telefono,ID_Tipo_Documento)
select ins.Apellido,ins.Calle,ins.Departamento,ins.[Fecha Nacimiento],ins.Localidad,ins.Mail,ins.Nacionalidad,ins.Nombre,
ins.[Numero Calle],ins.[Numero Documento],ins.Pais,ins.Piso,ins.Telefono,tdoc.ID_Tipo_Documento
from inserted ins, TEAM_CASTY.Tipo_Documento tdoc
where tdoc.Tipo_Documento=ins.[Tipo Documento]
end

else
begin
set @mensaje=@mensaje + 'No se realizó el alta';
RAISERROR (@mensaje,10,1);
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


create trigger TEAM_CASTY.modif_clientes
ON TEAM_CASTY.vistaClientes
instead of update
AS
begin

declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error: ';

if(exists (select * from TEAM_CASTY.Cliente c,inserted ins where c.Mail=ins.Mail and ins.Codigo<>c.ID_Cliente))
begin
set @error=1
set @mensaje=@mensaje + 'Mail repetido. ';
end

if(exists (select * from TEAM_CASTY.Cliente c,inserted ins,TEAM_CASTY.Tipo_Documento tdoc where c.Nro_Documento=ins.[Numero Documento] and tdoc.Tipo_Documento=ins.[Tipo Documento] and c.ID_Tipo_Documento=tdoc.ID_Tipo_Documento and c.ID_Cliente<>ins.Codigo))
begin
set @error=1
set @mensaje=@mensaje + 'Documento repetido. ';
end

if(@error=0)
begin
update c
set c.Nombre=ins.Nombre,c.Apellido=ins.Apellido,c.Mail=ins.Mail,c.ID_Tipo_Documento=tdoc.ID_Tipo_Documento,
c.Nro_Documento=ins.[Numero Documento],c.Telefono=ins.Telefono,c.Pais=ins.Pais,c.Localidad=ins.Localidad,
c.Nom_Calle=ins.Calle,c.Nro_Calle=ins.[Numero Calle],c.Piso=ins.Piso,c.Dto=ins.Departamento,
c.Nacionalidad=ins.Nacionalidad, c.Fecha_Nacimiento=ins.[Fecha Nacimiento]
from TEAM_CASTY.Cliente c, inserted ins,TEAM_CASTY.Tipo_Documento tdoc
where ins.Codigo=c.ID_Cliente and ins.[Tipo Documento] = tdoc.Tipo_Documento
end

else
begin
set @mensaje=@mensaje + 'No se realizó el alta';
RAISERROR (@mensaje,10,1);
end

end;

GO
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


create view vistaUsuarios
as
select u.Cod_Usuario as Codigo, u.Username, u.Contraseña, u.Habilitado
 from TEAM_CASTY.Usuario u join TEAM_CASTY.RolXUsuarioXHotel rxuxh
 
 
 -----------------------------------------------------------------------------------------------------------
 
 ---------------------------------------PUNTO 5--------------------------------------------------------------
 
 create view vistaHoteles
 as
 select
 from TEAM_CASTY.Hotel h join TEAM_CASTY.Ciudad c on (c.Cod_Ciudad= h.Cod_Ciudad)
                         join TEAM_CASTY.RegimenXHotel rxh on (rxh.Cod_Hotel = h.Cod_Hotel)
                         join TEAM_CASTY.Regimen r on (r.Cod_Regimen = rxh.Cod_Regimen)
                         join TEAM_CASTY.Periodo_Inhabilitado pinh on (pinh.Cod_Hotel = h.Cod_Hotel)
 
 create procedure
 
 --------------------------------------------------------------------------------------------------------------                         
 
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

