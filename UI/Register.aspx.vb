Imports System.Data
Imports System.Data.SqlClient

Public Class Register
    Inherits System.Web.UI.Page

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs)

        Dim nombre As String = txtNombre.Text.Trim()
        Dim correo As String = txtCorreo.Text.Trim()
        Dim telefono As String = txtTelefono.Text.Trim()
        Dim contrasena As String = txtContrasena.Text.Trim()
        Dim rol As String = ddlRol.SelectedValue

        If String.IsNullOrEmpty(nombre) OrElse
           String.IsNullOrEmpty(correo) OrElse
           String.IsNullOrEmpty(telefono) OrElse
           String.IsNullOrEmpty(contrasena) Then

            lblMensaje.Text = "Todos los campos son requeridos."
            lblMensaje.CssClass = "msg-error"
            Return
        End If

        Try

            DatabaseHelper.ExecuteNonQuery("sp_CrearUsuario",
                {
                    New SqlParameter("@Nombre", nombre),
                    New SqlParameter("@Correo", correo),
                    New SqlParameter("@Contrasena", contrasena),
                    New SqlParameter("@NumeroTelefono", telefono),
                    New SqlParameter("@Rol", rol)
                },
                isStoredProcedure:=True
            )

            lblMensaje.Text = "Cuenta creada exitosamente. Puedes iniciar sesión."
            lblMensaje.CssClass = "msg-success"

            txtNombre.Text = ""
            txtCorreo.Text = ""
            txtTelefono.Text = ""
            txtContrasena.Text = ""

        Catch ex As Exception
            lblMensaje.Text = "Error al registrar: " & ex.Message
            lblMensaje.CssClass = "msg-error"
        End Try

    End Sub

End Class
