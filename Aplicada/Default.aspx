<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Aplicada.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="Estilos/generales.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form runat="server">
    
        <div class="arriba">

            <h2 class="titulo">SORROZA´S SERVICE</h2>
            <p class="parrafo">Somos una empresa dedicada a buscar la mejor performance en su vehiculo con la mejor atencion y la mano de obra mas profesional ahre.</p>	

        </div>

        <div class="medio">

            <h2 class="titulo">La mejor atencion para su vehiculo</h2>

			<div class="services">

				<div class="item">
					
					<img src="img/s1.svg" alt="">
					<p>Emegencias</p>

				</div>

				<div class="item">
					
					<img src="img/s2.svg" alt="">
					<p>Atencion Personalizada</p>

				</div>
				
				<div class="item">
					
					<img src="img/s3.svg" alt="">
					<p>Profesionales</p>

				</div>
				
				<div class="item">
					
					<img src="img/s4.svg" alt="">
					<p>Listos para cualquier situacion</p>

				</div>
				
			</div>

        </div>
    
        <div  class="abajo">
        		
        		<h2>GRACIAS POR ELEGIRNOS!!</h2>

        </div>

        <footer>
        	
			<p>TODOS LOS DERECHOS RESERVADOS MAXI ®</p>

        </footer>
    
    </form>
</asp:Content>
