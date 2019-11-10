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
                <asp:DropDownList ID="DropTipoServicio" CssClass="modelito" runat="server" DataSourceID="Tiposdeservicios" DataTextField="tipodeservicio" DataValueField="id" AutoPostBack="True" OnSelectedIndexChanged="DropTipoServicio_SelectedIndexChanged" Enabled="False"></asp:DropDownList>
                <asp:EntityDataSource ID="Tiposdeservicios" runat="server" ConnectionString="name=aplicadaBDEntities" DefaultContainerName="aplicadaBDEntities" EnableFlattening="False" EntitySetName="tiposervicio" EntityTypeFilter="tiposervicio" Select="it.[id], it.[tipodeservicio]"></asp:EntityDataSource>
                <br />
                <br />
                <asp:DropDownList ID="DropServicio" CssClass="modelito" runat="server" Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="CambioElValordeldrop"></asp:DropDownList>
                <br />
                <br />

                <div>
                    <asp:Label ID="Label4" runat="server" Text="Cantidad: "></asp:Label>
                   <asp:TextBox ID="txtcantidad" runat="server"  AutoPostBack="true" OnTextChanged="Eventotest" onkeypress="javascript:return solonumeros(event)" CssClass="inputCantidad" Enabled="false" Text="1"></asp:TextBox>
                </div>
                 
                <%--<input type="number" runat="server" id="txtcantidad" value="1" visible="false" onkeypress="Eventotest" onchange="Eventotest"/>--%>
                <br />
                <div>
                    <asp:Label ID="Label5" runat="server" Text="Precio por cantidad: "></asp:Label>
                    <input type="number" runat="server" id="txtprecioporcantidad" value="0" visible="false" disabled="disabled" class="inputCantidad" />
                </div>
                <br />
                
            </div>


        <a href="#" runat="server" visible="false" class="guardarCambios" id="btnServicios" onserverclick="CargarServicios">Guardar</a>
            <br />
            <br />


            <div class="divaux">
                <asp:GridView ID="GridView2" CssClass="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                        <asp:BoundField DataField="cantidad" HeaderText="Cantidad" >
                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />

                            </asp:BoundField>   
                         <asp:BoundField DataField="total" HeaderText="Total ($)" >
                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />

                            </asp:BoundField>
                           

                        
                        
                        <asp:CommandField SelectText="Eliminar" ButtonType="Button" ShowSelectButton="true" />
                        
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    
               
                </asp:GridView>

                
            </div>
            <br />
            <br />
            <asp:Label ID="lblpreciototal" runat="server" Text="Precio Total: ">
                <asp:Label ID="lblprecio" runat="server" Text="0" Visible="false"></asp:Label>

            </asp:Label>
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
                    <%-- Aqui termina el Drops --%>
                </div>



				<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:aplicadaBDConnectionString %>" SelectCommand="SELECT * FROM [modelo] WHERE ([id_marca] = @id_marca)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="Dmarca" Name="id_marca" PropertyName="SelectedValue" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>



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
         <asp:SqlDataSource ID="DMecanicos" runat="server" ConnectionString="<%$ ConnectionStrings:aplicadaBDConnectionString %>" SelectCommand="SELECT [nombreyapellido], [id_empleado], [id_tipo] FROM [empleado] WHERE ([id_tipo] = 6) AND ([disponibilidad] = 0)"></asp:SqlDataSource>
        <a href="#" class="guardarCambios" runat="server"  id="btnpasartaller" visible="false" onserverclick="btnpasarataller_ServerClick">Pasar a taller</a>
		

	</div>

 </form>   
</asp:Content>
