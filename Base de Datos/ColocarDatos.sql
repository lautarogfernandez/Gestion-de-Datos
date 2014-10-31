--Esquema
USE [GD2C2014]
GO
CREATE SCHEMA [TEAM_CASTY] AUTHORIZATION [gd]
GO

--Roles
CREATE TABLE TEAM_CASTY.Rol ( 
	Cod_Rol numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Nombre nvarchar(255) NOT NULL,
	Activo bit DEFAULT 1 NOT NULL);
	
INSERT INTO TEAM_CASTY.Rol (Nombre, Activo) VALUES ('Administrador',1);
INSERT INTO TEAM_CASTY.Rol (Nombre, Activo) VALUES ('Recepcionista',1);
INSERT INTO TEAM_CASTY.Rol (Nombre, Activo) VALUES ('Guest',1);

SELECT * FROM TEAM_CASTY.Rol

--Funciones
CREATE TABLE TEAM_CASTY.Funcion ( 
	Cod_Funcion numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Descripcion nvarchar(255) NOT NULL);	
	
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('ABM de Rol');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('ABM de Usuario');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('ABM de Cliente');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('ABM de Hotel');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('ABM de Habitación');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('ABM Régimen de Estadía');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('Generar o Modificar un Reserva');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('Cancelar Reserva');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('Registrar Estadía');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('Registrar Consumibles');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('Facturar Estadía');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('Listado Estadístico');

SELECT * FROM TEAM_CASTY.Funcion

--FuncionesXRol
CREATE TABLE TEAM_CASTY.FuncionXRol ( 
	Cod_Rol numeric(18) NOT NULL,
	Cod_Funcion numeric(18) NOT NULL,
	PRIMARY KEY (Cod_Rol, Cod_Funcion),
	FOREIGN KEY (Cod_Funcion) REFERENCES TEAM_CASTY.Funcion (Cod_Funcion),
	FOREIGN KEY (Cod_Rol) REFERENCES TEAM_CASTY.Rol (Cod_Rol));
	
INSERT INTO TEAM_CASTY.FuncionXRol(Cod_Rol,Cod_Funcion) VALUES (1,1);
INSERT INTO TEAM_CASTY.FuncionXRol(Cod_Rol,Cod_Funcion) VALUES (1,2);
INSERT INTO TEAM_CASTY.FuncionXRol(Cod_Rol,Cod_Funcion) VALUES (1,3);
INSERT INTO TEAM_CASTY.FuncionXRol(Cod_Rol,Cod_Funcion) VALUES (1,4);
INSERT INTO TEAM_CASTY.FuncionXRol(Cod_Rol,Cod_Funcion) VALUES (1,5);
INSERT INTO TEAM_CASTY.FuncionXRol(Cod_Rol,Cod_Funcion) VALUES (1,6);
INSERT INTO TEAM_CASTY.FuncionXRol(Cod_Rol,Cod_Funcion) VALUES (1,7);
INSERT INTO TEAM_CASTY.FuncionXRol(Cod_Rol,Cod_Funcion) VALUES (1,8);
INSERT INTO TEAM_CASTY.FuncionXRol(Cod_Rol,Cod_Funcion) VALUES (1,9);
INSERT INTO TEAM_CASTY.FuncionXRol(Cod_Rol,Cod_Funcion) VALUES (1,10);
INSERT INTO TEAM_CASTY.FuncionXRol(Cod_Rol,Cod_Funcion) VALUES (1,11);
INSERT INTO TEAM_CASTY.FuncionXRol(Cod_Rol,Cod_Funcion) VALUES (1,12);
INSERT INTO TEAM_CASTY.FuncionXRol(Cod_Rol,Cod_Funcion) VALUES (2,3);
INSERT INTO TEAM_CASTY.FuncionXRol(Cod_Rol,Cod_Funcion) VALUES (2,7);
INSERT INTO TEAM_CASTY.FuncionXRol(Cod_Rol,Cod_Funcion) VALUES (2,8);
INSERT INTO TEAM_CASTY.FuncionXRol(Cod_Rol,Cod_Funcion) VALUES (2,9);
INSERT INTO TEAM_CASTY.FuncionXRol(Cod_Rol,Cod_Funcion) VALUES (2,10);
INSERT INTO TEAM_CASTY.FuncionXRol(Cod_Rol,Cod_Funcion) VALUES (2,11);
INSERT INTO TEAM_CASTY.FuncionXRol(Cod_Rol,Cod_Funcion) VALUES (3,7);
INSERT INTO TEAM_CASTY.FuncionXRol(Cod_Rol,Cod_Funcion) VALUES (3,8);

SELECT * FROM TEAM_CASTY.FuncionXRol

--Regimenes
CREATE TABLE TEAM_CASTY.Regimen ( 
	Cod_Regimen numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Descripcion nvarchar(255) NOT NULL,
	Precio numeric(18,2) NOT NULL);
	
INSERT INTO TEAM_CASTY.Regimen SELECT DISTINCT t1.Regimen_Descripcion, t1.Regimen_Precio
							   FROM gd_esquema.Maestra t1
							   ORDER BY t1.Regimen_Descripcion
														   
SELECT * FROM TEAM_CASTY.Regimen

--Tipos de Habitaciones
CREATE TABLE TEAM_CASTY.Tipo_Habitacion ( 
	Cod_Tipo numeric(18) NOT NULL PRIMARY KEY,
	Descripcion nvarchar(255) NOT NULL,
	Porcentual numeric(18,2) NOT NULL);

INSERT INTO TEAM_CASTY.Tipo_Habitacion SELECT DISTINCT t1.Habitacion_Tipo_Codigo, t1.Habitacion_Tipo_Descripcion, t1.Habitacion_Tipo_Porcentual
							   FROM gd_esquema.Maestra t1
							   ORDER BY t1.Habitacion_Tipo_Codigo
							   
SELECT * FROM TEAM_CASTY.Tipo_Habitacion

--Recarga Estrella
CREATE TABLE TEAM_CASTY.Recarga_Estrella ( 
	Cod_Recarga numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Fecha_Modificacion datetime NOT NULL,
	Recarga numeric(18) NOT NULL);
	
DECLARE @fecha_modificacion datetime;
DECLARE @recarga numeric(18);
SET @fecha_modificacion= (SELECT MIN(t1.Reserva_Fecha_Inicio) FROM gd_esquema.Maestra t1);
SET @recarga= (SELECT DISTINCT t1.Hotel_Recarga_Estrella FROM gd_esquema.Maestra t1);
INSERT INTO TEAM_CASTY.Recarga_Estrella(Fecha_Modificacion,Recarga) VALUES (@fecha_modificacion, @recarga);

--Ciudades
CREATE TABLE TEAM_CASTY.Ciudad (
	Cod_Ciudad numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Nombre nvarchar(255) NOT NULL);
	
INSERT INTO TEAM_CASTY.Ciudad SELECT DISTINCT t1.Hotel_Ciudad
							  FROM gd_esquema.Maestra t1
							  ORDER BY t1.Hotel_Ciudad

SELECT * FROM TEAM_CASTY.Ciudad

--Hoteles
CREATE TABLE TEAM_CASTY.Hotel ( 
	Cod_Ciudad numeric(18) NOT NULL,
	Calle nvarchar(255) NOT NULL,
	Nro_Calle numeric(18) NOT NULL,
	CantEstrella numeric(18) NOT NULL,	
	Cod_Hotel numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Fecha_Creacion datetime,
	Telefono nvarchar(50),
	Mail nvarchar(255),
	FOREIGN KEY (Cod_Ciudad) REFERENCES TEAM_CASTY.Ciudad (Cod_Ciudad));

INSERT INTO TEAM_CASTY.Hotel (Cod_Ciudad, Calle, Nro_Calle, CantEstrella) SELECT DISTINCT TEAM_CASTY.Ciudad.Cod_Ciudad, t1.Hotel_Calle, t1.Hotel_Nro_Calle, t1.Hotel_CantEstrella
																						    FROM gd_esquema.Maestra t1 JOIN TEAM_CASTY.Ciudad ON (TEAM_CASTY.Ciudad.Nombre=t1.Hotel_Ciudad)
																							ORDER BY TEAM_CASTY.Ciudad.Cod_Ciudad, t1.Hotel_Calle, t1.Hotel_Nro_Calle

SELECT * FROM TEAM_CASTY.Hotel

SELECT Cod_Hotel, Nombre,Calle, Nro_Calle, CantEstrella, Fecha_Creacion, Telefono, Mail
FROM TEAM_CASTY.Hotel h JOIN TEAM_CASTY.Ciudad c ON (c.Cod_Ciudad=h.Cod_Ciudad)
ORDER by Cod_Hotel

--Regimenes por Hotel
CREATE TABLE TEAM_CASTY.RegimenXHotel ( 
	Cod_Hotel numeric(18) NOT NULL,
	Cod_Regimen numeric(18) NOT NULL,
	Activo bit NOT NULL DEFAULT 1,
	PRIMARY KEY (Cod_Hotel, Cod_Regimen),
	FOREIGN KEY (Cod_Hotel) REFERENCES TEAM_CASTY.Hotel (Cod_Hotel),
	FOREIGN KEY (Cod_Regimen) REFERENCES TEAM_CASTY.Regimen (Cod_Regimen));

INSERT INTO TEAM_CASTY.RegimenXHotel (Cod_Hotel, Cod_Regimen) SELECT DISTINCT h.Cod_Hotel, r.Cod_Regimen
															  FROM gd_esquema.Maestra t1, TEAM_CASTY.Hotel h, TEAM_CASTY.Ciudad c, TEAM_CASTY.Regimen r
															  where t1.Hotel_Calle=h.Calle and
															  t1.Hotel_Nro_Calle=h.Nro_Calle and
															  c.Cod_Ciudad=h.Cod_Ciudad and
															  t1.Hotel_Ciudad=c.Nombre and
															  t1.Regimen_Descripcion=r.Descripcion
															  ORDER by h.Cod_Hotel, r.Cod_Regimen
															  
SELECT * FROM TEAM_CASTY.RegimenXHotel

SELECT c.Nombre, h.Calle, h.Nro_Calle, h.Mail, h.Telefono, r.Descripcion, r.Precio 
FROM TEAM_CASTY.RegimenXHotel rxh, TEAM_CASTY.Ciudad c, TEAM_CASTY.Hotel h, TEAM_CASTY.Regimen r
where rxh.Cod_Hotel=h.Cod_Hotel and
c.Cod_Ciudad=h.Cod_Ciudad and
r.Cod_Regimen=rxh.Cod_Regimen
ORDER by 1,2,3,4,5,6,7
	
--Habitaciones
CREATE TABLE TEAM_CASTY.Habitacion ( 
	Cod_Habitacion numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Numero numeric(18) NOT NULL,
	Cod_Hotel numeric(18) NOT NULL,
	Piso numeric(18) NOT NULL,
	Frente nvarchar(50) NOT NULL,
	Descripcion varchar(255),
	Cod_Tipo numeric(18) NOT NULL,
	Baja bit NOT NULL DEFAULT 0,
	FOREIGN KEY (Cod_Hotel) REFERENCES TEAM_CASTY.Hotel (Cod_Hotel),
	FOREIGN KEY (Cod_Tipo) REFERENCES TEAM_CASTY.Tipo_Habitacion (Cod_Tipo));

INSERT INTO TEAM_CASTY.Habitacion (Cod_Hotel,Piso, Numero,Frente,Cod_Tipo) SELECT DISTINCT h.Cod_Hotel, t1.Habitacion_Piso, t1.Habitacion_Numero, t1.Habitacion_Frente, t1.Habitacion_Tipo_Codigo
																		   FROM gd_esquema.Maestra t1 join TEAM_CASTY.Hotel h on (h.Calle=t1.Hotel_Calle AND h.Nro_Calle=t1.Hotel_Nro_Calle)
																									  join TEAM_CASTY.Ciudad c on(c.Cod_Ciudad=h.Cod_Ciudad AND t1.Hotel_Ciudad=c.Nombre)
																		   ORDER BY h.Cod_Hotel, t1.Habitacion_Piso, t1.Habitacion_Numero, t1.Habitacion_Tipo_Codigo

SELECT * FROM TEAM_CASTY.Habitacion																		   

SELECT hab.Cod_Habitacion, h.Cod_Hotel, Nombre,Calle, Nro_Calle, Piso, Numero, Frente, hab.Descripcion, t.Descripcion
FROM  TEAM_CASTY.Habitacion	hab JOIN TEAM_CASTY.Hotel h ON (hab.Cod_Hotel=h.Cod_Hotel)
								JOIN TEAM_CASTY.Ciudad c ON (c.Cod_Ciudad=h.Cod_Ciudad)
								JOIN TEAM_CASTY.Tipo_Habitacion t ON (hab.Cod_Tipo=t.Cod_Tipo)
ORDER by h.Cod_Hotel, Nombre,Calle, Nro_Calle, Piso, Numero, Frente

--Estados
CREATE TABLE TEAM_CASTY.Estados ( 
	Cod_Estado numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Descripcion nvarchar(255),
	Nombre nvarchar(255) NOT NULL UNIQUE);
	
INSERT INTO TEAM_CASTY.Estados(Nombre,Descripcion) VALUES ('Correcta','Reserva correcta');
INSERT INTO TEAM_CASTY.Estados(Nombre,Descripcion) VALUES ('Modificada','Reserva modificada (la misma sufrió algún cambio y no es la misma al momento de su creación)');
INSERT INTO TEAM_CASTY.Estados(Nombre,Descripcion) VALUES ('Cancelada Recepción','Reserva cancelada por Recepción');
INSERT INTO TEAM_CASTY.Estados(Nombre,Descripcion) VALUES ('Cancelada Cliente','Reserva cancelada por Cliente');
INSERT INTO TEAM_CASTY.Estados(Nombre,Descripcion) VALUES ('Cancelada No-Show','Reserva cancelada por No-Show');
INSERT INTO TEAM_CASTY.Estados(Nombre,Descripcion) VALUES ('Efectivizada','Reserva con ingreso (efectivizada)');

SELECT * FROM TEAM_CASTY.Estados

--Consumibles
CREATE TABLE TEAM_CASTY.Consumible ( 
	Cod_Consumible numeric(18) NOT NULL PRIMARY KEY,
	Descripcion nvarchar(255) NOT NULL,
	Precio numeric(18,2) NOT NULL);

INSERT INTO TEAM_CASTY.Consumible(Cod_Consumible,Descripcion,Precio) SELECT DISTINCT t1.Consumible_Codigo, t1.Consumible_Descripcion, t1.Consumible_Precio
																	 FROM gd_esquema.Maestra t1
																     WHERE t1.Consumible_Codigo IS NOT NULL
																	 ORDER BY t1.Consumible_Codigo
																	 
SELECT * FROM TEAM_CASTY.Consumible

--Formas de Pago
CREATE TABLE TEAM_CASTY.Forma_Pago ( 
	Cod_Forma_Pago numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Descripcion nvarchar(255) NOT NULL);
	
INSERT INTO TEAM_CASTY.Forma_Pago(Descripcion) VALUES ('Efectivo');
INSERT INTO TEAM_CASTY.Forma_Pago(Descripcion) VALUES ('Tarjeta de Crédito');
--INSERT INTO TEAM_CASTY.Forma_Pago(Descripcion) VALUES ('Tarjeta de Débito'); --¿va?

SELECT * FROM TEAM_CASTY.Forma_Pago

--Tipos de Documento
CREATE TABLE TEAM_CASTY.Tipo_Documento ( 
	ID_Tipo_Documento numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Tipo_Documento varchar(20) NOT NULL);

insert into TEAM_CASTY.Tipo_Documento (Tipo_Documento) values ('PASAPORTE');

select * from TEAM_CASTY.Tipo_Documento

--Clientes
CREATE TABLE TEAM_CASTY.Cliente ( 
	ID_Cliente numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	ID_Tipo_Documento numeric(18) NOT NULL,
	Nro_Documento numeric(18) NOT NULL,
	Apellido nvarchar(255) NOT NULL,
	Nombre nvarchar(255) NOT NULL,
	Fecha_Nacimiento datetime NOT NULL,	
	Pais nvarchar(255),
	Localidad nvarchar(255),
	Nom_Calle nvarchar(255) NOT NULL,
	Nro_Calle numeric(18) NOT NULL,
	Piso numeric(18) NOT NULL,
	Dto nvarchar(50),	
	Nacionalidad nvarchar(255) NOT NULL,
	Mail nvarchar(255) NOT NULL,
	Telefono nvarchar(50),
	Inhabilitado bit NOT NULL DEFAULT 0,	
	Erroneo bit NOT NULL DEFAULT 0);

SELECT DISTINCT t3.Cliente_Pasaporte_Nro, t3.Cliente_Apellido, t3.Cliente_Nombre, t3.Cliente_Fecha_Nac, 'ARGENTINA' AS 'Pais', 'CAPITAL FEDERAL' AS 'Localidad', t3.Cliente_Dom_Calle, t3.Cliente_Nro_Calle, t3.Cliente_Piso, t3.Cliente_Depto, t3.Cliente_Mail, t3.Cliente_Nacionalidad
INTO #datos_completos_clientes
FROM  gd_esquema.Maestra t3
ORDER BY 1,2,3

SELECT c.Cliente_Pasaporte_Nro
INTO #clientes_repetidos
FROM #datos_completos_clientes c
GROUP BY c.Cliente_Pasaporte_Nro
HAVING COUNT(c.Cliente_Pasaporte_Nro)>1

INSERT INTO TEAM_CASTY.Cliente (ID_Tipo_Documento,Nro_Documento,Apellido,Nombre,Fecha_Nacimiento,Pais,Localidad,Nom_Calle,Nro_Calle,Piso,Dto,Mail,Nacionalidad)
SELECT 1 AS 'ID_Tipo_Documento', t3.Cliente_Pasaporte_Nro, t3.Cliente_Apellido, t3.Cliente_Nombre, t3.Cliente_Fecha_Nac, 'ARGENTINA' AS 'Pais', 'CAPITAL FEDERAL' AS 'Localidad', t3.Cliente_Dom_Calle, t3.Cliente_Nro_Calle, t3.Cliente_Piso, t3.Cliente_Depto, t3.Cliente_Mail, t3.Cliente_Nacionalidad
FROM #datos_completos_clientes t3
WHERE t3.Cliente_Pasaporte_Nro not in (SELECT t1.Cliente_Pasaporte_Nro FROM #clientes_repetidos t1)
ORDER BY 2,3,4

INSERT INTO TEAM_CASTY.Cliente (ID_Tipo_Documento,Nro_Documento,Apellido,Nombre,Fecha_Nacimiento,Pais,Localidad,Nom_Calle,Nro_Calle,Piso,Dto,Mail,Nacionalidad, Erroneo)
SELECT 1 AS 'ID_Tipo_Documento', t3.Cliente_Pasaporte_Nro, t3.Cliente_Apellido, t3.Cliente_Nombre, t3.Cliente_Fecha_Nac, 'ARGENTINA' AS 'Pais', 'CAPITAL FEDERAL' AS 'Localidad', t3.Cliente_Dom_Calle, t3.Cliente_Nro_Calle, t3.Cliente_Piso, t3.Cliente_Depto, t3.Cliente_Mail, t3.Cliente_Nacionalidad, 1 AS 'Erroneo'
FROM #datos_completos_clientes t3
WHERE t3.Cliente_Pasaporte_Nro in (SELECT t1.Cliente_Pasaporte_Nro FROM #clientes_repetidos t1)
ORDER BY 2,3,4

DROP TABLE #clientes_repetidos
DROP TABLE #datos_completos_clientes

SELECT * FROM TEAM_CASTY.Cliente

--Tarjetas, solo se crea, no tiene datos al principio
CREATE TABLE TEAM_CASTY.Tarjeta ( 
	Numero numeric(18) NOT NULL,
	Banco nvarchar(255) NOT NULL,
	ID_Cliente numeric(18) NOT NULL,
	PRIMARY KEY (Numero, Banco),
	FOREIGN KEY (ID_Cliente) REFERENCES TEAM_CASTY.Cliente (ID_Cliente));

--TarjetaXFactura, solo se crea, no tiene datos al principio
CREATE TABLE TEAM_CASTY.TarjetaXFactura ( 
	Nro_Factura numeric(18) NOT NULL,
	Numero_Tarjeta numeric(18) NOT NULL,
	Banco nvarchar(255) NOT NULL,
	PRIMARY KEY (Nro_Factura, Numero_Tarjeta, Banco),
	FOREIGN KEY (Nro_Factura) REFERENCES TEAM_CASTY.Factura (Nro_Factura),
	FOREIGN KEY (Numero_Tarjeta, Banco) REFERENCES TEAM_CASTY.Tarjeta (Numero, Banco));
	
	
GO	

--Reservas
CREATE TABLE TEAM_CASTY.Reserva ( 
	Cod_Reserva numeric(18) NOT NULL PRIMARY KEY,
	Fecha_Reserva datetime NOT NULL,
	Cant_Noches numeric(18) NOT NULL,
	Cod_Hotel numeric(18) NOT NULL,
	ID_Cliente_Reservador numeric(18) NOT NULL,
	Cod_Regimen numeric(18) DEFAULT NULL,	
	Fecha_Inicio datetime,
	Fecha_Salida datetime,	
	Cod_Estado numeric(18) NOT NULL DEFAULT 1,
	FOREIGN KEY (ID_Cliente_Reservador) REFERENCES TEAM_CASTY.Cliente (ID_Cliente),
	FOREIGN KEY (Cod_Regimen) REFERENCES TEAM_CASTY.Regimen (Cod_Regimen),
	FOREIGN KEY (Cod_Estado) REFERENCES TEAM_CASTY.Estados (Cod_Estado));

select distinct t1.Reserva_Codigo, t1.Reserva_Fecha_Inicio, t1.Reserva_Cant_Noches, t1.Cliente_Pasaporte_Nro,t1.Cliente_Apellido, t1.Cliente_Nombre, t1.Hotel_Ciudad, t1.Hotel_Calle, t1.Hotel_Nro_Calle, t1.Regimen_Descripcion
into #reservas
FROM gd_esquema.Maestra t1
order by 1

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

select distinct t1.Reserva_Codigo
into #todas_reservas
FROM gd_esquema.Maestra t1
order by 1

select distinct t1.Reserva_Codigo
into #reservas_efectivas
FROM gd_esquema.Maestra t1
where t1.Factura_Total is not null
order by 1

select distinct t1.Reserva_Codigo
into #reservas_canceladas_NoShow
FROM #todas_reservas t1
where t1.Reserva_Codigo not in (select distinct t2.Reserva_Codigo
							    FROM #reservas_efectivas t2)
order by 1

INSERT INTO TEAM_CASTY.Reserva (Cod_Reserva,Fecha_Reserva,Cant_Noches,Cod_Hotel,Cod_Regimen,ID_Cliente_Reservador,Cod_Estado)
select distinct t1.Reserva_Codigo,t1.Reserva_Fecha_Inicio,t1.Reserva_Cant_Noches,t1.Cod_Hotel,t1.Cod_Regimen, t1.ID_Cliente, 6 AS 'Cod_Estado'
FROM #reservas_new t1
where t1.Reserva_Codigo in (select res.Reserva_Codigo
							from #reservas_efectivas res)
order by t1.Reserva_Codigo

INSERT INTO TEAM_CASTY.Reserva (Cod_Reserva,Fecha_Reserva,Cant_Noches,Cod_Hotel,Cod_Regimen,ID_Cliente_Reservador,Cod_Estado)
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

select * from TEAM_CASTY.Reserva


--Habitacion X Reserva
CREATE TABLE TEAM_CASTY.HabitacionXReserva ( 
	Cod_Reserva numeric(18) NOT NULL,
	Cod_Habitacion numeric(18) NOT NULL,
	PRIMARY KEY (Cod_Reserva, Cod_Habitacion),	
	FOREIGN KEY (Cod_Reserva) REFERENCES TEAM_CASTY.Reserva (Cod_Reserva),
	FOREIGN KEY (Cod_Habitacion) REFERENCES TEAM_CASTY.Habitacion (Cod_Habitacion));

INSERT INTO TEAM_CASTY.HabitacionXReserva (Cod_Reserva,Cod_Habitacion)
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




--Facturas
CREATE TABLE TEAM_CASTY.Factura ( 
	Fecha datetime NOT NULL,
	Nro_Factura numeric(18) NOT NULL PRIMARY KEY,
	Total numeric(18,2) NOT NULL,
	Cod_Reserva numeric(18) NOT NULL,
	Cod_Forma_Pago numeric(18) NOT NULL,
	FOREIGN KEY (Cod_Forma_Pago) REFERENCES TEAM_CASTY.Forma_Pago (Cod_Forma_Pago),
	FOREIGN KEY (Cod_Reserva) REFERENCES TEAM_CASTY.Reserva (Cod_Reserva));

CREATE TABLE TEAM_CASTY.Auxiliar_Item_Total ( 
	Nro_Factura numeric(18) NOT NULL,
	Total numeric(18,2) NOT NULL);

INSERT INTO TEAM_CASTY.Auxiliar_Item_Total select  Factura_Nro ,Consumible_Precio as  "Total"
from gd_esquema.Maestra m1
where m1.Consumible_Codigo is not null and m1.Factura_Nro is not null and m1.Regimen_Descripcion not in ('All inclusive' , 'All Inclusive moderado')

INSERT INTO TEAM_CASTY.Auxiliar_Item_Total select Factura_Nro , (Reserva_Cant_Noches * Item_Factura_Monto) as "Total"
from gd_esquema.Maestra m1
where m1.Consumible_Codigo is null and m1.Factura_Nro is not null

INSERT INTO TEAM_CASTY.Factura (Nro_Factura,Fecha,Cod_Reserva,Cod_Forma_Pago,Total)
SELECT DISTINCT  m.Factura_Nro AS "Nro_Factura", m.Factura_Fecha AS "Fecha", m.Reserva_Codigo AS "Cod_Reserva", 1 AS "Cod_Forma_Pago" , SUM (auxiliar.Total) AS "Total"
FROM gd_esquema.Maestra	m join TEAM_CASTY.Auxiliar_Item_Total auxiliar on (auxiliar.Nro_Factura = m.Factura_Nro)
group by m.Factura_Nro,m.Factura_Fecha, m.Reserva_Codigo
order by 1

drop table TEAM_CASTY.Auxiliar_Item_Total

select * from TEAM_CASTY.Factura