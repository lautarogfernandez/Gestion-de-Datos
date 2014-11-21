--Triggers
create trigger TEAM_CASTY.alta_clientes
ON TEAM_CASTY.vistaClientes
instead of insert
AS
begin

declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error: ';

if(exists (select * from TEAM_CASTY.Cliente c,inserted ins where c.Mail=ins.Mail))
begin
set @error=1
set @mensaje=@mensaje + 'Mail repetido. ';
end

if(exists (select * from TEAM_CASTY.Cliente c,inserted ins,TEAM_CASTY.Tipo_Documento tdoc where c.Nro_Documento=ins.[Numero Documento] and c.ID_Tipo_Documento=tdoc.ID_Tipo_Documento and ins.[Tipo Documento]=tdoc.Tipo_Documento))
begin
set @error=1
set @mensaje=@mensaje + 'Documento repetido. ';
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
set @mensaje=@mensaje + 'No se realizó el alta';
RAISERROR (@mensaje,10,1);
end

end;


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


create trigger TEAM_CASTY.modif_clientes
ON TEAM_CASTY.vistaClientes
instead of update
AS
begin

declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error: ';

if(exists (select * from TEAM_CASTY.Cliente c,inserted ins where c.Mail=ins.Mail and ins.Codigo<>c.ID_Cliente))
begin
set @error=1
set @mensaje=@mensaje + 'Mail repetido. ';
end

if(exists (select * from TEAM_CASTY.Cliente c,inserted ins,TEAM_CASTY.Tipo_Documento tdoc where c.Nro_Documento=ins.[Numero Documento] and tdoc.Tipo_Documento=ins.[Tipo Documento] and c.ID_Tipo_Documento=tdoc.ID_Tipo_Documento and c.ID_Cliente<>ins.Codigo))
begin
set @error=1
set @mensaje=@mensaje + 'Documento repetido. ';
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
set @mensaje=@mensaje + 'No se realizó el alta';
RAISERROR (@mensaje,10,1);
end

end;

GO
-----------------------------------------------------------------------------------------------------------------------
insert into TEAM_CASTY.vistaClientes
(Nombre,Apellido,[Tipo Documento],[Numero Documento],Mail,Telefono,Pais,Localidad,Calle,[Numero Calle],Piso,Departamento,Nacionalidad,[Fecha Nacimiento])
VALUES('leder','casty','PASAPORTE',222,'maaadsdggsailcasty@cascsc',111,'casty','casty','casty',111,2,'SSS','casty',CONVERT(DATETIME,'1979-06-24',111));

delete TEAM_CASTY.vistaClientes
where Nombre='leder' and
Apellido='casty' AND
[Tipo Documento]='PASAPORTE' and
[Numero Documento]=222 and
Mail='maaadsdggsailcasty@cascsc'

update TEAM_CASTY.vistaClientes
set [Numero Documento]=99713572
where Codigo=100741

select * from team_casty.vistaClientes
select * from team_casty.Cliente c

-----------------------------------------------------------------------------------------------------------------------
