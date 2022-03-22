Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Optimization

Public Class BundleConfig
    ' Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkID=303951
    Public Shared Sub RegisterBundles(ByVal bundles As BundleCollection)
        bundles.Add(New ScriptBundle("~/bundles/WebFormsJs").Include(
                        "~/Scripts/WebForms/WebForms.js",
                        "~/Scripts/WebForms/WebUIValidation.js",
                        "~/Scripts/WebForms/MenuStandards.js",
                        "~/Scripts/WebForms/Focus.js",
                        "~/Scripts/WebForms/GridView.js",
                        "~/Scripts/WebForms/DetailsView.js",
                        "~/Scripts/WebForms/TreeView.js",
                        "~/Scripts/WebForms/WebParts.js"))

        ' El orden es muy importante para el funcionamiento de estos archivos ya que tienen dependencias explícitas
        bundles.Add(New ScriptBundle("~/bundles/MsAjaxJs").Include(
                "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js",
                "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"))


        bundles.Add(New ScriptBundle("~/bundles/dashboard").Include(
                "~/Scripts/plugins/bootstrap/js/bootstrap.bundle.min.js",
                "~/Scripts/plugins/select2/js/select2.full.min.js",
                "~/Scripts/plugins/bootstrap4-duallistbox/jquery.bootstrap-duallistbox.min.js",
                "~/Scripts/plugins/moment/moment.min.js",
                "~/Scripts/plugins/inputmask/jquery.inputmask.min.js",
                "~/Scripts/plugins/daterangepicker/daterangepicker.js",
                "~/Scripts/plugins/bootstrap-colorpicker/js/bootstrap-colorpicker.min.js",
                "~/Scripts/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js",
                "~/Scripts/plugins/bootstrap-switch/js/bootstrap-switch.min.js",
                "~/Scripts/plugins/bs-stepper/js/bs-stepper.min.js",
                "~/Scripts/plugins/dropzone/min/dropzone.min.js"))
        ' Use la versión de desarrollo de Modernizr para desarrollar y aprender. Luego, cuando esté listo
        ' para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite
        bundles.Add(New ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"))
    End Sub
End Class
