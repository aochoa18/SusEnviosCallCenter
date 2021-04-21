using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SusEnviosCallCenter.Business;

namespace SusEnviosCallCenter.Propietario
{
    public partial class PropietarioEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
			{
				Response.Redirect("/Login.aspx");
			}
            if (!Page.IsPostBack)
            {
                this.cbIdTipoDocumento.DataSource = new TipoDocumentoBusiness().GetAll();
                this.cbIdTipoDocumento.DataTextField = "Nombre";
                this.cbIdTipoDocumento.DataValueField = "Id";
                this.cbIdTipoDocumento.DataBind();
                this.cbIdTipoDocumento.Items.Insert(0, new ListItem("[Seleccione]", ""));

                this.cbIdCiudad.DataSource = new MunicipioBusiness().GetAll();
                this.cbIdCiudad.DataTextField = "Nombre";
                this.cbIdCiudad.DataValueField = "Id";
                this.cbIdCiudad.DataBind();
                this.cbIdCiudad.Items.Insert(0, new ListItem("[Seleccione]", ""));

                if (Request.QueryString["Id"] != null)
                {
                    int id = int.Parse(Request.QueryString["Id"]);
                    SusEnviosCallCenter.Model.PropietarioModel obj = new PropietarioBusiness().GetById(id);
                    
                    this.lbId.Text = obj.Id.ToString();
                    this.txtNombre.Text = obj.Nombre;
                    this.cbIdTipoDocumento.SelectedValue = obj.IdTipoDocumento.ToString();
                    this.txtNumeroDocumeto.Text = obj.NumeroDocumeto;
                    this.txtNombreContacto.Text = obj.NombreContacto;
                    this.txtTelefonoContacto.Text = obj.TelefonoContacto;
                    this.txtDireccionContacto.Text = obj.DireccionContacto;
                    this.cbIdCiudad.SelectedValue = obj.IdCiudad.ToString();
                    this.hdEstado.Value = obj.Estado.ToString();
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
                SusEnviosCallCenter.Model.PropietarioModel obj;
                PropietarioBusiness business = new PropietarioBusiness();
                obj = new SusEnviosCallCenter.Model.PropietarioModel();
                
            obj.Nombre = this.txtNombre.Text;
            obj.IdTipoDocumento = int.Parse(this.cbIdTipoDocumento.SelectedValue);
            obj.NumeroDocumeto = this.txtNumeroDocumeto.Text;
            obj.NombreContacto = this.txtNombreContacto.Text;
            obj.TelefonoContacto = this.txtTelefonoContacto.Text;
            obj.DireccionContacto = this.txtDireccionContacto.Text;
            obj.IdCiudad = int.Parse(this.cbIdCiudad.SelectedValue);
            obj.Estado = bool.Parse(this.hdEstado.Value);
                if (Request.QueryString["Id"] != null)
                {
                    obj.Id = int.Parse(Request.QueryString["Id"]);
                    business.Update(obj);
                }
                else
                {
                    business.Create(obj);
                }
                this.ltScripts.Text = Utils.MessageBox("Atención", "El registro ha sido guardado exitósamente", "PropietarioList.aspx", "success");
            }
            catch(Exception)
            {
                this.ltScripts.Text = Utils.MessageBox("Atención", "No pudo ser guardado el registro, por favor verifique su información e intente nuevamente", null, "error");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("PropietarioList.aspx");
        }
    }
}
