<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioEdit.aspx.cs" Inherits="SusEnviosCallCenter.Usuario.UsuarioEdit" %>

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
                        <h3 class="card-label">Usuario</h3>
                    </div>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">UserName</label>
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:Label ID="lbId" runat="server" CssClass="form-control-static"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Activo</label>
                                <div class="checkbox">
                                    <label>
                                        <asp:CheckBox ID="chkActivo" runat="server" /></label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6 d-flex justify-content-between">
                            <asp:Button ID="btnCancel" Text="Cancelar" runat="server" CssClass="btn btn-default" OnClick="btnCancel_Click" />
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
        $('#MainWrapper_btnSave').click(function (e) {
            var str = "";

            if ($("#MainWrapper_chkActivo").val() == "") {
                str += "\n - .";
            }
            if (str != "") {
                alert("Por favor verificar los siguientes campos:" + str);
                e.preventDefault();
            }
        });
    </script>
</asp:Content>
