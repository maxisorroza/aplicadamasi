using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplicada
{
    public partial class Site1 : System.Web.UI.MasterPage
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
            btnLogin.Visible = true;
        
            if (LogEmpleado != null)
            {
                Label1.Text = LogEmpleado.correo;
            }

            if (LogEmpleado.correo != null)
            {
                btnLogout.Visible = true;
                btnLogin.Visible = false;
                HabilitarTaller();
                HabilitarOperario();
                HabilitarCaja();
                habilitarReportes();

            }
            else
            {
                btnAltadetalle.Visible = false;
                btnCaja.Visible = false;
                btnTaller.Visible = false;
                btnDetalleTaller.Visible = false;
                

            }
        }

        private void HabilitarCaja()
        {
            if (LogEmpleado.id_tipo == 8)
        {
           btnCaja.Visible = true;

            }
}

        private void HabilitarOperario()
        {
            if (LogEmpleado.id_tipo == 7)
            {
            btnAltadetalle.Visible = true;
            btnCargardetalle.Visible = true;
                btnEntregado.Visible = true;

             }
        }

        private void HabilitarTaller()
        {
            if (LogEmpleado.id_tipo == 6)
            {
            btnTaller.Visible = true;

            }
           }
        private void habilitarReportes()
        {
            if (LogEmpleado.id_tipo == 10)
            {
                btnReportes.Visible = true;
            }

        }

        protected void btnLogout_ServerClick(object sender, EventArgs e)
        {
            LogEmpleado = null;
         Server.Transfer("Default.aspx");

        }

    }
}