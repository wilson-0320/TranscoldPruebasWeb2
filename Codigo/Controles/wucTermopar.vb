Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

Public Class wucTermopar
    Inherits System.Web.UI.UserControl

    Private _codigo As String
    Private _stFecha As String
    Private _posicion_ini As Integer
    Private _posicion_fin As Integer
    Private _tb_ini As Integer

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarDatos()
        End If
    End Sub

    Public Sub CargarDatos()
        Dim dt As DataTable = BLL.Pru_Termopar_BLL.consulta(_codigo, _stFecha, -1, _posicion_ini, _posicion_fin)
        For Each dr As DataRow In dt.Rows
            If dr("posicion") = 317 Then
                Dim i As Integer = 1
                i = 2
            End If
            Dim num_canal As String = ""
            If Not dr("num_canal") Is DBNull.Value Then
                num_canal = dr("num_canal")
            End If
            Dim ctrlID As String = dr("posicion") - _posicion_ini + _tb_ini
            CType(FindControl("tb" + ctrlID), HtmlInputText).Value = num_canal
            If Not FindControl("tbNom" + ctrlID) Is Nothing Then
                Dim nombre As String = ""
                If Not dr("nombre") Is DBNull.Value Then
                    nombre = dr("nombre")
                End If
                CType(FindControl("tbNom" + ctrlID), HtmlInputText).Value = nombre
            End If
            If Not FindControl("tbNum" + ctrlID) Is Nothing Then
                Dim num As String = ""
                If Not dr("num") Is DBNull.Value Then
                    num = dr("num")
                End If
                CType(FindControl("tbNum" + ctrlID), HtmlInputText).Value = num
            End If
        Next
    End Sub

    <Bindable(True, BindingDirection.OneWay)> _
    <Browsable(True)> _
    <Category("Data")> _
    Public WriteOnly Property codigo() As String
        Set(ByVal value As String)
            _codigo = value
        End Set
    End Property

    <Bindable(True, BindingDirection.OneWay)> _
    <Browsable(True)> _
    <Category("Data")> _
    Public WriteOnly Property stFecha() As String
        Set(ByVal value As String)
            _stFecha = value
        End Set
    End Property

    <Bindable(True, BindingDirection.OneWay)> _
    <Browsable(True)> _
    <Category("Data")> _
    Public WriteOnly Property posicion_ini() As Integer
        Set(ByVal value As Integer)
            _posicion_ini = value
        End Set
    End Property

    <Bindable(True, BindingDirection.OneWay)> _
    <Browsable(True)> _
    <Category("Data")> _
    Public WriteOnly Property posicion_fin() As Integer
        Set(ByVal value As Integer)
            _posicion_fin = value
        End Set
    End Property

    <Bindable(True, BindingDirection.OneWay)> _
    <Browsable(True)> _
    <Category("Data")> _
    Public WriteOnly Property tb_ini() As Integer
        Set(ByVal value As Integer)
            _tb_ini = value
        End Set
    End Property

    Public Sub AgregaADt(ByRef dt As DataTable)
        For Each ctrl As Control In Me.Controls
            If Not ctrl.ID Is Nothing AndAlso ctrl.ID.StartsWith("tb") AndAlso Not ctrl.ID.StartsWith("tbNom") AndAlso Not ctrl.ID.StartsWith("tbNum") Then
                Dim nombre As String = ""
                If Not FindControl(ctrl.ID.Replace("tb", "tbNom")) Is Nothing Then
                    nombre = CType(FindControl(ctrl.ID.Replace("tb", "tbNom")), HtmlInputText).Value
                End If
                Dim num As String = ""
                If Not FindControl(ctrl.ID.Replace("tb", "tbNum")) Is Nothing Then
                    num = CType(FindControl(ctrl.ID.Replace("tb", "tbNum")), HtmlInputText).Value
                End If
                dt.Rows.Add(CInt(ctrl.ID.Replace("tb", "")) - _tb_ini + _posicion_ini, CType(ctrl, HtmlInputText).Value, False, num, nombre)
            End If
        Next
    End Sub

End Class
