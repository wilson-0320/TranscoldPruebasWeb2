Imports Microsoft.VisualBasic

Public Class TAF


    Dim TrSql_ As TransacSQL
    Dim QueriesTA_ As ApDataSetTableAdapters.QueriesTableAdapter
    Dim SolicitudTA_ As ApDataSetTableAdapters.Pru_SolicitudTableAdapter
    Dim SolEnsayoTA_ As ApDataSetTableAdapters.Pru_Solicitud_EnsayoTableAdapter
    Dim SolElementoTA_ As ApDataSetTableAdapters.Pru_Solicitud_ElementoTableAdapter
    Dim SolHistTA_ As ApDataSetTableAdapters.Pru_Solicitud_HistoricoTableAdapter
    Dim SolHistElemTA_ As ApDataSetTableAdapters.Pru_Solicitud_Historico_ElementoTableAdapter
    Dim CatalogoCategTA_ As ApDataSetTableAdapters.Pru_Catalogo_CategoriaTableAdapter
    Dim CatalogoTA_ As ApDataSetTableAdapters.Pru_CatalogoTableAdapter
    Dim ElemTA_ As ApDataSetTableAdapters.Pru_ElementoTableAdapter
    Dim ArchTA_ As ApDataSetTableAdapters.Pru_ArchivoTableAdapter
    Dim EqTA_ As ApDataSetTableAdapters.Pru_EquivalenciasTableAdapter
    Dim CompresorCompTA_ As ApDataSetTableAdapters.Pru_Compresor_ComponentesTableAdapter



    Public Function ValidaNulo(ByVal Row As Object, ByVal NomCampo As String, ByVal Defabol As Object, Optional formato As String = "") As Object
        Try
            If Row(NomCampo) Is DBNull.Value Then
                Return Defabol
            Else
                If formato = "" Then
                    Return Row(NomCampo)
                ElseIf formato = "fecha" Then
                    Return CType(Row(NomCampo), DateTime).ToString("dd/MM/yyyy")
                End If
            End If
        Catch ex As Exception
            Return Row(NomCampo)
        End Try
    End Function



    Public Function TrSql() As TransacSQL
        If TrSql_ Is Nothing Then
            TrSql_ = New TransacSQL
        End If
        Return TrSql_
    End Function

    Public Function QueriesTA() As ApDataSetTableAdapters.QueriesTableAdapter
        If QueriesTA_ Is Nothing Then
            QueriesTA_ = New ApDataSetTableAdapters.QueriesTableAdapter
        End If
        Return QueriesTA_
    End Function

    Public Function SolicitudTA() As ApDataSetTableAdapters.Pru_SolicitudTableAdapter
        If SolicitudTA_ Is Nothing Then
            SolicitudTA_ = New ApDataSetTableAdapters.Pru_SolicitudTableAdapter
        End If
        Return SolicitudTA_
    End Function

    Public Function SolEnsayoTA() As ApDataSetTableAdapters.Pru_Solicitud_EnsayoTableAdapter
        If SolEnsayoTA_ Is Nothing Then
            SolEnsayoTA_ = New ApDataSetTableAdapters.Pru_Solicitud_EnsayoTableAdapter
        End If
        Return SolEnsayoTA_
    End Function

    Public Function SolElementoTA() As ApDataSetTableAdapters.Pru_Solicitud_ElementoTableAdapter
        If SolElementoTA_ Is Nothing Then
            SolElementoTA_ = New ApDataSetTableAdapters.Pru_Solicitud_ElementoTableAdapter
        End If
        Return SolElementoTA_
    End Function

    Public Function SolHistTA() As ApDataSetTableAdapters.Pru_Solicitud_HistoricoTableAdapter
        If SolHistTA_ Is Nothing Then
            SolHistTA_ = New ApDataSetTableAdapters.Pru_Solicitud_HistoricoTableAdapter
        End If
        Return SolHistTA_
    End Function

    Public Function SolHistElemTA() As ApDataSetTableAdapters.Pru_Solicitud_Historico_ElementoTableAdapter
        If SolHistElemTA_ Is Nothing Then
            SolHistElemTA_ = New ApDataSetTableAdapters.Pru_Solicitud_Historico_ElementoTableAdapter
        End If
        Return SolHistElemTA_
    End Function

    Public Function CatalogoCategTA() As ApDataSetTableAdapters.Pru_Catalogo_CategoriaTableAdapter
        If CatalogoCategTA_ Is Nothing Then
            CatalogoCategTA_ = New ApDataSetTableAdapters.Pru_Catalogo_CategoriaTableAdapter
        End If
        Return CatalogoCategTA_
    End Function

    Public Function CatalogoTA() As ApDataSetTableAdapters.Pru_CatalogoTableAdapter
        If CatalogoTA_ Is Nothing Then
            CatalogoTA_ = New ApDataSetTableAdapters.Pru_CatalogoTableAdapter
        End If
        Return CatalogoTA_
    End Function

    Public Function ElemTA() As ApDataSetTableAdapters.Pru_ElementoTableAdapter
        If ElemTA_ Is Nothing Then
            ElemTA_ = New ApDataSetTableAdapters.Pru_ElementoTableAdapter
        End If
        Return ElemTA_
    End Function

    Public Function ArchTA() As ApDataSetTableAdapters.Pru_ArchivoTableAdapter
        If ArchTA_ Is Nothing Then
            ArchTA_ = New ApDataSetTableAdapters.Pru_ArchivoTableAdapter
        End If
        Return ArchTA_
    End Function

    Public Function EqTA() As ApDataSetTableAdapters.Pru_EquivalenciasTableAdapter
        If EqTA_ Is Nothing Then
            EqTA_ = New ApDataSetTableAdapters.Pru_EquivalenciasTableAdapter
        End If
        Return EqTA_
    End Function

    Public Function CompresorCompTA() As ApDataSetTableAdapters.Pru_Compresor_ComponentesTableAdapter
        If CompresorCompTA_ Is Nothing Then
            CompresorCompTA_ = New ApDataSetTableAdapters.Pru_Compresor_ComponentesTableAdapter
        End If
        Return CompresorCompTA_
    End Function






End Class
