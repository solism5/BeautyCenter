<%@ Page Title="Manejar Clientes" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeBehind="Clientes.aspx.vb" Inherits="BeautyCenter.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 class="page-title">Manejar Clientes</h1>

        <!-- Agregar Nuevo Cliente -->
        <div class="section-header">Agregar Nuevo Cliente</div>
        <div class="section-body">
            <div class="add-client-row">
                <div class="form-group">
                    <label>Nombre</label>
                    <asp:TextBox ID="txtNuevoNombre" runat="server" CssClass="form-input" placeholder="Nombre completo" />
                </div>
                <div class="form-group">
                    <label>Correo</label>
                    <asp:TextBox ID="txtNuevoCorreo" runat="server" CssClass="form-input" TextMode="Email" placeholder="correo@ejemplo.com" />
                </div>
                <div class="form-group">
                    <label>Tel&eacute;fono</label>
                    <asp:TextBox ID="txtNuevoTelefono" runat="server" CssClass="form-input" placeholder="+506 0000-0000" />
                </div>
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn-agregar" OnClick="btnAgregar_Click" />
            </div>
        </div>

        <!-- Lista de Clientes -->
        <div class="section-header">Lista de Clientes</div>
        <div class="section-body">
            <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False"
                CssClass="grid-table" DataKeyNames="ID"
                OnRowCommand="gvClientes_RowCommand"
                ShowHeaderWhenEmpty="True" EmptyDataText="No hay clientes registrados.">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" ItemStyle-Width="50px" />
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <asp:TextBox ID="txtNombreGrid" runat="server"
                                Text='<%# Eval("Nombre") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Correo">
                        <ItemTemplate>
                            <asp:TextBox ID="txtCorreoGrid" runat="server"
                                Text='<%# Eval("Correo") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tel&eacute;fono">
                        <ItemTemplate>
                            <asp:TextBox ID="txtTelefonoGrid" runat="server"
                                Text='<%# Eval("NumeroTelefono") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar"
                                CommandName="Guardar" CommandArgument='<%# Eval("ID") %>'
                                CssClass="btn-guardar" />
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar"
                                CommandName="Eliminar" CommandArgument='<%# Eval("ID") %>'
                                CssClass="btn-eliminar"
                                OnClientClick="return confirm('¿Está seguro de eliminar este cliente?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <asp:Label ID="lblMensaje" runat="server" />
    </div>
</asp:Content>
