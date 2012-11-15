Imports MPIClient.DataAccess.Model
Imports MPIClient.DataAccess.DAO

Public Class NewPatient
    Dim patient As Patient
    Dim patientDAO As New PatientDAO
    Dim fingerImage As FingerImage
    Dim fingerImage2 As FingerImage
    Enum Status
        Online
        Offline
        OnlineButServerError
    End Enum
    Friend Sub SetPatient(ByVal patient As Patient)
        Me.patient = patient
    End Sub
    Friend Sub SetFingerImage(ByVal fingerImage As FingerImage)
        Me.fingerImage = fingerImage
    End Sub
    Friend Sub SetFingerImage2(ByVal fingerImage2 As FingerImage)
        Me.fingerImage2 = fingerImage2
    End Sub
    Private Sub NewPatient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim genderComboItems As New List(Of GenderComboboxItem)
        genderComboItems.Add(New GenderComboboxItem(0, ""))
        genderComboItems.Add(New GenderComboboxItem(patient.GenderEnum.Male, patient.GenderEnum.Male.ToString()))
        genderComboItems.Add(New GenderComboboxItem(patient.GenderEnum.Female, patient.GenderEnum.Female.ToString()))

        genderCombobox.DisplayMember = "genderText"
        genderCombobox.ValueMember = "gender"

        genderCombobox.DataSource = genderComboItems
    End Sub

    Private Sub enrollButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles enrollButton.Click

        If genderCombobox.SelectedValue = 0 Then
            Return
        End If

        If (MessageBox.Show("Are you sure you want to enroll new patient?", "Enrollment Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK) Then
            Dim patientID As String = Nothing
            If patientDAO.Add(patient, patientID) > 0 Then
                updatePatientIDFromWebServiceCall(patientID)
                MessageBox.Show("Successfully save with PatientID = " + patientID)
            Else
                MessageBox.Show("Error while saving!!!")
            End If
        End If
    End Sub
    Private Function updatePatientIDFromWebServiceCall(ByRef patientID As String) As Boolean


        Dim result As Boolean = False
        Dim webRequest As New WebRequestClass
        Dim fingerprintUtil As New FingerprintUtil(grFingerXCtrl)
        Dim jsonObject As Object = webRequest.enroll(fingerprintUtil.extractJSON(fingerImage), fingerprintUtil.extractJSON(fingerImage2))

        If (jsonObject Is Nothing) Then
            updateConnectionStatus(Status.Offline)
        ElseIf jsonObject("error") = "" Then
            result = True
            updateConnectionStatus(Status.Online)
            Dim newPatientID As String
            newPatientID = jsonObject("patientid")
            If patientDAO.updatePatientID(patientID, newPatientID) > 0 Then
                patientID = newPatientID
            End If
        Else
            updateConnectionStatus(Status.OnlineButServerError, jsonObject("error"))
        End If

        Return result
    End Function
    Private Sub updateConnectionStatus(ByVal status As Status, Optional ByVal errorMessage As String = "")
        If status = status.Offline Then
            'Error connecting to WebServer. 
            infoLabel.Text = errorMessage + " Status: Offline"
        ElseIf status = SearchResult.Status.Online Then
            infoLabel.Text = "Status: Online"
        ElseIf status = SearchResult.Status.OnlineButServerError Then
            infoLabel.Text = String.Format("{0} Status: Server Error", errorMessage)
        End If
    End Sub
End Class