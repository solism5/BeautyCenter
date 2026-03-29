Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls

Public Class AgendarCita
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarClientes()
            CargarProcedimientos()
        End If
    End Sub

    '========================================
    ' CARGAR CLIENTES
    '========================================
    Private Sub CargarClientes()

        Dim dt = DatabaseHelper.ExecuteDataTable(
            "sp_LeerUsuarios",
            isStoredProcedure:=True
        )

        ddlClientes.Items.Clear()
        ddlClientes.Items.Add(New ListItem("-- Seleccione un cliente --", ""))

        For Each row As DataRow In dt.Rows
            If row("Rol").ToString() = "Cliente" Then
                ddlClientes.Items.Add(New ListItem(
                    row("Nombre").ToString(),
                    row("ID").ToString()
                ))
            End If
        Next

    End Sub

    '========================================
    ' CARGAR PROCEDIMIENTOS
    '========================================
    Private Sub CargarProcedimientos()

        Dim dt = DatabaseHelper.ExecuteDataTable(
            "sp_LeerProcedimientos",
            isStoredProcedure:=True
        )

        ddlProcedimientos.Items.Clear()
        ddlProcedimientos.Items.Add(New ListItem("-- Seleccione un procedimiento --", ""))

        For Each row As DataRow In dt.Rows
            ddlProcedimientos.Items.Add(New ListItem(
                row("NombreProcedimiento").ToString(),
                row("ID").ToString()
            ))
        Next

    End Sub


    '========================================
    ' CONFIRMAR CITA
    '========================================
    Protected Sub btnConfirmar_Click(sender As Object, e As EventArgs)

        lblMensaje.Text = ""
        lblMensaje.CssClass = ""

        Dim idCliente As String = ddlClientes.SelectedValue
        Dim idProcedimiento As String = ddlProcedimientos.SelectedValue
        Dim fechaCitaStr As String = txtFechaCita.Text

        If String.IsNullOrEmpty(idCliente) Then
            MostrarError("Debe seleccionar un cliente.")
            Return
        End If

        If String.IsNullOrEmpty(idProcedimiento) Then
            MostrarError("Debe seleccionar un procedimiento.")
            Return
        End If

        If String.IsNullOrEmpty(fechaCitaStr) Then
            MostrarError("Debe seleccionar una fecha y hora para la cita.")
            Return
        End If

        Dim fechaCita As DateTime
        If Not DateTime.TryParse(fechaCitaStr, fechaCita) Then
            MostrarError("La fecha ingresada no es válida.")
            Return
        End If

        Try

            DatabaseHelper.ExecuteNonQuery("sp_CrearCita",
                {
                    New SqlParameter("@IDPersona", Convert.ToInt32(idCliente)),
                    New SqlParameter("@IDProcedimiento", Convert.ToInt32(idProcedimiento)),
                    New SqlParameter("@Fecha", fechaCita)
                },
                isStoredProcedure:=True
            )

            MostrarExito("¡Cita agendada exitosamente!")

            txtFechaCita.Text = ""
            ddlProcedimientos.SelectedIndex = 0
            ddlClientes.SelectedIndex = 0

        Catch ex As Exception
            MostrarError("Error al agendar la cita: " & ex.Message)
        End Try

    End Sub


    Private Sub MostrarError(mensaje As String)
        lblMensaje.Text = mensaje
        lblMensaje.CssClass = "msg-error"
    End Sub

    Private Sub MostrarExito(mensaje As String)
        lblMensaje.Text = mensaje
        lblMensaje.CssClass = "msg-success"
    End Sub

End Class