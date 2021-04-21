<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="VehiculoEdit.aspx.cs" Inherits="SusEnviosCallCenter.Vehiculo.VehiculoEdit" %>
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
                Vehiculo
            </div>
            <div class="panel-body">
                <div class="form-horizontal"><div class="form-group">
                        <label class="col-lg-2 control-label">Id</label>

                        <div class="col-lg-10">
                            <asp:Label ID="lbId" runat="server" CssClass="form-control-static"></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label"></label>
                        <div class="col-sm-10">
                            <asp:DropDownList ID="cbIdTipoVehiculo" runat="server" CssClass="form-control m-b"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="hr-line-dashed"></div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label"></label>
                        <div class="col-sm-10">
                            <asp:DropDownList ID="cbIdTipoVinculacion" runat="server" CssClass="form-control m-b"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="hr-line-dashed"></div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label"></label>
                            <div class="col-sm-10">
                            <asp:TextBox ID="txtPlaca" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="hr-line-dashed"></div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label"></label>
                            <div class="col-sm-10">
                            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="hr-line-dashed"></div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label"></label>
                            <div class="col-sm-10">
                            <asp:TextBox ID="txtCapacidad" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="hr-line-dashed"></div><asp:HiddenField ID="hdEstado" runat="server" />
                    <div class="form-group">
                        <label class="col-lg-2 control-label"></label>
                        <div class="col-sm-10">
                            <asp:DropDownList ID="cbPropietario" runat="server" CssClass="form-control m-b"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="hr-line-dashed"></div>
                    <div class="form-group">
                        <label class="col-lg-2 control-label"></label>
                        <div class="col-sm-10">
                            <asp:DropDownList ID="cbIdUsuario" runat="server" CssClass="form-control m-b"></asp:DropDownList>
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
            
            if ($("#MainWrapper_cbIdTipoVehiculo").val() == "") {
                str += "\n - .";
            }
            if ($("#MainWrapper_cbIdTipoVinculacion").val() == "") {
                str += "\n - .";
            }
            if ($("#MainWrapper_txtPlaca").val() == "") {
                str += "\n - .";
            }
            if ($("#MainWrapper_txtDescripcion").val() == "") {
                str += "\n - .";
            }
            if ($("#MainWrapper_txtCapacidad").val() == "") {
                str += "\n - .";
            }
            if ($("#MainWrapper_cbPropietario").val() == "") {
                str += "\n - .";
            }
            if ($("#MainWrapper_cbIdUsuario").val() == "") {
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
