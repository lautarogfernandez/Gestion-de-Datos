create procedure validarUsuario(@usuario nvarchar(255),@contraseña nvarchar(255))
as
begin

if exists (select * from TEAM_CASTY.Usuario u where u.Username=@usuario and u.Habilitado =0 )
  begin
  
  
  
  end

if exists (select * from TEAM_CASTY.Usuario u where u.Username=@usuario and u.Habilitado =1 )
  begin
  
  if  exists (select * from TEAM_CASTY.Usuario u where u.Username=@usuario and u.Contraseña = @contraseña )
    begin
    update TEAM_CASTY.Usuario set Cant_Intentos=0 where Username = @usuario
    end
  
  else 
    begin
    update TEAM_CASTY.Usuario set Cant_Intentos= Cant_Intentos + 1 where Username = @usuario
    update TEAM_CASTY.Usuario set Habilitado=0 where Username = @usuario and Cant_Intentos >= 3
    end  
    
  end

end



CREATE FUNCTION RolesDeUsuarioEnHotel (@usuario numeric(18),@hotel numeric(18))
RETURNS TABLE
AS
RETURN 
   select distinct r.Cod_Rol as Codigo, r.Nombre ,r.Activo
   from TEAM_CASTY.RolXUsuarioXHotel RxUxH , TEAM_CASTY.Rol r 
   where  RxUxH.Cod_Rol = r.Cod_Rol and RxUxH.Cod_Hotel = @hotel and RxUxH.Cod_Usuario = @usuario
   
   

CREATE FUNCTION FuncionesDeUnRol (@Rol numeric(18))
RETURNS TABLE
AS
RETURN 
   select distinct f.Cod_Funcion, f.Descripcion
   from TEAM_CASTY.Funcion f , TEAM_CASTY.Rol r , TEAM_CASTY.FuncionXRol fXr
   where  @Rol = r.Cod_Rol and r.Cod_Rol = fXr.Cod_Rol and fXr.Cod_Funcion=f.Cod_Funcion