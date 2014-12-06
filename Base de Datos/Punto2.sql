create procedure validarUsuario(@usuario nvarchar(255),@contraseña nvarchar(255))
as
begin

if exists (select * from TEAM_CASTY.Usuario u where u.Username=@usuario and u.Habilitado =0 ) -- si existe y esta inhabilitado
  begin
  
  --retornar error inhabilitado
  
  end
  else
   begin
     if exists (select * from TEAM_CASTY.Usuario u where u.Username=@usuario and u.Habilitado =1 )-- si  existe y esta habilitado
       begin
  
       if  exists (select * from TEAM_CASTY.Usuario u where u.Username=@usuario and u.Contraseña = @contraseña )-- si la contraseña es correcta
         begin
           update TEAM_CASTY.Usuario set Cant_Intentos=0 where Username = @usuario
           --tiene q devolver 1??
         end
  
         else -- si la contraseña es incorrecta
         begin
           update TEAM_CASTY.Usuario set Cant_Intentos= Cant_Intentos + 1 where Username = @usuario
           update TEAM_CASTY.Usuario set Habilitado=0 where Username = @usuario and Cant_Intentos >= 3
           --tiene q devolver 0??
         end  
    
       end
   
    else-- si no existe
      begin
        --retornar error username
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
