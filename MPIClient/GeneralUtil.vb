Imports System.Web.Script.Serialization
Imports MPIClient.DataAccess.Model

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
        Dim jsonPatient As Object = jsonObject("patient")
        If Not jsonPatient Is Nothing Then
            Dim jsSerializer As New JavaScriptSerializer()
            patient = jsSerializer.Deserialize(Of Patient)(jsSerializer.Serialize(jsonPatient))
        End If
        Return patient
    End Function

End Class
