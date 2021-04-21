<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="UsuarioPosList.aspx.cs" Inherits="SusEnviosCallCenter.UsuarioPos.UsuarioPosList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainWrapper" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <div class="hpanel">
                <div class="panel-heading">
                    <div class="panel-tools">
                        <a class="showhide"><i class="fa fa-chevron-up"></i></a>
                        <a class="closebox"><i class="fa fa-times"></i></a>
                    </div>
                    Seleccione:
                </div>
                <div class="panel-body">
                    <p><asp:Button ID="btnNew" runat="server" Text="Nuevo Registro" CssClass="btn btn-primary" OnClick="btnNew_Click" /></p>
                    <table id="example2" class="table table-striped table-bordered table-hover">
                        <thead>
                            <tr>
                            <th></th>
                            <th></th>
                            <th></th>
                            <th></th>
                            <th></th>  
                                <th></th>                              
                            </tr>
                        </thead>
                        <tbody>
                           <asp:Literal ID="ltTableItems" runat="server"></asp:Literal>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="scripts">
</asp:Content>
