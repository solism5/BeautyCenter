Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class DatabaseHelper

    Private Shared ReadOnly connectionString As String =
        ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString


    '========================================
    ' DEVUELVE DATATABLE
    '========================================
    Public Shared Function ExecuteDataTable(query As String,
                                            Optional parameters() As SqlParameter = Nothing,
                                            Optional isStoredProcedure As Boolean = False) As DataTable

        Dim dt As New DataTable()

        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)

                If isStoredProcedure Then
                    cmd.CommandType = CommandType.StoredProcedure
                End If

                If parameters IsNot Nothing Then
                    cmd.Parameters.AddRange(parameters)
                End If

                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using

            End Using
        End Using

        Return dt

    End Function


    '========================================
    ' DEVUELVE ESCALAR
    '========================================
    Public Shared Function ExecuteScalar(query As String,
                                         Optional parameters() As SqlParameter = Nothing,
                                         Optional isStoredProcedure As Boolean = False) As Object

        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)

                If isStoredProcedure Then
                    cmd.CommandType = CommandType.StoredProcedure
                End If

                If parameters IsNot Nothing Then
                    cmd.Parameters.AddRange(parameters)
                End If

                conn.Open()
                Return cmd.ExecuteScalar()

            End Using
        End Using

    End Function


    '========================================
    ' INSERT / UPDATE / DELETE
    '========================================
    Public Shared Sub ExecuteNonQuery(query As String,
                                      Optional parameters() As SqlParameter = Nothing,
                                      Optional isStoredProcedure As Boolean = False)

        Using conn As New SqlConnection(connectionString)
            Using cmd As New SqlCommand(query, conn)

                If isStoredProcedure Then
                    cmd.CommandType = CommandType.StoredProcedure
                End If

                If parameters IsNot Nothing Then
                    cmd.Parameters.AddRange(parameters)
                End If

                conn.Open()
                cmd.ExecuteNonQuery()

            End Using
        End Using

    End Sub

End Class