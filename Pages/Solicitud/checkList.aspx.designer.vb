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


Partial Public Class checkList

    '''<summary>
    '''Control upCrud.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents upCrud As Global.System.Web.UI.UpdatePanel

    '''<summary>
    '''Control tbCodigoFiltro.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbCodigoFiltro As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control tbModeloFiltro.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbModeloFiltro As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control btnGenerar.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnGenerar As Global.System.Web.UI.WebControls.LinkButton

    '''<summary>
    '''Control hfQuery.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents hfQuery As Global.System.Web.UI.WebControls.HiddenField

    '''<summary>
    '''Control hfID.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents hfID As Global.System.Web.UI.WebControls.HiddenField

    '''<summary>
    '''Control lblTipo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblTipo As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control dplTipo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents dplTipo As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control lblCliente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblCliente As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control tbCliente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbCliente As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control lblPais.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblPais As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control tbPais.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbPais As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control lblSolicitado.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblSolicitado As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control tbSolicitado.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbSolicitado As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control lblSolicitud.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblSolicitud As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control tbCodigo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbCodigo As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control lblModelo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblModelo As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control tbModelo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbModelo As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control lblwo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblwo As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control tbWorkOrder.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbWorkOrder As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control lblNoSerie.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblNoSerie As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control tbSerie.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbSerie As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control lblUsuarioOperador.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblUsuarioOperador As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control lblUser.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblUser As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control lblUsuarioDespacho.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblUsuarioDespacho As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control tbDespachos.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbDespachos As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control lblParillas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblParillas As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control tbParrillas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbParrillas As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control lblClips.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblClips As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control tbClips.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbClips As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control lblLamparas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblLamparas As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control tbLamparas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbLamparas As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control lblRotulo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblRotulo As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control cbRotulo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cbRotulo As Global.System.Web.UI.WebControls.CheckBox

    '''<summary>
    '''Control lblCubremotor.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblCubremotor As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control cbCubremotor.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cbCubremotor As Global.System.Web.UI.WebControls.CheckBox

    '''<summary>
    '''Control lblCertificado.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblCertificado As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control cbCertificado.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cbCertificado As Global.System.Web.UI.WebControls.CheckBox

    '''<summary>
    '''Control lblEtiqueta.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblEtiqueta As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control cbEtiquetaSerie.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cbEtiquetaSerie As Global.System.Web.UI.WebControls.CheckBox

    '''<summary>
    '''Control lblMan1.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblMan1 As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control cbManOpe.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cbManOpe As Global.System.Web.UI.WebControls.CheckBox

    '''<summary>
    '''Control lblManIns.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblManIns As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control cbManIns.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cbManIns As Global.System.Web.UI.WebControls.CheckBox

    '''<summary>
    '''Control lblCal.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblCal As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control cbCalcomania.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cbCalcomania As Global.System.Web.UI.WebControls.CheckBox

    '''<summary>
    '''Control lblDiagrama.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblDiagrama As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control cbDiagrama.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cbDiagrama As Global.System.Web.UI.WebControls.CheckBox

    '''<summary>
    '''Control lblFunciona.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblFunciona As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control cbFuncionamiento.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cbFuncionamiento As Global.System.Web.UI.WebControls.CheckBox

    '''<summary>
    '''Control lblParTrasera.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblParTrasera As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control cbParrillasTraseras.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cbParrillasTraseras As Global.System.Web.UI.WebControls.CheckBox

    '''<summary>
    '''Control lblHalador.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblHalador As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control cbHalador.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents cbHalador As Global.System.Web.UI.WebControls.CheckBox

    '''<summary>
    '''Control lblGolpes.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblGolpes As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control tbGolpes.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbGolpes As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control lblRayon.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblRayon As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control tbRayones.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbRayones As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control lblComentarios.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblComentarios As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control tbComentarios.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents tbComentarios As Global.System.Web.UI.WebControls.TextBox

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
    '''Control RepeaterRecepcion.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents RepeaterRecepcion As Global.System.Web.UI.WebControls.Repeater
End Class
