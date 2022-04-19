Imports Microsoft.VisualBasic

Public Class MiPageN
    Inherits System.Web.UI.Page

    Public Shared HabilitaMensError As Boolean = True
    Public MapaMensajesError As New Collections.Generic.Dictionary(Of String, String)

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("MensajeError") Is Nothing Then
            Alerta(Session("MensajeError"))
            Session.Remove("CuentaMensajeErrorRepetido")
            Session.Remove("MensajeError")
        End If
    End Sub

    Protected Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
        'If HabilitaMensError Then
        '    Dim ex As Exception = Server.GetLastError()
        '    Session("MensajeError") = TransformaMensError(ex)
        '    If Session("MensajeErrorAnterior") = Session("MensajeError") Then
        '        If Session("CuentaMensajeErrorRepetido") Is Nothing Then
        '            Session("CuentaMensajeErrorRepetido") = 1
        '        End If
        '        Session("CuentaMensajeErrorRepetido") = Int(Session("CuentaMensajeErrorRepetido")) + 1
        '        If Int(Session("CuentaMensajeErrorRepetido")) > 20 Then
        '            Session.Remove("CuentaMensajeErrorRepetido")
        '            Session.Remove("MensajeErrorAnterior")
        '            Session.Remove("MensajeError")
        '            Exit Sub
        '        End If
        '    Else
        '        Session.Remove("CuentaMensajeErrorRepetido")
        '    End If
        '    Session("MensajeErrorAnterior") = Session("MensajeError")
        '    Context.ClearError()
        '    Response.Redirect(Request.Url.AbsoluteUri)
        'End If
    End Sub

    Public Function TransformaMensError(ByVal Message As String) As String
        For Each llave As String In MapaMensajesError.Keys
            If Message.Contains(llave) Then
                Return MapaMensajesError(llave)
            End If
        Next
        Dim Palabras As String() = Message.Split(" ")
        If Message.Contains("Cannot insert duplicate key") Then
            Return "No se pueden insertar registros duplicados"
        ElseIf Message.Contains("conflicted with TABLE REFERENCE") Then
            Return "Existe un registro en otra tabla relacionado con ese registro"
        ElseIf Message.Contains("UPDATE statement conflicted") Then
            Return "Registro no tiene registro relacionado en tabla " + Palabras(Palabras.Length - 7).Replace("'", "").Replace(",", "")
        ElseIf Message.Contains("DELETE statement conflicted with") Then
            Return "Registro no se puede eliminar pues tiene registros relacionados"
        ElseIf Message.Contains("Cannot insert the value NULL") Then
            Return "Hay campos vacios que deben tener un valor"
        Else
            Return "Notificacion: " + Message
        End If
    End Function

    Public Function TransformaMensError(ByVal ex As Exception) As String
        If ex.InnerException Is Nothing Then
            Return TransformaMensError(ex.Message)
        Else
            Return TransformaMensError(ex.InnerException.Message)
        End If
    End Function

    Public Sub MuestraError(ByVal ex As Exception)
        Alerta(TransformaMensError(ex))
    End Sub

    Public Sub MuestraError(ByVal s As String, Optional ByVal DentroDeUpdatePanel As Boolean = False)
        Alerta(TransformaMensError(s), DentroDeUpdatePanel)
    End Sub

    Public Sub MuestraErrorToast(ByVal s As String, ByVal tipo As Int32, Optional ByVal DentroDeUpdatePanel As Boolean = False)
        Notificacion(TransformaMensError(s), tipo, DentroDeUpdatePanel)
    End Sub

    Public Overridable Sub Javascript(ByVal Script As String, Optional ByVal DentroDeUpdatePanel As Boolean = False)
        'If Not DentroDeUpdatePanel Then
        '    Dim strscript As String = "<script language=javascript>" + Script + "</script>"
        '    If (Not ClientScript.IsStartupScriptRegistered("clientScript")) Then
        '        ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", strscript)
        '    End If
        'Else
        '    If (Not ClientScript.IsClientScriptIncludeRegistered("clientUPScript")) Then
        '        System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "clientScript", Script, True)
        '    End If
        'End If

        Dim key As String = Guid.NewGuid.ToString
        If Not DentroDeUpdatePanel Then
            Dim strscript As String = "<script language=javascript>" + Script + "</script>"
            If (Not ClientScript.IsStartupScriptRegistered("clientScript")) Then
                ClientScript.RegisterStartupScript(Page.GetType(), key, strscript)
            End If
        Else
            If (Not ClientScript.IsClientScriptIncludeRegistered("clientUPScript")) Then
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), key, Script, True)
            End If
        End If
    End Sub

    Public Sub Alerta(ByVal s As String, Optional ByVal DentroDeUpdatePanel As Boolean = False)
        Javascript("$('div').each(function(i, e){if ($(e).css('position') == 'absolute') $(e).hide();});" +
                   "alert(""" + s.Replace("""", "'").Replace("<", "[").Replace(">", "]").Replace(vbCrLf, "") + """);" +
                   "$('div').each(function(i, e){if ($(e).css('position') == 'absolute') $(e).show();});", DentroDeUpdatePanel)
    End Sub

    Public Sub Notificacion(ByVal s As String, ByVal tipo As Int32, Optional ByVal DentroDeUpdatePanel As Boolean = False)
        Javascript("metodo('" + s + "','" + tipo.ToString + "')", DentroDeUpdatePanel)
    End Sub

    Public Sub funcionesvarias(ByVal s As String, Optional ByVal DentroDeUpdatePanel As Boolean = False)
        Javascript(s, DentroDeUpdatePanel)
    End Sub

    Public Function AFecha(ByVal s As String) As Object
        If s = "" Then
            Return Nothing
        Else
            Dim v As String() = s.Split("/")
            Return New DateTime(v(2), v(1), v(0))
        End If
    End Function

    Public Function FechaAStr(ByVal d As Object, Optional ByVal formato As String = Nothing) As String
        Try
            If d Is DBNull.Value Then
                Return ""
            End If
        Catch ex As Exception
        End Try
        Try
            If d Is Nothing Then
                Return ""
            End If
        Catch ex As Exception
        End Try
        If formato Is Nothing Then
            Return d.Day.ToString.PadLeft(2, "0") + "/" + d.Month.ToString.PadLeft(2, "0") + "/" + d.Year.ToString
        Else
            Return CType(d, DateTime).ToString(formato)
        End If
    End Function

    Public Function ValidaNulo(ByVal o As Object, Optional ByVal defa As Object = "", Optional ByVal formato As String = Nothing) As Object
        Try
            If o Is DBNull.Value Then
                Return defa
            End If
        Catch ex As Exception
        End Try
        Try
            If o Is Nothing Then
                Return defa
            End If
        Catch ex As Exception
        End Try
        If formato Is Nothing Then
            Return o
        ElseIf formato = "fecha" Then
            Return Date.ParseExact(o, "dd/MM/yyyy", Nothing)
        ElseIf formato = "stFechaHora" Then
            Return CType(o, DateTime).ToString("dd/MM/yyyy hh:mm")
        Else
            Return String.Format(formato, o)
        End If
    End Function

    Public Function Roles(ByVal pag As String, ByVal tipo As Integer) As Boolean
        Dim PermisosA() As String
        Dim PermisosDetalle(150) As String
        PermisosDetalle(0) = "A"
        PermisosDetalle(1) = "false"
        PermisosDetalle(2) = "false"
        PermisosDetalle(3) = "false"
        Try
            Dim s As String = Session.SessionID

            If (Session("Roles") Is Nothing) Then


            Else
                PermisosA = Session("Roles").ToString.Split("$")
                Dim pags() As String = pag.Split(",")

                For index As Integer = 0 To PermisosA.Length - 1 Step 1
                    For index2 As Integer = 0 To pags.Length - 1 Step 1


                        If (PermisosA(index).Contains(pags(index2))) Then
                            PermisosDetalle = PermisosA(index).Split("!")
                            If (Boolean.Parse(PermisosDetalle(tipo))) Then
                                Return Boolean.Parse(PermisosDetalle(tipo))
                            End If
                        End If
                    Next

                Next
            End If

        Catch ex As Exception

        End Try


        If (PermisosDetalle.Length > 0) Then
            Return Boolean.Parse(PermisosDetalle(tipo))
        End If

    End Function

End Class
