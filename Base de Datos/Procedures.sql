--Procedures
create procedure  TEAM_CASTY.Actualizar_Reservas
@fecha_actual datetime
AS
update res
set res.Cod_Estado=5
from TEAM_CASTY.Reserva res
where res.Fecha_Reserva<@fecha_actual AND
res.Cod_Estado=1 AND	  
res.Cod_Reserva not in (select est.Cod_Reserva from TEAM_CASTY.Estadia est)
GO


create procedure  TEAM_CASTY.Disponibilidad_Reserva
@fecha_desde datetime,@fecha_hasta datetime,@tipo_habitacion numeric(18),@hotel numeric(18),@sePuede numeric(18) out
AS

set @sePuede=1;

if(@fecha_desde<@fecha_hasta)
begin

if (exists (
select *
from TEAM_CASTY.Habitacion hab,TEAM_CASTY.Hotel hot,TEAM_CASTY.Reserva
where hab.Baja=0 and
hab.Cod_Hotel=@hotel and
hab.Cod_Habitacion in 
(select distinct hxr.Cod_Habitacion 
from TEAM_CASTY.Reserva res, TEAM_CASTY.HabitacionXReserva hxr
where res.Cod_Reserva=hxr.Cod_Reserva and
(@fecha_desde>res.Fecha_Reserva+res.Cant_Noches or @fecha_hasta<res.Fecha_Reserva)
) and
hab.Cod_Tipo=@tipo_habitacion
))
begin
set @sePuede=0;
end

end


GO


create function  TEAM_CASTY.Precios_Por_Dia (@hotel numeric(18),@tipo_habitacion numeric(18),@regimen numeric(18))
RETURNS @tablaPorDia TABLE(
Descripcion nvarchar(255) not null,
[Precio Por Dia] numeric(18,2))
AS
begin
INSERT  into @tablaPorDia 
select thab.Descripcion, (reg.Precio*thab.Porcentual+(hot.CantEstrella*(select top 1 rec.Recarga from TEAM_CASTY.Recarga_Estrella rec order by rec.Fecha_Modificacion desc))) "Precio Por Dia" 
from TEAM_CASTY.Tipo_Habitacion thab,TEAM_CASTY.Hotel hot,TEAM_CASTY.Regimen reg
where hot.Cod_Hotel=@hotel and thab.Cod_Tipo=@tipo_habitacion and reg.Cod_Regimen=@regimen
RETURN 
end

select *
into #casty
from TEAM_CASTY.Precios_Por_Dia(1,1001,1)
drop table #casty

