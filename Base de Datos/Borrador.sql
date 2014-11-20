--cosumibles de la reserva (por habitacion) --anda OK
CREATE TABLE TEAM_CASTY.ConsumibleXHabitacionXReserva ( 
	Cod_Reserva numeric(18) NOT NULL,
	Cod_Habitacion numeric(18) NOT NULL,
	Cod_Consumible numeric(18) NOT NULL,
	Cantidad numeric(18) NOT NULL,
	PRIMARY KEY (Cod_Reserva,Cod_Habitacion,Cod_Consumible),
	FOREIGN KEY (Cod_Habitacion) REFERENCES TEAM_CASTY.Habitacion (Cod_Habitacion),
	FOREIGN KEY (Cod_Reserva) REFERENCES TEAM_CASTY.Reserva (Cod_Reserva),
	FOREIGN KEY (Cod_Consumible) REFERENCES TEAM_CASTY.Consumible (Cod_Consumible));
	
SELECT  distinct habXres.Cod_Habitacion, hab.Cod_Hotel, hot.Cod_Ciudad , Cod_Reserva, Numero,Nombre,Calle,Nro_Calle
INTO #auxiliar
FROM TEAM_CASTY.HabitacionXReserva habXres JOIN  TEAM_CASTY.Habitacion hab on (habXres.Cod_Habitacion= hab.Cod_Habitacion) 
                                           JOIN TEAM_CASTY.Hotel hot ON(hot.Cod_Hotel = hab.Cod_Hotel)
                                           JOIN TEAM_CASTY.Ciudad ciu ON(hot.Cod_Ciudad = ciu.Cod_Ciudad);  
                                           
INSERT INTO TEAM_CASTY.ConsumibleXHabitacionXReserva (Cod_Reserva,Cod_Habitacion,Cod_Consumible,Cantidad)
SELECT a.Cod_Reserva, a.Cod_Habitacion,m.Consumible_Codigo,count(m.Consumible_Codigo) AS "Cantidad"
FROM gd_esquema.Maestra m JOIN #auxiliar a ON(a.Cod_Reserva=m.Reserva_Codigo and a.Numero = m.Habitacion_Numero and a.Nombre = m.Hotel_Ciudad and a.Calle=m.Hotel_Calle and a.Nro_Calle = m.Hotel_Nro_Calle)
WHERE m.Consumible_Codigo is not null and m.Factura_Nro is not null
GROUP BY a.Cod_Reserva, a.Cod_Habitacion,m.Consumible_Codigo

DROP TABLE #auxiliar





--consumible, habitacion y factura
CREATE TABLE TEAM_CASTY.item_ConsumibleXFactura ( 
	Nro_Factura numeric(18) NOT NULL,
	Cod_Habitacion numeric(18) NOT NULL,
	Cod_Consumible numeric(18) NOT NULL,
	Cantidad numeric(18) NOT NULL,
	Monto numeric(18,2) NOT NULL,
	PRIMARY KEY (Nro_Factura,Cod_Habitacion,Cod_Consumible),
	FOREIGN KEY (Cod_Habitacion) REFERENCES TEAM_CASTY.Habitacion (Cod_Habitacion),
	FOREIGN KEY (Nro_Factura) REFERENCES TEAM_CASTY.Factura (Nro_Factura),
	FOREIGN KEY (Cod_Consumible) REFERENCES TEAM_CASTY.Consumible (Cod_Consumible));

INSERT INTO TEAM_CASTY.item_ConsumibleXFactura (Nro_Factura,Cod_Habitacion,Cod_Consumible,Cantidad,Monto)
SELECT f.Nro_Factura,chres.Cod_Habitacion,chres.Cod_Consumible,chres.Cantidad, chres.Cantidad*con.Precio
FROM TEAM_CASTY.ConsumibleXHabitacionXReserva chres, TEAM_CASTY.Factura f, TEAM_CASTY.Consumible con
WHERE f.Cod_Reserva=chres.Cod_Reserva and chres.Cod_Consumible = con.Cod_Consumible

select * from TEAM_CASTY.item_ConsumibleXFactura