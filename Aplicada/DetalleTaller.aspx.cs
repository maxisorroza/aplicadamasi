using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplicada
{
    public partial class DetalleTaller : System.Web.UI.Page
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (LogEmpleado.id_tipo != 2)
            {
                Server.Transfer("Default.aspx");
            }

        }

        protected void btnpasarataller_ServerClick(object sender, EventArgs e)
        {
            if ((LogEmpleado.contraseña == txtpwd.Value) && (DropMecanicosDispo.SelectedValue.ToString() != ""))
            {
                using (aplicadaBDEntities DBF = new aplicadaBDEntities())
                {

                    ordenempleado ordenemple = new ordenempleado
                    {
                        id_orden = OrdenActual.id_orden,
                        id_empleado = int.Parse(DropMecanicosDispo.SelectedValue.ToString())

                    };

                    DBF.ordenempleado.Add(ordenemple);
                    DBF.SaveChanges();
                    ordenestado oestado = (from q in DBF.ordenestado where q.id_orden == OrdenActual.id_orden select q).First();
                    oestado.estado = 1;
                    oestado.fecha_espera = System.DateTime.Now;
                     //////////////////////////////////////////////////////////
                    DBF.SaveChanges();
                    empleado oempleado = (from q in DBF.empleado where q.id_empleado == ordenemple.id_empleado select q).First();
                    oempleado.disponibilidad = 1;
                    DBF.SaveChanges();
                    foreach (stock ostock in Lstock)
                    {
                        stock Stocko = new stock();
                        Stocko = (from q in DBF.stock where q.id_stock == ostock.id_stock select q).First();
                        Stocko.cantidad = (int.Parse(Stocko.cantidad) - 1).ToString();
                        DBF.SaveChanges();
                    }
                    OrdenActual = null;
                    Lstock = null;
                    Server.Transfer("Default.aspx");

                }
            }
            else
            {
                Server.Transfer("DetalleTaller.aspx");
            }
        }
    }
}