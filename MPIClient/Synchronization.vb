Imports MPIClient.DataAccess.Model
Imports MPIClient.DataAccess.DAO
Imports MPIClient.DataAccess
Imports System.Threading
Imports System.Text
Imports System.Web.Script.Serialization

Public Class Synchronization
    Private Const STATUS_COMPLETED As String = "Completed."
    Private Const STATUS_Error As String = "Error."
    Private Const STATUS_Synchronizing As String = "Synchronizing."
    Private isCancel As Boolean
    Dim numberOfSyn As Integer
    Dim numberOfSynLeft As Integer

    Dim listOfSuccesfulSynPatients As New List(Of Patient)
    Dim listOfDuplicatedSynPatients As New List(Of Patient)
    Dim listOfErrSynPatients As New List(Of Patient)
    Dim listOfSynPatients As New List(Of Patient)

    Dim patientDAO As New PatientDAO
    Dim visitDAO As New VisitDAO
    Dim nonSynPatients As New List(Of Patient)()
    Dim workerThread As Thread
    Dim patients As New List(Of Patient)
    Dim fingerprintUtil As FingerprintUtil
    Dim grFingerX As AxGrFingerXLib.AxGrFingerXCtrl
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
        numberOfSyn = Convert.ToInt32(ConfigManager.GetConfiguarationValue("NumberOfSyn"))
        numberOfSynLeft = numberOfSyn
        fillPatientListWithNonSynData()
        updateGridView(nonSynPatients)
        If DataGridView1.Rows.Count = 0 Then
            synchronizationButton.Enabled = False
        End If
        updatePatientFoundLabel()
    End Sub
    Public Sub setFilgerprintUtil(ByVal fingerprintUtilObject As FingerprintUtil)
        fingerprintUtil = fingerprintUtilObject
    End Sub
    Friend Sub SetGrFingerX(ByVal grFingerX As AxGrFingerXLib.AxGrFingerXCtrl)
        Me.grFingerX = grFingerX
    End Sub
    Private Sub updatePatientFoundLabel()
        patientFoundLabel.Text = nonSynPatients.Count.ToString() + " patients found."
    End Sub
    Private Sub fillPatientListWithNonSynData()
        nonSynPatients.AddRange(patientDAO.getAll(DataAccess.DAO.PatientDAO.Synchronization.NonSyn))
    End Sub
    Private Sub updateGridView(ByVal datasource As List(Of Patient))
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = PatientBindingSource
        PatientBindingSource.DataSource = datasource
        DataGridView1.Refresh()
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
            isCancel = False
            resetList()
            resetLabelSummary()
            synchronizationWorker.RunWorkerAsync()
            updateSynCaptionButtonToWait()

        Else
            isCancel = True
        End If

    End Sub

    Private Sub resetLabelSummary()
        NumOfDuplicationLabel.Text = "0"
        NumOfErrorLabel.Text = "0"
        NumOfSuccessLabel.Text = "0"
        NumOfTotalSynLabel.Text = "0"
    End Sub
    Private Sub resetList()
        listOfDuplicatedSynPatients.Clear()
        listOfErrSynPatients.Clear()
        listOfSuccesfulSynPatients.Clear()
        listOfSynPatients.Clear()

    End Sub
    Private Sub synchronizationWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles synchronizationWorker.DoWork

        Dim webRequestClass = New WebRequestClass
        workerThread = Thread.CurrentThread
        For index As Integer = 0 To DataGridView1.Rows.Count - 1
            If isCancel = False Then
                If DataGridView1.Rows(index).Cells(STATUS_COL_IDEX).Value = STATUS_COMPLETED Then
                    Continue For
                End If
                If numberOfSynLeft > 0 Then
                    updateProgressStatus(ProgressStatus.Starting, index)
                    numberOfSynLeft = numberOfSynLeft - 1
                    Dim currentPatient As Patient = nonSynPatients(index)

                    'Add patient to a synchronization list
                    addPatientToSynchronizationList(currentPatient)

                    webRequestClass.synPatient(preparePatientSynObject(currentPatient), AddressOf uploadProgressChange, AddressOf uploadLoadValuesCompleted, index)

                End If

                If numberOfSynLeft <= 0 Then
                    workerThread.Suspend()
                End If
            Else
                updateSynCaptionButtonBackToSyn()
            End If
        Next
        If numberOfSynLeft = numberOfSyn Then
            updateSynCaptionButtonBackToSyn()
        End If

    End Sub
    Private Sub resumeWorkerThread()
        If workerThread.ThreadState = 68 Or workerThread.ThreadState = ThreadState.Suspended Then
            workerThread.Resume()
        End If
    End Sub
    Private Sub uploadLoadValuesCompleted(ByVal senders As Object, ByVal e As System.Net.UploadValuesCompletedEventArgs)
        Dim errorMessage As String
        numberOfSynLeft = numberOfSynLeft + 1
        resumeWorkerThread()

        Dim itemIndex As Integer = e.UserState
        Dim currentPatient As Patient = DataGridView1.Rows(itemIndex).DataBoundItem

        Dim patients As New List(Of Patient)
        If Not e.Error Is Nothing Then
            If e.Error.Message.Contains("The request was aborted: The request was canceled") Then
                errorMessage = "Can't connect to the server. You're offline."
                updateProgressStatus(ProgressStatus.ContainError, itemIndex, errorMessage)
            Else
                updateProgressStatus(ProgressStatus.ContainError, itemIndex, e.Error.Message)
                errorMessage = e.Error.Message
            End If
            addPatientToListOfError(currentPatient, errorMessage)
            Return
        End If

        Dim jsonResult As Object = GeneralUtil.serializeToJSONObject(e.Result)
        If jsonResult Is Nothing Then
            errorMessage = "Webserver: Internal server error."
            updateProgressStatus(ProgressStatus.ContainError, itemIndex, errorMessage)
            'Add patient to a list of error
            addPatientToListOfError(currentPatient, errorMessage)
            Return
        End If
        Try
            patients.AddRange(GeneralUtil.getPatientListFromJSONObject(jsonResult))
        Catch ex As Exception
            errorMessage = "Error while serializing JSON object."
            updateProgressStatus(ProgressStatus.ContainError, itemIndex, errorMessage)
            'Add patient to a list of error
            addPatientToListOfError(currentPatient, errorMessage)
            Return
        End Try

        If patients.Count = 1 Then
            Dim patient As Patient = patients(0)
            patient.Syn = True
            Dim status = patientDAO.Update(currentPatient.PatientID, patient)
            If status >= 0 Then
                'Add patient to a list of success
                addPatientToListOfSuccess(currentPatient)

                updateProgressStatus(ProgressStatus.Completed, itemIndex)
                DataGridView1.Visible = False
                DataGridView1.Rows(itemIndex).Cells(PATIENT_ID_COL_IDEX).Value = patient.PatientID
                DataGridView1.Visible = True
            Else
                updateProgressStatus(ProgressStatus.ContainError, itemIndex, "Fail in synchronizing data in local database.")
            End If
        ElseIf patients.Count > 1 Then

            'Add patient to a list of duplication 
            addPatientToListOfDuplication(currentPatient, patients)

            DataGridView1.Visible = False
            DataGridView1.Rows(itemIndex).Cells(STATUS_COL_IDEX).Tag = patients
            DataGridView1.Visible = True
            updateProgressStatus(ProgressStatus.ManualSyn, itemIndex, "", patients.Count)
        Else
            errorMessage = jsonResult("error")
            updateProgressStatus(ProgressStatus.ContainError, itemIndex, errorMessage)
            'Add patient to a list of error
            addPatientToListOfError(currentPatient, errorMessage)
        End If

        DataGridView1.Visible = True
        'updateProgressStatus(ProgressStatus.Completed, 0)

    End Sub
    Private Sub addPatientToListOfError(ByVal currentPatient As Patient, ByVal errorMessage As String)
        currentPatient.setTag(errorMessage)
        listOfErrSynPatients.Add(currentPatient)
    End Sub
    Private Sub addPatientToSynchronizationList(ByVal currentPatient As Patient)
        listOfSynPatients.Add(currentPatient)
    End Sub
    Private Sub addPatientToListOfSuccess(ByVal currentPatient As Patient)
        currentPatient.setTag(STATUS_COMPLETED)
        listOfSuccesfulSynPatients.Add(currentPatient)
    End Sub
    Private Sub addPatientToListOfDuplication(ByVal currentPatient As Patient, ByVal patients As List(Of Patient))
        currentPatient.setTag(patients)
        listOfDuplicatedSynPatients.Add(currentPatient)
    End Sub
    Public Function preparePatientSynObject(ByVal currentPatient As Patient) As PatientSyn
        Dim patientSyn As New PatientSyn
        patientSyn.patientid = currentPatient.PatientID
        patientSyn.fingerprint_r1 = fingerprintUtil.getTemplateBase64(currentPatient.Fingerprint_r1)
        patientSyn.fingerprint_r2 = fingerprintUtil.getTemplateBase64(currentPatient.Fingerprint_r2)
        patientSyn.fingerprint_r3 = fingerprintUtil.getTemplateBase64(currentPatient.Fingerprint_r3)
        patientSyn.fingerprint_r4 = fingerprintUtil.getTemplateBase64(currentPatient.Fingerprint_r4)
        patientSyn.fingerprint_r5 = fingerprintUtil.getTemplateBase64(currentPatient.Fingerprint_r5)
        patientSyn.fingerprint_l1 = fingerprintUtil.getTemplateBase64(currentPatient.Fingerprint_l1)
        patientSyn.fingerprint_l2 = fingerprintUtil.getTemplateBase64(currentPatient.Fingerprint_l2)
        patientSyn.fingerprint_l3 = fingerprintUtil.getTemplateBase64(currentPatient.Fingerprint_l3)
        patientSyn.fingerprint_l4 = fingerprintUtil.getTemplateBase64(currentPatient.Fingerprint_l4)
        patientSyn.fingerprint_l5 = fingerprintUtil.getTemplateBase64(currentPatient.Fingerprint_l5)

        patientSyn.gender = currentPatient.Gender
        patientSyn.age = currentPatient.Age
        patientSyn.sitecode = currentPatient.SiteCode
        If currentPatient.DateBirth.Trim().Equals("") Then
            patientSyn.datebirth = ""
        Else
            patientSyn.datebirth = DateTime.Parse(currentPatient.DateBirth).ToString("yyyy-MM-dd HH:mm:ss")
        End If



        patientSyn.createdate = DateTime.Parse(currentPatient.Createdate).ToString("yyyy-MM-dd HH:mm:ss")
        patientSyn.updatedate = DateTime.Parse(currentPatient.Updatedate).ToString("yyyy-MM-dd HH:mm:ss")
        currentPatient.Visits = visitDAO.getAll(currentPatient.PatientID, DAO.VisitDAO.Synchronization.NonSyn)
        patientSyn.addVisits(currentPatient.Visits)
        Return patientSyn
    End Function
    Private Sub synchronizationWorker_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles synchronizationWorker.RunWorkerCompleted

        updateSynSummary()

    End Sub
    Private Sub updateSynSummary()
        NumOfSuccessLabel.Text = listOfSuccesfulSynPatients.Count
        NumOfDuplicationLabel.Text = listOfDuplicatedSynPatients.Count
        NumOfErrorLabel.Text = listOfErrSynPatients.Count
        NumOfTotalSynLabel.Text = listOfSynPatients.Count
    End Sub
    Private Sub uploadProgressChange(ByVal sender As Object, ByVal e As System.Net.UploadProgressChangedEventArgs)
        Dim itemIndex As Integer = e.UserState

        updateProgressStatus(ProgressStatus.Processing, itemIndex)

    End Sub
    Private Sub updateProgressStatus(ByVal status As ProgressStatus, ByVal index As Integer, Optional ByVal errorMessage As String = "", Optional ByVal numOfRecords As Int32 = 0)
        If status = ProgressStatus.Starting Then
            DataGridView1.Rows(index).Cells(STATUS_COL_IDEX).Value = STATUS_Synchronizing
            'DataGridView1.Rows(index).Cells(STATUS_COL_IDEX) = New DataGridViewImageCell()
            'DataGridView1.Rows(index).Cells(STATUS_COL_IDEX).Value = My.Resources.loading_icon
        ElseIf status = ProgressStatus.Processing Then
            DataGridView1.Rows(index).Cells(STATUS_COL_IDEX).Value += "."
        ElseIf status = ProgressStatus.Completed Then
            Dim cell As New DataGridViewTextBoxCell()
            cell.Value = STATUS_COMPLETED
            DataGridView1.Rows(index).Cells(STATUS_COL_IDEX) = cell
        ElseIf status = ProgressStatus.ContainError Then
            Dim cell As DataGridViewLinkCell = New DataGridViewLinkCell()
            cell.Value = STATUS_Error
            cell.ErrorText = errorMessage
            DataGridView1.Rows(index).Cells(STATUS_COL_IDEX) = cell
        ElseIf status = ProgressStatus.ManualSyn Then
            Dim cell As DataGridViewLinkCell = New DataGridViewLinkCell()
            Dim currentCell = DataGridView1.Rows(index).Cells(STATUS_COL_IDEX)
            cell.Tag = currentCell.Tag
            cell.Value = numOfRecords.ToString() + " records found"
            DataGridView1.Rows(index).Cells(STATUS_COL_IDEX) = cell
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex < 0 Then
            Return
        End If
        Dim dataGridItem As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        Dim currentPatient As Patient = dataGridItem.DataBoundItem
        Dim cell As DataGridViewCell = dataGridItem.Cells(STATUS_COL_IDEX)
        If Not TypeOf cell Is DataGridViewLinkCell Then
            Return
        End If
        If cell.ErrorText.Equals("") Then
            showManualSynForm(currentPatient, cell.Tag)
        Else
            MessageBox.Show(cell.ErrorText, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub showManualSynForm(ByVal currentPatient As Patient, ByVal patients As List(Of Patient))
        Dim manualSyn As New ManualSyn
        manualSyn.SetCurrentPatient(currentPatient)
        manualSyn.SetMatchedPatients(patients)
        manualSyn.Owner = Me
        manualSyn.ShowDialog(Me)
    End Sub

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        'Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        'Dim dataSource As List(Of Patient) = DirectCast(DataGridView1.DataSource, System.Windows.Forms.BindingSource).DataSource
        'Dim patient As Patient = dataSource(e.RowIndex)
        'Dim tag As Object = patient.getTag()
        'row.Cells(3).Value = patient.Createdate
        'row.Cells(4).Value = patient.Updatedate
        'If TypeOf (tag) Is List(Of Patient) Then
        '    Dim patients As List(Of Patient) = CType(patient.getTag(), List(Of Patient))
        '    DataGridView1.Rows(e.RowIndex).Cells(STATUS_COL_IDEX).Tag = patients
        '    updateProgressStatus(ProgressStatus.ManualSyn, e.RowIndex, "", patients.Count)
        'ElseIf TypeOf (tag) Is String Then
        '    Dim message As String = CType(tag, String)
        '    If message.Equals(STATUS_COMPLETED) Then
        '        updateProgressStatus(ProgressStatus.Completed, e.RowIndex)
        '    Else
        '        updateProgressStatus(ProgressStatus.ContainError, e.RowIndex, message)
        '    End If
        'End If
        'GeneralUtil.formatDateOfDataGridRow(row, "dd/MM/yyyy hh:mm:ss tt", 3, 4)
    End Sub
    Private Sub DataGridView1_DataBindingComplete(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles DataGridView1.DataBindingComplete
        Dim row As DataGridViewRow
        For index As Integer = 0 To DataGridView1.Rows.Count - 1
            row = DataGridView1.Rows(index)
            Dim dataSource As List(Of Patient) = DirectCast(DataGridView1.DataSource, System.Windows.Forms.BindingSource).DataSource
            Dim patient As Patient = dataSource(index)
            Dim tag As Object = patient.getTag()
            row.Cells(3).Value = patient.Createdate
            row.Cells(4).Value = patient.Updatedate
            If TypeOf (tag) Is List(Of Patient) Then
                Dim patients As List(Of Patient) = CType(patient.getTag(), List(Of Patient))
                DataGridView1.Rows(index).Cells(STATUS_COL_IDEX).Tag = patients
                updateProgressStatus(ProgressStatus.ManualSyn, index, "", patients.Count)
            ElseIf TypeOf (tag) Is String Then
                Dim message As String = CType(tag, String)
                If message.Equals(STATUS_COMPLETED) Then
                    updateProgressStatus(ProgressStatus.Completed, index)
                Else
                    updateProgressStatus(ProgressStatus.ContainError, index, message)
                End If
            End If
            GeneralUtil.formatDateOfDataGridRow(row, "dd/MM/yyyy hh:mm:ss tt", 3, 4)

        Next

    End Sub
    Private Sub NumOfSuccessLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumOfSuccessLabel.Click
        updateGridView(listOfSuccesfulSynPatients)
    End Sub

    Private Sub NumOfDuplicationLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumOfDuplicationLabel.Click
        updateGridView(listOfDuplicatedSynPatients)
    End Sub

    Private Sub NumOfErrorLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumOfErrorLabel.Click
        updateGridView(listOfErrSynPatients)
    End Sub

    Private Sub NumOfTotalSynLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumOfTotalSynLabel.Click
        updateGridView(listOfSynPatients)
    End Sub

    Private Sub RefreshButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshButton.Click
        resetLabelSummary()
        resetList()
        resetTag(nonSynPatients)
        updateGridView(nonSynPatients)
    End Sub
    Private Sub resetTag(ByVal patients As List(Of Patient))
        For Each p As Patient In patients
            p.setTag(Nothing)
        Next
    End Sub
    Public Sub updateSelectedRowToCompleted()
        Dim itemIndex As Integer = DataGridView1.SelectedRows(0).Index
        Dim currentPatient As Patient = DataGridView1.Rows(itemIndex).DataBoundItem

        listOfDuplicatedSynPatients.Remove(currentPatient)
        listOfSuccesfulSynPatients.Add(currentPatient)
        updateProgressStatus(ProgressStatus.Completed, itemIndex)
        updateSynSummary()
    End Sub
End Class