Imports MPIClient.DataAccess.Model
Imports MPIClient.DataAccess.DAO
Imports System.Threading
Imports System.Web.Script.Serialization

Public Class SearchResult
    Dim patientDAO As New PatientDAO
    Dim patient As Patient
    Dim fingerprintUtil As FingerprintUtil
    Dim fingerImage As FingerImage
    Dim fingerImage2 As FingerImage
    Dim searchThread As Thread
    Dim filterredPatients As New List(Of Patient)()
    Dim webRequest As New WebRequestClass
    Enum Status
        Online
        Offline
        OnlineButServerError
    End Enum
    Private Sub bindSearchPatientResult()

        Dim jsonObject As Object = webRequest.indentify(fingerprintUtil.extractJSON(fingerImage), fingerprintUtil.extractJSON(fingerImage2), patient)

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

    End Sub
    Private Sub fillPatientListWithAllLocalDBData()
        filterredPatients.AddRange(patientDAO.getMatchedPatients(patient.Fingerprint, fingerprintUtil, patient.Gender))
    End Sub
    Private Sub fillPatientListWhenOnline(ByVal jsonObject As Object)
        filterredPatients.AddRange(GeneralUtil.getPatientListFromJSONObject(jsonObject))
        fillPatientListWithNonSynLocalDBData()
    End Sub

    Private Sub fillPatientListWithNonSynLocalDBData()
        filterredPatients.AddRange(patientDAO.getMatchedPatients(patient.Fingerprint, fingerprintUtil, patient.Gender, patientDAO.Synchronization.NonSyn))
    End Sub
    Private Sub updateGridView()
        'If Me.InvokeRequired Then
        '    Me.Invoke(New MethodInvoker(AddressOf updateGridView))
        'Else
        waitingProgress.Visible = False
        countTimer.Enabled = False
        PatientBindingSource.DataSource = filterredPatients
        'End If

    End Sub
    Private Sub updateConnectionStatus(ByVal status As Status, Optional ByVal errorMessage As String = "")
        If status = status.Offline Then
            'Error connecting to WebServer. 
            infoLabel.Text = errorMessage + " Status: Offline"
        ElseIf status = SearchResult.Status.Online Then
            infoLabel.Text = "Status: Online"
        ElseIf status = SearchResult.Status.OnlineButServerError Then
            infoLabel.Text = String.Format("The WebServer encounter problem: {0} Status: Server Error", errorMessage)
        End If
    End Sub
    Private Sub buttonNewPatient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles newPatientButton.Click
        If patient Is Nothing Then
            Return
        End If

        showNewPatientForm()

    End Sub

    Private Sub showNewPatientForm()
        Dim newPatientForm As New NewPatient
        newPatientForm.SetPatient(patient)
        newPatientForm.SetFingerImage(fingerImage)
        newPatientForm.SetFingerImage2(fingerImage2)
        newPatientForm.ShowDialog(Me)
    End Sub
    Private Sub SearchResult_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        If patient Is Nothing Then
            Return
        End If

        searchThread = New Thread(AddressOf Me.bindSearchPatientResult)
        'searchThread.Priority = ThreadPriority.Highest
        searchThread.Start()
        countTimer.Enabled = True

    End Sub

    Public Sub setPatient(ByVal patientObject As Patient)
        patient = patientObject
    End Sub
    Public Sub setFilgerprintUtil(ByVal fingerprintUtilObject As FingerprintUtil)
        fingerprintUtil = fingerprintUtilObject
    End Sub
    Friend Sub SetFingerImage2(ByVal fingerImage2 As FingerImage)
        Me.fingerImage2 = fingerImage2
    End Sub
    Public Sub setFingerImage(ByVal fingerImage As FingerImage)
        Me.fingerImage = fingerImage
    End Sub
    Private Sub buttonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles closeButton.Click
        Me.Close()
    End Sub

    Private Sub countTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles countTimer.Tick
        countLabel.Text = Convert.ToInt32(countLabel.Text) + 1
    End Sub

    Private Sub DataGridView1_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
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
        showNewVisitForm(e.RowIndex)
    End Sub

    Private Sub showNewVisitForm(ByVal rowIndex As Integer)
        Dim newVisit As New NewVisit
        newVisit.setPatientID(filterredPatients(rowIndex).PatientID)
        newVisit.ShowDialog()
    End Sub
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        showNewVisitForm(e.RowIndex)
    End Sub

    Private Sub newVisitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles newVisitButton.Click
        Dim selectedRows As DataGridViewSelectedRowCollection = DataGridView1.SelectedRows
        If (selectedRows.Count > 0) Then
            showNewVisitForm(selectedRows(0).Index)
        End If

    End Sub

    Private Sub SearchResult_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Owner.Show()
    End Sub

End Class