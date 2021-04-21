using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SusEnviosCallCenter.Business;

namespace SusEnviosCallCenter.Vehiculo
{
    public partial class VehiculoEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
			{
				Response.Redirect("/Login.aspx");
			}
            if (!Page.IsPostBack)
            {
                this.cbIdTipoVehiculo.DataSource = new TipoVehiculoBusiness().GetAll();
                this.cbIdTipoVehiculo.DataTextField = "Nombre";
                this.cbIdTipoVehiculo.DataValueField = "Id";
                this.cbIdTipoVehiculo.DataBind();
                this.cbIdTipoVehiculo.Items.Insert(0, new ListItem("[Seleccione]", ""));

                this.cbIdTipoVinculacion.DataSource = new TipoVinculacionBusiness().GetAll();
                this.cbIdTipoVinculacion.DataTextField = "Nombre";
                this.cbIdTipoVinculacion.DataValueField = "Id";
                this.cbIdTipoVinculacion.DataBind();
                this.cbIdTipoVinculacion.Items.Insert(0, new ListItem("[Seleccione]", ""));

                this.cbPropietario.DataSource = new PropietarioBusiness().GetAll();
                this.cbPropietario.DataTextField = "Nombre";
                this.cbPropietario.DataValueField = "Id";
                this.cbPropietario.DataBind();
                this.cbPropietario.Items.Insert(0, new ListItem("[Seleccione]", ""));

                this.cbIdUsuario.DataSource = new UsuarioBusiness().GetAll();
                this.cbIdUsuario.DataTextField = "Nombre";
                this.cbIdUsuario.DataValueField = "Id";
                this.cbIdUsuario.DataBind();
                this.cbIdUsuario.Items.Insert(0, new ListItem("[Seleccione]", ""));

                if (Request.QueryString["Id"] != null)
                {
                    int id = int.Parse(Request.QueryString["Id"]);
                    SusEnviosCallCenter.Model.VehiculoModel obj = new VehiculoBusiness().GetById(id);
                    
                    this.lbId.Text = obj.Id.ToString();
                    this.cbIdTipoVehiculo.SelectedValue = obj.IdTipoVehiculo.ToString();
                    this.cbIdTipoVinculacion.SelectedValue = obj.IdTipoVinculacion.ToString();
                    this.txtPlaca.Text = obj.Placa;
                    this.txtDescripcion.Text = obj.Descripcion;
                    this.txtCapacidad.Text = obj.Capacidad.ToString();
                    this.hdEstado.Value = obj.Estado.ToString();
                    this.cbPropietario.SelectedValue = obj.Propietario.ToString();
                    this.cbIdUsuario.SelectedValue = obj.IdUsuario.ToString();
                }
                else
                {
                    this.hdEstado.Value = true.ToString();
                }
                

                if (Request.QueryString["View"] == "0")
                {
                    Utils.DisableForm(this.Controls);
                    btnCancel.Enabled = true;
                }
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SusEnviosCallCenter.Model.VehiculoModel obj;
                VehiculoBusiness business = new VehiculoBusiness();
                obj = new SusEnviosCallCenter.Model.VehiculoModel();
                
            obj.IdTipoVehiculo = int.Parse(this.cbIdTipoVehiculo.SelectedValue);
            obj.IdTipoVinculacion = int.Parse(this.cbIdTipoVinculacion.SelectedValue);
            obj.Placa = this.txtPlaca.Text;
            obj.Descripcion = this.txtDescripcion.Text;
            obj.Capacidad = double.Parse(this.txtCapacidad.Text);
            obj.Estado = bool.Parse(this.hdEstado.Value);
            obj.Propietario = int.Parse(this.cbPropietario.SelectedValue);
            obj.IdUsuario = int.Parse(this.cbIdUsuario.SelectedValue);
                if (Request.QueryString["Id"] != null)
                {
                    obj.Id = int.Parse(Request.QueryString["Id"]);
                    business.Update(obj);
                }
                else
                {
                    business.Create(obj);
                }
                this.ltScripts.Text = Utils.MessageBox("Atención", "El registro ha sido guardado exitósamente", "VehiculoList.aspx", "success");
            }
            catch(Exception)
            {
                this.ltScripts.Text = Utils.MessageBox("Atención", "No pudo ser guardado el registro, por favor verifique su información e intente nuevamente", null, "error");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("VehiculoList.aspx");
        }
    }
}
