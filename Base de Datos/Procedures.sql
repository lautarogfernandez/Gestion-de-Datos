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




--PUNTO 12

create function TEAM_CASTY.PrecioPorDiaEspecifico
(@hotel numeric(18), @regimen numeric (18),@tipo_habitacion numeric (18))
RETURNS @precio numeric (18,2)
AS
begin
INSERT  into @tablaPorDia 
select distinct reg.Descripcion, thab.Descripcion, (reg.Precio*thab.Porcentual+(hot.CantEstrella*(select top 1 rec.Recarga from TEAM_CASTY.Recarga_Estrella rec order by rec.Fecha_Modificacion desc))) [Precio Por Dia]
from TEAM_CASTY.Tipo_Habitacion thab,TEAM_CASTY.Hotel hot,TEAM_CASTY.Regimen reg, TEAM_CASTY.RegimenXHotel rxh
where hot.Cod_Hotel=@hotel and rxh.Cod_Hotel=@hotel and rxh.Activo=1
RETURN 
end;



create procedure  TEAM_CASTY.Facturar
@cod_Estadia numeric(18), @fecha datetime, @cod_forma_pago numeric(18)
AS
begin
declare @mensaje nvarchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error: ';


if (exists(select * from TEAM_CASTY.Estadia e where e.Cod_Estadia=@cod_Estadia))
begin
	if ((select e.Fecha_Salida from TEAM_CASTY.Estadia e) is null)
	begin
		set @error=1;
		set @mensaje+=' No se realizó el Check OUT aún.';
	end
	else
	begin
		if ((select e.Fecha_Salida from TEAM_CASTY.Estadia e where e.Cod_Estadia=@cod_Estadia)=@fecha)
		begin
			set @error=1;
			set @mensaje+=' Fecha incorrecta.';
		end
	end
end
else
	set @error=1; 
	set @mensaje+=' Estadía inexistente.';
end

if (not exists(select * from TEAM_CASTY.Forma_Pago fp where @cod_forma_pago=fp.Cod_Forma_Pago))
begin
	set @error=1; 
	set @mensaje+=' Forma de pago inexistente.';
end

if (@error=0)
begin
	begin try
		declare @nro_factura numeric (18);
		select @nro_factura=max(f.Nro_Factura)+1 from TEAM_CASTY.Factura f;
		insert into TEAM_CASTY.Factura
		(Cod_Estadia,Cod_Forma_Pago,Fecha,Nro_Factura,Total)
		values (@cod_Estadia,@cod_forma_pago,@fecha,@nro_factura,0);
		insert into TEAM_CASTY.item_ConsumibleXFactura
		select @nro_factura, cxhxe.Cod_ConsumibleXHabitacionXEstadia
		from TEAM_CASTY.ConsumibleXHabitacionXEstadia cxhxe
		where cxhxe.Cod_Estadia=@cod_Estadia;
		declare @dias_completados numeric (18);
		select @dias_completados=DATEDIFF(day,est.Fecha_Inicio,est.Fecha_Salida)
		from TEAM_CASTY.Estadia est
		where @cod_Estadia=est.Cod_Estadia;
		declare @dias_faltantes numeric (18);
		select @dias_faltantes=res.Cant_Noches-@dias_completados
		from TEAM_CASTY.Reserva res, TEAM_CASTY.Estadia est
		where @cod_Estadia=est.Cod_Estadia and est.Cod_Reserva=res.Cod_Reserva;
		insert into TEAM_CASTY.item_habitacionXFactura
		(Cod_Habitacion,Cod_Regimen,Nro_Factura,Monto_Completados,Monto_Completados,Dias_Faltantes,Monto_Faltantes)
		select hab.Cod_Habitacion,res.Cod_Regimen,@nro_factura,,,res.Cant_Noches-datediff(day,est.Fecha_Inicio,est.Fecha_Salida),,
		from TEAM_CASTY.Reserva res, TEAM_CASTY.Habitacion hab, TEAM_CASTY.HabitacionXEstadia hxe, TEAM_CASTY.Estadia est
		where @cod_Estadia=est.Cod_Estadia and res.Cod_Reserva=est.Cod_Reserva and est.Cod_Estadia=hxe.Cod_Estadia and
		hxe.Cod_Habitacion=hab.Cod_Habitacion
	end try
	begin catch
		set @mensaje=@mensaje + 'No se realizó la factura.';
		RAISERROR (@mensaje,15,1);
	end catch
end
else
begin
	set @mensaje=@mensaje + 'No se realizó la factura.';
	RAISERROR (@mensaje,15,1);
end
end;

GO