--Triggers
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

if(exists (select * from TEAM_CASTY.Cliente c where c.Mail=@Mail))
begin
RAISERROR (N'Mail repetido.',10,1);
end
else
insert into TEAM_CASTY.Cliente 
(Nombre,Apellido,Mail,ID_Tipo_Documento,Nro_Documento,Telefono,Pais,Localidad,Nom_Calle,Nro_Calle,
Piso,Dto,Nacionalidad,Fecha_Nacimiento)
values (@Nombre, @Apellido, @Mail,@cod_tipo_doc,@Num_doc,@Telefono,@Pais,@Localidad,@Nom_Calle,@Nro_Calle,
@Piso,@Dto,@Nacionalidad,@Fecha_Nacimiento)
end
FETCH NEXT FROM _cursor INTO @Cod, @Nombre, @Apellido, @Mail,@Tipo_Documento, @Num_doc,
@Telefono,@Pais,@Localidad,@Nom_Calle ,@Nro_Calle,@Piso ,@Dto,@Nacionalidad,@Fecha_Nacimiento

END;




CLOSE _cursor;
DEALLOCATE _cursor;

end
GO

insert into TEAM_CASTY.vistaClientes
(Nombre,Apellido,[Tipo Documento],[Numero Documento],Mail,Telefono,Pais,Localidad,Calle,[Numero Calle],Piso,Departamento,Nacionalidad,[Fecha Nacimiento])
VALUES('casty','casty','PASAPORTE',222,'maaadsdggsailcasty@cascsc',111,'casty','casty','casty',111,2,'SSS','casty',CONVERT(DATETIME,'1979-06-24',111))

select * from TEAM_CASTY.vistaClientes





create trigger TEAM_CASTY.alta_clientes
ON TEAM_CASTY.vistaClientes
instead of INSERT
AS
begin


insert into TEAM_CASTY.Cliente
(Nombre,Apellido,Mail,ID_Tipo_Documento,Nro_Documento,Telefono,Pais,Localidad,Nom_Calle,Nro_Calle,
Piso,Dto,Nacionalidad,Fecha_Nacimiento)
select i.Nombre,i.Apellido,i.Mail,td.ID_Tipo_Documento,i.[Numero Documento],i.Telefono,i.Pais,i.Localidad,i.Calle,i.[Numero Calle],i.Piso,i.Departamento,i.Nacionalidad,i.[Fecha Nacimiento]
from inserted i, TEAM_CASTY.Tipo_Documento td
where i.[Tipo Documento]=td.Tipo_Documento


end
GO