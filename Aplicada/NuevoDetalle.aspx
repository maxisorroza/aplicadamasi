<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NuevoDetalle.aspx.cs" Inherits="Aplicada.NuevoDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <form id="form1" runat="server" class="FormDetalle">

        <div class="StockError" id="StockError" runat="server" visible="false">

            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
             
        </div>

        <div class="StockWarning" id="StockWarning" runat="server" visible="false">

            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>

        </div>

        <div class="StockWarning" id="NoAuto" runat="server" visible="false">

            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>

        </div>
 <div class="contenedor1">

		<div class="contenedorServicios">
           
            <div class="divaux drop">
                <asp:DropDownList ID="DropTipoServicio" CssClass="modelito" runat="server" DataSourceID="Típoservicios" DataTextField="tipodeservicio" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="DropTipoServicio_SelectedIndexChanged"></asp:DropDownList>
               <asp:EntityDataSource ID="Típoservicios" runat="server" ConnectionString="name=aplicadaBDEntities" DefaultContainerName="aplicadaBDEntities" EnableFlattening="False" EntitySetName="tiposervicio"></asp:EntityDataSource>
                <br />
                <br />
                <asp:DropDownList ID="DropServicio" CssClass="modelito" runat="server" Visible="false"></asp:DropDownList>
                <br />
                <br />
               <input type="number" runat="server" id="txtcantidad" value="1" visible="false"/>
                <br />
                <br />
                
            </div>


        <a href="#" runat="server" visible="false" class="guardarCambios" id="btnServicios" onserverclick="CargarServicios">Guardar</a>
            <br />
            <br />


            <div class="divaux">
                <asp:GridView ID="GridView2" CssClass="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                            <asp:BoundField DataField="detalle" HeaderText="Detalle" >

                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />

                            </asp:BoundField>

                            <asp:BoundField DataField="precio" HeaderText="Precio ($)" > 

                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />

                            </asp:BoundField>
                            <asp:BoundField DataField="total" HeaderText="Total ($)" >
                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />

                            </asp:BoundField>
                            <asp:BoundField DataField="cantidad" HeaderText="Cantidad" >
                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />

                            </asp:BoundField>

                        
                        
                        <asp:CommandField SelectText="Eliminar" ButtonType="Button" ShowSelectButton="true"  />
                        
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />
                    
               
                </asp:GridView>

                
            </div>
            <asp:Label ID="lblpreciototal" runat="server" Text="Preciototal ">
                <asp:Label ID="lblprecio" runat="server" Text="0" Visible="true"></asp:Label>
            </asp:Label>
            <br />
            <br />
            <br />
            <br />
            <a href="#" class="guardarCambios" runat="server" onserverclick="Avanzar" id="btnfinalizar" visible="false">Finalizar Presupuesto</a>
		</div>		

		<div class="contenedor2">
			
			<div class="vehiculo">

        		<div class="inputbtn">
				
				    <input type="text" runat="server" id="txtpatente" placeholder="Ingresar patente"/>  
				    <a href="#" runat="server" onserverclick="Unnamed_ServerClick1">Buscar</a>

			    </div>
				
				<input type="text" runat="server" id="txtmodelo" placeholder="Modelo" disabled visible="true">

                <div class="drop">   
                    <%-- Aqui empieza el drop --%>
                    <asp:DropDownList ID="Dmarca" CssClass="modelito" runat="server" DataSourceID="EMarca" DataTextField="nombre" DataValueField="id_marca" AutoPostBack="True" Visible="False"></asp:DropDownList>
                    <asp:EntityDataSource ID="EMarca" runat="server" ConnectionString="name=aplicadaBDEntities" DefaultContainerName="aplicadaBDEntities" EnableFlattening="False" EntitySetName="marca"></asp:EntityDataSource>


				



                    <asp:DropDownList ID="Dmodelo" CssClass="modelito" runat="server" DataSourceID="SqlDataSource1" DataTextField="nombre" DataValueField="id_modelo" Visible="False"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:aplicadaBDConnectionString %>" SelectCommand="SELECT * FROM [modelo] WHERE ([id_marca] = @id_marca)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="Dmarca" Name="id_marca" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                    <%-- Aqui termina el Drops --%>
                </div>



				



				<input type="text" runat="server" id="txtmarca" placeholder="Marca" disabled visible="true">
				<input type="text" runat="server" id="txtaño" placeholder="Año" disabled>

				<div class="inputbtn">
					<input type="text" placeholder="Titular Dni" id="txtdni" runat="server" >
				<a href="#" runat="server" onserverclick="BuscarCliente" visible="false" id="btnAgregarcliente">Agregar </a>
                 <a href="#" runat="server"  visible="false" id="A1" onserverclick="BuscarCliente">Modificar </a>

			</div>

			</div>

			<div class="duenio">
				
				<input type="text" placeholder="Apellido" id="txtapellido" runat="server" disabled="disabled">
				<input type="text" placeholder="Nombre" id="txtnombre" runat="server" disabled>
				
				<input type="text" placeholder="Telefono" id="txttelefono" runat="server" disabled>
				<input type="text" placeholder="E-Mail" id="txtemail" runat="server" disabled> 
                <a href="#" runat="server"  visible="false" id="btnGuardar" onserverclick="CargaryAvanzar" class="guardarCambios">Guardar</a>

			</div>

		</div>

	</div>

	<div class="btnGuardar">
		
		<a href="#" class="guardarCambios" runat="server" onserverclick="Cancelar">Cancelar</a>
		<asp:DropDownList ID="DropMecanicosDispo" runat="server" DataSourceID="DMecanicos" DataTextField="nombreyapellido" DataValueField="id_empleado" CssClass="select modelitoo" ></asp:DropDownList>
        <asp:SqlDataSource ID="DMecanicos" runat="server" ConnectionString="<%$ ConnectionStrings:aplicadaBDConnectionString %>" SelectCommand="SELECT [nombreyapellido], [id_empleado], [id_tipo] FROM [empleado] WHERE ([id_tipo] = 1) AND ([disponibilidad] = 0)"></asp:SqlDataSource>
        <a href="#" class="guardarCambios" runat="server"  id="btnpasartaller" visible="false" onserverclick="btnpasarataller_ServerClick">Pasar a taller</a>
		

	</div>

 </form> 
</asp:Content>
