Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Met_Proveedores_BLL
        Inherits Base_BLL

        Public Shared Sub crud(ByVal query As String, ByVal id As Int32, ByVal calibracion As Boolean, ByVal suministros As Boolean,
                               ByVal nombre As String, ByVal direccion As String, ByVal pais As String, ByVal contacto As String,
                               ByVal correo As String, ByVal telefono As String, ByVal comentarioEnvio As String)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Met_Proveedor_ABCD", New Object() {
                                            New Object() {"@query", query},
                                            New Object() {"@id", id},
                                            New Object() {"@calibracion", calibracion},
                                            New Object() {"@suministros", suministros},
                                            New Object() {"@nombre", nombre},
                                            New Object() {"@direccion", direccion},
                                            New Object() {"@pais", pais},
                                            New Object() {"@contacto", contacto},
                                            New Object() {"@correo", correo},
                                            New Object() {"@telefono", telefono},
                                            New Object() {"@comentario_envio", comentarioEnvio}
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub


        Public Shared Sub eliminar(ByVal id As Integer)
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                trsql.EjecutarActualizacion("TranscoldPruebas", "Met_Proveedor_ABCD", New Object() {
                                            New Object() {"@query", "ELIMINAR"},
                                            New Object() {"@id", id}
                                            }, Data.CommandType.StoredProcedure)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Sub

        Public Shared Function consultar() As DataTable
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Met_Proveedor_ABCD", New Object() {
                                                New Object() {"@query", "TODOS"}
                                                }, Data.CommandType.StoredProcedure).Tables(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function



        Public Shared Function consultar_por_id(ByVal id As String) As DataRow
            MsjError = Nothing
            Try
                Dim trsql As New TransacSQL
                Return trsql.EjecutarConsulta("TranscoldPruebas", "Pru_Entrega_sp", New Object() {
                                                New Object() {"@query", "POR LLAVE"},
                                                New Object() {"@id", id}
                                                }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)
            Catch ex As Exception
                colocaError(ex)
            End Try
        End Function




    End Class

End Namespace

