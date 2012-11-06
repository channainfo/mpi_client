Imports MPIClient.DataAccess.Model
Imports MPIClient.DataAccess.DAO
Imports System.Web.Script.Serialization
Imports System.Text

Public Class ManualSyn
    Dim currentPatient As Patient
    Dim matchedPatients As List(Of Patient)


    Friend Sub SetCurrentPatient(ByVal currentPatient As Patient)
        Me.currentPatient = currentPatient
    End Sub
    Friend Sub SetMatchedPatients(ByVal matchedPatients As List(Of Patient))
        Me.matchedPatients = matchedPatients
    End Sub
    Private Sub ManualSyn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = matchedPatients

        updatePatientProfile()

    End Sub

    Private Sub uploadLoadValuesCompleted(ByVal sender As Object, ByVal e As System.Net.UploadValuesCompletedEventArgs)

        Dim jsonString As String = Encoding.UTF8.GetString(e.Result)
        Dim jsonResult As Object = Nothing
        Dim jsSerializer As New JavaScriptSerializer()

        jsonResult = jsSerializer.DeserializeObject(jsonString)
        Dim patients As New List(Of Patient)
        Dim patientDAO As New PatientDAO
        patients.AddRange(GeneralUtil.getPatientFromJSONObject(jsonResult))

        If patients.Count > 0 Then
            Dim status = patientDAO.Update(currentPatient.PatientID, patients(0))
            If status > 0 Then
                MessageBox.Show("Successful.")
            Else
                MessageBox.Show("Fail.")
            End If
        End If
    End Sub

    Private Sub updatePatientProfile()
        patientIDLabel.Text = currentPatient.PatientID
        dateOfBirthLabel.Text = currentPatient.DateBirth
        genderLabel.Text = currentPatient.Gender
    End Sub

    Private Sub synchronizationButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles synchronizationButton.Click
        Dim webRequestClass = New WebRequestClass
        Dim patientID As String
        Dim selectedPatientToSyn As Patient = DataGridView1.SelectedRows(0).DataBoundItem
        patientID = selectedPatientToSyn.PatientID
        webRequestClass.synPatientWithPatientID(currentPatient, patientID, AddressOf uploadLoadValuesCompleted)
    End Sub
End Class