<%@ Page Title="Ver Citas" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeBehind="VerCitas.aspx.vb" Inherits="BeautyCenter.VerCitas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1 class="page-title">Citas Agendadas</h1>

        <div class="section-header">Lista de Citas</div>
        <div class="section-body">
            <asp:GridView ID="gvCitas" runat="server" AutoGenerateColumns="False"
                CssClass="grid-table"
                ShowHeaderWhenEmpty="True" EmptyDataText="No hay citas registradas.">
                <Columns>
                    <asp:BoundField DataField="NombreCliente" HeaderText="Cliente" />
                    <asp:BoundField DataField="NombreProcedimiento" HeaderText="Procedimiento" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy hh:mm tt}" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
