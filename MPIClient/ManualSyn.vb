Imports MPIClient.DataAccess.Model
Imports MPIClient.DataAccess.DAO
Imports System.Web.Script.Serialization
Imports System.Text

Public Class ManualSyn
    Private STR_SuccessfulUpdate As String
    Private STR_WebserverInternalServerError As String
    Private STR_FailInUpdatingPatient As String
    Private STR_Information As String
    Dim currentPatient As Patient
    Dim matchedPatients As List(Of Patient)
    Dim synchronization As Synchronization
    Dim resourceManager As Resources.ResourceManager
    Friend Sub SetCurrentPatient(ByVal currentPatient As Patient)
        Me.currentPatient = currentPatient
    End Sub
    Friend Sub SetMatchedPatients(ByVal matchedPatients As List(Of Patient))
        Me.matchedPatients = matchedPatients
    End Sub
    Private Sub ManualSyn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GeneralUtil.setTopMostBaseOnAppConfig(Me)
        resourceManager = New Resources.ResourceManager("MPIClient.LocalizedText", GetType(ManualSyn).Assembly)

        setResourcesText()

        DataGridView1.DataSource = matchedPatients
        synchronization = CType(Me.Owner, Synchronization)
        updatePatientProfile()

    End Sub

    Private Sub setResourcesText()
        STR_SuccessfulUpdate = resourceManager.GetString("STR_SuccessfulUpdate")
        STR_WebserverInternalServerError = resourceManager.GetString("STR_WebserverInternalServerError")
        STR_FailInUpdatingPatient = resourceManager.GetString("STR_FailInUpdatingPatient")
        STR_Information = resourceManager.GetString("STR_Information")
    End Sub
    Private Sub uploadLoadValuesCompleted(ByVal sender As Object, ByVal e As System.Net.UploadValuesCompletedEventArgs)

        Dim jsonString As String = Encoding.UTF8.GetString(e.Result)
        Dim jsonResult As Object = Nothing
        Dim jsSerializer As New JavaScriptSerializer()

        jsonResult = jsSerializer.DeserializeObject(jsonString)

        Dim patientDAO As New PatientDAO
        Dim patient As Patient = GeneralUtil.getPatientFromJSONObject(jsonResult)

        If patient Is Nothing Then
            Dim customMsgBox As New CustomMessageBox()
            customMsgBox.display(STR_WebserverInternalServerError, STR_Information, MessageBoxButtons.OK, MessageBoxIcon.Information)
            'MessageBox.Show(STR_WebserverInternalServerError, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        patient.Syn = True
        Dim status = patientDAO.Update(currentPatient.PatientID, patient)
        If status > 0 Then
            Dim customMsgBox As New CustomMessageBox()
            customMsgBox.display(STR_SuccessfulUpdate, STR_Information, MessageBoxButtons.OK, MessageBoxIcon.Information)
            'MessageBox.Show(STR_SuccessfulUpdate, STR_Information, MessageBoxButtons.OK, MessageBoxIcon.Information)
            synchronization.updateSelectedRowToCompleted()
            Me.Close()
        Else
            Dim customMsgBox As New CustomMessageBox()
            customMsgBox.display(STR_FailInUpdatingPatient, STR_Information, MessageBoxButtons.OK, MessageBoxIcon.Information)
            'MessageBox.Show(STR_FailInUpdatingPatient, STR_Information, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub updatePatientProfile()
        patientIDLabel.Text = currentPatient.PatientID
        dateOfBirthLabel.Text = currentPatient.DateBirth
        genderLabel.Text = currentPatient.GenderText
    End Sub

    Private Sub synchronizeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles synchronizeButton.Click
        Dim webRequestClass = New WebRequestClass
        Dim selectedPatientToSyn As Patient = DataGridView1.SelectedRows(0).DataBoundItem
        selectedPatientToSyn.Syn = True
        Dim patientID As String = selectedPatientToSyn.PatientID
        webRequestClass.synPatientWithPatientID(synchronization.preparePatientSynObject(currentPatient), patientID, AddressOf uploadLoadValuesCompleted)
        'Dim patientDAO As New PatientDAO
        'Dim result = patientDAO.Update(currentPatient.PatientID, selectedPatientToSyn)

        'If result > 0 Then
        '    MessageBox.Show("Successful update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Else
        '    MessageBox.Show("Fail in updating patient.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
    End Sub

    Private Sub closeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles closeButton.Click
        Me.Close()
    End Sub
End Class