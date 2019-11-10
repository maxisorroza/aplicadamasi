<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="Aplicada.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="Estilos/Reportes.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form id="form1" runat="server" class="FormDetalleReporte">
        <div class="contenedor">
            <h2>Reportes para generar</h2>
        <div class="contenidoprincipal">
            
            <h3>Reportes de Stock</h3>
            <input type="text" runat="server" id="txtinput" placeholder="Agrege Marca o Producto"  visible="true">
            <a href="#" class="btnReport" runat="server" id="LST" onserverclick="PDFLST">Lista Stock TOTAL</a>
            <a href="#" class="btnReport" runat="server" id="LSM" onserverclick="PDFLSM">Lista Stock MARCA</a>
            <a href="#" class="btnReport" runat="server" id="LSP" onserverclick="PDFLSP">Lista Stock PRODUCTO</a>
            
        </div>

            <div class="contenidoprincipal">
            
            <h3>Reportes por tipo de pago</h3>

                <asp:DropDownList ID="DropMetododePago" runat="server" CssClass="modelito"></asp:DropDownList>
            <a href="#" class="btnReport" runat="server" id="PTP" onserverclick="PDFPTP">Por tipo de Pago</a>
 
        </div>

            <div class="contenidoprincipal">
            
            <h3>Reportes por tipo Cliente</h3>

             <input type="text" runat="server" id="txtdni" placeholder="Coloque DNI"  visible="true">   
            
                <input type="date" runat="server" id="txtfechainicio" placeholder="Fecha de Inicio"  visible="true">   
                <input type="date" runat="server" id="txtfechafin" placeholder="Fecha de Finalizacion"  visible="true">  
                <a href="#" class="btnReport" runat="server" id="PP" onserverclick="PDFPP">Por Patente</a>
        </div>

            <div class="contenidoprincipal">
            
            <h3>Reportes por tipo Empleado</h3>

                      
                    <asp:DropDownList ID="DropTipodeEmpleados" runat="server" CssClass="modelito" DataSourceID="tipodeempelados" DataTextField="detalle" DataValueField="id_tipo"></asp:DropDownList> 
                <asp:SqlDataSource ID="tipodeempelados" runat="server" ConnectionString="<%$ ConnectionStrings:aplicadaBDConnectionString %>" SelectCommand="SELECT * FROM [tipo] WHERE (([id_tipo] = 7) OR ([id_tipo] = 6) OR ([id_tipo] = 8))">
                </asp:SqlDataSource>
                   <input type="date" runat="server" id="FechaInicios" placeholder="Fecha de Inicio"  visible="true">   
                <input type="date" runat="server" id="FechaFinale" placeholder="Fecha de Finalizacion"  visible="true">  
                <a href="#" class="btnReport" runat="server" id="RPE" onserverclick="PDFRPE">Realizar</a>
        </div





</div>
    </form>

</asp:Content>
