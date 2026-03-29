<%@ Page Title="Registro" Language="VB" AutoEventWireup="false" CodeBehind="Register.aspx.vb" Inherits="BeautyCenter.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Registro - Beauty Glow Center</title>
    <style>
        body {
            font-family: 'Segoe UI', sans-serif;
            background-color: #f8f9fa;
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
            margin: 0;
        }
        .register-box {
            background: white;
            padding: 35px 30px;
            border-radius: 8px;
            box-shadow: 0 2px 8px rgba(0,0,0,0.1);
            width: 360px;
        }
        .register-box h2 {
            color: #7C3AED;
            text-align: center;
            margin-bottom: 5px;
            font-size: 22px;
        }
        .register-box p.subtitle {
            text-align: center;
            color: #999;
            font-size: 12px;
            margin-bottom: 25px;
        }
        .register-box label {
            display: block;
            margin-bottom: 4px;
            font-size: 13px;
            color: #555;
        }
        .register-box input[type=text],
        .register-box input[type=password],
        .register-box select {
            width: 100%;
            padding: 9px 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            margin-bottom: 14px;
            font-size: 13px;
            box-sizing: border-box;
            font-family: inherit;
        }
        .register-box input:focus,
        .register-box select:focus {
            outline: none;
            border-color: #7C3AED;
        }
        .btn-register {
            width: 100%;
            padding: 10px;
            background: #7C3AED;
            color: white;
            border: none;
            border-radius: 6px;
            font-size: 14px;
            cursor: pointer;
            margin-top: 5px;
        }
        .btn-register:hover {
            background: #6D28D9;
        }
        .link-login {
            text-align: center;
            margin-top: 18px;
            font-size: 12px;
            color: #777;
        }
        .link-login a {
            color: #7C3AED;
            text-decoration: none;
        }
        .link-login a:hover {
            text-decoration: underline;
        }
        .msg-error {
            color: #DC2626;
            background: #FEF2F2;
            border: 1px solid #FECACA;
            padding: 8px 10px;
            border-radius: 5px;
            margin-top: 10px;
            font-size: 12px;
            text-align: center;
        }
        .msg-success {
            color: #16A34A;
            background: #F0FDF4;
            border: 1px solid #BBF7D0;
            padding: 8px 10px;
            border-radius: 5px;
            margin-top: 10px;
            font-size: 12px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="register-box">
            <h2>&#10022; Beauty Glow Center</h2>
            <p class="subtitle">Crear Cuenta</p>

            <label>Nombre completo</label>
            <asp:TextBox ID="txtNombre" runat="server" placeholder="Tu nombre" />

            <label>Correo electr&oacute;nico</label>
            <asp:TextBox ID="txtCorreo" runat="server" placeholder="correo@ejemplo.com" />

            <label>Tel&eacute;fono</label>
            <asp:TextBox ID="txtTelefono" runat="server" placeholder="+506 0000-0000" />

            <label>Contrase&ntilde;a</label>
            <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" placeholder="Tu contraseña" />

            <label>Rol</label>
            <asp:DropDownList ID="ddlRol" runat="server">
                <asp:ListItem Text="Cliente" Value="Cliente" />
                <asp:ListItem Text="Administrador" Value="Administrador" />
            </asp:DropDownList>

            <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" CssClass="btn-register" OnClick="btnRegistrar_Click" />

            <asp:Label ID="lblMensaje" runat="server" />

            <div class="link-login">
                &iquest;Ya tienes cuenta? <a href="Login.aspx">Inicia sesi&oacute;n</a>
            </div>
        </div>
    </form>
</body>
</html>
