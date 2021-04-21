using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SusEnviosCallCenter.Business;
using SusEnviosCallCenter.Model;

namespace SusEnviosCallCenter.Usuario
{
    public partial class UsuarioList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                //Response.Redirect("/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                ClienteBackEnd business = new ClienteBackEnd();
                List<UsuarioModel> lista = new List<UsuarioModel>();//business.GetAllUsuarios();
                string content = "";
                foreach (UsuarioModel item in lista)
                {
                    content += "<tr>" +

                        "<td>" + item.ID + "</td>" +
                        "<td>" + item.UserName + "</td>" +
                        "<td>" + item.Activo + "</td>" +
                        "<td>" + item.XueUserCode + "</td>" +
                        "<td>" + item.idPerfil.Nombre + "</td>" +
                        "<td><span class=\"col-lg-4\"><a href=\"UsuarioEdit.aspx?View=0&Id=" + item.ID + "\"><i class=\"fa fa-eye\"></i>ver</a></span>" +
                        "<span class=\"col-lg-4\"><a href=\"UsuarioEdit.aspx?View=1&Id=" + item.ID + "\"><i class=\"fa fa-edit\"></i> editar </a></span></td></tr>";
                }
                this.ltTableItems.Text = content;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsuarioEdit.aspx");
        }
    }
}
