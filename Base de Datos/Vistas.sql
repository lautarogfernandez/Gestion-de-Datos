--vista cliente
create view TEAM_CASTY.vistaClientes
(Codigo, Nombre, Apellido, Mail, "Tipo Documento", "Numero Documento",Telefono,Pais,Localidad,"Calle","Numero Calle",Piso, "Departamento", Nacionalidad,"Fecha Nacimiento")
AS
select c.ID_Cliente, c.Nombre, c.Apellido, c.Mail, d.Tipo_Documento, c.Nro_Documento, c.Telefono, c.Pais, c.Localidad, c.Nom_Calle, c.Nro_Calle, c.Piso ,c.Dto,c.Nacionalidad, c.Fecha_Nacimiento
from TEAM_CASTY.Cliente c, TEAM_CASTY.Tipo_Documento d
where c.Baja=0

--SELECT * FROM TEAM_CASTY.vistaClientes
   
--Vista factura
--create view TEAM_CASTY.vistaFacturas
--([Numero Factura], Fecha, Total, [Forma de Pago], [Codigo de Estadia])
--AS
--select fac.Nro_Factura,fac.Fecha,fac.Total, fdp.Descripcion,fac.Cod_Estadia
--from TEAM_CASTY.Factura fac, TEAM_CASTY.Forma_Pago fdp
--where fac.Cod_Forma_Pago=fdp.Cod_Forma_Pago

--select * from TEAM_CASTY.vistaFacturas

  
-- vista habitaciones
create view TEAM_CASTY.vistaHabitaciones
(Codigo,Descripcion,Piso,Numero,Frente, Hotel,Ciudad,Calle,"Numero Calle", Tipo, "Descripcion de tipo",Porcentual)
AS
select hab.Cod_Habitacion,hab.Descripcion,hab.Piso,hab.Numero,hab.Frente,hab.Cod_Hotel, ciu.Nombre,hot.Calle,hot.Nro_Calle,thab.Cod_Tipo,thab.Descripcion ,thab.Porcentual
from TEAM_CASTY.Habitacion hab, TEAM_CASTY.Tipo_Habitacion thab, TEAM_CASTY.Hotel hot, TEAM_CASTY.Ciudad ciu
where hab.Baja = 0 and
hot.Cod_Hotel=hab.Cod_Hotel and
thab.Cod_Tipo=hab.Cod_Tipo and
ciu.Cod_Ciudad=hot.Cod_Ciudad

select * from TEAM_CASTY.vistaHabitaciones

   
-- vistas sobre reservas
Create view TEAM_CASTY.Vista_Reserva_Estado 
AS
select r.Cod_Reserva, r.ID_Cliente_Reservador,r.Cod_Regimen,r.Cod_Estado,e.Nombre as "Nombre_Estado",e.Descripcion as"Descripcion_Estado",r.Fecha_Reserva,r.Fecha_Inicio,r.Fecha_Salida,r.Cant_Noches
from TEAM_CASTY.Reserva r , TEAM_CASTY.Estados e
where r.Cod_Estado = e.Cod_Estado

select * from TEAM_CASTY.Vista_Reserva_Estado


Create view TEAM_CASTY.Vista_Reserva_Regimen
AS
select  r.Cod_Reserva, r.ID_Cliente_Reservador,r.Cod_Regimen,reg.Descripcion as "Descripcion_Regimen",reg.Precio as "Precio_Regimen",r.Cod_Estado,r.Fecha_Reserva,r.Fecha_Inicio,r.Fecha_Salida,r.Cant_Noches
from TEAM_CASTY.Reserva r, TEAM_CASTY.Regimen reg
where r.Cod_Regimen = reg.Cod_Regimen

select * from TEAM_CASTY.Vista_Reserva_Regimen


Create view TEAM_CASTY.vistaReservas(Codigo, "Cliente reservador", Regimen, "Precio Regimen", "Fecha de reserva", "Fecha de inicio", "Fecha de salida", "Cantidad de Noches" , Estado, "Descripcion de estado" )
as
select r.Cod_Reserva, r.ID_Cliente_Reservador,r.Descripcion_Regimen,r.Precio_Regimen,r.Fecha_Reserva,r.Fecha_Inicio, r.Fecha_Salida,r.Cant_Noches, e.Nombre_Estado, e.Descripcion_Estado
 from TEAM_CASTY.Vista_Reserva_Regimen r, TEAM_CASTY.Vista_Reserva_Estado e 
 where r.Cod_Reserva = e.Cod_Reserva

select * from TEAM_CASTY.vistaReservas
 

--vista hotel
create view TEAM_CASTY.vistaHoteles
(Codigo,Pais,Nombre,Ciudad,Calle,[Numero Calle],Telefono,Mail,[Fecha Creacion],[Cantidad de estrellas], [Recarga por estrella])
AS
select  h.Cod_Hotel, h.Pais,h.Nombre, c.Nombre ,h.Calle,h.Nro_Calle,h.Telefono,h.Mail,h.Fecha_Creacion,h.CantEstrella,re.Recarga  
from TEAM_CASTY.Hotel h, TEAM_CASTY.Ciudad c , TEAM_CASTY.Recarga_Estrella re
where h.Cod_Ciudad= c.Cod_Ciudad

GO

select * from TEAM_CASTY.vistaHoteles


 -- vista regimenes-hoteles  
create view TEAM_CASTY.vistaRegimenesXHoteles(Hotel,Ciudad,Calle,"Numero Calle","Cantidad de estrellas",Telefono,Mail, Regimen , "Precio Regimen")
AS  
select   h.Codigo,h.Ciudad,h.Calle,h.[Numero Calle],h.[Cantidad de estrellas],h.Telefono,h.Mail,r.Descripcion,r.Precio
from  TEAM_CASTY.vistaHoteles h, TEAM_CASTY.RegimenXHotel rxh , TEAM_CASTY.Regimen r
where h.Codigo = rxh.Cod_Hotel and rxh.Cod_Regimen = r.Cod_Regimen


select * 
from TEAM_CASTY.vistaRegimenesXHoteles


create view TEAM_CASTY.vistaHabitacionesXReservas(Reserva,Hotel, "Numero de habitacion", Piso, Frente, Tipo,"Descripcion de tipo", Porcentual)
AS  
select   r.Codigo,h.Hotel, h.Numero, h.Piso, h.Frente, h.Tipo, h.[Descripcion de tipo], h.Porcentual
from  TEAM_CASTY.vistaHabitaciones h, TEAM_CASTY.HabitacionXReserva  hxr , TEAM_CASTY.vistaReservas r
where h.Codigo = hxr.Cod_Habitacion and hxr.Cod_Reserva = r.Codigo

select * from TEAM_CASTY.vistaHabitacionesXReservas


-- vista ClienteXReserva
create view TEAM_CASTY.vistaClientesXReservas
AS  
select   c.Codigo, c.Nombre, c.Apellido, c.Mail, c.[Tipo Documento],c.[Numero Documento] ,c.Telefono,c.Pais,c.Localidad,c.Calle,c.[Numero Calle],c.Piso, c.Departamento, c.Nacionalidad,c.[Fecha Nacimiento],r.Codigo as "Reserva"
from  TEAM_CASTY.ClienteXReserva cxr, TEAM_CASTY.vistaClientes  c, TEAM_CASTY.vistaReservas r
where c.Codigo = cxr.ID_Cliente and cxr.Cod_Reserva = r.Codigo


select * from TEAM_CASTY.vistaClientesXReservas


--vista FuncionesXRol
create view TEAM_CASTY.vistasFuncionesXRol
AS  
select   r.*,f.*
from  TEAM_CASTY.FuncionXRol fxr, TEAM_CASTY.Rol  r, TEAM_CASTY.Funcion f
where fxr.Cod_Rol = r.Cod_Rol and f.Cod_Funcion = fxr.Cod_Funcion
select * from TEAM_CASTY.vistasFuncionesXRol


--vista ConsumibleXHabitacionXReserva
create view TEAM_CASTY.vistaConsumibleXHabitacionXReserva
AS  
select   c.Cod_Consumible,c.Descripciona as "Descripcion_Consumible", c.Precio as "Precio_Consumible",vhxr.*
from  TEAM_CASTY.ConsumibleXHabitacionXReserva,TEAM_CASTY.Consumible c, TEAM_CASTY.vistaHabitacionesXReservas vhxr


select * from TEAM_CASTY.vistaConsumibleXHabitacionXReserva


--drop de las vistas
drop view TEAM_CASTY.vistaClientes
drop view TEAM_CASTY.vistaFacturas
drop view TEAM_CASTY.vistaHabitaciones
drop view TEAM_CASTY.Vista_Reserva_Estado
drop view TEAM_CASTY.Vista_Reserva_Regimen
drop view TEAM_CASTY.vistaReservas 
drop view TEAM_CASTY.vistaHoteles
drop view  TEAM_CASTY.vistaRegimenesXHoteles 
drop view  TEAM_CASTY.vistaHabitacionesXReservas
drop view TEAM_CASTY.vistaClientesXReservas
drop view TEAM_CASTY.vistasFuncionesXRol
drop view TEAM_CASTY.vistaConsumibleXHabitacionXReserva







---------------------------------------------------------------------------------------------------------------------
--LISTADOS
 ---- agregar resto de campos en select y en group by
-----------------------------------------------------------------------------------------------------------------------------------
CREATE FUNCTION vistaTOP5ReservasCanceladas (@pFecha_Inicio date,@pFecha_Fin date)
RETURNS TABLE
AS
RETURN 
   select  top 5 vh.Codigo, vh.Ciudad, vh.Calle,vh.[Numero Calle], vh.Telefono, vh.Mail, vh.[Cantidad de estrellas], vh.[Recarga por estrella], count (distinct r.Cod_Reserva)  as "Cantidad Reservas Canceladas"
   from TEAM_CASTY.vistaHoteles vh, TEAM_CASTY.HabitacionXReserva hxr,TEAM_CASTY.Reserva r ,TEAM_CASTY.Habitacion hab, TEAM_CASTY.Estados e
   where vh.Codigo = hab.Cod_Hotel and hab.Cod_Habitacion= hxr.Cod_Habitacion and r.Cod_Reserva= hxr.Cod_Reserva
       and  r.Cod_Estado= e.Cod_Estado and e.Nombre  = 'Cancelada' and r.Fecha_Reserva between @pFecha_Inicio and @pFecha_Fin
   group by vh.Codigo, vh.Ciudad, vh.Calle,vh.[Numero Calle], vh.Telefono, vh.Mail, vh.[Cantidad de estrellas], vh.[Recarga por estrella]
   order by [Cantidad Reservas Canceladas] desc

   SELECT * FROM   vistaTOP5ReservasCanceladas('2013-01-01 00:00:00.000','2024-12-28 00:00:00.000')

drop function vistaTOP5ReservasCanceladas

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
   select  top 5  vh.Codigo, vh.Ciudad, vh.Calle,vh.[Numero Calle], vh.Telefono, vh.Mail, vh.[Cantidad de estrellas], vh.[Recarga por estrella], Sum (CxHxE.Cantidad) as "Cantidad Consumibles" 
from TEAM_CASTY.vistaHoteles vh,TEAM_CASTY.Habitacion hab, TEAM_CASTY.ConsumibleXHabitacionXEstadia CxHxE, TEAM_CASTY.Factura f
where vh.Codigo = hab.Cod_Hotel and hab.Cod_Habitacion=CxHxE.Cod_Habitacion  and  f.Cod_Estadia = CxHxE.Cod_Estadia 
       and f.Fecha between @pFecha_Inicio and @pFecha_Fin
group by  vh.Codigo, vh.Ciudad, vh.Calle,vh.[Numero Calle], vh.Telefono, vh.Mail, vh.[Cantidad de estrellas], vh.[Recarga por estrella]
order by [Cantidad Consumibles] desc

drop function vistaTOP5ConsumiblesFacturados

SELECT * FROM vistaTOP5ConsumiblesFacturados('2013-01-01 00:00:00.000','2013-12-28 00:00:00.000')


--vista que no sirve
create view TEAM_CASTY.vistaTOP5ConsumiblesFacturados
as 
select  top 5 h.Cod_Hotel, vh.Ciudad, vh.Calle, vh.Nro_Calle, vh.Telefono,  vh.Mail, vh.CantEstrella,vh.Recarga_Estrella, Sum (vCxHxR.Cantidad) as "Cantidad_Consumibles" 
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
select  top 5 vh.Codigo, vh.Ciudad, vh.Calle,vh.[Numero Calle], vh.Telefono, vh.Mail, vh.[Cantidad de estrellas], vh.[Recarga por estrella],SUM(dbo.cantidadDeDias(@pFecha_Inicio, @pFecha_Fin,ph.Fecha_Inicio,ph.Fecha_Fin )) as "Total Dias Fuera De Servicio"
from TEAM_CASTY.vistaHoteles vh, TEAM_CASTY.Periodo_Inhabilitado ph 
where vh.Codigo = ph.Cod_Hotel and dbo.cantidadDeDias(@pFecha_Inicio, @pFecha_Fin,ph.Fecha_Inicio,ph.Fecha_Fin ) >0
group by vh.Codigo, vh.Ciudad, vh.Calle,vh.[Numero Calle], vh.Telefono, vh.Mail, vh.[Cantidad de estrellas], vh.[Recarga por estrella]
order by [Total Dias Fuera De Servicio] desc



SELECT * FROM vistaTOP5CantidadDeDiasFueraDeServicio('2013-01-01 00:00:00.000','2024-12-28 00:00:00.000')

drop function vistaTOP5CantidadDeDiasFueraDeServicio
------------------------------------------------------------------------------------

CREATE FUNCTION vistaTOP5HabitacionesHabitadas (@pFecha_Inicio date,@pFecha_Fin date)
RETURNS TABLE
AS
RETURN
select  top 5 vhab.Codigo, vhab.Hotel, vhab.Numero, vhab.Piso,vhab.Frente, vhab.Tipo,vhab.[Descripcion de tipo], vhab.Porcentual ,SUM(dbo.cantidadDeDias(@pFecha_Inicio, @pFecha_Fin,est.Fecha_Inicio,est.Fecha_Salida )) as "Dias Ocupada", COUNT (est.Cod_Estadia) as "Cantidad De Veces Ocupada"
from TEAM_CASTY.vistaHabitaciones vhab,TEAM_CASTY.HabitacionXEstadia habxest, TEAM_CASTY.Estadia est
where vhab.Codigo = habxest.Cod_Habitacion   and est.Cod_Estadia=habxest.Cod_Estadia and  dbo.cantidadDeDias(@pFecha_Inicio, @pFecha_Fin,est.Fecha_Inicio,est.Fecha_Salida) >0
group by  vhab.Codigo, vhab.Hotel, vhab.Numero, vhab.Piso,vhab.Frente, vhab.Tipo,vhab.[Descripcion de tipo], vhab.Porcentual
order by  [Dias Ocupada] desc, [Cantidad De Veces Ocupada] desc


SELECT * FROM vistaTOP5HabitacionesHabitadas('2013-01-01 00:00:00.000','2013-01-28 00:00:00.000')

drop function vistaTOP5HabitacionesHabitadas
--------------------------------------------------------------------

CREATE FUNCTION vistaTOP5ClienteConPuntos (@pFecha_Inicio date,@pFecha_Fin date)
RETURNS TABLE
AS
RETURN 
select top 5 vc.Codigo,vc.Nombre,vc.Apellido,vc.Mail, vc.[Tipo Documento], vc.[Numero Documento], vc.Telefono, vc.Pais, vc.Localidad, vc.Calle, vc.[Numero Calle], vc.Piso, vc.Departamento, vc.Nacionalidad, vc.[Fecha Nacimiento] , sum(CxHxE.Precio)/5 as puntos
from TEAM_CASTY.Factura f,TEAM_CASTY.Estadia e,TEAM_CASTY.Reserva r , TEAM_CASTY.ConsumibleXHabitacionXEstadia CxHxE, TEAM_CASTY.vistaClientes vc--- ID_Cliente_Reservador
where f.Cod_Estadia = e.Cod_Estadia and r.Cod_Reserva = e.Cod_Reserva and CxHxE.Cod_Estadia = e.Cod_Estadia and vc.Codigo = r.ID_Cliente_Reservador
group by  vc.Codigo,vc.Nombre,vc.Apellido,vc.Mail, vc.[Tipo Documento], vc.[Numero Documento], vc.Telefono, vc.Pais, vc.Localidad, vc.Calle, vc.[Numero Calle], vc.Piso, vc.Departamento, vc.Nacionalidad, vc.[Fecha Nacimiento] 
order by puntos desc


SELECT * FROM vistaTOP5ClienteConPuntos('2013-01-01 ','2024-12-28')

drop function vistaTOP5ClienteConPuntos


Cliente con mayor cantidad de puntos, donde cada $10 en estadías vale 1 puntos y cada $5 de consumibles es 1 punto,
 de la sumatoria de todas las facturaciones que haya tenido dentro de un periodo independientemente del Hotel. 
 Tener en cuenta que la facturación siempre es a quien haya realizado la reserva.

