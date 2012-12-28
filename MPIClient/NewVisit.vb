Imports MPIClient.DataAccess.Model
Imports MPIClient.DataAccess.DAO

Public Class NewVisit
    Private patientID As String
    Private visitDAO As New VisitDAO
    Dim webRequest As New WebRequestClass
    Enum Status
        Online
        Offline
        OnlineButServerError
    End Enum
    Private Sub updateConnectionStatus(ByVal status As Status, Optional ByVal errorMessage As String = "")
        If status = status.Offline Then
            'Error connecting to WebServer. 
            infoLabel.Text = errorMessage + " Status: Offline"
        ElseIf status = SearchResult.Status.Online Then
            infoLabel.Text = "Status: Online"
        ElseIf status = SearchResult.Status.OnlineButServerError Then
            infoLabel.Text = String.Format("{0} Status: Server Error", errorMessage)
        End If
    End Sub
    Private Sub NewVisit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        patientIDLabel.Text = patientID
    End Sub
    Public Sub setPatientID(ByVal patientID As String)
        Me.patientID = patientID
    End Sub

    Private Sub saveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveButton.Click
        Dim visit As Visit = prepareVisit()
        If visitDAO.Add(visit, visit.VisitID) > 0 Then
            updateVisIDFromWebServiceCall(visit)
            MessageBox.Show("Successfully save with VistiID = " + visit.VisitID)
        Else
            MessageBox.Show("Error while saving!!!")
        End If

    End Sub
    Private Function updateVisIDFromWebServiceCall(ByRef visit As Visit) As Boolean


        Dim result As Boolean = False
        Dim jsonObject As Object = webRequest.enrollService(visit)

        If (jsonObject Is Nothing) Then
            updateConnectionStatus(Status.Offline)
        ElseIf jsonObject("error") = "" Then
            result = True
            updateConnectionStatus(Status.Online)
            Dim newVisitID As String
            newVisitID = jsonObject("visitid")
            If visitDAO.updateVisitID(visit.VisitID, newVisitID) > 0 Then
                visit.VisitID = newVisitID
            End If
        Else
            updateConnectionStatus(Status.OnlineButServerError, jsonObject("error"))
        End If

        Return result
    End Function
    Private Function prepareVisit() As Visit
        Dim visit As New Visit
        visit.PatientID = patientIDLabel.Text
        visit.ServiceID = serviceIDTextBox.Text
        visit.SiteCode = siteCodeTextBox.Text
        visit.VisitDate = visitDateTextBox.Text
        visit.ExternalCode = externalCodeTextBox.Text
        visit.ExternalCode2 = externalCode2TextBox.Text
        visit.Info = infoTextBox.Text
        Return visit
    End Function
End Class