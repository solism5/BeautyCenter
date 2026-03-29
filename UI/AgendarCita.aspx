<%@ Page Title="Agendar Cita" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeBehind="AgendarCita.aspx.vb" Inherits="BeautyCenter.AgendarCita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <!-- Logo Section -->
        <div class="logo-section">
            <div class="logo-divider"></div>
            <img src="<%= ResolveUrl("~/Images/logo.png") %>" alt="Beauty Glow Center" />
            <div class="logo-divider"></div>
            <div class="logo-subtitle">Ciudad Col&oacute;n</div>
        </div>

        <!-- CLIENTE Section -->
        <div class="section-label">Cliente</div>

        <div class="form-group">
            <label>Seleccionar Cliente</label>
            <asp:DropDownList ID="ddlClientes" runat="server" CssClass="form-input">
            </asp:DropDownList>
        </div>

        <!-- PROCEDIMIENTO Section -->
        <div class="section-label">Procedimiento</div>
        <div class="form-group">
            <label>Procedimiento de Belleza</label>
            <asp:DropDownList ID="ddlProcedimientos" runat="server" CssClass="form-input">
            </asp:DropDownList>
        </div>

        <!-- FECHA Y HORA Section -->
        <div class="section-label">Fecha y Hora</div>
        <div class="form-group">
            <label>Fecha de la Cita</label>
            <asp:TextBox ID="txtFechaCita" runat="server" CssClass="form-input" TextMode="DateTimeLocal" />
        </div>

        <!-- Confirmar -->
        <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar Cita" CssClass="btn-primary" OnClick="btnConfirmar_Click" />

        <asp:Label ID="lblMensaje" runat="server" />
    </div>
</asp:Content>
