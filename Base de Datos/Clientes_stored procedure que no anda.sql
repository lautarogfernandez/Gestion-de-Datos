-- no anda
create procedure  TEAM_CASTY.Cargar_Clientes
AS

DECLARE _cursor CURSOR FOR
SELECT distinct t2.Cliente_Pasaporte_Nro, t2.Cliente_Apellido, t2.Cliente_Nombre, t2.Cliente_Fecha_Nac, t2.Cliente_Mail, t2.Cliente_Dom_Calle, t2.Cliente_Nro_Calle, t2.Cliente_Piso , t2.Cliente_Depto, t2.Cliente_Nacionalidad
FROM (SELECT DISTINCT t1.Cliente_Pasaporte_Nro, t1.Cliente_Nombre, t1.Cliente_Apellido
	  FROM gd_esquema.Maestra t1) t3, 
	  gd_esquema.Maestra t2
WHERE t2.Cliente_Pasaporte_Nro=t3.Cliente_Pasaporte_Nro
ORDER BY t2.Cliente_Pasaporte_Nro, t2.Cliente_Apellido, t2.Cliente_Nombre

DECLARE 
@Cliente_Pasaporte_Nro numeric(18), @Cliente_Apellido nvarchar(255),
@Cliente_Nombre nvarchar(255), @Cliente_Fecha_Nac datetime,
@Cliente_Mail nvarchar(255), @Cliente_Dom_Calle nvarchar(255),
@Cliente_Nro_Calle numeric(18), @Cliente_Piso numeric(18),
@Cliente_Depto nvarchar(50), @Cliente_Nacionalidad nvarchar(255);
OPEN _cursor;
FETCH NEXT FROM _cursor INTO @Cliente_Pasaporte_Nro,@Cliente_Apellido,
@Cliente_Nombre, @Cliente_Fecha_Nac, @Cliente_Mail, @Cliente_Dom_Calle,
@Cliente_Nro_Calle, @Cliente_Piso, @Cliente_Depto, @Cliente_Nacionalidad;

WHILE @@FETCH_STATUS = 0
BEGIN
 
  IF (NOT EXISTS (select Tipo_Documento,Nro_Documento
				  from TEAM_CASTY.Cliente
				  where Tipo_Documento='PASAPORTE' AND  Nro_Documento=@Cliente_Pasaporte_Nro))
  BEGIN
        INSERT INTO TEAM_CASTY.Cliente
        (Tipo_Documento,Nro_Documento,Apellido,Nombre,Fecha_Nacimiento,Pais,Localidad,
		 Nom_Calle,Nro_Calle,Piso,Dto,Nacionalidad,Mail)
        VALUES('PASAPORTE',@Cliente_Pasaporte_Nro,@Cliente_Apellido,@Cliente_Nombre,
			   @Cliente_Fecha_Nac,'ARGENTINA','CAPITAL FEDERAL',@Cliente_Dom_Calle,
		       @Cliente_Nro_Calle, @Cliente_Piso, @Cliente_Depto, @Cliente_Nacionalidad,@Cliente_Mail)
  END
  ELSE
  BEGIN
		UPDATE TEAM_CASTY.Cliente SET Duplicado=1 WHERE Nro_Documento=@Cliente_Pasaporte_Nro
		INSERT INTO TEAM_CASTY.Cliente
        (Tipo_Documento,Nro_Documento,Apellido,Nombre,Fecha_Nacimiento,Pais,Localidad,
		 Nom_Calle,Nro_Calle,Piso,Dto,Nacionalidad,Mail,Duplicado)
        VALUES('PASAPORTE',@Cliente_Pasaporte_Nro,@Cliente_Apellido,@Cliente_Nombre,
			   @Cliente_Fecha_Nac,'ARGENTINA','CAPITAL FEDERAL',@Cliente_Dom_Calle,
		       @Cliente_Nro_Calle, @Cliente_Piso, @Cliente_Depto, @Cliente_Nacionalidad,@Cliente_Mail,1)
  END

  FETCH NEXT FROM _cursor INTO @Cliente_Pasaporte_Nro,@Cliente_Apellido,
  @Cliente_Nombre, @Cliente_Fecha_Nac, @Cliente_Mail, @Cliente_Dom_Calle,
  @Cliente_Nro_Calle, @Cliente_Piso, @Cliente_Depto, @Cliente_Nacionalidad;

END;

CLOSE _cursor;
DEALLOCATE _cursor;

EXEC TEAM_CASTY.Cargar_Clientes



create procedure  TEAM_CASTY.Setear_Check_IN_OUT
AS
DECLARE _cursor CURSOR FOR
SELECT  Cod_Reserva
FROM TEAM_CASTY.Reserva res
DECLARE @Cod_Reserva numeric(18,0)
OPEN _cursor;
FETCH NEXT FROM _cursor INTO @Cod_Reserva;
WHILE @@FETCH_STATUS = 0
BEGIN
if(@Cod_Reserva in (select f.Cod_Reserva from TEAM_CASTY.Factura f))
begin
update TEAM_CASTY.Reserva
set Fecha_Inicio=Fecha_Reserva,
Fecha_Salida=(select f.Fecha from TEAM_CASTY.Factura f where f.Cod_Reserva=@Cod_Reserva),
Cod_Estado=6
where @Cod_Reserva=Cod_Reserva
end
else
FETCH NEXT FROM _cursor INTO @Cod_Reserva;
END

GO