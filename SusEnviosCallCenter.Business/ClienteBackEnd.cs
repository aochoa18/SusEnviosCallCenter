using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SusEnviosCallCenter.Model;
using System.Collections.Generic;

namespace SusEnviosCallCenter.Business
{
    public class ClienteBackEnd : ClienteBase
    {
        public UsuarioModel Login(string Login, string Password)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            object objectLogin = new
            {
                username = Login,
                password = Password
            };
            ModelRespuesta mr = ConsumirPorPost("LoginUsuario", param, objectLogin);
            if (mr.Value == null)
                return null;
            else
                return JsonConvert.DeserializeObject<UsuarioModel>(mr.Value);
        }

        public ClienteModel GetCienteById(int idCliente)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            object model = new
            {
                idUsuario = idCliente
            };
            ModelRespuesta mr = ConsumirPorPost("GetUsuario", param, model);
            if (mr.Value == null)
                return null;
            else
                return JsonConvert.DeserializeObject<ClienteModel>(mr.Value);
        }

        public JObject GetParametros()
        {
            ModelRespuesta mr = ConsumirPorPost("GetParametros", null, null);
            if (mr.Value == null)
                return null;
            else
                return JsonConvert.DeserializeObject<JObject>(mr.Value);
        }

        public List<ServicioModel> GetServiciosByEstado(string estado)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            object model = new
            {
                estado = estado
            };
            ModelRespuesta mr = ConsumirPorPost("GetServicios", param, model);
            if (mr.Value == null)
                return null;
            else
                return JsonConvert.DeserializeObject<List<ServicioModel>>(mr.Value);
        }

        public ServicioModel GetServicioById(int idServicio)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            object model = new
            {
                id = idServicio
            };
            ModelRespuesta mr = ConsumirPorPost("GetServicio", param, model);
            if (mr.Value == null)
                return null;
            else
                return JsonConvert.DeserializeObject<ServicioModel>(mr.Value);
        }

        public ServicioModel UpdateServicio(ServicioRequest servicio)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            object model = new
            {
                servicio = JsonConvert.SerializeObject(servicio)
            };
            ModelRespuesta mr = ConsumirPorPost("UpdateServicio", param, model);
            if (mr.Value == null)
                return null;
            else
                return JsonConvert.DeserializeObject<ServicioModel>(mr.Value);
        }

        public void CrearRegistroServicio(RegistroServicioRequest registroServicio)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            object model = new
            {
                registroServicio = JsonConvert.SerializeObject(registroServicio)
            };
            ModelRespuesta mr = ConsumirPorPost("CrearRegistroServicio", param, model);
        }

        public List<UsuarioPosModel> GetCamionesByPos(string lon, string lat, string idTipoCamion)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            object model = new
            {
                lat = lat,
                lon = lon,
                idTipoCamion = idTipoCamion
            };
            ModelRespuesta mr = ConsumirPorPost("GetVehiculosByPos", param, model);
            if (mr.Value == null)
                return null;
            else
                return JsonConvert.DeserializeObject<List<UsuarioPosModel>>(mr.Value);
        }

        public List<PersonaModel> GetAllPersonas()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            ModelRespuesta mr = ConsumirPorPost("GetAllPersonas", param, null);
            if (mr.Value == null)
                return null;
            else
                return JsonConvert.DeserializeObject<List<PersonaModel>>(mr.Value);
        }
    }
}
