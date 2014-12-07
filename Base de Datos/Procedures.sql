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
begin
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
end;

GO

--probar
--PUNTO 9
create procedure  TEAM_CASTY.Cancelar_Reserva
@Cod_Reserva numeric(18),@fecha datetime,@motivo varchar(255), @usuario numeric(18)
AS
declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error:';

if(not exists (select * from TEAM_CASTY.Reserva r where @Cod_Reserva=r.Cod_Reserva))
begin
	set @error=1;
	set @mensaje=@mensaje + ' No existe la Reserva.';
end;
if(not exists (select * from TEAM_CASTY.Reserva r where @Cod_Reserva=r.Cod_Reserva and datediff(day,r.Fecha_Reserva,@fecha)>0))
begin
	set @error=1;
	set @mensaje=@mensaje + ' Fecha inválida.';
end;
if(not exists(select distinct h.Cod_Hotel
from TEAM_CASTY.Hotel h, TEAM_CASTY.Reserva r,TEAM_CASTY.Habitacion hab, TEAM_CASTY.HabitacionXReserva hxr
where h.Cod_Hotel=hab.Cod_Hotel and
r.Cod_Reserva=@Cod_Reserva and
hxr.Cod_Reserva=@Cod_Reserva and		
hxr.Cod_Habitacion=hab.Cod_Habitacion and
h.Cod_Hotel in(select rxuxh.Cod_Hotel from TEAM_CASTY.RolXUsuarioXHotel rxuxh where @usuario=rxuxh.Cod_Usuario)))
begin
	set @error=1;
	set @mensaje=@mensaje + ' El usuario no puede operar sobre ese hotel.';
end	;
if (@error=0)	
begin
	declare @estado numeric(18);
	if(@usuario=3)
	begin
		set @estado=4 
	end
	else
	begin
		set @estado=5
	end
	insert into TEAM_CASTY.Cancelacion (Cod_Reserva,Cod_Usuario,Fecha,Motivo)
	values (@Cod_Reserva,@usuario,@fecha,@motivo);
	update TEAM_CASTY.Reserva 
	set Cod_Estado=@estado
	where @Cod_Reserva=Cod_Reserva;	
	declare @num numeric (18);
	declare @cod_user numeric (18);
	select @num=MAX(mxr.Numero_Modificacion) from TEAM_CASTY.ModificacionXReserva mxr where mxr.Cod_Reserva=@Cod_Reserva;
	select @num=u.Cod_Usuario from TEAM_CASTY.Usuario u where u.Username=@usuario
	insert into TEAM_CASTY.ModificacionXReserva
	(Cod_Reserva,Cod_Usuario,Descripcion,Fecha,Numero_Modificacion)
	values (@Cod_Reserva,@cod_user,@fecha,@num,@motivo);
end
else	
begin
	set @mensaje=@mensaje + 'No se realizó cancelación.';
	RAISERROR (@mensaje,15,1);
end

--probar
--PUNTO 10
--check in
create procedure  TEAM_CASTY.Check_IN
@Cod_Reserva numeric(18),@fecha datetime, @usuario numeric(18),@hotel numeric(18)
AS
begin
declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error: ';

if(not exists (select * from TEAM_CASTY.Reserva r where @Cod_Reserva=r.Cod_Reserva))
begin
	set @error=1;
	set @mensaje=@mensaje + 'No existe la Reserva';
end;

if (exists (select * from TEAM_CASTY.Reserva r where @Cod_Reserva=r.Cod_Reserva and datediff(day,r.Fecha_Reserva,@fecha)>0))
begin
		set @error=1;
		set @mensaje=@mensaje + 'Fecha inválida: es en el futuro';
end;

if (exists (select * from TEAM_CASTY.Reserva r where @Cod_Reserva=r.Cod_Reserva and datediff(day,r.Fecha_Reserva,@fecha)<0))
begin
		set @error=1;
		set @mensaje=@mensaje + 'Fecha inválida: no se presentó cuando debía';
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
u.Cod_Usuario=@usuario and
u.Cod_Usuario=uxrxh.Cod_Usuario))
begin		
	set @error=1;
	set @mensaje=@mensaje + 'El usuario no puede operar sobre ese hotel';
end;


	
if (@error=0)	
begin
	insert into TEAM_CASTY.Estadia (Cod_Reserva,Fecha_Inicio)
	values(@Cod_Reserva,@fecha);
	update TEAM_CASTY.Reserva
	set Cod_Estado=6
	where @Cod_Reserva=Cod_Reserva;
end
else
begin
	set @mensaje=@mensaje + 'No se realizó el Check IN.';
	RAISERROR (@mensaje,15,1);
end
end;

--check out
create procedure  TEAM_CASTY.Check_OUT
@Cod_Reserva numeric(18),@fecha datetime, @usuario numeric(18),@hotel numeric(18)
AS
begin
declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error: ';

if(not exists (select * from TEAM_CASTY.Reserva r where @Cod_Reserva=r.Cod_Reserva))
begin
	set @error=1;
	set @mensaje=@mensaje + 'No existe la Reserva';
end;

if(not exists (select * from TEAM_CASTY.Estadia r where @Cod_Reserva=r.Cod_Reserva and))
begin
	set @error=1;
	set @mensaje=@mensaje + 'No se realizó el Check IN previamente';
end;

if (exists (select * from TEAM_CASTY.Estadia e where @Cod_Reserva=e.Cod_Reserva and datediff(day,e.Fecha_Inicio,@fecha)<0))
begin
	set @error=1;
	set @mensaje=@mensaje + 'No concuerdan las fechas';
end;

if(not exists(select *
from TEAM_CASTY.Habitacion hab, TEAM_CASTY.HabitacionXReserva hxr,TEAM_CASTY.Hotel h, TEAM_CASTY.Usuario u, TEAM_CASTY.RolXUsuarioXHotel uxrxh
where hab.Cod_Hotel=h.Cod_Hotel and
h.Cod_Hotel=@hotel and
hxr.Cod_Habitacion=hab.Cod_Habitacion and
hxr.Cod_Reserva=@Cod_Reserva and
u.Cod_Usuario=@usuario and
u.Cod_Usuario=uxrxh.Cod_Usuario))
begin		
	set @error=1;
	set @mensaje=@mensaje + 'El usuario no puede operar sobre ese hotel';
end;

if (@error=0)	
begin
	update TEAM_CASTY.Estadia
	set Fecha_Salida=@fecha
	where @Cod_Reserva=Cod_Reserva;
end
else
begin
	set @mensaje=@mensaje + 'No se realizó el Check OUT.';
	RAISERROR (@mensaje,15,1);
end
end;