using System;
using System.Web.UI;

namespace SusEnviosCallCenter
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("/Login.aspx");
            }
        }
    }
}