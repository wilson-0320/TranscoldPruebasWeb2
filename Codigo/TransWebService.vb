Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
'Imports TaskScheduler

Imports System.Security.Principal
Imports System.Data

<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class TransWebService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

    Private Function ConvertToSecureString(ByVal str As String) As System.Security.SecureString
        Dim password As New System.Security.SecureString
        For Each c As Char In str.ToCharArray
            password.AppendChar(c)
        Next
        Return password
    End Function

    Private LOGON32_LOGON_INTERACTIVE As Integer = 2
    Private LOGON32_PROVIDER_DEFAULT As Integer = 0
    Dim impersonationContext As WindowsImpersonationContext
    Declare Function LogonUserA Lib "advapi32.dll" (ByVal lpszUsername As String, ByVal lpszDomain As String, ByVal lpszPassword As String, ByVal dwLogonType As Integer, ByVal dwLogonProvider As Integer, ByRef phToken As IntPtr) As Integer
    Declare Auto Function DuplicateToken Lib "advapi32.dll" (ByVal ExistingTokenHandle As IntPtr, ByVal ImpersonationLevel As Integer, ByRef DuplicateTokenHandle As IntPtr) As Integer
    Declare Auto Function RevertToSelf Lib "advapi32.dll" () As Long
    Declare Auto Function CloseHandle Lib "kernel32.dll" (ByVal handle As IntPtr) As Long

    Public Function impersonateValidUser(ByVal userName As String,
     ByVal domain As String, ByVal password As String) As Boolean

        Dim tempWindowsIdentity As WindowsIdentity
        Dim token As IntPtr = IntPtr.Zero
        Dim tokenDuplicate As IntPtr = IntPtr.Zero
        impersonateValidUser = False

        If RevertToSelf() Then
            If LogonUserA(userName, domain, password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, token) <> 0 Then
                If DuplicateToken(token, 2, tokenDuplicate) <> 0 Then
                    tempWindowsIdentity = New WindowsIdentity(tokenDuplicate)
                    impersonationContext = tempWindowsIdentity.Impersonate()
                    If Not impersonationContext Is Nothing Then
                        impersonateValidUser = True
                    End If
                End If
            End If
        End If
        If Not tokenDuplicate.Equals(IntPtr.Zero) Then
            CloseHandle(tokenDuplicate)
        End If
        If Not token.Equals(IntPtr.Zero) Then
            CloseHandle(token)
        End If
    End Function

    Private Sub undoImpersonation()
        impersonationContext.Undo()
    End Sub

    <WebMethod()>
    <Script.Services.ScriptMethod(UseHttpGet:=True)>
    Public Sub AbreReporte(ByVal Compu As String, ByVal PathReporte As String)
        Dim TrSql As New TransacSQL
        TrSql.EjecutarActualizacion("TranscoldPruebas", "Pru_Compu_Reporte_ABCD", New Object() {
                                    New Object() {"@Op", "Guarda"},
                                    New Object() {"@Compu", Compu},
                                    New Object() {"@PathReporte", PathReporte}
                                    }, Data.CommandType.StoredProcedure)
        'Dim PathReporteador As String = TrSql.EjecutarConsulta("TranscoldPruebas", "Pru_Compu_Reporte_ABCD", New Object() { _
        '                                                       New Object() {"@Op", "Consulta"}, _
        '                                                       New Object() {"@Compu", Compu} _
        '                                                       }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)("PathReporteador")

        'Dim client As Net.WebClient = New Net.WebClient()
        'Dim downloadString As String = client.DownloadString("http://" + Compu + "/ClienteWebApp/PruebasHandler.ashx/AbreReporte?PathReporteador=" + PathReporteador)
        'Return downloadString

        'Dim p As System.Diagnostics.Process = New System.Diagnostics.Process()
        'p.StartInfo.FileName = "schtasks"
        'p.StartInfo.Arguments = "/run /s " + Compu + " /tn AbrirLabView"
        'p.StartInfo.UserName = "administrator"
        'p.StartInfo.Password = ConvertToSecureString("f5ZuwD8cJA2")
        'p.StartInfo.Domain = "fogel-group.com"
        'p.StartInfo.UseShellExecute = False
        'p.Start()

        'If impersonateValidUser("administrator", "fogel-group.com", "f5ZuwD8cJA2") Then
        '    Dim st As ScheduledTasks = New ScheduledTasks("\\\\" + Compu)
        '    Dim t As Task = st.OpenTask("AbrirLabView")
        '    t.SetAccountInformation("administrator@fogel-group.com", "f5ZuwD8cJA2")
        '    t.Run()
        '    t.Close()
        '    undoImpersonation()
        'End If

        'If impersonateValidUser("administrator", "fogel-group.com", "f5ZuwD8cJA2") Then
        'Using ts As TaskService = New TaskService(Compu, "administrator", "fogel-group.com", "f5ZuwD8cJA2")
        '    Dim t As Task = ts.GetTask("AbrirLabView")
        '    t.Run()
        'End Using
        'End If
    End Sub

    Private Sub InitializeComponent()

    End Sub
End Class
