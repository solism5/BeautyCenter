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
            "SELECT ID, Nombre FROM Cliente"
        )

        ddlClientes.Items.Clear()
        ddlClientes.Items.Add(New ListItem("-- Seleccione un cliente --", ""))

        For Each row As DataRow In dt.Rows
            ddlClientes.Items.Add(New ListItem(
                row("Nombre").ToString(),
                row("ID").ToString()
            ))
        Next

    End Sub

    '========================================
    ' CARGAR PROCEDIMIENTOS
    '========================================
    Private Sub CargarProcedimientos()

        Dim dt = DatabaseHelper.ExecuteDataTable(
            "SELECT ID, NombreProcedimiento FROM Procedimiento"
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

        Dim tipoCliente As String = hfClienteType.Value
        Dim idProcedimiento As String = ddlProcedimientos.SelectedValue
        Dim fechaCitaStr As String = txtFechaCita.Text

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

        Dim idCliente As Integer = 0

        Try

            '===================================
            ' CLIENTE NUEVO
            '===================================
            If tipoCliente = "nuevo" Then

                Dim nombre As String = txtNombre.Text.Trim()
                Dim correo As String = txtCorreo.Text.Trim()
                Dim telefono As String = txtTelefono.Text.Trim()

                If String.IsNullOrEmpty(nombre) OrElse
                   String.IsNullOrEmpty(correo) OrElse
                   String.IsNullOrEmpty(telefono) Then

                    MostrarError("Todos los campos del cliente son requeridos.")
                    Return
                End If

                Dim sqlInsertCliente As String =
                    "INSERT INTO Cliente (Nombre, Correo, NumeroTelefono) " &
                    "OUTPUT INSERTED.ID " &
                    "VALUES (@Nombre, @Correo, @NumeroTelefono)"

                Dim result = DatabaseHelper.ExecuteScalar(sqlInsertCliente,
                    {
                        New SqlParameter("@Nombre", nombre),
                        New SqlParameter("@Correo", correo),
                        New SqlParameter("@NumeroTelefono", telefono)
                    }
                )

                idCliente = Convert.ToInt32(result)

            Else

                '===================================
                ' CLIENTE EXISTENTE
                '===================================
                If String.IsNullOrEmpty(ddlClientes.SelectedValue) Then
                    MostrarError("Debe seleccionar un cliente existente.")
                    Return
                End If

                idCliente = Convert.ToInt32(ddlClientes.SelectedValue)

            End If


            '===================================
            ' INSERTAR CITA
            '===================================
            Dim sqlInsertCita As String =
                "INSERT INTO Cita (IDPersona, IDProcedimiento, Fecha) " &
                "VALUES (@IDPersona, @IDProcedimiento, @Fecha)"

            DatabaseHelper.ExecuteNonQuery(sqlInsertCita,
                {
                    New SqlParameter("@IDPersona", idCliente),
                    New SqlParameter("@IDProcedimiento", Convert.ToInt32(idProcedimiento)),
                    New SqlParameter("@Fecha", fechaCita)
                }
            )


            MostrarExito("¡Cita agendada exitosamente!")

            ' Limpiar campos
            txtNombre.Text = ""
            txtCorreo.Text = ""
            txtTelefono.Text = ""
            txtFechaCita.Text = ""
            ddlProcedimientos.SelectedIndex = 0
            ddlClientes.SelectedIndex = 0

            CargarClientes()

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