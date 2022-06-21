Imports System.Data
Imports System.Web

Public Class EspecificoTipoProy

    Public Function ObtPropiedad(ByVal Key As String) As String
        Return System.Configuration.ConfigurationManager.AppSettings(Key)
    End Function

    Public Function ObtCorreoFrom() As String
        Dim config As System.Configuration.Configuration = _
            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath)
        Dim settings As System.Net.Configuration.MailSettingsSectionGroup = _
            CType(config.GetSectionGroup("system.net/mailSettings"), System.Net.Configuration.MailSettingsSectionGroup)
        Return settings.Smtp.From
    End Function
    
    Public Sub AgregarLogBase(ByVal id_elem As String, ByVal log As String, ByVal usuario As String)
        'Agrega un log de la aplicacion con un id especifico
        Dim TrSQL As New TransacSQL
        TrSql.EjecutarActualizacion("aspnetdb3", "insert into global_log (accion, fecha, ip, usuario, aplicacion, id_elem) values ('" + _
            log.Replace("'", "''") + "', getdate(), '" + _
            HttpContext.Current.Request.UserHostAddress + "', '" + usuario + "', '" + _
            System.Configuration.ConfigurationManager.AppSettings("NombreAplicacion") + "', '" + id_elem + "')")
    End Sub

    Public Function PaginaAyuda(ByVal Pagina As String, Optional ByVal Aplicacion As String = Nothing) As String
        'Devuelve la ayuda guardada para una pagina
        Dim TrSQL As New TransacSQL
        Aplicacion = IIf(Aplicacion Is Nothing, ObtPropiedad("NombreAplicacion"), Aplicacion)
        Dim Host As String = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port.ToString
        Dim MyTable As DataTable = TrSQL.EjecutarConsulta("aspnetdb3", "select * from global_AplicacionAyuda where " + _
            "ApplicationName = '" + Aplicacion + "' and '" + Pagina + "' like '%'+Pagina+'%'").Tables(0)
        If MyTable.Rows.Count = 0 Then
            Return Nothing
        Else
            If MyTable.Rows(0)("ayuda") Is DBNull.Value Then
                Return Nothing
            Else
                Dim AyudaSt As String = MyTable.Rows(0)("ayuda")
                If MyTable.Rows(0)("principal") = 0 Then
                    Dim MyTablePrincipal As DataTable = TrSQL.EjecutarConsulta("aspnetdb3", "select * from global_AplicacionAyuda where " + _
                        "ApplicationName = '" + Aplicacion + "' and Principal = 1").Tables(0)
                    If MyTablePrincipal.Rows.Count > 0 Then
                        AyudaSt += String.Format("<br><br><a href=""{0}/SeguridadGlobal/Ayuda.aspx?PaginaActual={1}&Aplicacion={2}"">Inicio</a>", _
                            Host, MyTablePrincipal.Rows(0)("pagina"), MyTablePrincipal.Rows(0)("ApplicationName"))
                    End If
                Else
                    AyudaSt += "<br><br><ul>"
                    Dim MyTableLinks As DataTable = TrSQL.EjecutarConsulta("aspnetdb3", "select *, isnull(titulo, pagina) ElTitulo from global_AplicacionAyuda where " + _
                        "ApplicationName = '" + Aplicacion + "' and Principal = 0 order by isnull(num, 0), pagina").Tables(0)
                    For Each row As DataRow In MyTableLinks.Rows
                        AyudaSt += String.Format("<li><a href=""{0}/SeguridadGlobal/Ayuda.aspx?PaginaActual={1}&Aplicacion={2}"">{3}</a><br>", _
                            Host, row("Pagina"), row("ApplicationName"), row("ElTitulo"))
                    Next
                    AyudaSt += "</ul>"
                End If
                Return AyudaSt
            End If
        End If
    End Function

End Class
