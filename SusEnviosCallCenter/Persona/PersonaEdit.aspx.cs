using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SusEnviosCallCenter.Business;
using SusEnviosCallCenter.Model;

namespace SusEnviosCallCenter.Persona
{
    public partial class PersonaEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                //Response.Redirect("/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                //List<TipoDocumentoModel> tiposDoc = Utils.GetItemsFromParameters<List<TipoDocumentoModel>>(Session["Parametros"], "tipoDocumento");
                List<TipoDocumentoModel> tiposDoc = new List<TipoDocumentoModel> { new TipoDocumentoModel { Id = 1, Nombre = "CC" } };

                this.cbIdTipoDocumento.DataSource = tiposDoc;
                this.cbIdTipoDocumento.DataTextField = "Nombre";
                this.cbIdTipoDocumento.DataValueField = "Id";
                this.cbIdTipoDocumento.DataBind();
                this.cbIdTipoDocumento.Items.Insert(0, new ListItem("[Seleccione]", ""));

                if (Request.QueryString["Id"] != null)
                {
                    int id = int.Parse(Request.QueryString["Id"]);
                    PersonaModel obj = null;// new ClienteBackEnd().GetPersonaById(id);

                    this.hdId.Value = obj.Id.ToString();
                    this.hdIdUsuario.Value = obj.idUsuario == null ? "" : obj.idUsuario.ID.ToString();
                    this.cbIdTipoDocumento.SelectedValue = obj.IdTipoDocumento.ToString();
                    this.txtNumeroDocumento.Text = obj.NumeroDocumento;
                    this.txtNombres.Text = obj.Nombres;
                    this.txtApellidos.Text = obj.Apellidos;
                    this.txtCelular.Text = obj.Celular;
                    //this.txtFoto.Text = obj.Foto;
                    this.hdEstado.Value = obj.Estado.ToString();
                    this.txtEmail.Text = obj.Email;
                }
                else
                {
                    this.hdEstado.Value = true.ToString();
                }


                if (Request.QueryString["View"] == "0")
                {
                    Utils.DisableForm(this.Controls);
                }
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                PersonaModel obj;
                ClienteBackEnd business = new ClienteBackEnd();
                obj = new PersonaModel();

                obj.idTipoDocumento = new TipoDocumentoModel { Id = int.Parse(this.cbIdTipoDocumento.SelectedValue) };
                obj.NumeroDocumento = this.txtNumeroDocumento.Text;
                obj.Nombres = this.txtNombres.Text;
                obj.Apellidos = this.txtApellidos.Text;
                obj.Celular = this.txtCelular.Text;
                //obj.Foto = this.txtFoto.Text;
                obj.Estado = bool.Parse(this.hdEstado.Value);
                obj.Email = this.txtEmail.Text;
                if (Request.QueryString["Id"] != null)
                {
                    obj.Id = int.Parse(Request.QueryString["Id"]);
                    //business.UpdatePersona(obj);
                }
                else
                {
                    //business.CreatePersona(obj);
                }
                this.ltScripts.Text = Utils.MessageBox("Atención", "El registro ha sido guardado exitósamente", "PersonaList.aspx", "success");
            }
            catch (Exception)
            {
                this.ltScripts.Text = Utils.MessageBox("Atención", "No pudo ser guardado el registro, por favor verifique su información e intente nuevamente", null, "error");
            }
        }
    }
}
