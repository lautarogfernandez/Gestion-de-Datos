create procedure baja_habitacion(@codHabitacion numeric(18),@fechaActual datetime)
as
begin

declare @mensaje  nvarchar(255)

if not exists (select * from TEAM_CASTY.Reserva r,TEAM_CASTY.HabitacionXReserva hxr where r.Cod_Reserva=hxr.Cod_Reserva and hxr.Cod_Habitacion=@codHabitacion
                                 and r.Cod_Estado in(1,2,6) and @fechaActual < DATEADD(DAY,r.Cant_Noches, r.Fecha_Realizacion) )
  begin
    update TEAM_CASTY.Habitacion  set Baja=1 where Cod_Habitacion = @codHabitacion
  end
else
  begin
      set @mensaje= 'La habitacion se encuentra reservada'
     RAISERROR (@mensaje,15,1);
  end
end;
go


 ----------------------------------------PUNTO6-----------------------------------------------------------------
 create view TEAM_CASTY.vistaHabitaciones
 as
 select h.Cod_Habitacion as Codigo, h.Numero , h.Piso , h.Frente, h.Descripcion , th.Descripcion as "Tipo de habitacion" , h.Cod_Hotel Hotel
 from TEAM_CASTY.Habitacion h, TEAM_CASTY.Tipo_Habitacion th
 where h.Cod_Tipo = th.Cod_Tipo


create trigger TEAM_CASTY.alta_Habitaciones
 ON TEAM_CASTY.vistaHabitaciones
instead of insert
as
begin
declare @mensaje nvarchar(255)
if not exists (select h.* from inserted i, TEAM_CASTY.Habitacion h  where i.Numero= h.Numero and i.Hotel = h.Cod_Hotel)
 begin
insert into TEAM_CASTY.Habitacion (Numero ,Piso ,Descripcion ,Cod_Hotel , Frente , Cod_Tipo ) select i.Numero, i.Piso,i.Descripcion, i.Hotel as Cod_Hotel , i.Frente , th.Cod_Tipo from inserted i , TEAM_CASTY.Tipo_Habitacion th 
                                                                                                                             where i.[Tipo de habitacion] = th.Descripcion  
end
else
begin
     set @mensaje= 'El numero de habitacion esta ocupado'
     RAISERROR (@mensaje,15,1);

end

end



create trigger TEAM_CASTY.modificacion_Habitaciones
ON TEAM_CASTY.vistaHabitaciones
instead of update
as
begin
declare @mensaje nvarchar(255)
if not exists (select h.* from TEAM_CASTY.Habitacion h,inserted i where i.Numero= h.Numero and i.Hotel = h.Cod_Hotel)
 begin
  update h set h.Piso = i.Piso , h.Numero = i.Numero , h.Frente = i.Frente , h.Descripcion = i.Descripcion 
  from TEAM_CASTY.Habitacion h join inserted i on (i.Codigo = h.Cod_Habitacion)
 end
else
begin
    set @mensaje= 'El numero de habitacion esta ocupado'
     RAISERROR (@mensaje,15,1);
end 
end;
go 
