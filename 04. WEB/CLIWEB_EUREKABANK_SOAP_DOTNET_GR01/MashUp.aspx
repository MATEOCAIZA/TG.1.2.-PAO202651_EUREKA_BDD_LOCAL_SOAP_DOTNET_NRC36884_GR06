<%@ Page Title="MashUp - Estado de Cuentas" Language="C#" MasterPageFile="~/Site.Master"
         AutoEventWireup="true" CodeBehind="MashUp.aspx.cs"
         Inherits="CLIWEB_EUREKABANK_SOAP_DOTNET_GR01.MashUp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="d-flex justify-content-between align-items-center mb-3">
    <h3 class="fw-bold" style="color:#0d47a1;">
        MashUp &ndash; Estado de Cuentas en Tiempo Real
    </h3>
    <span class="badge bg-secondary">Actualiza cada 4 seg.</span>
</div>

<div class="alert alert-info small mb-3">
    <strong>Verde</strong> = Cuenta disponible para transacciones &nbsp;|&nbsp;
    <strong>Rojo</strong> = Cuenta bloqueada por un cajero
</div>

<asp:UpdatePanel ID="upMashUp" runat="server">
    <ContentTemplate>
        <asp:Timer ID="timRefresh" runat="server" Interval="4000" OnTick="timRefresh_Tick" />
        <asp:Label ID="lblMsg" runat="server" CssClass="alert alert-danger d-block" Visible="false" />

        <div class="row row-cols-1 row-cols-md-3 g-3" id="divCuentas" runat="server">
        </div>
    </ContentTemplate>
</asp:UpdatePanel>

<script>
    // Fuerza refresco visual inmediato al cargar
    window.addEventListener('load', function () {
        var timer = document.querySelector('[id$="timRefresh"]');
        if (timer) timer.dispatchEvent(new Event('tick'));
    });
</script>
</asp:Content>
