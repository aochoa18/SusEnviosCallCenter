using Newtonsoft.Json.Linq;
using SusEnviosCallCenter.Business;
using SusEnviosCallCenter.Model;
using System;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace SusEnviosCallCenter
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false)]
        public static string LoginUser(string Login, string Password)
        {
            Login log = new Login();
            string json = "";
            try
            {
                respuestaLogin Result = log.BuscaUsuario(Login, Password);
                var jsonSerialiser = new JavaScriptSerializer();
                json = jsonSerialiser.Serialize(Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return json;
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = false)]
        public static string RecoveryPassword(string correo)
        {
            Login log = new Login();
            string json = "";
            try
            {
                //respuestaRecovery Result = log.EnviarCorreoRecovery(correo);
                //var jsonSerialiser = new JavaScriptSerializer();
                //json = jsonSerialiser.Serialize(Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return json;
        }

        public respuestaLogin BuscaUsuario(string user, string password)
        {
            string llave = ConfigurationManager.AppSettings["Usuario"].ToString();

            respuestaLogin respuesta = new respuestaLogin();
            Session["Conectado"] = "";
            Session["IdUsuario"] = "";
            Session["Usuario"] = "";
            Session["IdTipoUsuario"] = "";
            Session["NombreCompleto"] = "";
            Session["Login"] = null;
            Session["Email"] = null;
            Session["IdEstablecimiento"] = "";

            if (!String.IsNullOrEmpty(user) && !String.IsNullOrEmpty(password))
            {
                UsuarioModel userLogin;
                string contrasena = RationalSWUtils.Criptography.CreateMD5(password);
                if (user.Contains("@"))
                {
                    userLogin = new ClienteBackEnd().Login(user, contrasena);
                }
                else
                {
                    userLogin = new ClienteBackEnd().Login(user, contrasena);
                }

                if (userLogin != null)
                {
                    Session["IdUsuario"] = userLogin.ID.ToString();
                    //Session["IdEstablecimiento"] = userLogin.IdEstablecimiento.ToString();
                    Session["Usuario"] = userLogin.UserName.ToString();
                    Session["IdTipoUsuario"] = 1;
                    Session["Nombres"] = userLogin.idPersona.Nombres.ToString();
                    Session["Nombres"] = userLogin.idPersona.Nombres.ToString();
                    Session["Apellidos"] = userLogin.idPersona.Apellidos.ToString();
                    Session["Login"] = user.Trim();
                    Session["FechaIngreso"] = DateTime.Now.ToString();
                    Session["Email"] = userLogin.idPersona.Email.ToString();

                    ClienteBackEnd business = new ClienteBackEnd();
                    JObject jParams = business.GetParametros();
                    Session["Parametros"] = jParams;


                    respuesta.idRol = 1;
                    respuesta.idUsuario = int.Parse(userLogin.ID.ToString());
                }
            }
            return respuesta;
        }

        //public respuestaRecovery EnviarCorreoRecovery(string correo)
        //{
        //    string llave = ConfigurationManager.AppSettings["Usuario"].ToString();

        //    SusEnviosCallCenter.Model.ClienteModel userLogin;
        //    userLogin = new ClienteBackEnd().Login(correo);
        //    RecoveryPasswordCliente recovery = new RecoveryPasswordCliente(llave);
        //    RecoveryPasswordModel passwordModel = new RecoveryPasswordModel();
        //    respuestaRecovery resp = new respuestaRecovery();
        //    if (userLogin != null)
        //    {
        //        DateTime FechaHora = DateTime.Now;
        //        byte[] time = BitConverter.GetBytes(FechaHora.ToBinary());
        //        byte[] key = Guid.NewGuid().ToByteArray();
        //        string token = Convert.ToBase64String(time.Concat(key).ToArray());
        //        passwordModel.IdUsuario = userLogin.Id;
        //        passwordModel.Token = token;
        //        passwordModel.FechaCreacion = FechaHora;
        //        passwordModel.FechaVencimiento = FechaHora.AddHours(24);
        //        passwordModel.Estado = true;
        //        recovery.Create(passwordModel);
        //        EmailBussines emailBussines = new EmailBussines();
        //        string path = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority;
        //        emailBussines.SendMailRecovery(passwordModel, userLogin, path);
        //        resp.result = 1;
        //    }
        //    else
        //    {
        //        resp.result = 0;
        //    }
        //    return resp;
        //}

    }

    public class respuestaLogin
    {
        public int idRol { get; set; }
        public int idUsuario { get; set; }
    }

    public class respuestaRecovery
    {
        public int result { get; set; }
    }
}