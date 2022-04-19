Public Class lecturas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Function datos() As String
        Dim data As String = "C1-104$2022-01-01 12:00:00.000$313$0$|C1-H$2022-01-01 12:00:00.000$316$0$"

        Dim cls = New DLL2.metodos()
        Dim path As String
        Dim fecha As String = DateTime.Now.ToString("yyyy/MM/dd hh:mm")
        path = "D:/lmpv/"
        Dim retorno As String(,) = cls.TranscolPruebasWeb("22/0001", path, fecha, data)


        Dim strDatos As String = "["
        Dim tiempo As Double
        For index As Integer = 1 To retorno.GetLength(0) - 1 Step 1
            tiempo = tiempo + 0.5
            strDatos = strDatos + "[" + tiempo.ToString.Replace(",", ".") + ","
            For index1 As Integer = 0 To retorno.GetLength(1) - 1 Step 1
                If (index1 = retorno.GetLength(1)) Then
                    strDatos = strDatos + retorno(index, index1)
                Else

                    strDatos = strDatos + retorno(index, index1) + ","
                End If

            Next
            strDatos = strDatos + "],"
        Next
        strDatos = strDatos + "]"
        Return strDatos

        'cls.LabPruebasActivas("")
    End Function

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        datos()
    End Sub
End Class