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
	
INSERT INTO TEAM_CASTY.Rol (Nombre, Activo) VALUES ('Administrador General',1);
INSERT INTO TEAM_CASTY.Rol (Nombre, Activo) VALUES ('Recepcionista',1);
INSERT INTO TEAM_CASTY.Rol (Nombre, Activo) VALUES ('Guest',1);

--SELECT * FROM TEAM_CASTY.Rol

--Funciones
CREATE TABLE TEAM_CASTY.Funcion ( 
	Cod_Funcion numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Descripcion nvarchar(255) NOT NULL);	
	
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('ABM de Rol');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('ABM de Usuario');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('ABM de Cliente');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('ABM de Hotel');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('ABM de Habitaci�n');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('ABM R�gimen de Estad�a');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('Generar o Modificar un Reserva');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('Cancelar Reserva');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('Registrar Estad�a');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('Registrar Consumibles');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('Facturar Estad�a');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('Listado Estad�stico');

--SELECT * FROM TEAM_CASTY.Funcion

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

--SELECT * FROM TEAM_CASTY.FuncionXRol

--Regimenes
CREATE TABLE TEAM_CASTY.Regimen ( 
	Cod_Regimen numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Descripcion nvarchar(255) NOT NULL,
	Precio numeric(18,2) NOT NULL);
	
INSERT INTO TEAM_CASTY.Regimen SELECT DISTINCT t1.Regimen_Descripcion, t1.Regimen_Precio
							   FROM gd_esquema.Maestra t1
							   ORDER BY t1.Regimen_Descripcion
														   
--SELECT * FROM TEAM_CASTY.Regimen

--Tipos de Habitaciones
CREATE TABLE TEAM_CASTY.Tipo_Habitacion ( 
	Cod_Tipo numeric(18) NOT NULL PRIMARY KEY,
	Descripcion nvarchar(255) NOT NULL,
	Porcentual numeric(18,2) NOT NULL);

INSERT INTO TEAM_CASTY.Tipo_Habitacion SELECT DISTINCT t1.Habitacion_Tipo_Codigo, t1.Habitacion_Tipo_Descripcion, t1.Habitacion_Tipo_Porcentual
							   FROM gd_esquema.Maestra t1
							   ORDER BY t1.Habitacion_Tipo_Codigo
							   
--SELECT * FROM TEAM_CASTY.Tipo_Habitacion

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

--SELECT * FROM TEAM_CASTY.Ciudad

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
	Pais nvarchar(255),
	FOREIGN KEY (Cod_Ciudad) REFERENCES TEAM_CASTY.Ciudad (Cod_Ciudad));

INSERT INTO TEAM_CASTY.Hotel (Cod_Ciudad, Calle, Nro_Calle, CantEstrella, Pais) SELECT DISTINCT TEAM_CASTY.Ciudad.Cod_Ciudad, t1.Hotel_Calle, t1.Hotel_Nro_Calle, t1.Hotel_CantEstrella,'ARGENTINA' as Pais
																						    FROM gd_esquema.Maestra t1 JOIN TEAM_CASTY.Ciudad ON (TEAM_CASTY.Ciudad.Nombre=t1.Hotel_Ciudad)
																							ORDER BY TEAM_CASTY.Ciudad.Cod_Ciudad, t1.Hotel_Calle, t1.Hotel_Nro_Calle

--SELECT * FROM TEAM_CASTY.Hotel

--SELECT Cod_Hotel, Nombre,Calle, Nro_Calle, CantEstrella, Fecha_Creacion, Telefono, Mail
--FROM TEAM_CASTY.Hotel h JOIN TEAM_CASTY.Ciudad c ON (c.Cod_Ciudad=h.Cod_Ciudad)
--ORDER BY Cod_Hotel

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
															  WHERE t1.Hotel_Calle=h.Calle and
															  t1.Hotel_Nro_Calle=h.Nro_Calle and
															  c.Cod_Ciudad=h.Cod_Ciudad and
															  t1.Hotel_Ciudad=c.Nombre and
															  t1.Regimen_Descripcion=r.Descripcion
															  ORDER BY h.Cod_Hotel, r.Cod_Regimen
															  
--SELECT * FROM TEAM_CASTY.RegimenXHotel

--SELECT c.Nombre, h.Calle, h.Nro_Calle, h.Mail, h.Telefono, r.Descripcion, r.Precio 
--FROM TEAM_CASTY.RegimenXHotel rxh, TEAM_CASTY.Ciudad c, TEAM_CASTY.Hotel h, TEAM_CASTY.Regimen r
--WHERE rxh.Cod_Hotel=h.Cod_Hotel and
--c.Cod_Ciudad=h.Cod_Ciudad and
--r.Cod_Regimen=rxh.Cod_Regimen
--ORDER BY 1,2,3,4,5,6,7
	
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

--SELECT * FROM TEAM_CASTY.Habitacion																		   

--SELECT hab.Cod_Habitacion, h.Cod_Hotel, Nombre,Calle, Nro_Calle, Piso, Numero, Frente, hab.Descripcion, t.Descripcion
--FROM  TEAM_CASTY.Habitacion	hab JOIN TEAM_CASTY.Hotel h ON (hab.Cod_Hotel=h.Cod_Hotel)
--								JOIN TEAM_CASTY.Ciudad c ON (c.Cod_Ciudad=h.Cod_Ciudad)
--								JOIN TEAM_CASTY.Tipo_Habitacion t ON (hab.Cod_Tipo=t.Cod_Tipo)
--ORDER BY h.Cod_Hotel, Nombre,Calle, Nro_Calle, Piso, Numero, Frente

--Estados
CREATE TABLE TEAM_CASTY.Estados ( 
	Cod_Estado numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Descripcion nvarchar(255),
	Nombre nvarchar(255) NOT NULL UNIQUE);
	
INSERT INTO TEAM_CASTY.Estados(Nombre,Descripcion) VALUES ('Correcta','Reserva correcta');
INSERT INTO TEAM_CASTY.Estados(Nombre,Descripcion) VALUES ('Modificada','Reserva modificada (la misma sufri� alg�n cambio y no es la misma al momento de su creaci�n)');
INSERT INTO TEAM_CASTY.Estados(Nombre,Descripcion) VALUES ('Cancelada Recepci�n','Reserva cancelada por Recepci�n');
INSERT INTO TEAM_CASTY.Estados(Nombre,Descripcion) VALUES ('Cancelada Cliente','Reserva cancelada por Cliente');
INSERT INTO TEAM_CASTY.Estados(Nombre,Descripcion) VALUES ('Cancelada No-Show','Reserva cancelada por No-Show');
INSERT INTO TEAM_CASTY.Estados(Nombre,Descripcion) VALUES ('Efectivizada','Reserva con ingreso (efectivizada)');

--SELECT * FROM TEAM_CASTY.Estados

--Consumibles
CREATE TABLE TEAM_CASTY.Consumible ( 
	Cod_Consumible numeric(18) NOT NULL PRIMARY KEY,
	Descripcion nvarchar(255) NOT NULL,
	Precio numeric(18,2) NOT NULL);

INSERT INTO TEAM_CASTY.Consumible(Cod_Consumible,Descripcion,Precio) SELECT DISTINCT t1.Consumible_Codigo, t1.Consumible_Descripcion, t1.Consumible_Precio
																	 FROM gd_esquema.Maestra t1
																     WHERE t1.Consumible_Codigo IS NOT NULL
																	 ORDER BY t1.Consumible_Codigo
																	 
--SELECT * FROM TEAM_CASTY.Consumible

--Formas de Pago
CREATE TABLE TEAM_CASTY.Forma_Pago ( 
	Cod_Forma_Pago numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Descripcion nvarchar(255) NOT NULL);
	
INSERT INTO TEAM_CASTY.Forma_Pago(Descripcion) VALUES ('Efectivo');
INSERT INTO TEAM_CASTY.Forma_Pago(Descripcion) VALUES ('Tarjeta de Cr�dito');
--INSERT INTO TEAM_CASTY.Forma_Pago(Descripcion) VALUES ('Tarjeta de D�bito'); --�va? �alguno m�s?

--SELECT * FROM TEAM_CASTY.Forma_Pago

--Tipos de Documento
CREATE TABLE TEAM_CASTY.Tipo_Documento ( 
	ID_Tipo_Documento numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Tipo_Documento varchar(20) NOT NULL);

INSERT INTO TEAM_CASTY.Tipo_Documento (Tipo_Documento) values ('PASAPORTE');

--SELECT * FROM TEAM_CASTY.Tipo_Documento

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
	Erroneo bit NOT NULL DEFAULT 0,
	Baja bit NOT NULL DEFAULT 0,
	FOREIGN KEY (ID_Tipo_Documento) REFERENCES TEAM_CASTY.Tipo_Documento (ID_Tipo_Documento));

SELECT DISTINCT t3.Cliente_Pasaporte_Nro, t3.Cliente_Apellido, t3.Cliente_Nombre, t3.Cliente_Fecha_Nac, 'ARGENTINA' AS 'Pais', 'CAPITAL FEDERAL' AS 'Localidad', t3.Cliente_Dom_Calle, t3.Cliente_Nro_Calle, t3.Cliente_Piso, t3.Cliente_Depto, t3.Cliente_Mail, t3.Cliente_Nacionalidad
INTO #datos_completos_clientes
FROM  gd_esquema.Maestra t3
ORDER BY 1,2,3

SELECT c.Cliente_Pasaporte_Nro
INTO #clientes_repetidos
FROM #datos_completos_clientes c
GROUP BY c.Cliente_Pasaporte_Nro
HAVING COUNT(c.Cliente_Pasaporte_Nro)>1

INSERT INTO TEAM_CASTY.Cliente (ID_Tipo_Documento,Nro_Documento,Apellido,Nombre,Fecha_Nacimiento,Pais,Localidad,Nom_Calle,Nro_Calle,Piso,Dto,Mail,Nacionalidad,Baja)
SELECT 1 AS 'ID_Tipo_Documento', t3.Cliente_Pasaporte_Nro, t3.Cliente_Apellido, t3.Cliente_Nombre, t3.Cliente_Fecha_Nac, 'ARGENTINA' AS 'Pais', 'CAPITAL FEDERAL' AS 'Localidad', t3.Cliente_Dom_Calle, t3.Cliente_Nro_Calle, t3.Cliente_Piso, t3.Cliente_Depto, t3.Cliente_Mail, t3.Cliente_Nacionalidad,0
FROM #datos_completos_clientes t3
WHERE t3.Cliente_Pasaporte_Nro not in (SELECT t1.Cliente_Pasaporte_Nro FROM #clientes_repetidos t1)
ORDER BY 2,3,4

INSERT INTO TEAM_CASTY.Cliente (ID_Tipo_Documento,Nro_Documento,Apellido,Nombre,Fecha_Nacimiento,Pais,Localidad,Nom_Calle,Nro_Calle,Piso,Dto,Mail,Nacionalidad, Erroneo,Baja)
SELECT 1 AS 'ID_Tipo_Documento', t3.Cliente_Pasaporte_Nro, t3.Cliente_Apellido, t3.Cliente_Nombre, t3.Cliente_Fecha_Nac, 'ARGENTINA' AS 'Pais', 'CAPITAL FEDERAL' AS 'Localidad', t3.Cliente_Dom_Calle, t3.Cliente_Nro_Calle, t3.Cliente_Piso, t3.Cliente_Depto, t3.Cliente_Mail, t3.Cliente_Nacionalidad, 1 AS 'Erroneo',0
FROM #datos_completos_clientes t3
WHERE t3.Cliente_Pasaporte_Nro in (SELECT t1.Cliente_Pasaporte_Nro FROM #clientes_repetidos t1)
ORDER BY 2,3,4

DROP TABLE #clientes_repetidos
DROP TABLE #datos_completos_clientes

--SELECT * FROM TEAM_CASTY.Cliente

--Usuarios
CREATE TABLE TEAM_CASTY.Usuario ( 
	Cod_Usuario numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Username nvarchar(255) NOT NULL UNIQUE,
	Contrase�a nvarchar(255) NOT NULL,	
	Cant_Intentos numeric(18) DEFAULT 0 NOT NULL,
	Habilitado bit DEFAULT 1 NOT NULL,
	Baja bit DEFAULT 0 NOT NULL);
	
INSERT INTO TEAM_CASTY.Usuario (Username,Contrase�a) values ('admin','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7');--la contrase�a es CASTY
INSERT INTO TEAM_CASTY.Usuario (Username,Contrase�a) values ('guest','16ceb2796ccd9d52d4f2a92134ef9ecfeb8f016150a82d36b299d09d5b9963f0');--la contrase�a es GUEST

--SELECT * FROM TEAM_CASTY.Usuario
	
--Empleados	
CREATE TABLE TEAM_CASTY.Empleado ( 
	Cod_Empleado numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Nombre nvarchar(255) NOT NULL,
	Apellido nvarchar(255) NOT NULL,
	Mail nvarchar(255) NOT NULL,
	Telefono nvarchar(50) NOT NULL,
	Direccion nvarchar(255) NOT NULL,
	Fecha_Nacimiento datetime NOT NULL,
	Cod_Usuario numeric(18) NOT NULL,
	FOREIGN KEY (Cod_Usuario) REFERENCES TEAM_CASTY.Usuario (Cod_Usuario));

--Roles de los Usuarios por cada Hotel
CREATE TABLE TEAM_CASTY.RolXUsuarioXHotel (	
	Cod_Usuario numeric(18) NOT NULL,	
	Cod_Hotel numeric(18) NOT NULL,
	Cod_Rol numeric(18) NOT NULL,
	PRIMARY KEY (Cod_Usuario,Cod_Hotel,Cod_Rol),
	FOREIGN KEY (Cod_Rol) REFERENCES TEAM_CASTY.Rol (Cod_Rol),
	FOREIGN KEY (Cod_Hotel) REFERENCES TEAM_CASTY.Hotel (Cod_Hotel),
	FOREIGN KEY (Cod_Usuario) REFERENCES TEAM_CASTY.Usuario (Cod_Usuario));	

SELECT 1 AS Cod_Usuario,h.Cod_Hotel,1 AS Cod_Rol
INTO #hoteles_admnistrador
FROM TEAM_CASTY.Hotel h

SELECT 2 AS Cod_Usuario,h.Cod_Hotel,3 AS Cod_Rol
INTO #hoteles_guest
FROM TEAM_CASTY.Hotel h

INSERT INTO TEAM_CASTY.RolXUsuarioXHotel (Cod_Usuario,Cod_Hotel,Cod_Rol)
SELECT *
FROM #hoteles_admnistrador

INSERT INTO TEAM_CASTY.RolXUsuarioXHotel (Cod_Usuario,Cod_Hotel,Cod_Rol)
SELECT *
FROM #hoteles_guest

DROP TABLE #hoteles_admnistrador
DROP TABLE #hoteles_guest

--SELECT * FROM TEAM_CASTY.RolXUsuarioXHotel
	
--Inhabilitacion de los Hoteles	
CREATE TABLE TEAM_CASTY.Periodo_Inhabilitado ( 
	Cod_Hotel numeric(18) NOT NULL,
	Fecha_Inicio datetime NOT NULL,
	Fecha_Fin datetime NOT NULL,
	Descripcion varchar(255),
	PRIMARY KEY (Cod_Hotel, Fecha_Inicio, Fecha_Fin),--ver
	FOREIGN KEY (Cod_Hotel) REFERENCES TEAM_CASTY.Hotel (Cod_Hotel));	

--Reservas
CREATE TABLE TEAM_CASTY.Reserva ( 
	Cod_Reserva numeric(18) NOT NULL PRIMARY KEY,
	Fecha_Reserva datetime NOT NULL,
	Cant_Noches numeric(18) NOT NULL,
	ID_Cliente_Reservador numeric(18) NOT NULL,
	Cod_Regimen numeric(18) DEFAULT NULL,	
	Fecha_Inicio datetime,
	Fecha_Salida datetime,	
	Cod_Estado numeric(18) NOT NULL DEFAULT 1,
	FOREIGN KEY (ID_Cliente_Reservador) REFERENCES TEAM_CASTY.Cliente (ID_Cliente),
	FOREIGN KEY (Cod_Regimen) REFERENCES TEAM_CASTY.Regimen (Cod_Regimen),
	FOREIGN KEY (Cod_Estado) REFERENCES TEAM_CASTY.Estados (Cod_Estado));

SELECT distinct t1.Reserva_Codigo, t1.Reserva_Fecha_Inicio, t1.Reserva_Cant_Noches, t1.Cliente_Pasaporte_Nro,t1.Cliente_Apellido, t1.Cliente_Nombre, t1.Hotel_Ciudad, t1.Hotel_Calle, t1.Hotel_Nro_Calle, t1.Regimen_Descripcion
INTO #reservas
FROM gd_esquema.Maestra t1
ORDER BY 1

SELECT distinct res.Reserva_Codigo,res.Reserva_Fecha_Inicio,res.Reserva_Cant_Noches,h.Cod_Hotel,reg.Cod_Regimen, c.ID_Cliente
INTO #reservas_new
FROM TEAM_CASTY.Ciudad ciu, TEAM_CASTY.Cliente c, TEAM_CASTY.Hotel h, #reservas res, TEAM_CASTY.Regimen reg
WHERE
ciu.Nombre=res.Hotel_Ciudad and
h.Calle=res.Hotel_Calle and
h.Cod_Ciudad=ciu.Cod_Ciudad and
h.Nro_Calle=res.Hotel_Nro_Calle and
c.Nro_Documento=res.Cliente_Pasaporte_Nro and
c.Apellido=res.Cliente_Apellido and
c.Nombre=res.Cliente_Nombre and
reg.Descripcion=res.Regimen_Descripcion
ORDER BY 1

--SELECT * FROM #reservas_new

INSERT INTO TEAM_CASTY.Reserva (Cod_Reserva,Fecha_Reserva,Cant_Noches,Cod_Regimen,ID_Cliente_Reservador,Cod_Estado)
SELECT distinct t1.Reserva_Codigo,t1.Reserva_Fecha_Inicio,t1.Reserva_Cant_Noches,t1.Cod_Regimen, t1.ID_Cliente, 1 AS 'Cod_Estado'
FROM #reservas_new t1
WHERE t1.Reserva_Codigo in (SELECT res.Reserva_Codigo FROM #reservas_new res)
ORDER BY t1.Reserva_Codigo

DROP TABLE #reservas
DROP TABLE #reservas_new	

--SELECT * FROM TEAM_CASTY.Reserva

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

--SELECT * FROM TEAM_CASTY.HabitacionXReserva

--Clientes por Reserva
CREATE TABLE TEAM_CASTY.ClienteXReserva ( 	
	Cod_Reserva numeric(18) NOT NULL,
	ID_Cliente numeric(18) NOT NULL,
	PRIMARY KEY (Cod_Reserva,ID_Cliente),
	FOREIGN KEY (Cod_Reserva) REFERENCES TEAM_CASTY.Reserva (Cod_Reserva),
	FOREIGN KEY (ID_Cliente) REFERENCES TEAM_CASTY.Cliente (ID_Cliente));
	
INSERT INTO TEAM_CASTY.ClienteXReserva
SELECT DISTINCT t1.Reserva_Codigo, c.ID_Cliente
FROM gd_esquema.Maestra t1, TEAM_CASTY.Cliente c, TEAM_CASTY.Reserva r
WHERE 
t1.Cliente_Apellido=c.Apellido and
t1.Cliente_Nombre=c.Nombre and
t1.Cliente_Pasaporte_Nro=c.Nro_Documento and
r.Cod_Reserva=t1.Reserva_Codigo
ORDER BY t1.Reserva_Codigo, c.ID_Cliente

--SELECT * FROM TEAM_CASTY.ClienteXReserva

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
    Factura_Fecha datetime NOT NULL,
	Reserva_Codigo numeric(18) NOT NULL,
	Nro_Factura numeric(18) NOT NULL,
	Total numeric(18,2) NOT NULL);

INSERT INTO TEAM_CASTY.Auxiliar_Item_Total (Reserva_Codigo,Factura_Fecha,Nro_Factura,Total)
select Reserva_Codigo ,Factura_Fecha, Factura_Nro, Consumible_Precio as  "Total"
from gd_esquema.Maestra m1
where m1.Consumible_Codigo is not null and m1.Factura_Nro is not null and m1.Regimen_Descripcion not in ('All inclusive' , 'All Inclusive moderado')

INSERT INTO TEAM_CASTY.Auxiliar_Item_Total (Reserva_Codigo,Factura_Fecha,Nro_Factura,Total)
select Reserva_Codigo,Factura_Fecha, Factura_Nro , (Reserva_Cant_Noches * Item_Factura_Monto) as "Total"
from gd_esquema.Maestra m1
where m1.Consumible_Codigo is null and m1.Factura_Nro is not null

INSERT INTO TEAM_CASTY.Factura (Nro_Factura,Fecha,Cod_Reserva,Cod_Forma_Pago,Total)
SELECT DISTINCT  auxiliar.Nro_Factura AS "Nro_Factura", auxiliar.Factura_Fecha AS "Fecha", auxiliar.Reserva_Codigo AS "Cod_Reserva", 1 AS "Cod_Forma_Pago" , SUM (auxiliar.Total) AS "Total"
FROM TEAM_CASTY.Auxiliar_Item_Total auxiliar 
group by auxiliar.Nro_Factura, auxiliar.Factura_Fecha, auxiliar.Reserva_Codigo
order by 1

DROP TABLE TEAM_CASTY.Auxiliar_Item_Total

--SELECT * FROM TEAM_CASTY.Factura

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

--Cambiar hacer check in y out de las reservas 
UPDATE TEAM_CASTY.Reserva
SET TEAM_CASTY.Reserva.Fecha_Inicio=TEAM_CASTY.Reserva.Fecha_Reserva,
TEAM_CASTY.Reserva.Fecha_Salida=(SELECT r.Fecha_Reserva+r.Cant_Noches FROM TEAM_CASTY.Reserva r WHERE r.Cod_Reserva=TEAM_CASTY.Reserva.Cod_Reserva),
TEAM_CASTY.Reserva.Cod_Estado=6
WHERE TEAM_CASTY.Reserva.Cod_Reserva in (SELECT fac.Cod_Reserva FROM TEAM_CASTY.Factura fac)

--cosumibles de la reserva (por habitacion) --anda OK
CREATE TABLE TEAM_CASTY.ConsumibleXHabitacionXReserva ( 
	Cod_Reserva numeric(18) NOT NULL,
	Cod_Habitacion numeric(18) NOT NULL,
	Cod_Consumible numeric(18) NOT NULL,
	Cantidad numeric(18) NOT NULL,
	PRIMARY KEY (Cod_Reserva,Cod_Habitacion,Cod_Consumible),
	FOREIGN KEY (Cod_Habitacion) REFERENCES TEAM_CASTY.Habitacion (Cod_Habitacion),
	FOREIGN KEY (Cod_Reserva) REFERENCES TEAM_CASTY.Reserva (Cod_Reserva),
	FOREIGN KEY (Cod_Consumible) REFERENCES TEAM_CASTY.Consumible (Cod_Consumible));
	
SELECT  distinct habXres.Cod_Habitacion, hab.Cod_Hotel, hot.Cod_Ciudad , Cod_Reserva, Numero,Nombre,Calle,Nro_Calle
INTO #auxiliar
FROM TEAM_CASTY.HabitacionXReserva habXres JOIN  TEAM_CASTY.Habitacion hab on (habXres.Cod_Habitacion= hab.Cod_Habitacion) 
                                           JOIN TEAM_CASTY.Hotel hot ON(hot.Cod_Hotel = hab.Cod_Hotel)
                                           JOIN TEAM_CASTY.Ciudad ciu ON(hot.Cod_Ciudad = ciu.Cod_Ciudad);  
                                           
INSERT INTO TEAM_CASTY.ConsumibleXHabitacionXReserva (Cod_Reserva,Cod_Habitacion,Cod_Consumible,Cantidad)
SELECT a.Cod_Reserva, a.Cod_Habitacion,m.Consumible_Codigo,count(m.Consumible_Codigo) AS "Cantidad"
FROM gd_esquema.Maestra m JOIN #auxiliar a ON(a.Cod_Reserva=m.Reserva_Codigo and a.Numero = m.Habitacion_Numero and a.Nombre = m.Hotel_Ciudad and a.Calle=m.Hotel_Calle and a.Nro_Calle = m.Hotel_Nro_Calle)
WHERE m.Consumible_Codigo is not null and m.Factura_Nro is not null
GROUP BY a.Cod_Reserva, a.Cod_Habitacion,m.Consumible_Codigo

DROP TABLE #auxiliar

--SELECT * FROM TEAM_CASTY.ConsumibleXHabitacionXReserva

--consumible, habitacion y factura
CREATE TABLE TEAM_CASTY.item_ConsumibleXFactura ( 
	Nro_Factura numeric(18) NOT NULL,
	Cod_Habitacion numeric(18) NOT NULL,
	Cod_Consumible numeric(18) NOT NULL,
	Cantidad numeric(18) NOT NULL,
	Monto numeric(18,2) NOT NULL,
	PRIMARY KEY (Nro_Factura,Cod_Habitacion,Cod_Consumible),
	FOREIGN KEY (Cod_Habitacion) REFERENCES TEAM_CASTY.Habitacion (Cod_Habitacion),
	FOREIGN KEY (Nro_Factura) REFERENCES TEAM_CASTY.Factura (Nro_Factura),
	FOREIGN KEY (Cod_Consumible) REFERENCES TEAM_CASTY.Consumible (Cod_Consumible));

INSERT INTO TEAM_CASTY.item_ConsumibleXFactura (Nro_Factura,Cod_Habitacion,Cod_Consumible,Cantidad,Monto)
SELECT f.Nro_Factura,chres.Cod_Habitacion,chres.Cod_Consumible,chres.Cantidad, chres.Cantidad*con.Precio
FROM TEAM_CASTY.ConsumibleXHabitacionXReserva chres, TEAM_CASTY.Factura f, TEAM_CASTY.Consumible con
WHERE f.Cod_Reserva=chres.Cod_Reserva and chres.Cod_Consumible = con.Cod_Consumible

select * from TEAM_CASTY.item_ConsumibleXFactura

--estadia, habitacion y factura
CREATE TABLE TEAM_CASTY.item_EstadiaXFactura ( 
	Nro_Factura numeric(18) NOT NULL,
	Cod_Habitacion numeric(18) NOT NULL,
	Cod_Regimen numeric(18) NOT NULL,
	Monto numeric(18,2) NOT NULL,
	PRIMARY KEY (Nro_Factura,Cod_Habitacion,Cod_Regimen),
	FOREIGN KEY (Cod_Habitacion) REFERENCES TEAM_CASTY.Habitacion (Cod_Habitacion),
	FOREIGN KEY (Nro_Factura) REFERENCES TEAM_CASTY.Factura (Nro_Factura),
	FOREIGN KEY (Cod_Regimen) REFERENCES TEAM_CASTY.Regimen (Cod_Regimen));

INSERT INTO TEAM_CASTY.item_EstadiaXFactura (Nro_Factura,Cod_Habitacion,Cod_Regimen,Monto)
SELECT f.Nro_Factura, hxr.Cod_Habitacion, res.Cod_Regimen, res.Cant_Noches*reg.Precio*thab.Porcentual+hot.CantEstrella*rec.Recarga AS Monto
FROM TEAM_CASTY.Factura f, TEAM_CASTY.Habitacion hab, TEAM_CASTY.HabitacionXReserva hxr, TEAM_CASTY.Hotel hot, TEAM_CASTY.Recarga_Estrella rec, TEAM_CASTY.Regimen reg, TEAM_CASTY.Reserva res,TEAM_CASTY.Tipo_Habitacion thab
WHERE f.Cod_Reserva=res.Cod_Reserva and
res.Cod_Reserva=hxr.Cod_Reserva and
hxr.Cod_Habitacion=hab.Cod_Habitacion and
hab.Cod_Hotel=hot.Cod_Hotel and
rec.Cod_Recarga=1 and
res.Cod_Regimen=reg.Cod_Regimen and
thab.Cod_Tipo=hab.Cod_Tipo

--select * from TEAM_CASTY.item_EstadiaXFactura

--Usuario por reserva (para modificacion de Reserva)
CREATE TABLE TEAM_CASTY.UsuarioXReserva ( 
	Cod_Reserva numeric(18) NOT NULL,
	Numero_Modificacion numeric(18) NOT NULL,
	Cod_Usuario numeric(18) NOT NULL,
	Fecha datetime DEFAULT getdate(),	
	Descripcion varchar(255),
	PRIMARY KEY (Cod_Reserva, Numero_Modificacion),
	FOREIGN KEY (Cod_Reserva) REFERENCES TEAM_CASTY.Reserva (Cod_Reserva),
	FOREIGN KEY (Cod_Usuario) REFERENCES TEAM_CASTY.Usuario (Cod_Usuario));

GO