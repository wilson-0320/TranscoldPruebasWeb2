Imports Microsoft.VisualBasic
Imports System.Data

Namespace BLL

    Public Class Solicitud_Elemento_BLL

        'Const PathBase As String = "\\fogelgt1\E$\\EstaticosWeb\\TranscoldPruebasWeb\\"
        Const PathBase As String = "E:\\EstaticosWeb\\TranscoldPruebasWeb\\"

        Public Shared Function Inserta(ByVal Solicitud_Cod As String, ByVal Elemento_ID As Integer, ByVal Valor As String, ByVal Cantidad As String,
                                  ByVal Precio As String, ByVal Comentario As String, ByVal EsExterno As Boolean, ByVal usuario As String) As String
            Dim TrSql As New TransacSQL
            Dim msj As String = TrSql.EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Elemento_Actualiza", New Object() {
                                   New Object() {"@Tipo", "Insertar"},
                                   New Object() {"@Solicitud_Cod", Solicitud_Cod.TrimEnd},
                                   New Object() {"@Elemento_ID", Elemento_ID},
                                   New Object() {"@Valor", Valor},
                                   New Object() {"@Cantidad", Cantidad},
                                   New Object() {"@Precio", Precio},
                                   New Object() {"@Comentario", Comentario},
                                   New Object() {"@EsExterno", EsExterno},
                                   New Object() {"@usuario", usuario}
                                   }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)(0)
            If Not msj.StartsWith("Error:") Then
                Dim v As String() = msj.Split("/")
                Dim ElemID As String = v(0)
                For Each Archivo As String In v(1).Split("|")
                    If Archivo <> "" Then
                        ArchivosLib.MoverArchivoADirectorio(PathBase + "ElemSol\\" + usuario + "\\", PathBase + "ElemSol\\" + ElemID.ToString + "\\", Archivo)
                    End If
                Next
            End If
            Return msj
        End Function


        Public Shared Function modificarEliminar(ByVal tipo As String, ByVal Solicitud_Cod As String, ByVal ID As Int32, ByVal Elemento_ID As Integer, ByVal Valor As String, ByVal Cantidad As String,
                                ByVal Precio As String, ByVal Comentario As String, ByVal EsExterno As Boolean, ByVal usuario As String) As String
            Dim TrSql As New TransacSQL
            Dim msj As String = TrSql.EjecutarConsulta("TranscoldPruebas", "Pru_Solicitud_Elemento_Actualiza", New Object() {
                                   New Object() {"@Tipo", tipo},
                                   New Object() {"@Solicitud_Cod", Solicitud_Cod},
                                   New Object() {"@ID", ID},
                                   New Object() {"@Elemento_ID", Elemento_ID},
                                   New Object() {"@Valor", Valor},
                                   New Object() {"@Cantidad", Cantidad},
                                   New Object() {"@Precio", Precio},
                                   New Object() {"@Comentario", Comentario},
                                   New Object() {"@EsExterno", EsExterno},
                                   New Object() {"@usuario", usuario}
                                   }, Data.CommandType.StoredProcedure).Tables(0).Rows(0)(0)
            '  New Object() {"@usuario", HttpContext.Current.User.Identity.Name} _

            Return msj
        End Function
    End Class

End Namespace
