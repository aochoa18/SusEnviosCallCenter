<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClienteEdit.aspx.cs" Inherits="SusEnviosCallCenter.Cliente.ClienteEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form action="#" id="submit_form" novalidate="novalidate" method="POST" runat="server">
        <div class="col-md-12">
            <div class="card card-custom">
                <div class="card-header">
                    <div class="card-title">
                        <span class="card-icon">
                            <i class="fas fa-camera text-primary"></i>
                        </span>
                        <h3 class="card-label">Cliente</h3>
                    </div>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label class="control-label">Tipo de Documento</label>
                                <asp:DropDownList ID="cbIdTipoDocumento" runat="server" CssClass="form-control m-b"></asp:DropDownList>
                                <asp:HiddenField ID="hdId" runat="server"></asp:HiddenField>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label class="control-label">Numero de documento</label>
                                <asp:TextBox ID="txtNumeroDocumento" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label class="control-label">Nombres</label>
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label class="control-label">Apellidos</label>
                                <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label class="control-label">Direccion</label>
                                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label class="control-label">Celular</label>
                                <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label class="control-label">Email</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label class="control-label">Ciudad</label>
                                <asp:DropDownList ID="cbIdCiudad" runat="server" CssClass="form-control m-b"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label class="control-label">PlayerId</label>
                                <asp:TextBox ID="txtPlayerId" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="hr-line-dashed"></div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label class="control-label">PushToken</label>
                                <asp:TextBox ID="txtPushToken" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:HiddenField ID="hdEstado" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6 d-flex justify-content-between">
                            <button type="button" id="btnCancel" class="btn btn-default" onclick="window.location.href='ClienteList.aspx'">Cancelar</button>
                            <%--<asp:Button ID="btnCancel" Text="Cancelar" runat="server" CssClass="btn btn-default" OnClick="btnCancel_Click" />--%>
                            <asp:Button ID="btnSave" Text="Guardar" runat="server" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
<asp:Content ID="ContentScripts" ContentPlaceHolderID="BodyPlug" runat="server">
    <asp:Literal ID="ltScripts" runat="server"></asp:Literal>

    <script>
        $(document).ready(function () {
            var validatorJ = FormValidation.formValidation(
                document.getElementById('submit_form'),
                {
                    fields: {
                        ctl00$MainContent$cbIdTipoDocumento: {
                            validators: {
                                notEmpty: {
                                    message: 'Debe seleccionar el tipo de documento'
                                }
                            }
                        },
                        ctl00$MainContent$txtNumeroDocumento: {
                            validators: {
                                notEmpty: {
                                    message: 'El Campo Numero de documento es obligatorio'
                                },
                                digits: {
                                    message: 'El Campo Numero de documento debe estar compuesto solamente por digitos'
                                }
                            }
                        },
                        ctl00$MainContent$txtNombre: {
                            validators: {
                                notEmpty: {
                                    message: 'El campo Nombres es obligatorio'
                                }
                            }
                        },
                        ctl00$MainContent$txtApellidos: {
                            validators: {
                                notEmpty: {
                                    message: 'El campo Apellidos es obligatorio'
                                }
                            }
                        },
                        ctl00$MainContent$txtCelular: {
                            validators: {
                                notEmpty: {
                                    message: 'El campo Celular es obligatorio'
                                }
                            }
                        },
                        ctl00$MainContent$txtDireccion: {
                            validators: {
                                notEmpty: {
                                    message: 'El campo Celular es obligatorio'
                                }
                            }
                        },
                        ctl00$MainContent$txtEmail: {
                            validators: {
                                notEmpty: {
                                    message: 'El campo Email es obligatorio'
                                },
                                emailAddress: {
                                    message: 'Debe ingresar una direccion de correo valida.'
                                },
                            }
                        }
                    },
                    plugins: {
                        trigger: new FormValidation.plugins.Trigger(),
                        submitButton: new FormValidation.plugins.SubmitButton({
                            aspNetButton: true
                        }),
                        defaultSubmit: new FormValidation.plugins.DefaultSubmit(), // Uncomment this line to enable normal button submit after form validation
                        bootstrap: new FormValidation.plugins.Bootstrap()
                    }
                }
            );
        });
    </script>
</asp:Content>
