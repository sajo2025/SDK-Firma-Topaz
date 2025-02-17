' SDK para Captura de Firmas con Topaz T-LBK750-BHSB-R en Infosalud
Imports SigPlusNET
Imports System.Threading

Public Class CapturaFirmaTopaz
    Private sigObj As New SigPlusNET()
    Private rutaFirma As String = "C:\Firmas\firma_paciente.bmp"

    ' Constructor que inicializa la tableta automáticamente
    Public Sub New()
        IniciarTablet()
    End Sub

    ' Inicializa la tableta
    Public Sub IniciarTablet()
        sigObj.SetTabletState(1) ' Activa la tableta
        sigObj.SetImageXSize(500)
        sigObj.SetImageYSize(200)
    End Sub

    ' Captura la firma y la guarda como imagen
    Public Function CapturarFirma() As Boolean
        If sigObj.NumberOfTabletPoints() > 0 Then
            sigObj.SaveSigImage(rutaFirma)
            Return True ' Firma capturada con éxito
        Else
            Return False ' No se detectó firma
        End If
    End Function

    ' Obtiene la ruta de la firma guardada
    Public Function ObtenerRutaFirma() As String
        Return rutaFirma
    End Function

    ' Mantener la aplicación en ejecución para detectar la tableta
    Public Sub Ejecutar()
        While True
            Thread.Sleep(1000) ' Espera 1 segundo antes de verificar nuevamente
        End While
    End Sub
End Class

' Punto de entrada de la aplicación
Module Main
    Sub Main()
        Dim firmaTopaz As New CapturaFirmaTopaz()
        firmaTopaz.Ejecutar()
    End Sub
End Module
