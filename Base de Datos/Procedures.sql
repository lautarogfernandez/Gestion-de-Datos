--Procedures
create procedure  TEAM_CASTY.Actualizar_Reservas
@fecha_actual datetime
AS
update TEAM_CASTY.Reserva
set TEAM_CASTY.Reserva.Cod_Estado=5
where TEAM_CASTY.Reserva.Fecha_Inicio<@fecha_actual AND
TEAM_CASTY.Reserva.Cod_Estado=1 AND	  
TEAM_CASTY.Reserva.Cod_Reserva not in (select f.Cod_Reserva from TEAM_CASTY.Factura f)
GO