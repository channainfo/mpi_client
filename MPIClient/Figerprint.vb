Imports MPIClient.DataAccess.Model
Imports System.Web.Script.Serialization

Public Class Figerprint
    Private Const STR_StatusFingerPlaced As String = "Status: scaning finger"
    Private Const STR_StatusUnplugged As String = "Status: Unplugged"
    Private Const STR_StatusReady As String = "Status: Ready"
    Dim fingerImage As FingerImage
    Dim fingerImage2 As FingerImage
    Dim fingerprintUtil As FingerprintUtil

    Private Sub AxGrFingerXCtrl1_SensorPlug(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_SensorPlugEvent) Handles grFingerXCtrl.SensorPlug
        Dim status As Integer = grFingerXCtrl.CapStartCapture(e.idSensor)
        labelStatus.Text = STR_StatusReady
    End Sub

    Private Sub Figerprint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fingerprintUtil = New FingerprintUtil(labelStatus, grFingerXCtrl)
        fingerprintUtil.initializeFigerprint()

        Dim genderComboItems As New List(Of GenderComboboxItem)
        genderComboItems.Add(New GenderComboboxItem(0, ""))
        genderComboItems.Add(New GenderComboboxItem(Patient.GenderEnum.Male, Patient.GenderEnum.Male.ToString()))
        genderComboItems.Add(New GenderComboboxItem(Patient.GenderEnum.Female, Patient.GenderEnum.Female.ToString()))

        genderCombobox.DisplayMember = "genderText"
        genderCombobox.ValueMember = "gender"

        genderCombobox.DataSource = genderComboItems



    End Sub

    Private Sub Figerprint_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        fingerprintUtil.disposeFingerprint()

    End Sub

    Private Sub grFingerXCtrl_SensorUnplug(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_SensorUnplugEvent) Handles grFingerXCtrl.SensorUnplug
        Dim status As Integer = grFingerXCtrl.CapStopCapture(e.idSensor)
        labelStatus.Text = STR_StatusUnplugged
    End Sub

    Private Sub grFingerXCtrl_FingerDown(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_FingerDownEvent) Handles grFingerXCtrl.FingerDown
        labelStatus.Text = STR_StatusFingerPlaced

    End Sub

    Private Sub grFingerXCtrl_FingerUp(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_FingerUpEvent) Handles grFingerXCtrl.FingerUp
        labelStatus.Text = STR_StatusReady
    End Sub

    Private Sub grFingerXCtrl_ImageAcquired(ByVal sender As System.Object, ByVal e As AxGrFingerXLib._IGrFingerXCtrlEvents_ImageAcquiredEvent) Handles grFingerXCtrl.ImageAcquired

        If pictureFringerprint1.BorderStyle = BorderStyle.FixedSingle Then
            fingerImage = fingerprintUtil.captureImage(e)
        Else
            fingerImage2 = fingerprintUtil.captureImage(e)
        End If
        
        If Not (fingerImage Is Nothing) Then
            pictureFingerprint.Image = fingerImage.img
            pictureFingerprint.Update()

            Dim selectedFingerprint As PictureBox = getSelectedFingerprint()
            selectedFingerprint.Image = fingerImage.img
            selectedFingerprint.Update()

        End If
    End Sub

    Private Function getSelectedFingerprint() As PictureBox
        If pictureFringerprint1.BorderStyle = BorderStyle.FixedSingle Then
            Return pictureFringerprint1
        Else
            Return pictureFringerprint2
        End If
    End Function
    Private Sub SearchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchButton.Click

        If fingerImage Is Nothing Or fingerImage2 Is Nothing Or genderCombobox.SelectedText = "" Then
            Return
        End If
        'Dim jsSerializer As New JavaScriptSerializer()
        'Dim patients As List(Of Patient)
        'Dim jsonString As String = "[{""id"":""5065314132dae"",""gender"":""male"",""datebirth"":""01/01/2012"",""visits"":[]}]"
        'patients = jsSerializer.Deserialize(Of List(Of Patient))(jsonString)
        'MessageBox.Show(patients.Count)
        indentifyPatient()

    End Sub
    Private Sub indentifyPatient()
        Dim patient As Patient = preparePatient()

        If Not patient.Fingerprint Is Nothing Then
            Me.Hide()
            showSearchResultForm(patient)
        Else
            MessageBox.Show("Invalid Format")
        End If
    End Sub
    Private Sub showSearchResultForm(ByVal patient As Patient)
        Dim searchResultForm As New SearchResult
        searchResultForm.setFingerImage(fingerImage)
        searchResultForm.SetFingerImage2(fingerImage2)
        searchResultForm.setPatient(Patient)
        searchResultForm.setFilgerprintUtil(fingerprintUtil)
        searchResultForm.ShowDialog(Me)
    End Sub
    Private Function preparePatient() As Patient
        Dim patient As New Patient
        patient.Fingerprint = fingerprintUtil.extractFingerprint(fingerImage)
        patient.Fingerprint2 = fingerprintUtil.extractFingerprint(fingerImage2)
        patient.Gender = genderCombobox.SelectedValue
        Return patient
    End Function

    Private Sub closeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles closeButton.Click
        Me.Close()
    End Sub

    Private Sub SynchronizationButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SynchronizationButton.Click
        Dim synChronization As New Synchronization
        synChronization.ShowDialog(Me)
    End Sub

    Private Sub pictureFringerprint2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pictureFringerprint2.Click
        pictureFringerprint2.BorderStyle = BorderStyle.FixedSingle
        pictureFringerprint1.BorderStyle = BorderStyle.None
        pictureFingerprint.Image = pictureFringerprint2.Image
        pictureFingerprint.Update()
    End Sub

    Private Sub pictureFringerprint1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pictureFringerprint1.Click
        pictureFringerprint1.BorderStyle = BorderStyle.FixedSingle
        pictureFringerprint2.BorderStyle = BorderStyle.None
        pictureFingerprint.Image = pictureFringerprint1.Image
        pictureFingerprint.Update()
    End Sub
End Class
