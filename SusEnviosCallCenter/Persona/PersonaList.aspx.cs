using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SusEnviosCallCenter.Business;
using SusEnviosCallCenter.Model;

namespace SusEnviosCallCenter.Persona
{
    public partial class PersonaList : System.Web.UI.Page
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
                List<PersonaModel> lista = new List<PersonaModel>(); //business.GetAllPersonas();
                string content = "";
                foreach (PersonaModel item in lista)
                {
                    content += "<tr>" +

                        "<td>" + item.Id + "</td>" +
                        "<td>" + item.idTipoDocumento.Nombre + "</td>" +
                        "<td>" + item.NumeroDocumento + "</td>" +
                        "<td>" + item.Nombres + "</td>" +
                        "<td>" + item.Apellidos + "</td>" +
                        "<td>" + item.Celular + "</td>" +
                        "<td>" + item.Foto + "</td>" +
                        "<td>" + item.Email + "</td>" +
                        "<td>" + item.Estado + "</td>" +
                        "<td><span class=\"col-lg-4\"><a href=\"PersonaEdit.aspx?View=0&Id=" + item.Id + "\"><i class=\"fa fa-eye\"></i>ver</a></span>" +
                        "<span class=\"col-lg-4\"><a href=\"PersonaEdit.aspx?View=1&Id=" + item.Id + "\"><i class=\"fa fa-edit\"></i> editar </a></span></td></tr>";
                }
                this.ltTableItems.Text = content;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("PersonaEdit.aspx");
        }
    }
}
