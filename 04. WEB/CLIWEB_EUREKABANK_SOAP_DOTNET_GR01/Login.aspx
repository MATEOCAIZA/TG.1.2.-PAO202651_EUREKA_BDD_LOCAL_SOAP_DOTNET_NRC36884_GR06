<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs"
         Inherits="CLIWEB_EUREKABANK_SOAP_DOTNET_GR01.Login" %>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Eureka Bank &ndash; Acceso</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        html, body { height: 100%; margin: 0; background: #0a0f1e; }
        .login-wrap { display: flex; height: 100vh; }
        .panel-left {
            flex: 0 0 45%;
            background: linear-gradient(160deg,#0d47a1 0%,#01579b 60%,#0a237c 100%);
            display: flex; flex-direction: column;
            align-items: center; justify-content: center; color: #fff; padding: 40px;
        }
        .panel-left img { max-width: 220px; margin-bottom: 24px; border-radius: 12px; }
        .panel-left .bank-name { font-size: 2.2rem; font-weight: 700; letter-spacing: 2px; }
        .panel-left .tagline   { font-size: 1rem; opacity: .75; margin-top: 8px; }
        .panel-right {
            flex: 1; display: flex; align-items: center; justify-content: center;
            background: #f0f4ff;
        }
        .login-card {
            background: #fff; border-radius: 16px; padding: 48px 40px;
            box-shadow: 0 8px 40px rgba(0,0,0,.14); width: 100%; max-width: 400px;
        }
        .login-card h3 { color: #0d47a1; font-weight: 700; margin-bottom: 6px; }
        .login-card p  { color: #666; font-size: .9rem; margin-bottom: 28px; }
        .btn-bank { background: #0d47a1; border-color: #0d47a1; width: 100%; font-weight: 600; }
        .btn-bank:hover { background: #1565c0; border-color: #1565c0; }
        .alert-msg { display: none; }
    </style>
    <link href="Content/eureka-hud.css" rel="stylesheet" />
</head>
<body>
<div class="login-wrap">
    <!-- PANEL IZQUIERDO: imagen del banco -->
    <div class="panel-left">
        <%-- Imagen del tema común --%>
        <img src="Content/hud.jpg"
             onerror="this.style.display='none'"
             alt="Eureka Bank" />
        <div class="bank-name">EUREKA BANK</div>
        <div class="tagline">Sistema Transaccional Centralizado</div>
    </div>

    <!-- PANEL DERECHO: formulario -->
    <div class="panel-right">
        <div class="login-card">
            <h3>Bienvenido</h3>
            <p>Ingresa tus credenciales para continuar</p>

            <form runat="server" id="frmLogin">
                <asp:Label ID="lblError" runat="server" CssClass="alert alert-danger d-block mb-3"
                           Visible="false" />

                <div class="mb-3">
                    <label class="form-label fw-semibold">Usuario</label>
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"
                                 placeholder="Ej. monster" />
                    <asp:RequiredFieldValidator ControlToValidate="txtUsuario" runat="server"
                                               ErrorMessage="Requerido" CssClass="text-danger small"
                                               Display="Dynamic" />
                </div>
                <div class="mb-4">
                    <label class="form-label fw-semibold">Contrase&ntilde;a</label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"
                                 CssClass="form-control" placeholder="************" />
                    <asp:RequiredFieldValidator ControlToValidate="txtPassword" runat="server"
                                               ErrorMessage="Requerido" CssClass="text-danger small"
                                               Display="Dynamic" />
                </div>
                <asp:Button ID="btnLogin" runat="server" Text="Ingresar"
                            CssClass="btn btn-primary btn-bank"
                            OnClick="btnLogin_Click" />
            </form>
        </div>
    </div>
</div>
<script src="Scripts/jquery-3.7.0.min.js"></script>
<script src="Scripts/bootstrap.bundle.min.js"></script>
</body>
</html>
