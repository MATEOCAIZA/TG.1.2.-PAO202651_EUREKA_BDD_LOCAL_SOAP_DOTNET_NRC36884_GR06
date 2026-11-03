<%@ Page Title="Movimientos" Language="C#" MasterPageFile="~/Site.Master"
         AutoEventWireup="true" CodeBehind="Movimientos.aspx.cs"
         Inherits="CLIWEB_EUREKABANK_SOAP_DOTNET_GR01.Movimientos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="d-flex justify-content-between align-items-center mb-3">
    <h3 class="fw-bold" style="color:#0d47a1;">
        Extracto de Cuenta:
        <asp:Label ID="lblCuenta" runat="server" CssClass="text-primary" />
    </h3>
    <a href="Cuentas.aspx" class="btn btn-outline-secondary btn-sm">&larr; Volver</a>
</div>

<asp:Label ID="lblMsg" runat="server" CssClass="alert alert-danger d-block" Visible="false" />

<asp:GridView ID="gvMovimientos" runat="server" AutoGenerateColumns="false"
              CssClass="table table-striped table-bordered align-middle"
              EmptyDataText="No hay movimientos para esta cuenta.">
    <HeaderStyle CssClass="table-dark" />
    <Columns>
        <asp:BoundField DataField="NumeroOperacion" HeaderText="N&deg; Operaci&oacute;n"   />
        <asp:BoundField DataField="Fecha"           HeaderText="Fecha/Hora"
                        DataFormatString="{0:dd/MM/yyyy HH:mm}" />
        <asp:TemplateField HeaderText="Tipo">
            <ItemTemplate>
                <span class='<%# Eval("Tipo").ToString()=="Deposito" ? "badge bg-success" :
                                   Eval("Tipo").ToString()=="Retiro"   ? "badge bg-danger"  : "badge bg-info" %>'>
                    <%# Eval("Tipo") %>
                </span>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Monto"          HeaderText="Monto"          DataFormatString="{0:C}" />
        <asp:BoundField DataField="SaldoAnterior"  HeaderText="Saldo Anterior" DataFormatString="{0:C}" />
        <asp:BoundField DataField="SaldoPosterior" HeaderText="Saldo Posterior" DataFormatString="{0:C}" />
        <asp:BoundField DataField="EmpleadoNombre" HeaderText="Cajero"         />
        <asp:BoundField DataField="CuentaDestinoNum" HeaderText="Cta. Destino" />
    </Columns>
</asp:GridView>
</asp:Content>
