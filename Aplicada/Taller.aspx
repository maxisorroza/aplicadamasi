<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Taller.aspx.cs" Inherits="Aplicada.Taller" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server" class="FormDetalle">

        <div class="contenedor">
		
                <div class="orden">
				
				    <div class="datos">
                        <asp:Label ID="lblpatente" runat="server" Text="PATENTE: "></asp:Label>
                        <asp:Label ID="lblmodelo" runat="server" Text="MODELO: "></asp:Label>		

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
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="gridTaller">
                            <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="detalle" HeaderText="Producto Necesario" > 
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

                <div class="ContenedorTalleristas">
                  
                      <input type="password" placeholder="ingresar contraseña para confirmar"  runat="server" id="txtpwd"/>
    
                </div>

			    <div class="btnTaller">
				
				    <a href="#">Imprimir</a>
				    <a href="#" runat="server" id="btnaceptar" onserverclick="BtnAceptarTrabajo">Reparando</a>
				    <a href="#" runat="server" onserverclick="BtnTerminarTrabajo" id="btnfinalizar">Finalizar</a>

			    </div>

	    </div>

    </form>
</asp:Content>
