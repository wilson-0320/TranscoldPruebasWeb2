Imports Microsoft.VisualBasic
Imports System.Data

Public Class Base_BLL

    Public Shared MsjError As String

    Private Shared Function obtError(ByVal ex As Exception) As String
        If ex.InnerException Is Nothing Then
            Return ex.Message
        Else
            Return ex.Message + " - " + obtError(ex.InnerException)
        End If
    End Function

    Public Shared Sub colocaError(ByVal ex As Exception)
        MsjError = obtError(ex)


    End Sub

    Public Shared Function FechaONulo(ByVal sFecha As String) As Object
        If sFecha = "" Then
            Return DBNull.Value
        Else
            Return DateTime.ParseExact(sFecha, "dd/MM/yyyy", Nothing)
        End If
    End Function

    Public Shared Function ObtieneDataTable(ByVal dt As DataTable) As DataTable
        Return dt
    End Function

    Public Shared Function ObtieneDataTableConParams(ByVal dt As DataTable, param1 As Object, param2 As Object, param3 As Object) As DataTable
        Return dt
    End Function

End Class
