<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Entregado.aspx.cs" Inherits="Aplicada.Entregado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="Estilos/Entregado.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <form runat="server" class="contenedorEntregar">

        <div class="buscarOrden">
				
            <input type="text" placeholder="INGRESAR NUMERO DE ORDEN" runat="server" id="txtorden"/>
            <a href="#" runat="server"  id="btnbuscarorden" onserverclick="BtnBuscarO">Buscar</a>
        
        </div>

        <div class="buscarOrden">
				
            <input type="text" placeholder="INGRESAR PATENTE" runat="server" id="txtpatente" />
            <a href="#" runat="server"  id="btnbuscarpatente" onserverclick="BtnBuscarP">Buscar</a>

        </div>

        <br />
        <br />


        <div class="titulo">

            <h2 id="labeltitulo" runat="server">DATOS DEL PROPIETARIO Y VEHICULO</h2>

        </div>


        <div class="datosEntregar">

            <div class="itemm">

                <asp:Label CssClass="label" ID="Nombre" runat="server" Text="Nombre: "></asp:Label>
                <asp:Label CssClass="label" ID="lblNombre" runat="server" Text="------"></asp:Label><br />
            </div>
            
            <div class="itemm">

                <asp:Label CssClass="label" ID="DNI" runat="server" Text="DNI: "></asp:Label>
                <asp:Label CssClass="label" ID="lblDNI" runat="server" Text="------"></asp:Label><br />
            
            </div>
            
            <div class="itemm">
            
                <asp:Label CssClass="label" ID="Patente" runat="server" Text="Patente: "></asp:Label>
                <asp:Label CssClass="label" ID="lblPatente" runat="server" Text="------"></asp:Label><br />

            </div>

            <div class="itemm">

                <asp:Label CssClass="label" ID="Marca" runat="server" Text="Marca: "></asp:Label>
                <asp:Label CssClass="label" ID="lblMarca" runat="server" Text="------"></asp:Label><br />

            </div>
            
            <div class="itemm">
                <asp:Label CssClass="label" ID="Modelo" runat="server" Text="Modelo: "></asp:Label>
                <asp:Label CssClass="label" ID="lblModelo" runat="server" Text="------"></asp:Label><br />
            
            </div>

            <div class="itemm">
                
                <asp:Label CssClass="label" ID="Estado" runat="server" Text="Estado: "></asp:Label>
                <asp:Label CssClass="label" ID="lblEstado" runat="server" Text="------"></asp:Label>

            </div>

        </div>


        <div class="botones">

            <a href="#" runat="server" class="btnEntregar" onserverclick="btnEntregar">Entregar</a>

        </div>

    </form>

</asp:Content>
