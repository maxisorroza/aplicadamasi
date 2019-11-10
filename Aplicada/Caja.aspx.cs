using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Aplicada
{
    public partial class Caja : System.Web.UI.Page
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
        public List<orden> LOrden
        {
            get
            {
                if (Session["orden"] == null)
                    Session["orden"] = new List<orden>();
                return (List<orden>)Session["orden"];
            }
            set
            {
                Session["orden"] = value;
            }
        }

        public orden Ordenn
        {
            get
            {
                if (Session["LaOrden"] == null)
                    Session["LaOrden"] = new orden();
                return (orden)Session["LaOrden"];
            }
            set
            {
                Session["LaOrden"] = value;
            }
        }
        public DataTable dt
        {
            get
            {
                if (Session["dt"] == null)
                    Session["dt"] = new DataTable();
                return (DataTable)Session["dt"];
            }
            set
            {
                Session["dt"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (LogEmpleado.id_tipo != 8)
            {
                Server.Transfer("Default.aspx");
            }
            fecha.Text = DateTime.Now.ToString("dd-MM-yyyy");
            Buscadores bus = new Buscadores();
            List<ordenestado> Lordenestado = bus.buscarListOrdenEstado(3);
            List<orden> Lorden = bus.buscarordeestado(Lordenestado);
            List<vehiculo> LVehiculo = bus.buscarordevehiculo(Lorden);
            LOrden = Lorden;


        }

        protected void BtnBuscarO(object sender, EventArgs e)
        {
            Buscadores bus = new Buscadores();
            lblmodelo.Text = "La patente ingresada no se encuentra para Cobrar";
            lblpatente.Text = "-";
            lblprecio.Text = "-";
            GridView1.DataSource = null;
            GridView1.DataBind();
            if (txtorden.Value != "")
            {
                txtpatente.Visible = false;
                btnbuscarpatente.Visible = false;
                foreach (orden oOrden in LOrden)
                {

                    if (int.Parse(txtorden.Value) == oOrden.id_orden)
                    {
                        Ordenn = oOrden;
                        lblpatente.Text = oOrden.vehiculo.patente;
                        cliente objcliente = bus.ocliente(oOrden.vehiculo);
                        NTitular.Text = objcliente.nombre;
                        DNI.Text = objcliente.dni;
                        modelo omodelo = bus.buscarmodelo(oOrden.vehiculo);
                        lblmodelo.Text = omodelo.nombre;
                        NOrden.Text = "N°Orden" + oOrden.id_orden.ToString();
                        CargarGrid(oOrden);

                    }

                }

            }


        }

        protected void BtnBuscarP(object sender, EventArgs e)
        {
            Buscadores bus = new Buscadores();
            lblmodelo.Text = "La patente ingresada no se encuentra para Cobrar";
            lblpatente.Text = "-";
            GridView1.DataSource = null;
            GridView1.DataBind();
            lblprecio.Text = "-";
            if (txtpatente.Value != "")
            {
                txtorden.Visible = false;
                btnbuscarorden.Visible = false;
                foreach (orden oOrden in LOrden)
                {
                    if (txtpatente.Value == oOrden.vehiculo.patente)
                    {
                        Ordenn = oOrden;
                        lblpatente.Text = oOrden.vehiculo.patente;
                        cliente objcliente = bus.ocliente(oOrden.vehiculo);
                        NTitular.Text = objcliente.nombre;
                        DNI.Text = objcliente.dni;
                        modelo omodelo = bus.buscarmodelo(oOrden.vehiculo);
                        lblmodelo.Text = omodelo.nombre;
                        NOrden.Text = "N°Orden" + oOrden.id_orden.ToString();
                        CargarGrid(oOrden);


                    }

                }

            }




        }


        private void MetodosdePago()
        {
            System.Web.UI.WebControls.ListItem i;
            i = new System.Web.UI.WebControls.ListItem("Tarjeta de Credito", "Tarjeta de Credito");
            DropMetododePago.Items.Add(i);
            i = new System.Web.UI.WebControls.ListItem("Tarjeta de Debito", "Tarjeta de Debito");
            DropMetododePago.Items.Add(i);
            i = new System.Web.UI.WebControls.ListItem("Efectivo", "Efectivo");
            DropMetododePago.Items.Add(i);
            divmetodo.Visible = true;
        }

        private void CargarGrid(orden oOrden)
        {

            MetodosdePago();
            Buscadores bus = new Buscadores();
            List<ordenservicio> Lidservidcios = new List<ordenservicio>();
            Lidservidcios = bus.buscarlistaid(oOrden.id_orden);
            List<servicio> Lservicios = ObtenerServicios(Lidservidcios);
            DataTable dtable = new DataTable();
            dtable.Columns.AddRange(new DataColumn[4] { new DataColumn("Cantidad"), new DataColumn("Detalle"), new DataColumn("Precio"), new DataColumn("Total") });
            int preciototal = 0;
            foreach (ordenservicio o in Lidservidcios)
            {

                servicio oservicio = Lservicios.Find(x => x.id_servicios == o.id_servicio);
                int cantidad = o.cantidad ?? default(int);
                string total = (double.Parse(oservicio.precio) * Convert.ToDouble(cantidad)).ToString();
                dtable.Rows.Add(o.cantidad, oservicio.detalle, oservicio.precio, total);
                preciototal = preciototal + int.Parse(total);
            }
            //foreach (servicio x in Lservicios)
            //{
            //    a = a + int.Parse(x.precio);
            //}
            lblprecio.Text = preciototal.ToString();
            //GridView1.DataSource = Lservicios;
            dt = dtable;
            GridView1.DataSource = dtable;
            GridView1.DataBind();
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

        protected void BtnCobrar(object sender, EventArgs e)
        {

            using (aplicadaBDEntities DBF = new aplicadaBDEntities())
            {
                ordenestado oestado = (from q in DBF.ordenestado where q.id_orden == Ordenn.id_orden select q).First();
                oestado.estado = 4;
                oestado.fecha_cobrado = System.DateTime.Now;
                DBF.SaveChanges();
                orden oorden = (from q in DBF.orden where q.id_orden == Ordenn.id_orden select q).First();
                oorden.mpago = DropMetododePago.SelectedValue;
                DBF.SaveChanges();
                ordenempleado ordenemple = new ordenempleado
                {
                    id_orden = oorden.id_orden,
                    id_empleado = LogEmpleado.id_empleado,

                };
                DBF.ordenempleado.Add(ordenemple);
                DBF.SaveChanges();
                Server.Transfer("Default.aspx");


            }
        }

     

        public void PDFESTADOCERO()
        {

            Buscadores bus = new Buscadores();
            var doc = new iTextSharp.text.Document(PageSize.A4);
            string path = Server.MapPath("~");
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path + "/Factura.pdf", FileMode.Create));


            vehiculo ovehiculo = bus.buscarvehiculoid(Ordenn.id_vehiculo ?? default(int));
            cliente ocliente = bus.ocliente(ovehiculo);
            modelo omodelo = bus.buscarmodelo(ovehiculo);
            marca omarca = bus.buscarmarca(omodelo);

            doc.Open();

            //Cabecera
            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfntHead, 16, 1, iTextSharp.text.BaseColor.BLUE.Darker());
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = 1;
            prgHeading.Add(new Chunk("Factura".ToUpper(), fntHead));
            doc.Add(prgHeading);
            doc.Add(Chunk.NEWLINE);

            //Generado By
            Paragraph prgGeneratedBY = new Paragraph();
            BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntAuthor = new iTextSharp.text.Font(btnAuthor, 12, 2, iTextSharp.text.BaseColor.BLACK);
            prgGeneratedBY.Alignment = Element.ALIGN_RIGHT;
            prgGeneratedBY.Add(new Chunk("Generado por: " + LogEmpleado.nombreyapellido, fntAuthor));  //Agregar LOG Empleado
            prgGeneratedBY.Add(new Chunk("\nFecha : " + DateTime.Now.ToShortDateString(), fntAuthor));
            prgGeneratedBY.Add(new Chunk("\nN° de Orden : " + Ordenn.id_orden, fntAuthor));
            doc.Add(prgGeneratedBY);
            doc.Add(Chunk.NEWLINE);

            doc.Add(Chunk.NEWLINE);

            //tablados
            PdfPTable tabla2 = new PdfPTable(2);
            tabla2.WidthPercentage = 100;
            tabla2.SpacingAfter = 20;

            PdfPCell vehiculoTitulo = new PdfPCell(new Phrase("Vehiculo"));
            vehiculoTitulo.BorderWidth = 0;
            vehiculoTitulo.BorderWidthRight = 0.75f;
            vehiculoTitulo.BorderWidthTop = 0.75f;
            vehiculoTitulo.BorderWidthLeft = 0.75f;
            vehiculoTitulo.HorizontalAlignment = Element.ALIGN_CENTER;
            vehiculoTitulo.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#C8C8C8"));

            PdfPCell clienteTitulo = new PdfPCell(new Phrase("Cliente"));
            clienteTitulo.BorderWidth = 0;
            clienteTitulo.BorderWidthTop = 0.75f;
            clienteTitulo.BorderWidthRight = 0.75f;
            clienteTitulo.HorizontalAlignment = Element.ALIGN_CENTER;
            clienteTitulo.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#C8C8C8"));



            PdfPCell patente = new PdfPCell(new Phrase("Patente: " + ovehiculo.patente));
            patente.BorderWidth = 0;
            patente.BorderWidthRight = 0.75f;
            patente.BorderWidthBottom = 0.75f;
            patente.BorderWidthLeft = 0.75f;
            patente.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#C8C8C8"));

            PdfPCell marca = new PdfPCell(new Phrase("Marca: " + omarca.nombre));
            marca.BorderWidth = 0;
            marca.BorderWidthRight = 0.75f;
            marca.BorderWidthLeft = 0.75f;
            marca.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#C8C8C8"));

            PdfPCell modelo = new PdfPCell(new Phrase("Modelo: " + omodelo.nombre));
            modelo.BorderWidth = 0;
            modelo.BorderWidthRight = 0.75f;
            modelo.BorderWidthLeft = 0.75f;
            modelo.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#C8C8C8"));

            PdfPCell nombre = new PdfPCell(new Phrase("Apellido y Nombre: " + ocliente.nombre));
            nombre.BorderWidth = 0;
            nombre.BorderWidthLeft = 0.75f;
            nombre.BorderWidthBottom = 0.75f;
            nombre.BorderWidthRight = 0.75f;
            nombre.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#C8C8C8"));

            PdfPCell dni = new PdfPCell(new Phrase("DNI: " + ocliente.dni));
            dni.BorderWidth = 0;
            dni.BorderWidthBottom = 0.75f;
            dni.BorderWidthRight = 0.75f;
            dni.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#C8C8C8"));

            tabla2.AddCell(vehiculoTitulo);
            tabla2.AddCell(clienteTitulo);

            tabla2.AddCell(marca);
            tabla2.AddCell(modelo);
            tabla2.AddCell(nombre);
            tabla2.AddCell(patente);
            tabla2.AddCell(dni);

            doc.Add(tabla2);
            dt.Rows.Add("", "", "Total", lblprecio.Text);
            PdfPTable table = new PdfPTable(dt.Columns.Count);

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string cellText = Server.HtmlDecode(dt.Columns[i].ColumnName);
                PdfPCell cell = new PdfPCell();
                cell.Phrase = new Phrase(cellText, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, 1, new BaseColor(System.Drawing.ColorTranslator.FromHtml("#000000"))));
                cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#C8C8C8"));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_CENTER;
                cell.PaddingBottom = 5;

                table.AddCell(cell);
            }
            //Agregando Campos a la tabla
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.Phrase = new Phrase(dt.Rows[i][j].ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, 0, new BaseColor(System.Drawing.ColorTranslator.FromHtml("#000000"))));

                    if (j == 1)
                    {
                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    }
                    else
                    {
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;

                    }
                    if (dt.Rows[i][j].ToString() == "Total")
                    {
                        cell.Phrase = new Phrase(dt.Rows[i][j].ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, 1, new BaseColor(System.Drawing.ColorTranslator.FromHtml("#000000"))));

                    }
                    table.AddCell(cell);
                }
            }
            table.SetWidths(new float[] { 2, 8, 1, 1 });
            doc.Add(table);
            //Espacio


            doc.Close();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('Factura.pdf','_newtab');", true);
            //Response.Redirect("Presupuesto.pdf");


        }

        protected void BtnImporimir(object sender, EventArgs e)
        {
            PDFESTADOCERO();

        }
    }
}