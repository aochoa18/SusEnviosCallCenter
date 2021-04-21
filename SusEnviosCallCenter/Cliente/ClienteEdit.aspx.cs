using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SusEnviosCallCenter.Business;
using SusEnviosCallCenter.Model;

namespace SusEnviosCallCenter.Cliente
{
    public partial class ClienteEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                //Response.Redirect("/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                List<TipoDocumentoModel> tiposDoc = new List<TipoDocumentoModel> { new TipoDocumentoModel { Id = 1, Nombre = "CC" } };

                this.cbIdTipoDocumento.DataSource = tiposDoc;
                this.cbIdTipoDocumento.DataTextField = "Nombre";
                this.cbIdTipoDocumento.DataValueField = "Id";
                this.cbIdTipoDocumento.DataBind();
                this.cbIdTipoDocumento.Items.Insert(0, new ListItem("[Seleccione]", ""));

                /*this.cbIdCiudad.DataSource = new MunicipioBusiness().GetAll();
                this.cbIdCiudad.DataTextField = "Nombre";
                this.cbIdCiudad.DataValueField = "Id";
                this.cbIdCiudad.DataBind();
                this.cbIdCiudad.Items.Insert(0, new ListItem("[Seleccione]", ""));*/

                if (Request.QueryString["Id"] != null)
                {
                    int id = int.Parse(Request.QueryString["Id"]);
                    ClienteModel obj = new ClienteModel();// new ClienteBusiness().GetById(id);

                    this.hdId.Value = obj.Id.ToString();
                    this.cbIdTipoDocumento.SelectedValue = obj.IdTipoDocumento.ToString();
                    this.txtNumeroDocumento.Text = obj.NumeroDocumento;
                    this.txtNombre.Text = obj.Nombre;
                    this.txtApellidos.Text = obj.Apellidos;
                    this.txtDireccion.Text = obj.Direccion;
                    this.txtCelular.Text = obj.Celular;
                    this.txtEmail.Text = obj.Email;
                    //this.txtPassword.Text = obj.Password;
                    this.cbIdCiudad.SelectedValue = obj.IdCiudad.ToString();
                    this.txtPlayerId.Text = obj.PlayerId;
                    this.txtPushToken.Text = obj.PushToken;
                    this.hdEstado.Value = obj.Estado.ToString();
                }
                else
                {
                    this.hdEstado.Value = true.ToString();
                }


                if (Request.QueryString["View"] == "0")
                {
                    Utils.DisableForm(this.Controls);
                    //btnCancel.Enabled = true;
                }
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteModel obj;
                ClienteBackEnd business = new ClienteBackEnd();
                obj = new ClienteModel();

                obj.IdTipoDocumento = int.Parse(this.cbIdTipoDocumento.SelectedValue);
                obj.NumeroDocumento = this.txtNumeroDocumento.Text;
                obj.Nombre = this.txtNombre.Text;
                obj.Apellidos = this.txtApellidos.Text;
                obj.Direccion = this.txtDireccion.Text;
                obj.Celular = this.txtCelular.Text;
                obj.Email = this.txtEmail.Text;
                obj.IdCiudad = int.Parse(this.cbIdCiudad.SelectedValue);
                obj.PlayerId = this.txtPlayerId.Text;
                obj.PushToken = this.txtPushToken.Text;
                obj.Estado = bool.Parse(this.hdEstado.Value);
                if (Request.QueryString["Id"] != null)
                {
                    obj.Id = int.Parse(Request.QueryString["Id"]);
                    //business.Update(obj);
                }
                else
                {
                    //business.Create(obj);
                }
                this.ltScripts.Text = Utils.MessageBox("Atención", "El registro ha sido guardado exitósamente", "ClienteList.aspx", "success");
            }
            catch (Exception)
            {
                this.ltScripts.Text = Utils.MessageBox("Atención", "No pudo ser guardado el registro, por favor verifique su información e intente nuevamente", null, "error");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClienteList.aspx");
        }
    }
}
