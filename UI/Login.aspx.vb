Imports System.Data
Imports System.Data.SqlClient

Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)

        Dim correo As String = txtCorreo.Text.Trim()
        Dim contrasena As String = txtContrasena.Text.Trim()

        If String.IsNullOrEmpty(correo) OrElse String.IsNullOrEmpty(contrasena) Then
            lblMensaje.Text = "Debe ingresar correo y contraseña."
            lblMensaje.CssClass = "msg-error"
            Return
        End If

        Try

            Dim dt = DatabaseHelper.ExecuteDataTable(
                "sp_Login",
                {
                    New SqlParameter("@Correo", correo),
                    New SqlParameter("@Contrasena", contrasena)
                },
                isStoredProcedure:=True
            )

            If dt.Rows.Count > 0 Then
                Response.Redirect("~/UI/AgendarCita.aspx")
            Else
                lblMensaje.Text = "Correo o contraseña incorrectos."
                lblMensaje.CssClass = "msg-error"
            End If

        Catch ex As SqlException
            lblMensaje.Text = "Correo o contraseña incorrectos."
            lblMensaje.CssClass = "msg-error"
        Catch ex As Exception
            lblMensaje.Text = "Error: " & ex.Message
            lblMensaje.CssClass = "msg-error"
        End Try

    End Sub

End Class
