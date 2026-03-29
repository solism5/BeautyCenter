Imports System.Data

Public Class VerCitas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarCitas()
        End If
    End Sub

    Private Sub CargarCitas()

        Dim dt = DatabaseHelper.ExecuteDataTable(
            "sp_GetCitas",
            isStoredProcedure:=True
        )

        gvCitas.DataSource = dt
        gvCitas.DataBind()

    End Sub

End Class
