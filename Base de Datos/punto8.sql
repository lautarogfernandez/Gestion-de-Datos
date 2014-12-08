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
declare @aux bit
    if ((@FechaInicio1 > @FechaFin2 or  @FechaInicio2 > @FechaFin1 ))  set @aux= 1
   else  set @aux = 0
   return @aux
END;
GO

drop function periodosSinInterseccion

--------------------------------------------------------------------------------------------------------------------------------

create procedure Team_Casty.agregarHabitacionReserva(@codHabitacion numeric(18),@codReserva numeric(18))
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


create function Team_Casty.regimenesEnHotel (@codHotel numeric(18))
returns table
as
return select reg.Cod_Regimen as Codigo ,reg.Descripcion,reg.Precio from Team_Casty.Regimen reg, Team_Casty.RegimenXHotel rxh where @codHotel= rxh.Cod_Hotel and rxh.Cod_Regimen=reg.Cod_Regimen and rxh.Activo =1
go


create function Team_Casty.habitacionesLibresEnHotel(@codHotel numeric(18),@fechaInicio datetime,@fechaSalida datetime)
returns table
as
return select hab.* 
       from Team_Casty.Habitacion hab,Team_Casty.Reserva res,Team_Casty.HabitacionXReserva hxr
        where Cod_Hotel = @codHotel and hab.Baja = 0 and not(hab.Cod_Habitacion= hxr.Cod_Habitacion
              and hxr.Cod_Reserva=res.Cod_Reserva and 
              periodosSinInterseccion(@fechaInicio,@fechaSalida,res.Fecha_Reserva,DATEADD(DAY,1,res.Fecha_Reserva))=0)
go

create procedure Team_Casty.precioPorDia(@codHabitacion numeric(18), @codRegimen numeric(18),@precio numeric(18) output)
as
begin 
  set @precio= (select distinct (reg.Precio *th.Porcentual + hot.CantEstrella*recarga.Recarga)  as precioDia
   from Team_Casty.Habitacion hab , Team_Casty.Tipo_Habitacion th, Team_Casty.Hotel hot, Team_Casty.Regimen reg,(select top 1 re.Recarga,re.Fecha_Modificacion from Team_Casty.Recarga_Estrella re order by  re.Fecha_Modificacion desc) as recarga
               where reg.Cod_Regimen=@codRegimen and hab.Cod_Habitacion=@codHabitacion and hab.Cod_Tipo=th.Cod_Tipo and hab.Cod_Hotel=hot.Cod_Hotel)
end
go