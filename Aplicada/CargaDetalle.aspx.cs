using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplicada
{
    public partial class CargaDetalle : System.Web.UI.Page
    {
        public empleado LogEmpleado
        {
            get
            {
                if (Session["Empleado"] == null)
                    Session["Empleado"] = new empleado();
                return (empleado)Session["Empleado"];
            }
            set
            {
                Session["Empleado"] = value;
            }
        }
        public orden OrdenActual
        {
            get
            {
                if (Session["Orden"] == null)
                    Session["Orden"] = new orden();
                return (orden)Session["Orden"];
            }
            set
            {
                Session["Orden"] = value;
            }
        }

        public List<stock> Lstock
        {
            get
            {
                if (Session["Lstock"] == null)
                    Session["Lstock"] = new List<stock>();
                return (List<stock>)Session["Lstock"];
            }
            set
            {
                Session["Lstock"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (LogEmpleado.id_tipo != 7)
                {
                    Server.Transfer("Default.aspx");
                }




            }
        }

        protected void BtnBuscar(object sender, EventArgs e)
        {
            Buscadores bus = new Buscadores();
            if (txtidorden.Value != "")
            {
                orden oOrden = bus.buscarorden(int.Parse(txtidorden.Value));
                ordenestado Oordenestado = new ordenestado();

                if (oOrden != null)
                {
                    Oordenestado = bus.buscarvestadoorden(oOrden.id_orden);
                }

                if (oOrden != null)
                {
                    if ((Oordenestado == null) || (Oordenestado.estado == null) || (Oordenestado.estado == 0) || (Oordenestado.estado == 5))
                    {

                        //Validar orden estado 2 o superior aca? si?
                        NoAuto.Visible = false;
                        vehiculo Ovehiculo = bus.buscarvehiculoid(int.Parse(oOrden.id_vehiculo.ToString()));
                        cliente oCliente = bus.ocliente(Ovehiculo);
                        modelo omodelo = bus.buscarmodelo(Ovehiculo);
                        Ovehiculo.modelo = omodelo;
                        marca omarca = bus.buscarmarca(Ovehiculo.modelo);
                        Ovehiculo.modelo.marca = omarca;
                        Ovehiculo.cliente = oCliente;
                        oOrden.vehiculo = Ovehiculo;

                        txtpatente.Value = oOrden.vehiculo.patente;
                        txtmodelo.Value = oOrden.vehiculo.modelo.nombre;
                        txtmarca.Value = oOrden.vehiculo.modelo.marca.nombre;

                        txtaño.Value = oOrden.vehiculo.annio;
                        string[] separadas;
                        if (Ovehiculo.cliente.dni != null)
                        {
                            separadas = Ovehiculo.cliente.nombre.Split(' ');
                            txtdni.Value = Ovehiculo.cliente.dni;
                            txtapellido.Value = separadas[0];
                            txtnombre.Value = separadas[1];
                            txttelefono.Value = Ovehiculo.cliente.telefono;
                            txtemail.Value = Ovehiculo.cliente.email;
                        }
                        OrdenActual = oOrden;
                        CargarGrid(oOrden);
                        PDFESTADOCERO();
                    }
                    else
                    {
                        Label3.Text = "EL VEHICULO YA POSEE UNA ORDEN ACTIVA";
                        NoAuto.Visible = true;
                    }
                }
                else
                {
                    Label3.Text = "ORDEN NO EXISTENTE";
                    NoAuto.Visible = true;
                }
            }
        }

        private void CargarGrid(orden oOrden)
        {
            StockError.Visible = false;
            StockWarning.Visible = false;

            Buscadores bus = new Buscadores(); List<ordenservicio> Lidservidcios = new List<ordenservicio>();
            Lidservidcios = bus.buscarlistaid(oOrden.id_orden);
            List<servicio> Lservicios = ObtenerServicios(Lidservidcios);
            DataTable dtable = new DataTable();
            dtable.Columns.AddRange(new DataColumn[4] { new DataColumn("Detalle"), new DataColumn("Precio"), new DataColumn("Total"), new DataColumn("Cantidad") });
            int preciototal = 0;
            foreach (ordenservicio o in Lidservidcios)
            {

                servicio oservicio = Lservicios.Find(x => x.id_servicios == o.id_servicio);
                int cantidad = o.cantidad ?? default(int);
                string total = (double.Parse(oservicio.precio) * Convert.ToDouble(cantidad)).ToString();
                dtable.Rows.Add(oservicio.detalle, oservicio.precio, total, o.cantidad);
                preciototal = preciototal + int.Parse(total);
            }
            //lblprecio.Text = preciototal.ToString(); <--- poner label para el total
            lblprecio.Text = preciototal.ToString();
            Lservicios = ObtenerServicios(Lidservidcios);
            List<serviciostock> Lserstock = Lserviciostock(Lservicios);
            List<stock> Nstock = Lstockuso(Lserstock);
            foreach (stock ostock in Nstock)
            {
                Lstock.Add(ostock);
                if (int.Parse(ostock.cantidad) <= int.Parse(ostock.minimo))
                {
                    StockError.Visible = true;
                    Label1.Text = "¡ATENCION! EL STOCK ES MENOR AL MINIMO: " + ostock.detalle;

                }
                if ((int.Parse(ostock.cantidad) >= int.Parse(ostock.minimo)) && (int.Parse(ostock.cantidad) <= (int.Parse(ostock.minimo) + 5)) && (StockError.Visible == false))
                {
                    StockWarning.Visible = true;
                    Label2.Text = "¡ATENCION! EL STOCK ESTA CERCANO AL MINIMO: " + ostock.detalle;

                }
            }


            GridView2.DataSource = dtable;
            GridView2.DataBind();
        }

        private List<servicio> ObtenerServicios(List<ordenservicio> Lidservidcios)
        {
            List<servicio> Lservicio = new List<servicio>();
            Buscadores bus = new Buscadores();
            foreach (ordenservicio idservicios in Lidservidcios)
            {
                servicio oservicio = bus.buscarservicio(idservicios.id_servicio);
                Lservicio.Add(oservicio);
            }
            return Lservicio;


        }



        protected void Avanzar(object sender, EventArgs e)
        {
            if ((txtpatente.Value != "") && (txtdni.Value != "") && (StockError.Visible == false))
            {


                Buscadores bus = new Buscadores();
                cliente ocliente = bus.oclientedni(txtdni.Value);
                vehiculo ovehiculo = bus.buscarvehiculo(txtpatente.Value);
                cliente oclientes = bus.ocliente(ovehiculo);

                if ((ovehiculo != null) && (ovehiculo.id_cliente != null) && (ocliente != null) && (ovehiculo.id_cliente == ocliente.id))
                {

                    Server.Transfer("DetalleTaller.aspx");

                }
                else
                {


                }

            }

        }
        public List<stock> Lstockuso(List<serviciostock> Lstockservi)
        {
            Buscadores bus = new Buscadores();
            List<stock> Lstock = bus.Lstock();
            List<stock> stockactivo = new List<stock>();
            foreach (stock Stock in Lstock)
            {
                foreach (serviciostock Servistock in Lstockservi)
                {
                    if (Stock.id_stock == Servistock.id_stock)
                    {
                        stockactivo.Add(Stock);

                    }

                }
            }

            return stockactivo;

        }
        public List<serviciostock> Lserviciostock(List<servicio> Lservicios)
        {
            Buscadores bus = new Buscadores();
            List<serviciostock> Lserviciostocks = bus.Lstockservi();
            List<serviciostock> NLserviciostock = new List<serviciostock>();
            foreach (servicio x in Lservicios)
            {
                foreach (serviciostock t in Lserviciostocks)
                {
                    if (x.id_servicios == t.id_servicio)
                    {
                        NLserviciostock.Add(t);

                    }

                }

            }


            return NLserviciostock;

        }

        public void PDFESTADOCERO()
        {
            Buscadores bus = new Buscadores();
            var doc = new iTextSharp.text.Document(PageSize.A4.Rotate());
            string path = Server.MapPath("~");
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path + "/Presupuesto01.pdf", FileMode.Create));

            doc.Open();

            doc.AddTitle("Presupuesto");

            Paragraph p = new Paragraph("Presupuesto");
            p.Alignment = 1;
            p.Font.Size = 24;
            doc.Add(p);
            PdfContentByte cb = writer.DirectContent;
            cb.MoveTo(100, 0);
            cb.LineTo(0, 0);
            cb.Stroke();
            doc.Add(Chunk.NEWLINE);
            Paragraph d = new Paragraph("Orden N°: " + OrdenActual.id_orden);
            d.Alignment = 2;
            d.Font.Size = 12;
            doc.Add(d);

            

            Paragraph fe = new Paragraph(DateTime.Now.ToString("dd-MM-yyyy"));
            fe.Alignment = 2;
            fe.Font.Size = 12;
            doc.Add(fe);

            Paragraph op = new Paragraph("Operario: " + LogEmpleado.nombreyapellido);
            op.Alignment = 2;
            op.Font.Size = 12;
            doc.Add(op);
            doc.Add(Chunk.NEWLINE);

            

            vehiculo ovehiculo = bus.buscarvehiculo(txtpatente.Value);
            cliente ocliente = bus.ocliente(ovehiculo);
            modelo omarca = bus.buscarmodelo(ovehiculo);
            marca omodelo = bus.buscarmarca(omarca);

            Paragraph Cliente = new Paragraph("Apellido y Nombre: " + ocliente.nombre + "                 DNI: " + ocliente.dni + "            Telefono: " + ocliente.telefono + "        Correo Electronico: " + ocliente.email);
            doc.Add(Cliente);
            doc.Add(Chunk.NEWLINE);
            Paragraph Vehiculo = new Paragraph("Patente: " + ovehiculo.patente + "          Modelo: " + omodelo.nombre + "       Marca: " + omarca.nombre);
            doc.Add(Vehiculo);
            doc.Add(Chunk.NEWLINE);


            if (GridView2.Rows.Count != 0)
            {

            
            PdfPTable pdfTable = new PdfPTable(GridView2.HeaderRow.Cells.Count);

            foreach (TableCell headerCell in GridView2.HeaderRow.Cells)
            {
                PdfPCell pdfCell = new PdfPCell(new Phrase(headerCell.Text));
                pdfTable.AddCell(pdfCell);
            }

            foreach (GridViewRow gridViewRow in GridView2.Rows)
            {

                foreach (TableCell tableCell in gridViewRow.Cells)
                {
                    PdfPCell pdfCell = new PdfPCell(new Phrase(tableCell.Text));
                    pdfTable.AddCell(pdfCell);
                }
            }
            doc.Add(pdfTable);
            }
            Paragraph tt = new Paragraph("Total: $" + lblprecio.Text);
            tt.Alignment = 2;
            tt.Font.Size = 12;
            doc.Add(tt);
            doc.Add(Chunk.NEWLINE);

            doc.Close();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('Presupuesto01.pdf','_newtab');", true);
            //Response.Redirect("Presupuesto.pdf");

        }



    }
}