<%@ Page Title="Cuentas" Language="C#" MasterPageFile="~/Site.Master"
         AutoEventWireup="true" CodeBehind="Cuentas.aspx.cs"
         Inherits="CLIWEB_EUREKABANK_SOAP_DOTNET_GR01.Cuentas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="d-flex justify-content-between align-items-center mb-3">
    <h3 class="fw-bold" style="color:#0d47a1;">
        Cuentas de la Sucursal
        <asp:Label ID="lblSucursal" runat="server" CssClass="text-muted fs-5" />
    </h3>
    <div>
        <asp:Label ID="lblEmpleado" runat="server" CssClass="badge bg-primary fs-6 me-2" />
        <a href="Transaccion.aspx" class="btn btn-success btn-sm">+ Nueva Transacci&oacute;n</a>
    </div>
</div>

<asp:Label ID="lblMsg" runat="server" CssClass="alert alert-info d-block" Visible="false" />

<asp:GridView ID="gvCuentas" runat="server" AutoGenerateColumns="false"
              CssClass="table table-bordered table-hover align-middle"
              OnRowCommand="gvCuentas_RowCommand"
              EmptyDataText="No hay cuentas registradas para esta sucursal.">
    <HeaderStyle CssClass="table-dark" />
    <Columns>
        <asp:BoundField DataField="NumeroCuenta"  HeaderText="N&deg; Cuenta"  />
        <asp:BoundField DataField="ClienteNombre" HeaderText="Titular"    />
        <asp:BoundField DataField="Cedula"        HeaderText="C&eacute;dula"     />
        <asp:BoundField DataField="Saldo"         HeaderText="Saldo"      DataFormatString="{0:C}" />
        <asp:BoundField DataField="Estado"        HeaderText="Estado"     />
        <asp:TemplateField HeaderText="Disponibilidad">
            <ItemTemplate>
                <span class='<%# Convert.ToBoolean(Eval("Bloqueada")) ? "badge bg-danger" : "badge bg-success" %>'>
                    <%# Convert.ToBoolean(Eval("Bloqueada")) ? "&#128308; Bloqueada &mdash; " + Eval("BloqueadaPorNombre") : "&#128994; Disponible" %>
                </span>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:LinkButton runat="server" CommandName="VerMovimientos"
                                CommandArgument='<%# Eval("CuentaID") + "|" + Eval("NumeroCuenta") %>'
                                CssClass="btn btn-outline-primary btn-sm">Movimientos</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</asp:Content>
