Imports Microsoft.VisualBasic

Public Class UI_Lib

    Public Shared Function htmlSeguro(ByVal s As String) As String
        Dim v As String() = New String() {" ", ";", "(", ")", "[", "]", "{", "}", "/", "%", "$", "#", "!"}
        Dim o As String() = New String() {"á", "é", "í", "ó", "ú", "Á", "É", "Í", "Ó", "Ú"}
        Dim n As String() = New String() {"a", "e", "i", "o", "u", "A", "E", "I", "O", "U"}
        For i As Integer = 0 To v.Length - 1
            s = s.Replace(v(i), "_")
        Next
        For i As Integer = 0 To o.Length - 1
            s = s.Replace(o(i), n(i))
        Next
        Return s
    End Function

End Class
