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


--PUNTO 11

CREATE TYPE TEAM_CASTY.t_tablaConsumibles AS TABLE(
	Cod_Habitacion numeric (18),
	Nombre nvarchar (50),
	Cantidad numeric (18));
	
GO

create procedure  TEAM_CASTY.RegistrarConsumibles
@cod_Estadia numeric(18),@tabla TEAM_CASTY.t_tablaConsumibles READONLY
AS
begin
declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error: ';

if(not exists (select * from TEAM_CASTY.Estadia e where e.Cod_Estadia=@cod_Estadia))
begin
	set @error=1;
	set @mensaje+=' No existe esa estadía.';
end

if (exists (select * from @tabla t where t.Nombre not in (select c.Descripcion from TEAM_CASTY.Consumible c)))
begin
	set @error=1;
	set @mensaje+=' Consumible inexistente.';
end
 
if(exists(select * from @tabla t where t.Cod_Habitacion not in (select hxe.Cod_Habitacion from TEAM_CASTY.HabitacionXEstadia hxe where hxe.Cod_Estadia=@cod_Estadia)))
begin
	set @error=1;
	set @mensaje+=' Habitación no correspondiente a estadía.';
end 
 
if(exists (select * from @tabla t where t.Cantidad<0))
begin
	set @error=1;
	set @mensaje+=' Cantidad incorrecta.';
end 
 
if (@error=0)	
begin
	insert into TEAM_CASTY.ConsumibleXHabitacionXEstadia
	(Cod_Estadia,Cod_Habitacion,Cod_Consumible,Precio,Cantidad)
	select @cod_Estadia,t.Cod_Habitacion,con.Cod_Consumible,con.Precio,t.Cantidad
	from TEAM_CASTY.Consumible con, @tabla t
	where t.Nombre=con.Descripcion;
end
else
begin
	set @mensaje=@mensaje + 'No se realizó el registro de consumibles.';
	RAISERROR (@mensaje,15,1);
end
end;


--PUNTO 12

create function TEAM_CASTY.PrecioPorDiaEspecifico
(@hotel numeric(18), @regimen numeric (18),@tipo_habitacion numeric (18))
RETURNS numeric(18,2)
AS
begin 

declare @adicional_hotel numeric (18,2);
declare @precio_regimen numeric (18,2);
declare @precio_tipo_habitacion numeric (18,2);

select @adicional_hotel=(hot.CantEstrella*(select top 1 rec.Recarga from TEAM_CASTY.Recarga_Estrella rec order by rec.Fecha_Modificacion desc))
from TEAM_CASTY.Hotel hot
where hot.Cod_Hotel=@hotel;

select @precio_regimen=reg.Precio
from TEAM_CASTY.Regimen reg
where reg.Cod_Regimen=@regimen;

select @precio_tipo_habitacion=thab.Porcentual
from TEAM_CASTY.Tipo_Habitacion thab
where thab.Cod_Tipo=@tipo_habitacion;

return @precio_tipo_habitacion*@precio_regimen+@adicional_hotel;
end;


create function TEAM_CASTY.MontoConsumibles
(@cod_estadia numeric(18))
RETURNS numeric(18,2)
AS
begin 
return (
select SUM(cxhxe.Precio*cxhxe.Cantidad)
from TEAM_CASTY.ConsumibleXHabitacionXEstadia cxhxe 
where cxhxe.Cod_Estadia=@cod_estadia);
end;

create function TEAM_CASTY.MontoHabitaciones
(@cod_estadia numeric(18))
RETURNS numeric(18,2)
AS
begin 
return (
select SUM(ihf.Monto_Completados+ihf.Monto_Faltantes)
from TEAM_CASTY.item_habitacionXFactura ihf, TEAM_CASTY.Factura f
where f.Cod_Estadia=@cod_estadia and ihf.Nro_Factura=f.Nro_Factura);
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
		
		declare @hotel numeric (18);
		select distinct @hotel=hab.Cod_Hotel
		from TEAM_CASTY.Estadia est,TEAM_CASTY.Habitacion hab, TEAM_CASTY.HabitacionXEstadia hxe
		where est.Cod_Estadia=@cod_Estadia and est.Cod_Estadia=hxe.Cod_Estadia and hxe.Cod_Habitacion=hab.Cod_Habitacion;
		
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
		(Cod_Habitacion,Cod_Regimen,Nro_Factura,Dias_Completados,Monto_Completados,Dias_Faltantes,Monto_Faltantes)
		select hab.Cod_Habitacion,res.Cod_Regimen,@nro_factura,@dias_completados,
		@dias_completados*TEAM_CASTY.PrecioPorDiaEspecifico(@hotel,res.Cod_Regimen,hab.Cod_Habitacion),
		(res.Cant_Noches-@dias_completados)*TEAM_CASTY.PrecioPorDiaEspecifico(@hotel,res.Cod_Regimen,hab.Cod_Habitacion)
		from TEAM_CASTY.Reserva res, TEAM_CASTY.Habitacion hab, TEAM_CASTY.HabitacionXEstadia hxe,
		TEAM_CASTY.Estadia est
		where @cod_Estadia=est.Cod_Estadia and res.Cod_Reserva=est.Cod_Reserva and
		est.Cod_Estadia=hxe.Cod_Estadia and hxe.Cod_Habitacion=hab.Cod_Habitacion;
		
		declare @monto_consumibles numeric(18,2);
		set @monto_consumibles=TEAM_CASTY.MontoConsumibles(@cod_Estadia);
		declare @monto_habitaciones numeric(18,2);
		set @monto_habitaciones=TEAM_CASTY.MontoHabitaciones(@cod_Estadia);
		declare @monto_total numeric(18,2);
		set @monto_total=@monto_habitaciones;
		if((select res.Cod_Regimen
		from TEAM_CASTY.Reserva res, TEAM_CASTY.Estadia est
		where est.Cod_Estadia=@cod_Estadia and res.Cod_Reserva=est.Cod_Reserva)<>1)
		begin
			set @monto_total+=@monto_consumibles;
		end
		
		update TEAM_CASTY.Factura
		set Total=@monto_total
		where Cod_Estadia=@cod_Estadia;
		
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



select * from TEAM_CASTY.Tarjeta
select * from TEAM_CASTY.TarjetaXFactura



create function TEAM_CASTY.MontoHabitaciones
(@cod_estadia numeric(18))
RETURNS numeric(18,2)
AS
begin 
return (
select SUM(ihf.Monto_Completados+ihf.Monto_Faltantes)
from TEAM_CASTY.item_habitacionXFactura ihf, TEAM_CASTY.Factura f
where f.Cod_Estadia=@cod_estadia and ihf.Nro_Factura=f.Nro_Factura);
end;

go

create procedure  TEAM_CASTY.RegistrarPagoTarjeta
@cod_Estadia numeric(18), @numero_tajeta numeric(18), @banco nvarchar(255)
AS
begin
declare @mensaje nvarchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error:';

declare @id_cliente numeric(18);
select @id_cliente=res.ID_Cliente_Reservador
from TEAM_CASTY.Estadia est, TEAM_CASTY.Reserva res
where est.Cod_Estadia=@cod_Estadia and est.Cod_Reserva=res.Cod_Reserva;

if (not exists(select * from TEAM_CASTY.Tarjeta tar where @numero_tajeta=tar.Numero and @banco=tar.Banco and @id_cliente=tar.ID_Cliente))
begin
	if (exists(select * from TEAM_CASTY.Tarjeta tar where @numero_tajeta=tar.Numero and @banco=tar.Banco))
	begin
		set @error=1;
		set @mensaje+=' La tarjeta no corresonde al cliente que realizó el pago.';
	end
	else
	begin
		insert into TEAM_CASTY.Tarjeta
		(ID_Cliente,Banco,Numero)
		values (@id_cliente,@banco,@numero_tajeta);
	end
end


if (@error=0)
begin
	declare @nro_factura numeric(18);
	select @nro_factura=f.Nro_Factura
	from TEAM_CASTY.Factura f
	where f.Cod_Estadia=@cod_Estadia;
	
	insert into TEAM_CASTY.TarjetaXFactura
	(Nro_Factura,Banco,Numero_Tarjeta)
	values (@nro_factura,@banco,@numero_tajeta);
end
else
begin
	set @mensaje=@mensaje + 'No se realizó el pago correctamente.';
	RAISERROR (@mensaje,15,1);
end
end;

GO

create function TEAM_CASTY.RegimenesDeUnHotel
(@cod_hotel numeric (18))
RETURNS TABLE
AS 
return (
select reg.Descripcion
from TEAM_CASTY.RegimenXHotel rxh, TEAM_CASTY.Regimen reg
where rxh.Cod_Hotel=@cod_hotel and rxh.Activo=1 and reg.Cod_Regimen=rxh.Cod_Regimen);

go

create function TEAM_CASTY.Regimenes
()
RETURNS TABLE
AS 
return (
select reg.Descripcion
from TEAM_CASTY.Regimen reg);

go