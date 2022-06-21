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


Partial Public Class panelMetrologia

    '''<summary>
    '''Control hfInstrumento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents hfInstrumento As Global.System.Web.UI.WebControls.HiddenField

    '''<summary>
    '''Control upPanel.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents upPanel As Global.System.Web.UI.UpdatePanel

    '''<summary>
    '''Control repeaterMet.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents repeaterMet As Global.System.Web.UI.WebControls.Repeater

    '''<summary>
    '''Control ODSBLL_Met_Instrumentos_Magnitud.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ODSBLL_Met_Instrumentos_Magnitud As Global.System.Web.UI.WebControls.ObjectDataSource

    '''<summary>
    '''Control ddlLaboratorios.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddlLaboratorios As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control lbtnGuardarLaboratorios.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbtnGuardarLaboratorios As Global.System.Web.UI.WebControls.LinkButton

    '''<summary>
    '''Control repeaterLaboratorios.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents repeaterLaboratorios As Global.System.Web.UI.WebControls.Repeater

    '''<summary>
    '''Control ODSBLL_Met_Proveedor_Instrumentos.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ODSBLL_Met_Proveedor_Instrumentos As Global.System.Web.UI.WebControls.ObjectDataSource

    '''<summary>
    '''Control repeaterCertificado.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents repeaterCertificado As Global.System.Web.UI.WebControls.Repeater

    '''<summary>
    '''Control ODSBLL_Met_Certificado.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ODSBLL_Met_Certificado As Global.System.Web.UI.WebControls.ObjectDataSource

    '''<summary>
    '''Control updatePanelCrud.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents updatePanelCrud As Global.System.Web.UI.UpdatePanel

    '''<summary>
    '''Control hfID.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents hfID As Global.System.Web.UI.WebControls.HiddenField

    '''<summary>
    '''Control hfQuery.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents hfQuery As Global.System.Web.UI.WebControls.HiddenField

    '''<summary>
    '''Control upCrud.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents upCrud As Global.System.Web.UI.UpdatePanel

    '''<summary>
    '''Control tbExactitud.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbExactitud As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control tbResolucion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbResolucion As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control tbPuntosCal.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbPuntosCal As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control tbRangoIni.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbRangoIni As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control tbRangoFin.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbRangoFin As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control ddlMagnitud.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddlMagnitud As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control lbtnGuardar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbtnGuardar As Global.System.Web.UI.WebControls.LinkButton

    '''<summary>
    '''Control lbtnCancelar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbtnCancelar As Global.System.Web.UI.WebControls.LinkButton

    '''<summary>
    '''Control hfIDCal.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents hfIDCal As Global.System.Web.UI.WebControls.HiddenField

    '''<summary>
    '''Control hfQueryCal.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents hfQueryCal As Global.System.Web.UI.WebControls.HiddenField

    '''<summary>
    '''Control upCrudCertificado.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents upCrudCertificado As Global.System.Web.UI.UpdatePanel

    '''<summary>
    '''Control ddlLaboratoriosAsignados.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddlLaboratoriosAsignados As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control tbGuiaEnvio.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbGuiaEnvio As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control tbGuiaRetorno.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbGuiaRetorno As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control CbVigente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents CbVigente As Global.System.Web.UI.WebControls.CheckBox

    '''<summary>
    '''Control tbCertificado.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbCertificado As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control tbLinkCertificado.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbLinkCertificado As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control tbFechaCal.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbFechaCal As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control tbFechaProx.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbFechaProx As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control lbtnGuardarCer.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbtnGuardarCer As Global.System.Web.UI.WebControls.LinkButton

    '''<summary>
    '''Control lbtnCancelarCer.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lbtnCancelarCer As Global.System.Web.UI.WebControls.LinkButton
End Class
