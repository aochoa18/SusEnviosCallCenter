using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SusEnviosCallCenter.Business;
using SusEnviosCallCenter.Model;

namespace SusEnviosCallCenter.Cliente
{
    public partial class ClienteList : System.Web.UI.Page
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
                List<ClienteModel> lista = new List<ClienteModel>();// business.GetAll();
                string content = "";
                foreach (SusEnviosCallCenter.Model.ClienteModel item in lista)
                {
                    content += "<tr>" +
                        
                        "<td>" + item.Id + "</td>" +
                        "<td>" + item.idTipoDocumento.Nombre + "</td>" +
                        "<td>" + item.NumeroDocumento + "</td>" +
                        "<td>" + item.Nombre + "</td>" +
                        "<td>" + item.Apellidos + "</td>" +
                        "<td>" + item.Direccion + "</td>" +
                        "<td>" + item.Celular + "</td>" +
                        "<td>" + item.Email + "</td>" +
                        "<td>" + item.Password + "</td>" +
                        "<td>" + item.idCiudad.Nombre + "</td>" +
                        "<td><span class=\"col-lg-4\"><a href=\"ClienteEdit.aspx?View=0&Id=" + item.Id + "\"><i class=\"fa fa-eye\"></i>ver</a></span>" +
                        "<span class=\"col-lg-4\"><a href=\"ClienteEdit.aspx?View=1&Id=" + item.Id + "\"><i class=\"fa fa-edit\"></i> editar </a></span></td></tr>";
                }
                this.ltTableItems.Text = content;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClienteEdit.aspx");
        }
    }
}
