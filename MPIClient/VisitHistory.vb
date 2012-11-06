Imports MPIClient.DataAccess.Model
Imports MPIClient.DataAccess.DAO
Public Class VisitHistory
    Dim patient As Patient
    Dim visitDAO As New VisitDAO
    Public Sub setPatient(ByVal patientObject As Patient)
        patient = patientObject
    End Sub


    Private Sub VisitHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If patient Is Nothing Then
            Return
        End If

        If patient.Visits Is Nothing Then
            patient.Visits = visitDAO.getAll(patient.PatientID)
        End If
        updatePatientProfile()
        updateVisitDataGrid()

    End Sub
    Private Sub updatePatientProfile()
        patientIDLabel.Text = patient.PatientID
        dateOfBirthLabel.Text = patient.DateBirth
        genderLabel.Text = patient.Gender
    End Sub
    Private Sub updateVisitDataGrid()
        visitDataGrid.DataSource = patient.Visits
    End Sub

    Private Sub closeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles closeButton.Click
        Me.Close()
    End Sub

    Private Sub VisitHistory_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Owner.Show()
    End Sub
End Class