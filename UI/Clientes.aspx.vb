Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls

Public Class Clientes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindClientes()
        End If
    End Sub

    '========================================
    ' CARGAR CLIENTES EN GRIDVIEW
    '========================================
    Private Sub BindClientes()

        Dim dt = DatabaseHelper.ExecuteDataTable(
            "sp_LeerUsuarios",
            isStoredProcedure:=True
        )

        Dim dtClientes As New DataTable()
        dtClientes = dt.Clone()

        For Each row As DataRow In dt.Rows
            If row("Rol").ToString() = "Cliente" Then
                dtClientes.ImportRow(row)
            End If
        Next

        gvClientes.DataSource = dtClientes
        gvClientes.DataBind()

    End Sub


    '========================================
    ' AGREGAR CLIENTE
    '========================================
    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs)

        lblMensaje.Text = ""
        lblMensaje.CssClass = ""

        Dim nombre As String = txtNuevoNombre.Text.Trim()
        Dim correo As String = txtNuevoCorreo.Text.Trim()
        Dim telefono As String = txtNuevoTelefono.Text.Trim()

        If String.IsNullOrEmpty(nombre) OrElse
           String.IsNullOrEmpty(correo) OrElse
           String.IsNullOrEmpty(telefono) Then

            MostrarError("Todos los campos son requeridos.")
            Return
        End If

        Try

            DatabaseHelper.ExecuteNonQuery("sp_CrearUsuario",
                {
                    New SqlParameter("@Nombre", nombre),
                    New SqlParameter("@Correo", correo),
                    New SqlParameter("@Contrasena", "1234"),
                    New SqlParameter("@NumeroTelefono", telefono),
                    New SqlParameter("@Rol", "Cliente")
                },
                isStoredProcedure:=True
            )

            txtNuevoNombre.Text = ""
            txtNuevoCorreo.Text = ""
            txtNuevoTelefono.Text = ""

            MostrarExito("Cliente agregado exitosamente.")
            BindClientes()

        Catch ex As Exception
            MostrarError("Error al agregar cliente: " & ex.Message)
        End Try

    End Sub


    '========================================
    ' GUARDAR O ELIMINAR
    '========================================
    Protected Sub gvClientes_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        If e.CommandName = "Guardar" OrElse e.CommandName = "Eliminar" Then

            Dim id As Integer = Convert.ToInt32(e.CommandArgument)

            Dim row As GridViewRow = DirectCast(
                DirectCast(e.CommandSource, Button).NamingContainer,
                GridViewRow
            )

            Select Case e.CommandName

                '=============================
                ' ACTUALIZAR
                '=============================
                Case "Guardar"

                    Dim nombre As String = DirectCast(row.FindControl("txtNombreGrid"), TextBox).Text.Trim()
                    Dim correo As String = DirectCast(row.FindControl("txtCorreoGrid"), TextBox).Text.Trim()
                    Dim telefono As String = DirectCast(row.FindControl("txtTelefonoGrid"), TextBox).Text.Trim()

                    If String.IsNullOrEmpty(nombre) OrElse
                       String.IsNullOrEmpty(correo) OrElse
                       String.IsNullOrEmpty(telefono) Then

                        MostrarError("Todos los campos son requeridos para actualizar.")
                        Return
                    End If

                    Try

                        Dim dtUsuario = DatabaseHelper.ExecuteDataTable(
                            "sp_LeerUsuarioPorID",
                            {New SqlParameter("@ID", id)},
                            isStoredProcedure:=True
                        )

                        Dim contrasenaActual As String = DatabaseHelper.ExecuteScalar(
                            "SELECT Contrasena FROM Usuario WHERE ID = @ID",
                            {New SqlParameter("@ID", id)}
                        ).ToString()

                        DatabaseHelper.ExecuteNonQuery("sp_ActualizarUsuario",
                            {
                                New SqlParameter("@ID", id),
                                New SqlParameter("@Nombre", nombre),
                                New SqlParameter("@Correo", correo),
                                New SqlParameter("@Contrasena", contrasenaActual),
                                New SqlParameter("@NumeroTelefono", telefono),
                                New SqlParameter("@Rol", "Cliente")
                            },
                            isStoredProcedure:=True
                        )

                        MostrarExito("Cliente actualizado exitosamente.")

                    Catch ex As Exception
                        MostrarError("Error al actualizar: " & ex.Message)
                    End Try


                '=============================
                ' ELIMINAR
                '=============================
                Case "Eliminar"

                    Try

                        DatabaseHelper.ExecuteNonQuery("sp_EliminarUsuario",
                            {
                                New SqlParameter("@ID", id)
                            },
                            isStoredProcedure:=True
                        )

                        MostrarExito("Cliente eliminado exitosamente.")

                    Catch ex As Exception
                        MostrarError("Error al eliminar: " & ex.Message)
                    End Try

            End Select

            BindClientes()

        End If

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