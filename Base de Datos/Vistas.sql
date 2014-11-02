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

drop table TEAM_CASTY.Vista_Reserva_Regimen
