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
            if (LogEmpleado.id_tipo == 3)
        {
           btnCaja.Visible = true;

            }
}

        private void HabilitarOperario()
        {
            if (LogEmpleado.id_tipo == 2)
            {
            btnAltadetalle.Visible = true;
            btnCargardetalle.Visible = true;

             }
        }

        private void HabilitarTaller()
        {
            if (LogEmpleado.id_tipo == 1)
            {
            btnTaller.Visible = true;

            }
           }
        protected void btnLogout_ServerClick(object sender, EventArgs e)
        {
            LogEmpleado = null;
         Server.Transfer("Default.aspx");

        }

    }
}