Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Generic

Public Class TransacSQL

    Protected ComandoSQL As New SqlCommand
    Protected SQLDA As SqlDataAdapter
    Protected SQLCB As SqlCommandBuilder
    Protected RegistroSQL As DataSet
    Protected Conexiones As Generic.Dictionary(Of String, Object()) = New Generic.Dictionary(Of String, Object())
    'Este diccionario de conexiones permite obtener siempre la misma instancia de conexion, si la base de datos es la misma

    Public Function Conn(ByVal bd As String, Optional ByVal TimeOut As Integer = -1) As Object()
        bd = bd.ToUpper
        If Not Conexiones.ContainsKey(bd) Then
            'Server=192.168.1.2; uid=TranscoldSa; pwd=SaTranscolD;
            '"Server=WUZPA; uid=wuzpa; pwd=wuz33.;
            Conexiones.Add(bd, New Object() {New SqlConnection("Server=WUZPA; uid=wuzpa; pwd=wuz33.; database=" + bd), TimeOut})
        End If
        Return Conexiones(bd)
    End Function

    Public Function EjecutarConsulta(ByVal bd As String, ByVal Consulta As String, Optional ByVal parametros As Object() = Nothing, _
                                     Optional ByVal CommType As CommandType = CommandType.Text) As DataSet
        Conn(bd)(0).Open()
        If Conn(bd)(1) <> -1 Then
            ComandoSQL.CommandTimeout = Conn(bd)(1)
        End If
        ComandoSQL.Connection = Conn(bd)(0)
        ComandoSQL.CommandText = Consulta
        ComandoSQL.CommandTimeout = 180
        ComandoSQL.CommandType = CommType
        SQLDA = New SqlDataAdapter(ComandoSQL)
        SQLCB = New SqlCommandBuilder(SQLDA)

        ComandoSQL.Parameters.Clear()
        If Not parametros Is Nothing Then
            For Each parametro As Object In parametros
                If parametro.GetType.Name.Contains("SqlParameter") Then
                    ComandoSQL.Parameters.Add(parametro)
                Else
                    Dim param As New SqlParameter(parametro(0).ToString, parametro(1))
                    ComandoSQL.Parameters.Add(param)
                End If
            Next
        End If

        RegistroSQL = New DataSet
        Try
            SQLDA.Fill(RegistroSQL)
        Catch Ex As Exception
            EjecutarConsulta = Nothing
            Conn(bd)(0).Close()
            If Ex.InnerException Is Nothing Then
                Throw New Exception(Ex.Message)
            Else
                Throw New Exception(Ex.InnerException.Message)
            End If
        End Try
        EjecutarConsulta = RegistroSQL
        Conn(bd)(0).Close()
    End Function

    Public Function ValorEjecutarConsulta(ByVal bd As String, ByVal Consulta As String, Optional ByVal parametros As Object() = Nothing, Optional ByVal Defabol As Object = Nothing, _
                                          Optional ByVal CommType As CommandType = CommandType.Text) As Object
        Dim dt As DataTable = EjecutarConsulta(bd, Consulta, parametros, CommType).Tables(0)
        If dt.Rows.Count = 0 And Not Defabol Is Nothing Then
            Return Defabol
        End If
        Return dt.Rows(0)(0)
    End Function

    Public Sub EjecutarActualizacion(ByVal bd As String, ByVal Consulta As String, Optional ByVal parametros As Object() = Nothing, _
                                     Optional ByVal CommType As CommandType = CommandType.Text)
        Conn(bd)(0).Open()
        If Conn(bd)(1) <> -1 Then
            ComandoSQL.CommandTimeout = Conn(bd)(1)
        End If
        ComandoSQL.Connection = Conn(bd)(0)
        ComandoSQL.CommandText = Consulta
        ComandoSQL.CommandTimeout = 1000
        ComandoSQL.CommandType = CommType

        ComandoSQL.Parameters.Clear()
        If Not parametros Is Nothing Then
            For Each parametro As Object In parametros
                If parametro.GetType.Name.Contains("SqlParameter") Then
                    ComandoSQL.Parameters.Add(parametro)
                Else
                    Dim param As New SqlParameter(parametro(0).ToString, parametro(1))
                    ComandoSQL.Parameters.Add(param)
                End If
            Next
        End If

        Try
            ComandoSQL.ExecuteNonQuery()
        Catch Ex As Exception
            Conn(bd)(0).Close()
            If Ex.InnerException Is Nothing Then
                Throw New Exception(Ex.Message)
            Else
                Throw New Exception(Ex.InnerException.Message)
            End If
        End Try
        Conn(bd)(0).Close()
    End Sub

    Public Function DiccionarioADataTable(ByVal stNomColumnas As String, ByVal stTiposColumnas As String, ByRef Filas As ArrayList) As DataTable
        Dim NomColumnas As String() = stNomColumnas.Split(",")
        Dim TiposColumnas As String() = stTiposColumnas.ToLower.Split(",")
        Dim dt As New DataTable
        For Each NomColumna As Object In NomColumnas
            dt.Columns.Add(NomColumna, GetType(String))
        Next
        For Each Fila As Dictionary(Of String, Object) In Filas
            Dim dr As DataRow = dt.NewRow()
            For i As Integer = 0 To NomColumnas.Length - 1
                Dim NomColumna As String = NomColumnas(i)
                Dim TipoColumna As String = TiposColumnas(i)
                If Fila(NomColumna) Is DBNull.Value Then
                    dr(NomColumna) = DBNull.Value
                ElseIf TipoColumna = "string" Then
                    dr(NomColumna) = CType(Fila(NomColumna), String)
                ElseIf TipoColumna = "integer" Then
                    dr(NomColumna) = CType(Fila(NomColumna), Integer)
                ElseIf TipoColumna = "double" Then
                    dr(NomColumna) = CType(Fila(NomColumna), Double)
                ElseIf TipoColumna = "boolean" Then
                    dr(NomColumna) = CType(Fila(NomColumna), Boolean)
                End If
            Next
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Function ObtParamLista(ByVal NomCampo As String, ByVal NombreTipo As String, ByVal stNomColumnas As String, _
                                  ByVal stTiposColumnas As String, ByRef Filas As ArrayList) As SqlParameter
        Dim param_l As New SqlParameter(NomCampo, SqlDbType.Structured)
        param_l.Direction = ParameterDirection.Input
        param_l.TypeName = NombreTipo
        param_l.Value = DiccionarioADataTable(stNomColumnas, stTiposColumnas, Filas)
        Return param_l
    End Function

    Public Function ObtParamLista(ByVal NomCampo As String, ByVal NombreTipo As String, ByVal DT As DataTable) As SqlParameter
        Dim param_l As New SqlParameter(NomCampo, SqlDbType.Structured)
        param_l.Direction = ParameterDirection.Input
        param_l.TypeName = NombreTipo
        param_l.Value = DT
        Return param_l
    End Function

End Class
