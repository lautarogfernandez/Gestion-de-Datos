--Vistas
create view TEAM_CASTY.vistaClientes
AS
select c.Nombre, c.Apellido, c.Mail, d.Tipo_Documento AS 'Tipo Documento', c.Nro_Documento AS 'Numero Documento', c.Telefono, c.Pais, c.Localidad, c.Nom_Calle AS 'Calle', c.Nro_Calle AS 'Numero Calle', c.Piso ,c.Dto AS 'Departamento',c.Nacionalidad, c.Fecha_Nacimiento AS 'Fecha Nacimiento'
from TEAM_CASTY.Cliente c, TEAM_CASTY.Tipo_Documento d
where c.Baja=0
order by 4,5