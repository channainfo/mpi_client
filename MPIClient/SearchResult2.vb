Imports MPIClient.DataAccess.Model
Imports MPIClient.DataAccess.DAO
Imports System.Threading
Imports System.Web.Script.Serialization
Public Class SearchResult2
    Private STR_PatientsFound As String
    Private STR_Warning As String
    Private STR_Confirmation As String
    Private STR_Information As String
    Private STR_Offline As String
    Private STR_Online As String
    Private STR_TheWebServerEncounterProblemStatusServerError As String
    Private STR_AtLeastTwoFingerprintsAreRequiredForTheEnrollment As String
    Private STR_AreYouSureYouWantToEnrollNewPatient As String
    Private STR_SuccessfullySaveWithPatientID As String
    Private STR_ErrorWhileSaving As String
    Dim patientDAO As New PatientDAO
    Dim patient As Patient
    Dim fingerprintUtil As FingerprintUtil
    Dim searchThread As Thread
    Dim filterredPatients As New List(Of Patient)()
    Dim webRequest As New WebRequestClass
    Dim grFingerX As AxGrFingerXLib.AxGrFingerXCtrl
    Dim resourceManager As Resources.ResourceManager
    Enum Status
        Online
        Offline
        OnlineButServerError
    End Enum
    Private Sub SearchResult2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        setResourcesText()

        If patient Is Nothing Then
            Return
        End If
        refreshLoadingPatient()

    End Sub
    Private Sub setResourcesText()
        resourceManager = New Resources.ResourceManager("MPIClient.LocalizedText", GetType(SearchResult2).Assembly)
        STR_PatientsFound = resourceManager.GetString("STR_PatientsFound")
        STR_Warning = resourceManager.GetString("STR_Warning")
        STR_Confirmation = resourceManager.GetString("STR_Confirmation")
        STR_Information = resourceManager.GetString("STR_Information")
        STR_Offline = resourceManager.GetString("STR_Offline")
        STR_Online = resourceManager.GetString("STR_Online")
        STR_TheWebServerEncounterProblemStatusServerError = resourceManager.GetString("STR_TheWebServerEncounterProblemStatusServerError")
        STR_AtLeastTwoFingerprintsAreRequiredForTheEnrollment = resourceManager.GetString("STR_AtLeastTwoFingerprintsAreRequiredForTheEnrollment")
        STR_AreYouSureYouWantToEnrollNewPatient = resourceManager.GetString("STR_AreYouSureYouWantToEnrollNewPatient")
        STR_SuccessfullySaveWithPatientID = resourceManager.GetString("STR_SuccessfullySaveWithPatientID")
        STR_ErrorWhileSaving = resourceManager.GetString("STR_ErrorWhileSaving")
    End Sub
    Private Sub refreshLoadingPatient()
        waitingProgress.Visible = True
        countTimer.Enabled = True
        searchThread = New Thread(AddressOf Me.bindSearchPatientResult)
        'searchThread.Priority = ThreadPriority.Highest
        searchThread.Start()

    End Sub
    Private Sub bindSearchPatientResult()
        clearDataSourceGrid()
        Dim jsonObject As Object = webRequest.indentify(patient, grFingerX)

        If (jsonObject Is Nothing) Then
            updateConnectionStatus(Status.Offline)
            fillPatientListWithAllLocalDBData()
        ElseIf jsonObject("error") = "" Then
            updateConnectionStatus(Status.Online)
            fillPatientListWhenOnline(jsonObject)
        Else
            updateConnectionStatus(Status.OnlineButServerError, jsonObject("error"))
            fillPatientListWithAllLocalDBData()
        End If
        updateGridView()
        updatePatientFoundLabel()

    End Sub
    Private Sub updatePatientFoundLabel()
        patientFoundLabel.Text = filterredPatients.Count.ToString() + STR_PatientsFound
    End Sub
    Private Sub clearDataSourceGrid()
        DataGridView1.Visible = False
        DataGridView1.DataSource = Nothing
        DataGridView1.Refresh()
        filterredPatients.Clear()
        DataGridView1.Visible = True
    End Sub
    Private Sub fillPatientListWithAllLocalDBData()
        filterredPatients.AddRange(patientDAO.getMatchedPatients(patient, fingerprintUtil))
    End Sub
    Private Sub fillPatientListWhenOnline(ByVal jsonObject As Object)
        filterredPatients.AddRange(GeneralUtil.getPatientListFromJSONObject(jsonObject))
        fillPatientListWithNonSynLocalDBData()
    End Sub

    Private Sub fillPatientListWithNonSynLocalDBData()
        filterredPatients.AddRange(patientDAO.getMatchedPatients(patient, fingerprintUtil, patientDAO.Synchronization.NonSyn))
    End Sub
    Private Sub updateGridView()
        'If Me.InvokeRequired Then
        '    Me.Invoke(New MethodInvoker(AddressOf updateGridView))
        'Else
        DataGridView1.Visible = False
        DataGridView1.DataSource = Nothing
        DataGridView1.DataSource = PatientBindingSource
        PatientBindingSource.DataSource = filterredPatients
        DataGridView1.Refresh()

        waitingProgress.Visible = False
        countTimer.Enabled = False
        DataGridView1.Visible = True
        'End If

    End Sub
    Private Sub updateConnectionStatus(ByVal status As Status, Optional ByVal errorMessage As String = "")
        If status = status.Offline Then
            'Error connecting to WebServer. 
            infoLabel.Text = errorMessage + STR_Offline
        ElseIf status = SearchResult.Status.Online Then
            infoLabel.Text = STR_Online
        ElseIf status = SearchResult.Status.OnlineButServerError Then
            infoLabel.Text = String.Format(STR_TheWebServerEncounterProblemStatusServerError, errorMessage)
        End If
    End Sub
    Private Sub buttonNewPatient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles newPatientButton.Click
        Dim customMsgBox As New CustomMessageBox()

        If patient Is Nothing Then
            Return
        End If
        If patient.getFingerprintsInPriority().Count < 2 Then

            customMsgBox.display(STR_AtLeastTwoFingerprintsAreRequiredForTheEnrollment, STR_Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'MessageBox.Show(STR_AtLeastTwoFingerprintsAreRequiredForTheEnrollment, STR_Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
            Owner.Show()
            Return
        End If
        'If (MessageBox.Show(STR_AreYouSureYouWantToEnrollNewPatient, STR_Confirmation, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
        If (customMsgBox.display(STR_AreYouSureYouWantToEnrollNewPatient, STR_Confirmation, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
            Dim patientID As String = Nothing
            If patientDAO.Add(patient, patientID) > 0 Then
                updatePatientIDFromWebServiceCall(patientID)
                addNewPatientToGrid(patientID)
                customMsgBox.display(STR_SuccessfullySaveWithPatientID + patientID, STR_Information, MessageBoxButtons.OK, MessageBoxIcon.Information)
                'MessageBox.Show(STR_SuccessfullySaveWithPatientID + patientID, STR_Information, MessageBoxButtons.OK, MessageBoxIcon.Information)
                'refreshLoadingPatient()
            Else
                customMsgBox.display(STR_ErrorWhileSaving, STR_Information, MessageBoxButtons.OK, MessageBoxIcon.Information)
                'MessageBox.Show(STR_ErrorWhileSaving, STR_Information, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End If

    End Sub
    Private Sub addNewPatientToGrid(ByRef patientID As String)
        filterredPatients.Add(patientDAO.getPatient(patientID))
        updateGridView()
    End Sub
    Private Function updatePatientIDFromWebServiceCall(ByRef patientID As String) As Boolean


        Dim result As Boolean = False
        Dim webRequest As New WebRequestClass

        Dim jsonObject As Object = webRequest.enroll(patient, grFingerX)

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
    Public Sub setPatient(ByVal patientObject As Patient)
        patient = patientObject
    End Sub
    Public Sub setFilgerprintUtil(ByVal fingerprintUtilObject As FingerprintUtil)
        fingerprintUtil = fingerprintUtilObject
    End Sub
    Friend Sub SetGrFingerX(ByVal grFingerX As AxGrFingerXLib.AxGrFingerXCtrl)
        Me.grFingerX = grFingerX
    End Sub
    Private Sub buttonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles closeButton.Click
        Me.Close()
    End Sub

    Private Sub countTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles countTimer.Tick
        countLabel.Text = Convert.ToInt32(countLabel.Text) + 1
    End Sub

    Private Sub DataGridView1_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        GeneralUtil.formatDateOfDataGridRow(row, "dd/MM/yyyy hh:mm:ss tt", 3, 4)
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex < 0 Then
            Return
        End If
        If TypeOf DataGridView1.Columns(e.ColumnIndex) Is DataGridViewLinkColumn Then
            showVisitHistoryForm(e)
        End If
    End Sub
    Private Sub showVisitHistoryForm(ByVal e As DataGridViewCellEventArgs)
        Me.Hide()
        Dim visitHistoryForm As New VisitHistory
        visitHistoryForm.setPatient(filterredPatients(e.RowIndex))
        visitHistoryForm.ShowDialog(Me)
    End Sub

    Private Sub DataGridView1_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseDoubleClick
        If e.RowIndex < 0 Then
            Return
        End If
        showNewVisitForm(e.RowIndex)
    End Sub

    Private Sub showNewVisitForm(ByVal rowIndex As Integer)
        Dim newVisit As New NewVisit
        newVisit.setPatientID(filterredPatients(rowIndex).PatientID)
        newVisit.Owner = Me
        newVisit.setRowIndex(rowIndex)
        newVisit.ShowDialog()
    End Sub
    Public Sub updateVisit(ByVal rowIndex As Integer, ByVal visit As Visit)
        Dim patient As Patient = filterredPatients(rowIndex)
        patient.Visits.Add(visit)
        patient.NumVisit = patient.Visits.Count
        updateGridView()
    End Sub
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex < 0 Then
            Return
        End If
        showNewVisitForm(e.RowIndex)
    End Sub

    Private Sub newVisitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles newVisitButton.Click
        Dim selectedRows As DataGridViewSelectedRowCollection = DataGridView1.SelectedRows
        If (selectedRows.Count > 0) Then
            showNewVisitForm(selectedRows(0).Index)
        End If

    End Sub

    Private Sub SearchResult2_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Owner.Show()
    End Sub
End Class