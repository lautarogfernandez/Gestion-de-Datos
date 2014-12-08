--Esquema
USE [GD2C2014]
GO
CREATE SCHEMA [TEAM_CASTY] AUTHORIZATION [gd]
GO
print('Esquema creado');
--Roles
CREATE TABLE TEAM_CASTY.Rol ( 
	Cod_Rol numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Nombre nvarchar(255) NOT NULL,
	Activo bit DEFAULT 1 NOT NULL);
	
INSERT INTO TEAM_CASTY.Rol (Nombre, Activo) VALUES ('Administrador General',1);
INSERT INTO TEAM_CASTY.Rol (Nombre, Activo) VALUES ('Recepcionista',1);
INSERT INTO TEAM_CASTY.Rol (Nombre, Activo) VALUES ('Guest',1);

--SELECT * FROM TEAM_CASTY.Rol
print('Roloes OK');
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
print('Funciones OK');
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
print('Funciones por Rol OK');
--Regimenes
CREATE TABLE TEAM_CASTY.Regimen ( 
	Cod_Regimen numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Descripcion nvarchar(255) NOT NULL,
	Precio numeric(18,2) NOT NULL);
	
INSERT INTO TEAM_CASTY.Regimen SELECT DISTINCT t1.Regimen_Descripcion, t1.Regimen_Precio
							   FROM gd_esquema.Maestra t1
							   ORDER BY t1.Regimen_Descripcion
														   
--SELECT * FROM TEAM_CASTY.Regimen
print('Regimenes OK');
--Tipos de Habitaciones
CREATE TABLE TEAM_CASTY.Tipo_Habitacion ( 
	Cod_Tipo numeric(18) NOT NULL PRIMARY KEY,
	Descripcion nvarchar(255) NOT NULL,
	Porcentual numeric(18,2) NOT NULL);

INSERT INTO TEAM_CASTY.Tipo_Habitacion SELECT DISTINCT t1.Habitacion_Tipo_Codigo, t1.Habitacion_Tipo_Descripcion, t1.Habitacion_Tipo_Porcentual
							   FROM gd_esquema.Maestra t1
							   ORDER BY t1.Habitacion_Tipo_Codigo
							   
--SELECT * FROM TEAM_CASTY.Tipo_Habitacion
print('Tipos de Habitaci�n OK');
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
print('Recarga Estrella OK');
--Ciudades
CREATE TABLE TEAM_CASTY.Ciudad (
	Cod_Ciudad numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Nombre nvarchar(255) NOT NULL);
	
INSERT INTO TEAM_CASTY.Ciudad SELECT DISTINCT t1.Hotel_Ciudad
							  FROM gd_esquema.Maestra t1
							  ORDER BY t1.Hotel_Ciudad

--SELECT * FROM TEAM_CASTY.Ciudad
print('Ciudades OK');
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
	Nombre nvarchar(255),
	FOREIGN KEY (Cod_Ciudad) REFERENCES TEAM_CASTY.Ciudad (Cod_Ciudad));

INSERT INTO TEAM_CASTY.Hotel (Cod_Ciudad, Calle, Nro_Calle, CantEstrella, Pais) SELECT DISTINCT TEAM_CASTY.Ciudad.Cod_Ciudad, t1.Hotel_Calle, t1.Hotel_Nro_Calle, t1.Hotel_CantEstrella,'ARGENTINA' as Pais
																						    FROM gd_esquema.Maestra t1 JOIN TEAM_CASTY.Ciudad ON (TEAM_CASTY.Ciudad.Nombre=t1.Hotel_Ciudad)
																							ORDER BY TEAM_CASTY.Ciudad.Cod_Ciudad, t1.Hotel_Calle, t1.Hotel_Nro_Calle

--SELECT * FROM TEAM_CASTY.Hotel
print('Hoteles OK');
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
print('Estados OK');
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
print('Consumibles OK');
--Formas de Pago
CREATE TABLE TEAM_CASTY.Forma_Pago ( 
	Cod_Forma_Pago numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Descripcion nvarchar(255) NOT NULL);
	
INSERT INTO TEAM_CASTY.Forma_Pago(Descripcion) VALUES ('Efectivo');
INSERT INTO TEAM_CASTY.Forma_Pago(Descripcion) VALUES ('Tarjeta de Cr�dito');
--INSERT INTO TEAM_CASTY.Forma_Pago(Descripcion) VALUES ('Tarjeta de D�bito'); --�va? �alguno m�s?

--SELECT * FROM TEAM_CASTY.Forma_Pago
print('Formas de Pago OK');
--Tipos de Documento
CREATE TABLE TEAM_CASTY.Tipo_Documento ( 
	ID_Tipo_Documento numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Tipo_Documento varchar(20) NOT NULL);

INSERT INTO TEAM_CASTY.Tipo_Documento (Tipo_Documento) values ('PASAPORTE');

--SELECT * FROM TEAM_CASTY.Tipo_Documento
print('Tipos de Documento OK');
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
print('Clientes OK');
--Usuarios
CREATE TABLE TEAM_CASTY.Usuario ( 
	Cod_Usuario numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Username nvarchar(255) NOT NULL UNIQUE,
	Contrase�a nvarchar(255) NOT NULL,	
	Cant_Intentos numeric(18) DEFAULT 0 NOT NULL,
	Habilitado bit DEFAULT 1 NOT NULL,
	Baja bit DEFAULT 0 NOT NULL);
	
INSERT INTO TEAM_CASTY.Usuario (Username,Contrase�a) values ('admin','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7');--la contrase�a es w23e
INSERT INTO TEAM_CASTY.Usuario (Username,Contrase�a) values ('guest','16ceb2796ccd9d52d4f2a92134ef9ecfeb8f016150a82d36b299d09d5b9963f0');--la contrase�a es GUEST

--SELECT * FROM TEAM_CASTY.Usuario
	
--Empleados	
CREATE TABLE TEAM_CASTY.Empleado ( 
	Cod_Empleado numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	ID_Tipo_Documento numeric(18) NOT NULL,
	Nro_Documento numeric(18) NOT NULL,
	Nombre nvarchar(255) NOT NULL,
	Apellido nvarchar(255) NOT NULL,
	Mail nvarchar(255) NOT NULL,
	Telefono nvarchar(50) NOT NULL,
	Direccion nvarchar(255) NOT NULL,
	Fecha_Nacimiento datetime NOT NULL,
	Cod_Usuario numeric(18) NOT NULL,
	FOREIGN KEY (Cod_Usuario) REFERENCES TEAM_CASTY.Usuario (Cod_Usuario),
	FOREIGN KEY (ID_Tipo_Documento) REFERENCES TEAM_CASTY.Tipo_Documento (ID_Tipo_Documento));

print('Empleados OK');
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
print('Rol por Usuario por Hotel OK');
--Inhabilitacion de los Hoteles	
CREATE TABLE TEAM_CASTY.Periodo_Inhabilitado ( 
	Cod_Hotel numeric(18) NOT NULL,
	Fecha_Inicio datetime NOT NULL,
	Fecha_Fin datetime NOT NULL,
	Descripcion varchar(255),
	PRIMARY KEY (Cod_Hotel, Fecha_Inicio, Fecha_Fin),--ver
	FOREIGN KEY (Cod_Hotel) REFERENCES TEAM_CASTY.Hotel (Cod_Hotel));	
	
print('Per�odo inhabilitado OK');
--Reservas
CREATE TABLE TEAM_CASTY.Reserva ( 
	Cod_Reserva numeric(18) NOT NULL PRIMARY KEY,
	Fecha_Realizacion datetime DEFAULT GETDATE(),
	Fecha_Reserva datetime NOT NULL,
	Cant_Noches numeric(18) NOT NULL,
	ID_Cliente_Reservador numeric(18) NOT NULL,
	Cod_Regimen numeric(18) DEFAULT NULL,	
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

INSERT INTO TEAM_CASTY.Reserva (Cod_Reserva,Fecha_Reserva,Cant_Noches,Cod_Regimen,ID_Cliente_Reservador,Cod_Estado,Fecha_Realizacion)
SELECT distinct t1.Reserva_Codigo,t1.Reserva_Fecha_Inicio,t1.Reserva_Cant_Noches,t1.Cod_Regimen, t1.ID_Cliente, 1 AS 'Cod_Estado',t1.Reserva_Fecha_Inicio
FROM #reservas_new t1
WHERE t1.Reserva_Codigo in (SELECT res.Reserva_Codigo FROM #reservas_new res)
ORDER BY t1.Reserva_Codigo

DROP TABLE #reservas
DROP TABLE #reservas_new	

--SELECT * FROM TEAM_CASTY.Reserva
print('Reservas OK');
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
print('Habitaciones por Reserva OK');
--Usuario por reserva (para modificacion de Reserva)
CREATE TABLE TEAM_CASTY.ModificacionXReserva ( 
	Cod_Reserva numeric(18) NOT NULL,
	Numero_Modificacion numeric(18) NOT NULL,
	Cod_Usuario numeric(18) NOT NULL,
	Fecha datetime DEFAULT getdate(),	
	Descripcion varchar(255),
	PRIMARY KEY (Cod_Reserva, Numero_Modificacion),
	FOREIGN KEY (Cod_Reserva) REFERENCES TEAM_CASTY.Reserva (Cod_Reserva),
	FOREIGN KEY (Cod_Usuario) REFERENCES TEAM_CASTY.Usuario (Cod_Usuario));

insert into TEAM_CASTY.ModificacionXReserva (Cod_Reserva,Numero_Modificacion,Cod_Usuario,Fecha,Descripcion)	
select res.Cod_Reserva,1,2,res.Fecha_Realizacion,'De la migraci�n'
from TEAM_CASTY.Reserva res
print('Modificaci�n Reservas OK');
--Reservas canceladas
CREATE TABLE TEAM_CASTY.Cancelacion ( 
	Cod_Reserva numeric(18) NOT NULL,
	Motivo varchar(255),
	Fecha datetime NOT NULL,
	Cod_Usuario numeric(18)NOT NULL,
	FOREIGN KEY (Cod_Reserva) REFERENCES TEAM_CASTY.Reserva (Cod_Reserva),
	FOREIGN KEY (Cod_Usuario) REFERENCES TEAM_CASTY.Usuario (Cod_Usuario));
print('Reservas Canceladas OK');
--Estad�a	
CREATE TABLE TEAM_CASTY.Estadia ( 
	Cod_Estadia numeric(18) NOT NULL PRIMARY KEY IDENTITY (1,1),
	Cod_Reserva numeric(18) NOT NULL,
	Fecha_Inicio datetime,
	Fecha_Salida datetime,
	FOREIGN KEY (Cod_Reserva) REFERENCES TEAM_CASTY.Reserva (Cod_Reserva));		
	
insert into TEAM_CASTY.Estadia
(Cod_Reserva,Fecha_Inicio,Fecha_Salida)
select DISTINCT t.Reserva_Codigo,t.Estadia_Fecha_Inicio,t.Estadia_Fecha_Inicio + t.Estadia_Cant_Noches
from gd_esquema.Maestra t join TEAM_CASTY.Reserva r on (r.Cod_Reserva=t.Reserva_Codigo)
where t.Estadia_Fecha_Inicio is not null
order by t.Reserva_Codigo

--select * from TEAM_CASTY.Estadia
print('Estad�as OK');
--Clientes por Estad�a
CREATE TABLE TEAM_CASTY.ClienteXEstadia ( 	
	Cod_Estadia numeric(18) NOT NULL,
	ID_Cliente numeric(18) NOT NULL,
	PRIMARY KEY (Cod_Estadia,ID_Cliente),
	FOREIGN KEY (Cod_Estadia) REFERENCES TEAM_CASTY.Estadia (Cod_Estadia),
	FOREIGN KEY (ID_Cliente) REFERENCES TEAM_CASTY.Cliente (ID_Cliente));	
	
INSERT INTO TEAM_CASTY.ClienteXEstadia
select distinct e.Cod_Estadia,c.ID_Cliente
FROM gd_esquema.Maestra t, TEAM_CASTY.Cliente c, TEAM_CASTY.Estadia e
where t.Cliente_Apellido=c.Apellido and
t.Cliente_Nombre=c.Nombre and
t.Cliente_Pasaporte_Nro=c.Nro_Documento and
e.Cod_Reserva=t.Reserva_Codigo
ORDER BY e.Cod_Estadia,c.ID_Cliente

--SELECT * FROM TEAM_CASTY.ClienteXEstadia	
print('Clientes por Estad�a OK');
--Habitaciones por Estad�a
CREATE TABLE TEAM_CASTY.HabitacionXEstadia ( 	
	Cod_Estadia numeric(18) NOT NULL,
	Cod_Habitacion numeric(18) NOT NULL,
	PRIMARY KEY (Cod_Estadia,Cod_Habitacion),
	FOREIGN KEY (Cod_Estadia) REFERENCES TEAM_CASTY.Estadia (Cod_Estadia),
	FOREIGN KEY (Cod_Habitacion) REFERENCES TEAM_CASTY.Habitacion (Cod_Habitacion));	

INSERT INTO TEAM_CASTY.HabitacionXEstadia (Cod_Estadia,Cod_Habitacion)
SELECT DISTINCT est.Cod_Estadia, hxr.Cod_Habitacion
FROM TEAM_CASTY.Estadia est,TEAM_CASTY.Reserva res, TEAM_CASTY.HabitacionXReserva hxr
where res.Cod_Reserva=est.Cod_Reserva and
res.Cod_Reserva=hxr.Cod_Reserva
ORDER BY est.Cod_Estadia, hxr.Cod_Habitacion

--select * from TEAM_CASTY.HabitacionXEstadia
print('HAbitaciones por Estad�a OK');
--Consumibles por Estadia
CREATE TABLE TEAM_CASTY.ConsumibleXHabitacionXEstadia ( 
	Cod_ConsumibleXHabitacionXEstadia numeric(18)  NOT NULL PRIMARY KEY IDENTITY(1,1),
	Cod_Estadia numeric(18) NOT NULL,
	Cod_Habitacion numeric(18) NOT NULL,
	Cod_Consumible numeric(18) NOT NULL,
	Precio numeric(18,2) NOT NULL,
	Cantidad numeric(18) NOT NULL,	
	FOREIGN KEY (Cod_Habitacion) REFERENCES TEAM_CASTY.Habitacion (Cod_Habitacion),
	FOREIGN KEY (Cod_Estadia) REFERENCES TEAM_CASTY.Estadia (Cod_Estadia),
	FOREIGN KEY (Cod_Consumible) REFERENCES TEAM_CASTY.Consumible (Cod_Consumible));
	
SELECT  distinct est.Cod_Estadia,habXest.Cod_Habitacion, hab.Cod_Hotel, hot.Cod_Ciudad,Numero,ciu.Nombre,Calle,Nro_Calle
INTO #auxiliar
FROM TEAM_CASTY.HabitacionXEstadia habXest JOIN  TEAM_CASTY.Habitacion hab on (habXest.Cod_Habitacion= hab.Cod_Habitacion) 
                                           JOIN TEAM_CASTY.Hotel hot ON(hot.Cod_Hotel = hab.Cod_Hotel)
                                           JOIN TEAM_CASTY.Ciudad ciu ON(hot.Cod_Ciudad = ciu.Cod_Ciudad)
                                           JOIN TEAM_CASTY.Estadia  est ON (est.Cod_Estadia=habXest.Cod_Estadia);
                                           
INSERT INTO TEAM_CASTY.ConsumibleXHabitacionXEstadia (Cod_Estadia,Cod_Habitacion,Cod_Consumible,Precio,Cantidad)
SELECT a.Cod_Estadia, a.Cod_Habitacion,m.Consumible_Codigo,m.Consumible_Precio,count(m.Consumible_Codigo) AS Cantidad
FROM gd_esquema.Maestra m,#auxiliar a,TEAM_CASTY.Estadia est
WHERE est.Cod_Estadia=a.Cod_Estadia and
est.Cod_Reserva=m.Reserva_Codigo and
a.Numero = m.Habitacion_Numero
and a.Nombre = m.Hotel_Ciudad
and a.Calle=m.Hotel_Calle and
a.Nro_Calle = m.Hotel_Nro_Calle and
m.Consumible_Codigo is not null and m.Factura_Nro is not null
GROUP BY a.Cod_Estadia, a.Cod_Habitacion,m.Consumible_Codigo,m.Consumible_Precio

DROP TABLE #auxiliar

--select * from TEAM_CASTY.ConsumibleXHabitacionXEstadia
print('Consumibles por Estad�a OK');
--Cambiar estado de las reservas con check in
UPDATE res
SET res.Cod_Estado=6
from TEAM_CASTY.Reserva res join TEAM_CASTY.Estadia est on (res.Cod_Reserva=est.Cod_Reserva)
print('Actualizaci�n Reservas por las Estad�as OK');

--Facturas
CREATE TABLE TEAM_CASTY.Factura ( 
	Nro_Factura numeric(18) NOT NULL PRIMARY KEY,
	Fecha datetime NOT NULL,	
	Total numeric(18,2) NOT NULL,
	Cod_Estadia numeric(18) NOT NULL,
	Cod_Forma_Pago numeric(18) NOT NULL,
	FOREIGN KEY (Cod_Forma_Pago) REFERENCES TEAM_CASTY.Forma_Pago (Cod_Forma_Pago),
	FOREIGN KEY (Cod_Estadia) REFERENCES TEAM_CASTY.Estadia (Cod_Estadia));

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

INSERT INTO TEAM_CASTY.Factura (Nro_Factura,Fecha,Cod_Estadia,Cod_Forma_Pago,Total)
SELECT DISTINCT  auxiliar.Nro_Factura AS "Nro_Factura", auxiliar.Factura_Fecha AS "Fecha", e.Cod_Estadia, 1 AS "Cod_Forma_Pago" , SUM (auxiliar.Total) AS "Total"
FROM TEAM_CASTY.Auxiliar_Item_Total auxiliar JOIN TEAM_CASTY.Estadia e ON(e.Cod_Reserva=auxiliar.Reserva_Codigo)
group by auxiliar.Nro_Factura, auxiliar.Factura_Fecha,  e.Cod_Estadia
order by 1

DROP TABLE TEAM_CASTY.Auxiliar_Item_Total

--SELECT * FROM TEAM_CASTY.Factura
print('Facturas OK');
--Tarjetas, solo se crea, no tiene datos al principio
CREATE TABLE TEAM_CASTY.Tarjeta ( 
	Numero numeric(18) NOT NULL,
	Banco nvarchar(255) NOT NULL,
	ID_Cliente numeric(18) NOT NULL,
	PRIMARY KEY (Numero, Banco),
	FOREIGN KEY (ID_Cliente) REFERENCES TEAM_CASTY.Cliente (ID_Cliente));
print('Tarjetas OK');
--TarjetaXFactura, solo se crea, no tiene datos al principio
CREATE TABLE TEAM_CASTY.TarjetaXFactura ( 
	Nro_Factura numeric(18) NOT NULL,
	Numero_Tarjeta numeric(18) NOT NULL,
	Banco nvarchar(255) NOT NULL,
	PRIMARY KEY (Nro_Factura, Numero_Tarjeta, Banco),
	FOREIGN KEY (Nro_Factura) REFERENCES TEAM_CASTY.Factura (Nro_Factura),
	FOREIGN KEY (Numero_Tarjeta, Banco) REFERENCES TEAM_CASTY.Tarjeta (Numero, Banco));
print('Tarjetas por Factura OK');
--consumible, habitacion y factura
CREATE TABLE TEAM_CASTY.item_ConsumibleXFactura ( 
	Nro_Factura numeric(18) NOT NULL,
	Cod_ConsumibleXHabitacionXEstadia numeric(18) NOT NULL,
	PRIMARY KEY (Nro_Factura,Cod_ConsumibleXHabitacionXEstadia),
	FOREIGN KEY (Nro_Factura) REFERENCES TEAM_CASTY.Factura (Nro_Factura),
	FOREIGN KEY (Cod_ConsumibleXHabitacionXEstadia) REFERENCES TEAM_CASTY.ConsumibleXHabitacionXEstadia (Cod_ConsumibleXHabitacionXEstadia));

INSERT INTO TEAM_CASTY.item_ConsumibleXFactura (Nro_Factura,Cod_ConsumibleXHabitacionXEstadia)
SELECT f.Nro_Factura,chr.Cod_ConsumibleXHabitacionXEstadia
FROM TEAM_CASTY.ConsumibleXHabitacionXEstadia chr, TEAM_CASTY.Factura f, TEAM_CASTY.Estadia est
WHERE f.Cod_Estadia=est.Cod_Estadia and
est.Cod_Estadia=chr.Cod_Estadia

--select * from TEAM_CASTY.item_ConsumibleXFactura
print('Item consumible de factura OK');
--estadia, habitacion y factura
CREATE TABLE TEAM_CASTY.item_habitacionXFactura ( 
	Nro_Factura numeric(18) NOT NULL,
	Cod_Habitacion numeric(18) NOT NULL,
	Cod_Regimen numeric(18) NOT NULL,
	Dias_Completados numeric(18) NOT NULL,
	Monto_Completados numeric(18,2) NOT NULL,
	Dias_Faltantes numeric(18) DEFAULT 0 NOT NULL,
	Monto_Faltantes numeric(18,2) DEFAULT 0 NOT NULL,
	PRIMARY KEY (Nro_Factura,Cod_Habitacion,Cod_Regimen),
	FOREIGN KEY (Cod_Habitacion) REFERENCES TEAM_CASTY.Habitacion (Cod_Habitacion),
	FOREIGN KEY (Nro_Factura) REFERENCES TEAM_CASTY.Factura (Nro_Factura),
	FOREIGN KEY (Cod_Regimen) REFERENCES TEAM_CASTY.Regimen (Cod_Regimen));

INSERT INTO TEAM_CASTY.item_habitacionXFactura (Nro_Factura,Cod_Habitacion,Cod_Regimen,Monto_Completados,Dias_Completados)
SELECT f.Nro_Factura, hxe.Cod_Habitacion, res.Cod_Regimen, res.Cant_Noches*reg.Precio*thab.Porcentual+hot.CantEstrella*rec.Recarga AS Monto,res.Cant_Noches
FROM TEAM_CASTY.Factura f, TEAM_CASTY.Habitacion hab, TEAM_CASTY.HabitacionXEstadia hxe, TEAM_CASTY.Hotel hot, TEAM_CASTY.Recarga_Estrella rec, TEAM_CASTY.Regimen reg, TEAM_CASTY.Estadia est,TEAM_CASTY.Tipo_Habitacion thab, TEAM_CASTY.Reserva res
WHERE f.Cod_Estadia=est.Cod_Estadia and
est.Cod_Estadia=hxe.Cod_Estadia and
hxe.Cod_Habitacion=hab.Cod_Habitacion and
hab.Cod_Hotel=hot.Cod_Hotel and
rec.Cod_Recarga=1 and
res.Cod_Regimen=reg.Cod_Regimen and
thab.Cod_Tipo=hab.Cod_Tipo and
res.Cod_Reserva=est.Cod_Reserva

--select * from TEAM_CASTY.item_habitacionXFactura
print('Item habitaci�n de factura OK')

GO

create procedure TEAM_CASTY.validarUsuario
(@usuario nvarchar(255),@contrase�a nvarchar(255))
as
begin

declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error:';

if exists (select * from TEAM_CASTY.Usuario u where u.Username=@usuario and u.Habilitado =0 ) -- si existe y esta inhabilitado
begin  
	set @error=1;
	set @mensaje+=' Usuario inhabilitado.';  
end
else
begin
     if exists (select * from TEAM_CASTY.Usuario u where u.Username=@usuario and u.Habilitado =1 )-- si  existe y esta habilitado
     begin  
		if  exists (select * from TEAM_CASTY.Usuario u where u.Username=@usuario and u.Contrase�a = @contrase�a )-- si la contrase�a es correcta
        begin
			update TEAM_CASTY.Usuario set Cant_Intentos=0 where Username = @usuario;
           --tiene q devolver 1??
        end  
        else -- si la contrase�a es incorrecta
        begin
			set @error=1;
			set @mensaje+=' Contrase�a incorrecta.'; 
			update TEAM_CASTY.Usuario set Cant_Intentos= Cant_Intentos + 1 where Username = @usuario
            update TEAM_CASTY.Usuario set Habilitado=0 where Username = @usuario and Cant_Intentos >= 3
            if((select u.Cant_Intentos from TEAM_CASTY.Usuario u where u.Username=@usuario)=3)
            begin
				set @mensaje+=' Se inahabilit� al usuario.'; 
           end           
        end      
     end   
     else-- si no existe
     begin
         set @error=1;
		 set @mensaje+=' Usuario inexistente.'; 
     end   
end

if (@error=1)
begin
	set @mensaje=@mensaje + ' No se realiz� el log in.';
	RAISERROR (@mensaje,15,1);
end
end

--CREATE FUNCTION TEAM_CASTY.HotelesPorUsario
--(@usuario nvarchar(255))
--RETURNS TABLE
--AS
--RETURN 
--   select vistaClientes.*
--   from TEAM_CASTY.RolXUsuarioXHotel RxUxH,TEAM_CASTY.Usuario u, TEAM_CASTY.vistaHoteles h
--   where @usuario=u.Username and
--   RxUxH.Cod_Usuario = u.Cod_Usuario and
--   RxUxH.Cod_Hotel=h.Codigo;

CREATE FUNCTION TEAM_CASTY.RolesDeUsuarioEnHotel
(@usuario nvarchar(255),@hotel numeric(18))
RETURNS TABLE
AS
RETURN 
   select distinct r.Cod_Rol as [Codigo de Rol], r.Nombre as [Nombre de Rol]
   from TEAM_CASTY.RolXUsuarioXHotel RxUxH, TEAM_CASTY.Rol r, TEAM_CASTY.Usuario u
   where  @usuario=u.Username and
   RxUxH.Cod_Rol = r.Cod_Rol and
   RxUxH.Cod_Hotel = @hotel and
   RxUxH.Cod_Usuario = u.Cod_Usuario;
   
CREATE FUNCTION TEAM_CASTY.FuncionesDeUnRol
(@Rol numeric(18))
RETURNS TABLE
AS
RETURN 
   select distinct f.Cod_Funcion, f.Descripcion
   from TEAM_CASTY.Funcion f , TEAM_CASTY.Rol r , TEAM_CASTY.FuncionXRol fXr
   where  @Rol = r.Cod_Rol and r.Cod_Rol = fXr.Cod_Rol and fXr.Cod_Funcion=f.Cod_Funcion

GO

create view TEAM_CASTY.vistaClientes
(Codigo, Nombre, Apellido, Mail, "Tipo Documento", "Numero Documento",Telefono,Pais,Localidad,"Calle","Numero Calle",Piso, "Departamento", Nacionalidad,"Fecha Nacimiento")
AS
select c.ID_Cliente, c.Nombre, c.Apellido, c.Mail, d.Tipo_Documento, c.Nro_Documento, c.Telefono, c.Pais, c.Localidad, c.Nom_Calle, c.Nro_Calle, c.Piso ,c.Dto,c.Nacionalidad, c.Fecha_Nacimiento
from TEAM_CASTY.Cliente c, TEAM_CASTY.Tipo_Documento d
where c.Baja=0;

Create view TEAM_CASTY.vistaHoteles(Codigo,Nombre,Ciudad,Calle,"Numero Calle",Telefono,Mail,"Cantidad de estrellas", "Recarga por estrella" )
AS
select  h.Cod_Hotel, h.Nombre, c.Nombre ,h.Calle,h.Nro_Calle,h.Telefono,h.Mail,h.CantEstrella,re.Recarga  
from TEAM_CASTY.Hotel h, TEAM_CASTY.Ciudad c , TEAM_CASTY.Recarga_Estrella re
where h.Cod_Ciudad= c.Cod_Ciudad;

GO

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
select ins.Apellido,ins.Calle,ins.Departamento,ins.[Fecha Nacimiento],ins.Localidad,ins.Mail,ins.Nacionalidad,ins.Nombre,
ins.[Numero Calle],ins.[Numero Documento],ins.Pais,ins.Piso,ins.Telefono,tdoc.ID_Tipo_Documento
from inserted ins, TEAM_CASTY.Tipo_Documento tdoc
where tdoc.Tipo_Documento=ins.[Tipo Documento]
end

else
begin
set @mensaje=@mensaje + ' No se realiz� el alta.';
RAISERROR (@mensaje,15,1);
end

end;

GO

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

GO

create trigger TEAM_CASTY.modif_clientes
ON TEAM_CASTY.vistaClientes
instead of update
AS
begin

declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error:';

if(exists (select * from TEAM_CASTY.Cliente c,inserted ins where c.Mail=ins.Mail and ins.Codigo<>c.ID_Cliente))
begin
set @error=1
set @mensaje=@mensaje + ' Mail repetido.';
end

if(exists (select * from TEAM_CASTY.Cliente c,inserted ins,TEAM_CASTY.Tipo_Documento tdoc where c.Nro_Documento=ins.[Numero Documento] and tdoc.Tipo_Documento=ins.[Tipo Documento] and c.ID_Tipo_Documento=tdoc.ID_Tipo_Documento and c.ID_Cliente<>ins.Codigo))
begin
set @error=1
set @mensaje=@mensaje + ' Documento repetido.';
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
set @mensaje=@mensaje + ' No se realiz� la modificaci�n.';
RAISERROR (@mensaje,10,1);
end

end;

GO

create procedure TEAM_CASTY.CambiarPassword
(@usuario nvarchar(255),@contrase�a nvarchar(255))
as
begin
update TEAM_CASTY.Usuario
set Contrase�a=@contrase�a
where @usuario=Cod_Usuario;
end;

create procedure TEAM_CASTY.CargarHabitacion
(@hotel numeric(18), @numero numeric(18),@piso numeric(18),@frente char(1),@tipo nvarchar(255),@descripcion nvarchar(255))
as
begin

declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error:';

if(exists (select * from TEAM_CASTY.Habitacion hab where hab.Cod_Hotel=@hotel and hab.Numero=@numero and @piso=hab.Piso))
begin
set @error=1
set @mensaje=@mensaje + ' Habitaci�n existente.';
end

if(@error=0)
begin
declare @cod_tipo numeric(18);
select @cod_tipo=th.Cod_Tipo
from TEAM_CASTY.Tipo_Habitacion th
where th.Descripcion=@tipo;
insert into TEAM_CASTY.Habitacion
(Cod_Hotel,Cod_Tipo,Descripcion,Cod_Tipo,Frente,Numero,Piso)
values (@hotel,@cod_tipo,@descripcion,@frente,@numero,@piso);
end

else
begin
set @mensaje=@mensaje + ' No se realiz� el alta.';
RAISERROR (@mensaje,15,1);
end

end;

GO

create procedure TEAM_CASTY.ModificarHabitacion
(@hotel numeric(18), @numero numeric(18),@piso numeric(18),@frente char(1),@tipo nvarchar(255),@descripcion nvarchar(255), @baja numeric(18))
as
begin

declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error:';

if(@baja=1)
begin
set @error=1
set @mensaje=@mensaje + ' No se puede dar de baja.';
end

if(exists (select * from TEAM_CASTY.Habitacion hab where hab.Cod_Hotel=@hotel and hab.Numero=@numero and @piso=hab.Piso))
begin
set @error=1
set @mensaje=@mensaje + ' Habitaci�n existente.';
end

if(@error=0)
begin
update TEAM_CASTY.Habitacion
set Descripcion=@descripcion,Numero=@numero,Piso=@piso,Frente=@frente,Baja=0
where Cod_Hotel=@hotel and Numero=@numero and Piso=@piso;
end

else
begin
set @mensaje=@mensaje + ' No se realiz� la modificaci�n.';
RAISERROR (@mensaje,15,1);
end

end;

GO
create procedure TEAM_CASTY.BajarHabitacion
(@hotel numeric(18), @numero numeric(18),@piso numeric(18),@fecha datetime)
as
begin

declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error:';

if(exists (select * from TEAM_CASTY.Habitacion hab where hab.Cod_Hotel=@hotel and hab.Numero=@numero and @piso=hab.Piso))
begin
set @error=1
set @mensaje=@mensaje + ' Habitaci�n existente.';
end

if (exists(
select *
from TEAM_CASTY.Habitacion hab, TEAM_CASTY.Reserva res, TEAM_CASTY.HabitacionXReserva hxr
where hab.Cod_Hotel=@hotel and hab.Piso=@piso and @numero=hab.Numero and
hxr.Cod_Habitacion=hab.Cod_Habitacion and
res.Cod_Reserva=hxr.Cod_Reserva and
res.Cod_Estado=1 and
datediff(day,res.Fecha_Reserva,@fecha)>0
))
begin
set @error=1
set @mensaje=@mensaje + ' La habitaci�n tiene reservas, en el futuro o actualmente.';
end

if (exists(
SELECT *
from TEAM_CASTY.Estadia est, TEAM_CASTY.Habitacion hab, TEAM_CASTY.HabitacionXEstadia hxe
where hab.Piso=@piso and hab.Numero=@numero and hab.Cod_Hotel=@hotel and
hab.Cod_Habitacion=hxe.Cod_Habitacion and
hxe.Cod_Estadia=est.Cod_Estadia and
datediff(day,est.Fecha_Inicio,@fecha)>0 and datediff(day,@fecha,est.Fecha_Salida)<0
))
begin
set @error=1
set @mensaje=@mensaje + ' La habitaci�n tiene una estad�a.';
end

if(@error=0)
begin
update TEAM_CASTY.Habitacion
set Baja=1
where Cod_Hotel=@hotel and Numero=@numero and Piso=@piso;
end

else
begin
set @mensaje=@mensaje + ' No se realiz� la baja.';
RAISERROR (@mensaje,15,1);
end

end;

GO

create function  TEAM_CASTY.Precios_Por_Dia
(@hotel numeric(18))
RETURNS @tablaPorDia TABLE(
Regimen nvarchar(255),
[Tipo Habitaci�n] nvarchar(255),
[Precio Por Dia] numeric(18,2))
AS
begin
INSERT  into @tablaPorDia 
select distinct reg.Descripcion, thab.Descripcion, (reg.Precio*thab.Porcentual+(hot.CantEstrella*(select top 1 rec.Recarga from TEAM_CASTY.Recarga_Estrella rec order by rec.Fecha_Modificacion desc))) [Precio Por Dia]
from TEAM_CASTY.Tipo_Habitacion thab,TEAM_CASTY.Hotel hot,TEAM_CASTY.Regimen reg, TEAM_CASTY.RegimenXHotel rxh
where hot.Cod_Hotel=@hotel and rxh.Cod_Hotel=@hotel and rxh.Activo=1
RETURN 
end;

GO

create function TEAM_CASTY.FuncionesAsignables
()
RETURNS @tabla TABLE(
Codigo numeric (18) not null,
Descripcion nvarchar(255) not null)
AS
begin
insert into @tabla
select f.Cod_Funcion,f.Descripcion
from TEAM_CASTY.Funcion f
where f.Cod_Funcion not in (2,4,5,6)
return;
end;

GO

create function TEAM_CASTY.RegimenesElegibles
(@hotel numeric (18))
RETURNS @tabla TABLE(
Codigo numeric (18) not null,
Descripcion nvarchar(255) not null)
AS
begin
insert into @tabla
select reg.Cod_Regimen,reg.Descripcion
from TEAM_CASTY.Regimen reg, TEAM_CASTY.RegimenXHotel rxh
where reg.Cod_Regimen=rxh.Cod_Regimen and rxh.Cod_Hotel=@hotel and rxh.Activo=1
return;
end;

GO

CREATE TYPE [TEAM_CASTY].[t_funcion] AS TABLE(
	[funcion] [nvarchar](50) NULL)
	
GO

create view TEAM_CASTY.vistaRoles
AS  
select rol.Cod_Rol as [Codigo de Rol], rol.Nombre,rol.Activo
from  TEAM_CASTY.Rol rol
where rol.Cod_Rol<>1

GO

create procedure  TEAM_CASTY.Alta_Rol
@nombre varchar(250), @funciones TEAM_CASTY.t_funcion READONLY, @Activo numeric(18)
AS
begin
declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error:';

if (not exists(select *
		   from @funciones f
	       where f.funcion in (select f.Descripcion from TEAM_CASTY.Funcion f)))
begin
set @error=1;
set @mensaje=@mensaje + ' Funci�n inexistente.';
end

if (exists(select *
		   from TEAM_CASTY.Rol r
		   where @nombre=r.Nombre))
begin
set @error=1;
set @mensaje=@mensaje + ' Rol existente.';
end

if (@error=0) 
begin
 
insert into TEAM_CASTY.Rol
(Activo,Nombre)
values (1,@nombre);

insert into TEAM_CASTY.FuncionXRol
select r.Cod_Rol,fun.Cod_Funcion
from @funciones f join TEAM_CASTY.Funcion fun on (f.funcion = fun.Descripcion)
				  join TEAM_CASTY.Rol r on (r.Nombre=@nombre)

end

else
begin
set @mensaje=@mensaje + ' No se realiz� el alta.';
RAISERROR (@mensaje,15,1);
end
end;

GO

create procedure  TEAM_CASTY.Modificacion_Rol
(@codigo numeric (18), @nombre varchar(250), @funciones TEAM_CASTY.t_funcion READONLY, @activo numeric(18))
AS
begin
declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error:';

if (not exists(select *
		   from @funciones f
	       where f.funcion in (select f.Descripcion from TEAM_CASTY.Funcion f)))
begin
set @error=1;
set @mensaje=@mensaje + ' Funci�n inexistente.';
end

if (not exists(select *
		   from TEAM_CASTY.Rol r
		   where @codigo=r.Cod_Rol))
begin
set @error=1;
set @mensaje=@mensaje + ' Rol inexistente.';
end

if (@error=0) 
begin
update TEAM_CASTY.Rol
set Nombre=@nombre
where Cod_Rol=@codigo;
delete from TEAM_CASTY.FuncionXRol
where @codigo=Cod_Rol;
insert into TEAM_CASTY.FuncionXRol
select r.Cod_Rol,fun.Cod_Funcion
from @funciones f join TEAM_CASTY.Funcion fun on (f.funcion = fun.Descripcion)
				  join TEAM_CASTY.Rol r on (@codigo=r.Cod_Rol);
if(@activo=1)
begin
update TEAM_CASTY.Rol
set Activo=1
where @codigo=Cod_Rol;
end
end

else
begin
set @mensaje=@mensaje + ' No se realiz� la modificaci�n.';
RAISERROR (@mensaje,15,1);
end
end;

GO

create procedure  TEAM_CASTY.Baja_Rol
@nombre varchar(250)
AS
begin
declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error:';


if (exists(select *
		   from TEAM_CASTY.Rol r
		   where @nombre=r.Nombre))
begin
set @error=1;
set @mensaje=@mensaje + ' Rol existente.';
end

if (@error=0) 
begin
declare @cod_rol numeric(18); 
select @cod_rol=r.Cod_Rol
from TEAM_CASTY.Rol r
where @nombre=Nombre;
update TEAM_CASTY.Rol
set Activo=0
where @cod_rol=Cod_Rol;
end

else
begin
set @mensaje=@mensaje + ' No se realiz� la baja.';
RAISERROR (@mensaje,15,1);
end
end;

GO

create view TEAM_CASTY.vistaHoteles
(Codigo,Pais,Nombre,Ciudad,Calle,[Numero Calle],Telefono,Mail,[Fecha Creacion],[Cantidad de estrellas], [Recarga por estrella])
AS
select  h.Cod_Hotel, h.Pais,h.Nombre, c.Nombre ,h.Calle,h.Nro_Calle,h.Telefono,h.Mail,h.Fecha_Creacion,h.CantEstrella,re.Recarga  
from TEAM_CASTY.Hotel h, TEAM_CASTY.Ciudad c , TEAM_CASTY.Recarga_Estrella re
where h.Cod_Ciudad= c.Cod_Ciudad

GO

create view TEAM_CASTY.vistaClientes
(Codigo, Nombre, Apellido, Mail, "Tipo Documento", "Numero Documento",Telefono,Pais,Localidad,"Calle","Numero Calle",Piso, "Departamento", Nacionalidad,"Fecha Nacimiento",Inhabilitado)
AS
select c.ID_Cliente, c.Nombre, c.Apellido, c.Mail, d.Tipo_Documento, c.Nro_Documento, c.Telefono, c.Pais, c.Localidad, c.Nom_Calle, c.Nro_Calle, c.Piso ,c.Dto,c.Nacionalidad, c.Fecha_Nacimiento,c.Inhabilitado
from TEAM_CASTY.Cliente c, TEAM_CASTY.Tipo_Documento d
where c.Baja=0

GO

create view TEAM_CASTY.vistaClientesErroneos
(Codigo, Nombre, Apellido, Mail, "Tipo Documento", "Numero Documento",Telefono,Pais,Localidad,"Calle","Numero Calle",Piso, "Departamento", Nacionalidad,"Fecha Nacimiento",Inhabilitado)
AS
select c.ID_Cliente, c.Nombre, c.Apellido, c.Mail, d.Tipo_Documento, c.Nro_Documento, c.Telefono, c.Pais, c.Localidad, c.Nom_Calle, c.Nro_Calle, c.Piso ,c.Dto,c.Nacionalidad, c.Fecha_Nacimiento,c.Inhabilitado
from TEAM_CASTY.Cliente c, TEAM_CASTY.Tipo_Documento d
where c.Baja=0 and c.Erroneo=1

GO

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
set @mensaje=@mensaje + ' No se realiz� el alta.';
RAISERROR (@mensaje,15,1);
end

end;

GO

create trigger TEAM_CASTY.modificacion_clientes
ON TEAM_CASTY.vistaClientes
instead of update
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
set @mensaje=@mensaje + ' No se realiz� la modificaci�n.';
RAISERROR (@mensaje,15,1);
end

end;

GO

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

GO

CREATE TYPE TEAM_CASTY.t_tablaConsumibles AS TABLE(
	Cod_Habitacion numeric (18),
	Nombre nvarchar (50),
	Cantidad numeric (18));
	
GO

create procedure  TEAM_CASTY.RegistrarConsumibles
@cod_Estadia numeric(18),@tabla TEAM_CASTY.t_tablaConsumibles READONLY
AS
begin
declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error: ';

if(not exists (select * from TEAM_CASTY.Estadia e where e.Cod_Estadia=@cod_Estadia))
begin
	set @error=1;
	set @mensaje+=' No existe esa estad�a.';
end

if (exists (select * from @tabla t where t.Nombre not in (select c.Descripcion from TEAM_CASTY.Consumible c)))
begin
	set @error=1;
	set @mensaje+=' Consumible inexistente.';
end
 
if(exists(select * from @tabla t where t.Cod_Habitacion not in (select hxe.Cod_Habitacion from TEAM_CASTY.HabitacionXEstadia hxe where hxe.Cod_Estadia=@cod_Estadia)))
begin
	set @error=1;
	set @mensaje+=' Habitaci�n no correspondiente a estad�a.';
end 
 
if(exists (select * from @tabla t where t.Cantidad<0))
begin
	set @error=1;
	set @mensaje+=' Cantidad incorrecta.';
end 
 
if (@error=0)	
begin
	insert into TEAM_CASTY.ConsumibleXHabitacionXEstadia
	(Cod_Estadia,Cod_Habitacion,Cod_Consumible,Precio,Cantidad)
	select @cod_Estadia,t.Cod_Habitacion,con.Cod_Consumible,con.Precio,t.Cantidad
	from TEAM_CASTY.Consumible con, @tabla t
	where t.Nombre=con.Descripcion;
end
else
begin
	set @mensaje=@mensaje + 'No se realiz� el registro de consumibles.';
	RAISERROR (@mensaje,15,1);
end
end;

GO