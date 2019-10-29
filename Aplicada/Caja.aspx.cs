using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (LogEmpleado.id_tipo != 3)
            {
                Server.Transfer("Default.aspx");
            }
            fecha.Text = DateTime.Now.ToString("dd-MM-yyyy");
            Buscadores bus = new Buscadores();
            List<ordenestado> Lordenestado = bus.buscarListOrdenEstado(3);
            List<orden> Lorden = bus.buscarordeestado(Lordenestado);
            List<vehiculo> LVehiculo = bus.buscarordevehiculo(Lorden);
            LOrden = Lorden;
            //DropDownList1.DataSource = Lorden;
            //DropDownList1.DataTextField = "id_orden";
            //DropDownList1.DataValueField = "id_orden";
            //DropDownList1.DataBind();

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
            ListItem i;
            i = new ListItem("Tarjeta de Credito", "Tarjeta de Credito");
            DropMetododePago.Items.Add(i);
            i = new ListItem("Tarjeta de Debito", "Tarjeta de Debito");
            DropMetododePago.Items.Add(i);
            i = new ListItem("Efectivo", "Efectivo");
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
            //foreach (servicio x in Lservicios)
            //{
            //    a = a + int.Parse(x.precio);
            //}
            lblprecio.Text = preciototal.ToString();
            //GridView1.DataSource = Lservicios;
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
    }
}