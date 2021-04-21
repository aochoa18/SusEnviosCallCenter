using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SusEnviosCallCenter.Business;
using SusEnviosCallCenter.Model;

namespace SusEnviosCallCenter.Usuario
{
    public partial class UsuarioEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                //Response.Redirect("/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    int id = int.Parse(Request.QueryString["Id"]);
                    UsuarioModel obj = null;//new ClienteBackEnd().GetCienteById(id);

                    this.lbId.Text = obj.ID.ToString();
                    this.txtUserName.Text = obj.UserName;
                    this.chkActivo.Checked = obj.Activo;
                }
                else
                {
                    //this.hdEstado.Value = true.ToString();
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
                SusEnviosCallCenter.Model.UsuarioModel obj;
                ClienteBackEnd business = new ClienteBackEnd();
                obj = new SusEnviosCallCenter.Model.UsuarioModel();

                obj.UserName = this.txtUserName.Text;
                obj.Activo = this.chkActivo.Checked;
                if (Request.QueryString["Id"] != null)
                {
                    obj.ID = int.Parse(Request.QueryString["Id"]);
                    //business.Update(obj);
                }
                else
                {
                    //business.Create(obj);
                }
                this.ltScripts.Text = Utils.MessageBox("Atención", "El registro ha sido guardado exitósamente", "UsuarioList.aspx", "success");
            }
            catch (Exception)
            {
                this.ltScripts.Text = Utils.MessageBox("Atención", "No pudo ser guardado el registro, por favor verifique su información e intente nuevamente", null, "error");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsuarioList.aspx");
        }
    }
}
