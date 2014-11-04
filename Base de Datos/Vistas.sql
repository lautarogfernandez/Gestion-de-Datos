   
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
where h.Baja = 0
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
select  r.Cod_Reserva, r.Cod_Hotel,r.ID_Cliente_Reservador,r.Cod_Regimen,reg.Descripcion as "Descripcion_Regimen",reg.Precio as "Precio_Regimen",r.Cod_Estado,r.Fecha_Reserva,r.Fecha_Inicio,r.Fecha_Salida,r.Cant_Noches
from TEAM_CASTY.Reserva r, TEAM_CASTY.Regimen reg

select * from TEAM_CASTY.Vista_Reserva_Regimen

drop view TEAM_CASTY.Vista_Reserva_Regimen  



Create view TEAM_CASTY.vistaReservas--(contiene a las otras 2)
as
select r.*, e.Nombre_Estado, e.Descripcion_Estado
 from TEAM_CASTY.Vista_Reserva_Regimen r, Vista_Reserva_Estado e 

select * from TEAM_CASTY.vistaReservas

drop view TEAM_CASTY.vistaReservas  

--vista hotel
Create view TEAM_CASTY.vistaHoteles
AS
select  h.Cod_Hotel, c.Nombre as "Ciudad",h.Calle,h.Nro_Calle,h.Telefono,h.Mail,h.CantEstrella,re.Recarga as "Recarga_Estrella"
from TEAM_CASTY.Hotel h, TEAM_CASTY.Ciudad c , TEAM_CASTY.Recarga_Estrella re

select * from TEAM_CASTY.vistaHoteles

drop view TEAM_CASTY.vistaHoteles

   
   
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
create view TEAM_CASTY.vistaConsumibleXHabitacionXReserva
AS  
select   c.*,vhxr.*
from  TEAM_CASTY.ConsumibleXHabitacionXReserva,TEAM_CASTY.Consumible c, TEAM_CASTY.vistaHabitacionesXReservas vhxr


select * from TEAM_CASTY.vistaConsumibleXHabitacionXReserva

drop view TEAM_CASTY.vistaConsumibleXHabitacionXReserva



---------------------------------------------------------------------------------------------------------------------
--LISTADOS

-----------------------------------------------------------------------------------------------------------------------------------
CREATE FUNCTION vistaTOP5ReservasCanceladas (@pFecha_Inicio date,@pFecha_Fin date)
RETURNS TABLE
AS
RETURN
   select  top 5 h.Cod_Hotel, vh.Ciudad, vh.Calle, vh.Nro_Calle, vh.Telefono,  vh.Mail, vh.CantEstrella,vh.Recarga_Estrella, count (vr.Cod_Reserva)  as "Cantidad_Reservas_Canceladas"
from TEAM_CASTY.vistaHoteles vh,TEAM_CASTY.Hotel h, TEAM_CASTY.Habitacion, TEAM_CASTY.vistaReservas vr 
where vr.Nombre_Estado = 'Cancelada' and vr.Fecha_Reserva between @pFecha_Inicio and @pFecha_Fin
group by h.Cod_Hotel, vh.Ciudad, vh.Calle, vh.Nro_Calle, vh.Telefono,  vh.Mail, vh.CantEstrella,vh.Recarga_Estrella
order by Cantidad_Reservas_Canceladas desc

SELECT * FROM vistaTOP5ReservasCanceladas


-- vista q no sirve
create view TEAM_CASTY.vistaTOP5ReservasCanceladas
as 
select  top 5 h.Cod_Hotel, vh.Ciudad, vh.Calle, vh.Nro_Calle, vh.Telefono,  vh.Mail, vh.CantEstrella,vh.Recarga_Estrella, count (vr.Cod_Reserva)  as "Cantidad_Reservas_Canceladas"
from TEAM_CASTY.vistaHoteles vh,TEAM_CASTY.Hotel h, TEAM_CASTY.Habitacion, TEAM_CASTY.vistaReservas vr 
where vr.Nombre_Estado = 'Cancelada'
group by h.Cod_Hotel, vh.Ciudad, vh.Calle, vh.Nro_Calle, vh.Telefono,  vh.Mail, vh.CantEstrella,vh.Recarga_Estrella


select * from TEAM_CASTY.vistaTOP5ReservasCanceladas

drop view TEAM_CASTY.vistaTOP5ReservasCanceladas

------------------------------------------------------------------------------------------------------
CREATE FUNCTION vistaTOP5ConsumiblesFacturados (@pFecha_Inicio date,@pFecha_Fin date)
RETURNS TABLE
AS
RETURN
   select  top 5 h.Cod_Hotel, vh.Ciudad, vh.Calle, vh.Nro_Calle, vh.Telefono,  vh.Mail, vh.CantEstrella,vh.Recarga_Estrella, COUNT (vCxHxR.Cod_Hotel) as "Cantidad_Consumibles" 
from TEAM_CASTY.vistaHoteles vh,TEAM_CASTY.Hotel h, TEAM_CASTY.vistaConsumibleXHabitacionXReserva vCxHxR
where vCxHxR.Nombre_Estado = 'Finalizada' and vCxHxR.Fecha_Reserva between @pFecha_Inicio and @pFecha_Fin
group by h.Cod_Hotel, vh.Ciudad, vh.Calle, vh.Nro_Calle, vh.Telefono,  vh.Mail, vh.CantEstrella,vh.Recarga_Estrella
order by Cantidad_Consumibles


SELECT * FROM vistaTOP5ConsumiblesFacturados


--vista que no sirve
create view TEAM_CASTY.vistaTOP5ConsumiblesFacturados
as 
select  top 5 h.Cod_Hotel, vh.Ciudad, vh.Calle, vh.Nro_Calle, vh.Telefono,  vh.Mail, vh.CantEstrella,vh.Recarga_Estrella, COUNT (vCxHxR.Cod_Hotel) as "Cantidad_Consumibles" 
from TEAM_CASTY.vistaHoteles vh,TEAM_CASTY.Hotel h, TEAM_CASTY.vistaConsumibleXHabitacionXReserva vCxHxR
where vCxHxR.Nombre_Estado = 'Finalizada'
group by h.Cod_Hotel, vh.Ciudad, vh.Calle, vh.Nro_Calle, vh.Telefono,  vh.Mail, vh.CantEstrella,vh.Recarga_Estrella


select * from TEAM_CASTY.vistaTOP5ConsumiblesFacturados

drop view TEAM_CASTY.vistaTOP5ConsumiblesFacturados

------------------------------------------------------------------------
CREATE FUNCTION dbo.cantidadDeDias (@pFecha_Inicio_Trimestre date,@pFecha_Fin_Trimestre date, @pFecha_Inicio_Inhabilitado date,@pFecha_Fin_Inhabilitad date )
RETURNS INTEGER 
AS
BEGIN
    RETURN ( CASE
                WHEN @pFecha_Inicio_Inhabilitado BETWEEN @pFecha_Inicio_Trimestre AND @pFecha_Fin_Trimestre AND @pFecha_Fin_Inhabilitad BETWEEN @pFecha_Inicio_Trimestre AND @pFecha_Fin_Trimestre THEN DATEDIFF(DAY,@pFecha_Inicio_Inhabilitado,@pFecha_Fin_Inhabilitad)
                WHEN @pFecha_Fin_Inhabilitad BETWEEN @pFecha_Inicio_Trimestre AND @pFecha_Fin_Trimestre THEN DATEDIFF(DAY,@pFecha_Inicio_Trimestre,@pFecha_Fin_Inhabilitad)
                WHEN @pFecha_Inicio_Inhabilitado BETWEEN @pFecha_Inicio_Trimestre AND @pFecha_Fin_Trimestre THEN DATEDIFF(DAY,@pFecha_Inicio_Inhabilitado,@pFecha_Fin_Trimestre) 
                ELSE  0
           END)
END




CREATE FUNCTION vistaTOP5CantidadDeDiasFueraDeServicio (@pFecha_Inicio date,@pFecha_Fin date)
RETURNS TABLE
AS
RETURN
select  top 5 h.Cod_Hotel, vh.Ciudad, vh.Calle, vh.Nro_Calle, vh.Telefono,  vh.Mail, vh.CantEstrella,vh.Recarga_Estrella,SUM(dbo.cantidadDeDias(@pFecha_Inicio, @pFecha_Fin,ph.Fecha_Inicio,ph.Fecha_Fin )) as "Total_Dias_Fuera_De_Servicio"
from TEAM_CASTY.vistaHoteles vh,TEAM_CASTY.Hotel h, TEAM_CASTY.Periodo_Inhabilitado ph 
group by h.Cod_Hotel, vh.Ciudad, vh.Calle, vh.Nro_Calle, vh.Telefono,  vh.Mail, vh.CantEstrella,vh.Recarga_Estrella
order by Total_Dias_Fuera_De_Servicio desc


------------------------------------------------------------------------------------

CREATE FUNCTION TEAM_CASTY.vistaTOP5HabitacionesHabitadas (@pFecha_Inicio date,@pFecha_Fin date)
RETURNS TABLE
AS
RETURN
select  top 5 vhxr.Cod_Hotel, vhxr.Numero, vhxr.Piso,hab.Frente, vhxr.Descripcion, vhxr.Tipo_De_Habitacion, vhxr.Porcentual ,SUM(dbo.cantidadDeDias(@pFecha_Inicio, @pFecha_Fin,vhxr.Fecha_Inicio,vhxr.Fecha_Salida )) as "Dias_Ocupada", COUNT (vhxr.Cod_Reserva) "Cantidad_De_Veces_Ocupada"
from TEAM_CASTY.vistaHabitacionesXReservas vhxr, TEAM_CASTY.vistaHoteles h
group by  vhxr.Cod_Hotel, vhxr.Numero, vhxr.Piso,hab.Frente, vhxr.Descripcion, vhxr.Tipo_De_Habitacion, vhxr.Porcentual
order by  Dias_Ocupada, Cantidad_De_Veces_Ocupada


--------------------------------------------------------------------

CREATE FUNCTION TEAM_CASTY.vistaTOP5HabitacionesHabitadas (@pFecha_Inicio date,@pFecha_Fin date)
RETURNS TABLE
AS
RETURN
select top 5
from TEAM_CASTY--- ID_Cliente_Reservador


