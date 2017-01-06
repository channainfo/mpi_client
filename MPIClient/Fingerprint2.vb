Imports MPIClient.DataAccess.Model
Imports System.IO

Public Class Fingerprint2
    Private STR_Confirmation As String

    Private STR_StatusFingerPlaced As String
    Private STR_StatusUnplugged As String
    Private STR_StatusReady As String
    Private STR_FingerprintScannerIsUnplugged As String
    Private STR_FingerprintScannerInitializedSuccessfull As String
    Private STR_AreYouSureYouWantToExit As String
    Private STR_SomeFingerprintsAreTheSame As String
    Private STR_GenderMustBeSelected As String
    Private STR_SomeFingerprintsAreInBadQualityMediumToHightQual As String
    Private STR_OneFingerprintIsRequired As String
    Private STR_Warning As String
    Private STR_Information As String
    Private STR_Error As String
    Public STR_IMAGE_BAD_QUALITY As String
    Public STR_IMAGE_MEDIUM_QUALITY As String
    Public STR_IMAGE_HIGHT_QUALITY As String
    Public DEFAULT_FINGER As PictureBox
    Dim numberOfFingerScan As Integer = 0
    Dim numberOfBadQuality As Integer = 0
    Dim lastSelectedFinger As PictureBox
    Dim fingerprintUtil As FingerprintUtil
    Dim patient As Patient
    Dim idSensor As String = "File"
    Dim resourceManager As Resources.ResourceManager


    Private Sub Fingerprint2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GeneralUtil.setTopMostBaseOnAppConfig(Me)
        fingerprintUtil = New FingerprintUtil(grFingerXCtrl)
        fingerprintUtil.initializeFigerprint()
        resourceManager = New Resources.ResourceManager("MPIClient.LocalizedText", GetType(Fingerprint2).Assembly)

        setResourcesText()

        patient = New Patient

        setDefaultSelectedFinger()

        fillGenderComboItems()
        requestApplicationToken()

    End Sub
  Private Sub requestApplicationToken()
        Dim token = MpiAccessToken.getToken()
        Console.WriteLine("Access Token http:" + token)
    End Sub


    Private Sub setResourcesText()
        STR_StatusFingerPlaced = resourceManager.GetString("STR_StatusFingerPlaced")
        STR_StatusUnplugged = resourceManager.GetString("STR_StatusUnplugged")
        STR_StatusReady = resourceManager.GetString("STR_StatusReady")
        STR_FingerprintScannerIsUnplugged = resourceManager.GetString("STR_FingerprintScannerIsUnplugged")
        STR_FingerprintScannerInitializedSuccessfull = resourceManager.GetString("STR_FingerprintScannerInitializedSuccessfull")
        STR_AreYouSureYouWantToExit = resourceManager.GetString("STR_AreYouSureYouWantToExit")
        STR_SomeFingerprintsAreTheSame = resourceManager.GetString("STR_SomeFingerprintsAreTheSame")
        STR_GenderMustBeSelected = resourceManager.GetString("STR_GenderMustBeSelected")
        STR_SomeFingerprintsAreInBadQualityMediumToHightQual = resourceManager.GetString("STR_SomeFingerprintsAreInBadQualityMediumToHightQual")
        STR_OneFingerprintIsRequired = resourceManager.GetString("STR_OneFingerprintIsRequired")
        STR_Warning = resourceManager.GetString("STR_Warning")
        STR_Information = resourceManager.GetString("STR_Information")
        STR_Confirmation = resourceManager.GetString("STR_Confirmation")
        STR_Error = resourceManager.GetString("STR_Error")
        STR_IMAGE_BAD_QUALITY = resourceManager.GetString("STR_IMAGE_BAD_QUALITY")
        STR_IMAGE_MEDIUM_QUALITY = resourceManager.GetString("STR_IMAGE_MEDIUM_QUALITY")
        STR_IMAGE_HIGHT_QUALITY = resourceManager.GetString("STR_IMAGE_HIGHT_QUALITY")
    End Sub
    Private Sub setDefaultSelectedFinger()
        DEFAULT_FINGER = finger2right
        DEFAULT_FINGER.BorderStyle = BorderStyle.FixedSingle
        lastSelectedFinger = DEFAULT_FINGER
        hightLightFinger(DEFAULT_FINGER)
    End Sub
    Private Sub hightLightFinger(ByVal finger As PictureBox)

        Select Case finger.Name
            Case finger1right.Name
                RightPalmPic.Image = My.Resources.RightF1
                LeftPalmPic.Image = My.Resources.left
            Case finger2right.Name
                RightPalmPic.Image = My.Resources.RightF2
                LeftPalmPic.Image = My.Resources.left
            Case finger3right.Name
                RightPalmPic.Image = My.Resources.RightF3
                LeftPalmPic.Image = My.Resources.left
            Case finger4right.Name
                RightPalmPic.Image = My.Resources.RightF4
                LeftPalmPic.Image = My.Resources.left
            Case finger5right.Name
                RightPalmPic.Image = My.Resources.RightF5
                LeftPalmPic.Image = My.Resources.left
            Case finger1Left.Name
                LeftPalmPic.Image = My.Resources.LeftF1
                RightPalmPic.Image = My.Resources.right
            Case finger2left.Name
                LeftPalmPic.Image = My.Resources.LeftF2
                RightPalmPic.Image = My.Resources.right
            Case finger3left.Name
                LeftPalmPic.Image = My.Resources.LeftF3
                RightPalmPic.Image = My.Resources.right
            Case finger4left.Name
                LeftPalmPic.Image = My.Resources.LeftF4
                RightPalmPic.Image = My.Resources.right
            Case finger5left.Name
                LeftPalmPic.Image = My.Resources.LeftF5
                RightPalmPic.Image = My.Resources.right
            Case Else

        End Select
    End Sub
    Private Sub fillGenderComboItems()
        Dim genderComboItems As New List(Of GenderComboboxItem)
        genderComboItems.Add(New GenderComboboxItem(0, ""))
        genderComboItems.Add(New GenderComboboxItem(patient.GenderEnum.Male, resourceManager.GetString("STR_MALE")))
        genderComboItems.Add(New GenderComboboxItem(patient.GenderEnum.Female, resourceManager.GetString("STR_FEMALE")))

        genderCombobox.DisplayMember = "genderText"
        genderCombobox.ValueMember = "gender"

        genderCombobox.DataSource = genderComboItems
    End Sub
    Private Sub grFingerXCtrl_FingerDown(ByVal sender As Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_FingerDownEvent) Handles grFingerXCtrl.FingerDown
        labelStatus.Text = STR_StatusFingerPlaced
    End Sub

    Private Sub grFingerXCtrl_FingerUp(ByVal sender As Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_FingerUpEvent) Handles grFingerXCtrl.FingerUp
        labelStatus.Text = STR_StatusReady
        labelStatus.ForeColor = Color.Green
    End Sub

    Private Sub grFingerXCtrl_SensorPlug(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_SensorPlugEvent) Handles grFingerXCtrl.SensorPlug
        Dim status As Integer = grFingerXCtrl.CapStartCapture(e.idSensor)
        If Not e.idSensor.Equals("File") Then
            labelStatus.Text = STR_StatusReady
            labelStatus.ForeColor = Color.Green
        End If
        idSensor = e.idSensor
    End Sub

    Private Sub grFingerXCtrl_SensorUnplug(ByVal sender As Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_SensorUnplugEvent) Handles grFingerXCtrl.SensorUnplug
        Dim status As Integer = grFingerXCtrl.CapStopCapture(e.idSensor)
        labelStatus.Text = STR_StatusUnplugged
        labelStatus.ForeColor = Color.Red
        idSensor = "File"
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

        checkToEnablesearchbutton()

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
                quality1right.Text = imageQuality
                hightLightFinger(finger1Left)
            Case finger2right.Name
                previousQuality = quality2right.Text
                patient.Fingerprint_r2 = fingerPrint
                quality2right.Text = imageQuality
                hightLightFinger(finger2left)
            Case finger3right.Name
                previousQuality = quality3right.Text
                patient.Fingerprint_r3 = fingerPrint
                quality3right.Text = imageQuality
                hightLightFinger(finger3left)
            Case finger4right.Name
                previousQuality = quality4right.Text
                patient.Fingerprint_r4 = fingerPrint
                quality4right.Text = imageQuality
                hightLightFinger(finger4left)
            Case finger5right.Name
                previousQuality = quality5right.Text
                patient.Fingerprint_r5 = fingerPrint
                quality5right.Text = imageQuality
                hightLightFinger(finger5left)
            Case finger1Left.Name
                previousQuality = quality1Left.Text
                patient.Fingerprint_l1 = fingerPrint
                quality1Left.Text = imageQuality
                hightLightFinger(finger2right)
            Case finger2left.Name
                previousQuality = quality2left.Text
                patient.Fingerprint_l2 = fingerPrint
                quality2left.Text = imageQuality
                hightLightFinger(finger3right)
            Case finger3left.Name
                previousQuality = quality3left.Text
                patient.Fingerprint_l3 = fingerPrint
                quality3left.Text = imageQuality
                hightLightFinger(finger4right)
            Case finger4left.Name
                previousQuality = quality4left.Text
                patient.Fingerprint_l4 = fingerPrint
                quality4left.Text = imageQuality
                hightLightFinger(finger5right)
            Case finger5left.Name
                previousQuality = quality4left.Text
                patient.Fingerprint_l5 = fingerPrint
                quality5left.Text = imageQuality
                hightLightFinger(finger5left)
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
        checkToEnablesearchbutton()
    End Sub
    Private Sub SearchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchButton.Click

        Dim validationErrMessage As String = ""

        isValidated(validationErrMessage)

        If isDuplicateFingerprints() Then
            validationErrMessage = validationErrMessage + STR_SomeFingerprintsAreTheSame + vbCrLf
        End If

        patient.Gender = genderCombobox.SelectedValue
        If validationErrMessage = "" Then
            Me.Hide()
            showSearchResultForm(patient)
        Else
            Dim customMsgBox As New CustomMessageBox()
            customMsgBox.display(validationErrMessage, STR_Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'MessageBox.Show(validationErrMessage, STR_Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub
    Private Function isValidated(Optional ByRef validationErrMessage As String = "")
        Dim result As Boolean = True
        If numberOfFingerScan < 1 Then
            validationErrMessage = validationErrMessage + STR_OneFingerprintIsRequired + vbCrLf
            result = False
        End If

        If numberOfBadQuality > 0 Then
            validationErrMessage = validationErrMessage + STR_SomeFingerprintsAreInBadQualityMediumToHightQual + vbCrLf
            result = False
        End If

        If genderCombobox.SelectedValue = 0 Then
            validationErrMessage = validationErrMessage + STR_GenderMustBeSelected + vbCrLf
            result = False
        End If

        Return result
    End Function
    Private Function isDuplicateFingerprints() As Boolean
        Dim fingerprintsInPriority As List(Of Array) = patient.getFingerprintsInPriority()
        If fingerprintsInPriority.Count > 1 Then

            For index1 As Integer = 0 To fingerprintsInPriority.Count - 1
                fingerprintUtil.setSourceFingerprint(fingerprintsInPriority(index1))
                For index As Integer = index1 + 1 To fingerprintsInPriority.Count - 1
                    If fingerprintUtil.indentifyFingerprint(fingerprintsInPriority(index), Nothing) Then
                        Return True
                    End If
                Next
            Next



        End If
        Return False
    End Function
    Private Sub showSearchResultForm(ByVal patient As Patient)
        Dim searchResultForm As New SearchResult2
        searchResultForm.setPatient(patient)
        searchResultForm.setFilgerprintUtil(fingerprintUtil)
        searchResultForm.SetGrFingerX(grFingerXCtrl)
        searchResultForm.ShowDialog(Me)
    End Sub


    Private Sub SynchronizationButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SynchronizationButton.Click
        Dim synChronization As New Synchronization
        synChronization.SetGrFingerX(grFingerXCtrl)
        synChronization.setFilgerprintUtil(fingerprintUtil)
        synChronization.ShowDialog(Me)
    End Sub

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    Private Sub genderCombobox_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles genderCombobox.KeyDown
        If e.KeyValue = 46 Then
            clearLastSelectedFinger()
        End If
    End Sub

    Private Sub removeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles removeButton.Click
        clearLastSelectedFinger()
    End Sub

    Private Sub clearAllButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clearAllButton.Click

        numberOfBadQuality = 0
        numberOfFingerScan = 0

        patient.Fingerprint_l1 = Nothing
        patient.Fingerprint_l2 = Nothing
        patient.Fingerprint_l3 = Nothing
        patient.Fingerprint_l4 = Nothing
        patient.Fingerprint_l5 = Nothing

        patient.Fingerprint_r1 = Nothing
        patient.Fingerprint_r2 = Nothing
        patient.Fingerprint_r3 = Nothing
        patient.Fingerprint_r4 = Nothing
        patient.Fingerprint_r5 = Nothing

        For Each ctl As Control In Me.Controls
            If ctl.Name.Contains("finger") And TypeOf (ctl) Is PictureBox Then
                Dim pic As PictureBox = CType(ctl, PictureBox)
                pic.Image = Nothing
                pic.BorderStyle = BorderStyle.None
            ElseIf ctl.Name.Contains("quality") And TypeOf (ctl) Is Label Then
                CType(ctl, Label).Text = ""
            ElseIf ctl.Name = pictureFingerprint.Name Then
                pictureFingerprint.Image = Nothing
            End If
        Next

        setDefaultSelectedFinger()

    End Sub

    Private Sub initializeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles initializeButton.Click
        fingerprintUtil.disposeFingerprint()
        Dim errorCode = fingerprintUtil.initializeFigerprint()
        If (Not idSensor.Equals("File")) Then
            If errorCode >= 0 Then
                Dim customMsgBox As New CustomMessageBox()
                customMsgBox.display(STR_FingerprintScannerInitializedSuccessfull, STR_Information, MessageBoxButtons.OK, MessageBoxIcon.Information)
                'MessageBox.Show(STR_FingerprintScannerInitializedSuccessfull, STR_Information, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Dim customMsgBox As New CustomMessageBox()
                CustomMessageBox.display(fingerprintUtil.getErrorMessage(errorCode), STR_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
                'MessageBox.Show(fingerprintUtil.getErrorMessage(errorCode), STR_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            Dim customMsgBox As New CustomMessageBox()
            customMsgBox.display(STR_FingerprintScannerIsUnplugged)
            'MessageBox.Show(STR_FingerprintScannerIsUnplugged)
            labelStatus.Text = STR_StatusUnplugged
        End If


    End Sub

    Private Sub genderCombobox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles genderCombobox.SelectedIndexChanged
        checkToEnablesearchbutton()
    End Sub
    Private Sub checkToEnablesearchbutton()
        If isValidated() Then
            SearchButton.Enabled = True
        Else
            SearchButton.Enabled = False
        End If
    End Sub

    Private Sub Fingerprint2_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        fingerprintUtil.disposeFingerprint()
    End Sub

    Private Sub Fingerprint2_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim customMsgBox = New CustomMessageBox()
        Dim dialogResult As DialogResult = customMsgBox.display(resourceManager.GetString("STR_AreYouSureYouWantToExit"), STR_Confirmation)
        If dialogResult = dialogResult.Cancel Then
            e.Cancel = True
        End If

        'If (MessageBox.Show(resourceManager.GetString("STR_AreYouSureYouWantToExit"), "Action Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel) Then
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        MessageBox.Show(MpiAccessToken.getToken())
    End Sub
End Class