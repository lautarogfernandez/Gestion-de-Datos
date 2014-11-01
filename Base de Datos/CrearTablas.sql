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
		
	
CREATE TABLE TEAM_CASTY.ConsumibleXHabitacionXReserva ( 
	Cod_Reserva numeric(18) NOT NULL,
	Cod_Habitacion numeric(18) NOT NULL,
	Cod_Consumible numeric(18) NOT NULL,
	Cantidad numeric(18) NOT NULL,
	PRIMARY KEY (Cod_Reserva,Cod_Habitacion,Cod_Consumible),
	FOREIGN KEY (Cod_Habitacion) REFERENCES TEAM_CASTY.Habitacion (Cod_Habitacion),
	FOREIGN KEY (Cod_Reserva) REFERENCES TEAM_CASTY.Reserva (Cod_Reserva),
	FOREIGN KEY (Cod_Consumible) REFERENCES TEAM_CASTY.Consumible (Cod_Consumible));
	
	
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
	Cod_Usuario numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Username nvarchar(255) NOT NULL UNIQUE,
	Password nvarchar(255) NOT NULL,	
	Cant_Intentos numeric(18) DEFAULT 0 NOT NULL,
	Cod_Empleado numeric(18) NOT NULL,
	Habilitado bit DEFAULT 1 NOT NULL,
	Baja bit DEFAULT 0 NOT NULL);
	
	
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
	
	
CREATE TABLE TEAM_CASTY.RolXUsuarioXHotel (
	Cod_Rol numeric(18) NOT NULL,
	Cod_Usuario numeric(18) NOT NULL,
	Cod_Hotel numeric(18) NOT NULL,
	PRIMARY KEY (Cod_Usuario,Cod_Hotel,Cod_Rol),
	FOREIGN KEY (Cod_Rol) REFERENCES TEAM_CASTY.Rol (Cod_Rol),
	FOREIGN KEY (Cod_Hotel) REFERENCES TEAM_CASTY.Hotel (Cod_Hotel),
	FOREIGN KEY (Cod_Usuario) REFERENCES TEAM_CASTY.Usuario (Cod_Usuario));	
	

CREATE TABLE TEAM_CASTY.Rol ( 
	Cod_Rol numeric(18) NOT NULL PRIMARY KEY IDENTITY (1, 1),
	Nombre nvarchar(255) NOT NULL,
	Activo bit DEFAULT 1 NOT NULL);
	
	
CREATE TABLE TEAM_CASTY.RolXUsuario ( --no va, la que va es TEAM_CASTY.RolXUsuarioXHotel
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
	
	
CREATE TABLE TEAM_CASTY.UsuarioXHotel ( --me parece que no va
	Cod_Hotel numeric(18) NOT NULL,
	Cod_Usuario numeric(18) NOT NULL,
	PRIMARY KEY (Cod_Hotel, Cod_Usuario),
	FOREIGN KEY (Cod_Hotel) REFERENCES TEAM_CASTY.Hotel (Cod_Hotel),
	FOREIGN KEY (Cod_Usuario) REFERENCES TEAM_CASTY.Usuario (Cod_Usuario));	
	
	
CREATE TABLE TEAM_CASTY.UsuarioXReserva ( 
	Cod_Reserva numeric(18) NOT NULL,
	Numero_Modificacion numeric(18) NOT NULL,
	Cod_Usuario numeric(18) NOT NULL,
	Fecha datetime NOT NULL,	
	Descripcion varchar(255),
	PRIMARY KEY (Cod_Reserva, Numero_Modificacion),
	FOREIGN KEY (Cod_Reserva) REFERENCES TEAM_CASTY.Reserva (Cod_Reserva),
	FOREIGN KEY (Cod_Usuario) REFERENCES TEAM_CASTY.Usuario (Cod_Usuario));
	
	
	
	
	
	
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
	