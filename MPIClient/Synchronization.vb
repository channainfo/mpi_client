﻿Imports MPIClient.DataAccess.Model
Imports MPIClient.DataAccess.DAO
Imports MPIClient.DataAccess
Imports System.Threading
Imports System.Text
Imports System.Web.Script.Serialization

Public Class Synchronization
    Dim numberOfSyn As Integer
    Dim numberOfSynLeft As Integer
    Dim patientDAO As New PatientDAO
    Dim nonSynPatients As New List(Of Patient)()
    Dim workerThread As Thread
    Dim matchedPatients As New List(Of Patient)
    Enum ProgressStatus
        Starting
        ContainError
        Processing
        Completed
        ManualSyn
    End Enum

    Private Sub Synchronization_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        numberOfSyn = Convert.ToInt16(ConfigManager.GetConfiguarationValue("NumberOfSyn"))
        numberOfSynLeft = numberOfSyn
        fillPatientListWithNonSynData()
        updateGridView()
    End Sub
    Private Sub fillPatientListWithNonSynData()
        nonSynPatients.AddRange(patientDAO.getAll(DataAccess.DAO.PatientDAO.Synchronization.NonSyn))
    End Sub
    Private Sub updateGridView()
        DataGridView1.DataSource = nonSynPatients
    End Sub

    Private Sub synchronizationButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles synchronizationButton.Click
        synchronizationWorker.RunWorkerAsync()

    End Sub

    Private Sub synchronizationWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles synchronizationWorker.DoWork

        Dim webRequestClass = New WebRequestClass
        workerThread = Thread.CurrentThread
        For index As Integer = 0 To DataGridView1.Rows.Count - 1
            If numberOfSynLeft > 0 Then
                updateProgressStatus(ProgressStatus.Starting, index)
                numberOfSynLeft = numberOfSynLeft - 1
            Else
                workerThread.Suspend()
            End If
            webRequestClass.synPatient(nonSynPatients(index), AddressOf uploadLoadValuesCompleted, index)
        Next

    End Sub

    Private Sub synchronizationWorker_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles synchronizationWorker.RunWorkerCompleted

        MessageBox.Show("Finish.")

    End Sub

    Private Sub updateProgressStatus(ByVal status As ProgressStatus, ByVal index As Integer, Optional ByVal numOfRecords As Int16 = 0)
        If status = ProgressStatus.Starting Then
            DataGridView1.Rows(index).Cells(5).Value = "Synchronizing."
        ElseIf status = ProgressStatus.Processing Then
            DataGridView1.Rows(index).Cells(5).Value += "."
        ElseIf status = ProgressStatus.Completed Then
            DataGridView1.Rows(index).Cells(5).Value = "Completed."
        ElseIf status = ProgressStatus.ContainError Then
            DataGridView1.Rows(index).Cells(5).Value = "Error."
        ElseIf status = ProgressStatus.ManualSyn Then
            DataGridView1.Rows(index).Cells(5) = New DataGridViewLinkCell()
            DataGridView1.Rows(index).Cells(5).Value = numOfRecords + " records found"
        End If
    End Sub

    Private Sub uploadLoadValuesCompleted(ByVal sender As Object, ByVal e As System.Net.UploadValuesCompletedEventArgs)
        numberOfSynLeft = numberOfSynLeft + 1

        Dim itemIndex As Integer = e.UserState
        Dim currentPatient As Patient = DataGridView1.Rows(itemIndex).DataBoundItem

        Dim jsonString As String = Encoding.UTF8.GetString(e.Result)
        Dim jsonResult As Object = Nothing
        Dim jsSerializer As New JavaScriptSerializer()

        If e.Error Is Nothing Then
            updateProgressStatus(ProgressStatus.ContainError, itemIndex)
            Return
        End If

        jsonResult = jsSerializer.DeserializeObject(jsonString)

        matchedPatients.AddRange(GeneralUtil.getPatientFromJSONObject(jsonResult))

        If matchedPatients.Count = 1 Then
            Dim status = patientDAO.Update(currentPatient.PatientID, matchedPatients(0))
            If status > 0 Then
                updateProgressStatus(ProgressStatus.Completed, itemIndex)
            Else
                updateProgressStatus(ProgressStatus.ContainError, itemIndex)
            End If
        ElseIf matchedPatients.Count > 1 Then
            updateProgressStatus(ProgressStatus.ManualSyn, itemIndex, matchedPatients.Count)
        Else
            updateProgressStatus(ProgressStatus.ContainError, itemIndex)
        End If


        'updateProgressStatus(ProgressStatus.Completed, 0)
        If Not workerThread.IsAlive Then
            workerThread.Resume()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim currentPatient As Patient = DataGridView1.Rows(e.RowIndex).DataBoundItem
        If TypeOf sender Is DataGridViewLinkCell Then
            showManualSynForm(currentPatient)
        End If
    End Sub
    Private Sub showManualSynForm(ByVal currentPatient As Patient)
        Dim manualSyn As New ManualSyn
        manualSyn.SetCurrentPatient(currentPatient)
        manualSyn.SetMatchedPatients(matchedPatients)
        manualSyn.ShowDialog(Me)
    End Sub
End Class