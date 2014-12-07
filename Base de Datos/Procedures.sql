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

create procedure  TEAM_CASTY.Alta_Rol
@nombre varchar(250), @funciones TEAM_CASTY.t_funcion READONLY
AS

declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error: ';

if (not exists(select *
		   from @funciones f
	       where f.funcion in (select f.Descripcion from TEAM_CASTY.Funcion f)))
begin
set @error=1;
set @mensaje=@mensaje + 'Función inexistente. ';
end

if (exists(select *
		   from TEAM_CASTY.Rol r
		   where @nombre=r.Nombre))
begin
set @error=1;
set @mensaje=@mensaje + 'Rol existente. ';
end

if (@error=0) 
begin
 
insert into TEAM_CASTY.Rol
(Activo,Nombre)
values (1,@nombre);

insert into TEAM_CASTY.FuncionXRol
select r.Cod_Rol,fun.Cod_Funcion
from @funciones f join TEAM_CASTY.Funcion fun on (f.funcion = fun.Descripcion)
				  join TEAM_CASTY.Rol r on (r.Nombre=@nombre)

end

else
begin
set @mensaje=@mensaje + 'No se realizó la modificación';
RAISERROR (@mensaje,10,1);
end

go




declare @tablaParaProbar TEAM_CASTY.t_funcion;
insert into @tablaParaProbar
select f.Descripcion
from TEAM_CASTY.Funcion f;
exec TEAM_CASTY.Alta_Rol @nombre='ELPIBE', @funciones=@tablaParaProbar;

select * from TEAM_CASTY.Rol
select * from TEAM_CASTY.FuncionXRol



--probar
--PUNTO 9
create procedure  TEAM_CASTY.Cancelar_Reserva
@Cod_Reserva numeric(18),@fecha datetime,@motivo varchar(255), @usuario numeric(18)
AS
declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error: ';

if(not exists (select * from TEAM_CASTY.Reserva r where @Cod_Reserva=r.Cod_Reserva))
begin
	set @error=1;
	set @mensaje=@mensaje + 'No existe la Reserva.';
end;
if(not exists (select * from TEAM_CASTY.Reserva r where @Cod_Reserva=r.Cod_Reserva and datediff(day,r.Fecha_Reserva,@fecha)>0))
begin
	set @error=1;
	set @mensaje=@mensaje + 'Fecha inválida.';
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
	set @mensaje=@mensaje + 'El usuario no puede operar sobre ese hotel.';
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
	insert into TEAM_CASTY
end
else	
begin
	set @mensaje=@mensaje + 'No se realizó cancelación.';
	RAISERROR (@mensaje,10,1);
end


--probar
--PUNTO 10
--check in
create procedure  TEAM_CASTY.Check_IN
@Cod_Reserva numeric(18),@fecha datetime, @usuario numeric(18),@hotel numeric(18)
AS
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
	RAISERROR (@mensaje,10,1);
end




--check out
create procedure  TEAM_CASTY.Check_OUT
@Cod_Reserva numeric(18),@fecha datetime, @usuario numeric(18),@hotel numeric(18)
AS
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
	RAISERROR (@mensaje,10,1);
end;





--Punto 1

create procedure  TEAM_CASTY.
@Cod_Reserva numeric(18),@fecha datetime, @usuario numeric(18),@hotel numeric(18)
AS
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
	RAISERROR (@mensaje,10,1);
end;


select * from TEAM_CASTY.Usuario