Imports MPIClient.DataAccess.Model
Imports MPIClient.DataAccess.DAO
Imports MPIClient.DataAccess
Imports System.Threading
Imports System.Text
Imports System.Web.Script.Serialization

Public Class Synchronization
    Private Const STATUS_COMPLETED As String = "Completed."
    Dim numberOfSyn As Integer
    Dim numberOfSynLeft As Integer
    Dim patientDAO As New PatientDAO
    Dim visitDAO As New VisitDAO
    Dim nonSynPatients As New List(Of Patient)()
    Dim workerThread As Thread
    Dim patients As New List(Of Patient)
    Public Const PATIENT_ID_COL_IDEX As Integer = 0
    Public Const STATUS_COL_IDEX As Integer = 5
    Public Const CANCEL As String = "Cancel"
    Dim synButtonCaption As String
    Enum ProgressStatus
        Starting
        ContainError
        Processing
        Completed
        ManualSyn
    End Enum

    Private Sub Synchronization_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        synButtonCaption = synchronizationButton.Text
        numberOfSyn = Convert.ToInt16(ConfigManager.GetConfiguarationValue("NumberOfSyn"))
        numberOfSynLeft = numberOfSyn
        fillPatientListWithNonSynData()
        updateGridView()
        If DataGridView1.Rows.Count = 0 Then
            synchronizationButton.Enabled = False
        End If
    End Sub
    Private Sub fillPatientListWithNonSynData()
        nonSynPatients.AddRange(patientDAO.getAll(DataAccess.DAO.PatientDAO.Synchronization.NonSyn))
    End Sub
    Private Sub updateGridView()
        DataGridView1.DataSource = nonSynPatients
    End Sub

    Private Sub updateSynCaptionButtonBackToSyn()
        synchronizationButton.Text = synButtonCaption
        synchronizationButton.Tag = Nothing
        numberOfSynLeft = numberOfSyn
    End Sub
    Private Sub updateSynCaptionButtonToWait()
        synchronizationButton.Text = CANCEL
        synchronizationButton.Tag = CANCEL
    End Sub
    Private Sub synchronizationButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles synchronizationButton.Click

        If synchronizationButton.Tag = Nothing Then
            synchronizationWorker.RunWorkerAsync()
            updateSynCaptionButtonToWait()
        Else
            synchronizationWorker.CancelAsync()
            updateSynCaptionButtonBackToSyn()
        End If

    End Sub

    Private Sub synchronizationWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles synchronizationWorker.DoWork

        Dim webRequestClass = New WebRequestClass
        workerThread = Thread.CurrentThread
        For index As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(index).Cells(STATUS_COL_IDEX).Value = STATUS_COMPLETED Then
                Continue For
            End If
            If numberOfSynLeft > 0 Then
                updateProgressStatus(ProgressStatus.Starting, index)
                numberOfSynLeft = numberOfSynLeft - 1
                Dim currentPatient As Patient = nonSynPatients(index)
                webRequestClass.synPatient(preparePatientSynObject(currentPatient), AddressOf uploadProgressChange, AddressOf uploadLoadValuesCompleted, index)
            End If

            If numberOfSynLeft <= 0 Then
                workerThread.Suspend()
            End If

        Next
        If numberOfSynLeft = numberOfSyn Then
            updateSynCaptionButtonBackToSyn()
        End If
    End Sub
    Private Sub uploadLoadValuesCompleted(ByVal senders As Object, ByVal e As System.Net.UploadValuesCompletedEventArgs)



        numberOfSynLeft = numberOfSynLeft + 1
        If workerThread.ThreadState = 68 Or workerThread.ThreadState = ThreadState.Suspended Then
            workerThread.Resume()
        End If

        Dim itemIndex As Integer = e.UserState
        Dim patients As New List(Of Patient)
        If Not e.Error Is Nothing Then
            updateProgressStatus(ProgressStatus.ContainError, itemIndex, e.Error.Message)
            Return
        End If

        Dim currentPatient As Patient = DataGridView1.Rows(itemIndex).DataBoundItem

        Dim jsonResult As Object = serializeToJSONObject(e.Result)

        patients.AddRange(GeneralUtil.getPatientListFromJSONObject(jsonResult))

        If patients.Count = 1 Then
            Dim patient As Patient = patients(0)
            patient.Syn = True
            Dim status = patientDAO.Update(currentPatient.PatientID, patient)
            If status >= 0 Then
                updateProgressStatus(ProgressStatus.Completed, itemIndex)
                DataGridView1.Visible = False
                DataGridView1.Rows(itemIndex).Cells(PATIENT_ID_COL_IDEX).Value = patient.PatientID
                DataGridView1.Visible = True
            Else
                updateProgressStatus(ProgressStatus.ContainError, itemIndex, "Fail in synchronizing data in local database.")
            End If
        ElseIf patients.Count > 1 Then
            DataGridView1.Visible = False
            DataGridView1.Rows(itemIndex).Cells(STATUS_COL_IDEX).Tag = patients
            DataGridView1.Visible = True
            updateProgressStatus(ProgressStatus.ManualSyn, itemIndex, "", patients.Count)
        Else
            updateProgressStatus(ProgressStatus.ContainError, itemIndex, jsonResult("error"))
        End If

        DataGridView1.Visible = True
        'updateProgressStatus(ProgressStatus.Completed, 0)

    End Sub
    Private Function preparePatientSynObject(ByVal currentPatient As Patient) As PatientSyn
        Dim patientSyn As New PatientSyn
        Dim fingerprintUtil As New FingerprintUtil(grFingerXCtrl)
        patientSyn.patientid = currentPatient.PatientID
        patientSyn.fingerprint = fingerprintUtil.getTemplateBase64(currentPatient.Finger1Right)
        patientSyn.fingerprint2 = fingerprintUtil.getTemplateBase64(currentPatient.Finger2Right)
        patientSyn.gender = currentPatient.Gender
        patientSyn.datebirth = currentPatient.DateBirth


        patientSyn.createdate = DateTime.Parse(currentPatient.Createdate).ToString("yyyy-MM-dd HH:mm:ss")
        patientSyn.updatedate = DateTime.Parse(currentPatient.Updatedate).ToString("yyyy-MM-dd HH:mm:ss")
        currentPatient.Visits = visitDAO.getAll(currentPatient.PatientID)
        patientSyn.addVisits(currentPatient.Visits)
        Return patientSyn
    End Function
    Private Sub synchronizationWorker_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles synchronizationWorker.RunWorkerCompleted

        'MessageBox.Show("Finish.")

    End Sub
    Private Sub uploadProgressChange(ByVal sender As Object, ByVal e As System.Net.UploadProgressChangedEventArgs)
        Dim itemIndex As Integer = e.UserState

        updateProgressStatus(ProgressStatus.Processing, itemIndex)

    End Sub
    Private Sub updateProgressStatus(ByVal status As ProgressStatus, ByVal index As Integer, Optional ByVal errorMessage As String = "", Optional ByVal numOfRecords As Int16 = 0)
        If status = ProgressStatus.Starting Then
            DataGridView1.Rows(index).Cells(STATUS_COL_IDEX).Value = "Synchronizing."
            'DataGridView1.Rows(index).Cells(STATUS_COL_IDEX) = New DataGridViewImageCell()
            'DataGridView1.Rows(index).Cells(STATUS_COL_IDEX).Value = My.Resources.loading_icon
        ElseIf status = ProgressStatus.Processing Then
            DataGridView1.Rows(index).Cells(STATUS_COL_IDEX).Value += "."
        ElseIf status = ProgressStatus.Completed Then
            DataGridView1.Rows(index).Cells(STATUS_COL_IDEX).Value = STATUS_COMPLETED
        ElseIf status = ProgressStatus.ContainError Then
            Dim cell As DataGridViewLinkCell = New DataGridViewLinkCell()
            cell.Value = "Error."
            cell.ErrorText = errorMessage
            DataGridView1.Rows(index).Cells(STATUS_COL_IDEX) = cell
            'DataGridView1.Rows(index).Cells(STATUS_COL_IDEX).Value = "Error."
            'DataGridView1.Rows(index).Cells(STATUS_COL_IDEX).ErrorText = errorMessage
        ElseIf status = ProgressStatus.ManualSyn Then
            Dim cell As DataGridViewLinkCell = New DataGridViewLinkCell()
            Dim currentCell = DataGridView1.Rows(index).Cells(STATUS_COL_IDEX)
            cell.Tag = currentCell.Tag
            cell.Value = numOfRecords.ToString() + " records found"
            DataGridView1.Rows(index).Cells(STATUS_COL_IDEX) = cell
        End If
    End Sub

    Private Shared Function serializeToJSONObject(ByVal result As Byte()) As Object
        Dim jsonString As String = Encoding.UTF8.GetString(result)
        Dim jsonResult As Object = Nothing
        Dim jsSerializer As New JavaScriptSerializer()

        Try
            jsonResult = jsSerializer.DeserializeObject(jsonString)
        Catch ex As Exception

        End Try
        Return jsonResult
    End Function
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim dataGridItem As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        Dim currentPatient As Patient = dataGridItem.DataBoundItem
        Dim cell As DataGridViewCell = dataGridItem.Cells(STATUS_COL_IDEX)
        If Not TypeOf cell Is DataGridViewLinkCell Then
            Return
        End If
        If cell.ErrorText.Equals("") Then
            showManualSynForm(currentPatient, cell.Tag)
        Else
            MessageBox.Show(cell.ErrorText)
        End If
    End Sub
    Private Sub showManualSynForm(ByVal currentPatient As Patient, ByVal patients As List(Of Patient))
        Dim manualSyn As New ManualSyn
        manualSyn.SetCurrentPatient(currentPatient)
        manualSyn.SetMatchedPatients(patients)
        manualSyn.ShowDialog(Me)
    End Sub

    Private Sub DataGridView1_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting

    End Sub
End Class