﻿Imports System.Web.Script.Serialization

' Raw image data type.
Public Class FingerImage
    ' Image data.
    Public rawImage As Object
    Public img As System.Drawing.Image
    ' Image width.
    Public width As Long
    ' Image height.
    Public height As Long
    ' Image resolution.
    Public res As Long
End Class
Public Class FingerprintUtil
    Private Declare Function GetDC Lib "user32" (ByVal hwnd As Int32) As Int32
    Dim labelStatus As Label
    Dim grFingerX As AxGrFingerXLib.AxGrFingerXCtrl

    ' Raw image data type.
    Public Sub New(ByVal labelStatus As Label, ByVal grFingerX As AxGrFingerXLib.AxGrFingerXCtrl)
        Me.labelStatus = labelStatus
        Me.grFingerX = grFingerX
    End Sub

    Public Function initializeFigerprint()
        Dim status As Integer = grFingerX.Initialize
        If status < 0 Then
            Return status
        End If
        Return grFingerX.CapInitialize
    End Function
    Public Function captureImage(ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_ImageAcquiredEvent) As FingerImage
        Dim hdc As Integer = GetDC(0)
        Dim fingerImage As New FingerImage
        fingerImage.rawImage = e.rawImage
        fingerImage.width = e.width
        fingerImage.height = e.height
        fingerImage.res = e.res
        grFingerX.BiometricDisplay(extractFingerprint(fingerImage), fingerImage.rawImage, e.width, e.height, e.res, hdc, fingerImage.img, GrFingerXLib.GRConstants.GR_NO_CONTEXT)
        'grFingerX.CapRawImageToHandle(fingerImage.rawImage, e.width, e.height, hdc, fingerImage.img)
        Return fingerImage
    End Function
    Public Sub disposeFingerprint()
        grFingerX.Finalize()
        grFingerX.CapFinalize()
    End Sub
    Public Function extractFingerprint(ByVal fingerImage As FingerImage) As Array

        Dim fingerprint As Array = Array.CreateInstance(GetType(Byte), 5000)
        Dim status As Integer = grFingerX.Extract(fingerImage.rawImage, fingerImage.width, fingerImage.height, fingerImage.res, fingerprint, fingerprint.Length, GrFingerXLib.GRConstants.GR_DEFAULT_CONTEXT)

        If status < 0 Then
            Return Nothing
        Else
            Return fingerprint
        End If
    End Function

    Public Function verifyFingerprint(ByVal soureFingerprint As Array, ByVal desFingerprint As Array, ByRef score As String) As Boolean

        Dim result As Integer
        'result = grFingerX.Verify(soureFingerprint, desFingerprint, score, GrFingerXLib.GRConstants.GR_DEFAULT_CONTEXT)
        result = grFingerX.IdentifyPrepare(soureFingerprint, GrFingerXLib.GRConstants.GR_DEFAULT_CONTEXT)

        If result < 0 Then Return False

        result = grFingerX.Identify(desFingerprint, score, GrFingerXLib.GRConstants.GR_DEFAULT_CONTEXT)
        If result = GrFingerXLib.GRConstants.GR_MATCH Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Function indentifyFingerprint(ByVal fingerprint As Array, ByRef score As String) As Boolean

        Dim result As Integer = grFingerX.Identify(fingerprint, score, GrFingerXLib.GRConstants.GR_DEFAULT_CONTEXT)
        If result = GrFingerXLib.GRConstants.GR_MATCH Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function setSourceFingerprint(ByVal soureFingerprint As Array) As Integer
        Dim result As Integer = grFingerX.IdentifyPrepare(soureFingerprint, GrFingerXLib.GRConstants.GR_DEFAULT_CONTEXT)
        Return result
    End Function

    Public Function extractJSON(ByVal fingerImage As FingerImage) As Object
        Dim jsonString As String = grFingerX.ExtractJSON(fingerImage.rawImage, fingerImage.width, fingerImage.height, fingerImage.res, GrFingerXLib.GRConstants.GR_DEFAULT_CONTEXT, GrFingerXLib.GRConstants.GR_DEFAULT_CONTEXT)

        Dim jsSerializer As New JavaScriptSerializer()
        Dim jsonObject As Object = jsSerializer.DeserializeObject(jsonString)
        Return jsonObject
    End Function

End Class
