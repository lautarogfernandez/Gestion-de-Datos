drop trigger TEAM_CASTY.alta_clientes;
drop trigger TEAM_CASTY.baja_clientes;
drop trigger TEAM_CASTY.modif_clientes;
drop trigger TEAM_CASTY.alta_clientes;
drop trigger TEAM_CASTY.modificacion_clientes;
drop trigger TEAM_CASTY.baja_clientes;

DROP VIEW TEAM_CASTY.vistaHoteles;
DROP VIEW TEAM_CASTY.vistaRoles;
drop view TEAM_CASTY.vistaClientesErroneos;
DROP VIEW TEAM_CASTY.vistaClientes;

DROP TABLE TEAM_CASTY.Cancelacion;
DROP TABLE TEAM_CASTY.ModificacionXReserva;
DROP TABLE TEAM_CASTY.UsuarioXHotel;
DROP TABLE TEAM_CASTY.TarjetaXFactura;
drop table TEAM_CASTY.item_habitacionXFactura;
drop table TEAM_CASTY.HabitacionXEstadia;
DROP TABLE TEAM_CASTY.ConsumibleXHabitacionXEstadia;
DROP TABLE TEAM_CASTY.RolXUsuarioXHotel
DROP TABLE TEAM_CASTY.ClienteXEstadia;
DROP TABLE TEAM_CASTY.RegimenXHotel;
DROP TABLE TEAM_CASTY.Periodo_Inhabilitado;
DROP TABLE TEAM_CASTY.Item_Factura_Consumible;	
DROP TABLE TEAM_CASTY.Item_EstadiaXFactura;
DROP TABLE TEAM_CASTY.HabitacionXReserva;	
DROP TABLE TEAM_CASTY.Tarjeta;
DROP TABLE TEAM_CASTY.FuncionXRol;	
DROP TABLE TEAM_CASTY.Factura;
DROP TABLE TEAM_CASTY.item_ConsumibleXFactura;
DROP TABLE TEAM_CASTY.ConsumibleXReserva;
DROP TABLE TEAM_CASTY.Usuario;
DROP TABLE TEAM_CASTY.Empleado;
DROP TABLE TEAM_CASTY.Consumible;
DROP TABLE TEAM_CASTY.Estadia;
DROP TABLE TEAM_CASTY.Reserva;	
DROP TABLE TEAM_CASTY.Habitacion;
DROP TABLE TEAM_CASTY.Hotel;	
DROP TABLE TEAM_CASTY.Funcion;
DROP TABLE TEAM_CASTY.Rol;
DROP TABLE TEAM_CASTY.Tipo_Habitacion;	
DROP TABLE TEAM_CASTY.Regimen;
DROP TABLE TEAM_CASTY.Cliente;	
DROP TABLE TEAM_CASTY.Ciudad;
DROP TABLE TEAM_CASTY.Forma_Pago;
DROP TABLE TEAM_CASTY.Tipo_Documento;
DROP TABLE TEAM_CASTY.Estados;
DROP TABLE TEAM_CASTY.Recarga_Estrella;

drop FUNCTION TEAM_CASTY.RolesDeUsuarioEnHotel;
drop FUNCTION TEAM_CASTY.FuncionesDeUnRol;
drop function  TEAM_CASTY.Precios_Por_Dia;
drop function TEAM_CASTY.FuncionesAsignables;
drop function TEAM_CASTY.RegimenesElegibles;
drop function TEAM_CASTY.periodoOK;
drop function TEAM_CASTY.RegimenesDeUnHotel;
drop function TEAM_CASTY.Regimenes;

DROP procedure TEAM_CASTY.validarUsuario;
drop procedure TEAM_CASTY.CambiarPassword;
drop procedure TEAM_CASTY.CargarHabitacion;
drop procedure TEAM_CASTY.ModificarHabitacion;
drop procedure TEAM_CASTY.BajarHabitacion;
drop procedure  TEAM_CASTY.Alta_Rol;
drop procedure  TEAM_CASTY.Modificacion_Rol;
drop procedure  TEAM_CASTY.Baja_Rol;
drop procedure  TEAM_CASTY.RegistrarConsumibles;
drop procedure TEAM_CASTY.alta_Hotel;
drop procedure TEAM_CASTY.modificacion_Hotel;
drop procedure TEAM_CASTY.baja_Hotel;
drop procedure TEAM_CASTY.crearUsuario;
drop procedure TEAM_CASTY.modificarUsuario;
drop procedure TEAM_CASTY.bajaUsuario;

drop TYPE TEAM_CASTY.t_tablaRegimenes;
drop TYPE TEAM_CASTY.t_funcion;
drop TYPE TEAM_CASTY.t_tablaHotelYRol;
drop TYPE TEAM_CASTY.t_tablaConsumibles;

Drop schema TEAM_CASTY;