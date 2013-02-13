Imports MPIClient.DataAccess.Model
Imports MPIClient.DataAccess.DAO
Public Class VisitHistory
    Dim patient As Patient
    Dim visitDAO As New VisitDAO
    Public Sub setPatient(ByVal patientObject As Patient)
        patient = patientObject
    End Sub


    Private Sub VisitHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GeneralUtil.setTopMostBaseOnAppConfig(Me)
        If patient Is Nothing Then
            Return
        End If

        If patient.Visits Is Nothing Then
            patient.Visits = visitDAO.getAll(patient.PatientID)
        End If
        updatePatientProfile()
        updateVisitDataGrid()
        scanGridRowAndDoHightlight()
    End Sub
    Private Sub scanGridRowAndDoHightlight()
        For Each row As DataGridViewRow In visitDataGrid.Rows
            highlightIfResultIsInPositive(row)
        Next
    End Sub
    Private Sub updatePatientProfile()
        patientIDLabel.Text = patient.PatientID
        dateOfBirthLabel.Text = patient.DateBirth
        genderLabel.Text = patient.GenderText
    End Sub
    Private Sub updateVisitDataGrid()
        visitDataGrid.DataSource = patient.Visits
    End Sub

    Private Sub closeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub VisitHistory_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Owner.Show()
    End Sub

    Private Sub visitDataGrid_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles visitDataGrid.RowsAdded
        Dim row As DataGridViewRow = visitDataGrid.Rows(e.RowIndex)
        GeneralUtil.formatDateOfDataGridRow(row, "dd/MM/yyyy hh:mm:ss tt", 3)
    End Sub
    Private Shared Sub highlightIfResultIsInPositive(ByRef row As DataGridViewRow)
        Dim visit As Visit = row.DataBoundItem
        If visit.Info.Equals("positive", StringComparison.InvariantCultureIgnoreCase) And visit.ServiceID = visit.Service.VCCT Then
            row.DefaultCellStyle.BackColor = Color.Red
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub
End Class