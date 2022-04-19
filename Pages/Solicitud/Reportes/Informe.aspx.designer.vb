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


Partial Public Class Informe

    '''<summary>
    '''Control tbCodigo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbCodigo As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control tbComputadora.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbComputadora As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control listOpciones.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents listOpciones As Global.System.Web.UI.WebControls.ListBox

    '''<summary>
    '''Control btnGenerar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnGenerar As Global.System.Web.UI.WebControls.LinkButton

    '''<summary>
    '''Control cbPresentacion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cbPresentacion As Global.System.Web.UI.WebControls.CheckBox

    '''<summary>
    '''Control upCrud.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents upCrud As Global.System.Web.UI.UpdatePanel

    '''<summary>
    '''Control hfIDElmentoCrud.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents hfIDElmentoCrud As Global.System.Web.UI.WebControls.HiddenField

    '''<summary>
    '''Control hfListElemento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents hfListElemento As Global.System.Web.UI.WebControls.HiddenField

    '''<summary>
    '''Control hfTipoCrud.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents hfTipoCrud As Global.System.Web.UI.WebControls.HiddenField

    '''<summary>
    '''Control hfElementID.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents hfElementID As Global.System.Web.UI.WebControls.HiddenField

    '''<summary>
    '''Control hfTipoImagen.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents hfTipoImagen As Global.System.Web.UI.WebControls.HiddenField

    '''<summary>
    '''Control hfUsuario.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents hfUsuario As Global.System.Web.UI.WebControls.HiddenField

    '''<summary>
    '''Control __tbCodigoEditorCrud.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents __tbCodigoEditorCrud As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control ddlDivision.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddlDivision As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control panelHistorico.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents panelHistorico As Global.System.Web.UI.WebControls.Panel

    '''<summary>
    '''Control lblUserPrueba.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblUserPrueba As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control fnEnviado.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents fnEnviado As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control lblUserRevisado.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblUserRevisado As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control fnRevisado.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents fnRevisado As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control lblEstadoTransaccion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblEstadoTransaccion As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control listElemento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents listElemento As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control btnGuardarCrud.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnGuardarCrud As Global.System.Web.UI.WebControls.LinkButton

    '''<summary>
    '''Control btnEliminarCrud.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnEliminarCrud As Global.System.Web.UI.WebControls.LinkButton

    '''<summary>
    '''Control btnCancelarModificacion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnCancelarModificacion As Global.System.Web.UI.WebControls.LinkButton

    '''<summary>
    '''Control tbCodigoCrud.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbCodigoCrud As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control listCodigoCrud.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents listCodigoCrud As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control cbExterno.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cbExterno As Global.System.Web.UI.WebControls.CheckBox

    '''<summary>
    '''Control tbCantidadCrud.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbCantidadCrud As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control ddlCargaRefrigerante.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddlCargaRefrigerante As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control tbPrecioCrud.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbPrecioCrud As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control tbComentariosObservacionesCrud.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbComentariosObservacionesCrud As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control panelTxtEnriquecido.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents panelTxtEnriquecido As Global.System.Web.UI.WebControls.Panel

    '''<summary>
    '''Control upImagenesUpload.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents upImagenesUpload As Global.System.Web.UI.UpdatePanel

    '''<summary>
    '''Control tbDescripcionFoto.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbDescripcionFoto As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control fuArchivos.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents fuArchivos As Global.System.Web.UI.WebControls.FileUpload

    '''<summary>
    '''Control btnGuardarFoto.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnGuardarFoto As Global.System.Web.UI.WebControls.LinkButton

    '''<summary>
    '''Control repeaterImagenes.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents repeaterImagenes As Global.System.Web.UI.WebControls.Repeater

    '''<summary>
    '''Control upGVpendienteRevision.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents upGVpendienteRevision As Global.System.Web.UI.UpdatePanel

    '''<summary>
    '''Control btnEnviarRevision.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnEnviarRevision As Global.System.Web.UI.WebControls.LinkButton

    '''<summary>
    '''Control repeaterPendienteRevision.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents repeaterPendienteRevision As Global.System.Web.UI.WebControls.Repeater

    '''<summary>
    '''Control upLinea.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents upLinea As Global.System.Web.UI.UpdatePanel

    '''<summary>
    '''Control panelLineaTiempo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents panelLineaTiempo As Global.System.Web.UI.WebControls.Panel

    '''<summary>
    '''Control hfCodigo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents hfCodigo As Global.System.Web.UI.WebControls.HiddenField

    '''<summary>
    '''Control hfDivision.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents hfDivision As Global.System.Web.UI.WebControls.HiddenField

    '''<summary>
    '''Control hfSolicitud.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents hfSolicitud As Global.System.Web.UI.WebControls.HiddenField

    '''<summary>
    '''Control repeaterReporte.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents repeaterReporte As Global.System.Web.UI.WebControls.Repeater
End Class
