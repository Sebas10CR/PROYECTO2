<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LOGIN.aspx.cs" Inherits="EXAMEN2.Vista.LOGIN" %>

<!DOCTYPE html>

<html lang="es">
    
    <head>
        
        <meta charset="utf-8">
        
        <title> Formulario de Acceso </title>    
        
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
 
        
        
        
       
        <<link href="css1.css" rel="stylesheet" />


      
        
        <style type="text/css">
            
        </style>
        
        <script type="text/javascript">
        
        </script>
        
    </head>
    
    <body>
        
        <div id="contenedor">
            <div id="central">
                <div id="login">
                    <div class="titulo">
                        Bienvenido
                    </div>
                    <form id="loginform" runat="server">
                        <input type="text" name="usuario" placeholder="Usuario" required>
                        
                        <input type="password" placeholder="Contraseña" name="password" required>
                        
                        <button type="submit" title="Ingresar" name="Ingresar" ><a href="menu.aspx">Login</a></button>
                    <div class="pie-form">
                        
                     
                        
                    </div>
                    </form>
                </div>
                <div class="inferior">
                    <a href="#">Volver</a>
                </div>
            </div>
        </div>
            
    </body>
</html>
