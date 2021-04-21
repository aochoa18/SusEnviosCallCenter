<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PersonaEdit.aspx.cs" Inherits="SusEnviosCallCenter.Persona.PersonaEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form action="#" id="submit_form" novalidate="novalidate" method="POST" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div class="col-md-12">
            <div class="card card-custom">
                <div class="card-header">
                    <div class="card-title">
                        <span class="card-icon">
                            <i class="fas fa-camera text-primary"></i>
                        </span>
                        <h3 class="card-label">Persona</h3>
                    </div>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Tipo De Documento</label>
                                <asp:DropDownList ID="cbIdTipoDocumento" runat="server" CssClass="form-control m-b"></asp:DropDownList>
                                <asp:HiddenField ID="hdId" runat="server"></asp:HiddenField>
                                <asp:HiddenField ID="hdIdUsuario" runat="server"></asp:HiddenField>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Numero de Documento</label>
                                <asp:TextBox ID="txtNumeroDocumento" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Nombres</label>
                                <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Apellidos</label>
                                <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Celular</label>
                                <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <asp:HiddenField ID="hdEstado" runat="server" />
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Email</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <%--<div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label"></label>
                                <asp:TextBox ID="txtFoto" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>--%>
                    </div>
                    <div class="row">
                        <div class="col-lg-6 d-flex justify-content-between">
                            <button type="button" id="btnCancel" class="btn btn-default" onclick="window.location.href='PersonaList.aspx'">Cancelar</button>
                            <asp:Button ID="btnSave" Text="Guardar" runat="server" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <% if (hdId.Value != "")
                            {
                                if (hdIdUsuario.Value != "")
                                { %>
                        <h1>Tiene Usuario</h1>
                        <% }
                            else
                            {
                        %>
                        <h1>No Tiene Usuario</h1>
                        <%
                                }
                            }
                            else
                            {%>
                        <div class="col-md-3">
                            <div class="form-group">
                                <div class="checkbox-inline">
                                    <label class="checkbox checkbox-lg">
                                        <asp:CheckBox ID="chkCrearUsuario" runat="server" />
                                        <span></span>
                                        Incluir la creación del usuario.
                                    </label>
                                </div>
                            </div>
                        </div>
                        <%} %>
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
                        ctl00$MainContent$txtNombres: {
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
