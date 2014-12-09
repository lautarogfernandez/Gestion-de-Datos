--hoteles (el recargo por estrella es el mismo)
SELECT DISTINCT t1.Hotel_Ciudad, t1.Hotel_Calle, t1.Hotel_Nro_Calle, t1.Hotel_CantEstrella, t1.Hotel_Recarga_Estrella
FROM gd_esquema.Maestra t1
ORDER BY t1.Hotel_Ciudad, t1.Hotel_Calle, t1.Hotel_Nro_Calle

--ciudades
SELECT DISTINCT t1.Hotel_Ciudad
FROM gd_esquema.Maestra t1
ORDER BY t1.Hotel_Ciudad

--regimenes
SELECT DISTINCT t1.Regimen_Descripcion, t1.Regimen_Precio
FROM gd_esquema.Maestra t1
ORDER BY t1.Regimen_Descripcion

--clientes
SELECT DISTINCT t1.Cliente_Pasaporte_Nro, t1.Cliente_Nombre, t1.Cliente_Apellido
INTO #todos_los_clientes
FROM gd_esquema.Maestra t1

SELECT *
FROM #todos_los_clientes
ORDER BY 1,3,2

SELECT #todos_los_clientes.Cliente_Pasaporte_Nro
INTO #clientes_repetidos
FROM #todos_los_clientes
group BY #todos_los_clientes.Cliente_Pasaporte_Nro
having COUNT(#todos_los_clientes.Cliente_Pasaporte_Nro)>1

SELECT *
FROM #clientes_repetidos
ORDER BY 1

SELECT t2.Cliente_Pasaporte_Nro, t2.Cliente_Apellido, t2.Cliente_Nombre
FROM #clientes_repetidos t1, #todos_los_clientes t2
WHERE t2.Cliente_Pasaporte_Nro=t1.Cliente_Pasaporte_Nro
ORDER BY 1,2,3

--todos los clientes con datos completos
SELECT distinct t2.Cliente_Pasaporte_Nro, t2.Cliente_Apellido, t2.Cliente_Nombre, t2.Cliente_Fecha_Nac, t2.Cliente_Mail, t2.Cliente_Dom_Calle, t2.Cliente_Nro_Calle, t2.Cliente_Piso , t2.Cliente_Depto, t2.Cliente_Nacionalidad
FROM #todos_los_clientes t1, gd_esquema.Maestra t2
WHERE t2.Cliente_Pasaporte_Nro=t1.Cliente_Pasaporte_Nro
ORDER BY 1,2,3

SELECT distinct t2.Cliente_Pasaporte_Nro, t2.Cliente_Apellido, t2.Cliente_Nombre, t2.Cliente_Fecha_Nac, t2.Cliente_Mail, t2.Cliente_Dom_Calle, t2.Cliente_Nro_Calle, t2.Cliente_Piso , t2.Cliente_Depto, t2.Cliente_Nacionalidad
FROM (SELECT DISTINCT t1.Cliente_Pasaporte_Nro, t1.Cliente_Nombre, t1.Cliente_Apellido
	  FROM gd_esquema.Maestra t1) t3, 
	  gd_esquema.Maestra t2
WHERE t2.Cliente_Pasaporte_Nro=t3.Cliente_Pasaporte_Nro
ORDER BY t2.Cliente_Pasaporte_Nro, t2.Cliente_Apellido, t2.Cliente_Nombre

--consumibles
SELECT DISTINCT t1.Consumible_Codigo, t1.Consumible_Descripcion, t1.Consumible_Precio
FROM gd_esquema.Maestra t1
WHERE t1.Consumible_Codigo IS NOT NULL
ORDER BY t1.Consumible_Codigo

--tipos de habitaciones
SELECT DISTINCT t1.Habitacion_Tipo_Codigo, t1.Habitacion_Tipo_Descripcion, t1.Habitacion_Tipo_Porcentual
FROM gd_esquema.Maestra t1
ORDER BY t1.Habitacion_Tipo_Codigo

--habitaciones
SELECT DISTINCT t1.Hotel_Ciudad, t1.Hotel_Calle, t1.Hotel_Nro_Calle, t1.Habitacion_Piso, t1.Habitacion_Numero, t1.Habitacion_Frente, t1.Habitacion_Tipo_Codigo
FROM gd_esquema.Maestra t1
ORDER BY t1.Hotel_Ciudad, t1.Hotel_Calle, t1.Hotel_Nro_Calle, t1.Habitacion_Piso, t1.Habitacion_Numero, t1.Habitacion_Frente

SELECT DISTINCT t1.Hotel_Ciudad, t1.Hotel_Calle, t1.Hotel_Nro_Calle, t1.Habitacion_Piso, t1.Habitacion_Numero, t1.Habitacion_Frente
FROM gd_esquema.Maestra t1 
ORDER BY t1.Hotel_Ciudad, t1.Hotel_Calle, t1.Hotel_Nro_Calle, t1.Habitacion_Piso, t1.Habitacion_Numero, t1.Habitacion_Frente


--reservas
select distinct t1.Reserva_Codigo, t1.Reserva_Fecha_Inicio, t1.Reserva_Cant_Noches, t1.Cliente_Pasaporte_Nro,t1.Cliente_Apellido, t1.Cliente_Nombre, t1.Hotel_Ciudad, t1.Hotel_Calle, t1.Hotel_Nro_Calle, t1.Regimen_Descripcion
into #reservas
FROM gd_esquema.Maestra t1
order by 1

--select * from #reservas order by 1

select distinct res.Reserva_Codigo,res.Reserva_Fecha_Inicio,res.Reserva_Cant_Noches,h.Cod_Hotel,reg.Cod_Regimen, c.ID_Cliente
into #reservas_new
FROM TEAM_CASTY.Ciudad ciu, TEAM_CASTY.Cliente c, TEAM_CASTY.Hotel h, #reservas res, TEAM_CASTY.Regimen reg
where
ciu.Nombre=res.Hotel_Ciudad and
h.Calle=res.Hotel_Calle and
h.Cod_Ciudad=ciu.Cod_Ciudad and
h.Nro_Calle=res.Hotel_Nro_Calle and
c.Nro_Documento=res.Cliente_Pasaporte_Nro and
c.Apellido=res.Cliente_Apellido and
c.Nombre=res.Cliente_Nombre and
reg.Descripcion=res.Regimen_Descripcion
order by 1

--select * from #reservas_new

select distinct t1.Reserva_Codigo
into #todas_reservas
FROM gd_esquema.Maestra t1
order by 1

--select * from #todas_reservas order by 1

select distinct t1.Reserva_Codigo
into #reservas_efectivas
FROM gd_esquema.Maestra t1
where t1.Factura_Total is not null
order by 1

--select * from #reservas_efectivas order by 1

select distinct t1.Reserva_Codigo
into #reservas_canceladas_NoShow
FROM #todas_reservas t1
where t1.Reserva_Codigo not in (select distinct t2.Reserva_Codigo
							   FROM #reservas_efectivas t2)
order by 1

--select * from #reservas_canceladas_NoShow order by 1

select distinct t1.Reserva_Codigo,t1.Reserva_Fecha_Inicio,t1.Reserva_Cant_Noches,t1.Cod_Hotel,t1.Cod_Regimen, t1.ID_Cliente, 6 AS 'Cod_Estado'
FROM #reservas_new t1
where t1.Reserva_Codigo in (select res.Reserva_Codigo
							from #reservas_efectivas res)
order by t1.Reserva_Codigo

select distinct t1.Reserva_Codigo,t1.Reserva_Fecha_Inicio,t1.Reserva_Cant_Noches,t1.Cod_Hotel,t1.Cod_Regimen, t1.ID_Cliente, 5 AS 'Cod_Estado'	
FROM #reservas_new t1
where t1.Reserva_Codigo in (select res.Reserva_Codigo
							from #reservas_canceladas_NoShow res)
order by t1.Reserva_Codigo

drop table #reservas
drop table #reservas_new
drop table #todas_reservas
drop table #reservas_efectivas
drop table #reservas_canceladas_NoShow

--habiacionesXreserva
SELECT DISTINCT t1.Reserva_Codigo, hab.Cod_Habitacion
FROM gd_esquema.Maestra t1, TEAM_CASTY.Hotel h, TEAM_CASTY.Ciudad ciu, TEAM_CASTY.Habitacion hab
WHERE hab.Cod_Tipo=t1.Habitacion_Tipo_Codigo AND
	  hab.Frente=t1.Habitacion_Frente AND
	  t1.Habitacion_Numero=hab.Numero AND
	  t1.Habitacion_Piso=hab.Piso AND
	  h.Cod_Hotel=hab.Cod_Hotel AND
	  h.Cod_Ciudad=ciu.Cod_Ciudad AND
	  t1.Hotel_Calle=h.Calle AND
	  t1.Hotel_Nro_Calle= h.Nro_Calle AND
	  ciu.Nombre=t1.Hotel_Ciudad AND
	  ciu.Cod_Ciudad=h.Cod_Ciudad
ORDER BY t1.Reserva_Codigo


SELECT distinct t1.Reserva_Codigo, t1.Hotel_Ciudad, t1.Hotel_Calle, t1.Hotel_Nro_Calle, t1.Habitacion_Piso, Habitacion_Numero, Habitacion_Tipo_Codigo, t1.Habitacion_Frente
FROM gd_esquema.Maestra t1
ORDER BY t1.Reserva_Codigo


SELECT MIN(t1.Reserva_Codigo)
FROM gd_esquema.Maestra t1

--clientes x reserva
SELECT DISTINCT t1.Reserva_Codigo, c.ID_Cliente
FROM gd_esquema.Maestra t1, TEAM_CASTY.Cliente c, TEAM_CASTY.Reserva r
WHERE 
t1.Cliente_Apellido=c.Apellido and
t1.Cliente_Nombre=c.Nombre and
t1.Cliente_Pasaporte_Nro=c.Nro_Documento and
r.Cod_Reserva=t1.Reserva_Codigo
ORDER BY t1.Reserva_Codigo, c.ID_Cliente

--items facturas rey
select  Factura_Nro ,'Consumible' as "Tipo_Item"  ,Consumible_Codigo  as "Codigo"
from gd_esquema.Maestra
where Consumible_Codigo is not null and Factura_Nro is not null
UNION all
select Factura_Nro , 'Estadia' as "Tipo_Item",Reserva_Codigo  as "Codigo"
from gd_esquema.Maestra
where Consumible_Codigo is null and Factura_Nro is not null
order by Factura_Nro,2,3

--facturas
SELECT DISTINCT t1.Factura_Nro, t1.Factura_Fecha, t1.Factura_Total
INTO #numeros_facturas
FROM gd_esquema.Maestra t1
WHERE t1.Factura_Nro IS NOT NULL
ORDER BY t1.Factura_Nro

SELECT *
FROM #numeros_facturas

SELECT DISTINCT t1.Factura_Nro, t1.Item_Factura_Cantidad, t1.Item_Factura_Monto
FROM gd_esquema.Maestra t1 JOIN #numeros_facturas t2 ON (t1.Factura_Nro=t2.Factura_Nro)
ORDER BY t1.Factura_Nro, t1.Item_Factura_Cantidad, t1.Item_Factura_Monto

--para probar el monto de facturas
select *
from gd_esquema.Maestra
where Consumible_Codigo is null and Factura_Nro is not null

select t1.Habitacion_Tipo_Descripcion,t1.Habitacion_Tipo_Porcentual,t1.Consumible_Descripcion,t1.Consumible_Precio,t1.Regimen_Descripcion,t1.Regimen_Precio,t1.Estadia_Cant_Noches,t1.Hotel_CantEstrella,t1.Hotel_Recarga_Estrella,t1.Item_Factura_Cantidad,t1.Item_Factura_Monto,t1.Factura_Nro,t1.Factura_Total
from gd_esquema.Maestra t1
where t1.Reserva_Codigo=10329

select f.*
from TEAM_CASTY.Factura f
where f.Cod_Reserva=10329

--para boludear
SELECT MAX(t1.Cliente_Piso)
FROM gd_esquema.Maestra t1

SELECT MIN(t1.Cliente_Fecha_Nac)
FROM gd_esquema.Maestra t1

SELECT MAX(t1.Cliente_Fecha_Nac)
FROM gd_esquema.Maestra t1

SELECT DISTINCT t1.Reserva_Codigo
FROM gd_esquema.Maestra t1
ORDER BY 1

select *
from gd_esquema.Maestra t1
where t1.Estadia_Cant_Noches>t1.Reserva_Cant_Noches or t1.Estadia_Cant_Noches<t1.Reserva_Cant_Noches
order by t1.Reserva_Codigo

select distinct t1.Reserva_Codigo, t1.Reserva_Cant_Noches, t1.Habitacion_Tipo_Porcentual, t1.Hotel_CantEstrella, t1.Item_Factura_Cantidad, t1.Item_Factura_Monto, t1.Factura_Total, t1.Regimen_Descripcion, t1.Regimen_Precio
from gd_esquema.Maestra t1
where t1.Item_Factura_Cantidad is not null
order by 1,2,3,4,5,6,7,8,9

select *
from gd_esquema.Maestra t1
where t1.Reserva_Codigo=10010

select distinct t1.Cliente_Dom_Calle from gd_esquema.Maestra t1

select Habitacion_Numero, Habitacion_Piso, Reserva_Codigo, Reserva_Fecha_Inicio, Reserva_Cant_Noches, Hotel_Calle, Hotel_Ciudad, Hotel_Nro_Calle
 from gd_esquema.Maestra
 group by Habitacion_Numero, Habitacion_Piso, Reserva_Codigo, Reserva_Fecha_Inicio, Reserva_Cant_Noches, Hotel_Calle, Hotel_Ciudad, Hotel_Nro_Calle
 order by  Habitacion_Numero, Habitacion_Piso, Reserva_Codigo, Reserva_Fecha_Inicio, Reserva_Cant_Noches, Hotel_Calle, Hotel_Ciudad, Hotel_Nro_Calle
 
 select MAX(m.Reserva_Codigo) from gd_esquema.Maestra m
select MAX(m.Factura_Fecha) from gd_esquema.Maestra m

select MAX(e.Fecha_Salida) from TEAM_CASTY.Estadia e
select MAX(f.Fecha) from TEAM_CASTY.Factura f

--consulta genérica
SELECT *
FROM gd_esquema.Maestra t1
where t1.Item_Factura_Cantidad is not null

SELECT *
FROM gd_esquema.Maestra