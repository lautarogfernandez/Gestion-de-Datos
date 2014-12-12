--Procedures

--PUNTO 8
create procedure  TEAM_CASTY.Actualizar_Reservas
@fecha_actual datetime
AS
begin
update res
set res.Cod_Estado=5
from TEAM_CASTY.Reserva res
where datediff(day,res.Fecha_Reserva,@fecha_actual)>0 AND
res.Cod_Estado=1 AND	  
res.Cod_Reserva not in (select est.Cod_Reserva from TEAM_CASTY.Estadia est)
end;

GO


create function  TEAM_CASTY.Disponibilidad_Reserva1--anda OK
(@fecha_desde datetime,@fecha_hasta datetime,@tipo_habitacion nvarchar(255),@hotel numeric(18))
returns numeric (18)
AS
begin

declare @sePuede numeric(18)=0;
declare @cod_tipo_habitacion numeric(18);
select @cod_tipo_habitacion=th.Cod_Tipo
from TEAM_CASTY.Tipo_Habitacion th
where @tipo_habitacion=th.Descripcion;

if(datediff(day,@fecha_desde,@fecha_hasta)>0)
begin
	if(not exists(
	select *
	from TEAM_CASTY.Periodo_Inhabilitado pein
	where pein.Cod_Hotel=@hotel and
	TEAM_CASTY.periodoOK(pein.Fecha_Inicio,pein.Fecha_Fin,@fecha_desde,@fecha_hasta)=0))
	begin
		if (exists (
		select * 
		from TEAM_CASTY.Habitacion hab
		where hab.Cod_Tipo=@cod_tipo_habitacion and hab.Cod_Hotel=@hotel and hab.Baja=0 and hab.Cod_Habitacion not in		
		(select distinct hxr.Cod_Habitacion 
		from TEAM_CASTY.Reserva res, TEAM_CASTY.HabitacionXReserva hxr
		where res.Cod_Reserva=hxr.Cod_Reserva and
		TEAM_CASTY.periodoOK(@fecha_desde,@fecha_hasta,res.Fecha_Reserva,res.Fecha_Reserva+res.Cant_Noches)=0 and
		hab.Cod_Tipo=@cod_tipo_habitacion)))
		begin
			set @sePuede=1;
		end
	end
end
RETURN @sePuede;
end;

GO



create type TEAM_CASTY.t_reserva AS TABLE(
Tipo_habitacion nvarchar(255),
Cantidad numeric(18));

GO

create function  TEAM_CASTY.estaReservada--NO esta reservada=1
(@fecha_desde datetime,@fecha_hasta datetime,@cod_hab numeric(18))
returns numeric(18)
AS
begin
	declare @si numeric(18)=1;
	if (exists(
	select *
	from TEAM_CASTY.Reserva res, TEAM_CASTY.HabitacionXReserva hxr
	where hxr.Cod_Habitacion=@cod_hab and res.Cod_Reserva=hxr.Cod_Reserva and
	TEAM_CASTY.periodoOK(@fecha_desde,@fecha_hasta,res.Fecha_Reserva,res.Fecha_Reserva+res.Cant_Noches)=0
	))
	begin
		set @si=0;
	end
	return @si;
end;

GO

create function TEAM_CASTY.Cant_Hab_Disponibles
(@fecha_desde datetime,@fecha_hasta datetime,@hotel numeric(18),@cod_tipo_hab numeric(18))
returns numeric(18)
AS
begin
	return(
	select COUNT(distinct hab.Cod_Habitacion)
	from TEAM_CASTY.Habitacion hab
	where hab.Cod_Hotel=@hotel and hab.Baja=0 and hab.Cod_Tipo=@cod_tipo_hab and 
	TEAM_CASTY.estaReservada(@fecha_desde,@fecha_hasta,hab.Cod_Habitacion)=1)
end;

GO

create function  TEAM_CASTY.Disponibilidad_Reserva--OK=1; NO=0;
(@fecha_desde datetime,@fecha_hasta datetime,@hotel numeric(18),@tabla TEAM_CASTY.t_reserva readonly)
returns numeric(18)
AS
begin

declare @sePuede numeric(18)=1;

if(datediff(day,@fecha_desde,@fecha_hasta)>0)
begin
	if(not exists(
	select *
	from TEAM_CASTY.Periodo_Inhabilitado pein
	where pein.Cod_Hotel=@hotel and
	TEAM_CASTY.periodoOK(pein.Fecha_Inicio,pein.Fecha_Fin,@fecha_desde,@fecha_hasta)=0))
	begin
		DECLARE _cursor CURSOR FOR
		select * from @tabla;
		OPEN _cursor;
		DECLARE @t_hab nvarchar(255), @cant numeric(18),@cod_t_hab numeric(18),@seguir  numeric(18)=1;
		FETCH NEXT FROM _cursor INTO @t_hab, @cant;
		WHILE (@@FETCH_STATUS = 0 and @seguir=1)
		BEGIN
			select @cod_t_hab=th.Cod_Tipo
			from TEAM_CASTY.Tipo_Habitacion th
			where th.Descripcion=@t_hab;
			
			if(TEAM_CASTY.Cant_Hab_Disponibles(@fecha_desde,@fecha_hasta,@hotel,@cod_t_hab)<@cant)
			begin
				set @seguir=0;
				set @sePuede=0;
			end;
			
			FETCH NEXT FROM _cursor INTO @t_hab, @cant;					
		END;		
		CLOSE _cursor;
		DEALLOCATE _cursor;	
	end
	else
	begin
		set @sePuede=0;
	end
end
else
begin
	set @sePuede=0;
end
RETURN @sePuede;
end;

GO

create function  TEAM_CASTY.Ultimo_Codigo_Reserva
()
returns numeric(18)
as
begin
	return (select MAX(r.Cod_Reserva) from TEAM_CASTY.Reserva r)
end;

GO

create function  TEAM_CASTY.Obtener_Habitacion
(@fecha_desde datetime,@fecha_hasta datetime,@hotel numeric(18),@cod_tipo_hab numeric(18))
returns numeric(18)
as
begin
	return(	
	select TOP 1 hab.Cod_Habitacion
	from TEAM_CASTY.Habitacion hab
	where hab.Cod_Hotel=@hotel and hab.Baja=0 and hab.Cod_Tipo=@cod_tipo_hab and 
	TEAM_CASTY.estaReservada(@fecha_desde,@fecha_hasta,hab.Cod_Habitacion)=1)
end;

GO

----------------------------------------------------------------------------------------------------

create procedure  TEAM_CASTY.Reservar
(@usuario nvarchar(255),@fecha_realizacion datetime,@fecha_reserva datetime,@cant_noches numeric(18),@id_cliente numeric(18),
@regimen nvarchar(255),@hotel numeric(18),@tabla TEAM_CASTY.t_reserva readonly)
as
begin
	declare @cod_t_reg numeric(18);
	select @cod_t_reg=r.Cod_Regimen
	from TEAM_CASTY.Regimen r
	where r.Descripcion=@regimen;
	
	declare @cod_usuario numeric(18);
	select @cod_usuario=u.Cod_Usuario
	from TEAM_CASTY.Usuario u
	where @usuario=u.Username;
	
	declare @cod_reserva numeric(18)=TEAM_CASTY.Ultimo_Codigo_Reserva()+1;
	
	insert into TEAM_CASTY.Reserva
	(Cant_Noches,Cod_Estado,Cod_Regimen,Cod_Reserva,Fecha_Realizacion,Fecha_Reserva,ID_Cliente_Reservador)
	values (@cant_noches,1,@cod_t_reg,@cod_reserva,@fecha_realizacion,@fecha_reserva,@id_cliente);
	
	insert into TEAM_CASTY.ModificacionXReserva
	(Cod_Reserva,Cod_Usuario,Descripcion,Fecha,Numero_Modificacion)
	values (@cod_reserva,@cod_usuario,'Creación',@fecha_realizacion,1);
	
	exec TEAM_CASTY.Reservar_Habitaciones @cod_reserva,@fecha_reserva,@cant_noches,@hotel,@tabla;
	
end;


create procedure  TEAM_CASTY.Reservar_Habitaciones
(@cod_reserva numeric(18),@fecha_reserva datetime,@cant_noches numeric(18),
@hotel numeric(18),@tabla TEAM_CASTY.t_reserva readonly)
as
begin
	declare @i int;
	
	DECLARE _cursor CURSOR FOR
	select * from @tabla;
	OPEN _cursor;
	DECLARE @t_hab nvarchar(255), @cant numeric(18),@cod_t_hab numeric(18);
	FETCH NEXT FROM _cursor INTO @t_hab, @cant;
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		select @cod_t_hab=th.Cod_Tipo
		from TEAM_CASTY.Tipo_Habitacion th
		where th.Descripcion=@t_hab;
		
		set @i=0;
		while (@i<@cant)
		begin
			insert into TEAM_CASTY.HabitacionXReserva (Cod_Reserva,Cod_Habitacion)
			values (@cod_reserva,TEAM_CASTY.Obtener_Habitacion(@fecha_reserva,@fecha_reserva+@cant_noches,@hotel,@cod_t_hab));
			set @i=@i+1;
		end
		
		FETCH NEXT FROM _cursor INTO @t_hab, @cant;					
	END;		
	CLOSE _cursor;
	DEALLOCATE _cursor;			
end;



--create procedure  TEAM_CASTY.Realizar_Reserva
--(@usuario nvarchar(255),@fecha_realizacion datetime,@fecha_reserva datetime,@cant_noches numeric(18),@id_cliente numeric(18),
--@regimen nvarchar(255),@hotel numeric(18),@tabla TEAM_CASTY.t_reserva readonly)
--as
--begin
--	declare @cod_t_reg numeric(18);
--	select @cod_t_reg=r.Cod_Regimen
--	from TEAM_CASTY.Regimen r
--	where r.Descripcion=@regimen;
	
--	declare @cod_usuario numeric(18);
--	select @cod_usuario=u.Cod_Usuario
--	from TEAM_CASTY.Usuario u
--	where @usuario=u.Username;
	
--	declare @cod_reserva numeric(18)=TEAM_CASTY.Ultimo_Codigo_Reserva()+1;
	
--	insert into TEAM_CASTY.Reserva
--	(Cant_Noches,Cod_Estado,Cod_Regimen,Cod_Reserva,Fecha_Realizacion,Fecha_Reserva,ID_Cliente_Reservador)
--	values (@cant_noches,1,@cod_t_reg,@cod_reserva,@fecha_realizacion,@fecha_reserva,@id_cliente);
	
--	insert into TEAM_CASTY.ModificacionXReserva
--	(Cod_Reserva,Cod_Usuario,Descripcion,Fecha,Numero_Modificacion)
--	values (@cod_reserva,@cod_usuario,'Creación',@fecha_realizacion,1);
	
--	declare @i int;
	
--	DECLARE _cursor CURSOR FOR
--		select * from @tabla;
--		OPEN _cursor;
--		DECLARE @t_hab nvarchar(255), @cant numeric(18),@cod_t_hab numeric(18);
--		FETCH NEXT FROM _cursor INTO @t_hab, @cant;
--		WHILE (@@FETCH_STATUS = 0)
--		BEGIN
--			select @cod_t_hab=th.Cod_Tipo
--			from TEAM_CASTY.Tipo_Habitacion th
--			where th.Descripcion=@t_hab;
			
--			set @i=0;
--			while (@i<@cant)
--			begin
--				insert into TEAM_CASTY.HabitacionXReserva (Cod_Reserva,Cod_Habitacion)
--				values (@cod_reserva,TEAM_CASTY.Obtener_Habitacion(@fecha_reserva,@fecha_reserva+@cant_noches,@hotel,@cod_t_hab));
--				set @i=@i+1;
--			end
			
--			FETCH NEXT FROM _cursor INTO @t_hab, @cant;					
--		END;		
--	CLOSE _cursor;
--	DEALLOCATE _cursor;		
--end;

--GO


create procedure  TEAM_CASTY.Modificar_Reserva
(@usuario nvarchar(255),@cod_reserva numeric(18),@fecha_realizacion datetime,@fecha_reserva datetime,@cant_noches numeric(18),
@id_cliente numeric(18),@regimen nvarchar(255),@hotel numeric(18),@tabla TEAM_CASTY.t_reserva readonly)
as
begin	
	declare @mensaje varchar(1000);
	declare @error int;
	set @error=0;
	set @mensaje='Error:';
	
	begin transaction
	
		delete TEAM_CASTY.HabitacionXReserva
		where Cod_Reserva=@cod_reserva;
	
		if(TEAM_CASTY.Disponibilidad_Reserva(@fecha_reserva,@fecha_reserva+@cant_noches,@hotel,@tabla)=0)
		begin
			set @error=1;
			set @mensaje+=' No hay disponibilidad.';
		end
	
	if(@error=0)		
	begin
		exec TEAM_CASTY.Reservar_Habitaciones @cod_reserva,@fecha_reserva,@cant_noches,@hotel,@tabla;
		declare @cod_usuario numeric(18);
		select @cod_usuario=u.Cod_Usuario from TEAM_CASTY.Usuario u where u.Username=@usuario;
		declare @num numeric(18);
		select @num=(1+max(mxr.Numero_Modificacion)) from TEAM_CASTY.ModificacionXReserva mxr;
		insert into TEAM_CASTY.ModificacionXReserva
		(Cod_Reserva,Cod_Usuario,Descripcion,Fecha,Numero_Modificacion)
		values (@cod_reserva,@cod_usuario,'Modificación',@fecha_realizacion,@num);
		commit transaction	
	end
	else
	begin
		rollback transaction	
		set @mensaje+=' No se realizó la modifición.';
		RAISERROR(@mensaje,15,1);
	end
end;

GO





select * from TEAM_CASTY.Regimen;
select * from TEAM_CASTY.Reserva r order by r.Cod_Reserva desc;
select * from TEAM_CASTY.Tipo_Habitacion;
select * from TEAM_CASTY.Habitacion hab where hab.Cod_Hotel=1 and hab.Cod_Tipo=1005;
select * from TEAM_CASTY.Habitacion hab where hab.Cod_Hotel=1 and hab.Cod_Tipo=1003;
select * from TEAM_CASTY.Habitacion hab where hab.Cod_Habitacion in (2,15);
select * from TEAM_CASTY.HabitacionXReserva hxr where hxr.Cod_Reserva=110747;
select * from TEAM_CASTY.Usuario;
select * from TEAM_CASTY.ModificacionXReserva mxr where mxr.Cod_Reserva=110747;
select * from TEAM_CASTY.Reserva mxr where mxr.Cod_Reserva=110747;


declare @tab TEAM_CASTY.t_reserva;
insert into @tab (Tipo_habitacion,Cantidad) values ('Base Simple',2);
insert into @tab (Tipo_habitacion,Cantidad) values ('King',2);
insert into @tab (Tipo_habitacion,Cantidad) values ('Base Triple',5);
declare @f1 datetime=convert(datetime,'2043-04-09',111);
declare @f2 datetime=@f1-1;
select TEAM_CASTY.Obtener_Habitacion(@f1,@f1+5,1,1005);
exec  TEAM_CASTY.Realizar_Reserva 'admin',@f2,@f1,5,111,'All Inclusive moderado',1,@tab;


declare @f1 datetime=convert(datetime,'2043-04-09',111);
declare @f2 datetime=@f1-1;
declare @tab TEAM_CASTY.t_reserva;
insert into @tab (Tipo_habitacion,Cantidad) values ('Base Simple',1);
insert into @tab (Tipo_habitacion,Cantidad) values ('King',2);
insert into @tab (Tipo_habitacion,Cantidad) values ('Base Triple',5);
exec  TEAM_CASTY.Modificar_Reserva 'admin',110747,@f2,@f1,5,111,'Pension Completa',1,@tab;

declare @f1 datetime=convert(datetime,'2043-04-08',111);
exec TEAM_CASTY.Cancelar_Reserva 110747,@f1,'Porque siiiiiiiiiii','admin';

select * from TEAM_CASTY.Cancelacion


--probar
--PUNTO 9
create procedure  TEAM_CASTY.Cancelar_Reserva
@cod_Reserva numeric(18),@fecha datetime,@motivo varchar(255), @usuario nvarchar(255)
AS
declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error:';

if (not exists (select * from TEAM_CASTY.Usuario u where u.Username=@usuario))
begin
	set @error=1;
	set @mensaje=' No existe ese usuario.';
end

else
begin
	declare @cod_user numeric(18);
	select @cod_user=u.Cod_Usuario from TEAM_CASTY.Usuario u where u.Username=@usuario;
	if(not exists (select * from TEAM_CASTY.Reserva r where @Cod_Reserva=r.Cod_Reserva))
	begin
		set @error=1;
		set @mensaje=@mensaje + ' No existe la Reserva.';
	end;
	if(exists (select * from TEAM_CASTY.Reserva r where @Cod_Reserva=r.Cod_Reserva and datediff(day,r.Fecha_Reserva,@fecha)>0))
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
	h.Cod_Hotel in(select rxuxh.Cod_Hotel from TEAM_CASTY.RolXUsuarioXHotel rxuxh where @cod_user=rxuxh.Cod_Usuario)))
	begin
		set @error=1;
		set @mensaje=@mensaje + ' El usuario no puede operar sobre ese hotel.';
	end	;
	if(exists (select * from TEAM_CASTY.Cancelacion c where @Cod_Reserva=c.Cod_Reserva))
	begin
		set @error=1;
		set @mensaje=@mensaje + ' La reserva ya fue cancelada.';
	end;	

end;
if (@error=0)	
begin
	declare @estado numeric(18);
	if(@cod_user=3)
	begin
		set @estado=4 
	end
	else
	begin
		set @estado=5
	end
	insert into TEAM_CASTY.Cancelacion (Cod_Reserva,Cod_Usuario,Fecha,Motivo)
	values (@Cod_Reserva,@cod_user,@fecha,@motivo);
	update TEAM_CASTY.Reserva 
	set Cod_Estado=@estado
	where @Cod_Reserva=Cod_Reserva;	
	declare @num numeric (18);
	select @num=(1+MAX(mxr.Numero_Modificacion)) from TEAM_CASTY.ModificacionXReserva mxr where mxr.Cod_Reserva=@Cod_Reserva;	
	insert into TEAM_CASTY.ModificacionXReserva
	(Cod_Reserva,Cod_Usuario,Descripcion,Fecha,Numero_Modificacion)
	values (@Cod_Reserva,@cod_user,@motivo,@fecha,@num);
end
else	
begin
	set @mensaje=@mensaje + ' No se realizó cancelación.';
	RAISERROR (@mensaje,15,1);
end

GO


declare @f1 datetime=convert(datetime,'2046-05-22',111);
declare @f2 datetime=@f1-1;
declare @tab TEAM_CASTY.t_reserva;
insert into @tab (Tipo_habitacion,Cantidad) values ('Base Simple',1);
insert into @tab (Tipo_habitacion,Cantidad) values ('King',2);
exec  TEAM_CASTY.Reservar 'guest',@f2,@f1,5,111,'Pension Completa',1,@tab;

select * from TEAM_CASTY.Reserva r order by r.Cod_Reserva desc
select * from TEAM_CASTY.Reserva r  where r.Cod_Reserva=110741;

declare @f1 datetime=convert(datetime,'2046-05-22',111);
exec TEAM_CASTY.Check_IN 110748,@f1,'admin',1;

select * from TEAM_CASTY.Estadia e order by e.Cod_Estadia desc;
select * from TEAM_CASTY.HabitacionXEstadia hxe order by hxe.Cod_Estadia desc;
select * from TEAM_CASTY.HabitacionXEstadia hxe where hxe.Cod_Estadia=89604;

--probar
--PUNTO 10
--check in

-------------------------------------------------------------------------------------------------------------------

--CREATE FUNCTION TEAM_CASTY.HotelesPorUsario
--(@usuario nvarchar(255))
--RETURNS TABLE
--AS
--RETURN 
--   select vistaClientes.*
--   from TEAM_CASTY.RolXUsuarioXHotel RxUxH,TEAM_CASTY.Usuario u, TEAM_CASTY.vistaHoteles h
--   where @usuario=u.Username and
--   RxUxH.Cod_Usuario = u.Cod_Usuario and
--   RxUxH.Cod_Hotel=h.Codigo;

create function  TEAM_CASTY.Reservas_Para_Check_IN
(@fecha datetime, @hotel numeric(18))
returns table
AS
	return(
	select distinct res.Cod_Reserva
	from TEAM_CASTY.Reserva res,TEAM_CASTY.Habitacion hab, TEAM_CASTY.HabitacionXReserva hxr
	where res.Cod_Reserva=hxr.Cod_Reserva and hxr.Cod_Habitacion=hab.Cod_Habitacion and hab.Cod_Hotel=@hotel and
	datediff(day,res.Fecha_Reserva,@fecha)=0);

GO

create function  TEAM_CASTY.Estadias_Para_Check_OUT
(@hotel numeric(18))
returns table
AS
	return(
	select distinct est.Cod_Estadia,c.Nombre,c.Apellido,td.Tipo_Documento,c.Nro_Documento,c.Telefono,c.Mail
	from TEAM_CASTY.Estadia est,TEAM_CASTY.HabitacionXEstadia hxe, TEAM_CASTY.Habitacion hab,TEAM_CASTY.Cliente c,
	TEAM_CASTY.Reserva res,TEAM_CASTY.Tipo_Documento td
	where est.Fecha_Salida is null and est.Fecha_Inicio is not null and hab.Cod_Habitacion=hxe.Cod_Habitacion and
	est.Cod_Estadia=hxe.Cod_Estadia and hab.Cod_Hotel=@hotel and res.Cod_Reserva=est.Cod_Reserva and
	res.ID_Cliente_Reservador=c.ID_Cliente and td.ID_Tipo_Documento=c.ID_Tipo_Documento);

GO

create function  TEAM_CASTY.Utimo_Codigo_Estadia
()
returns numeric(18)
AS
begin
	return(select MAX(e.Cod_Estadia) from TEAM_CASTY.Estadia e);
end;

GO

create procedure  TEAM_CASTY.Agregar_Clientes_A_Estadia
(@Cod_Reserva numeric(18),@tabla TEAM_CASTY.t_agregar_clientes readonly)
AS
begin
	declare @cod_est numeric(18);
	select @cod_est=est.Cod_Estadia from TEAM_CASTY.Estadia est where est.Cod_Reserva=@Cod_Reserva;
	
	insert into TEAM_CASTY.ClienteXEstadia
	(Cod_Estadia,ID_Cliente)
	select @cod_est,t.cod_cliente
	from @tabla t;	
end;

GO

create procedure  TEAM_CASTY.Check_IN
@Cod_Reserva numeric(18),@fecha datetime, @usuario nvarchar(255),@hotel numeric(18)
AS
begin
declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error:';
declare @cod_user numeric(18);
select @cod_user=u.Cod_Usuario from TEAM_CASTY.Usuario u where u.Username=@usuario;

if(not exists (select * from TEAM_CASTY.Reserva r where @Cod_Reserva=r.Cod_Reserva))
begin
	set @error=1;
	set @mensaje=@mensaje + ' No existe la Reserva';
end;

if(exists (select * from TEAM_CASTY.Estadia e where @Cod_Reserva=e.Cod_Reserva))
begin
	set @error=1;
	set @mensaje=@mensaje + ' Ya se hizo el Check IN.';
end;

if (exists (select * from TEAM_CASTY.Reserva r where @Cod_Reserva=r.Cod_Reserva and datediff(day,r.Fecha_Reserva,@fecha)>0))
begin
		set @error=1;
		set @mensaje=@mensaje + ' Fecha inválida.';
end;

if (exists (select * from TEAM_CASTY.Reserva r where @Cod_Reserva=r.Cod_Reserva and datediff(day,r.Fecha_Reserva,@fecha)<0))
begin
		set @error=1;
		set @mensaje=@mensaje + ' Fecha inválida.';
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
u.Cod_Usuario=@cod_user and
u.Cod_Usuario=uxrxh.Cod_Usuario))
begin		
	set @error=1;
	set @mensaje=@mensaje + ' El usuario no puede operar sobre ese hotel';
end;
	
if (@error=0)	
begin
	insert into TEAM_CASTY.Estadia (Cod_Reserva,Fecha_Inicio,Usuario_Inicio)
	values(@Cod_Reserva,@fecha,@cod_user);
	update TEAM_CASTY.Reserva
	set Cod_Estado=6
	where @Cod_Reserva=Cod_Reserva;	
	insert into TEAM_CASTY.HabitacionXEstadia(Cod_Estadia,Cod_Habitacion)
	select TEAM_CASTY.Utimo_Codigo_Estadia(),hxr.Cod_Habitacion
	from TEAM_CASTY.HabitacionXReserva hxr
	where hxr.Cod_Reserva=@Cod_Reserva;
end
else
begin
	set @mensaje=@mensaje + ' No se realizó el Check IN.';
	RAISERROR (@mensaje,15,1);
end
end;

GO

create type TEAM_CASTY.t_agregar_clientes as table (
cod_cliente numeric(18));

GO

create procedure  TEAM_CASTY.Agregar_Clientes_A_Estadia
(@Cod_Reserva numeric(18),@tabla TEAM_CASTY.t_agregar_clientes readonly)
AS
begin
	declare @cod_est numeric(18);
	select @cod_est=est.Cod_Estadia from TEAM_CASTY.Estadia est where est.Cod_Reserva=@Cod_Reserva;
	
	insert into TEAM_CASTY.ClienteXEstadia
	(Cod_Estadia,ID_Cliente)
	select @cod_est,t.cod_cliente
	from @tabla t;	
	
	insert into TEAM_CASTY.ClienteXEstadia
	(Cod_Estadia,ID_Cliente)
	select @cod_est,r.ID_Cliente_Reservador
	from TEAM_CASTY.Reserva r
	where r.Cod_Reserva=@Cod_Reserva;
end;

GO

create procedure  TEAM_CASTY.Check_OUT
@cod_estadia numeric(18),@fecha datetime, @usuario nvarchar(255),@hotel numeric(18)
AS
begin
declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error:';
declare @cod_user numeric(18);
select @cod_user=u.Cod_Usuario from TEAM_CASTY.Usuario u where u.Username=@usuario;

if(exists(select * from TEAM_CASTY.Estadia est where est.Cod_Estadia=@cod_estadia and est.Fecha_Salida is not null))
begin
	set @error=1;
set @mensaje=' Ya se había realizado el Check OUT.';
end
else
begin

if(not exists (select * from TEAM_CASTY.Estadia e where @cod_estadia=e.Cod_Estadia))
begin
	set @error=1;
	set @mensaje=@mensaje + ' No se realizó el Check IN previamente';
end;

if (exists (select * from TEAM_CASTY.Estadia e where @cod_estadia=e.Cod_Estadia and datediff(day,e.Fecha_Inicio,@fecha)<0))
begin
	set @error=1;
	set @mensaje=@mensaje + ' No concuerdan las fechas.';
end
else
begin
	declare @fs datetime;
	select @fs=(res.Fecha_Reserva+res.Cant_Noches) from TEAM_CASTY.Reserva res, TEAM_CASTY.Estadia est
	where est.Cod_Estadia=@cod_estadia and est.Cod_Reserva=res.Cod_Reserva;
	if (datediff(day,@fecha,@fs)<0)
	begin
		set @error=1;
		set @mensaje=@mensaje + ' No concuerdan las fechas.';
	end
end

if (exists (select * from TEAM_CASTY.Estadia e where @cod_estadia=e.Cod_Estadia and datediff(day,e.Fecha_Inicio,@fecha)=0))
begin
	set @error=1;
	set @mensaje=@mensaje + ' No ha pasado un día aún.';
end

if(not exists(select *
from TEAM_CASTY.Habitacion hab, TEAM_CASTY.HabitacionXEstadia hxe,TEAM_CASTY.Hotel h, TEAM_CASTY.Usuario u, TEAM_CASTY.RolXUsuarioXHotel uxrxh
where hab.Cod_Hotel=h.Cod_Hotel and
h.Cod_Hotel=@hotel and
hxe.Cod_Habitacion=hab.Cod_Habitacion and
hxe.Cod_Estadia=@cod_estadia and
u.Cod_Usuario=@cod_user and
u.Cod_Usuario=uxrxh.Cod_Usuario))
begin		
	set @error=1;
	set @mensaje=@mensaje + ' El usuario no puede operar sobre ese hotel.';
end;
end

if (@error=0)	
begin
	update TEAM_CASTY.Estadia
	set Fecha_Salida=@fecha,Usuario_Salida=@cod_user
	where @cod_estadia=Cod_Estadia;
end
else
begin
	set @mensaje=@mensaje + ' No se realizó el Check OUT.';
	RAISERROR (@mensaje,15,1);
end
end;

GO





select * from TEAM_CASTY.Usuario u where u.Username='guest';

declare @f1 datetime=convert(datetime,'2046-12-09',111);
declare @f2 datetime=@f1-1;
declare @tab TEAM_CASTY.t_reserva;
insert into @tab (Tipo_habitacion,Cantidad) values ('Base Simple',1);
insert into @tab (Tipo_habitacion,Cantidad) values ('King',2);
exec  TEAM_CASTY.Reservar 'guest',@f2,@f1,5,111,'Pension Completa',1,@tab;

select * from TEAM_CASTY.Reserva r order by r.Cod_Reserva desc;

declare @f1 datetime=convert(datetime,'2046-12-09',111);
exec TEAM_CASTY.Check_IN 110751,@f1,'admin',1;

select * from TEAM_CASTY.Estadia e order by e.Cod_Estadia desc;
select * from TEAM_CASTY.HabitacionXEstadia hxe order by hxe.Cod_Estadia desc;
select * from TEAM_CASTY.HabitacionXEstadia hxe where hxe.Cod_Estadia=89607;
select * from TEAM_CASTY.ClienteXEstadia cxe where cxe.Cod_Estadia=89607;

select * from TEAM_CASTY.ClienteXEstadia cxe where cxe.Cod_Estadia=89609;
declare @tab TEAM_CASTY.t_agregar_clientes;
insert into @tab (cod_cliente) values(9);
insert into @tab (cod_cliente) values(4);
exec TEAM_CASTY.Agregar_Clientes_A_Estadia 110751,@tab;
select * from TEAM_CASTY.ClienteXEstadia cxe where cxe.Cod_Estadia=89611;

declare @f1 datetime=convert(datetime,'2046-12-12',111);
exec TEAM_CASTY.Check_OUT 89613,@f1,'guest',1;

select * from TEAM_CASTY.Estadia e where e.Cod_Estadia=89609;



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

GO

select TEAM_CASTY.PrecioPorDiaEspecifico(1,1,1004);
select * from TEAM_CASTY.Estadia e order by e.Cod_Estadia desc;
select * from TEAM_CASTY.HabitacionXEstadia hxe order by hxe.Cod_Estadia desc;
select * from TEAM_CASTY.Habitacion hab
select * from TEAM_CASTY.Regimen reg
select * from TEAM_CASTY.Tipo_Habitacion

create function TEAM_CASTY.MontoConsumibles
(@cod_estadia numeric(18))
RETURNS numeric(18,2)
AS
begin 
declare @monto numeric(18,2)=0;
select @monto=SUM(cxhxe.Precio*cxhxe.Cantidad)
from TEAM_CASTY.ConsumibleXHabitacionXEstadia cxhxe 
where cxhxe.Cod_Estadia=@cod_estadia;
if(@monto is null)
begin
	set @monto=0;
end
return @monto;
end;

GO

create function TEAM_CASTY.MontoHabitaciones
(@cod_estadia numeric(18))
RETURNS numeric(18,2)
AS
begin 
declare @monto numeric(18,2)=0;

select @monto=SUM(ihf.Monto_Completados+ihf.Monto_Faltantes)
from TEAM_CASTY.item_habitacionXFactura ihf, TEAM_CASTY.Factura f
where f.Cod_Estadia=@cod_estadia and ihf.Nro_Factura=f.Nro_Factura;

return @monto;
end;

GO

create function  TEAM_CASTY.Tiene_Factura
(@cod_estadia numeric(18))
returns int
AS
begin
declare @si int;
if (exists(
select * from TEAM_CASTY.Factura f where f.Cod_Estadia=@cod_estadia
))
begin
	set @si=1;
end
else
begin
	set @si=0;
end
return @si;
end;

GO

create function  TEAM_CASTY.Estadias_Sin_Factura_General 
()
returns table
AS
return select est.Cod_Estadia from TEAM_CASTY.Estadia est where TEAM_CASTY.Tiene_Factura(est.Cod_Estadia)=0;

go

select * from TEAM_CASTY.Estadias_Sin_Factura_General ()

select distinct est.Cod_Estadia
from TEAM_CASTY.Estadia est,
(select e.Cod_Estadia from TEAM_CASTY.Estadia e  join TEAM_CASTY.Factura f on (e.Cod_Estadia=f.Cod_Estadia)) ef
where est.Cod_Estadia not in (ef.Cod_Estadia)


select est.Cod_Estadia,fac.Nro_Factura
from TEAM_CASTY.Estadia est join TEAM_CASTY.Factura fac on (est.Cod_Estadia=fac.Cod_Estadia)

insert into TEAM_CASTY.Estadia (Cod_Reserva,Fecha_Inicio)values(10001,getdate());

select * from TEAM_CASTY.Factura f where f.Cod_Estadia=100000

create function  TEAM_CASTY.Estadias_Sin_Factura
(@hotel numeric(18))
returns table
AS
return(
select distinct est.Cod_Estadia--,c.Nombre,c.Apellido,c.Nacionalidad,c.[Tipo Documento],c.[Numero Documento]
from TEAM_CASTY.Estadia est, TEAM_CASTY.Habitacion hab,
TEAM_CASTY.HabitacionXEstadia hxe,--TEAM_CASTY.vistaClientes c, TEAM_CASTY.Reserva res,
where TEAM_CASTY.Tiene_Factura(est.Cod_Estadia)=0 and est.Fecha_Salida is not null and est.Cod_Estadia=hxe.Cod_Estadia and
hxe.Cod_Habitacion=hab.Cod_Habitacion and hab.Cod_Hotel=@hotel-- and res.Cod_Reserva=est.Cod_Reserva and
--c.Codigo=res.ID_Cliente_Reservador
);


GO

select * from TEAM_CASTY.Estadias_Sin_Factura(1)


create procedure  TEAM_CASTY.Facturar
@cod_Estadia numeric(18), @fecha datetime, @cod_forma_pago numeric(18),@hotel numeric(18),@money money output
AS
begin
declare @mensaje nvarchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error: ';

if (exists(select * from TEAM_CASTY.Estadia e where e.Cod_Estadia=@cod_Estadia))
begin
	if ((select e.Fecha_Salida from TEAM_CASTY.Estadia e where e.Cod_Estadia=@cod_Estadia) is null)
	begin
		set @error=1;
		set @mensaje+=' No se realizó el Check OUT aún.';
	end
	else
	begin
		if (datediff(day,(select e.Fecha_Salida from TEAM_CASTY.Estadia e where e.Cod_Estadia=@cod_Estadia),@fecha)<>0)
		begin
			set @error=1;
			set @mensaje+=' Fecha incorrecta.';
		end
		else
		begin
			if(not exists(
			select * from TEAM_CASTY.HabitacionXEstadia hxe, TEAM_CASTY.Habitacion hab
			 where hxe.Cod_Estadia=@cod_Estadia and hxe.Cod_Habitacion=hab.Cod_Habitacion and @hotel=hab.Cod_Hotel))
			begin
				set @error=1;
				set @mensaje+=' El hotel no corresponde a esa estadía.';
			end
		end
	end
end
else
begin
	set @error=1; 
	set @mensaje+=' Estadía inexistente.';
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
		where est.Cod_Estadia=@cod_Estadia;
		
		declare @dias_faltantes numeric (18);
		select @dias_faltantes=res.Cant_Noches-@dias_completados
		from TEAM_CASTY.Reserva res, TEAM_CASTY.Estadia est
		where @cod_Estadia=est.Cod_Estadia and est.Cod_Reserva=res.Cod_Reserva;
		
		insert into TEAM_CASTY.item_habitacionXFactura
		(Cod_Habitacion,Cod_Regimen,Nro_Factura,Dias_Completados,Monto_Completados,Dias_Faltantes,Monto_Faltantes)
		select hab.Cod_Habitacion,res.Cod_Regimen,@nro_factura,@dias_completados,
		(@dias_completados*TEAM_CASTY.PrecioPorDiaEspecifico(@hotel,res.Cod_Regimen,hab.Cod_Tipo)),
		@dias_faltantes,
		(@dias_faltantes*TEAM_CASTY.PrecioPorDiaEspecifico(@hotel,res.Cod_Regimen,hab.Cod_Tipo))
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
		set @money=@monto_total;
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
	
	update TEAM_CASTY.Factura
	set Cod_Forma_Pago=2
	where Cod_Estadia=@cod_Estadia;
end
else
begin
	set @mensaje=@mensaje + 'No se realizó el pago correctamente.';
	RAISERROR (@mensaje,15,1);
end
end;

GO

select * from TEAM_CASTY.Estadia e order by e.Cod_Estadia desc;
select * from TEAM_CASTY.Factura f order by f.Nro_Factura desc;
select * from TEAM_CASTY.Estadia e order by e.Cod_Estadia desc

declare @f datetime=convert(datetime,'2046-12-12',111);
exec TEAM_CASTY.Facturar 89613,@f,1;

select * from TEAM_CASTY.Factura f order by f.Nro_Factura desc;
select * from TEAM_CASTY.item_ConsumibleXFactura t where t.Nro_Factura=2486357;
select * from TEAM_CASTY.item_habitacionXFactura t where t.Nro_Factura=2486357;
select * from TEAM_CASTY.Estadia e where e.Cod_Estadia=89611;
select * from TEAM_CASTY.Factura t where t.Nro_Factura=2486357;


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



create function TEAM_CASTY.RegimenesDeUnHotel
(@cod_hotel numeric (18))
RETURNS TABLE
AS 
return (
select reg.Descripcion
from TEAM_CASTY.RegimenXHotel rxh, TEAM_CASTY.Regimen reg
where rxh.Cod_Hotel=@cod_hotel and rxh.Activo=1 and reg.Cod_Regimen=rxh.Cod_Regimen);

go

create function TEAM_CASTY.DescripcionesDeRegimenes
()
RETURNS TABLE
AS 
return (
select reg.Descripcion
from TEAM_CASTY.Regimen reg);

go

CREATE TYPE TEAM_CASTY.t_tablaRegimenes AS TABLE(
	Descripcion nvarchar (255));
	
GO

create procedure TEAM_CASTY.alta_Hotel
(@nombre nvarchar(255),@mail nvarchar(255),@telefono nvarchar(50),@pais nvarchar(255),@cidudad nvarchar(255),@cant_Estrellas numeric (18),
@calle nvarchar(255),@num_calle numeric (18),@fecha_creacion datetime, @tabla t_tablaRegimenes readonly)
as
begin
declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error: ';

 if (exists (
 select *
 from TEAM_CASTY.Hotel h, TEAM_CASTY.Ciudad c
 where h.Calle=@calle and @num_calle=h.Nro_Calle and h.Pais=upper(@pais) and c.Nombre=@cidudad))
 begin
	set @error=1;
	set @mensaje+=' El hotel ya existe.';
 end

if(exists(
select * from TEAM_CASTY.Hotel h where h.Mail=@mail
))
begin
	set @error=1;
	set @mensaje+='Mail repetido.';
end
 
if (@error=0)
begin
	declare @cod_ciudad numeric (18);
	if (not exists (
	select * from TEAM_CASTY.Hotel h, TEAM_CASTY.Ciudad c where h.Pais=@pais and c.Nombre=@cidudad))
	begin
		INSERT INTO TEAM_CASTY.Ciudad (Nombre) values (@cidudad);
	end
	select @cod_ciudad=c.Cod_Ciudad	from TEAM_CASTY.Ciudad c where c.Nombre=@cidudad;	
	
	insert into Team_Casty.Hotel
	(Nombre,Pais,Cod_Ciudad,Calle,Nro_Calle,Telefono,Mail,CantEstrella,Fecha_Creacion)
	values(@nombre,upper(@pais),@cod_ciudad,@calle,@num_calle,@telefono,@mail,@cant_Estrellas,@fecha_creacion);
	
	declare @cod_hotel numeric (18);
	select @cod_hotel=MAX(h.Cod_Hotel) from TEAM_CASTY.Hotel h;
	
	insert into TEAM_CASTY.RegimenXHotel
	(Cod_Hotel,Cod_Regimen,Activo)
	select @cod_hotel,r.Cod_Regimen,1
	from  TEAM_CASTY.Regimen r, @tabla t
	where r.Descripcion=t.Descripcion;
	
end	
else
begin
	set @mensaje=@mensaje + 'No se realizó el alta.';
	RAISERROR (@mensaje,15,1);
end
end;
 
 GO
 
 create procedure TEAM_CASTY.modificacion_Hotel
(@cod_hotel numeric (18),@nombre nvarchar(255),@mail nvarchar(255),@telefono nvarchar(50),@pais nvarchar(255),@cidudad nvarchar(255),@cant_Estrellas numeric (18),
@calle nvarchar(255),@num_calle numeric (18),@fecha_creacion datetime, @tabla t_tablaRegimenes readonly)
 as
 begin
 declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error: ';

 if (not exists (
 select *
 from TEAM_CASTY.Hotel h
 where h.Cod_Hotel=@cod_hotel))
 begin
	set @error=1;
	set @mensaje+=' El hotel no existe.';
 end
 
 if(exists(
select * from TEAM_CASTY.Hotel h where h.Mail=@mail and @cod_hotel<>h.Cod_Hotel
))
begin
	set @error=1;
	set @mensaje+='Mail repetido.';
end
 
if (@error=0)
begin	
	declare @cod_ciudad numeric (18);
	if (not exists (
	select * from TEAM_CASTY.Hotel h, TEAM_CASTY.Ciudad c where h.Pais=upper(@pais) and c.Nombre=@cidudad))
	begin
		INSERT INTO TEAM_CASTY.Ciudad (Nombre) values (@cidudad);
	end
	select @cod_ciudad=c.Cod_Ciudad	from TEAM_CASTY.Ciudad c where c.Nombre=@cidudad;
	
	update Team_Casty.Hotel
	set Nombre=@nombre,Pais=@pais,Calle=@calle,Nro_Calle=@num_calle,Telefono=@telefono,
	Mail=@mail,CantEstrella=@cant_Estrellas,Fecha_Creacion=@fecha_creacion,Cod_Ciudad=@cod_ciudad
	where @cod_hotel=Cod_Hotel;
	
	delete TEAM_CASTY.RegimenXHotel	
	where Cod_Hotel=@cod_hotel;
	
	insert into TEAM_CASTY.RegimenXHotel
	(Cod_Hotel,Cod_Regimen,Activo)
	select @cod_hotel,r.Cod_Regimen,1
	from  TEAM_CASTY.Regimen r, @tabla t
	where r.Descripcion=t.Descripcion;	
end	
else
begin
	set @mensaje=@mensaje + 'No se realizó la modificación.';
	RAISERROR (@mensaje,15,1);
end
end;
 
 GO
 
 create function TEAM_CASTY.periodoOK
(@fi1 datetime, @ff1 datetime, @fi2 datetime, @ff2 datetime)
RETURNS numeric(18)
AS
begin
declare @ok numeric (18);

if( (@ff2<@fi1) or (@fi2>@ff1) )
begin
	set @ok=1;
end
else
begin
	set @ok=0;
end

return @ok;
end;

GO
 
create procedure TEAM_CASTY.baja_Hotel
(@cod_hotel numeric (18),@fecha_inicio datetime, @fecha_fin datetime,@motivo nvarchar(255))
 as
 begin
 declare @mensaje varchar(1000);
declare @error int;
set @error=0;
set @mensaje='Error:';

 if (not exists (
 select *
 from TEAM_CASTY.Hotel h
 where h.Cod_Hotel=@cod_hotel))
 begin
	set @error=1;
	set @mensaje+=' El hotel no existe.';
 end
 
if(exists(
select * from
(select r.Fecha_Reserva as Fecha_Inicio, r.Fecha_Reserva+r.Cant_Noches as Fecha_Fin
from TEAM_CASTY.Reserva r, TEAM_CASTY.HabitacionXReserva hxr,TEAM_CASTY.Habitacion hab
where r.Cod_Reserva=hxr.Cod_Reserva and hxr.Cod_Habitacion=hab.Cod_Habitacion
and @cod_hotel=hab.Cod_Hotel and r.Cod_Estado in(1,2,6)) t
where TEAM_CASTY.periodoOK(@fecha_inicio,@fecha_fin,Fecha_Inicio,Fecha_Fin)=0
))
begin
	set @error=1;
	set @mensaje+=' El hotel no se puede inhabilitar.';
end

if(exists(
select *
from TEAM_CASTY.Periodo_Inhabilitado pein
where TEAM_CASTY.periodoOK(@fecha_inicio,@fecha_fin,pein.Fecha_Inicio,pein.Fecha_Fin)=0
))
begin
	set @error=1;
	set @mensaje+=' El hotel ya está inhabilitado.';
end
 
if (@error=0)
begin
	insert into TEAM_CASTY.Periodo_Inhabilitado
	(Cod_Hotel,Fecha_Inicio,Fecha_Fin,Descripcion)
	values (@cod_hotel,@fecha_inicio,@fecha_fin,@motivo);	
end	
else
begin
	set @mensaje=@mensaje + ' No se realizó la modificación.';
	RAISERROR (@mensaje,15,1);
end
end;
 
 GO
 
 
 
 
create procedure TEAM_CASTY.Insertar_Recarga
 (@fecha datetime, @recarga numeric(18))
 as
 begin
	declare @mensaje varchar(1000);
	declare @error int;
	set @error=0;
	set @mensaje='Error:';
	
	if(exists (select * from TEAM_CASTY.Recarga_Estrella re where datediff(day,re.Fecha_Modificacion,@fecha)=0))
	begin
		set @error=1;
		set @mensaje=' Ya se cambió la recarga ese día.';
	end
	
	if (@error=0)
	begin
		insert into TEAM_CASTY.Recarga_Estrella
		(Fecha_Modificacion,Recarga)
		values (@fecha,@recarga);
	end	
	else
	begin
		set @mensaje=@mensaje + ' No se realizó la modificación.';
		RAISERROR (@mensaje,15,1);
	end
end;

GO