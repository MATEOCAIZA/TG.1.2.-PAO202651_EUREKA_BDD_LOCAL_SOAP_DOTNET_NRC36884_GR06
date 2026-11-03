<%@ Page Title="Transacci&oacute;n" Language="C#" MasterPageFile="~/Site.Master"
         AutoEventWireup="true" CodeBehind="Transaccion.aspx.cs"
         Inherits="CLIWEB_EUREKABANK_SOAP_DOTNET_GR01.Transaccion" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="row justify-content-center">
<div class="col-md-7">
    <div class="card shadow-sm">
        <div class="card-header text-white fw-bold" style="background:#0d47a1;">
            Nueva Transacci&oacute;n
        </div>
        <div class="card-body">
            <asp:Label ID="lblMsg" runat="server" CssClass="alert d-block" Visible="false" />

            <div class="mb-3">
                <label for="txtCuentaID" class="form-label fw-semibold">N&uacute;mero de Cuenta Origen</label>
                <asp:TextBox ID="txtCuentaID" runat="server" CssClass="form-control"
                             placeholder="Ej. 2200100001" />
                <asp:RequiredFieldValidator ControlToValidate="txtCuentaID" runat="server"
                                           ErrorMessage="Requerido" CssClass="text-danger small" Display="Dynamic" />
            </div>

            <div class="mb-3">
                <label for="ddlTipo" class="form-label fw-semibold">Tipo de Operaci&oacute;n</label>
                <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-select"
                                  OnSelectedIndexChanged="ddlTipo_Changed" AutoPostBack="true">
                    <asp:ListItem Value="Deposito">Dep&oacute;sito</asp:ListItem>
                    <asp:ListItem Value="Retiro">Retiro</asp:ListItem>
                    <asp:ListItem Value="Transferencia">Transferencia</asp:ListItem>
                </asp:DropDownList>
            </div>

            <asp:Panel ID="pnlDestino" runat="server" Visible="false" CssClass="mb-3">
                <label for="txtCuentaDestino" class="form-label fw-semibold">N&uacute;mero de Cuenta Destino</label>
                <asp:TextBox ID="txtCuentaDestino" runat="server" CssClass="form-control"
                             placeholder="Ej. 2200100002" />
            </asp:Panel>

            <div class="mb-4">
                <label for="txtMonto" class="form-label fw-semibold">Monto ($)</label>
                <asp:TextBox ID="txtMonto" runat="server" CssClass="form-control"
                             placeholder="Ej. 250.00" />
                <asp:RequiredFieldValidator ControlToValidate="txtMonto" runat="server"
                                           ErrorMessage="Requerido" CssClass="text-danger small" Display="Dynamic" />
                <asp:RegularExpressionValidator ControlToValidate="txtMonto" runat="server"
                    ValidationExpression="^\d+(\.\d{1,2})?$"
                    ErrorMessage="Monto inv&aacute;lido" CssClass="text-danger small" Display="Dynamic" />
            </div>

            <asp:Button ID="btnEjecutar" runat="server" Text="Ejecutar Transacci&oacute;n"
                        CssClass="btn btn-success w-100 fw-bold"
                        OnClick="btnEjecutar_Click" />
        </div>
    </div>
</div>
</div>
</asp:Content>
