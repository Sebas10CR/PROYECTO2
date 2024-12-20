<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tecnicos.aspx.cs" Inherits="EXAMEN2.Vista.Tecnicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="estilopagina.css" rel="stylesheet" />
<link href="Mbarra.css" rel="stylesheet" />

   
</head>
<body>
    <form id="form1" runat="server">
                <div>
    <ul>
        <li><a class="active" href="menu.aspx">Home</a></li>
        <li><a href="Usuarios.aspx">Usuarios</a></li>
        <li><a href="Equipos.aspx">Equipos</a></li>
        <li><a href="Tecnicos.aspx">Tecnicos</a></li>
        <li><a href="Reparaciones.aspx">Reparaciones</a></li>
        <li><a href="Asignaciones.aspx">Asignaciones</a></li>
        <li><a href="DetallesReparaciones.aspx">Detalles Reparacion</a></li>
  
    </ul>
</div>
        <h1>DATOS DE TECNICOS</h1>
<div class="section">
    <div class="grid-container">
        <asp:GridView ID="GridView1" runat="server" Width="400px"></asp:GridView>
    </div>
    <div class="form-container">
        <label for="TextBox1">ID:</label>
        <asp:TextBox ID="tID" runat="server" BackColor="#CCCCCC" BorderColor="Black"></asp:TextBox>

        <label for="TextBox2">Nombre:</label>
        <asp:TextBox ID="tNombre" runat="server" BackColor="#CCCCCC" BorderColor="Black"></asp:TextBox>

        <label for="TextBox3">Especialidad:</label>
        <asp:TextBox ID="tEspecialidad" runat="server" BackColor="#CCCCCC" BorderColor="Black"></asp:TextBox>

      
            <asp:DropDownList ID="DropDownList1" runat="server" Width="500px">
                <asp:ListItem Selected="True">Activo</asp:ListItem>
                <asp:ListItem>Inactivo</asp:ListItem>
            </asp:DropDownList>
      


        <div class="buttons">
            <asp:Button ID="bAgregar1" runat="server" Text="Agregar" BackColor="#3399FF" BorderColor="Black" Font-Names="Arial Black" Font-Size="Medium" OnClick="bAgregar1_Click" />
            <asp:Button ID="bBorrar1" runat="server" Text="Borrar" BackColor="#3399FF" BorderColor="Black" Font-Names="Arial Black" Font-Size="Medium" OnClick="bBorrar1_Click" />
            <asp:Button ID="bModificar1" runat="server" Text="Modificar" BackColor="#3399FF" BorderColor="Black" Font-Names="Arial Black" Font-Size="Medium" OnClick="bModificar1_Click" />
            <asp:Button ID="bConsultar" runat="server" Text="Consultar" BackColor="#3399FF" BorderColor="Black" Font-Names="Arial Black" Font-Size="Medium" OnClick="bConsultar1_Click" />

            </div>
            <h1>Consultas</h1>
            <br />  
            <div class="grid-container2">
            <asp:GridView ID="GridView2" runat="server" Width="400px">
            </asp:GridView>
    </div>
    </form>
</body>
</html>
