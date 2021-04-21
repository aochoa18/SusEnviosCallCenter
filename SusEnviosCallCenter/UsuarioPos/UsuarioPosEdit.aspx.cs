using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SusEnviosCallCenter.Business;

namespace SusEnviosCallCenter.UsuarioPos
{
    public partial class UsuarioPosEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
			{
				Response.Redirect("/Login.aspx");
			}
            if (!Page.IsPostBack)
            {
                this.cbIdUsuario.DataSource = new UsuarioBusiness().GetAll();
                this.cbIdUsuario.DataTextField = "Nombre";
                this.cbIdUsuario.DataValueField = "Id";
                this.cbIdUsuario.DataBind();
                this.cbIdUsuario.Items.Insert(0, new ListItem("[Seleccione]", ""));


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
                SusEnviosCallCenter.Model.UsuarioPosModel obj;
                UsuarioPosBusiness business = new UsuarioPosBusiness();
                obj = new SusEnviosCallCenter.Model.UsuarioPosModel();
                
            obj.IdUsuario = int.Parse(this.cbIdUsuario.SelectedValue);
            obj.lat = decimal.Parse(this.txtlat.Text);
            obj.lon = decimal.Parse(this.txtlon.Text);
            obj.activo = this.chkactivo.Checked;
            obj.enEntrega = this.chkenEntrega.Checked;
                business.Create(obj);
                this.ltScripts.Text = Utils.MessageBox("Atención", "El registro ha sido guardado exitósamente", "UsuarioPosList.aspx", "success");
            }
            catch(Exception)
            {
                this.ltScripts.Text = Utils.MessageBox("Atención", "No pudo ser guardado el registro, por favor verifique su información e intente nuevamente", null, "error");
            }
    }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsuarioPosList.aspx");
        }
    }
}
