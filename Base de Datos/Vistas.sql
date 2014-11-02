--Vistas
create view TEAM_CASTY.vistaClientes
AS
select c.Nombre, c.Apellido, c.Mail, d.Tipo_Documento AS 'Tipo Documento', c.Nro_Documento AS 'Numero Documento', c.Telefono, c.Pais, c.Localidad, c.Nom_Calle AS 'Calle', c.Nro_Calle AS 'Numero Calle', c.Piso ,c.Dto AS 'Departamento',c.Nacionalidad, c.Fecha_Nacimiento AS 'Fecha Nacimiento'
from TEAM_CASTY.Cliente c, TEAM_CASTY.Tipo_Documento d
where c.Baja=0
order by 4,5

-- vistas sobre reservas   
Create view TEAM_CASTY.Vista_Reserva_Estado
AS
select r.Cod_Reserva, r.Cod_Hotel,r.ID_Cliente_Reservador,r.Cod_Regimen,r.Cod_Estado,e.Nombre as "Nombre_Estado",e.Descripcion as"Descripcion Estado",r.Fecha_Reserva,r.Fecha_Inicio,r.Fecha_Salida,r.Cant_Noches
from TEAM_CASTY.Reserva r , TEAM_CASTY.Estados e 

select * from TEAM_CASTY.Vista_Reserva_Estado

drop table TEAM_CASTY.Vista_Reserva_Estado



Create view TEAM_CASTY.Vista_Reserva_Regimen
AS
select r.Cod_Reserva, r.Cod_Hotel,r.ID_Cliente_Reservador,r.Cod_Regimen,reg.Descripcion as "Descripcion Regimen",reg.Precio as "Precio Regimen",r.Cod_Estado,r.Fecha_Reserva,r.Fecha_Inicio,r.Fecha_Salida,r.Cant_Noches
from TEAM_CASTY.Reserva r, TEAM_CASTY.Regimen reg 

select * from TEAM_CASTY.Vista_Reserva_Regimen


--vista hotel
Create view TEAM_CASTY.Vista_Hotel
AS
select c.Nombre as "Ciudad",h.Calle,h.Nro_Calle,h.Telefono,h.Mail,h.CantEstrella,re.Recarga as "Recarga_Estrella"
from TEAM_CASTY.Hotel h, TEAM_CASTY.Ciudad c , TEAM_CASTY.Recarga_Estrella re

select * from TEAM_CASTY.Vista_Hotel

drop table TEAM_CASTY.Vista_Hotel


--vista habitacion
Create view TEAM_CASTY.Vista_Habitacion
as
select h.Cod_Hotel,h.Numero,h.Piso,h.Frente,h.Descripcion,th.Descripcion as "Tipo de habitacion", th.Porcentual 
from TEAM_CASTY.Habitacion h, TEAM_CASTY.Tipo_Habitacion th
where h.Baja=0

select * from TEAM_CASTY.Vista_Habitacion

drop table TEAM_CASTY.Vista_Habitacion
drop table TEAM_CASTY.Vista_Reserva_Regimen
