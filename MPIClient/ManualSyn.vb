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

        Dim patientDAO As New PatientDAO
        Dim patient As Patient = GeneralUtil.getPatientFromJSONObject(jsonResult)

        If patient Is Nothing Then
            MessageBox.Show("Webserver: Internal server error.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        patient.Syn = True
        Dim status = patientDAO.Update(currentPatient.PatientID, patient)
        If status > 0 Then
            MessageBox.Show("Successful update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Fail in updating patient.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub updatePatientProfile()
        patientIDLabel.Text = currentPatient.PatientID
        dateOfBirthLabel.Text = currentPatient.DateBirth
        genderLabel.Text = currentPatient.GenderText
    End Sub

    Private Sub synchronizationButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles synchronizationButton.Click
        Dim webRequestClass = New WebRequestClass
        Dim selectedPatientToSyn As Patient = DataGridView1.SelectedRows(0).DataBoundItem
        selectedPatientToSyn.Syn = True
        Dim patientID As String = selectedPatientToSyn.PatientID
        webRequestClass.synPatientWithPatientID(Synchronization.preparePatientSynObject(currentPatient), patientID, AddressOf uploadLoadValuesCompleted)
        'Dim patientDAO As New PatientDAO
        'Dim result = patientDAO.Update(currentPatient.PatientID, selectedPatientToSyn)

        'If result > 0 Then
        '    MessageBox.Show("Successful update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Else
        '    MessageBox.Show("Fail in updating patient.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
    End Sub
End Class