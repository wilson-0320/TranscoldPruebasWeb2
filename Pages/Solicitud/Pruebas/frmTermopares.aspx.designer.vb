'------------------------------------------------------------------------------
' <generado automáticamente>
'     Este código fue generado por una herramienta.
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código. 
' </generado automáticamente>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Partial Public Class frmTermopares

    '''<summary>
    '''Control ddlFecha.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddlFecha As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control tbFechaReemplazo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbFechaReemplazo As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control lbtnModificarFecha.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbtnModificarFecha As Global.System.Web.UI.WebControls.LinkButton

    '''<summary>
    '''Control lbtnFiltrar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbtnFiltrar As Global.System.Web.UI.WebControls.LinkButton

    '''<summary>
    '''Control lbtnModificar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbtnModificar As Global.System.Web.UI.WebControls.LinkButton

    '''<summary>
    '''Control lbtnGuardar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbtnGuardar As Global.System.Web.UI.WebControls.LinkButton

    '''<summary>
    '''Control pnlTodo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents pnlTodo As Global.System.Web.UI.UpdatePanel

    '''<summary>
    '''Control divProdTemp.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents divProdTemp As Global.System.Web.UI.HtmlControls.HtmlGenericControl

    '''<summary>
    '''Control gvFilas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents gvFilas As Global.System.Web.UI.WebControls.GridView

    '''<summary>
    '''Control dsTermoparFila.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents dsTermoparFila As Global.System.Web.UI.WebControls.ObjectDataSource

    '''<summary>
    '''Control divRefrSystem1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents divRefrSystem1 As Global.System.Web.UI.HtmlControls.HtmlGenericControl

    '''<summary>
    '''Control wucRefrigSystem1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents wucRefrigSystem1 As Global.TranscoldPruebasWeb2.wucRefrig

    '''<summary>
    '''Control divRefrSystem2.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents divRefrSystem2 As Global.System.Web.UI.HtmlControls.HtmlGenericControl

    '''<summary>
    '''Control wucRefrSystem2.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents wucRefrSystem2 As Global.TranscoldPruebasWeb2.wucRefrig

    '''<summary>
    '''Control divGlassDoor.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents divGlassDoor As Global.System.Web.UI.HtmlControls.HtmlGenericControl

    '''<summary>
    '''Control wucGlassDoor.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents wucGlassDoor As Global.TranscoldPruebasWeb2.wucVidrios

    '''<summary>
    '''Control divEvaporatorPan.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents divEvaporatorPan As Global.System.Web.UI.HtmlControls.HtmlGenericControl

    '''<summary>
    '''Control wucEvaporatorPan.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents wucEvaporatorPan As Global.TranscoldPruebasWeb2.wucPanaEvaporador

    '''<summary>
    '''Control divElectrIndivM.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents divElectrIndivM As Global.System.Web.UI.HtmlControls.HtmlGenericControl

    '''<summary>
    '''Control wucElectrIndivM.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents wucElectrIndivM As Global.TranscoldPruebasWeb2.wucElectric

    '''<summary>
    '''Control divStationParams.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents divStationParams As Global.System.Web.UI.HtmlControls.HtmlGenericControl

    '''<summary>
    '''Control wucStationParams.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents wucStationParams As Global.TranscoldPruebasWeb2.wucEstacionPruebas

    '''<summary>
    '''Control divValoresAdicionales.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents divValoresAdicionales As Global.System.Web.UI.HtmlControls.HtmlGenericControl

    '''<summary>
    '''Control wucValoresAdicionales.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents wucValoresAdicionales As Global.TranscoldPruebasWeb2.wucAdicionales
End Class
