create procedure Team_Casty.cancelarReserva (@nroReserva numeric(18), @motivo varchar(255), @fechaCancelacion datetime,@username varchar(255))
as
begin
if not exists (select * from Team_Casty.Estados e where )
begin
     
	update c set c.Cod_Reserva=@nroReserva, c.Motivo=@motivo, c.Fecha=@fechaCancelacion, c.Cod_Usuario = u.Cod_Usuario
	from Team_Casty.Cancelacion c , Team_Casty.Usuario u
	where u.Username=@username


end
end
go


create function periodosSinInterseccion(@FechaInicio1 date, @FechaFin1 date, @FechaInicio2 date, @FechaFin2 date)
RETURNS bit
AS 
BEGIN
    if ((@FechaInicio1 > @FechaFin2 or  @FechaInicio2 > @FechaFin1 ))  RETURN 0
   else    RETURN 1
END;
GO




--------------------------------------------------

create procedure Team_Casty.habitacionReserva(@codHabitacion numeric(18),@codReserva numeric(18))
as
begin
  insert into Team_Casty.HabitacionXReserva (Cod_Habitacion,Cod_Reserva) values (@codHabitacion,@codReserva)
end
go

create procedure Team_Casty.generarReserva(@fechaRealizacion datetime, @fechaInicio datetime ,@fechaSalida datetime ,@nombreRegimen nvarchar(255),@codCliente numeric(18)) 
as
begin
  insert into Team_Casty.Reserva (Fecha_Realizacion, Fecha_Reserva , Cant_Noches ,ID_Cliente_Reservador,Cod_Regimen) 
              select @fechaRealizacion as Fecha_Realizacion, @fechaInicio as Fecha_Reserva, DATEDIFF(DAY,@fechaSalida,@fechaInicio) as Cant_Noches,
                     @codCliente as ID_Cliente_Reservador, r.Cod_Regimen
              from Team_Casty.Regimen r where r.Descripcion=@nombreRegimen       
                      
                           
end
go

create function Team_Casty.habitacionesEnHotel(@codHotel numeric(18))
returns table
as
--return select hab.* from Team_Casty.Habitacion hab where Cod_Hotel = @codHotel and hab.Baja = 0 and hab.


