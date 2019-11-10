<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CargaDetalle.aspx.cs" Inherits="Aplicada.CargaDetalle" %>
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

            <div class="arribaCargarDetalle">

                <input type="text" runat="server" placeholder="INGRESAR NUMERO DE ORDEN" id="txtidorden"/>
                <a href="#" runat="server" class="guardarCambios" onserverclick="BtnBuscar">Buscar Datos</a> <%--//onserverclick="CargarServicios"--%>

            </div>

            <div class="contenedor1">

                <div class="contenedorServicios">
           
                    <div class="divaux">

                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="GridView1" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">

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
                      
                   
                    <asp:Label ID="lblpreciototal" runat="server" Text="Precio Total: ">
                        
                        <asp:Label ID="lblprecio" runat="server" Text="0" Visible="false"></asp:Label>

                    </asp:Label>
                
                </div>

                <div class="contenedor2">
			
                    <div class="vehiculo">

                        <div class="inputbtn">
				
                            <asp:Label ID="Label4" runat="server" Text="Patente: "></asp:Label>
                            <input type="text" runat="server" id="txtpatente" disabled>

                        </div>
				        
                        <div class="inputbtn">
    
                            <asp:Label ID="Label5" runat="server" Text="Modelo: "></asp:Label>
                            <input type="text" runat="server" id="txtmodelo" disabled visible="true">

                        </div>
                                              
                        <div class="drop">   

                            <%-- Aqui empieza el drop --%>

                            <asp:DropDownList ID="Dmodelo" CssClass="Dmodelo" runat="server" DataSourceID="DMarca" DataTextField="nombre" DataValueField="id_marca" AutoPostBack="True" Visible="false"></asp:DropDownList>
                        
                            <asp:SqlDataSource ID="DMarca" runat="server" ConnectionString="<%$ ConnectionStrings:aplicadaBDConnectionString %>" SelectCommand="SELECT DISTINCT [nombre], [id_marca] FROM [marca]"></asp:SqlDataSource>

                            <asp:DropDownList ID="modelito" CssClass="modelito" runat="server" DataSourceID="Dmodelado" DataTextField="nombre" DataValueField="id_modelo" Visible="false"></asp:DropDownList>

                            <asp:SqlDataSource ID="Dmodelado" runat="server" ConnectionString="<%$ ConnectionStrings:aplicadaBDConnectionString %>" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT DISTINCT * FROM [modelo] WHERE ([id_marca] = @id_marca)">
                            
                                <SelectParameters>
                              
                                    <asp:ControlParameter ControlID="Dmodelo" Name="id_marca" PropertyName="SelectedValue" Type="Int32" />
                          
                                    </SelectParameters>

                            </asp:SqlDataSource>

                            <%-- Aqui termina el Drops --%>

                        </div>

                        <div class="inputbtn">
                            
                            <asp:Label ID="Label6" runat="server" Text="Marca: "></asp:Label>
                            <input type="text" runat="server" id="txtmarca" disabled visible="true">
                        
                        </div>
                        
                        <div class="inputbtn">
                            
                            <asp:Label ID="Label7" runat="server" Text="Año: "></asp:Label>
                            <input type="text" runat="server" id="txtaño" disabled>

                        </div>

                        <div class="inputbtn">
                            
                            <asp:Label ID="Label8" runat="server" Text="DNI: "></asp:Label>
                            <input type="text" id="txtdni" runat="server" disabled>

                        </div>

                    </div>

                    <div class="duenio">


                        <div class="inputbtn">

                            <asp:Label ID="Label9" runat="server" Text="Apellido: "></asp:Label>				
                            <input type="text" id="txtapellido" runat="server" disabled>
    
                        </div>
                        
                        <div class="inputbtn">
                            
                            <asp:Label ID="Label10" runat="server" Text="Nombre: "></asp:Label>				
                            <input type="text" id="txtnombre" runat="server" disabled>
                        
                        </div>
                        
                        <div class="inputbtn">
                        
                            <asp:Label ID="Label11" runat="server" Text="Telefono: "></asp:Label>				
                            <input type="text" id="txttelefono" runat="server" disabled>
                        
                        </div>

                        <div class="inputbtn">
    
                            <asp:Label ID="Label12" runat="server" Text="E-Mail: "></asp:Label>				
                            <input type="text" id="txtemail" runat="server" disabled>
                        
                        </div>
                    </div>

                </div>

            </div>

            <div class="btnGuardar">
		
                <a href="#" class="guardarCambios">Imprimir</a>
                <a href="#" class="guardarCambios" runat="server" onserverclick="Avanzar">Pasar a taller</a> 

            </div>

        </form>
</asp:Content>
