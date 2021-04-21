using SusEnviosCallCenter.Business;
using SusEnviosCallCenter.Model;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace SusEnviosCallCenter.Servicio
{
    public partial class ServicioList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                string estado = Request.QueryString["estado"] ?? "Solicitado";
                ClienteBackEnd business = new ClienteBackEnd();
                List<ServicioModel> lista = business.GetServiciosByEstado(estado);
                string content = "";
                foreach (ServicioModel item in lista)
                {
                    content += "<tr>" +

                        "<td>" + item.Id + "</td>" +
                        "<td>" + item.idCiudadOrigen.Nombre + "</td>" +
                        "<td>" + item.idCiudadDestino.Nombre + "</td>" +
                        "<td>" + item.DireccionOrigen + "</td>" +
                        "<td>" + item.DireccionDestino + "</td>" +
                        "<td>" + item.DescripcionCarga + "</td>" +
                        "<td>" + item.estadoServicio.Nombre + "</td>" +
                        "<td>" + item.FechaSolicitud + "</td>" +
                        "<td>" + item.Valor + "</td>" +
                        "<td><span class=\"col-lg-12\"><a href=\"ServicioEdit.aspx?View=0&Id=" + item.Id + "\"><i class=\"fa fa-eye\"></i>ver</a></span></td></tr>";
                }
                ltTableItems.Text = content;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("ServicioEdit.aspx");
        }
    }
}
