<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ServicioEdit.aspx.cs" Inherits="SusEnviosCallCenter.Servicio.ServicioEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form action="#" id="submit_form" method="POST" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div class="col-md-12">
            <div class="card card-custom">
                <div class="card-header">
                    <div class="card-title">
                        <span class="card-icon">
                            <i class="fas fa-camera text-primary"></i>
                        </span>
                        <h3 class="card-label">Servicio</h3>
                    </div>
                </div>
                <div class="card-body">
                    <div class="row">
                        <asp:HiddenField ID="hdId" runat="server"></asp:HiddenField>
                        <div class="col-3">
                            <label class="control-label">Cliente</label>
                            <asp:TextBox ID="txtCliente" runat="server" CssClass="form-control m-b"></asp:TextBox>
                            <asp:HiddenField ID="hdIdCliente" runat="server"></asp:HiddenField>
                        </div>
                        <div class="col-3">
                            <label class="control-label">Tipo de Camión</label>
                            <asp:DropDownList ID="cbIdTipoCamion" runat="server" CssClass="form-control m-b"></asp:DropDownList>
                        </div>
                        <div class="col-3">
                            <label class="control-label">Ciudad De Origen</label>
                            <asp:TextBox ID="txtCiudadOrigen" runat="server" CssClass="form-control m-b"></asp:TextBox>
                            <asp:HiddenField ID="hdIdCiudadOrigen" runat="server"></asp:HiddenField>
                        </div>
                        <div class="col-3">
                            <label class="control-label">Ciudad De Destino</label>
                            <asp:TextBox ID="txtCiudadDestino" runat="server" CssClass="form-control m-b"></asp:TextBox>
                            <asp:HiddenField ID="hdIdCiudadDestino" runat="server"></asp:HiddenField>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            <label class="control-label">Direccion de Origen</label>
                            <asp:TextBox ID="txtDireccionOrigen" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-3">
                            <label class="control-label">Direccion de Destino</label>
                            <asp:TextBox ID="txtDireccionDestino" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="col-3">
                            <label class="control-label">Descripcion de la entrega</label>
                            <asp:TextBox ID="txtDescripcionCarga" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-3">
                            <label class="control-label">Estado Servicio</label>
                            <asp:DropDownList ID="cbEstadoServicio" runat="server" CssClass="form-control m-b"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            <label class="control-label">Fecha Solicitud</label>
                            <div class="input-group date datetimepicker" id="datetimepicker2">
                                <div class="input-group-prepend">
                                    <span class="input-group-text fa fa-calendar"></span>
                                </div>
                                <asp:TextBox ID="txtFechaSolicitud" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-3">
                            <label class="control-label">Camion Asignado</label>
                            <asp:TextBox ID="txtCamion" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:HiddenField ID="hdnIdCamion" runat="server"></asp:HiddenField>
                        </div>
                        <div class="col-3">
                            <label class="control-label">Valor</label>
                            <asp:TextBox ID="txtValor" runat="server" CssClass="form-control inputCurrency"></asp:TextBox>
                            <asp:HiddenField ID="hdnLatOrigen" runat="server" />
                            <asp:HiddenField ID="hdnLonOrigen" runat="server" />
                            <asp:HiddenField ID="hdnLatDestino" runat="server" />
                            <asp:HiddenField ID="hdnLonDestino" runat="server" />
                        </div>
                        <div class="col-3">
                            <% if (cbEstadoServicio.SelectedValue == "1")
                                { %>
                            <br />
                            <button id="btnShowCamiones" type="button" data-toggle="modal" data-target="#mdlCamiones" class="btn btn-primary">Ver camiones disponibles</button>
                            <% } %>
                        </div>
                    </div>
                    <br />
                    <br />
                    <hr />
                    <div class="row">
                        <div class="col-lg-6 d-flex justify-content-between">
                            <asp:Button ID="btnCancel" Text="Cancelar" runat="server" CssClass="btn btn-default" OnClick="btnCancel_Click" />
                            <button id="btnValidate" type="button" onclick="ValidarForm()" class="btn btn-primary">Guardar</button>
                            <asp:Button ID="btnSave" Text="Guardar" runat="server" CssClass="hidden" OnClick="btnSave_Click" />
                        </div>
                    </div>
                    <br />
                    <hr />
                    <div class="row">
                        <div class="col-6">
                            <h4>Historial de registros</h4>
                        </div>
                        <div class="col-3">
                            <button id="btnShowModal" type="button" data-toggle="modal" data-target="#staticBackdrop" class="btn btn-primary">Añadir Comentario</button>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-12">
                            <table id="example2" class="table table-striped table-bordered table-hover">
                                <thead>
                                    <tr>
                                        <th>Id</th>
                                        <th>Observacion</th>
                                        <th>Fecha Registro</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Literal ID="ltTableItems" runat="server"></asp:Literal>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="card-footer d-flex justify-content-between">
                </div>
            </div>
        </div>

        <!--Begin:Modal-->
        <div class="modal fade" id="staticBackdrop" data-backdrop="static" tabindex="-1" role="dialog" aria-labelledby="staticBackdrop" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Agregar Observación</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <i aria-hidden="true" class="ki ki-close"></i>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-4">
                                <h4>Observación:</h4>
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtObservacion" TextMode="multiline" CssClass="form-control" runat="server" Rows="5"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-light-primary font-weight-bold" data-dismiss="modal">Cerrar</button>
                        <asp:Button ID="btnSaveComment" CssClass="btn btn-primary font-weight-bold" Text="Agregar Observación" runat="server" OnClick="btnSaveComment_Click"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
        <!--End:Modal-->

        <!--Begin:Modal-->
        <div class="modal fade" id="mdlCamiones" data-backdrop="static" tabindex="-1" role="dialog" aria-labelledby="staticBackdrop" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="mdlTitleCamiones">Camiones que coinciden con la busqueda</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <i aria-hidden="true" class="ki ki-close"></i>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="accordion  accordion-toggle-arrow" id="accordionExample4">
                            <div class="card">
                                <div class="card-header" id="headingTwo4">
                                    <div class="card-title collapsed" data-toggle="collapse" data-target="#collapseTwo4">
                                        <i class="far fa-credit-card"></i>Camiones Fuerza Propia
                                    </div>
                                </div>
                                <div id="collapseTwo4" class="collapse" data-parent="#accordionExample4">
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col-md-3">
                                                <label class="font-weight-bolder">Placa Vehiculo:</label>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="font-weight-bolder">Nombre Conductor:</label>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="font-weight-bolder">Telefono Conductor:</label>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="font-weight-bolder">Accion:</label>
                                            </div>
                                        </div>
                                        <asp:Repeater ID="rptCamiones" OnItemCommand="rptCamionesTerceros_ItemCommand" runat="server">
                                            <ItemTemplate>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <asp:Label ID="lblPlaca" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:Label ID="lblConductor" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:Label ID="lblTelefono" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:Button ID="btnAsignar" runat="server" CommandName="Asignar" CommandArgument='<%# Eval("idCamion") %>' CssClass="btn btn-danger font-weight-bolder font-size-sm" Text="Asignar"></asp:Button>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </div>
                            <div class="card">
                                <div class="card-header" id="headingOne4">
                                    <div class="card-title collapsed" data-toggle="collapse" data-target="#collapseOne4">
                                        <i class="far fa-credit-card"></i>Camiones de terceros
                                    </div>
                                </div>
                                <div id="collapseOne4" class="collapse" data-parent="#accordionExample4">
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col-md-3">
                                                <label class="font-weight-bolder">Placa Vehiculo:</label>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="font-weight-bolder">Nombre Conductor:</label>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="font-weight-bolder">Telefono Conductor:</label>
                                            </div>
                                            <div class="col-md-3">
                                                <label class="font-weight-bolder">Accion:</label>
                                            </div>
                                        </div>
                                        <asp:Repeater ID="rptCamionesTerceros" OnItemCommand="rptCamionesTerceros_ItemCommand" runat="server">
                                            <ItemTemplate>
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        <asp:Label ID="lblPlaca" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:Label ID="lblConductor" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:Label ID="lblTelefono" runat="server"></asp:Label>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:Button ID="btnAsignar" runat="server" CommandName="Asignar" CommandArgument='<%# Eval("idCamion") %>' CssClass="btn btn-danger font-weight-bolder font-size-sm" Text="Asignar"></asp:Button>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-light-primary font-weight-bold" data-dismiss="modal">Aceptar</button>
                    </div>
                </div>
            </div>
        </div>
        <!--End:Modal-->
    </form>
</asp:Content>
<asp:Content ID="ContentScripts" ContentPlaceHolderID="BodyPlug" runat="server">
    <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
    <script src="../assets/js/pages/crud/ktdatatable/base/html-table.js"></script>
    <script src="../assets/plugins/custom/datatables/datatables.bundle.js"></script>
    <script>
        function ValidarForm() {
            $('#MainContent_btnSave').click();
        };
    </script>
</asp:Content>
