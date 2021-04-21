<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="UsuarioPosEdit.aspx.cs" Inherits="SusEnviosCallCenter.UsuarioPos.UsuarioPosEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainWrapper" runat="server">
    <div class="col-lg-10">
        <div class="hpanel">
            <div class="panel-heading">
                <div class="panel-tools">
                    <a class="showhide"><i class="fa fa-chevron-up"></i></a>
                    <a class="closebox"><i class="fa fa-times"></i></a>
                </div>
                UsuarioPos
            </div>
            <div class="panel-body">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-2 control-label"></label>
                        <div class="col-sm-10">
                            <asp:DropDownList ID="cbIdUsuario" runat="server" CssClass="form-control m-b"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="hr-line-dashed"></div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label"></label>
                            <div class="col-sm-10">
                            <asp:TextBox ID="txtlat" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="hr-line-dashed"></div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label"></label>
                            <div class="col-sm-10">
                            <asp:TextBox ID="txtlon" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="hr-line-dashed"></div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label"></label>
                            <div class="col-sm-10">
                            <div class="checkbox">
                                <label><asp:CheckBox ID="chkactivo" runat="server" /></label>
                            </div>
                        </div>
                    </div>
                    <div class="hr-line-dashed"></div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label"></label>
                            <div class="col-sm-10">
                            <div class="checkbox">
                                <label><asp:CheckBox ID="chkenEntrega" runat="server" /></label>
                            </div>
                        </div>
                    </div>
                    <div class="hr-line-dashed"></div>
                    <div class="form-group">
                        <div class="col-sm-8 col-sm-offset-2">
                            <asp:Button ID="btnCancel" Text="Cancelar" runat="server" CssClass="btn btn-default" OnClick="btnCancel_Click" />
                            <asp:Button ID="btnSave" Text="Guardar" runat="server" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="ContentScripts" ContentPlaceHolderID="scripts" runat="server">
    <asp:Literal ID="ltScripts" runat="server"></asp:Literal>    
        
    <script>
        $('#MainWrapper_btnSave').click(function(e){
            var str = "";
            
            if ($("#MainWrapper_cbIdUsuario").val() == "") {
                str += "\n - .";
            }
            if ($("#MainWrapper_txtlat").val() == "") {
                str += "\n - .";
            }
            if ($("#MainWrapper_txtlon").val() == "") {
                str += "\n - .";
            }
            if ($("#MainWrapper_chkactivo").val() == "") {
                str += "\n - .";
            }
            if ($("#MainWrapper_chkenEntrega").val() == "") {
                str += "\n - .";
            }
            if (str != "")
            {
                alert("Por favor verificar los siguientes campos:" + str);
                e.preventDefault();
            }
        });
    </script>
</asp:Content>
