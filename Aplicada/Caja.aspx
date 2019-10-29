<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Caja.aspx.cs" Inherits="Aplicada.Caja" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" class="FormDetalle">
    

    <div class="contenedorCaja">
		
			<div class="buscarOrden">
				
				<input type="text" placeholder="INGRESAR NUMERO DE ORDEN" runat="server" id="txtorden"/>
				<a href="#" runat="server" onserverclick="BtnBuscarO" id="btnbuscarorden">Buscar</a>
                <%--<asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>--%>
			</div>

			<%--<div class="buscarOrden">
				
				<input type="text" placeholder="INGRESAR DNI DEL CLIENTE"/>
				<a href="#" runat="server" onserverclick="BtnBuscar">Buscar</a>

			</div>--%>

			<div class="buscarOrden">
				
				<input type="text" placeholder="INGRESAR PATENTE" runat="server" id="txtpatente" />
				<a href="#" runat="server" onserverclick="BtnBuscarP" id="btnbuscarpatente">Buscar</a>

			</div>

			<!-- PONER DROPDOWN LIST PARA PONER LOS TIPOS DE PAGO -->
			
       
				
            <div class="orden">
				
<%--				
				<div class="datos">

					    <asp:Label ID="lblpatente" runat="server" Text="PATENTE: "></asp:Label>
                        <asp:Label ID="lblmodelo" runat="server" Text="MODELO: "></asp:Label>		
                   
                <asp:Label ID="lblprecio" runat="server" Text="PRECIO TOTAL: "></asp:Label>				

				</div>

				<div class="servicios">

					<div class="divaux">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="gridTaller">
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
                        
                    </Columns>

                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />


                        </asp:GridView>
                      </div>		
                    

				</div>
  
                <div class="datos" id="divmetodo" runat="server" visible="false"> 

					    <asp:Label ID="Label1" runat="server" Text="METODO DE PAGO: "><asp:DropDownList ID="DropMetododePago" runat="server"></asp:DropDownList></asp:Label>	
                        		
				</div>

				--%>

                <div class="cabecera">
					
					<div class="logo">

						<h2>APLICADA</h2>
						
					</div>

					<div class="numeroOrden">

                        <asp:Label ID="NOrden" runat="server" Text="Numero Oden"></asp:Label>		

					</div>

                </div>

                <div class="datosFecha">
                    
                    <br />
                    <br />
                    <br />
                    <asp:Label ID="fecha" runat="server" Text="Fecha"></asp:Label>
                    <br />
                    <br />
                    <br />
                	
                </div>

                <div class="datosPropietarios">

                    <div>
                    <asp:Label runat="server" Text="Nombre Titular: "></asp:Label>
                    <asp:Label ID="NTitular" runat="server" Text="Nombre Titular"></asp:Label>
                    </div>

                    <div>                    
                    <asp:Label runat="server" Text="DNI: "></asp:Label>
                    <asp:Label ID="DNI" runat="server" Text="DNI"></asp:Label>
                    </div>
                    

                    <div>                    
                    <asp:Label runat="server" Text="Patente: "></asp:Label>
                    <asp:Label ID="lblpatente" runat="server" Text="Modelo"></asp:Label>
                    </div>

                    <div>                    
                    <asp:Label runat="server" Text="Modelo: "></asp:Label>
                    <asp:Label ID="lblmodelo" runat="server" Text="Modelo"></asp:Label>
                    </div>
                	

                </div>

                <div class="grid">

                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="gridTaller" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">

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

                <div>

                    <br />
                    <br />
                    <br />
                    <asp:Label runat="server" Text="Precio Total: "></asp:Label>
                    <asp:Label ID="lblprecio" runat="server" Text="$$$"></asp:Label>
                    <br />
                    <br />
                    <br />

                </div>

                <div id="divmetodo" class="metodosPago" runat="server" visible="false">
                    
                    <asp:DropDownList ID="DropMetododePago" runat="server" CssClass="drop modelito"></asp:DropDownList>

                </div>

			</div>
                
        <div class="btnTaller">
				
				<a href="#">Imprimir</a>
				<a href="#" runat="server" onserverclick="BtnCobrar">Cobrar</a>

			</div>
			</div>
</form>
</asp:Content>
