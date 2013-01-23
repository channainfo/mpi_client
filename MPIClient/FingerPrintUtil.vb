Imports System.Web.Script.Serialization
Imports GrFingerXLib
Imports MPIClient.DataAccess.Model

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
    Dim grFingerX As AxGrFingerXLib.AxGrFingerXCtrl

    ' Raw image data type.
    Public Sub New(ByVal grFingerX As AxGrFingerXLib.AxGrFingerXCtrl)
        Me.grFingerX = grFingerX
    End Sub

    Public Function initializeFigerprint() As Integer
        Dim status As Integer = grFingerX.Initialize
        If status < 0 Then
            Return status
        End If
        Return grFingerX.CapInitialize
    End Function
    Public Function getErrorMessage(ByVal errorCode As Integer) As String
        Dim errorMessage As String = ""
        Select Case errorCode
            Case GRConstants.GR_ERROR_INITIALIZE_FAIL
                errorCode = ("Fail to Initialize GrFingerX. (Error:" & errorCode & ")")
            Case GRConstants.GR_ERROR_NOT_INITIALIZED
                errorCode = ("The GrFingerX Library is not initialized. (Error:" & errorCode & ")")
            Case GRConstants.GR_ERROR_FAIL_LICENSE_READ
                errorCode = ("License not found. See manual for troubleshooting. (Error:" & errorCode & ")")
                MessageBox.Show("License not found. See manual for troubleshooting.")
            Case GRConstants.GR_ERROR_NO_VALID_LICENSE
                errorCode = ("The license is not valid. See manual for troubleshooting. (Error:" & errorCode & ")")
                MessageBox.Show("The license is not valid. See manual for troubleshooting.")
            Case GRConstants.GR_ERROR_NULL_ARGUMENT
                errorCode = ("The parameter have a null value. (Error:" & errorCode & ")")
            Case GRConstants.GR_ERROR_FAIL
                errorCode = ("Fail to create a GDI object. (Error:" & errorCode & ")")
            Case GRConstants.GR_ERROR_ALLOC
                errorCode = ("Fail to create a context. Cannot allocate memory. (Error:" & errorCode & ")")
            Case GRConstants.GR_ERROR_PARAMETERS
                errorCode = ("One or more parameters are out of bound. (Error:" & errorCode & ")")
            Case GRConstants.GR_ERROR_WRONG_USE
                errorCode = ("This function cannot be called at this time. (Error:" & errorCode & ")")
            Case GRConstants.GR_ERROR_EXTRACT
                errorCode = ("Template Extraction failed. (Error:" & errorCode & ")")
            Case GRConstants.GR_ERROR_SIZE_OFF_RANGE
                errorCode = ("Image is too larger or too short.  (Error:" & errorCode & ")")
            Case GRConstants.GR_ERROR_RES_OFF_RANGE
                errorCode = ("Image have too low or too high resolution. (Error:" & errorCode & ")")
            Case GRConstants.GR_ERROR_CONTEXT_NOT_CREATED
                errorCode = ("The Context could not be created. (Error:" & errorCode & ")")
            Case GRConstants.GR_ERROR_INVALID_CONTEXT
                errorCode = ("The Context does not exist. (Error:" & errorCode & ")")

                ' Capture error codes

            Case GRConstants.GR_ERROR_CONNECT_SENSOR
                errorCode = ("Error while connection to sensor. (Error:" & errorCode & ")")
            Case GRConstants.GR_ERROR_CAPTURING
                errorCode = ("Error while capturing from sensor. (Error:" & errorCode & ")")
            Case GRConstants.GR_ERROR_CANCEL_CAPTURING
                errorCode = ("Error while stop capturing from sensor. (Error:" & errorCode & ")")
            Case GRConstants.GR_ERROR_INVALID_ID_SENSOR
                errorCode = ("The idSensor is invalid. (Error:" & errorCode & ")")
            Case GRConstants.GR_ERROR_SENSOR_NOT_CAPTURING
                errorCode = ("The sensor is not capturing. (Error:" & errorCode & ")")
            Case GRConstants.GR_ERROR_INVALID_EXT
                errorCode = ("The File have a unknown extension. (Error:" & errorCode & ")")
            Case GRConstants.GR_ERROR_INVALID_FILENAME
                errorCode = ("The filename is invalid. (Error:" & errorCode & ")")
            Case GRConstants.GR_ERROR_INVALID_FILETYPE
                errorCode = ("The file type is invalid. (Error:" & errorCode & ")")
            Case GRConstants.GR_ERROR_SENSOR
                errorCode = ("The sensor raise an error. (Error:" & errorCode & ")")
        End Select
    End Function
    Public Function captureImage(ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_ImageAcquiredEvent, Optional ByRef status As Integer = -1) As FingerImage
        Dim hdc As Integer = GetDC(0)
        Dim fingerImage As New FingerImage
        fingerImage.rawImage = e.rawImage
        fingerImage.width = e.width
        fingerImage.height = e.height
        fingerImage.res = e.res
        grFingerX.BiometricDisplay(extractFingerprint(fingerImage, status), fingerImage.rawImage, e.width, e.height, e.res, hdc, fingerImage.img, GrFingerXLib.GRConstants.GR_NO_CONTEXT)
        'grFingerX.CapRawImageToHandle(fingerImage.rawImage, e.width, e.height, hdc, fingerImage.img)
        Return fingerImage
    End Function
    Public Sub disposeFingerprint()
        grFingerX.Finalize()
        grFingerX.CapFinalize()
    End Sub
    Public Function extractFingerprint(ByVal fingerImage As FingerImage, Optional ByRef status As Integer = -1) As Array
        Dim templateSize As Integer = GRConstants.GR_MAX_SIZE_TEMPLATE
        Dim fingerprint(templateSize) As Byte
        status = grFingerX.Extract(fingerImage.rawImage, fingerImage.width, fingerImage.height, fingerImage.res, fingerprint, templateSize, GrFingerXLib.GRConstants.GR_DEFAULT_CONTEXT)

        Array.Resize(fingerprint, templateSize)
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
    Public Function getQueryFingerprintInPriority(ByVal sourcePatient As Patient, ByVal QueryPatient As Patient) As List(Of Array)
        Dim result As New List(Of Array)
        If Not sourcePatient.Fingerprint_r1 Is Nothing Then
            result.Add(QueryPatient.Fingerprint_r1)
        End If
        If Not sourcePatient.Fingerprint_l1 Is Nothing Then
            result.Add(QueryPatient.Fingerprint_l1)
        End If
        If Not sourcePatient.Fingerprint_r2 Is Nothing Then
            result.Add(QueryPatient.Fingerprint_r2)
        End If
        If Not sourcePatient.Fingerprint_l2 Is Nothing Then
            result.Add(QueryPatient.Fingerprint_l2)
        End If
        If Not sourcePatient.Fingerprint_r3 Is Nothing Then
            result.Add(QueryPatient.Fingerprint_r3)
        End If
        If Not sourcePatient.Fingerprint_l3 Is Nothing Then
            result.Add(QueryPatient.Fingerprint_l3)
        End If
        If Not sourcePatient.Fingerprint_r4 Is Nothing Then
            result.Add(QueryPatient.Fingerprint_r4)
        End If
        If Not sourcePatient.Fingerprint_l4 Is Nothing Then
            result.Add(QueryPatient.Fingerprint_l4)
        End If
        If Not sourcePatient.Fingerprint_r5 Is Nothing Then
            result.Add(QueryPatient.Fingerprint_r5)
        End If
        If Not sourcePatient.Fingerprint_l5 Is Nothing Then
            result.Add(QueryPatient.Fingerprint_l5)
        End If
        Return result
    End Function
    Public Function extractJSON(ByVal fingerImage As FingerImage) As Object
        Dim jsonString As String = grFingerX.ExtractJSON(fingerImage.rawImage, fingerImage.width, fingerImage.height, fingerImage.res, GrFingerXLib.GRConstants.GR_DEFAULT_CONTEXT, GrFingerXLib.GRConstants.GR_DEFAULT_CONTEXT)

        Dim jsSerializer As New JavaScriptSerializer()
        Dim jsonObject As Object = jsSerializer.DeserializeObject(jsonString)
        Return jsonObject
    End Function

    Function getTemplateBase64(ByVal fingerprint As Array) As String

        If fingerprint Is Nothing Then
            Return ""
        End If
        Dim temSize As Integer = fingerprint.Length
        'Dim tempTpt As Array = Array.CreateInstance(GetType(Byte), fingerprint.Length)
        Dim tt As Integer = GRConstants.GR_MAX_SIZE_TEMPLATE
        Dim encodedBuffer(tt) As Byte
        Try
            Dim retVal As Integer = grFingerX.EncodeBase64(fingerprint, temSize, encodedBuffer, tt)
        Catch e As Exception
            MessageBox.Show(e.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Array.Resize(encodedBuffer, tt)
        Dim template64 As String = System.Text.Encoding.UTF8.GetString(encodedBuffer)
        Return template64
    End Function

End Class

