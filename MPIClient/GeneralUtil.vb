Imports System.Web.Script.Serialization
Imports MPIClient.DataAccess.Model
Imports System.Text

Public Class GeneralUtil

    Public Shared Function getPatientListFromJSONObject(ByVal jsonObject As Object) As List(Of Patient)
        Dim patients As New List(Of Patient)
        Dim jsonPatientArray As Object = jsonObject("patients")
        Dim patientArray As Array = jsonObject("patients")
        If patientArray.Length > 0 Then
            Dim jsSerializer As New JavaScriptSerializer()
            patients.AddRange(jsSerializer.Deserialize(Of List(Of Patient))(jsSerializer.Serialize(jsonPatientArray)))
        End If
        Return patients
    End Function

    Public Shared Function getPatientFromJSONObject(ByVal jsonObject As Object) As Patient
        Dim patient As Patient = Nothing
        If jsonObject Is Nothing Then
            Return patient
        End If
        Dim jsonPatient As Object = jsonObject("patient")
        If Not jsonPatient Is Nothing Then
            Dim jsSerializer As New JavaScriptSerializer()
            patient = jsSerializer.Deserialize(Of Patient)(jsSerializer.Serialize(jsonPatient))
        End If
        Return patient
    End Function
    Public Shared Function serializeToJSONObject(ByVal result As Byte()) As Object
        Dim jsonString As String = Encoding.UTF8.GetString(result)
        Dim jsonResult As Object = Nothing
        Dim jsSerializer As New JavaScriptSerializer()

        Try
            jsonResult = jsSerializer.DeserializeObject(jsonString)
        Catch ex As Exception

        End Try
        Return jsonResult
    End Function
    Public Shared Sub formatDateOfDataGridRow(ByVal row As DataGridViewRow, ByVal format As String, ByVal ParamArray indexs() As Integer)
        Dim dateValue As DateTime

        For i As Integer = 0 To indexs.Count - 1
            If DateTime.TryParse(row.Cells(indexs(i)).Value, dateValue) Then
                row.Cells(indexs(i)).Value = dateValue.ToString(format)
            End If
        Next

    End Sub

End Class
