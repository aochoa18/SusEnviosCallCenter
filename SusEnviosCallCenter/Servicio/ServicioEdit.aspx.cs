using SusEnviosCallCenter.Business;
using SusEnviosCallCenter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SusEnviosCallCenter.Servicio
{
    public partial class ServicioEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] == null)
            {
                Response.Redirect("/Login.aspx");
            }
            if (Request.QueryString["Id"] == null)
            {
                Response.Redirect("/ServiciosList.aspx");

            }
            if (!Page.IsPostBack)
            {
                List<CategoriaVehiculoModel> cateCam = Utils.GetItemsFromParameters<List<CategoriaVehiculoModel>>(Session["Parametros"], "categoriasVehiculo");

                List<TipoVehiculoModel> query = cateCam
                    .SelectMany(cat => cat.tipoVehiculos)
                    .ToList();

                cbIdTipoCamion.DataSource = query;
                cbIdTipoCamion.DataTextField = "Nombre";
                cbIdTipoCamion.DataValueField = "Id";
                cbIdTipoCamion.DataBind();
                cbIdTipoCamion.Items.Insert(0, new ListItem("[Seleccione]", ""));

                List<EstadoServicioModel> estados = Utils.GetItemsFromParameters<List<EstadoServicioModel>>(Session["Parametros"], "estadosServicio");

                cbEstadoServicio.DataSource = estados;
                cbEstadoServicio.DataTextField = "Nombre";
                cbEstadoServicio.DataValueField = "Id";
                cbEstadoServicio.DataBind();
                cbEstadoServicio.Items.Insert(0, new ListItem("[Seleccione]", ""));

                if (Request.QueryString["Id"] != null)
                {
                    ClienteBackEnd business = new ClienteBackEnd();

                    int id = int.Parse(Request.QueryString["Id"]);
                    ServicioModel obj = business.GetServicioById(id);

                    hdId.Value = obj.Id.ToString();
                    hdIdCliente.Value = obj.idCliente.Id.ToString();
                    txtCliente.Text = obj.idCliente.Nombre + " " + obj.idCliente.Apellidos;
                    cbIdTipoCamion.SelectedValue = obj.idTipoCamion == null ? "" : obj.idTipoCamion.Id.ToString();
                    hdIdCiudadOrigen.Value = obj.idCiudadOrigen.Id.ToString();
                    txtCiudadOrigen.Text = obj.idCiudadOrigen.Nombre.ToString();
                    hdIdCiudadDestino.Value = obj.idCiudadDestino.Id.ToString();
                    txtCiudadDestino.Text = obj.idCiudadDestino.Nombre.ToString();
                    txtDireccionOrigen.Text = obj.DireccionOrigen;
                    txtDireccionDestino.Text = obj.DireccionDestino;
                    txtDescripcionCarga.Text = obj.DescripcionCarga;
                    cbEstadoServicio.SelectedValue = obj.estadoServicio.Id.ToString();
                    txtFechaSolicitud.Text = obj.FechaSolicitud.ToString("yyyy-MM-dd hh:mm:ss tt");
                    txtValor.Text = decimal.Parse(obj.Valor.ToString()).ToString();

                    txtCamion.Text = (obj.IdUsuario == null) ? "" : obj.idUsuario.UserName;
                    hdnIdCamion.Value = (obj.IdUsuario == null) ? "" : obj.idUsuario.ID.ToString();

                    hdnLatDestino.Value = obj.latDest.ToString();
                    hdnLonDestino.Value = obj.lonDest.ToString();
                    hdnLatOrigen.Value = "4.588529";//obj.latOrigen.ToString();
                    hdnLonOrigen.Value = "-74.161869";// obj.lonOrigen.ToString();

                    if (obj.estadoServicio.Nombre == "Solicitado")
                    {
                        List<UsuarioPosModel> camiones = business.GetCamionesByPos(hdnLonOrigen.Value, hdnLatOrigen.Value, cbIdTipoCamion.SelectedValue);

                        /*List<UsuarioPosModel> camionesFP = camiones.Where(x => x.idCamion2.IdTipoVinculacion.Nombre == "Propio").ToList();
                        List<UsuarioPosModel> camionesTR = camiones.Where(x => x.idCamion2.IdTipoVinculacion.Nombre == "Tercero").ToList();
                        */
                        rptCamiones.DataSource = camiones;
                        rptCamiones.ItemDataBound += new RepeaterItemEventHandler
                           (rptCamiones_ItemDataBound);
                        rptCamiones.DataBind();

                        rptCamionesTerceros.DataSource = camiones;
                        rptCamionesTerceros.ItemDataBound += new RepeaterItemEventHandler
                           (rptCamiones_ItemDataBound);
                        rptCamionesTerceros.DataBind();
                    }
                    string content = "";
                    foreach (RegistroServicioModel item in obj.registroServicios)
                    {
                        content += "<tr>" +

                            "<td>" + item.Id + "</td>" +
                            "<td>" + item.Observacion + "</td>" +
                            "<td>" + string.Format("{0:yyyy-MM-dd hh:mm:ss tt}", item.FechaRegistro) + "</td>" +
                            "</tr>";
                    }
                    ltTableItems.Text = content;
                }
                else
                {
                    //this.hdEstado.Value = true.ToString();
                }


                if (Request.QueryString["View"] == "0")
                {
                    Utils.DisableForm(Controls);
                    cbEstadoServicio.Enabled = true;
                    txtObservacion.Enabled = true;
                    btnSaveComment.Enabled = true;
                    btnSave.Enabled = true;
                    btnCancel.Enabled = true;
                    foreach (RepeaterItem item in rptCamiones.Items)
                    {
                        (item.FindControl("btnAsignar") as Button).Enabled = true;
                    }

                    foreach (RepeaterItem item in rptCamionesTerceros.Items)
                    {
                        (item.FindControl("btnAsignar") as Button).Enabled = true;
                    }
                }
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteBackEnd business = new ClienteBackEnd();

                RegistroServicioRequest registroServicio = new RegistroServicioRequest
                {
                    fechaRegistro = DateTime.Now,
                    id = 0,
                    idEstadoServicio = int.Parse(cbEstadoServicio.SelectedValue),
                    idServicio = int.Parse(hdId.Value),
                    observacion = "Se realiza cambio de estado: Estado nuevo = " + cbEstadoServicio.SelectedItem.Text
                };
                business.CrearRegistroServicio(registroServicio);

                ltScripts.Text = Utils.MessageBox("Atención", "El registro ha sido guardado exitósamente", "ServicioList.aspx", "success");
            }
            catch (Exception)
            {
                ltScripts.Text = Utils.MessageBox("Atención", "No pudo ser guardado el registro, por favor verifique su información e intente nuevamente", null, "error");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ServicioList.aspx");
        }

        protected void btnSaveComment_Click(object sender, EventArgs e)
        {
            RegistroServicioRequest registroServicio = new RegistroServicioRequest
            {
                fechaRegistro = DateTime.Now,
                id = 0,
                idEstadoServicio = int.Parse(cbEstadoServicio.SelectedValue),
                idServicio = int.Parse(hdId.Value),
                observacion = txtObservacion.Text
            };
            Business.ClienteBackEnd business = new ClienteBackEnd();
            business.CrearRegistroServicio(registroServicio);
            ltScripts.Text = Utils.MessageBox("Atención", "El registro ha sido guardado exitósamente", Request.RawUrl, "success");
        }

        protected void rptCamiones_ItemDataBound(Object sender, RepeaterItemEventArgs args)
        {
            if (args.Item.ItemType == ListItemType.Item || args.Item.ItemType == ListItemType.AlternatingItem)
            {
                UsuarioPosModel item = args.Item.DataItem as UsuarioPosModel;
                Label lblPlaca = args.Item.FindControl("lblPlaca") as Label;
                Label lblConductor = args.Item.FindControl("lblConductor") as Label;
                Label lblTelefono = args.Item.FindControl("lblTelefono") as Label;
                Button btnAsignar = args.Item.FindControl("btnAsignar") as Button;
                lblPlaca.Text = item.IdUsuario.ToString();
                lblConductor.Text = item.IdUsuario.ToString();// item.idCamion2.Tripulantes[0].Nombres + " " + item.idCamion2.Tripulantes[0].Apellidos;
                lblTelefono.Text = item.IdUsuario.ToString();// item.idCamion2.Tripulantes[0].Celular;
                btnAsignar.Enabled = true;
            }
        }

        protected void rptCamionesTerceros_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Asignar")
            {
                int idCamion = int.Parse(e.CommandArgument.ToString());
                ClienteBackEnd business = new ClienteBackEnd();

                int id = int.Parse(Request.QueryString["Id"]);
                ServicioModel obj = business.GetServicioById(id);

                obj.IdUsuario = idCamion;

                obj = business.UpdateServicio(new ServicioRequest
                {
                    descripcionCarga = obj.DescripcionCarga,
                    direccionDestino = obj.DireccionDestino,
                    direccionOrigen = obj.DireccionOrigen,
                    estadoServicio = obj.EstadoServicio,
                    fechaSolicitud = obj.FechaSolicitud,
                    id = obj.Id,
                    idCamion = obj.IdUsuario.Value,
                    idCiudadDestino = obj.IdCiudadDestino,
                    idCiudadOrigen = obj.IdCiudadOrigen,
                    idCliente = obj.IdCliente,
                    idTipoCamion = obj.IdTipoCamion.Value,
                    latDest = obj.latDest.Value,
                    lonDest = obj.lonDest.Value,
                    latOrigen = obj.latOrigen.Value,
                    lonOrigen = obj.lonOrigen.Value,
                    valor = obj.Valor
                });
                int nuevoEstado = Utils.GetItemsFromParameters<List<EstadoServicioModel>>(Session["Parametros"], "estadosServicio").Where(x => x.Nombre == "Programado").FirstOrDefault().Id;
                RegistroServicioRequest registroServicio = new RegistroServicioRequest
                {
                    fechaRegistro = DateTime.Now,
                    id = 0,
                    idEstadoServicio = nuevoEstado,
                    idServicio = int.Parse(hdId.Value),
                    observacion = "Se realiza la asignacion del camion con Placa: " + obj.IdUsuario.ToString() /*obj.idCamion.Placa*/ + ". El estado del pedido es Programado."
                };
                business.CrearRegistroServicio(registroServicio);

                EmailBussines emailBussines = new EmailBussines();

                string html = "Estimado usuario " + obj.idCliente.Nombre + " " + obj.idCliente.Apellidos;
                html += "<br /><br />Se ha asignado el camion a su solicitud de servicio y esta ha pasado a estado <b>Programado</b>";
                html += "<br /><br />Los datos del Camion son: ";
                html += "<br /><b>Placa:</b> " + obj.idUsuario.idPersona.NumeroDocumento;
                html += "<br /><b>Descripcion:</b> " + obj.idUsuario.idPersona.NumeroDocumento;
                /* html += "<br /><br /><b>Tripulantes:</b> ";
                 foreach (PersonaModel tripulante in obj.idUsuario.idPersona)
                 {
                     html += "<br /><b>Nombre:</b> " + tripulante.Nombres + " " + tripulante.Apellidos;
                     html += "<br /><b>Celular:</b> " + tripulante.Celular;
                     //string tipoTripulante = "";//(Utils.GetItemsFromParameters<List<TipoTripulanteModel>>(Session["Parametros"], "tiposTripulante")).Where(x => x.Id == tripulante.idTipoTripulante).FirstOrDefault().Nombre;
                     //html += "<br /><b>Tipo Tripulante:</b> " + tipoTripulante;
                 }*/

                html += "<br /><br /><b>Propietario:</b> ";
                html += "<br /><b>Nombre:</b> " + obj.idUsuario.idPersona.Nombres;
                html += "<br /><b>Nombre Contancto:</b> " + obj.idUsuario.idPersona.NumeroDocumento;
                html += "<br /><b>Telefono Contacto:</b> " + obj.idUsuario.idPersona.Celular;
                html += "<br /><b>Direccion Contacto:</b> " + obj.idUsuario.idPersona.Celular;

                emailBussines.sendMailGeneric(obj.idCliente.Email, html, "Camion asignado a su solicitud");

                ltScripts.Text = Utils.MessageBox("Atención", "Se ha asignado correctamente el camión.", Request.RawUrl, "success");
            }
        }
    }
}
