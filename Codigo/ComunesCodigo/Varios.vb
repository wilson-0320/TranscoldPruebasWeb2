Imports Microsoft.VisualBasic
Imports System.Net.Mail
Imports System.Data
Imports System.Collections.Generic

Public Class ItemInvalidoException : Inherits Exception
    Public Sub New(ByVal s As String)
        MyBase.New(s)
    End Sub
End Class

Public Class ComboBoxItem
    Public Text As String
    Public Value As Object
    Public Sub New(ByVal Value_ As Object, ByVal Text_ As Object)
        Value = Value_
        Text = Text_.ToString
    End Sub
    Public Overrides Function ToString() As String
        Return Text
    End Function
End Class

Public Class Varios

    Public TrSql As New TransacSQL
    Dim EspTipoProy As New EspecificoTipoProy

    Private Sub CambiarRow(ByRef dataSet As DataSet, ByVal i As Integer, ByVal row As DataRow) 'Casi no lo utilizo
        Dim k As Integer
        dataSet.Tables(0).Rows(i).BeginEdit()
        For k = 0 To dataSet.Tables(0).Columns.Count - 1
            dataSet.Tables(0).Rows(i)(k) = row(k)
        Next
        dataSet.Tables(0).Rows(i).EndEdit()
    End Sub

    Public Sub OrdenarDataSet(ByRef dataSet As DataSet, ByVal columna As String) 'Casi no lo utilizo
        Dim i, j, k As Integer
        Dim rowI, rowJ, rowTemp As DataRow
        For i = 0 To dataSet.Tables(0).Rows.Count - 1
            For j = i To dataSet.Tables(0).Rows.Count - 1
                rowI = dataSet.Tables(0).Rows(i)
                rowJ = dataSet.Tables(0).Rows(j)
                If rowI(columna) > rowJ(columna) Then
                    rowTemp = dataSet.Tables(0).NewRow
                    rowTemp.BeginEdit()
                    For k = 0 To dataSet.Tables(0).Columns.Count - 1
                        rowTemp(k) = rowI(k)
                    Next
                    rowTemp.EndEdit()
                    CambiarRow(dataSet, i, rowJ)
                    CambiarRow(dataSet, j, rowTemp)
                End If
            Next
        Next
    End Sub

    Public Function ValorComboBox(ByRef cb As Object) As Object
        Try
            If cb.SelectedValue Is Nothing Then
                If cb.SelectedItem Is Nothing Then
                    Return Nothing
                Else
                    Try
                        Return cb.SelectedItem.Value
                    Catch ex As MissingMemberException
                        Return cb.SelectedItem
                    End Try
                End If
            ElseIf cb.SelectedValue Is DBNull.Value Then
                Return DBNull.Value
            ElseIf cb.SelectedItem Is DBNull.Value Then
                Return DBNull.Value
            End If
        Catch ex As Exception
        End Try
        If cb.GetType.Name = "ToolStripComboBox" Then
            If cb.ComboBox.SelectedValue.GetType.Name = "DataRowView" Then
                Return CType(cb.ComboBox.SelectedValue, DataRowView).Row(0)
            Else
                Return cb.ComboBox.SelectedValue
            End If
        Else
            If cb.SelectedValue.ToString.Contains("DataRowView") Then
                If cb.ValueMember <> "" Then
                    Return CType(cb.SelectedValue, DataRowView).Row(cb.ValueMember)
                Else
                    Return CType(cb.SelectedValue, DataRowView).Row(0)
                End If
            Else
                Return cb.SelectedValue
            End If
        End If
    End Function

    Public Function ValorControl(ByVal Control As Object) As String
        If Control.ToString.Contains("DropDownList") Or Control.GetType.Name = "ToolStripComboBox" Or _
            Control.ToString.Contains("RadioButtonList") Or Control.ToString.Contains("ComboBox") Then
            Return ValorComboBox(Control)
        ElseIf Control.ToString.Contains("TextBox") Then
            Return Control.Text
        ElseIf Control.ToString.Contains("CheckBox") Or Control.ToString.Contains("RadioButton") Then
            Return Control.Checked
        ElseIf Control.ToString.Contains("DateTimePicker") Then
            Dim d As DateTime = Control.Value
            Return d.Year.ToString + "-" + d.Month.ToString + "-" + d.Day.ToString + " " + _
                d.Hour.ToString + ":" + d.Minute.ToString + ":" + d.Second.ToString + "." + d.Millisecond.ToString
        End If
        Throw New Exception("No esta implementado obtener el valor de " + Control.ToString)
    End Function

    'Public Function SelComboBoxItem(ByRef cb As ComboBox, ByVal valor As Object) As Boolean
    '    Dim Itm As ComboBoxItem = Nothing
    '    Dim min, max, i, i_ant, n As Integer
    '    i_ant = -1
    '    n = cb.Items.Count
    '    min = 0
    '    max = cb.Items.Count - 1
    '    While (Itm Is Nothing OrElse Itm.Value <> valor) And i <> i_ant
    '        i_ant = i
    '        i = min + (max - min) / 2
    '        If cb.Items(i).Value = valor Then
    '            cb.SelectedIndex = i
    '            Return True
    '        Else
    '            If cb.Items(i).Value < valor Then

    '            End If
    '        End If
    '    End While
    '    Return False
    'End Function

    Public Sub ValorControl(ByRef Control As Object, ByVal Valor As Object)
        If Control.ToString.Contains("DropDownList") Or _
            Control.ToString.Contains("RadioButtonList") Or Control.ToString.Contains("ComboBox") Then
            If Control.Items.Count > 0 Then
                If Control.Items(0).GetType.ToString.Contains("DataRowView") Then
                    For Each Itm As DataRowView In Control.Items
                        Try
                            If Itm(0) = Valor Then
                                Control.SelectedItem = Itm
                                Exit Sub
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    Throw New ItemInvalidoException("Valor no se encuentra en el listado de valores del control " + Control.Name)
                ElseIf Control.Items(0).GetType.ToString.Contains("ComboBoxItem") Then
                    Dim Itm As ComboBoxItem
                    For i As Integer = 0 To Control.Items.Count - 1
                        Itm = Control.Items(i)
                        If Itm.Value = Valor Then
                            Control.SelectedIndex = i
                            Exit Sub
                        End If
                    Next
                    Throw New ItemInvalidoException("Valor no se encuentra en el listado de valores del control " + Control.Name)
                Else
                    Control.SelectedValue = Valor
                    If Control.SelectedValue Is Nothing Then
                        Control.SelectedItem = Valor
                        If Control.SelectedItem Is Nothing Then
                            Throw New ItemInvalidoException("Valor no se encuentra en el listado de valores del control " + Control.Name)
                        End If
                    End If
                End If
            Else
                Throw New ItemInvalidoException("Control " + Control.Name + " no tiene items")
            End If
        ElseIf Control.ToString.Contains("TextBox") Or Control.ToString.Contains("Label") Then
            Control.Text = IIf(Valor Is DBNull.Value Or Valor Is Nothing, "", Valor)
        ElseIf Control.ToString.Contains("CheckBox") Or Control.ToString.Contains("RadioButton") Then
            Control.Checked = Valor
        ElseIf Control.ToString.Contains("DateTimePicker") Then
            Control.Value = Valor
        Else
            Throw New Exception("No esta implementado asignar el valor de " + Control.ToString)
        End If
    End Sub

    Public Sub Enviar_Mail(ByVal from As String, ByRef destinatarios As IEnumerable, ByRef subject As String, ByRef body As String, Optional ByRef adjuntos As String() = Nothing, Optional ByVal IsBodyHtml As Boolean = False)
        'Envia un correo a un grupo de destinatarios (destinatarios)
        Dim Correo As New MailMessage()
        Dim smtpMail As New SmtpClient("smtp.gmail.com")
        smtpMail.Port = 587
        smtpMail.Credentials = New Net.NetworkCredential("FogelNotif@gmail.com", "moigddenogypzipc")
        smtpMail.EnableSsl = True
        With Correo
            .From = New MailAddress(from)
            For Each destinatario As String In destinatarios
                .To.Add(destinatario)
            Next
            .Subject = subject
            .Body = body
            .Priority = MailPriority.High
            .IsBodyHtml = IsBodyHtml
            If Not adjuntos Is Nothing Then
                For Each at As String In adjuntos
                    .Attachments.Add(New Attachment(at))
                Next
            End If
        End With
        smtpMail.Send(Correo)
        Correo.Dispose()
    End Sub

    Public Sub Enviar_Mail(ByRef destinatarios As IEnumerable, ByRef subject As String, ByRef body As String, Optional ByRef adjuntos As String() = Nothing, Optional ByVal IsBodyHtml As Boolean = False)
        'Envia un correo a un grupo de destinatarios. El "From" se obtiene de la configuracion de la aplicacion (web.config)
        Enviar_Mail(EspTipoProy.ObtCorreoFrom, destinatarios, subject, body, adjuntos, IsBodyHtml)
    End Sub

    Public Sub Enviar_Mail(ByVal Tipo As String, ByVal subject As String, ByVal body As String, Optional ByRef adjuntos As String() = Nothing, Optional ByVal IsBodyHtml As Boolean = False)
        'Envia un correo a un grupo de destinatarios almacenados en la tabla global_Correos, filtrados por la aplicacion y el tipo
        For Each row As DataRow In TrSql.EjecutarConsulta("aspnetdb3", "select correo from global_Correos where Aplicacion = '" + _
            EspTipoProy.ObtPropiedad("NombreAplicacion") + "' and tipo = '" + Tipo + "'").Tables(0).Rows
            Enviar_Mail(New String() {row("correo")}, subject, body, adjuntos, IsBodyHtml)
        Next
    End Sub

    Public Sub Enviar_Mail_Roles(ByVal Roles As String, ByVal subject As String, ByVal body As String, Optional ByRef adjuntos As String() = Nothing)
        Dim Correos As New ArrayList
        For Each row As DataRow In TrSql.EjecutarConsulta("aspnetdb3", "select email from dbo.Correos_de_Roles('" + _
                                                          EspTipoProy.ObtPropiedad("NombreAplicacion") + "', '" + Roles + "')").Tables(0).Rows
            Correos.Add(row("email"))
        Next
        Enviar_Mail(Correos, subject, body, adjuntos)
    End Sub

    Public Function MuestraError(ByVal Idioma As String, ByVal Message As String) As String
        'Muestra un mensaje mas comprensible de error en espa�ol o ingles
        Dim Palabras As String() = Message.Split(" ")
        If Idioma = "Espa�ol" Or Idioma Is Nothing Or Idioma = "" Then
            If Message.Contains("Cannot insert duplicate key") Then
                Return "No se pueden insertar registros duplicados"
            ElseIf Message.Contains("conflicted with TABLE REFERENCE") Then
                Return "Existe un registro en otra tabla relacionado con ese registro"
            ElseIf Message.Contains("UPDATE statement conflicted with COLUMN FOREIGN KEY constraint") Then
                Return "Registro no tiene registro relacionado en tabla " + Palabras(Palabras.Length - 7).Replace("'", "").Replace(",", "")
            ElseIf Message.Contains("DELETE statement conflicted with COLUMN REFERENCE") Then
                Return "Registro no se puede eliminar pues tiene registros relacionados"
            ElseIf Message.Contains("Cannot insert the value NULL") Then
                Return "Hay campos vacios que deben tener un valor"
            Else
                Return "Petici�n inv�lida: " + Message
            End If
        Else
            If Message.Contains("Cannot insert duplicate key row") Then
                Return "Cannot insert duplicate row"
            ElseIf Message.Contains("conflicted with TABLE REFERENCE") Then
                Return "There is a row in another table ralated to that row"
            ElseIf Message.Contains("UPDATE statement conflicted with COLUMN FOREIGN KEY constraint") Then
                Return "Record does not have a related record in table " + Palabras(Palabras.Length - 7).Replace("'", "").Replace(",", "")
            ElseIf Message.Contains("DELETE statement conflicted with COLUMN REFERENCE") Then
                Return "Record can not be deleted because it has related records"
            ElseIf Message.Contains("Cannot insert the value NULL") Then
                Return "There are empty fields which need a value"
            Else
                Return "Invalid request: " + Message
            End If
        End If
    End Function

    Public Function MuestraError(ByVal Idioma As String, ByVal ex As Exception) As String
        If ex.InnerException Is Nothing Then
            Return MuestraError(Idioma, ex.Message)
        Else
            Return MuestraError(Idioma, ex.InnerException.Message)
        End If
    End Function

    Public Function MuestraError(ByVal Message As String) As String
        Return MuestraError("Espa�ol", Message)
    End Function

    Public Function MuestraError(ByRef ex As Exception) As String
        If ex.InnerException Is Nothing Then
            Return MuestraError(ex.Message)
        Else
            Return MuestraError(ex.InnerException.Message)
        End If
    End Function

    Public Function AppPropiedad(ByVal Propiedad As String) As String
        'Obtiene un valor de una propiedad de aplicacion
        Dim MyTable As DataTable
        MyTable = TrSql.EjecutarConsulta("aspnetdb3", "select valor from global_AplicacionPropiedad where " + _
            "ApplicationName = '" + EspTipoProy.ObtPropiedad("NombreAplicacion") + "' and Propiedad = '" + Propiedad + "'").Tables(0)
        If MyTable.Rows.Count = 0 Then
            Return Nothing
        Else
            Return MyTable.Rows(0)("valor")
        End If
    End Function

    Public Sub GuardarAppPropiedad(ByVal Propiedad As String, ByVal valor As String)
        TrSql.EjecutarActualizacion("aspnetdb3", "update global_AplicacionPropiedad set valor = '" + valor.Replace("'", "''") + _
            "' where propiedad = '" + Propiedad + "'")
    End Sub

    Public Function UsuarioPropiedad(ByVal Usuario As String, ByVal Propiedad As String, Optional ByVal Defabol As String = Nothing, Optional ByVal Aplicacion As String = Nothing) As String
        'Obtiene un valor de una propiedad de usuario
        If Defabol Is Nothing Or Defabol Is DBNull.Value Then
            Defabol = "Null"
        Else
            Defabol = "'" + Defabol.Replace("'", "''") + "'"
        End If
        Dim Valor As Object = TrSql.EjecutarConsulta("aspnetdb3", "select dbo.obt_usuario_propiedad('" + _
            Usuario + "', '" + Propiedad + "', '" + IIf(Aplicacion Is Nothing, EspTipoProy.ObtPropiedad("NombreAplicacion"), "") + _
            "', " + Defabol + ")").Tables(0).Rows(0)(0)
        Return IIf(Valor Is DBNull.Value OrElse Valor = "Null", Nothing, Valor)
    End Function

    Public Sub GuardarUsuarioPropiedad(ByVal Usuario As String, ByVal Propiedad As String, ByVal Valor As String, Optional ByVal Aplicacion As String = Nothing)
        'Guarda una propiedad de usuario
        Dim qAplicacion As String
        If Aplicacion Is Nothing Then
            Aplicacion = EspTipoProy.ObtPropiedad("NombreAplicacion")
            If Aplicacion Is Nothing Then
                Aplicacion = ""
            End If
        End If
        qAplicacion = "'" + Aplicacion + "'"
        If TrSql.EjecutarConsulta("aspnetdb3", "select count(*) from global_UsuarioPropiedad where UserName = '" + Usuario + "' and Propiedad = '" + Propiedad + _
            "' and IsNull(ApplicationName, '') = " + qAplicacion).Tables(0).Rows(0)(0) = 0 Then
            TrSql.EjecutarActualizacion("aspnetdb3", "insert into global_UsuarioPropiedad (UserName, Propiedad, Valor, EditableUsuario, ApplicationName) " + _
                "values ('" + Usuario + "', '" + Propiedad + "', '" + Valor + "', 0, " + IIf(qAplicacion = "''", "null", qAplicacion) + ")")
        Else
            TrSql.EjecutarActualizacion("aspnetdb3", "update global_UsuarioPropiedad set valor = '" + Valor + "' where " + _
                "UserName = '" + Usuario + "' and Propiedad = '" + Propiedad + "' and IsNull(ApplicationName, '') = " + qAplicacion)
        End If
    End Sub

    Public Function TienePaginaAyuda(ByVal Pagina As String) As Integer
        'Verifica si una pagina tiene almacenado un registro de ayuda
        Dim MyTable As DataTable
        MyTable = TrSql.EjecutarConsulta("aspnetdb3", "select count(*) from global_AplicacionAyuda where " + _
            "ApplicationName = '" + EspTipoProy.ObtPropiedad("NombreAplicacion") + "' and '" + Pagina + "' like '%'+Pagina+'%'").Tables(0)
        Return MyTable.Rows(0)(0)
    End Function

    Public Function ControlStr(ByVal nombre As String, ByVal ctrl As Object) As String
        If ctrl.GetType.Name = "TextBox" Then
            Return String.Format("{0}: {1}", nombre, ctrl.Text)
        ElseIf ctrl.GetType.Name = "DropDownList" Then
            Return String.Format("{0}: {1}", nombre, CType(ctrl, Object).SelectedValue)
        ElseIf ctrl.GetType.Name = "CheckBox" Then
            Return String.Format("{0}: {1}", nombre, ctrl.Checked.ToString)
        ElseIf ctrl.GetType.Name = "Label" Then
            Return String.Format("{0}: {1}", nombre, ctrl.Text)
        End If
        Throw New Exception("No se puede convertir en string")
    End Function

    Public Function ControlStr(ByVal dv As Object, ByVal nombres As String, ByVal controles As String) As String
        Dim vnombres As String() = nombres.Split(",")
        Dim vcontroles As String() = controles.Split(",")
        Dim s As String() = New String(vnombres.Length - 1) {}
        For i As Integer = 0 To vnombres.Length - 1
            If Not dv.FindControl(vcontroles(i)) Is Nothing Then
                s(i) = ControlStr(vnombres(i), dv.FindControl(vcontroles(i)))
            End If
        Next
        Return String.Join(", ", s)
    End Function

    Public Sub AgregarLog(ByVal id_elem As String, ByVal log As String, ByVal usuario As String)
        'EspTipoProy.AgregarLogBase(id_elem, log, usuario)
    End Sub

    Public Sub AgregarLog(ByVal log As String, ByVal usuario As String)
        'Agrega un log de la aplicacion sin un id especifico
        AgregarLog("", log, usuario)
    End Sub

    Public Function ObtieneCulture(ByVal Idioma As String) As String
        'Obtiene la culture segun el idioma
        Dim MyTable As DataTable
        MyTable = TrSql.EjecutarConsulta("aspnetdb3", "select culture from global_Idiomas where Idioma = '" + Idioma + "'").Tables(0)
        If MyTable.Rows.Count = 0 Then
            Return Nothing
        Else
            Return MyTable.Rows(0)(0)
        End If
    End Function

    Private Function ValidaNulo(ByVal o As Object) As String
        'Devuelve la representacion de un valor o vacio para usarlo en queries
        Try
            If Not o.HasValue Then
                Return "null"
            Else
                Return "'" + o.ToString + "'"
            End If
        Catch ex As Exception
            If o Is Nothing Then
                Return "null"
            Else
                Return o.ToString
            End If
        End Try
    End Function

    Private Function ValidaNulo(ByVal Fecha As Nullable(Of Date)) As String
        'Devuelve la representacion de un valor o vacio de una fecha para usarlo en queries
        If Not Fecha.HasValue Then
            Return "null"
        Else
            Return "'" + Year(Fecha).ToString + "/" + Month(Fecha).ToString + "/" + Day(Fecha).ToString + "'"
        End If
    End Function

    Public Function ValDict(ByVal d As Dictionary(Of String, Object), ByVal Key As String, ByVal Defa As Object, Optional ByVal Tipo As String = Nothing) As Object
        Dim valor As Object
        If d.TryGetValue(Key, valor) Then
            If Tipo Is Nothing Then
                Return valor
            Else
                Select Case Tipo
                    Case "Double"
                        Return CType(valor, Double)
                    Case "Integer"
                        Return CType(valor, Integer)
                    Case Else
                        Throw New Exception("Tipo no v�lido: " + Tipo)
                End Select
            End If
        Else
            Return Defa
        End If
    End Function

    Public Sub TareaPeriodica(ByVal IDAp As String, ByVal Tipo As String, ByVal Parametros As Dictionary(Of String, String), _
        ByVal Periodicidad As String, ByVal Periodo As Nullable(Of Integer), ByVal Inicio As Nullable(Of Date), ByVal Fin As Nullable(Of Date), _
        ByVal Hora As Nullable(Of Integer), ByVal Minutos As Nullable(Of Integer), ByVal Incluir As String, _
        ByVal CorreoExito As String, ByVal CorreoError As String, ByVal Activa As Integer, ByVal Usuario As String)
        'Crea una tarea periodica que se ejecuta o no en fogelgt1 cada media hora (segun el horario de la tarea).
        ' Esta tarea esta configurada en el task manager de fogelgt1, el archivo que se ejecuta es el proyecto TareasPeriodicas
        'Parametros = Correo: From, Destinatarios (separados por ";"), Subject, Body. Query: bd, query. Ejecutable: path
        If Not "Correo,Query,Ejecutable".Contains(Tipo) Then
            Throw New Exception("Tipo de tarea inv�lida: " + Tipo)
        End If
        If Not "UnaVez,Diario,Semanal,Mensual,Anual".Contains(Periodicidad) Then
            Throw New Exception("Periodicidad de tarea inv�lida: " + Periodicidad)
        End If
        Dim Aplicacion As String = EspTipoProy.ObtPropiedad("NombreAplicacion")
        Dim stPeriodo, stHora, stMinutos, stParametros, stInicio, stFin, query As String
        stParametros = ""
        For Each key As String In Parametros.Keys
            stParametros += "," + key + "=" + Parametros(key).Replace(",", "[coma]").Replace("=", "[igual]").Replace("'", "''")
        Next
        stParametros = stParametros.Substring(1)
        stPeriodo = ValidaNulo(Periodo)
        stInicio = ValidaNulo(Inicio)
        stFin = ValidaNulo(Fin)
        stHora = ValidaNulo(Hora)
        stMinutos = ValidaNulo(Minutos)
        Incluir = ValidaNulo(Incluir)
        CorreoExito = ValidaNulo(CorreoExito)
        CorreoError = ValidaNulo(CorreoError)
        Dim DT As DataTable = TrSql.EjecutarConsulta("aspnetdb3", "select * from global_tareas where Aplicacion='" + Aplicacion + "' and IDAp='" + IDAp + "'").Tables(0)
        If DT.Rows.Count > 0 Then
            query = "update global_Tareas set Tipo = '" + Tipo + "', Parametros = '" + stParametros + "', Periodicidad = '" + Periodicidad + "', Periodo = " + stPeriodo + _
            ", Inicio = " + stInicio + ", Fin = " + stFin + ", Hora = " + stHora + ", Minutos = " + stMinutos + ", Incluir = " + Incluir + ", Activa = " + Activa.ToString + _
            ", Usuario = '" + Usuario + "', CorreoExito = " + CorreoExito + ", CorreoError = " + CorreoError + " where Aplicacion = '" + Aplicacion + "' and IDAp = '" + IDAp + "'"
        Else
            query = "insert into global_Tareas (Tipo, IDAp, Creacion, Parametros, Periodicidad, Periodo, Inicio, Fin, Hora, Minutos, Incluir, Activa, CorreoExito, CorreoError, Usuario, Aplicacion) " + _
                    "values ('" + Tipo + "', '" + IDAp + "', getdate(), '" + stParametros + "', '" + Periodicidad + "', " + stPeriodo + ", " + stInicio + "," + stFin + ", " + _
                    stHora + ", " + stMinutos + ", " + Incluir + ", " + Activa.ToString + ", " + CorreoExito + ", " + CorreoError + ", '" + Usuario + "', '" + Aplicacion + "')"
        End If
        Try
            TrSql.EjecutarActualizacion("aspnetdb3", query)
        Catch ex As Exception
            Throw New Exception(ex.Message.ToString + " " + query)
        End Try
    End Sub

    Public Sub TareaPeriodicaEliminar(ByVal IDAp As String)
        'Elimina una tarea periodica
        Dim Aplicacion As String = EspTipoProy.ObtPropiedad("NombreAplicacion")
        Dim query As String = "delete from global_Tareas where IDap = '" + IDAp + "' and Aplicacion = '" + Aplicacion + "'"
        TrSql.EjecutarActualizacion("aspnetdb3", query)
    End Sub

    Public Sub TareaPeriodicaActiva(ByVal IDAp As String, ByVal Activa As Integer)
        'Cambia el estado de una tarea periodica
        Dim Aplicacion As String = EspTipoProy.ObtPropiedad("NombreAplicacion")
        Dim query As String = "update global_Tareas set Activa = " + Activa.ToString + " where IDAp = '" + IDAp + "'"
        TrSql.EjecutarActualizacion("aspnetdb3", query)
    End Sub

End Class
