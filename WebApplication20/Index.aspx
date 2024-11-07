<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApplication20.Index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>AGREGAR PRODUCTOS</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label for="txtNombre">Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" Required="True"></asp:TextBox>
            <br />

            <label for="txtCantidad">Cantidad:</label>
            <asp:TextBox ID="txtCantidad" runat="server" Required="True"></asp:TextBox>
            <br />

            <label for="txtCosto">Costo:</label>
            <asp:TextBox ID="txtCosto" runat="server" Required="True"></asp:TextBox>
            <br />

            <label for="fileImagen">Imagen:</label>
            <asp:FileUpload ID="fileImagen" runat="server" />
            <br />

            <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar Producto" OnClick="btnAgregarProducto_Click" />

            <hr />

            <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvProductos_RowDataBound">
    <Columns>
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
        <asp:BoundField DataField="Costo" HeaderText="Costo" SortExpression="Costo" />

        
        <asp:TemplateField HeaderText="Imagen">
            <ItemTemplate>
                <asp:Image ID="imgProducto" runat="server" Width="100px" Height="100px" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>


        </div>
    </form>
</body>
</html>
