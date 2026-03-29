<%@ Page Title="Iniciar Sesión" Language="VB" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="BeautyCenter.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Login - Beauty Glow Center</title>
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
        .login-box {
            background: white;
            padding: 35px 30px;
            border-radius: 8px;
            box-shadow: 0 2px 8px rgba(0,0,0,0.1);
            width: 340px;
        }
        .login-box h2 {
            color: #7C3AED;
            text-align: center;
            margin-bottom: 5px;
            font-size: 22px;
        }
        .login-box p.subtitle {
            text-align: center;
            color: #999;
            font-size: 12px;
            margin-bottom: 25px;
        }
        .login-box label {
            display: block;
            margin-bottom: 4px;
            font-size: 13px;
            color: #555;
        }
        .login-box input[type=text],
        .login-box input[type=password] {
            width: 100%;
            padding: 9px 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            margin-bottom: 14px;
            font-size: 13px;
            box-sizing: border-box;
        }
        .login-box input:focus {
            outline: none;
            border-color: #7C3AED;
        }
        .btn-login {
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
        .btn-login:hover {
            background: #6D28D9;
        }
        .link-register {
            text-align: center;
            margin-top: 18px;
            font-size: 12px;
            color: #777;
        }
        .link-register a {
            color: #7C3AED;
            text-decoration: none;
        }
        .link-register a:hover {
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-box">
            <h2>&#10022; Beauty Glow Center</h2>
            <p class="subtitle">Iniciar Sesi&oacute;n</p>

            <label>Correo electr&oacute;nico</label>
            <asp:TextBox ID="txtCorreo" runat="server" placeholder="correo@ejemplo.com" />

            <label>Contrase&ntilde;a</label>
            <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" placeholder="Tu contraseña" />

            <asp:Button ID="btnLogin" runat="server" Text="Entrar" CssClass="btn-login" OnClick="btnLogin_Click" />

            <asp:Label ID="lblMensaje" runat="server" />

            <div class="link-register">
                &iquest;No tienes cuenta? <a href="Register.aspx">Reg&iacute;strate aqu&iacute;</a>
            </div>
        </div>
    </form>
</body>
</html>
