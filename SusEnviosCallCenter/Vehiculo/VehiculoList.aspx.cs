using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SusEnviosCallCenter.Business;

namespace SusEnviosCallCenter.Vehiculo
{
    public partial class VehiculoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
			{
				Response.Redirect("/Login.aspx");
			}
            if (!Page.IsPostBack)
            {
                VehiculoBusiness business = new VehiculoBusiness();
                List<SusEnviosCallCenter.Model.VehiculoModel> lista = business.GetAll();
                string content = "";
                foreach (SusEnviosCallCenter.Model.VehiculoModel item in lista)
                {
                    content += "<tr>" +
                        
                        "<td>" + item.Id + "</td>" +
                        "<td>" + new TipoVehiculoBusiness().GetById(item.IdTipoVehiculo).Nombre + "</td>" +
                        "<td>" + new TipoVinculacionBusiness().GetById(item.IdTipoVinculacion).Nombre + "</td>" +
                        "<td>" + item.Placa + "</td>" +
                        "<td>" + item.Descripcion + "</td>" +
                        "<td>" + item.Capacidad + "</td>" +
                        "<td>" + new PropietarioBusiness().GetById(item.Propietario).Nombre + "</td>" +
                        "<td>" + new UsuarioBusiness().GetById(item.IdUsuario).Nombre + "</td>" +
                        "<td><span class=\"col-lg-4\"><a href=\"VehiculoEdit.aspx?View=0&Id=" + item.Id + "\"><i class=\"fa fa-eye\"></i>ver</a></span>" +
                        "<span class=\"col-lg-4\"><a href=\"VehiculoEdit.aspx?View=1&Id=" + item.Id + "\"><i class=\"fa fa-edit\"></i> editar </a></span></td></tr>";
                }
                this.ltTableItems.Text = content;
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("VehiculoEdit.aspx");
        }
    }
}
