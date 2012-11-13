﻿Imports System.Text
Imports System.Net
Imports MPIClient.DataAccess
Imports System.IO
Imports System.Web.Script.Serialization
Imports MPIClient.DataAccess.Model
Imports MPIClient.DataAccess.DAO
Imports System.Collections.Specialized

Public Class WebRequestClass

    Sub synPatient(ByVal patient As Patient, ByVal uploadValuesCompleted As UploadValuesCompletedEventHandler, ByVal index As Integer)

        Using webClient As New WebClient()
            Dim enrollService As UploadValuesCompletedEventHandler = Nothing
            AddHandler webClient.UploadValuesCompleted, uploadValuesCompleted

            uploadValuesCompleted.Invoke(webClient, Nothing)
            Dim jsSerializer As New JavaScriptSerializer()
            Dim jsonResult As Object = Nothing
            Try
                Dim formData As New NameValueCollection()
                formData.Add("patient", jsSerializer.Serialize(patient))
                Dim url As String = ConfigManager.GetConfiguarationValue("Server") + ConfigManager.GetConfiguarationValue("SynURL")
                'webClient.UploadValuesAsync(New Uri(url), "post", formData, index)
            Catch ex As Exception
                'Throw ex
            End Try
        End Using

    End Sub
    Sub synPatientWithPatientID(ByVal patient As Patient, ByVal patientID As String, ByVal uploadValuesCompleted As UploadValuesCompletedEventHandler)
        Using webClient As New WebClient()
            Dim enrollService As UploadValuesCompletedEventHandler = Nothing
            AddHandler webClient.UploadValuesCompleted, uploadValuesCompleted

            uploadValuesCompleted.Invoke(webClient, Nothing)
            Dim jsSerializer As New JavaScriptSerializer()
            Dim jsonResult As Object = Nothing
            Try
                Dim formData As New NameValueCollection()
                formData.Add("patient", jsSerializer.Serialize(patient))
                Dim url As String = ConfigManager.GetConfiguarationValue("Server") + ConfigManager.GetConfiguarationValue("SynURL")
                formData.Add("patientid", patientID)
            Catch ex As Exception
                'Throw ex
            End Try
        End Using
    End Sub
    Function enrollService(ByVal visit As Visit) As Object
        Dim jsonResult As Object = Nothing
        Try
            'Dim queryString As String = "patientid=" + patientID
            Dim webClient As New WebClient

            Dim formData As New NameValueCollection
            formData.Add("patientid", visit.PatientID)
            formData.Add("serviceid", visit.ServiceID)
            formData.Add("sitecode", visit.SiteCode)
            formData.Add("visitdate", visit.VisitDate)
            formData.Add("externalcode", visit.ExternalCode)
            formData.Add("info", visit.Info)
            Dim url As String = ConfigManager.GetConfiguarationValue("Server") + ConfigManager.GetConfiguarationValue("EnrollServiceURL")
            Dim jsonString As String = Encoding.UTF8.GetString(webClient.UploadValues(url, "post", formData))

            'Dim queryData As Byte() = UTF8Encoding.UTF8.GetBytes(queryString)
            'Dim url As String = ConfigManager.GetConfiguarationValue("Server") + ConfigManager.GetConfiguarationValue("EnrollServiceURL")
            'Dim httpRequest = WebRequest.Create(url)

            'httpRequest.Method = "POST"
            'httpRequest.ContentType = "application/x-www-form-urlencoded"
            'httpRequest.ContentLength = queryData.Length
            'httpRequest.Timeout = 5000
            'httpRequest.Headers.Add()

            'Dim requestStream = httpRequest.GetRequestStream()

            'requestStream.Write(queryData, 0, queryDta.Length)

            'Dim response = httpRequest.GetResponse()
            'Dim reader = New StreamReader(response.GetResponseStream())
            'Dim jsonString As String = reader.ReadToEnd()
            'response.Close()

            Dim jsSerializer As New JavaScriptSerializer()
            jsonResult = jsSerializer.DeserializeObject(jsonString)
        Catch ex As Exception
            'Throw ex
        End Try
        Return jsonResult
    End Function
    Function indentify(ByVal jsonFingerprint As Object, ByVal jsonFingerprint2 As Object, ByVal patient As Patient) As Object
        Dim jsonResult As Object = Nothing
        Try
            Dim queryString As String = "fingerprint=" + jsonFingerprint("tpt") _
            + "&fingerprint2=" + jsonFingerprint2("tpt") _
            + "&gender=" + patient.Gender.ToString

            Dim queryData As Byte() = UTF8Encoding.UTF8.GetBytes(queryString)
            Dim url As String = ConfigManager.GetConfiguarationValue("Server") + ConfigManager.GetConfiguarationValue("IdentifyURL")
            Dim httpRequest = WebRequest.Create(url)

            httpRequest.Method = "POST"
            httpRequest.ContentType = "application/x-www-form-urlencoded"
            httpRequest.ContentLength = queryData.Length
            'httpRequest.Timeout = 5000

            Dim requestStream = httpRequest.GetRequestStream()

            requestStream.Write(queryData, 0, queryData.Length)
            Dim response = httpRequest.GetResponse()
            Dim reader = New StreamReader(response.GetResponseStream())
            Dim jsonString As String = reader.ReadToEnd()
            response.Close()

            'Dim jsonString As String = "{""patients"":[{""patientid"":""506bf4995901f"",""gender"":""2"",""birthdate"":""2012-10-03"",""visits"":[{""sitecode"":""0101"",""externalcode"":""00001"",""serviceid"":""1"",""info"":""positive"",""visitdate"":""2012-10-03""},{""sitecode"":""0101"",""externalcode"":""00001"",""serviceid"":""2"",""info"":"""",""visitdate"":""2012-10-03""},{""sitecode"":""0101"",""externalcode"":""00001"",""serviceid"":""2"",""info"":""positive"",""visitdate"":""2012-10-03""}]}],""error"":""""}"
            Dim jsSerializer As New JavaScriptSerializer()
            jsonResult = jsSerializer.DeserializeObject(jsonString)
        Catch ex As Exception
            'Throw ex
        End Try
        Return jsonResult

    End Function

    Function enroll(ByVal jsonFingerprint1 As Object, ByVal jsonFingerprint2 As Object) As Object
        Dim jsonResult As Object = Nothing

        Try
            Dim queryString As String = "fingerprint=" + jsonFingerprint1("tpt")
            queryString = queryString + "&fingerprint2=" + jsonFingerprint2("tpt")

            Dim queryData As Byte() = UTF8Encoding.UTF8.GetBytes(queryString)
            Dim url As String = ConfigManager.GetConfiguarationValue("Server") + ConfigManager.GetConfiguarationValue("EnrollURL")
            Dim httpRequest = WebRequest.Create(url)

            httpRequest.Method = "POST"
            httpRequest.ContentType = "application/x-www-form-urlencoded"
            httpRequest.ContentLength = queryData.Length

            Dim requestStream = httpRequest.GetRequestStream()

            requestStream.Write(queryData, 0, queryData.Length)
            Dim response = httpRequest.GetResponse()
            Dim reader = New StreamReader(response.GetResponseStream())
            Dim jsonString As String = reader.ReadToEnd()
            response.Close()

            Dim jsSerializer As New JavaScriptSerializer()
            jsonResult = jsSerializer.DeserializeObject(jsonString)
        Catch ex As Exception
            'Throw ex
        End Try

        Return jsonResult
    End Function
End Class
