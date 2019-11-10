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
    public partial class Reportes : System.Web.UI.Page
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MetodosdePago();
                if (LogEmpleado.id_tipo != 10)
                {
                    Server.Transfer("Default.aspx");
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

        }

        protected void PDFLST(object sender, EventArgs e)
        {

            Buscadores bus = new Buscadores();
            List<stock> Lstock = bus.listastock();
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Codigo"), new DataColumn("Detalle"), new DataColumn("Marca"), new DataColumn("Cantidad") });
            foreach (stock ostock in Lstock)
            {
                dt.Rows.Add(ostock.codigo, ostock.detalle, ostock.marca, ostock.cantidad);
            }
            iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(PageSize.A4);
            var doc = new iTextSharp.text.Document(rec);

            rec.BackgroundColor = new BaseColor(System.Drawing.Color.Olive);
            doc.SetPageSize(iTextSharp.text.PageSize.A4);
            string path = Server.MapPath("~");
            PdfWriter.GetInstance(doc, new FileStream(path + "/ReportesLSTT.pdf", FileMode.Create));
            doc.Open();
            //Cabecera
            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfntHead, 16, 1, iTextSharp.text.BaseColor.GREEN.Darker());
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_LEFT;
            prgHeading.Add(new Chunk("Taller de Reparaciones Reportes PDF".ToUpper(), fntHead));
            doc.Add(prgHeading);
            //Generado By
            Paragraph prgGeneratedBY = new Paragraph();
            BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntAuthor = new iTextSharp.text.Font(btnAuthor, 8, 2, iTextSharp.text.BaseColor.BLACK);
            prgGeneratedBY.Alignment = Element.ALIGN_RIGHT;
            prgGeneratedBY.Add(new Chunk("Generado por: " + LogEmpleado.nombreyapellido, fntAuthor));  //Agregar LOG Empleado
            prgGeneratedBY.Add(new Chunk("\nFecha Generada : " + DateTime.Now.ToShortDateString(), fntAuthor));
            doc.Add(prgGeneratedBY);
            //La f Linea  
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            doc.Add(p);
            //Espacio
            doc.Add(new Chunk("\n", fntHead));
            //Tabla
            PdfPTable table = new PdfPTable(dt.Columns.Count);

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string cellText = Server.HtmlDecode(dt.Columns[i].ColumnName);
                PdfPCell cell = new PdfPCell();
                cell.Phrase = new Phrase(cellText, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, 1, new BaseColor(System.Drawing.ColorTranslator.FromHtml("#000000"))));
                cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#C8C8C8"));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.PaddingBottom = 5;
                table.AddCell(cell);
            }
            //Agregando Campos a la tabla
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    table.AddCell(dt.Rows[i][j].ToString());
                }
            }
            doc.Add(table);
            doc.Close();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('ReportesLSTT.pdf','_newtab');", true);
        }

        protected void PDFLSM(object sender, EventArgs e)
        {
            if (txtinput.Value != "")
            {
                Buscadores bus = new Buscadores();
                List<stock> Lstock = bus.listastockmarca(txtinput.Value);//hacer input para poner el valor de la marca
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Codigo"), new DataColumn("Detalle"), new DataColumn("Marca"), new DataColumn("Cantidad") });
                foreach (stock ostock in Lstock)
                {
                    dt.Rows.Add(ostock.codigo, ostock.detalle, ostock.marca, ostock.cantidad);
                }
                iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(PageSize.A4);
                var doc = new iTextSharp.text.Document(rec);

                rec.BackgroundColor = new BaseColor(System.Drawing.Color.Olive);
                doc.SetPageSize(iTextSharp.text.PageSize.A4);
                string path = Server.MapPath("~");
                PdfWriter.GetInstance(doc, new FileStream(path + "/ReportesLSM.pdf", FileMode.Create));
                doc.Open();
                //Cabecera
                BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfntHead, 16, 1, iTextSharp.text.BaseColor.GREEN.Darker());
                Paragraph prgHeading = new Paragraph();
                prgHeading.Alignment = Element.ALIGN_LEFT;
                prgHeading.Add(new Chunk("Taller de Reparaciones Reportes PDF".ToUpper(), fntHead));
                doc.Add(prgHeading);
                //Generado By
                Paragraph prgGeneratedBY = new Paragraph();
                BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font fntAuthor = new iTextSharp.text.Font(btnAuthor, 8, 2, iTextSharp.text.BaseColor.BLACK);
                prgGeneratedBY.Alignment = Element.ALIGN_RIGHT;
                prgGeneratedBY.Add(new Chunk("Generado por: " + LogEmpleado.nombreyapellido, fntAuthor));  //Agregar LOG Empleado
                prgGeneratedBY.Add(new Chunk("\nFecha Generada : " + DateTime.Now.ToShortDateString(), fntAuthor));
                doc.Add(prgGeneratedBY);
                //La f Linea  
                Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                doc.Add(p);
                //Espacio
                doc.Add(new Chunk("\n", fntHead));
                //Tabla
                PdfPTable table = new PdfPTable(dt.Columns.Count);

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    string cellText = Server.HtmlDecode(dt.Columns[i].ColumnName);
                    PdfPCell cell = new PdfPCell();
                    cell.Phrase = new Phrase(cellText, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, 1, new BaseColor(System.Drawing.ColorTranslator.FromHtml("#000000"))));
                    cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#C8C8C8"));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 5;
                    table.AddCell(cell);
                }
                //Agregando Campos a la tabla
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        table.AddCell(dt.Rows[i][j].ToString());
                    }
                }
                doc.Add(table);
                doc.Close();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('ReportesLSM.pdf','_newtab');", true);
            }
        }

        protected void PDFLSP(object sender, EventArgs e)
        {
            if (txtinput.Value != "")
            {
                Buscadores bus = new Buscadores();
                List<stock> Lstock = bus.listastockproducto(txtinput.Value);//hacer input para poner el valor de la marca
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Codigo"), new DataColumn("Detalle"), new DataColumn("Marca"), new DataColumn("Cantidad") });
                foreach (stock ostock in Lstock)
                {
                    dt.Rows.Add(ostock.codigo, ostock.detalle, ostock.marca, ostock.cantidad);
                }
                iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(PageSize.A4);
                var doc = new iTextSharp.text.Document(rec);

                rec.BackgroundColor = new BaseColor(System.Drawing.Color.Olive);
                doc.SetPageSize(iTextSharp.text.PageSize.A4);
                string path = Server.MapPath("~");
                PdfWriter.GetInstance(doc, new FileStream(path + "/ReportesPRODU.pdf", FileMode.Create));
                doc.Open();
                //Cabecera
                BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfntHead, 16, 1, iTextSharp.text.BaseColor.GREEN.Darker());
                Paragraph prgHeading = new Paragraph();
                prgHeading.Alignment = Element.ALIGN_LEFT;
                prgHeading.Add(new Chunk("Taller de Reparaciones Reportes PDF".ToUpper(), fntHead));
                doc.Add(prgHeading);
                //Generado By
                Paragraph prgGeneratedBY = new Paragraph();
                BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font fntAuthor = new iTextSharp.text.Font(btnAuthor, 8, 2, iTextSharp.text.BaseColor.BLACK);
                prgGeneratedBY.Alignment = Element.ALIGN_RIGHT;
                prgGeneratedBY.Add(new Chunk("Generado por: " + LogEmpleado.nombreyapellido, fntAuthor));  //Agregar LOG Empleado
                prgGeneratedBY.Add(new Chunk("\nGenerated Date : " + DateTime.Now.ToShortDateString(), fntAuthor));
                doc.Add(prgGeneratedBY);
                //La f Linea  
                Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                doc.Add(p);
                //Espacio
                doc.Add(new Chunk("\n", fntHead));
                //Tabla
                PdfPTable table = new PdfPTable(dt.Columns.Count);

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    string cellText = Server.HtmlDecode(dt.Columns[i].ColumnName);
                    PdfPCell cell = new PdfPCell();
                    cell.Phrase = new Phrase(cellText, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, 1, new BaseColor(System.Drawing.ColorTranslator.FromHtml("#000000"))));
                    cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#C8C8C8"));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.PaddingBottom = 5;
                    table.AddCell(cell);
                }
                //Agregando Campos a la tabla
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        table.AddCell(dt.Rows[i][j].ToString());
                    }
                }
                doc.Add(table);
                doc.Close();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('ReportesPRODU.pdf','_newtab');", true);
            }
        }

        protected void PDFPTP(object sender, EventArgs e)
        {
            Buscadores bus = new Buscadores();
            List<orden> Lorden = bus.listasordenmp(DropMetododePago.SelectedValue);
            Lorden = bus.ordenponervyc(Lorden);
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("N°Orden"), new DataColumn("Patente"), new DataColumn("Cliente"), new DataColumn("Metodo de Pago") });
            foreach (orden oorden in Lorden)
            {
                dt.Rows.Add(oorden.id_orden, oorden.vehiculo.patente, oorden.vehiculo.cliente.nombre, oorden.mpago);
            }
            iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(PageSize.A4);
            var doc = new iTextSharp.text.Document(rec);

            rec.BackgroundColor = new BaseColor(System.Drawing.Color.Olive);
            doc.SetPageSize(iTextSharp.text.PageSize.A4);
            string path = Server.MapPath("~");
            PdfWriter.GetInstance(doc, new FileStream(path + "/ReportesLSTP.pdf", FileMode.Create));
            doc.Open();
            //Cabecera
            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfntHead, 16, 1, iTextSharp.text.BaseColor.GREEN.Darker());
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_LEFT;
            prgHeading.Add(new Chunk("Taller de Reparaciones Reportes PDF".ToUpper(), fntHead));
            doc.Add(prgHeading);
            //Generado By
            Paragraph prgGeneratedBY = new Paragraph();
            BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntAuthor = new iTextSharp.text.Font(btnAuthor, 8, 2, iTextSharp.text.BaseColor.BLACK);
            prgGeneratedBY.Alignment = Element.ALIGN_RIGHT;
            prgGeneratedBY.Add(new Chunk("Generado por: " + LogEmpleado.nombreyapellido, fntAuthor));  //Agregar LOG Empleado
            prgGeneratedBY.Add(new Chunk("\nGenerated Date : " + DateTime.Now.ToShortDateString(), fntAuthor));
            doc.Add(prgGeneratedBY);
            //La f Linea  
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            doc.Add(p);
            //Espacio
            doc.Add(new Chunk("\n", fntHead));
            //Tabla
            PdfPTable table = new PdfPTable(dt.Columns.Count);

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string cellText = Server.HtmlDecode(dt.Columns[i].ColumnName);
                PdfPCell cell = new PdfPCell();
                cell.Phrase = new Phrase(cellText, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, 1, new BaseColor(System.Drawing.ColorTranslator.FromHtml("#000000"))));
                cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#C8C8C8"));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.PaddingBottom = 5;
                table.AddCell(cell);
            }
            //Agregando Campos a la tabla
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    table.AddCell(dt.Rows[i][j].ToString());
                }
            }
            doc.Add(table);
            doc.Close();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('ReportesLSTP.pdf','_newtab');", true);



        }

        protected void PDFPP(object sender, EventArgs e)
        {
            if ((txtdni.Value != "") && (txtfechafin.Value != "") && (txtfechainicio.Value != ""))
            {
                Buscadores bus = new Buscadores();
                DateTime oDateinicio = Convert.ToDateTime(txtfechainicio.Value);
                DateTime oDatefin = Convert.ToDateTime(txtfechafin.Value);
                cliente ocliente = bus.oclientedni(txtdni.Value);

                if (ocliente.dni != null)
                {
                    List<vehiculo> Lvehiculo = bus.buscarclientevehiculo(ocliente.id);
                    Lvehiculo.Count();
                    if (Lvehiculo.Count != 0)
                    {
                        var doc = new iTextSharp.text.Document(PageSize.A4);
                        string path = Server.MapPath("~");
                        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path + "/PP.pdf", FileMode.Create));
                        doc.Open();
                        //Cabecera
                        BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfntHead, 16, 1, iTextSharp.text.BaseColor.GREEN.Darker());
                        Paragraph prgHeading = new Paragraph();
                        prgHeading.Alignment = 1;
                        prgHeading.Add(new Chunk("Taller de Reparaciones".ToUpper(), fntHead));
                        doc.Add(prgHeading);
                        doc.Add(Chunk.NEWLINE);
                        //Generado By
                        Paragraph prgGeneratedBY = new Paragraph();
                        BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        iTextSharp.text.Font fntAuthor = new iTextSharp.text.Font(btnAuthor, 12, 2, iTextSharp.text.BaseColor.BLACK);
                        prgGeneratedBY.Alignment = Element.ALIGN_RIGHT;
                        prgGeneratedBY.Add(new Chunk("Generado por: " + LogEmpleado.nombreyapellido, fntAuthor));  //Agregar LOG Empleado
                        prgGeneratedBY.Add(new Chunk("\nFecha : " + DateTime.Now.ToShortDateString(), fntAuthor));
                        doc.Add(prgGeneratedBY);
                        Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                        doc.Add(p);
                        //Espacio
                        doc.Add(new Chunk("\n", fntHead));
                        //Datos
                        Paragraph Datos = new Paragraph();
                        BaseFont bfntDatos = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                        iTextSharp.text.Font fntDatos = new iTextSharp.text.Font(bfntDatos, 12, 0, iTextSharp.text.BaseColor.BLACK);
                        Datos.Alignment = Element.ALIGN_CENTER;
                        Datos.Add(new Chunk("\nApellido y Nombre: " + ocliente.nombre + "   DNI:" + ocliente.dni + "  Telefono:  " + ocliente.telefono + " \nEmail:  " + ocliente.email, fntDatos));
                        doc.Add(Datos);
                        //Espacio
                        doc.Add(new Chunk("\n", fntHead));
                        int controlprecio;
                        foreach (vehiculo o in Lvehiculo)
                        {
                            controlprecio = 0;

                            o.modelo = bus.buscarmodelo(o);
                            o.modelo.marca = bus.buscarmarca(o.modelo);


                            //Creo una tabla
                            DataTable dt = new DataTable();
                            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("N°Orden"), new DataColumn("Fecha"), new DataColumn("PrecioTotal") });//nombre de las columnas
                            List<orden> Lorden = bus.buscarListaordenporvehiculo(o.id_vehiculo);
                            foreach (orden OrdenActual in Lorden)
                            {
                                int preciototal = 0;
                                ordenestado oestado = bus.buscarvestadoorden(OrdenActual.id_orden);
                                if ((oestado.fecha_entregado >= oDateinicio) && (oestado.fecha_entregado <= oDatefin))
                                {
                                    List<ordenservicio> Lidservidcios = new List<ordenservicio>();
                                    Lidservidcios = bus.buscarlistaid(OrdenActual.id_orden);
                                    List<servicio> Lservicio = bus.ObtenerServicios(Lidservidcios);
                                    foreach (ordenservicio ordenservi in Lidservidcios)
                                    {


                                        servicio oservicio = Lservicio.Find(x => x.id_servicios == ordenservi.id_servicio);
                                        int cantidad = ordenservi.cantidad ?? default(int);
                                        string total = (double.Parse(oservicio.precio) * Convert.ToDouble(cantidad)).ToString();
                                        preciototal = preciototal + int.Parse(total);
                                    }
                                    string fecha = oestado.fecha_entregado.ToString();
                                    string[] fechasinhora;
                                    fechasinhora = fecha.Split(' ');


                                    dt.Rows.Add(OrdenActual.id_orden, fechasinhora[0], preciototal);

                                    controlprecio = preciototal;

                                }

                            }
                            //aqui
                            if (dt.Rows.Count != 0)
                            {

                                doc.Add(p);
                                Paragraph Dato = new Paragraph();
                                Dato.Alignment = Element.ALIGN_LEFT;
                                Dato.Add(new Chunk("\npatente: " + o.patente + "   Modelo: " + o.modelo.nombre + "  Marca:  " + o.modelo.marca.nombre, fntDatos));
                                doc.Add(Dato);
                                //Espacio
                                doc.Add(new Chunk("\n", fntHead));
                                //Tabla
                                PdfPTable table = new PdfPTable(dt.Columns.Count);

                                for (int i = 0; i < dt.Columns.Count; i++)
                                {
                                    string cellText = Server.HtmlDecode(dt.Columns[i].ColumnName);
                                    PdfPCell cell = new PdfPCell();
                                    cell.Phrase = new Phrase(cellText, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, 1, new BaseColor(System.Drawing.ColorTranslator.FromHtml("#000000"))));
                                    cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#C8C8C8"));
                                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                    cell.PaddingBottom = 5;

                                    table.AddCell(cell);
                                }
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    for (int j = 0; j < dt.Columns.Count; j++)
                                    {
                                        table.AddCell(dt.Rows[i][j].ToString());

                                    }
                                }
                                table.HorizontalAlignment = Element.ALIGN_CENTER;

                                doc.Add(table);


                                //Espacio
                                doc.Add(new Chunk("\n", fntHead));
                            }
                        }



                        doc.Close();
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('PP.pdf','_newtab');", true);

                    }

                }
            }
        }

        protected void PDFRPE(object sender, EventArgs e)
        {
            if (((FechaFinale.Value != "") && (FechaInicios.Value != "")))
            {
                Buscadores bus = new Buscadores();
                DateTime oDateinicio = Convert.ToDateTime(FechaInicios.Value);
                DateTime oDatefin = Convert.ToDateTime(FechaFinale.Value);
                int tipodempleado = int.Parse(DropTipodeEmpleados.SelectedValue);
                List<empleado> Lempleados = bus.Lempleado();
                Lempleados = Lempleados.FindAll(x => (x.id_tipo ?? default(int)) == tipodempleado);
                if (Lempleados.Count != 0)
                {
                    var doc = new iTextSharp.text.Document(PageSize.A4);
                    string path = Server.MapPath("~");
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path + "/RE.pdf", FileMode.Create));
                    doc.Open();
                    //Cabecera
                    BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfntHead, 16, 1, iTextSharp.text.BaseColor.GREEN.Darker());
                    Paragraph prgHeading = new Paragraph();
                    prgHeading.Alignment = 1;
                    prgHeading.Add(new Chunk("Taller de Reparaciones".ToUpper(), fntHead));
                    doc.Add(prgHeading);
                    doc.Add(Chunk.NEWLINE);
                    //Generado By
                    Paragraph prgGeneratedBY = new Paragraph();
                    BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntAuthor = new iTextSharp.text.Font(btnAuthor, 12, 2, iTextSharp.text.BaseColor.BLACK);
                    prgGeneratedBY.Alignment = Element.ALIGN_RIGHT;
                    prgGeneratedBY.Add(new Chunk("Generado por: " + LogEmpleado.nombreyapellido, fntAuthor));  //Agregar LOG Empleado
                    prgGeneratedBY.Add(new Chunk("\nFecha : " + DateTime.Now.ToShortDateString(), fntAuthor));
                    doc.Add(prgGeneratedBY);
                    Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                    doc.Add(p);
                    //Espacio
                    doc.Add(new Chunk("\n", fntHead));
                    //Datos
                    Paragraph Datos = new Paragraph();
                    BaseFont bfntDatos = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    iTextSharp.text.Font fntDatos = new iTextSharp.text.Font(bfntDatos, 16, 0, iTextSharp.text.BaseColor.BLACK);
                    Datos.Alignment = Element.ALIGN_CENTER;
                    Datos.Add(new Chunk("\nEmpleado tipo: " + DropTipodeEmpleados.SelectedItem.Text, fntDatos));
                    doc.Add(Datos);
                    //Espacio
                    doc.Add(new Chunk("\n", fntHead));
                    int controlprecio;
                    foreach (empleado oempleado in Lempleados)
                    {
                        controlprecio = 0;
                        DataTable dt = new DataTable();
                        dt.Columns.AddRange(new DataColumn[4] { new DataColumn("N°Orden"), new DataColumn("Vehiculo"), new DataColumn("Fecha"), new DataColumn("PrecioTotal") });//nombre de las columnas
                        List<ordenempleado> Lordenempleado = bus.buscarListOrdenEstadoporempleado(oempleado.id_empleado);
                        List<orden> Lorden = bus.buscarordexempleado(Lordenempleado);
                        foreach (orden OrdenActual in Lorden)
                        {
                            int id = int.Parse(OrdenActual.id_vehiculo.ToString());
                            vehiculo ovehiculo = bus.buscarvehiculoid(id);
                            int preciototal = 0;
                            ordenestado oestado = bus.buscarvestadoorden(OrdenActual.id_orden);
                            if ((oestado.fecha_entregado >= oDateinicio) && (oestado.fecha_entregado <= oDatefin))
                            {
                                List<ordenservicio> Lidservidcios = new List<ordenservicio>();
                                Lidservidcios = bus.buscarlistaid(OrdenActual.id_orden);
                                List<servicio> Lservicio = bus.ObtenerServicios(Lidservidcios);
                                foreach (ordenservicio ordenservi in Lidservidcios)
                                {


                                    servicio oservicio = Lservicio.Find(x => x.id_servicios == ordenservi.id_servicio);
                                    int cantidad = ordenservi.cantidad ?? default(int);
                                    string total = (double.Parse(oservicio.precio) * Convert.ToDouble(cantidad)).ToString();
                                    preciototal = preciototal + int.Parse(total);
                                }
                                string fecha = oestado.fecha_entregado.ToString();
                                string[] fechasinhora;
                                fechasinhora = fecha.Split(' ');


                                dt.Rows.Add(OrdenActual.id_orden, ovehiculo.patente, fechasinhora[0], preciototal);

                                controlprecio = preciototal;

                            }

                        }
                        //aqui
                        if (dt.Rows.Count != 0)
                        {

                            doc.Add(p);
                            Paragraph Dato = new Paragraph();
                            Dato.Alignment = Element.ALIGN_LEFT;
                            Dato.Add(new Chunk("\nNombre y Apellido: " + oempleado.nombreyapellido + "   Correo: " + oempleado.correo + "  Direccion:  " + oempleado.direccion + "\nDireccion:  " + oempleado.telefono, fntDatos));
                            doc.Add(Dato);
                            //Espacio
                            doc.Add(new Chunk("\n", fntHead));
                            //Tabla
                            PdfPTable table = new PdfPTable(dt.Columns.Count);
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                string cellText = Server.HtmlDecode(dt.Columns[i].ColumnName);
                                PdfPCell cell = new PdfPCell();
                                cell.Phrase = new Phrase(cellText, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10, 1, new BaseColor(System.Drawing.ColorTranslator.FromHtml("#000000"))));
                                cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#C8C8C8"));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.PaddingBottom = 5;

                                table.AddCell(cell);
                            }
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                for (int j = 0; j < dt.Columns.Count; j++)
                                {
                                    table.AddCell(dt.Rows[i][j].ToString());

                                }
                            }
                            table.HorizontalAlignment = Element.ALIGN_CENTER;

                            doc.Add(table);


                            //Espacio
                            doc.Add(new Chunk("\n", fntHead));


                        }


                    }
                    doc.Close();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('RE.pdf','_newtab');", true);
                }

            }


        }

    }
}