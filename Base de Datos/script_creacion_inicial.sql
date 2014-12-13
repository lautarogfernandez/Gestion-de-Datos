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
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('ABM de Habitación');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('ABM Régimen de Estadía');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('Generar o Modificar un Reserva');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('Cancelar Reserva');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('Registrar Estadía');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('Registrar Consumibles');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('Facturar Estadía');
INSERT INTO TEAM_CASTY.Funcion(Descripcion) VALUES ('Listado Estadístico');

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
print('Tipos de Habitación OK');
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
INSERT INTO TEAM_CASTY.Estados(Nombre,Descripcion) VALUES ('Modificada','Reserva modificada (la misma sufrió algún cambio y no es la misma al momento de su creación)');
INSERT INTO TEAM_CASTY.Estados(Nombre,Descripcion) VALUES ('Cancelada Recepción','Reserva cancelada por Recepción');
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
INSERT INTO TEAM_CASTY.Forma_Pago(Descripcion) VALUES ('Tarjeta de Crédito');
--INSERT INTO TEAM_CASTY.Forma_Pago(Descripcion) VALUES ('Tarjeta de Débito'); --¿va? ¿alguno más?

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
	Contraseña nvarchar(255) NOT NULL,	
	Cant_Intentos numeric(18) DEFAULT 0 NOT NULL,
	Habilitado bit DEFAULT 1 NOT NULL,
	Baja bit DEFAULT 0 NOT NULL);
	
INSERT INTO TEAM_CASTY.Usuario (Username,Contraseña) values ('admin','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7');--la contraseña es w23e
INSERT INTO TEAM_CASTY.Usuario (Username,Contraseña) values ('guest','16ceb2796ccd9d52d4f2a92134ef9ecfeb8f016150a82d36b299d09d5b9963f0');--la contraseña es GUEST

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
	
print('Período inhabilitado OK');
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
select res.Cod_Reserva,1,2,res.Fecha_Realizacion,'De la migración'
from TEAM_CASTY.Reserva res
print('Modificación Reservas OK');
--Reservas canceladas
CREATE TABLE TEAM_CASTY.Cancelacion ( 
	Cod_Reserva numeric(18) NOT NULL,
	Motivo varchar(255),
	Fecha datetime NOT NULL,
	Cod_Usuario numeric(18)NOT NULL,
	FOREIGN KEY (Cod_Reserva) REFERENCES TEAM_CASTY.Reserva (Cod_Reserva),
	FOREIGN KEY (Cod_Usuario) REFERENCES TEAM_CASTY.Usuario (Cod_Usuario));
print('Reservas Canceladas OK');
--Estadía	
CREATE TABLE TEAM_CASTY.Estadia ( 
	Cod_Estadia numeric(18) NOT NULL PRIMARY KEY IDENTITY (1,1),
	Cod_Reserva numeric(18) NOT NULL,
	Fecha_Inicio datetime,
	Fecha_Salida datetime,
	Usuario_Inicio numeric(18),
	Usuario_Salida numeric(18),
	FOREIGN KEY (Cod_Reserva) REFERENCES TEAM_CASTY.Reserva (Cod_Reserva));		
	
insert into TEAM_CASTY.Estadia
(Cod_Reserva,Fecha_Inicio,Fecha_Salida)
select DISTINCT t.Reserva_Codigo,t.Estadia_Fecha_Inicio,t.Estadia_Fecha_Inicio + t.Estadia_Cant_Noches
from gd_esquema.Maestra t join TEAM_CASTY.Reserva r on (r.Cod_Reserva=t.Reserva_Codigo)
where t.Estadia_Fecha_Inicio is not null
order by t.Reserva_Codigo

--select * from TEAM_CASTY.Estadia
print('Estadías OK');
--Clientes por Estadía
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
print('Clientes por Estadía OK');
--Habitaciones por Estadía
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
print('HAbitaciones por Estadía OK');
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
print('Consumibles por Estadía OK');
--Cambiar estado de las reservas con check in
UPDATE res
SET res.Cod_Estado=6
from TEAM_CASTY.Reserva res join TEAM_CASTY.Estadia est on (res.Cod_Reserva=est.Cod_Reserva)
print('Actualización Reservas por las Estadías OK');

--Facturas
CREATE TABLE TEAM_CASTY.Factura ( 
	Nro_Factura numeric(18) NOT NULL PRIMARY KEY,
	Fecha datetime NOT NULL,	
	Total numeric(18,2) NOT NULL,
	Cod_Estadia numeric(18) NOT NULL,
	Cod_Forma_Pago numeric(18) NOT NULL,
	Puntos numeric(18),
	FOREIGN KEY (Cod_Forma_Pago) REFERENCES TEAM_CASTY.Forma_Pago (Cod_Forma_Pago),
	FOREIGN KEY (Cod_Estadia) REFERENCES TEAM_CASTY.Estadia (Cod_Estadia));

CREATE TABLE TEAM_CASTY.Auxiliar_Item_Total ( 
    Factura_Fecha datetime NOT NULL,
	Reserva_Codigo numeric(18) NOT NULL,
	Nro_Factura numeric(18) NOT NULL,
	Total numeric(18,2) NOT NULL,
	Puntos numeric(18));

INSERT INTO TEAM_CASTY.Auxiliar_Item_Total (Reserva_Codigo,Factura_Fecha,Nro_Factura,Total,Puntos)
select m1.Reserva_Codigo ,m1.Factura_Fecha, m1.Factura_Nro, m1.Consumible_Precio as  "Total",cast (round(m1.Consumible_Precio/5,0,1) as int)
from gd_esquema.Maestra m1
where m1.Consumible_Codigo is not null and m1.Factura_Nro is not null and m1.Regimen_Descripcion not in ('All inclusive');

INSERT INTO TEAM_CASTY.Auxiliar_Item_Total (Reserva_Codigo,Factura_Fecha,Nro_Factura,Total,Puntos)
select m1.Reserva_Codigo,m1.Factura_Fecha, m1.Factura_Nro , (m1.Reserva_Cant_Noches * m1.Item_Factura_Monto) as "Total",cast(round((m1.Reserva_Cant_Noches * m1.Item_Factura_Monto)/10,0,1)as int)
from gd_esquema.Maestra m1
where m1.Consumible_Codigo is null and m1.Factura_Nro is not null

INSERT INTO TEAM_CASTY.Factura (Nro_Factura,Fecha,Cod_Estadia,Cod_Forma_Pago,Total,Puntos)
SELECT DISTINCT  auxiliar.Nro_Factura AS "Nro_Factura", auxiliar.Factura_Fecha AS "Fecha", e.Cod_Estadia, 1 AS "Cod_Forma_Pago" , SUM (auxiliar.Total) AS "Total",SUM(auxiliar.Puntos)
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
print('Item habitación de factura OK')

GO

create procedure TEAM_CASTY.validarUsuario
(@usuario nvarchar(255),@contraseña nvarchar(255))
as
begin

declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error:';

if(@usuario<>'guest')
begin

if exists (select * from TEAM_CASTY.Usuario u where u.Username=@usuario and u.Habilitado =0 ) -- si existe y esta inhabilitado
	begin  
		set @error=1;
		set @mensaje+=' Usuario inhabilitado.';  
	end
	else
	begin
		 if exists (select * from TEAM_CASTY.Usuario u where u.Username=@usuario and u.Habilitado =1 )-- si  existe y esta habilitado
		 begin  
			if  exists (select * from TEAM_CASTY.Usuario u where u.Username=@usuario and u.Contraseña = @contraseña )-- si la contraseña es correcta
			begin
				update TEAM_CASTY.Usuario set Cant_Intentos=0 where Username = @usuario;
			end  
			else -- si la contraseña es incorrecta
			begin
				set @error=1;
				set @mensaje+=' Contraseña incorrecta.'; 
				update TEAM_CASTY.Usuario set Cant_Intentos= Cant_Intentos + 1 where Username = @usuario
				update TEAM_CASTY.Usuario set Habilitado=0 where Username = @usuario and Cant_Intentos >= 3
				if((select u.Cant_Intentos from TEAM_CASTY.Usuario u where u.Username=@usuario)=3)
				begin
					set @mensaje+=' Se inahabilitó al usuario.'; 
			   end           
			end      
		 end   
		 else-- si no existe
		 begin
			 set @error=1;
			 set @mensaje+=' Usuario inexistente.'; 
		 end   
	end
end
if (@error=1)
begin
	set @mensaje=@mensaje + ' No se realizó el log in.';
	RAISERROR (@mensaje,15,1);
end
end

GO


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
   
  GO
   
CREATE FUNCTION TEAM_CASTY.FuncionesDeUnRol
(@Rol numeric(18))
RETURNS TABLE
AS
RETURN 
   select distinct f.Cod_Funcion, f.Descripcion
   from TEAM_CASTY.Funcion f , TEAM_CASTY.Rol r , TEAM_CASTY.FuncionXRol fXr
   where  @Rol = r.Cod_Rol and r.Cod_Rol = fXr.Cod_Rol and fXr.Cod_Funcion=f.Cod_Funcion

GO

create view TEAM_CASTY.vistaUsuarios
as
select u.Cod_Usuario as Codigo,u.Username,e.Apellido,e.Nombre,e.Mail,td.Tipo_Documento as "Tipo de Documento",e.Nro_Documento as "Numero de Documento", e.Telefono, e.Direccion,e.Fecha_Nacimiento "Fecha de Nacimiento",u.Habilitado
 from TEAM_CASTY.Usuario u , TEAM_CASTY.Empleado e ,TEAM_CASTY.Tipo_Documento td
where e.Cod_Usuario = u.Cod_Usuario and td.ID_Tipo_Documento = e.ID_Tipo_Documento and u.Username not in ('admin','guest') and u.Baja = 0 
go

create view TEAM_CASTY.vistaClientes
(Codigo, Nombre, Apellido, Mail, "Tipo Documento", "Numero Documento",Telefono,Pais,Localidad,"Calle","Numero Calle",Piso, "Departamento", Nacionalidad,"Fecha Nacimiento",Inhabilitado)
AS
select c.ID_Cliente, c.Nombre, c.Apellido, c.Mail, d.Tipo_Documento, c.Nro_Documento, c.Telefono, c.Pais, c.Localidad, c.Nom_Calle, c.Nro_Calle, c.Piso ,c.Dto,c.Nacionalidad, c.Fecha_Nacimiento,c.Inhabilitado
from TEAM_CASTY.Cliente c, TEAM_CASTY.Tipo_Documento d
where c.Baja=0

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
set @mensaje=@mensaje + ' No se realizó el alta.';
RAISERROR (@mensaje,15,1);
end

end;

GO



create procedure TEAM_CASTY.CambiarPassword
(@usuario nvarchar(255),@contraseña nvarchar(255))
as
begin
update TEAM_CASTY.Usuario
set Contraseña=@contraseña
where @usuario=username;
end;

GO

create view TEAM_CASTY.vistaHabitaciones
(Codigo,Descripcion,Piso,Numero,Frente, "Numero Hotel", "Nombre Hotel",Ciudad,Calle,"Numero Calle", "Descripcion de tipo",Porcentual,Baja)
AS
select hab.Cod_Habitacion,hab.Descripcion,hab.Piso,hab.Numero,hab.Frente,hab.Cod_Hotel,hot.Nombre, ciu.Nombre,hot.Calle,hot.Nro_Calle,thab.Descripcion ,thab.Porcentual,hab.Baja
from TEAM_CASTY.Habitacion hab, TEAM_CASTY.Tipo_Habitacion thab, TEAM_CASTY.Hotel hot, TEAM_CASTY.Ciudad ciu
where hot.Cod_Hotel=hab.Cod_Hotel and
thab.Cod_Tipo=hab.Cod_Tipo and
ciu.Cod_Ciudad=hot.Cod_Ciudad


go	


create procedure TEAM_CASTY.CargarHabitacion
(@hotel numeric(18), @numero numeric(18),@piso numeric(18),@frente char(1),@tipo nvarchar(255),@descripcion nvarchar(255))
as
begin

declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error:';

if(exists (select * from TEAM_CASTY.Habitacion hab where hab.Cod_Hotel=@hotel and hab.Numero=@numero))
begin
set @error=1
set @mensaje=@mensaje + ' Habitación existente.';
end

if(@error=0)
begin
declare @cod_tipo numeric(18);
select @cod_tipo=th.Cod_Tipo
from TEAM_CASTY.Tipo_Habitacion th
where th.Descripcion=@tipo;
insert into TEAM_CASTY.Habitacion
(Cod_Hotel,Cod_Tipo,Descripcion,Frente,Numero,Piso)
values (@hotel,@cod_tipo,@descripcion,@frente,@numero,@piso);
end

else
begin
set @mensaje=@mensaje + ' No se realizó el alta.';
RAISERROR (@mensaje,15,1);
end

end;

GO

create procedure TEAM_CASTY.ModificarHabitacion
(@hotel numeric(18), @numeroAnterior numeric(18), @numeroActual numeric(18),@piso numeric(18),@frente char(1),@tipo nvarchar(255),@descripcion nvarchar(255), @baja numeric(18))
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

if(exists (select * from TEAM_CASTY.Habitacion hab where hab.Cod_Hotel=@hotel and hab.Numero=@numeroActual ) and @numeroActual <> @numeroAnterior)
begin
set @error=1
set @mensaje=@mensaje + ' Habitación existente.';
end

if(@error=0)
begin
update TEAM_CASTY.Habitacion
set Descripcion=@descripcion,Numero=@numeroActual,Piso=@piso,Frente=@frente,Baja=0
where Cod_Hotel=@hotel and Numero=@numeroAnterior;
end

else
begin
set @mensaje=@mensaje + ' No se realizó la modificación.';
RAISERROR (@mensaje,15,1);
end

end;

GO

create procedure TEAM_CASTY.BajarHabitacion
(@codHabitacion numeric(18),@fecha datetime)
as
begin

declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error:';

if(not exists (select * from TEAM_CASTY.Habitacion hab where hab.Cod_Habitacion=@codHabitacion))
begin
set @error=1
set @mensaje=@mensaje + ' Habitación inexistente.';
end

if (exists(
select *
from TEAM_CASTY.Habitacion hab, TEAM_CASTY.Reserva res, TEAM_CASTY.HabitacionXReserva hxr
where hab.Cod_Habitacion=@codHabitacion and
hxr.Cod_Habitacion=hab.Cod_Habitacion and
res.Cod_Reserva=hxr.Cod_Reserva and
res.Cod_Estado=1 and
datediff(day,@fecha,res.Fecha_Reserva)>0
))
begin
set @error=1
set @mensaje=@mensaje + ' La habitación tiene reservas, en el futuro o actualmente.';
end

if (exists(
SELECT *
from TEAM_CASTY.Estadia est, TEAM_CASTY.Habitacion hab, TEAM_CASTY.HabitacionXEstadia hxe
where hab.Cod_Habitacion=@codHabitacion and
hab.Cod_Habitacion=hxe.Cod_Habitacion and
hxe.Cod_Estadia=est.Cod_Estadia and
@fecha > est.Fecha_Inicio and 
est.Fecha_Salida is null
))
begin
set @error=1
set @mensaje=@mensaje + ' La habitación tiene una estadía.';
end

if(@error=0)
begin
update TEAM_CASTY.Habitacion
set Baja=1
where Cod_Habitacion=@codHabitacion;
end

else
begin
set @mensaje=@mensaje + ' No se realizó la baja.';
RAISERROR (@mensaje,15,1);
end

end;

GO

create function  TEAM_CASTY.Precios_Por_Dia
(@hotel numeric(18))
RETURNS @tablaPorDia TABLE(
Regimen nvarchar(255),
[Tipo Habitación] nvarchar(255),
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
set @mensaje=@mensaje + ' Función inexistente.';
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
set @mensaje=@mensaje + ' No se realizó el alta.';
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
set @mensaje=@mensaje + ' Función inexistente.';
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
set @mensaje=@mensaje + ' No se realizó la modificación.';
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


if (not exists(select * from TEAM_CASTY.Rol r where @nombre=r.Nombre))
begin
	set @error=1;
	set @mensaje=@mensaje + ' Rol inexistente.';
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
set @mensaje=@mensaje + ' No se realizó la baja.';
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

create view TEAM_CASTY.vistaClientesErroneos
(Codigo, Nombre, Apellido, Mail, "Tipo Documento", "Numero Documento",Telefono,Pais,Localidad,"Calle","Numero Calle",Piso, "Departamento", Nacionalidad,"Fecha Nacimiento",Inhabilitado)
AS
select c.ID_Cliente, c.Nombre, c.Apellido, c.Mail, d.Tipo_Documento, c.Nro_Documento, c.Telefono, c.Pais, c.Localidad, c.Nom_Calle, c.Nro_Calle, c.Piso ,c.Dto,c.Nacionalidad, c.Fecha_Nacimiento,c.Inhabilitado
from TEAM_CASTY.Cliente c, TEAM_CASTY.Tipo_Documento d
where c.Baja=0 and c.Erroneo=1

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
set @mensaje=@mensaje + ' No se realizó la modificación.';
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

create function TEAM_CASTY.HabitacionesDeEstadia
(@cod_estadia numeric(18))
returns table
as
return (
select hxe.Cod_Habitacion from TEAM_CASTY.HabitacionXEstadia hxe where hxe.Cod_Estadia=@cod_estadia);

GO

create function TEAM_CASTY.Clientes_Estadia_Fecha
(@fecha datetime,@hotel numeric(18))
returns table
as
return (
select distinct e.Cod_Estadia,c.Nombre,c.Apellido,td.Tipo_Documento,c.Nro_Documento,c.Fecha_Nacimiento,c.Telefono,c.Mail
from TEAM_CASTY.Estadia e, TEAM_CASTY.Cliente c,TEAM_CASTY.Habitacion hab,TEAM_CASTY.HabitacionXEstadia hxe,
TEAM_CASTY.Reserva res, TEAM_CASTY.Tipo_Documento td
where e.Cod_Estadia=hxe.Cod_Estadia and hab.Cod_Hotel=@hotel and hab.Cod_Habitacion=hxe.Cod_Habitacion and
res.ID_Cliente_Reservador=c.ID_Cliente and datediff(day,@fecha,e.Fecha_Salida)=0 and
td.ID_Tipo_Documento=c.ID_Tipo_Documento and res.Cod_Reserva=e.Cod_Reserva);

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

if(not exists (select * from TEAM_CASTY.Factura f where f.Cod_Estadia=@cod_Estadia))
begin

if(not exists (select * from TEAM_CASTY.Estadia e where e.Cod_Estadia=@cod_Estadia))
begin
	set @error=1;
	set @mensaje+=' No existe esa estadía.';
end

if (exists (select * from @tabla t where t.Nombre not in (select c.Descripcion from TEAM_CASTY.Consumible c)))
begin
	set @error=1;
	set @mensaje+=' Consumible inexistente.';
end
 
if(exists(select * from @tabla t where t.Cod_Habitacion not in (select hxe.Cod_Habitacion from TEAM_CASTY.HabitacionXEstadia hxe where hxe.Cod_Estadia=@cod_Estadia)))
begin
	set @error=1;
	set @mensaje+=' Habitación no correspondiente a estadía.';
end 
 
if(exists (select * from @tabla t where t.Cantidad<0))
begin
	set @error=1;
	set @mensaje+=' Cantidad incorrecta.';
end 
end
else
begin
	set @error=1;
	set @mensaje+=' La estadía ya fue facturada.';
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
	set @mensaje=@mensaje + 'No se realizó el registro de consumibles.';
	RAISERROR (@mensaje,15,1);
end
end;

GO


create function TEAM_CASTY.Regimenes
()
RETURNS TABLE
AS 
return (
select reg.Descripcion
from TEAM_CASTY.Regimen reg);

go

CREATE TYPE TEAM_CASTY.t_tablaRegimenes AS TABLE(
	Descripcion nvarchar (255));
	
GO

create procedure TEAM_CASTY.alta_Hotel
(@nombre nvarchar(255),@mail nvarchar(255),@telefono nvarchar(50),@pais nvarchar(255),@cidudad nvarchar(255),@cant_Estrellas numeric (18),
@calle nvarchar(255),@num_calle numeric (18),@fecha_creacion datetime, @tabla t_tablaRegimenes readonly)
as
begin
declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error: ';

 if (exists (
 select *
 from TEAM_CASTY.Hotel h, TEAM_CASTY.Ciudad c
 where h.Calle=@calle and @num_calle=h.Nro_Calle and h.Pais=upper(@pais) and c.Nombre=@cidudad))
 begin
	set @error=1;
	set @mensaje+=' El hotel ya existe.';
 end

if(exists(
select * from TEAM_CASTY.Hotel h where h.Mail=@mail
))
begin
	set @error=1;
	set @mensaje+='Mail repetido.';
end
 
if (@error=0)
begin
	declare @cod_ciudad numeric (18);
	if (not exists (
	select * from TEAM_CASTY.Hotel h, TEAM_CASTY.Ciudad c where h.Pais=@pais and c.Nombre=@cidudad))
	begin
		INSERT INTO TEAM_CASTY.Ciudad (Nombre) values (@cidudad);
	end
	select @cod_ciudad=c.Cod_Ciudad	from TEAM_CASTY.Ciudad c where c.Nombre=@cidudad;	
	
	insert into Team_Casty.Hotel
	(Nombre,Pais,Cod_Ciudad,Calle,Nro_Calle,Telefono,Mail,CantEstrella,Fecha_Creacion)
	values(@nombre,upper(@pais),@cod_ciudad,@calle,@num_calle,@telefono,@mail,@cant_Estrellas,@fecha_creacion);
	
	declare @cod_hotel numeric (18);
	select @cod_hotel=MAX(h.Cod_Hotel) from TEAM_CASTY.Hotel h;
	
	insert into TEAM_CASTY.RegimenXHotel
	(Cod_Hotel,Cod_Regimen,Activo)
	select @cod_hotel,r.Cod_Regimen,1
	from  TEAM_CASTY.Regimen r, @tabla t
	where r.Descripcion=t.Descripcion;
	
	insert into TEAM_CASTY.RolXUsuarioXHotel(Cod_Hotel,Cod_Rol,Cod_Usuario) values (@cod_hotel,1,1);
	insert into TEAM_CASTY.RolXUsuarioXHotel(Cod_Hotel,Cod_Rol,Cod_Usuario) values (@cod_hotel,3,2);	
end	
else
begin
	set @mensaje=@mensaje + 'No se realizó el alta.';
	RAISERROR (@mensaje,15,1);
end
end;
 
 GO
 
 create procedure TEAM_CASTY.modificacion_Hotel
(@cod_hotel numeric (18),@nombre nvarchar(255),@mail nvarchar(255),@telefono nvarchar(50),@pais nvarchar(255),@cidudad nvarchar(255),@cant_Estrellas numeric (18),
@calle nvarchar(255),@num_calle numeric (18), @tabla t_tablaRegimenes readonly)
 as
 begin
 declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error: ';

 if (not exists (
 select *
 from TEAM_CASTY.Hotel h
 where h.Cod_Hotel=@cod_hotel))
 begin
	set @error=1;
	set @mensaje+=' El hotel no existe.';
 end
 
 if(exists(
select * from TEAM_CASTY.Hotel h where h.Mail=@mail and @cod_hotel<>h.Cod_Hotel
))
begin
	set @error=1;
	set @mensaje+='Mail repetido.';
end
 
if (@error=0)
begin	
	declare @cod_ciudad numeric (18);
	if (not exists (
	select * from TEAM_CASTY.Hotel h, TEAM_CASTY.Ciudad c where h.Pais=upper(@pais) and c.Nombre=@cidudad))
	begin
		INSERT INTO TEAM_CASTY.Ciudad (Nombre) values (@cidudad);
	end
	select @cod_ciudad=c.Cod_Ciudad	from TEAM_CASTY.Ciudad c where c.Nombre=@cidudad;
	
	update Team_Casty.Hotel
	set Nombre=@nombre,Pais=@pais,Calle=@calle,Nro_Calle=@num_calle,Telefono=@telefono,
	Mail=@mail,CantEstrella=@cant_Estrellas,Cod_Ciudad=@cod_ciudad
	where @cod_hotel=Cod_Hotel;
	
	delete TEAM_CASTY.RegimenXHotel	
	where Cod_Hotel=@cod_hotel;
	
	insert into TEAM_CASTY.RegimenXHotel
	(Cod_Hotel,Cod_Regimen,Activo)
	select @cod_hotel,r.Cod_Regimen,1
	from  TEAM_CASTY.Regimen r, @tabla t
	where r.Descripcion=t.Descripcion;	
end	
else
begin
	set @mensaje=@mensaje + 'No se realizó la modificación.';
	RAISERROR (@mensaje,15,1);
end
end;
 
 GO
 
 create function TEAM_CASTY.periodoOK
(@fi1 datetime, @ff1 datetime, @fi2 datetime, @ff2 datetime)
RETURNS numeric(18)
AS
begin
declare @ok numeric (18);

if( (@ff2<@fi1) or (@fi2>@ff1) )
begin
	set @ok=1;
end
else
begin
	set @ok=0;
end

return @ok;
end;

GO
 
create procedure TEAM_CASTY.baja_Hotel
(@cod_hotel numeric (18),@fecha_inicio datetime, @fecha_fin datetime,@motivo nvarchar(255))
 as
 begin
 declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error:';

 if (not exists (
 select *
 from TEAM_CASTY.Hotel h
 where h.Cod_Hotel=@cod_hotel))
 begin
	set @error=1;
	set @mensaje+=' El hotel no existe.';
 end
 
if(exists(
select * from
(select r.Fecha_Reserva as Fecha_Inicio, r.Fecha_Reserva+r.Cant_Noches as Fecha_Fin
from TEAM_CASTY.Reserva r, TEAM_CASTY.HabitacionXReserva hxr,TEAM_CASTY.Habitacion hab
where r.Cod_Reserva=hxr.Cod_Reserva and hxr.Cod_Habitacion=hab.Cod_Habitacion
and @cod_hotel=hab.Cod_Hotel and r.Cod_Estado in(1,2,6)) t
where TEAM_CASTY.periodoOK(@fecha_inicio,@fecha_fin,Fecha_Inicio,Fecha_Fin)=0
))
begin
	set @error=1;
	set @mensaje+=' El hotel no se puede inhabilitar.';
end

if(exists(
select *
from TEAM_CASTY.Periodo_Inhabilitado pein
where TEAM_CASTY.periodoOK(@fecha_inicio,@fecha_fin,pein.Fecha_Inicio,pein.Fecha_Fin)=0 and Cod_Hotel=@cod_hotel
))
begin
	set @error=1;
	set @mensaje+=' El hotel ya está inhabilitado.';
end
 
if (@error=0)
begin
	insert into TEAM_CASTY.Periodo_Inhabilitado
	(Cod_Hotel,Fecha_Inicio,Fecha_Fin,Descripcion)
	values (@cod_hotel,@fecha_inicio,@fecha_fin,@motivo);	
end	
else
begin
	set @mensaje=@mensaje + ' No se realizó la modificación.';
	RAISERROR (@mensaje,15,1);
end
end;
 
 GO

create procedure TEAM_CASTY.Insertar_Recarga
(@fecha datetime, @recarga numeric(18))
as
begin
declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error:';

if(exists (select * from TEAM_CASTY.Recarga_Estrella re where datediff(day,re.Fecha_Modificacion,@fecha)=0))
begin
	set @error=1;
	set @mensaje=' Ya se cambió la recarga ese día.';
end

if (@error=0)
begin
	insert into TEAM_CASTY.Recarga_Estrella
	(Fecha_Modificacion,Recarga)
	values (@fecha,@recarga);
end	
else
begin
	set @mensaje=@mensaje + ' No se realizó la modificación.';
	RAISERROR (@mensaje,15,1);
end
end;

GO

 CREATE TYPE TEAM_CASTY.t_tablaHotelYRol AS TABLE(
	Cod_Hotel numeric (18),
	Nombre_Rol nvarchar (50));
	
GO

create function TEAM_CASTY.HotelYRolDeUnUsuario
(@usuario nvarchar(255))
returns table
as
return(
select rxuxh.Cod_Hotel,r.Nombre
from TEAM_CASTY.Usuario u, TEAM_CASTY.RolXUsuarioXHotel rxuxh,TEAM_CASTY.Rol r 
where u.Username=@usuario and rxuxh.Cod_Usuario=u.Cod_Usuario and r.Cod_Rol=rxuxh.Cod_Rol
);

GO

create procedure TEAM_CASTY.crearUsuario
(@username nvarchar(255),@password nvarchar(255),@nombre nvarchar(255),@apellido nvarchar(255),
 @tipoDocumento nvarchar(255), @numeroDocumento numeric(18), @mail nvarchar(255), @telefono nvarchar(50),
 @direccion nvarchar(255), @fechaNacimiento datetime, @tabla TEAM_CASTY.t_tablaHotelYRol readonly)
as
begin

declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error: ';

if (exists(select * from TEAM_CASTY.Usuario u where u.Username= @username))
begin
	set @error=1;
	set @mensaje=' Usuario existente.';
end

if (exists( 
select *
from TEAM_CASTY.Empleado e, TEAM_CASTY.Tipo_Documento td
where e.Nro_Documento=@numeroDocumento and @tipoDocumento=td.Tipo_Documento and e.ID_Tipo_Documento=td.ID_Tipo_Documento))
begin
	set @error=1;
	set @mensaje=' Empleado existente.';
end   

if (exists( 
select *
from TEAM_CASTY.Empleado e
where e.Mail=@mail))
begin
	set @error=1;
	set @mensaje=' Mail repetido.';
end   

if (not exists( 
select *
from TEAM_CASTY.Tipo_Documento td
where @tipoDocumento=td.Tipo_Documento))
begin
	set @error=1;
	set @mensaje=' Tipo de documneto inexistente.';
end   

if(exists(
select *
from @tabla t
where t.Cod_Hotel not in(select h.Cod_Hotel from TEAM_CASTY.Hotel h)))
begin
	set @error=1;
	set @mensaje=' Hotel inexistente.';
end

if(exists(
select *
from @tabla t
where t.Nombre_Rol not in(select r.Nombre from TEAM_CASTY.Rol r)))
begin
	set @error=1;
	set @mensaje=' Rol inexistente.';
end

if (@error=0)
begin
	insert into TEAM_CASTY.Usuario (Username,Contraseña) values (@username,@password);
	
	declare @cod_usuario numeric (18);
	select @cod_usuario=u.Cod_Usuario
	from TEAM_CASTY.Usuario u
	where @username=u.Username;
	
	declare @id_tipo_documento numeric (18);
	select @id_tipo_documento=td.ID_Tipo_Documento
	from TEAM_CASTY.Tipo_Documento td
	where td.Tipo_Documento=@tipoDocumento;

	insert into TEAM_CASTY.Empleado
	(Nombre,Apellido,ID_Tipo_Documento,Nro_Documento,Mail,Telefono,Direccion,Fecha_Nacimiento,Cod_Usuario)
    values(@nombre,@apellido,@id_tipo_documento,@numeroDocumento,@mail,@telefono,@direccion,@fechaNacimiento,@cod_usuario);
             
	insert into TEAM_CASTY.RolXUsuarioXHotel
	(Cod_Usuario,Cod_Rol,Cod_Hotel)
    select @cod_usuario,r.Cod_Rol,t.Cod_Hotel
    from TEAM_CASTY.Rol r , @tabla t
    where r.Nombre=t.Nombre_Rol;
end

else
begin
  	set @mensaje +=' No se realizó el alta.';
  	RAISERROR (@mensaje,15,1);
end
end;

GO

create procedure TEAM_CASTY.modificarUsuario
(@cod_usuario numeric(18),@username nvarchar(255),@nombre nvarchar(255),@apellido nvarchar(255),
 @tipoDocumento nvarchar(255), @numeroDocumento numeric(18), @mail nvarchar(255), @telefono nvarchar(50),
 @direccion nvarchar(255), @fechaNacimiento datetime, @habilitado numeric (18),@tabla TEAM_CASTY.t_tablaHotelYRol readonly)
as
begin

declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error: ';

if (not exists(select * from TEAM_CASTY.Usuario u where u.Username= @username and u.Cod_Usuario<>@cod_usuario))
begin
	set @error=1;
	set @mensaje=' Nombre de usuario repetido.';
end

if (exists( 
select *
from TEAM_CASTY.Empleado e, TEAM_CASTY.Tipo_Documento td
where @cod_usuario<>e.Cod_Usuario and e.Nro_Documento=@numeroDocumento and @tipoDocumento=td.Tipo_Documento and e.ID_Tipo_Documento=td.ID_Tipo_Documento))
begin
	set @error=1;
	set @mensaje=' Documento ya existente.';
end   

if (not exists( 
select *
from TEAM_CASTY.Tipo_Documento td
where @tipoDocumento=td.Tipo_Documento))
begin
	set @error=1;
	set @mensaje=' Tipo de documneto inexistente.';
end   

if (exists( 
select *
from TEAM_CASTY.Empleado e
where e.Mail=@mail and e.Cod_Usuario<>@cod_usuario))
begin
	set @error=1;
	set @mensaje=' Mail repetido.';
end 

if(exists(
select *
from @tabla t
where t.Cod_Hotel not in(select h.Cod_Hotel from TEAM_CASTY.Hotel h)))
begin
	set @error=1;
	set @mensaje=' Hotel inexistente.';
end

if(exists(
select *
from @tabla t
where t.Nombre_Rol not in(select r.Nombre from TEAM_CASTY.Rol r)))
begin
	set @error=1;
	set @mensaje=' Rol inexistente.';
end

if (@error=0)
begin	
	declare @id_tipo_documento numeric (18);
	select @id_tipo_documento=td.ID_Tipo_Documento
	from TEAM_CASTY.Tipo_Documento td
	where td.Tipo_Documento=@tipoDocumento;
	
	update TEAM_CASTY.Usuario
	set Username=@username
	where @cod_usuario=Cod_Usuario;
	
	if(@habilitado=1)
	begin
		update TEAM_CASTY.Usuario
		set Habilitado=1
		where @cod_usuario=Cod_Usuario;
	end

	update TEAM_CASTY.Empleado
	set Nombre=@nombre,Apellido=@apellido,ID_Tipo_Documento=@id_tipo_documento,
	Nro_Documento=@numeroDocumento,Mail=@mail,Telefono=@telefono,Direccion=@direccion,
	Fecha_Nacimiento=@fechaNacimiento
    where @cod_usuario=Cod_Usuario;
             
	delete TEAM_CASTY.RolXUsuarioXHotel
	where Cod_Usuario=@cod_usuario;
	
	insert into TEAM_CASTY.RolXUsuarioXHotel
	(Cod_Usuario,Cod_Rol,Cod_Hotel)
    select @cod_usuario,r.Cod_Rol,t.Cod_Hotel
    from TEAM_CASTY.Rol r , @tabla t
    where r.Nombre=t.Nombre_Rol;
end

else
begin
  	set @mensaje +=' No se realizó la modificación.';
  	RAISERROR (@mensaje,15,1);
end
end;

GO

create procedure TEAM_CASTY.bajaUsuario
(@username nvarchar(255))
as
declare @mensaje nvarchar(100);
begin
if(exists (
select *
from TEAM_CASTY.Usuario u
where @username=u.Username))
begin
	update TEAM_CASTY.Usuario set Baja=1 where @username=Username;
end
else
begin
  	set @mensaje ='Error: Usuario inexistente. No se realizó la baja.';
  	RAISERROR (@mensaje,15,1);
end  
end;
  
GO

create function TEAM_CASTY.RegimenesDeUnHotel
(@cod_hotel numeric (18))
RETURNS TABLE
AS 
return (
select reg.Descripcion
from TEAM_CASTY.RegimenXHotel rxh, TEAM_CASTY.Regimen reg
where rxh.Cod_Hotel=@cod_hotel and rxh.Activo=1 and reg.Cod_Regimen=rxh.Cod_Regimen);

go

create function  TEAM_CASTY.Tipos_Habitaciones_Hotel
(@hotel numeric(18))
returns table
AS
return(
select distinct th.Descripcion
from TEAM_CASTY.Tipo_Habitacion th, TEAM_CASTY.Habitacion hab
where hab.Cod_Tipo=th.Cod_Tipo and @hotel=hab.Cod_Hotel);

GO

create procedure  TEAM_CASTY.Actualizar_Reservas
@fecha_actual datetime
AS
begin
update res
set res.Cod_Estado=5
from TEAM_CASTY.Reserva res
where datediff(day,res.Fecha_Reserva,@fecha_actual)>0 AND
res.Cod_Estado=1 AND	  
res.Cod_Reserva not in (select est.Cod_Reserva from TEAM_CASTY.Estadia est)
end;

GO

create type TEAM_CASTY.t_reserva AS TABLE(
Tipo_habitacion nvarchar(255),
Cantidad numeric(18));

GO

create function  TEAM_CASTY.estaReservada--NO esta reservada=1
(@fecha_desde datetime,@fecha_hasta datetime,@cod_hab numeric(18))
returns numeric(18)
AS
begin
	declare @si numeric(18)=1;
	if (exists(
	select *
	from TEAM_CASTY.Reserva res, TEAM_CASTY.HabitacionXReserva hxr
	where hxr.Cod_Habitacion=@cod_hab and res.Cod_Reserva=hxr.Cod_Reserva and
	TEAM_CASTY.periodoOK(@fecha_desde,@fecha_hasta,res.Fecha_Reserva,res.Fecha_Reserva+res.Cant_Noches)=0
	))
	begin
		set @si=0;
	end
	return @si;
end;

GO

create function TEAM_CASTY.Cant_Hab_Disponibles
(@fecha_desde datetime,@fecha_hasta datetime,@hotel numeric(18),@cod_tipo_hab numeric(18))
returns numeric(18)
AS
begin
	return(
	select COUNT(distinct hab.Cod_Habitacion)
	from TEAM_CASTY.Habitacion hab
	where hab.Cod_Hotel=@hotel and hab.Baja=0 and hab.Cod_Tipo=@cod_tipo_hab and 
	TEAM_CASTY.estaReservada(@fecha_desde,@fecha_hasta,hab.Cod_Habitacion)=1)
end;

GO

create procedure  TEAM_CASTY.Disponibilidad_Reserva--OK=1; NO=0;
(@fecha_desde datetime,@fecha_hasta datetime,@hotel numeric(18),@regimen nvarchar(255),@tabla TEAM_CASTY.t_reserva readonly,
@sePuede bit output,@precio money output)
AS
begin

set @sePuede =1;
set @precio =0;

declare @cod_reg numeric(18);
select @cod_reg=reg.Cod_Regimen from TEAM_CASTY.Regimen reg where reg.Descripcion=@regimen;

if(datediff(day,@fecha_desde,@fecha_hasta)>0)
begin
	if(not exists(
	select *
	from TEAM_CASTY.Periodo_Inhabilitado pein
	where pein.Cod_Hotel=@hotel and
	TEAM_CASTY.periodoOK(pein.Fecha_Inicio,pein.Fecha_Fin,@fecha_desde,@fecha_hasta)=0))
	begin
		DECLARE _cursor CURSOR FOR
		select * from @tabla;
		OPEN _cursor;
		DECLARE @t_hab nvarchar(255), @cant numeric(18),@cod_t_hab numeric(18),@seguir  numeric(18)=1;
		FETCH NEXT FROM _cursor INTO @t_hab, @cant;
		WHILE (@@FETCH_STATUS = 0 and @seguir=1)
		BEGIN
			select @cod_t_hab=th.Cod_Tipo
			from TEAM_CASTY.Tipo_Habitacion th
			where th.Descripcion=@t_hab;
			
			if(TEAM_CASTY.Cant_Hab_Disponibles(@fecha_desde,@fecha_hasta,@hotel,@cod_t_hab)<@cant)
			begin
				set @seguir=0;
				set @sePuede=0;
			end;
			
			FETCH NEXT FROM _cursor INTO @t_hab, @cant;					
		END;		
		CLOSE _cursor;
		DEALLOCATE _cursor;	
	end
	else
	begin
		set @sePuede=0;
	end
end
else
begin
	set @sePuede=0;
end

if(@sePuede=1)
begin	
	DECLARE _cursor2 CURSOR FOR
	select * from @tabla;
	OPEN _cursor2;
	DECLARE @t_habitacion nvarchar(255), @cantidad numeric(18),@cod_tipo_habitacion numeric(18);
	FETCH NEXT FROM _cursor2 INTO @t_habitacion, @cantidad;
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		select @cod_tipo_habitacion=th.Cod_Tipo
		from TEAM_CASTY.Tipo_Habitacion th
		where th.Descripcion=@t_habitacion;
		
		set @precio+=((select TEAM_CASTY.PrecioPorDiaEspecifico(@hotel,@cod_reg,@cod_tipo_habitacion))*@cantidad*DATEDIFF(DAY,@fecha_desde,@fecha_hasta));
		
		FETCH NEXT FROM _cursor2 INTO @t_habitacion, @cantidad;				
	END
	CLOSE _cursor2;
	DEALLOCATE _cursor2;	
end

end;

GO


create function  TEAM_CASTY.Ultimo_Codigo_Reserva
()
returns numeric(18)
as
begin
	return (select MAX(r.Cod_Reserva) from TEAM_CASTY.Reserva r)
end;

GO

create function  TEAM_CASTY.Obtener_Habitacion
(@fecha_desde datetime,@fecha_hasta datetime,@hotel numeric(18),@cod_tipo_hab numeric(18))
returns numeric(18)
as
begin
	return(	
	select TOP 1 hab.Cod_Habitacion
	from TEAM_CASTY.Habitacion hab
	where hab.Cod_Hotel=@hotel and hab.Baja=0 and hab.Cod_Tipo=@cod_tipo_hab and 
	TEAM_CASTY.estaReservada(@fecha_desde,@fecha_hasta,hab.Cod_Habitacion)=1)
end;

GO

create procedure  TEAM_CASTY.Reservar_Habitaciones
(@cod_reserva numeric(18),@fecha_reserva datetime,@cant_noches numeric(18),
@hotel numeric(18),@tabla TEAM_CASTY.t_reserva readonly)
as
begin
	declare @i int;
	
	DECLARE _cursor CURSOR FOR
	select * from @tabla;
	OPEN _cursor;
	DECLARE @t_hab nvarchar(255), @cant numeric(18),@cod_t_hab numeric(18);
	FETCH NEXT FROM _cursor INTO @t_hab, @cant;
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		select @cod_t_hab=th.Cod_Tipo
		from TEAM_CASTY.Tipo_Habitacion th
		where th.Descripcion=@t_hab;
		
		set @i=0;
		while (@i<@cant)
		begin
			insert into TEAM_CASTY.HabitacionXReserva (Cod_Reserva,Cod_Habitacion)
			values (@cod_reserva,TEAM_CASTY.Obtener_Habitacion(@fecha_reserva,@fecha_reserva+@cant_noches,@hotel,@cod_t_hab));
			set @i=@i+1;
		end
		
		FETCH NEXT FROM _cursor INTO @t_hab, @cant;					
	END;		
	CLOSE _cursor;
	DEALLOCATE _cursor;			
end;

GO

create procedure  TEAM_CASTY.Reservar
(@usuario nvarchar(255),@fecha_realizacion datetime,@fecha_reserva datetime,@cant_noches numeric(18),@id_cliente numeric(18),
@regimen nvarchar(255),@hotel numeric(18),@tabla TEAM_CASTY.t_reserva readonly,@cod_reserva numeric(18) output)
as
begin
	declare @cod_t_reg numeric(18);
	select @cod_t_reg=r.Cod_Regimen
	from TEAM_CASTY.Regimen r
	where r.Descripcion=@regimen;
	
	declare @cod_usuario numeric(18);
	select @cod_usuario=u.Cod_Usuario
	from TEAM_CASTY.Usuario u
	where @usuario=u.Username;
	
	set @cod_reserva=TEAM_CASTY.Ultimo_Codigo_Reserva()+1;
	
	insert into TEAM_CASTY.Reserva
	(Cant_Noches,Cod_Estado,Cod_Regimen,Cod_Reserva,Fecha_Realizacion,Fecha_Reserva,ID_Cliente_Reservador)
	values (@cant_noches,1,@cod_t_reg,@cod_reserva,@fecha_realizacion,@fecha_reserva,@id_cliente);
	
	insert into TEAM_CASTY.ModificacionXReserva
	(Cod_Reserva,Cod_Usuario,Descripcion,Fecha,Numero_Modificacion)
	values (@cod_reserva,@cod_usuario,'Creación',@fecha_realizacion,1);
	
	exec TEAM_CASTY.Reservar_Habitaciones @cod_reserva,@fecha_reserva,@cant_noches,@hotel,@tabla;
	
end;

GO


create procedure  TEAM_CASTY.Datos_Reserva
(@cod_reserva numeric(18),@fecha_reserva datetime output,@cant_noches numeric(18) output,
@regimen nvarchar(255) output)
as
begin
	declare @cod_reg numeric(18);
	select @fecha_reserva=res.Fecha_Reserva,@cant_noches=res.Cant_Noches,@cod_reg=res.Cod_Regimen
	from TEAM_CASTY.Reserva res where res.Cod_Reserva=@cod_reserva;
	
	select @regimen=reg.Descripcion	from TEAM_CASTY.Regimen reg where reg.Cod_Regimen=@cod_reg;	
end;

GO

create function  TEAM_CASTY.Habitaciones_Reserva
(@cod_reserva numeric(18))
returns table
as

return(
select th.Descripcion,COUNT(*) as Cantidad
from TEAM_CASTY.Habitacion hab, TEAM_CASTY.Tipo_Habitacion th, TEAM_CASTY.HabitacionXReserva hxr
where hxr.Cod_Reserva=@cod_reserva and hab.Cod_Habitacion=hxr.Cod_Habitacion and th.Cod_Tipo=hab.Cod_Tipo
group by th.Descripcion);

GO


create procedure  TEAM_CASTY.Modificar_Reserva
(@usuario nvarchar(255),@cod_reserva numeric(18),@fecha_realizacion datetime,@fecha_reserva datetime,@cant_noches numeric(18),
@id_cliente numeric(18),@regimen nvarchar(255),@hotel numeric(18),@tabla TEAM_CASTY.t_reserva readonly)
as
begin	
	declare @mensaje varchar(1000);
	declare @error int;
	set @error=0;
	set @mensaje='Error:';
	
	begin transaction
	
		delete TEAM_CASTY.HabitacionXReserva
		where Cod_Reserva=@cod_reserva;

	
	if(@error=0)		
	begin
		exec TEAM_CASTY.Reservar_Habitaciones @cod_reserva,@fecha_reserva,@cant_noches,@hotel,@tabla;
		declare @cod_usuario numeric(18);
		select @cod_usuario=u.Cod_Usuario from TEAM_CASTY.Usuario u where u.Username=@usuario;
		declare @num numeric(18);
		select @num=(1+max(mxr.Numero_Modificacion)) from TEAM_CASTY.ModificacionXReserva mxr;
		insert into TEAM_CASTY.ModificacionXReserva
		(Cod_Reserva,Cod_Usuario,Descripcion,Fecha,Numero_Modificacion)
		values (@cod_reserva,@cod_usuario,'Modificación',@fecha_realizacion,@num);
		commit transaction	
	end
	else
	begin
		rollback transaction	
		set @mensaje+=' No se realizó la modifición.';
		RAISERROR(@mensaje,15,1);
	end
end;

GO

create view TEAM_CASTY.vistaReservasModificables
as
select * from TEAM_CASTY.Reserva 
where  Cod_Estado in(1,2)

go

create procedure  TEAM_CASTY.Cancelar_Reserva
@cod_Reserva numeric(18),@fecha datetime,@motivo varchar(255), @usuario nvarchar(255)
AS
declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error:';

if (not exists (select * from TEAM_CASTY.Usuario u where u.Username=@usuario))
begin
	set @error=1;
	set @mensaje=' No existe ese usuario.';
end

else
begin
	declare @cod_user numeric(18);
	select @cod_user=u.Cod_Usuario from TEAM_CASTY.Usuario u where u.Username=@usuario;
	if(not exists (select * from TEAM_CASTY.Reserva r where @Cod_Reserva=r.Cod_Reserva))
	begin
		set @error=1;
		set @mensaje=@mensaje + ' No existe la Reserva.';
	end;
	
	if(not exists(select distinct h.Cod_Hotel
	from TEAM_CASTY.Hotel h, TEAM_CASTY.Reserva r,TEAM_CASTY.Habitacion hab, TEAM_CASTY.HabitacionXReserva hxr
	where h.Cod_Hotel=hab.Cod_Hotel and
	r.Cod_Reserva=@Cod_Reserva and
	hxr.Cod_Reserva=@Cod_Reserva and		
	hxr.Cod_Habitacion=hab.Cod_Habitacion and
	h.Cod_Hotel in(select rxuxh.Cod_Hotel from TEAM_CASTY.RolXUsuarioXHotel rxuxh where @cod_user=rxuxh.Cod_Usuario)))
	begin
		set @error=1;
		set @mensaje=@mensaje + ' El usuario no puede operar sobre ese hotel.';
	end	;
	if(exists (select * from TEAM_CASTY.Cancelacion c where @Cod_Reserva=c.Cod_Reserva))
	begin
		set @error=1;
		set @mensaje=@mensaje + ' La reserva ya fue cancelada.';
	end;	

end;
if (@error=0)	
begin
	declare @estado numeric(18);
	if(@cod_user=3)
	begin
		set @estado=4 
	end
	else
	begin
		set @estado=5
	end
	insert into TEAM_CASTY.Cancelacion (Cod_Reserva,Cod_Usuario,Fecha,Motivo)
	values (@Cod_Reserva,@cod_user,@fecha,@motivo);
	update TEAM_CASTY.Reserva 
	set Cod_Estado=@estado
	where @Cod_Reserva=Cod_Reserva;	
	declare @num numeric (18);
	select @num=(1+MAX(mxr.Numero_Modificacion)) from TEAM_CASTY.ModificacionXReserva mxr where mxr.Cod_Reserva=@Cod_Reserva;	
	insert into TEAM_CASTY.ModificacionXReserva
	(Cod_Reserva,Cod_Usuario,Descripcion,Fecha,Numero_Modificacion)
	values (@Cod_Reserva,@cod_user,@motivo,@fecha,@num);
end
else	
begin
	set @mensaje=@mensaje + ' No se realizó cancelación.';
	RAISERROR (@mensaje,15,1);
end

GO

create function  TEAM_CASTY.Reservas_Para_Check_IN
(@fecha datetime, @hotel numeric(18))
returns table
AS
	return(
	select distinct res.Cod_Reserva,res.ID_Cliente_Reservador
	from TEAM_CASTY.Reserva res,TEAM_CASTY.Habitacion hab, TEAM_CASTY.HabitacionXReserva hxr
	where res.Cod_Reserva=hxr.Cod_Reserva and hxr.Cod_Habitacion=hab.Cod_Habitacion and hab.Cod_Hotel=@hotel and
	datediff(day,res.Fecha_Reserva,@fecha)=0 and res.Cod_Estado in (1,2));

GO

create function  TEAM_CASTY.Estadias_Para_Check_OUT
(@hotel numeric(18))
returns table
AS
	return(
	select distinct est.Cod_Estadia,res.ID_Cliente_Reservador
	from TEAM_CASTY.Estadia est,TEAM_CASTY.HabitacionXEstadia hxe, TEAM_CASTY.Habitacion hab,TEAM_CASTY.Reserva res
	where est.Fecha_Salida is null and est.Fecha_Inicio is not null and hab.Cod_Habitacion=hxe.Cod_Habitacion and
	est.Cod_Estadia=hxe.Cod_Estadia and hab.Cod_Hotel=@hotel and res.Cod_Reserva=est.Cod_Reserva);

GO

create function  TEAM_CASTY.Utimo_Codigo_Estadia
()
returns numeric(18)
AS
begin
	return(select MAX(e.Cod_Estadia) from TEAM_CASTY.Estadia e);
end;

GO

create procedure  TEAM_CASTY.Check_IN
@Cod_Reserva numeric(18),@fecha datetime, @usuario nvarchar(255),@hotel numeric(18),@cod_estadia numeric(18) output
AS
begin
declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error:';
declare @cod_user numeric(18);
select @cod_user=u.Cod_Usuario from TEAM_CASTY.Usuario u where u.Username=@usuario;

if(not exists (select * from TEAM_CASTY.Reserva r where @Cod_Reserva=r.Cod_Reserva))
begin
	set @error=1;
	set @mensaje=@mensaje + ' No existe la Reserva';
end;

if(exists (select * from TEAM_CASTY.Estadia e where @Cod_Reserva=e.Cod_Reserva))
begin
	set @error=1;
	set @mensaje=@mensaje + ' Ya se hizo el Check IN.';
end;

if (exists (select * from TEAM_CASTY.Reserva r where @Cod_Reserva=r.Cod_Reserva and datediff(day,r.Fecha_Reserva,@fecha)>0))
begin
		set @error=1;
		set @mensaje=@mensaje + ' Fecha inválida.';
end;

if (exists (select * from TEAM_CASTY.Reserva r where @Cod_Reserva=r.Cod_Reserva and datediff(day,r.Fecha_Reserva,@fecha)<0))
begin
		set @error=1;
		set @mensaje=@mensaje + ' Fecha inválida.';
		update TEAM_CASTY.Reserva
		set Cod_Estado=5
		where Cod_Reserva=@Cod_Reserva;
end;

if(not exists(select *
from TEAM_CASTY.Habitacion hab, TEAM_CASTY.HabitacionXReserva hxr,TEAM_CASTY.Hotel h, TEAM_CASTY.Usuario u, TEAM_CASTY.RolXUsuarioXHotel uxrxh
where hab.Cod_Hotel=h.Cod_Hotel and
h.Cod_Hotel=@hotel and
hxr.Cod_Habitacion=hab.Cod_Habitacion and
hxr.Cod_Reserva=@Cod_Reserva and
u.Cod_Usuario=@cod_user and
u.Cod_Usuario=uxrxh.Cod_Usuario))
begin		
	set @error=1;
	set @mensaje=@mensaje + ' El usuario no puede operar sobre ese hotel';
end;
	
if (@error=0)	
begin
	insert into TEAM_CASTY.Estadia (Cod_Reserva,Fecha_Inicio,Usuario_Inicio)
	values(@Cod_Reserva,@fecha,@cod_user);
	update TEAM_CASTY.Reserva
	set Cod_Estado=6
	where @Cod_Reserva=Cod_Reserva;	
	set @cod_estadia =TEAM_CASTY.Utimo_Codigo_Estadia();
	insert into TEAM_CASTY.HabitacionXEstadia(Cod_Estadia,Cod_Habitacion)
	select @cod_estadia,hxr.Cod_Habitacion
	from TEAM_CASTY.HabitacionXReserva hxr
	where hxr.Cod_Reserva=@Cod_Reserva;	
end
else
begin
	set @mensaje=@mensaje + ' No se realizó el Check IN.';
	RAISERROR (@mensaje,15,1);
end
end;

GO

create type TEAM_CASTY.t_agregar_clientes as table (
cod_cliente numeric(18));

GO

create procedure  TEAM_CASTY.Agregar_Clientes_A_Estadia
(@Cod_Reserva numeric(18),@tabla TEAM_CASTY.t_agregar_clientes readonly)
AS
begin
	declare @cod_est numeric(18);
	select @cod_est=est.Cod_Estadia from TEAM_CASTY.Estadia est where est.Cod_Reserva=@Cod_Reserva;
	
	insert into TEAM_CASTY.ClienteXEstadia
	(Cod_Estadia,ID_Cliente)
	select @cod_est,t.cod_cliente
	from @tabla t;	
	
	insert into TEAM_CASTY.ClienteXEstadia
	(Cod_Estadia,ID_Cliente)
	select @cod_est,r.ID_Cliente_Reservador
	from TEAM_CASTY.Reserva r
	where r.Cod_Reserva=@Cod_Reserva;
end;

GO

create procedure  TEAM_CASTY.Check_OUT
@cod_estadia numeric(18),@fecha datetime, @usuario nvarchar(255),@hotel numeric(18)
AS
begin
declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error:';
declare @cod_user numeric(18);
select @cod_user=u.Cod_Usuario from TEAM_CASTY.Usuario u where u.Username=@usuario;

if(exists(select * from TEAM_CASTY.Estadia est where est.Cod_Estadia=@cod_estadia and est.Fecha_Salida is not null))
begin
	set @error=1;
set @mensaje=' Ya se había realizado el Check OUT.';
end
else
begin

if(not exists (select * from TEAM_CASTY.Estadia e where @cod_estadia=e.Cod_Estadia))
begin
	set @error=1;
	set @mensaje=@mensaje + ' No se realizó el Check IN previamente';
end;

if (exists (select * from TEAM_CASTY.Estadia e where @cod_estadia=e.Cod_Estadia and datediff(day,e.Fecha_Inicio,@fecha)<0))
begin
	set @error=1;
	set @mensaje=@mensaje + ' No concuerdan las fechas.';
end
else
begin
	declare @fs datetime;
	select @fs=(res.Fecha_Reserva+res.Cant_Noches) from TEAM_CASTY.Reserva res, TEAM_CASTY.Estadia est
	where est.Cod_Estadia=@cod_estadia and est.Cod_Reserva=res.Cod_Reserva;
	if (datediff(day,@fecha,@fs)<0)
	begin
		set @error=1;
		set @mensaje=@mensaje + ' No concuerdan las fechas.';
	end
end

if (exists (select * from TEAM_CASTY.Estadia e where @cod_estadia=e.Cod_Estadia and datediff(day,e.Fecha_Inicio,@fecha)=0))
begin
	set @error=1;
	set @mensaje=@mensaje + ' No ha pasado un día aún.';
end

if(not exists(select *
from TEAM_CASTY.Habitacion hab, TEAM_CASTY.HabitacionXEstadia hxe,TEAM_CASTY.Hotel h, TEAM_CASTY.Usuario u, TEAM_CASTY.RolXUsuarioXHotel uxrxh
where hab.Cod_Hotel=h.Cod_Hotel and
h.Cod_Hotel=@hotel and
hxe.Cod_Habitacion=hab.Cod_Habitacion and
hxe.Cod_Estadia=@cod_estadia and
u.Cod_Usuario=@cod_user and
u.Cod_Usuario=uxrxh.Cod_Usuario))
begin		
	set @error=1;
	set @mensaje=@mensaje + ' El usuario no puede operar sobre ese hotel.';
end;
end

if (@error=0)	
begin
	update TEAM_CASTY.Estadia
	set Fecha_Salida=@fecha,Usuario_Salida=@cod_user
	where @cod_estadia=Cod_Estadia;
end
else
begin
	set @mensaje=@mensaje + ' No se realizó el Check OUT.';
	RAISERROR (@mensaje,15,1);
end
end;

GO

create function TEAM_CASTY.PrecioPorDiaEspecifico
(@hotel numeric(18), @regimen numeric (18),@tipo_habitacion numeric (18))
RETURNS numeric(18,2)
AS
begin 

declare @adicional_hotel numeric (18,2);
declare @precio_regimen numeric (18,2);
declare @precio_tipo_habitacion numeric (18,2);

select @adicional_hotel=(hot.CantEstrella*(select top 1 rec.Recarga from TEAM_CASTY.Recarga_Estrella rec order by rec.Fecha_Modificacion desc))
from TEAM_CASTY.Hotel hot
where hot.Cod_Hotel=@hotel;

select @precio_regimen=reg.Precio
from TEAM_CASTY.Regimen reg
where reg.Cod_Regimen=@regimen;

select @precio_tipo_habitacion=thab.Porcentual
from TEAM_CASTY.Tipo_Habitacion thab
where thab.Cod_Tipo=@tipo_habitacion;

return @precio_tipo_habitacion*@precio_regimen+@adicional_hotel;
end;

GO

create function TEAM_CASTY.MontoConsumibles
(@cod_estadia numeric(18))
RETURNS numeric(18,2)
AS
begin 
declare @monto numeric(18,2)=0;
select @monto=SUM(cxhxe.Precio*cxhxe.Cantidad)
from TEAM_CASTY.ConsumibleXHabitacionXEstadia cxhxe 
where cxhxe.Cod_Estadia=@cod_estadia;
if(@monto is null)
begin
	set @monto=0;
end
return @monto;
end;

GO

create function TEAM_CASTY.MontoHabitaciones
(@cod_estadia numeric(18))
RETURNS numeric(18,2)
AS
begin 
declare @monto numeric(18,2)=0;

select @monto=SUM(ihf.Monto_Completados+ihf.Monto_Faltantes)
from TEAM_CASTY.item_habitacionXFactura ihf, TEAM_CASTY.Factura f
where f.Cod_Estadia=@cod_estadia and ihf.Nro_Factura=f.Nro_Factura;

return @monto;
end;

GO

create procedure  TEAM_CASTY.Facturar
@cod_Estadia numeric(18), @fecha datetime, @cod_forma_pago numeric(18),@hotel numeric(18),@money money output
AS
begin
declare @mensaje nvarchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error: ';

if (exists(select * from TEAM_CASTY.Estadia e where e.Cod_Estadia=@cod_Estadia))
begin
	if ((select e.Fecha_Salida from TEAM_CASTY.Estadia e where e.Cod_Estadia=@cod_Estadia) is null)
	begin
		set @error=1;
		set @mensaje+=' No se realizó el Check OUT aún.';
	end
	else
	begin
		if (datediff(day,(select e.Fecha_Salida from TEAM_CASTY.Estadia e where e.Cod_Estadia=@cod_Estadia),@fecha)<>0)
		begin
			set @error=1;
			set @mensaje+=' Fecha incorrecta.';
		end
		else
		begin
			if(not exists(
			select * from TEAM_CASTY.HabitacionXEstadia hxe, TEAM_CASTY.Habitacion hab
			 where hxe.Cod_Estadia=@cod_Estadia and hxe.Cod_Habitacion=hab.Cod_Habitacion and @hotel=hab.Cod_Hotel))
			begin
				set @error=1;
				set @mensaje+=' El hotel no corresponde a esa estadía.';
			end
		end
	end
end
else
begin
	set @error=1; 
	set @mensaje+=' Estadía inexistente.';
end

if (@error=0)
begin
	begin try
		declare @nro_factura numeric (18);
		select @nro_factura=max(f.Nro_Factura)+1 from TEAM_CASTY.Factura f;
		
		insert into TEAM_CASTY.Factura
		(Cod_Estadia,Cod_Forma_Pago,Fecha,Nro_Factura,Total)
		values (@cod_Estadia,@cod_forma_pago,@fecha,@nro_factura,0);
		
		insert into TEAM_CASTY.item_ConsumibleXFactura
		select @nro_factura, cxhxe.Cod_ConsumibleXHabitacionXEstadia
		from TEAM_CASTY.ConsumibleXHabitacionXEstadia cxhxe
		where cxhxe.Cod_Estadia=@cod_Estadia;
				
		declare @dias_completados numeric (18);
		
		select @dias_completados=DATEDIFF(day,est.Fecha_Inicio,est.Fecha_Salida)
		from TEAM_CASTY.Estadia est
		where est.Cod_Estadia=@cod_Estadia;
		
		declare @dias_faltantes numeric (18);
		select @dias_faltantes=res.Cant_Noches-@dias_completados
		from TEAM_CASTY.Reserva res, TEAM_CASTY.Estadia est
		where @cod_Estadia=est.Cod_Estadia and est.Cod_Reserva=res.Cod_Reserva;
		
		insert into TEAM_CASTY.item_habitacionXFactura
		(Cod_Habitacion,Cod_Regimen,Nro_Factura,Dias_Completados,Monto_Completados,Dias_Faltantes,Monto_Faltantes)
		select hab.Cod_Habitacion,res.Cod_Regimen,@nro_factura,@dias_completados,
		(@dias_completados*TEAM_CASTY.PrecioPorDiaEspecifico(@hotel,res.Cod_Regimen,hab.Cod_Tipo)),
		@dias_faltantes,
		(@dias_faltantes*TEAM_CASTY.PrecioPorDiaEspecifico(@hotel,res.Cod_Regimen,hab.Cod_Tipo))
		from TEAM_CASTY.Reserva res, TEAM_CASTY.Habitacion hab, TEAM_CASTY.HabitacionXEstadia hxe,
		TEAM_CASTY.Estadia est
		where @cod_Estadia=est.Cod_Estadia and res.Cod_Reserva=est.Cod_Reserva and
		est.Cod_Estadia=hxe.Cod_Estadia and hxe.Cod_Habitacion=hab.Cod_Habitacion;
		
		declare @monto_consumibles numeric(18,2);
		set @monto_consumibles=TEAM_CASTY.MontoConsumibles(@cod_Estadia);
		declare @monto_habitaciones numeric(18,2);
		set @monto_habitaciones=TEAM_CASTY.MontoHabitaciones(@cod_Estadia);
		declare @monto_total numeric(18,2);
		set @monto_total=@monto_habitaciones;
		if((select res.Cod_Regimen
		from TEAM_CASTY.Reserva res, TEAM_CASTY.Estadia est
		where est.Cod_Estadia=@cod_Estadia and res.Cod_Reserva=est.Cod_Reserva)<>1)
		begin
			set @monto_total+=@monto_consumibles;
		end
		
		update TEAM_CASTY.Factura
		set Total=@monto_total
		where Cod_Estadia=@cod_Estadia;	
		set @money=@monto_total;
	end try
	begin catch	
		set @mensaje=@mensaje + 'No se realizó la factura.';
		RAISERROR (@mensaje,15,1);
	end catch
end
else
begin	
	set @mensaje=@mensaje + 'No se realizó la factura.';
	RAISERROR (@mensaje,15,1);
end
end;

GO

create procedure  TEAM_CASTY.RegistrarPagoTarjeta
@cod_Estadia numeric(18), @numero_tajeta numeric(18), @banco nvarchar(255)
AS
begin
declare @mensaje nvarchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error:';

declare @id_cliente numeric(18);
select @id_cliente=res.ID_Cliente_Reservador
from TEAM_CASTY.Estadia est, TEAM_CASTY.Reserva res
where est.Cod_Estadia=@cod_Estadia and est.Cod_Reserva=res.Cod_Reserva;

if (not exists(select * from TEAM_CASTY.Tarjeta tar where @numero_tajeta=tar.Numero and @banco=tar.Banco and @id_cliente=tar.ID_Cliente))
begin
	if (exists(select * from TEAM_CASTY.Tarjeta tar where @numero_tajeta=tar.Numero and @banco=tar.Banco))
	begin
		set @error=1;
		set @mensaje+=' La tarjeta no corresonde al cliente que realizó el pago.';
	end
	else
	begin
		insert into TEAM_CASTY.Tarjeta
		(ID_Cliente,Banco,Numero)
		values (@id_cliente,@banco,@numero_tajeta);
		
	end
end


if (@error=0)
begin
	declare @nro_factura numeric(18);
	select @nro_factura=f.Nro_Factura
	from TEAM_CASTY.Factura f
	where f.Cod_Estadia=@cod_Estadia;
	
	insert into TEAM_CASTY.TarjetaXFactura
	(Nro_Factura,Banco,Numero_Tarjeta)
	values (@nro_factura,@banco,@numero_tajeta);
	
	update TEAM_CASTY.Factura
	set Cod_Forma_Pago=2
	where Cod_Estadia=@cod_Estadia;
end
else
begin
	set @mensaje=@mensaje + 'No se realizó el pago correctamente.';
	RAISERROR (@mensaje,15,1);
end
end;

GO

CREATE FUNCTION TEAM_CASTY.vistaTOP5ReservasCanceladas (@pFecha_Inicio date,@pFecha_Fin date)
RETURNS TABLE
AS
RETURN 
   select  top 5 vh.Codigo, vh.Ciudad, vh.Calle,vh.[Numero Calle], vh.Telefono, vh.Mail, vh.[Cantidad de estrellas], vh.[Recarga por estrella], count (distinct r.Cod_Reserva)  as "Cantidad Reservas Canceladas"
   from TEAM_CASTY.vistaHoteles vh, TEAM_CASTY.HabitacionXReserva hxr,TEAM_CASTY.Reserva r ,TEAM_CASTY.Habitacion hab
   where vh.Codigo = hab.Cod_Hotel and hab.Cod_Habitacion= hxr.Cod_Habitacion and r.Cod_Reserva= hxr.Cod_Reserva
       and  r.Cod_Estado in (3,4,5) and r.Fecha_Reserva between @pFecha_Inicio and @pFecha_Fin
   group by vh.Codigo, vh.Ciudad, vh.Calle,vh.[Numero Calle], vh.Telefono, vh.Mail, vh.[Cantidad de estrellas], vh.[Recarga por estrella]
   order by [Cantidad Reservas Canceladas] desc
   
go
   
CREATE FUNCTION TEAM_CASTY.vistaTOP5ConsumiblesFacturados (@pFecha_Inicio date,@pFecha_Fin date)
RETURNS TABLE
AS
RETURN
   select  top 5  vh.Codigo, vh.Ciudad, vh.Calle,vh.[Numero Calle], vh.Telefono, vh.Mail, vh.[Cantidad de estrellas], vh.[Recarga por estrella], Sum (CxHxE.Cantidad) as "Cantidad Consumibles" 
from TEAM_CASTY.vistaHoteles vh,TEAM_CASTY.Habitacion hab, TEAM_CASTY.ConsumibleXHabitacionXEstadia CxHxE, TEAM_CASTY.Factura f
where vh.Codigo = hab.Cod_Hotel and hab.Cod_Habitacion=CxHxE.Cod_Habitacion  and  f.Cod_Estadia = CxHxE.Cod_Estadia 
       and f.Fecha between @pFecha_Inicio and @pFecha_Fin
group by  vh.Codigo, vh.Ciudad, vh.Calle,vh.[Numero Calle], vh.Telefono, vh.Mail, vh.[Cantidad de estrellas], vh.[Recarga por estrella]
order by [Cantidad Consumibles] desc   
   
go   
   
CREATE FUNCTION TEAM_CASTY.cantidadDeDias (@pFecha_Inicio_Trimestre date,@pFecha_Fin_Trimestre date, @pFecha_Inicio_Inhabilitado date,@pFecha_Fin_Inhabilitad date )
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

go


CREATE FUNCTION TEAM_CASTY.vistaTOP5CantidadDeDiasFueraDeServicio (@pFecha_Inicio date,@pFecha_Fin date)
RETURNS TABLE
AS
RETURN
select  top 5 vh.Codigo, vh.Ciudad, vh.Calle,vh.[Numero Calle], vh.Telefono, vh.Mail, vh.[Cantidad de estrellas], vh.[Recarga por estrella],SUM(TEAM_CASTY.cantidadDeDias(@pFecha_Inicio, @pFecha_Fin,ph.Fecha_Inicio,ph.Fecha_Fin )) as "Total Dias Fuera De Servicio"
from TEAM_CASTY.vistaHoteles vh, TEAM_CASTY.Periodo_Inhabilitado ph 
where vh.Codigo = ph.Cod_Hotel and TEAM_CASTY.cantidadDeDias(@pFecha_Inicio, @pFecha_Fin,ph.Fecha_Inicio,ph.Fecha_Fin ) >0
group by vh.Codigo, vh.Ciudad, vh.Calle,vh.[Numero Calle], vh.Telefono, vh.Mail, vh.[Cantidad de estrellas], vh.[Recarga por estrella]
order by [Total Dias Fuera De Servicio] desc
   
go   

CREATE FUNCTION TEAM_CASTY.vistaTOP5HabitacionesHabitadas (@pFecha_Inicio date,@pFecha_Fin date)
RETURNS TABLE
AS
RETURN
select  top 5 vhab.Codigo, vhab.[Numero Hotel], vhab.Numero, vhab.Piso,vhab.Frente,vhab.[Descripcion de tipo], vhab.Porcentual ,SUM(TEAM_CASTY.cantidadDeDias(@pFecha_Inicio, @pFecha_Fin,est.Fecha_Inicio,est.Fecha_Salida )) as "Dias Ocupada", COUNT (est.Cod_Estadia) as "Cantidad De Veces Ocupada"
from TEAM_CASTY.vistaHabitaciones vhab,TEAM_CASTY.HabitacionXEstadia habxest, TEAM_CASTY.Estadia est
where vhab.Codigo = habxest.Cod_Habitacion   and est.Cod_Estadia=habxest.Cod_Estadia and  TEAM_CASTY.cantidadDeDias(@pFecha_Inicio, @pFecha_Fin,est.Fecha_Inicio,est.Fecha_Salida) >0
group by  vhab.Codigo, vhab.[Numero Hotel], vhab.Numero, vhab.Piso,vhab.Frente ,vhab.[Descripcion de tipo], vhab.Porcentual
order by  [Dias Ocupada] desc, [Cantidad De Veces Ocupada] desc

go



CREATE FUNCTION TEAM_CASTY.vistaTOP5ClienteConPuntos (@pFecha_Inicio date,@pFecha_Fin date)
returns table
return (
select top 5  c.Nombre, c.Apellido,td.Tipo_Documento ,c.Nro_Documento,c.Nacionalidad,c.Mail,c.Fecha_Nacimiento ,sum(fac.Puntos) as Puntos
from TEAM_CASTY.Factura fac,TEAM_CASTY.Reserva res,TEAM_CASTY.Estadia est,TEAM_CASTY.Cliente c, TEAM_CASTY.Tipo_Documento td
where (fac.Fecha between @pFecha_Inicio and @pFecha_Fin) and fac.Cod_Estadia=est.Cod_Estadia and
res.Cod_Reserva=est.Cod_Reserva and c.ID_Cliente=res.ID_Cliente_Reservador and c.ID_Tipo_Documento=td.ID_Tipo_Documento
group by c.Nombre, c.Apellido,td.Tipo_Documento ,c.Nro_Documento,c.Nacionalidad,c.Mail,c.Fecha_Nacimiento 
order by Puntos desc
);

go