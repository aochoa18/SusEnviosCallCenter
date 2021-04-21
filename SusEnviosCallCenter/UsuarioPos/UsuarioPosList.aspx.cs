using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SusEnviosCallCenter.Business;

namespace SusEnviosCallCenter.UsuarioPos
{
    public partial class UsuarioPosList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
			{
				Response.Redirect("/Login.aspx");
			}
            if (!Page.IsPostBack)
            {
                UsuarioPosBusiness business = new UsuarioPosBusiness();
                List<SusEnviosCallCenter.Model.UsuarioPosModel> lista = business.GetAll();
                string content = "";
                foreach (SusEnviosCallCenter.Model.UsuarioPosModel item in lista)
                {
                    content += "<tr>" +
                        
                        "<td>" + new UsuarioBusiness().GetById(item.IdUsuario).Nombre + "</td>" +
                        "<td>" + item.lat + "</td>" +
                        "<td>" + item.lon + "</td>" +
                        "<td>" + item.activo + "</td>" +
                        "<td>" + item.enEntrega + "</td>" +
                        "<td><span class=\"col-lg-4\"><a href=\"UsuarioPosEdit.aspx?View=0&Id=" + item.Id + "\"><i class=\"fa fa-eye\"></i>ver</a></span>" +
                        "<span class=\"col-lg-4\"><a href=\"UsuarioPosEdit.aspx?View=1&Id=" + item.Id + "\"><i class=\"fa fa-edit\"></i> editar </a></span></td></tr>";
                }
                this.ltTableItems.Text = content;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsuarioPosEdit.aspx");
        }
    }
}
