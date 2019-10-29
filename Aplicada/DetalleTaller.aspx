<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DetalleTaller.aspx.cs" Inherits="Aplicada.DetalleTaller" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" class="FormDetalleTaller">

        <div class="ContenedorTalleristas">
    
            <asp:DropDownList ID="DropMecanicosDispo" runat="server" DataSourceID="DMecanicos" DataTextField="nombreyapellido" DataValueField="id_empleado" CssClass="select" ></asp:DropDownList>
         <asp:SqlDataSource ID="DMecanicos" runat="server" ConnectionString="<%$ ConnectionStrings:aplicadaBDConnectionString %>" SelectCommand="SELECT [nombreyapellido], [id_empleado], [id_tipo] FROM [empleado] WHERE ([id_tipo] = 1) AND ([disponibilidad] = 0)"></asp:SqlDataSource>

            <%--<asp:DropDownList ID="DropDownList1" runat="server" CssClass="select"></asp:DropDownList>--%>
            <input type="password" placeholder="ingresar contraseña para confirmar"  runat="server" id="txtpwd"/>
    
        </div>

        <div class="btnGuardar">
		
            <a href="NuevoDetalle.aspx" class="guardarCambios" runat="server" id="btnvolveraorden">Nueva Orden/Detalle</a>
            <a href="#" class="guardarCambios" runat="server" id="btnpasarataller" onserverclick="btnpasarataller_ServerClick">Pasar a Taller</a>

        </div>

    </form>
</asp:Content>
