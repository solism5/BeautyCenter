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

        <div class="toggle-group">
            <label class="toggle-btn active" id="lblNuevo">
                <input type="radio" name="clienteType" value="nuevo" checked="checked" onclick="toggleCliente('nuevo')" />
                Cliente Nuevo
            </label>
            <label class="toggle-btn" id="lblExistente">
                <input type="radio" name="clienteType" value="existente" onclick="toggleCliente('existente')" />
                Cliente Existente
            </label>
        </div>

        <asp:HiddenField ID="hfClienteType" runat="server" Value="nuevo" />

        <!-- Panel: Cliente Nuevo -->
        <div id="pnlNuevo" class="client-panel active">
            <div class="form-group">
                <label>Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-input" placeholder="Nombre completo" />
            </div>
            <div class="form-group">
                <label>Correo electr&oacute;nico</label>
                <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-input" TextMode="Email" placeholder="correo@ejemplo.com" />
            </div>
            <div class="form-group">
                <label>Tel&eacute;fono</label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-input" placeholder="+506 0000-0000" />
            </div>
        </div>

        <!-- Panel: Cliente Existente -->
        <div id="pnlExistente" class="client-panel">
            <div class="form-group">
                <label>Seleccionar Cliente</label>
                <asp:DropDownList ID="ddlClientes" runat="server" CssClass="form-input">
                </asp:DropDownList>
            </div>
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

    <script type="text/javascript">
        function toggleCliente(tipo) {
            var pnlNuevo = document.getElementById('pnlNuevo');
            var pnlExistente = document.getElementById('pnlExistente');
            var lblNuevo = document.getElementById('lblNuevo');
            var lblExistente = document.getElementById('lblExistente');
            var hf = document.getElementById('<%= hfClienteType.ClientID %>');

            if (tipo === 'nuevo') {
                pnlNuevo.className = 'client-panel active';
                pnlExistente.className = 'client-panel';
                lblNuevo.className = 'toggle-btn active';
                lblExistente.className = 'toggle-btn';
            } else {
                pnlNuevo.className = 'client-panel';
                pnlExistente.className = 'client-panel active';
                lblNuevo.className = 'toggle-btn';
                lblExistente.className = 'toggle-btn active';
            }
            hf.value = tipo;
        }
    </script>
</asp:Content>
