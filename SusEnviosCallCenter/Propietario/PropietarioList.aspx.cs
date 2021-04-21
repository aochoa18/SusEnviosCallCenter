using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SusEnviosCallCenter.Business;

namespace SusEnviosCallCenter.Propietario
{
    public partial class PropietarioList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
			{
				Response.Redirect("/Login.aspx");
			}
            if (!Page.IsPostBack)
            {
                PropietarioBusiness business = new PropietarioBusiness();
                List<SusEnviosCallCenter.Model.PropietarioModel> lista = business.GetAll();
                string content = "";
                foreach (SusEnviosCallCenter.Model.PropietarioModel item in lista)
                {
                    content += "<tr>" +
                        
                        "<td>" + item.Id + "</td>" +
                        "<td>" + item.Nombre + "</td>" +
                        "<td>" + new TipoDocumentoBusiness().GetById(item.IdTipoDocumento).Nombre + "</td>" +
                        "<td>" + item.NumeroDocumeto + "</td>" +
                        "<td>" + item.NombreContacto + "</td>" +
                        "<td>" + item.TelefonoContacto + "</td>" +
                        "<td>" + item.DireccionContacto + "</td>" +
                        "<td>" + new MunicipioBusiness().GetById(item.IdCiudad).Nombre + "</td>" +
                        "<td><span class=\"col-lg-4\"><a href=\"PropietarioEdit.aspx?View=0&Id=" + item.Id + "\"><i class=\"fa fa-eye\"></i>ver</a></span>" +
                        "<span class=\"col-lg-4\"><a href=\"PropietarioEdit.aspx?View=1&Id=" + item.Id + "\"><i class=\"fa fa-edit\"></i> editar </a></span></td></tr>";
                }
                this.ltTableItems.Text = content;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("PropietarioEdit.aspx");
        }
    }
}
