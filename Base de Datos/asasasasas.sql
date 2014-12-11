--sdasdakldassdasda

create procedure  TEAM_CASTY.Disponibilidad_Reserva--OK=1; NO=0;
(@fecha_desde datetime,@fecha_hasta datetime,@hotel numeric(18),@regimen nvarchar(255),@tabla TEAM_CASTY.t_reserva readonly,
@sePuede bit output,@precio money)
AS
begin

set @sePuede =1;
set @precio =0;

declare @cod_reg numeric(18);
select @cod_reg=reg.Cod_Regimen from TEAM_CASTY.Regimen reg where reg.Descripcion=@regimen;

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

if(@sePuede=1)
begin	
	DECLARE _cursor2 CURSOR FOR
	select * from @tabla;
	OPEN _cursor2;
	DECLARE @t_habitacion nvarchar(255), @cantidad numeric(18),@cod_tipo_habitacion numeric(18);
	FETCH NEXT FROM _cursor2 INTO @t_habitacion, @cantidad;
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		select @cod_tipo_habitacion=th.Cod_Tipo
		from TEAM_CASTY.Tipo_Habitacion th
		where th.Descripcion=@t_hab;
		
		set @precio+=((select TEAM_CASTY.PrecioPorDiaEspecifico(@hotel,@cod_reg,@cod_tipo_habitacion))*@cantidad);
		
		FETCH NEXT FROM _cursor2 INTO @t_habitacion, @cantidad;				
	END
	CLOSE _cursor2;
	DEALLOCATE _cursor2;	
end

end;

GO


create procedure  TEAM_CASTY.Reservar
(@usuario nvarchar(255),@fecha_realizacion datetime,@fecha_reserva datetime,@cant_noches numeric(18),@id_cliente numeric(18),
@regimen nvarchar(255),@hotel numeric(18),@tabla TEAM_CASTY.t_reserva readonly,@cod_reserva numeric(18) output)
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
	
	set @cod_reserva=TEAM_CASTY.Ultimo_Codigo_Reserva()+1;
	
	insert into TEAM_CASTY.Reserva
	(Cant_Noches,Cod_Estado,Cod_Regimen,Cod_Reserva,Fecha_Realizacion,Fecha_Reserva,ID_Cliente_Reservador)
	values (@cant_noches,1,@cod_t_reg,@cod_reserva,@fecha_realizacion,@fecha_reserva,@id_cliente);
	
	insert into TEAM_CASTY.ModificacionXReserva
	(Cod_Reserva,Cod_Usuario,Descripcion,Fecha,Numero_Modificacion)
	values (@cod_reserva,@cod_usuario,'Creación',@fecha_realizacion,1);
	
	exec TEAM_CASTY.Reservar_Habitaciones @cod_reserva,@fecha_reserva,@cant_noches,@hotel,@tabla;
	
end;

GO