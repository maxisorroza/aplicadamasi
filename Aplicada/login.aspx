<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Aplicada.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" class="FormDetalleTaller">

        <div class="login">

            <h2>Iniciar Sesion</h2>

            <div class="form">

                <input type="text" placeholder="Usuario o correo electronico" runat="server" id="txtemail"/>
                <input type="password" placeholder="Contraseña" runat="server" id="txtcontraseña"/>

            </div>

            <a href="#" class="btnLogin" runat="server" id="btnLogin" onserverclick="btnLogin_ServerClick">Acceder</a>

        </div>

    </form>

</asp:Content>
