using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplicada
{
    public partial class Entregado : System.Web.UI.Page
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (LogEmpleado.id_tipo != 7)
            {
                Server.Transfer("Default.aspx");
            }

            Buscadores bus = new Buscadores();
            List<ordenestado> Lordenestado = bus.buscarListOrdenEstado(4);
            List<orden> Lorden = bus.buscarordeestado(Lordenestado);
            List<vehiculo> LVehiculo = bus.buscarordevehiculo(Lorden);
            LOrden = Lorden;
        }

        protected void BtnBuscarO(object sender, EventArgs e)
        {
            Buscadores bus = new Buscadores();



            if (txtorden.Value != "")
            {


                foreach (orden oOrden in LOrden)
                {

                    if (int.Parse(txtorden.Value) == oOrden.id_orden)
                    {
                        labeltitulo.InnerText = "DATOS DEL PROPIETARIO Y VEHICULO";
                        Ordenn = oOrden;
                        lblPatente.Text = oOrden.vehiculo.patente;
                        cliente objcliente = bus.ocliente(oOrden.vehiculo);
                        lblNombre.Text = objcliente.nombre;
                        lblDNI.Text = objcliente.dni;
                        modelo omodelo = bus.buscarmodelo(oOrden.vehiculo);
                        lblModelo.Text = omodelo.nombre;
                        lblMarca.Text = bus.buscarmarca(omodelo).nombre;
                        lblEstado.Text = "Para entregar";


                    }

                }

            }
            else
            {
                labeltitulo.InnerText = "La patente ingresada no se encuentra para Entregar";
            }

        }
        protected void BtnBuscarP(object sender, EventArgs e)
        {
            Buscadores bus = new Buscadores();
            labeltitulo.InnerText = "La patente ingresada no se encuentra para Cobrar";
            if (txtpatente.Value != "")
            {



                foreach (orden oOrden in LOrden)
                {
                    if (txtpatente.Value == oOrden.vehiculo.patente)
                    {
                        labeltitulo.InnerText = "DATOS DEL PROPIETARIO Y VEHICULO";
                        Ordenn = oOrden;
                        lblPatente.Text = oOrden.vehiculo.patente;
                        cliente objcliente = bus.ocliente(oOrden.vehiculo);
                        lblNombre.Text = objcliente.nombre;
                        lblDNI.Text = objcliente.dni;
                        modelo omodelo = bus.buscarmodelo(oOrden.vehiculo);
                        lblModelo.Text = omodelo.nombre;
                        lblMarca.Text = bus.buscarmarca(omodelo).nombre;
                        lblEstado.Text = "Para entregar";


                    }

                }

            }


        }

        protected void btnEntregar(object sender, EventArgs e)
        {

            labeltitulo.InnerText = "La patente ingresada no se encuentra para Cobrar";
            if (lblDNI.Text != "------")
            {
                labeltitulo.InnerText = "DATOS DEL PROPIETARIO Y VEHICULO";
                if (lblEstado.Text == "Para entregar")
                {
                    using (aplicadaBDEntities DBF = new aplicadaBDEntities())
                    {
                        ordenestado oestado = (from q in DBF.ordenestado where q.id_orden == Ordenn.id_orden select q).First();
                        oestado.estado = 5;
                        oestado.fecha_entregado = System.DateTime.Now;
                        DBF.SaveChanges();
                        orden oorden = (from q in DBF.orden where q.id_orden == Ordenn.id_orden select q).First();
                        DBF.SaveChanges();
                        ordenempleado ordenemple = new ordenempleado
                        {
                            id_orden = oorden.id_orden,
                            id_empleado = LogEmpleado.id_empleado,

                        };
                        DBF.ordenempleado.Add(ordenemple);
                        DBF.SaveChanges();
                        PDFESTADOCERO();
                        lblEstado.Text = "Entregado";
                    }
                }
            }
        }
        public void PDFESTADOCERO()
        {
            Buscadores bus = new Buscadores();
            var doc = new iTextSharp.text.Document(PageSize.A4);
            string path = Server.MapPath("~");
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(path + "/Conformidad.pdf", FileMode.Create));


            vehiculo ovehiculo = bus.buscarvehiculo(lblPatente.Text);
            cliente ocliente = bus.ocliente(ovehiculo);
            modelo omarca = bus.buscarmodelo(ovehiculo);
            marca omodelo = bus.buscarmarca(omarca);

            doc.Open();

            //Cabecera
            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfntHead, 16, 1, iTextSharp.text.BaseColor.GREEN.Darker());
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = 1;
            prgHeading.Add(new Chunk("Contrato de Conformidad".ToUpper(), fntHead));
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


            Paragraph l = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            doc.Add(l);
            doc.Add(Chunk.NEWLINE);

            Paragraph Cliente1 = new Paragraph("Apellido y Nombre: " + ocliente.nombre);
            doc.Add(Cliente1);

            Paragraph Cliente2 = new Paragraph("DNI: " + ocliente.dni);
            doc.Add(Cliente2);

            Paragraph Cliente3 = new Paragraph("Telefono: " + ocliente.telefono);
            doc.Add(Cliente3);

            Paragraph Cliente4 = new Paragraph("Correo Electronico: " + ocliente.email);
            doc.Add(Cliente4);
            doc.Add(Chunk.NEWLINE);



            Paragraph Vehiculo1 = new Paragraph("Patente: " + ovehiculo.patente);
            doc.Add(Vehiculo1);

            Paragraph Vehiculo2 = new Paragraph("Marca: " + omodelo.nombre);
            doc.Add(Vehiculo2);

            Paragraph Vehiculo3 = new Paragraph("Modelo: " + omarca.nombre);
            doc.Add(Vehiculo3);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);

            Paragraph e = new Paragraph("Estimado cliente:");
            e.Font.Size = 18;
            doc.Add(e);
            doc.Add(Chunk.NEWLINE);

            Paragraph cu = new Paragraph("Gracias por confiar en nosotros para reparar su vehiculo, esperamos que la atencion haya sido de su agrado atte el personal de la empresa.");
            cu.Alignment = Element.ALIGN_JUSTIFIED;
            doc.Add(cu);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);


            Paragraph ff = new Paragraph("________");
            ff.Alignment = 1;
            doc.Add(ff);

            Paragraph fff = new Paragraph("(FIRMA)");
            fff.Alignment = 1;
            doc.Add(fff);
            doc.Add(Chunk.NEWLINE);


            doc.Close();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('Conformidad.pdf','_newtab');", true);
            //Response.Redirect("Presupuesto.pdf");

        }


    }
}