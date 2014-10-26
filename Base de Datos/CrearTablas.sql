--#define false 0
--#define true 1

CREATE TABLE TEAM_CASTY.Consumible ( 
	Cod_Consumible numeric(18) NOT NULL PRIMARY KEY,
	Descripcion nvarchar(255) NOT NULL,
	Precio numeric(18,2) NOT NULL);
	
	
CREATE TABLE TEAM_CASTY.Cliente ( 
	ID_Cliente numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Tipo_Documento varchar(20) NOT NULL,
	Nro_Documento numeric(18) NOT NULL,
	Apellido nvarchar(255) NOT NULL,
	Nombre nvarchar(255) NOT NULL,
	Fecha_Nacimiento datetime NOT NULL,
	Mail nvarchar(255) NOT NULL,
	Pais nvarchar(255),
	Localidad nvarchar(255),
	Nom_Calle nvarchar(255) NOT NULL,
	Nro_Calle numeric(18) NOT NULL,
	Piso numeric(18) NOT NULL,
	Nacionalidad nvarchar(255) NOT NULL,
	Telefono nvarchar(50) NOT NULL,
	Inhabilitado bit NOT NULL,	
	Duplicado bit NOT NULL);
	
	
CREATE TABLE TEAM_CASTY.Empleado ( 
	Nombre nvarchar(255) NOT NULL,
	Apellido nvarchar(255) NOT NULL,
	Mail nvarchar(255) NOT NULL,
	Telefono nvarchar(50) NOT NULL,
	Direccion nvarchar(255) NOT NULL,
	Fecha_Nacimiento datetime NOT NULL,
	Cod_Hotel numeric(18) NOT NULL,
	Cod_Empleado numeric(18) NOT NULL PRIMARY KEY);
	
	
CREATE TABLE TEAM_CASTY.Estados ( 
	Cod_Estado numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Descripcion nvarchar(255),
	Nombre nvarchar(255) NOT NULL UNIQUE);
	
	
CREATE TABLE TEAM_CASTY.Regimen ( 
	Cod_Regimen numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Descripcion nvarchar(255) NOT NULL,
	Precio numeric(18,2) NOT NULL);	
	
	
CREATE TABLE TEAM_CASTY.Reserva ( 
	Cod_Reserva numeric(18) NOT NULL PRIMARY KEY,
	Fecha_Reserva datetime NOT NULL,
	Cant_Noches numeric(18) NOT NULL,
	Cod_Hotel numeric(18) NOT NULL,
	ID_Cliente_Reservador numeric(18) NOT NULL,
	Cod_Regimen numeric(18) DEFAULT NULL,	
	--Cod_Tipo numeric(18) NOT NULL, --¿que es?	
	Fecha_Inicio datetime,
	Fecha_Salida datetime,	
	Cod_Estado numeric(18) NOT NULL DEFAULT 1,
	FOREIGN KEY (ID_Cliente_Reservador) REFERENCES TEAM_CASTY.Cliente (ID_Cliente),
	FOREIGN KEY (Cod_Regimen) REFERENCES TEAM_CASTY.Regimen (Cod_Regimen),
	FOREIGN KEY (Cod_Estado) REFERENCES TEAM_CASTY.Estados (Cod_Estado));
	
	
CREATE TABLE TEAM_CASTY.ClienteXReserva ( 	
	Cod_Reserva numeric(18) NOT NULL,
	ID_Cliente numeric(18) NOT NULL,
	PRIMARY KEY (Cod_Reserva,ID_Cliente),
	FOREIGN KEY (Cod_Reserva) REFERENCES TEAM_CASTY.Reserva (Cod_Reserva),
	FOREIGN KEY (ID_Cliente) REFERENCES TEAM_CASTY.Cliente (ID_Cliente));	
		
	
CREATE TABLE TEAM_CASTY.ConsumibleXReserva ( 
	Cod_Reserva numeric(18) NOT NULL,
	Cod_Consumible numeric(18) NOT NULL,
	PRIMARY KEY (Cod_Reserva, Cod_Consumible),
	FOREIGN KEY (Cod_Consumible) REFERENCES TEAM_CASTY.Consumible (Cod_Consumible),
	FOREIGN KEY (Cod_Reserva) REFERENCES TEAM_CASTY.Reserva (Cod_Reserva));	
	
	
CREATE TABLE TEAM_CASTY.Forma_Pago ( 
	Cod_Forma_Pago numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Descripcion nvarchar(255) NOT NULL);
		
	
CREATE TABLE TEAM_CASTY.Factura ( 
	Fecha datetime NOT NULL,
	Nro_Factura numeric(18) NOT NULL PRIMARY KEY,
	Total numeric(18,2) NOT NULL,
	Cod_Reserva numeric(18) NOT NULL,
	Basico numeric(18,2) NOT NULL,
	Cod_FormaDePago numeric(18) NOT NULL,
	FOREIGN KEY (Cod_FormaDePago) REFERENCES TEAM_CASTY.FormaDePago (Cod_FormaDePago),
	FOREIGN KEY (Cod_Reserva) REFERENCES TEAM_CASTY.Reserva (Cod_Reserva));
	
	
CREATE TABLE TEAM_CASTY.Funcion ( 
	Cod_Funcion numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Descripcion nvarchar(255) NOT NULL);	


CREATE TABLE TEAM_CASTY.FuncionXRol ( 
	Cod_Rol numeric(18) NOT NULL,
	Cod_Funcion numeric(18) NOT NULL,
	PRIMARY KEY (Cod_Rol, Cod_Funcion),
	FOREIGN KEY (Cod_Funcion) REFERENCES TEAM_CASTY.Funcion (Cod_Funcion),
	FOREIGN KEY (Cod_Rol) REFERENCES TEAM_CASTY.Rol (Cod_Rol));
	
	
CREATE TABLE TEAM_CASTY.Hotel ( 
	Cod_Ciudad numeric(18) NOT NULL,
	Calle nvarchar(255) NOT NULL,
	Nro_Calle numeric(18) NOT NULL,
	CantEstrella numeric(18) NOT NULL,
	Cod_Recarga numeric(18) NOT NULL,
	Cod_Hotel numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Fecha_Creacion datetime,
	Telefono nvarchar(50),
	Mail nvarchar(255),
	FOREIGN KEY (Cod_Recarga) REFERENCES TEAM_CASTY.Recarga_Estrella (Cod_Recarga));

CREATE TABLE TEAM_CASTY.Ciudad (
	Cod_Ciudad numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Nombre nvarchar(255) NOT NULL);


CREATE TABLE TEAM_CASTY.Tipo_Habitacion ( 
	Cod_Tipo numeric(18) NOT NULL PRIMARY KEY,
	Descripcion nvarchar(255) NOT NULL,
	Porcentual numeric(18,2) NOT NULL);
		
		
CREATE TABLE TEAM_CASTY.Recarga_Estrella ( 
	Cod_Recarga numeric(18) NOT NULL PRIMARY KEY,
	Fecha_Modificacion datetime NOT NULL,
	Recarga numeric(18) NOT NULL);
			

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
	
	
CREATE TABLE TEAM_CASTY.HabitacionXReserva ( 
	Cod_Reserva numeric(18) NOT NULL,
	Numero numeric(18) NOT NULL,
	Cod_Hotel numeric(18) NOT NULL,
	PRIMARY KEY (Cod_Reserva, Numero, Cod_Hotel),
	FOREIGN KEY (Numero, Cod_Hotel) REFERENCES TEAM_CASTY.Habitacion (Numero, Cod_Hotel),
	FOREIGN KEY (Cod_Reserva) REFERENCES TEAM_CASTY.Reserva (Cod_Reserva));
	
	
CREATE TABLE TEAM_CASTY.Item_Factura_Consumible ( 
	Cantidad numeric(18) NOT NULL,
	Precio_Unitario numeric(18,2) NOT NULL,
	Nro_Factura numeric(18) NOT NULL,
	Cod_Consumible numeric(18) NOT NULL,
	PRIMARY KEY (Nro_Factura, Cod_Consumible),
	FOREIGN KEY (Cod_Consumible) REFERENCES TEAM_CASTY.Consumible (Cod_Consumible),
	FOREIGN KEY (Nro_Factura) REFERENCES TEAM_CASTY.Factura (Nro_Factura));
	
	
CREATE TABLE TEAM_CASTY.Usuario ( 
	Username nvarchar(255) NOT NULL UNIQUE,
	Password nvarchar(255) NOT NULL,
	Cod_Usuario numeric(18) NOT NULL PRIMARY KEY ,
	Cant_Intentos numeric(18) DEFAULT 0 NOT NULL,
	Cod_Empleado numeric(18) NOT NULL,
	Habilitado bit DEFAULT 1 NOT NULL,
	Baja bit DEFAULT 0 NOT NULL,
	FOREIGN KEY (Cod_Empleado) REFERENCES TEAM_CASTY.Empleado (Cod_Empleado));
	
	
CREATE TABLE TEAM_CASTY.Periodo_Inhabilitado ( 
	Cod_Hotel numeric(18) NOT NULL,
	Fecha_Inicio datetime NOT NULL,
	Fecha_Fin datetime NOT NULL,
	Descripcion varchar(255),
	PRIMARY KEY (Cod_Hotel, Fecha_Inicio, Fecha_Fin),--ver
	FOREIGN KEY (Cod_Hotel) REFERENCES TEAM_CASTY.Hotel (Cod_Hotel));
	
	
CREATE TABLE TEAM_CASTY.RegimenXHotel ( 
	Cod_Hotel numeric(18) NOT NULL,
	Cod_Regimen numeric(18) NOT NULL,
	Activo bit NOT NULL,
	PRIMARY KEY (Cod_Hotel, Cod_Regimen),
	FOREIGN KEY (Cod_Hotel) REFERENCES TEAM_CASTY.Hotel (Cod_Hotel),
	FOREIGN KEY (Cod_Regimen) REFERENCES TEAM_CASTY.Regimen (Cod_Regimen));	
CREATE TABLE TEAM_CASTY.RolXUsuarioXHotel ( --VER
	Cod_Rol numeric(18) NOT NULL,
	Cod_Usuario numeric(18) NOT NULL,
	Cod_Hotel numeric(18) NOT NULL,
	PRIMARY KEY (Cod_Hotel, Cod_Usuario),
	FOREIGN KEY (Cod_Hotel) REFERENCES TEAM_CASTY.Hotel (Cod_Hotel),
	FOREIGN KEY (Cod_Usuario) REFERENCES TEAM_CASTY.Usuario (Cod_Usuario));	
	

CREATE TABLE TEAM_CASTY.Rol ( 
	Cod_Rol numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Nombre nvarchar(255) NOT NULL,
	Activo bit DEFAULT 1 NOT NULL);
	
	
CREATE TABLE TEAM_CASTY.RolXUsuario ( 
	Cod_Rol numeric(18) NOT NULL,
	Cod_Usuario numeric(18) NOT NULL,
	PRIMARY KEY (Cod_Rol, Cod_Usuario),
	FOREIGN KEY (Cod_Rol) REFERENCES TEAM_CASTY.Rol (Cod_Rol),
	FOREIGN KEY (Cod_Usuario) REFERENCES TEAM_CASTY.Usuario (Cod_Usuario));
	
	
CREATE TABLE TEAM_CASTY.Tarjeta ( 
	Numero numeric(18) NOT NULL,
	Banco nvarchar(255) NOT NULL,
	ID_Cliente numeric(18) NOT NULL,
	PRIMARY KEY (Numero, Banco),
	FOREIGN KEY (ID_Cliente) REFERENCES TEAM_CASTY.Cliente (ID_Cliente));
	
	
CREATE TABLE TEAM_CASTY.TarjetaXFactura ( 
	Nro_Factura numeric(18) NOT NULL,
	Numero_Tarjeta numeric(18) NOT NULL,
	Banco nvarchar(255) NOT NULL,
	PRIMARY KEY (Nro_Factura, Numero_Tarjeta, Banco),
	FOREIGN KEY (Nro_Factura) REFERENCES TEAM_CASTY.Factura (Nro_Factura),
	FOREIGN KEY (Numero_Tarjeta, Banco) REFERENCES TEAM_CASTY.Tarjeta (Numero, Banco));
	
	
CREATE TABLE TEAM_CASTY.UsuarioXHotel ( 
	Cod_Hotel numeric(18) NOT NULL,
	Cod_Usuario numeric(18) NOT NULL,
	PRIMARY KEY (Cod_Hotel, Cod_Usuario),
	FOREIGN KEY (Cod_Hotel) REFERENCES TEAM_CASTY.Hotel (Cod_Hotel),
	FOREIGN KEY (Cod_Usuario) REFERENCES TEAM_CASTY.Usuario (Cod_Usuario));	
	
	
CREATE TABLE TEAM_CASTY.UsuarioXReserva ( 
	Cod_Reserva numeric(18) NOT NULL,
	Cod_Usuario numeric(18) NOT NULL,
	Fecha datetime NOT NULL,
	Numero_Modificacion numeric(18) NOT NULL,
	Descripcion varchar(255),
	PRIMARY KEY (Cod_Reserva, Numero_Modificacion),
	FOREIGN KEY (Cod_Reserva) REFERENCES TEAM_CASTY.Reserva (Cod_Reserva),
	FOREIGN KEY (Cod_Usuario) REFERENCES TEAM_CASTY.Usuario (Cod_Usuario));