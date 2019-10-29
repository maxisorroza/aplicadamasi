using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplicada
{
    public partial class login : System.Web.UI.Page
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

        }

        protected void btnLogin_ServerClick(object sender, EventArgs e)
        {
            Buscadores bus = new Buscadores();
            empleado oempleado = bus.buscarempleado(txtemail.Value);
            if (oempleado != null)
            {


                if (oempleado.contraseña == txtcontraseña.Value)
                {
                    LogEmpleado = oempleado;
                    Server.Transfer("Default.aspx");

                }
            }

        }
    }
}