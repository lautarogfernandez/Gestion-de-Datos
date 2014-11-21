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
CREATE TABLE TEAM_CASTY.item_habitacionXFactura ( 
	Nro_Factura numeric(18) NOT NULL,
	Cod_Habitacion numeric(18) NOT NULL,
	Cod_Regimen numeric(18) NOT NULL,
	Monto numeric(18,2) NOT NULL,
	PRIMARY KEY (Nro_Factura,Cod_Habitacion,Cod_Regimen),
	FOREIGN KEY (Cod_Habitacion) REFERENCES TEAM_CASTY.Habitacion (Cod_Habitacion),
	FOREIGN KEY (Nro_Factura) REFERENCES TEAM_CASTY.Factura (Nro_Factura),
	FOREIGN KEY (Cod_Regimen) REFERENCES TEAM_CASTY.Regimen (Cod_Regimen));

INSERT INTO TEAM_CASTY.item_habitacionXFactura (Nro_Factura,Cod_Habitacion,Cod_Regimen,Monto)
SELECT f.Nro_Factura, hxr.Cod_Habitacion, res.Cod_Regimen, res.Cant_Noches*reg.Precio*thab.Porcentual+hot.CantEstrella*rec.Recarga AS Monto
FROM TEAM_CASTY.Factura f, TEAM_CASTY.Habitacion hab, TEAM_CASTY.HabitacionXReserva hxr, TEAM_CASTY.Hotel hot, TEAM_CASTY.Recarga_Estrella rec, TEAM_CASTY.Regimen reg, TEAM_CASTY.Reserva res,TEAM_CASTY.Tipo_Habitacion thab
WHERE f.Cod_Reserva=res.Cod_Reserva and
res.Cod_Reserva=hxr.Cod_Reserva and
hxr.Cod_Habitacion=hab.Cod_Habitacion and
hab.Cod_Hotel=hot.Cod_Hotel and
rec.Cod_Recarga=1 and
res.Cod_Regimen=reg.Cod_Regimen and
thab.Cod_Tipo=hab.Cod_Tipo






create trigger TEAM_CASTY.alta_clientes
ON TEAM_CASTY.vistaClientes
instead of INSERT
AS
begin

declare @cod_tipo_doc numeric(18)

DECLARE _cursor CURSOR FOR
SELECT * FROM inserted

DECLARE @Cod numeric(18),@Nombre nvarchar(255), @Apellido nvarchar(255),@Mail nvarchar(255),
@Tipo_Documento nvarchar(255), @Num_doc numeric(18),
@Telefono numeric(18),@Pais nvarchar(255),@Localidad nvarchar(255),@Nom_Calle nvarchar(255),
@Nro_Calle numeric(18),@Piso numeric(18),@Dto nvarchar(50),@Nacionalidad nvarchar(255),
@Fecha_Nacimiento datetime

OPEN _cursor;
FETCH NEXT FROM _cursor INTO @Cod, @Nombre, @Apellido, @Mail,@Tipo_Documento, @Num_doc,
@Telefono,@Pais,@Localidad,@Nom_Calle ,@Nro_Calle,@Piso ,@Dto,@Nacionalidad,@Fecha_Nacimiento

WHILE @@FETCH_STATUS = 0
BEGIN
 
select @cod_tipo_doc=td.ID_Tipo_Documento
from TEAM_CASTY.Tipo_Documento td
where @Tipo_Documento=td.Tipo_Documento

declare @mensaje varchar(1000)
declare @error int
set @error=0
set @mensaje=''

if(exists (select * from TEAM_CASTY.Cliente c where c.Mail=@Mail))
begin
set @error=1
set @mensaje=@mensaje + 'Mail repetido. ';
end

if(exists (select * from TEAM_CASTY.Cliente c where c.Nro_Documento=@Num_doc and c.ID_Tipo_Documento=@cod_tipo_doc))
begin
set @error=1
set @mensaje=@mensaje + 'Documento repetido. ';
end

if(@error=0)
begin
insert into TEAM_CASTY.Cliente 
(Nombre,Apellido,Mail,ID_Tipo_Documento,Nro_Documento,Telefono,Pais,Localidad,Nom_Calle,Nro_Calle,
Piso,Dto,Nacionalidad,Fecha_Nacimiento)
values (@Nombre, @Apellido, @Mail,@cod_tipo_doc,@Num_doc,@Telefono,@Pais,@Localidad,@Nom_Calle,@Nro_Calle,
@Piso,@Dto,@Nacionalidad,@Fecha_Nacimiento)
end

else
begin
set @mensaje=@mensaje + 'No se realizó el alta';
RAISERROR (@mensaje,10,1);
end

FETCH NEXT FROM _cursor INTO @Cod, @Nombre, @Apellido, @Mail,@Tipo_Documento, @Num_doc,
@Telefono,@Pais,@Localidad,@Nom_Calle ,@Nro_Calle,@Piso ,@Dto,@Nacionalidad,@Fecha_Nacimiento

END

CLOSE _cursor;
DEALLOCATE _cursor;

end

GO



--create trigger TEAM_CASTY.alta_clientes
--ON TEAM_CASTY.vistaClientes
--instead of INSERT
--AS
--begin


--insert into TEAM_CASTY.Cliente
--(Nombre,Apellido,Mail,ID_Tipo_Documento,Nro_Documento,Telefono,Pais,Localidad,Nom_Calle,Nro_Calle,
--Piso,Dto,Nacionalidad,Fecha_Nacimiento)
--select i.Nombre,i.Apellido,i.Mail,td.ID_Tipo_Documento,i.[Numero Documento],i.Telefono,i.Pais,i.Localidad,i.Calle,i.[Numero Calle],i.Piso,i.Departamento,i.Nacionalidad,i.[Fecha Nacimiento]
--from inserted i, TEAM_CASTY.Tipo_Documento td
--where i.[Tipo Documento]=td.Tipo_Documento


--end
--GO


create trigger TEAM_CASTY.alta_clientes
ON TEAM_CASTY.vistaClientes
instead of insert
AS
begin

declare @cod_tipo_doc numeric(18);
DECLARE _cursor CURSOR FOR
SELECT * FROM inserted;
DECLARE @Cod numeric(18),@Nombre nvarchar(255), @Apellido nvarchar(255),@Mail nvarchar(255),
@Tipo_Documento nvarchar(255), @Num_doc numeric(18),
@Telefono numeric(18),@Pais nvarchar(255),@Localidad nvarchar(255),@Nom_Calle nvarchar(255),
@Nro_Calle numeric(18),@Piso numeric(18),@Dto nvarchar(50),@Nacionalidad nvarchar(255),
@Fecha_Nacimiento datetime;
OPEN _cursor;
FETCH NEXT FROM _cursor INTO @Cod, @Nombre, @Apellido, @Mail,@Tipo_Documento, @Num_doc,
@Telefono,@Pais,@Localidad,@Nom_Calle ,@Nro_Calle,@Piso ,@Dto,@Nacionalidad,@Fecha_Nacimiento

WHILE @@FETCH_STATUS = 0
BEGIN
 
select @cod_tipo_doc=td.ID_Tipo_Documento
from TEAM_CASTY.Tipo_Documento td
where @Tipo_Documento=td.Tipo_Documento

declare @mensaje varchar(1000)
declare @error int
set @error=0
set @mensaje='Error: '

if(exists (select * from TEAM_CASTY.Cliente c where c.Mail=@Mail))
begin
set @error=1
set @mensaje=@mensaje + 'Mail repetido. ';
end

if(exists (select * from TEAM_CASTY.Cliente c where c.Nro_Documento=@Num_doc and c.ID_Tipo_Documento=@cod_tipo_doc))
begin
set @error=1
set @mensaje=@mensaje + 'Documento repetido. ';
end

if(@error=0)
begin
insert into TEAM_CASTY.Cliente 
(Nombre,Apellido,Mail,ID_Tipo_Documento,Nro_Documento,Telefono,Pais,Localidad,Nom_Calle,Nro_Calle,
Piso,Dto,Nacionalidad,Fecha_Nacimiento)
values (@Nombre, @Apellido, @Mail,@cod_tipo_doc,@Num_doc,@Telefono,@Pais,@Localidad,@Nom_Calle,@Nro_Calle,
@Piso,@Dto,@Nacionalidad,@Fecha_Nacimiento)
end

else
begin
set @mensaje=@mensaje + 'No se realizó el alta';
RAISERROR (@mensaje,10,1);
end

FETCH NEXT FROM _cursor INTO @Cod, @Nombre, @Apellido, @Mail,@Tipo_Documento, @Num_doc,
@Telefono,@Pais,@Localidad,@Nom_Calle ,@Nro_Calle,@Piso ,@Dto,@Nacionalidad,@Fecha_Nacimiento

END
CLOSE _cursor;
DEALLOCATE _cursor;
end