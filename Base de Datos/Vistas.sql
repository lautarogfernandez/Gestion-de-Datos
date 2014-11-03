   
--vista cliente (agregado el ID)
create view TEAM_CASTY.vistaClientes
AS
select c.ID_Cliente, c.Nombre, c.Apellido, c.Mail, d.Tipo_Documento AS 'Tipo Documento', c.Nro_Documento AS 'Numero Documento', c.Telefono, c.Pais, c.Localidad, c.Nom_Calle AS 'Calle', c.Nro_Calle AS 'Numero Calle', c.Piso ,c.Dto AS 'Departamento',c.Nacionalidad, c.Fecha_Nacimiento AS 'Fecha Nacimiento'
from TEAM_CASTY.Cliente c, TEAM_CASTY.Tipo_Documento d
where c.Baja=0   
   
   
   
--Vista factura
create view TEAM_CASTY.vistaFacturas
AS
select fac.*, fdp.Descripcion as "Forma_De_Pago"
from TEAM_CASTY.Factura fac, TEAM_CASTY.Forma_Pago fdp

select * from TEAM_CASTY.vistaFacturas

drop view TEAM_CASTY.vistaFacturas
   
   
-- vista habitaciones
create view TEAM_CASTY.vistaHabitaciones
AS
select h.*, th.Descripcion as "Tipo_De_Habitacion" ,th.Porcentual
from TEAM_CASTY.Habitacion h, TEAM_CASTY.Tipo_Habitacion th

select * from TEAM_CASTY.vistaHabitaciones

drop view TEAM_CASTY.vistaHabitaciones
   
-- vistas sobre reservas
Create view TEAM_CASTY.Vista_Reserva_Estado
AS
select r.Cod_Reserva, r.Cod_Hotel,r.ID_Cliente_Reservador,r.Cod_Regimen,r.Cod_Estado,e.Nombre as "Nombre_Estado",e.Descripcion as"Descripcion_Estado",r.Fecha_Reserva,r.Fecha_Inicio,r.Fecha_Salida,r.Cant_Noches
from TEAM_CASTY.Reserva r , TEAM_CASTY.Estados e

select * from TEAM_CASTY.Vista_Reserva_Estado

drop view TEAM_CASTY.Vista_Reserva_Estado

Create view TEAM_CASTY.Vista_Reserva_Regimen
AS
select r.Cod_Reserva, r.Cod_Hotel,r.ID_Cliente_Reservador,r.Cod_Regimen,reg.Descripcion as "Descripcion_Regimen",reg.Precio as "Precio_Regimen",r.Cod_Estado,r.Fecha_Reserva,r.Fecha_Inicio,r.Fecha_Salida,r.Cant_Noches
from TEAM_CASTY.Reserva r, TEAM_CASTY.Regimen reg

select * from TEAM_CASTY.Vista_Reserva_Regimen

drop view TEAM_CASTY.Vista_Reserva_Regimen  



Create view TEAM_CASTY.vistaReservas --(contiene a las otras 2)
as
select r.*, e.Nombre_Estado, e.Descripcion_Estado
 from TEAM_CASTY.Vista_Reserva_Regimen r, Vista_Reserva_Estado e 

select * from TEAM_CASTY.vistaReservas

drop view TEAM_CASTY.vistaReservas  

--vista hotel
Create view TEAM_CASTY.vistaHoteles
AS
select c.Nombre as "Ciudad",h.Calle,h.Nro_Calle,h.Telefono,h.Mail,h.CantEstrella,re.Recarga as "Recarga_Estrella"
from TEAM_CASTY.Hotel h, TEAM_CASTY.Ciudad c , TEAM_CASTY.Recarga_Estrella re

select * from TEAM_CASTY.vistaHoteles

drop view TEAM_CASTY.vistaHoteles
--vista habitacion
Create view TEAM_CASTY.vistaHabitaciones
as
select h.Cod_Hotel,h.Numero,h.Piso,h.Frente,h.Descripcion,th.Descripcion as "Tipo de habitacion", th.Porcentual
from TEAM_CASTY.Habitacion h, TEAM_CASTY.Tipo_Habitacion th
where h.Baja=0

select * from TEAM_CASTY.vistaHabitaciones

drop view TEAM_CASTY.vistaHabitaciones
 
   
   
 -- vista regimenes-hoteles  
create view TEAM_CASTY.vistaRegimenesXHoteles
AS  
select     h.* , r.*
from  TEAM_CASTY.vistaHoteles h, TEAM_CASTY.RegimenXHotel , TEAM_CASTY.Regimen r

select *
from TEAM_CASTY.vistaRegimenesXHoteles

   
drop view  TEAM_CASTY.vistaRegimenesXHoteles   



--vista HabitacionXReserva
create view TEAM_CASTY.vistaHabitacionesXReservas
AS  
select    h.Cod_Habitacion, h.Numero, h.Piso, h.Frente, h.Descripcion as "Descripcion_Habitacion", h."Tipo_De_Habitacion", h.Porcentual ,r.*
from  TEAM_CASTY.vistaHabitaciones h, TEAM_CASTY.HabitacionXReserva , TEAM_CASTY.vistaReservas r


select * from TEAM_CASTY.vistaHabitacionesXReservas

   
drop view  TEAM_CASTY.vistaHabitacionesXReservas   



-- vista ClienteXReserva
create view TEAM_CASTY.vistaClientesXReservas
AS  
select   c.*,r.*
from  TEAM_CASTY.ClienteXReserva, TEAM_CASTY.vistaClientes  c, TEAM_CASTY.Reserva r

select * from TEAM_CASTY.vistaClientesXReservas

drop view TEAM_CASTY.vistaClientesXReservas



--vista FuncionesXRol
create view TEAM_CASTY.vistasFuncionesXRol
AS  
select   r.*,f.*
from  TEAM_CASTY.FuncionesXRol, TEAM_CASTY.Rol  r, TEAM_CASTY.Funcion f

select * from TEAM_CASTY.vistasFuncionesXRol

drop view TEAM_CASTY.vistasFuncionesXRol




--vista ConsumibleXHabitacionXReserva
create view TEAM_CASTY.vistasConsumibleXHabitacionXReserva
AS  
select   c.*,vhxr.*
from  TEAM_CASTY.ConsumibleXHabitacionXReserva,TEAM_CASTY.Consumible c, TEAM_CASTY.vistaHabitacionesXReservas vhxr


select * from TEAM_CASTY.vistasConsumibleXHabitacionXReserva

drop view TEAM_CASTY.vistasConsumibleXHabitacionXReserva



