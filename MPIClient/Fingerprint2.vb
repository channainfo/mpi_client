Imports MPIClient.DataAccess.Model

Public Class Fingerprint2

    Private Const STR_StatusFingerPlaced As String = "Status: scaning finger"
    Private Const STR_StatusUnplugged As String = "Status: Unplugged"
    Private Const STR_StatusReady As String = "Status: Ready"
    Public Const STR_IMAGE_BAD_QUALITY = "Bad"
    Public Const STR_IMAGE_MEDIUM_QUALITY = "Medium"
    Public Const STR_IMAGE_HIGHT_QUALITY = "Hight"
    Public DEFAULT_FINGER As PictureBox
    Dim numberOfFingerScan As Integer = 0
    Dim numberOfBadQuality As Integer = 0
    Dim lastSelectedFinger As PictureBox
    Dim fingerprintUtil As FingerprintUtil
    Dim patient As Patient
    Private Sub Fingerprint2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fingerprintUtil = New FingerprintUtil(grFingerXCtrl)
        fingerprintUtil.initializeFigerprint()
        patient = New Patient
        DEFAULT_FINGER = finger2right
        DEFAULT_FINGER.BorderStyle = BorderStyle.FixedSingle

        lastSelectedFinger = DEFAULT_FINGER

        fillGenderComboItems()
    End Sub
    Private Sub fillGenderComboItems()
        Dim genderComboItems As New List(Of GenderComboboxItem)
        genderComboItems.Add(New GenderComboboxItem(0, ""))
        genderComboItems.Add(New GenderComboboxItem(Patient.GenderEnum.Male, Patient.GenderEnum.Male.ToString()))
        genderComboItems.Add(New GenderComboboxItem(Patient.GenderEnum.Female, Patient.GenderEnum.Female.ToString()))

        genderCombobox.DisplayMember = "genderText"
        genderCombobox.ValueMember = "gender"

        genderCombobox.DataSource = genderComboItems
    End Sub
    Private Sub grFingerXCtrl_FingerDown(ByVal sender As Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_FingerDownEvent) Handles grFingerXCtrl.FingerDown
        labelStatus.Text = STR_StatusFingerPlaced
    End Sub

    Private Sub grFingerXCtrl_FingerUp(ByVal sender As Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_FingerUpEvent) Handles grFingerXCtrl.FingerUp
        labelStatus.Text = STR_StatusReady
    End Sub

    Private Sub grFingerXCtrl_SensorPlug(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_SensorPlugEvent) Handles grFingerXCtrl.SensorPlug
        Dim status As Integer = grFingerXCtrl.CapStartCapture(e.idSensor)
        labelStatus.Text = STR_StatusReady
    End Sub

    Private Sub grFingerXCtrl_SensorUnplug(ByVal sender As Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_SensorUnplugEvent) Handles grFingerXCtrl.SensorUnplug
        Dim status As Integer = grFingerXCtrl.CapStopCapture(e.idSensor)
        labelStatus.Text = STR_StatusUnplugged
    End Sub

    Private Sub finger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles finger2right.Click, finger1right.Click, finger5right.Click, finger5left.Click, finger4right.Click, finger4left.Click, finger3right.Click, finger3left.Click, finger2left.Click, finger1Left.Click
        clearLastSelectedFingerFocus()

        Dim selectingFinger As PictureBox = getSelectingFinger(sender)
        pictureFingerprint.Image = selectingFinger.Image

    End Sub
    Private Sub finger_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles finger2right.MouseClick, finger5right.MouseClick, finger5left.MouseClick, finger4right.MouseClick, finger4left.MouseClick, finger3right.MouseClick, finger3left.MouseClick, finger2left.MouseClick, finger1right.MouseClick, finger1Left.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            clearLastSelectedFinger()
        End If

    End Sub
    Private Function getImageQaulity(ByVal status As Integer) As String
        If status = GrFingerXLib.GRConstants.GR_BAD_QUALITY Then
            Return STR_IMAGE_BAD_QUALITY
        ElseIf status = GrFingerXLib.GRConstants.GR_MEDIUM_QUALITY Then
            Return STR_IMAGE_MEDIUM_QUALITY
        ElseIf status = GrFingerXLib.GRConstants.GR_HIGH_QUALITY Then
            Return STR_IMAGE_HIGHT_QUALITY
        Else
            Return ""
        End If
    End Function
    Private Function getSelectingFinger(ByVal sender As Object) As PictureBox
        Dim selectingFinger As PictureBox = CType(sender, PictureBox)

        selectingFinger.BorderStyle = BorderStyle.FixedSingle
        lastSelectedFinger = selectingFinger
        Return selectingFinger
    End Function
    Private Sub clearLastSelectedFingerFocus()
        'clear bother style if no image in lastSelectedFinger
        If lastSelectedFinger.Image Is Nothing Then
            lastSelectedFinger.BorderStyle = BorderStyle.None
        End If
    End Sub
    Private Sub grFingerXCtrl_ImageAcquired(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_ImageAcquiredEvent) Handles grFingerXCtrl.ImageAcquired
        Dim status As Integer
        Dim fingerImage As FingerImage = fingerprintUtil.captureImage(e, status)

        'fingerprintQuality1.Text = getImageQaulity(status)
        pictureFingerprint.Image = fingerImage.img

        Dim fingerPrint As Array = fingerprintUtil.extractFingerprint(fingerImage, status)
        Dim imageQuality As String = getImageQaulity(status)
        setPatientFingerPrint(fingerPrint, imageQuality, fingerImage.img)
    End Sub

    Private Sub setPatientFingerPrint(ByVal fingerPrint As Array, ByVal imageQuality As String, Optional ByVal image As Image = Nothing)
        Dim previousQuality As String = ""
        If fingerPrint Is Nothing Then
            If Not lastSelectedFinger.Image Is Nothing Then
                numberOfFingerScan = numberOfFingerScan - 1
            End If
            lastSelectedFinger.Image = Nothing
            lastSelectedFinger.BorderStyle = BorderStyle.None
        Else
            If lastSelectedFinger.Image Is Nothing Then
                numberOfFingerScan = numberOfFingerScan + 1
            End If
            lastSelectedFinger.Image = image
            lastSelectedFinger.BorderStyle = BorderStyle.FixedSingle
        End If


        Select Case lastSelectedFinger.Name

            Case finger1right.Name
                patient.Fingerprint_r1 = fingerPrint
                previousQuality = quality1right.Text
                'If quality1right.Text = STR_IMAGE_BAD_QUALITY And imageQuality = "" Then
                '    numberOfBadQuality = numberOfBadQuality - 1
                'End If
                quality1right.Text = imageQuality
            Case finger2right.Name
                previousQuality = quality2right.Text
                patient.Fingerprint_r2 = fingerPrint
                'If quality2right.Text = STR_IMAGE_BAD_QUALITY And imageQuality = "" Then
                '    numberOfBadQuality = numberOfBadQuality - 1
                'End If
                quality2right.Text = imageQuality
            Case finger3right.Name
                previousQuality = quality3right.Text
                patient.Fingerprint_r3 = fingerPrint
                'If quality3right.Text = STR_IMAGE_BAD_QUALITY And imageQuality = "" Then
                '    numberOfBadQuality = numberOfBadQuality - 1
                'End If
                quality3right.Text = imageQuality
            Case finger4right.Name
                previousQuality = quality4right.Text
                patient.Fingerprint_r4 = fingerPrint
                'If quality4right.Text = STR_IMAGE_BAD_QUALITY And imageQuality = "" Then
                '    numberOfBadQuality = numberOfBadQuality - 1
                'End If
                quality4right.Text = imageQuality
            Case finger5right.Name
                previousQuality = quality5right.Text
                patient.Fingerprint_r5 = fingerPrint
                'If quality5right.Text = STR_IMAGE_BAD_QUALITY And imageQuality = "" Then
                '    numberOfBadQuality = numberOfBadQuality - 1
                'End If
                quality5right.Text = imageQuality
            Case finger1Left.Name
                previousQuality = quality1Left.Text
                patient.Fingerprint_l1 = fingerPrint
                'If quality1Left.Text = STR_IMAGE_BAD_QUALITY And imageQuality = "" Then
                '    numberOfBadQuality = numberOfBadQuality - 1
                'End If
                quality1Left.Text = imageQuality
            Case finger2left.Name
                previousQuality = quality2left.Text
                patient.Fingerprint_l2 = fingerPrint
                'If quality2left.Text = STR_IMAGE_BAD_QUALITY And imageQuality = "" Then
                '    numberOfBadQuality = numberOfBadQuality - 1
                'End If
                quality2left.Text = imageQuality
            Case finger3left.Name
                previousQuality = quality3left.Text
                patient.Fingerprint_l3 = fingerPrint
                'If quality3left.Text = STR_IMAGE_BAD_QUALITY And imageQuality = "" Then
                '    numberOfBadQuality = numberOfBadQuality - 1
                'End If
                quality3left.Text = imageQuality
            Case finger4left.Name
                previousQuality = quality4left.Text
                patient.Fingerprint_l4 = fingerPrint
                'If quality4left.Text = STR_IMAGE_BAD_QUALITY And imageQuality = "" Then
                '    numberOfBadQuality = numberOfBadQuality - 1
                'End If
                quality4left.Text = imageQuality
            Case finger5left.Name
                previousQuality = quality4left.Text
                patient.Fingerprint_l5 = fingerPrint
                'If quality5left.Text = STR_IMAGE_BAD_QUALITY And imageQuality = "" Then
                '    numberOfBadQuality = numberOfBadQuality - 1
                'End If
                quality5left.Text = imageQuality
            Case Else

        End Select

        If (lastSelectedFinger.Image Is Nothing And imageQuality = STR_IMAGE_BAD_QUALITY) Or _
            (Not lastSelectedFinger.Image Is Nothing And previousQuality <> STR_IMAGE_BAD_QUALITY And _
             imageQuality = STR_IMAGE_BAD_QUALITY) Then
            numberOfBadQuality = numberOfBadQuality + 1
        ElseIf (fingerPrint Is Nothing And previousQuality = STR_IMAGE_BAD_QUALITY) Or _
            (Not fingerPrint Is Nothing And previousQuality = STR_IMAGE_BAD_QUALITY And _
             imageQuality <> STR_IMAGE_BAD_QUALITY) Then
            numberOfBadQuality = numberOfBadQuality - 1
        End If


    End Sub
    Private Sub Fingerprint2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = 46 Then
            clearLastSelectedFinger()
        End If
    End Sub

    Private Sub clearLastSelectedFinger()
        pictureFingerprint.Image = Nothing
        setPatientFingerPrint(Nothing, "")
    End Sub
    Private Sub SearchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchButton.Click

        Dim validationErrMessage As String = ""

        If numberOfFingerScan < 1 Then
            validationErrMessage = validationErrMessage + "- One fingerprint is required." + vbCrLf
        End If

        If numberOfBadQuality > 0 Then
            validationErrMessage = validationErrMessage + "- Some fingerprints are in bad quality (Medium to hight quality is required)." + vbCrLf
        End If

        If genderCombobox.SelectedValue = 0 Then
            validationErrMessage = validationErrMessage + "- Gender must be selected." + vbCrLf
        End If

        If isDuplicateFingerprints() Then
            validationErrMessage = validationErrMessage + "- Some fingerprints are the same." + vbCrLf
        End If

        isDuplicateFingerprints()
        patient.Gender = genderCombobox.SelectedValue
        If validationErrMessage = "" Then
            Me.Hide()
            showSearchResultForm(patient)
        Else
            MessageBox.Show(validationErrMessage, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub
    Private Function isDuplicateFingerprints() As Boolean
        Dim fingerprintsInPriority As List(Of Array) = patient.getFingerprintsInPriority()
        If fingerprintsInPriority.Count > 1 Then
            fingerprintUtil.setSourceFingerprint(fingerprintsInPriority(0))

            For index As Integer = 1 To fingerprintsInPriority.Count - 1
                If fingerprintUtil.indentifyFingerprint(fingerprintsInPriority(index), Nothing) Then
                    Return True
                End If
            Next

        End If
        Return False
    End Function
    Private Sub showSearchResultForm(ByVal patient As Patient)
        Dim searchResultForm As New SearchResult2
        searchResultForm.setPatient(Patient)
        searchResultForm.setFilgerprintUtil(fingerprintUtil)
        searchResultForm.SetGrFingerX(grFingerXCtrl)
        searchResultForm.ShowDialog(Me)
    End Sub


    Private Sub SynchronizationButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SynchronizationButton.Click
        Dim synChronization As New Synchronization
        synChronization.ShowDialog(Me)
    End Sub

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click
        If (MessageBox.Show("Are you sure you want to exit?", "Action Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
            Me.Close()
        End If
    End Sub

    Private Sub genderCombobox_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles genderCombobox.KeyDown
        If e.KeyValue = 46 Then
            clearLastSelectedFinger()
        End If
    End Sub
End Class