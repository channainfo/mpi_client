Imports System.Text
Imports System.Net
Imports MPIClient.DataAccess
Imports System.IO
Imports System.Web.Script.Serialization
Imports MPIClient.DataAccess.Model
Imports MPIClient.DataAccess.DAO
Imports System.Collections.Specialized
Imports System.Web

Public Class WebRequestClass

    Function getSiteCode() As String
        Return ""
    End Function

    Function getMemberFPName() As String
        Return ""
    End Function

    Function getMemberFBValue() As String
        Return ""
    End Function

    Private Sub addFormDataAuthokenRequest(ByVal formData As NameValueCollection)
        formData.Add("sitecode", getSiteCode())
        formData.Add("member_fp_name", getMemberFPName())
        formData.Add("member_fp_value", getMemberFBValue())
    End Sub
    Private Function getAuthRequestQueryString() As String
        Return "&sitecode=" + getSiteCode() + "&member_fp_name=" + getMemberFPName() + "&member_fp_value=" + getMemberFBValue()
    End Function


    Public Function getToken() As String
        Dim mydocpath As String = "c:\\" 'Directory.GetCurrentDirectory()
        Dim accessTokenFileName As String = mydocpath & "access_token.txt"

        If File.Exists(accessTokenFileName) = True Then
            Dim accessToken = loadTokenFromFile(accessTokenFileName)
            Console.WriteLine("Read from cached file: " & accessToken("token"))
            Return accessToken("token")
        Else
            Dim jsonStr As String = loadTokenFromServer()
            Dim jsSerializer As New JavaScriptSerializer()
            writeTokentToFile(accessTokenFileName, jsonStr)
            Dim accessToken = jsSerializer.DeserializeObject(jsonStr)
            Console.WriteLine("Requested from server: " & accessToken("token"))

            Return accessToken("token")
        End If
    End Function
    Public Function loadTokenFromServer() As String
        Using webClient As New WebClient()
            Dim formData As New NameValueCollection()
            formData.Add("client_id", "nk474e4c2d25e491c1f4e153e7c4ec56d8")
            formData.Add("client_secret", "nsa6721f17ca46e9961e5247daad25bc3e")
            formData.Add("grant_type", "client_credentials")

            Dim url As String = ConfigManager.GetConfiguarationValue("Server") + ConfigManager.GetConfiguarationValue("access_token_url")
            Dim response = webClient.UploadValues(url, "POST", formData)
            Dim responseBody = (New System.Text.UTF8Encoding).GetString(response)
            Console.WriteLine(responseBody)

            Return responseBody


        End Using
    End Function

    Public Function loadTokenFromFile(ByVal accessTokenFileName) As Object
        Dim jsonAccessTokenStr As String = File.ReadAllText(accessTokenFileName)
        Dim jsSerializer As New JavaScriptSerializer()
        Dim jsonResult = jsSerializer.DeserializeObject(jsonAccessTokenStr)
        Return jsonResult

    End Function

    Private Sub writeTokentToFile(ByVal accessTokenFileName As String, ByVal jsonString As String)
        Dim FileWriter As StreamWriter

        'Dim mydocpath As String = Directory.GetCurrentDirectory()
        'If (Not System.IO.Directory.Exists("acess_token")) Then
        '  System.IO.Directory.CreateDirectory("acess_token")
        'End If

        IO.File.CreateText(accessTokenFileName).Close()

        FileWriter = New StreamWriter(accessTokenFileName, False)
        FileWriter.WriteLine(jsonString)
        FileWriter.Close()
    End Sub

    Sub synPatient(ByVal patient As PatientSyn, ByVal uploadProgressChange As UploadProgressChangedEventHandler, ByVal uploadValuesCompleted As UploadValuesCompletedEventHandler, ByVal index As Integer)

        Using webClient As New WebClient()
            'Dim enrollService As UploadValuesCompletedEventHandler = Nothing
            AddHandler webClient.UploadValuesCompleted, uploadValuesCompleted
            AddHandler webClient.UploadProgressChanged, uploadProgressChange
            'uploadValuesCompleted.Invoke(webClient, Nothing)
            Dim jsSerializer As New JavaScriptSerializer()
            Dim jsonResult As Object = Nothing
            Try
                Dim formData As New NameValueCollection()
                formData.Add("patient", jsSerializer.Serialize(patient))

                addFormDataAuthokenRequest(formData)

                Dim url As String = ConfigManager.GetConfiguarationValue("Server") + ConfigManager.GetConfiguarationValue("SynURL")
                webClient.UploadValuesAsync(New Uri(url), "post", formData, index)
            Catch ex As Exception
                'Throw ex
            End Try
        End Using

    End Sub



    Sub synPatientWithPatientID(ByVal patient As PatientSyn, ByVal patientID As String, ByVal uploadValuesCompleted As UploadValuesCompletedEventHandler)
        Using webClient As New WebClient()
            'Dim enrollService As UploadValuesCompletedEventHandler = Nothing
            AddHandler webClient.UploadValuesCompleted, uploadValuesCompleted

            'uploadValuesCompleted.Invoke(webClient, Nothing)
            Dim jsSerializer As New JavaScriptSerializer()
            Dim jsonResult As Object = Nothing
            Try
                Dim formData As New NameValueCollection()
                formData.Add("patient", jsSerializer.Serialize(patient))
                formData.Add("patientid", patientID)
                addFormDataAuthokenRequest(formData)
                Dim url As String = ConfigManager.GetConfiguarationValue("Server") + ConfigManager.GetConfiguarationValue("SynUpdateURL")
                webClient.UploadValuesAsync(New Uri(url), "post", formData)
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
            formData.Add("age", visit.Age)
            formData.Add("serviceid", visit.ServiceID)
            formData.Add("sitecode", visit.SiteCode)
            formData.Add("visitdate", visit.VisitDate)
            formData.Add("externalcode", visit.ExternalCode)
            formData.Add("externalcode2", visit.ExternalCode2)
            formData.Add("info", visit.Info)
            addFormDataAuthokenRequest(formData)
            Dim url As String = ConfigManager.GetConfiguarationValue("Server") + ConfigManager.GetConfiguarationValue("EnrollServiceURL")
            Dim jsonString As String = Encoding.UTF8.GetString(webClient.UploadValues(url, "post", formData))

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

            Dim queryString As String = "fingerprint=" + HttpUtility.UrlEncode(jsonFingerprint("tpt")) _
            + "&fingerprint2=" + HttpUtility.UrlEncode(jsonFingerprint2("tpt")) _
            + "&gender=" + patient.Gender.ToString _
            + getAuthRequestQueryString()

            Dim queryData As Byte() = UTF8Encoding.UTF8.GetBytes(queryString)
            Dim url As String = ConfigManager.GetConfiguarationValue("Server") + ConfigManager.GetConfiguarationValue("IdentifyURL")
            Dim httpRequest = WebRequest.Create(url)

            httpRequest.Method = "POST"
            httpRequest.ContentType = "application/x-www-form-urlencoded"
            httpRequest.ContentLength = queryData.Length
            httpRequest.Timeout = ConfigManager.GetConfiguarationValue("RequestTimeOut")

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
    Function indentify(ByVal patient As Patient, ByVal grFingerX As AxGrFingerXLib.AxGrFingerXCtrl) As Object
        Dim jsonResult As Object = Nothing
        Dim fingerprintUtil As New FingerprintUtil(grFingerX)
        Try

            Dim queryString As String = "fingerprint_r1=" + HttpUtility.UrlEncode(fingerprintUtil.getTemplateBase64(patient.Fingerprint_r1)) _
            + "&fingerprint_r2=" + HttpUtility.UrlEncode(fingerprintUtil.getTemplateBase64(patient.Fingerprint_r2)) _
            + "&fingerprint_r3=" + HttpUtility.UrlEncode(fingerprintUtil.getTemplateBase64(patient.Fingerprint_r3)) _
            + "&fingerprint_r4=" + HttpUtility.UrlEncode(fingerprintUtil.getTemplateBase64(patient.Fingerprint_r4)) _
            + "&fingerprint_r5=" + HttpUtility.UrlEncode(fingerprintUtil.getTemplateBase64(patient.Fingerprint_r5)) _
            + "&fingerprint_l1=" + HttpUtility.UrlEncode(fingerprintUtil.getTemplateBase64(patient.Fingerprint_l1)) _
            + "&fingerprint_l2=" + HttpUtility.UrlEncode(fingerprintUtil.getTemplateBase64(patient.Fingerprint_l2)) _
            + "&fingerprint_l3=" + HttpUtility.UrlEncode(fingerprintUtil.getTemplateBase64(patient.Fingerprint_l3)) _
            + "&fingerprint_l4=" + HttpUtility.UrlEncode(fingerprintUtil.getTemplateBase64(patient.Fingerprint_l4)) _
            + "&fingerprint_l5=" + HttpUtility.UrlEncode(fingerprintUtil.getTemplateBase64(patient.Fingerprint_l5)) _
            + "&gender=" + patient.Gender.ToString() _
            + getAuthRequestQueryString()

            Dim queryData As Byte() = UTF8Encoding.UTF8.GetBytes(queryString)
            Dim url As String = ConfigManager.GetConfiguarationValue("Server") + ConfigManager.GetConfiguarationValue("IdentifyURL")
            Dim httpRequest = WebRequest.Create(url)

            httpRequest.Method = "POST"
            httpRequest.ContentType = "application/x-www-form-urlencoded"
            httpRequest.ContentLength = queryData.Length
            httpRequest.Timeout = ConfigManager.GetConfiguarationValue("RequestTimeOut")

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
    Function enroll(ByVal patient As Patient, ByVal jsonFingerprint As Object, ByVal jsonFingerprint2 As Object) As Object
        Dim jsonResult As Object = Nothing

        Try
            Dim queryString As String = "fingerprint=" + HttpUtility.UrlEncode(jsonFingerprint("tpt")) _
            + "&fingerprint2=" + HttpUtility.UrlEncode(jsonFingerprint2("tpt")) _
            + "&gender=" + patient.Gender.ToString _
            + getAuthRequestQueryString()

            Dim queryData As Byte() = UTF8Encoding.UTF8.GetBytes(queryString)
            Dim url As String = ConfigManager.GetConfiguarationValue("Server") + ConfigManager.GetConfiguarationValue("EnrollURL")
            Dim httpRequest = WebRequest.Create(url)

            httpRequest.Method = "POST"
            httpRequest.ContentType = "application/x-www-form-urlencoded"
            httpRequest.ContentLength = queryData.Length
            httpRequest.Timeout = ConfigManager.GetConfiguarationValue("RequestTimeOut")

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
    Function enroll(ByVal patient As Patient, ByVal grFingerX As AxGrFingerXLib.AxGrFingerXCtrl) As Object
        Dim jsonResult As Object = Nothing
        Dim fingerprintUtil As New FingerprintUtil(grFingerX)
        Try
            Dim queryString As String = "fingerprint_r1=" + HttpUtility.UrlEncode(fingerprintUtil.getTemplateBase64(patient.Fingerprint_r1)) _
            + "&fingerprint_r2=" + HttpUtility.UrlEncode(fingerprintUtil.getTemplateBase64(patient.Fingerprint_r2)) _
            + "&fingerprint_r3=" + HttpUtility.UrlEncode(fingerprintUtil.getTemplateBase64(patient.Fingerprint_r3)) _
            + "&fingerprint_r4=" + HttpUtility.UrlEncode(fingerprintUtil.getTemplateBase64(patient.Fingerprint_r4)) _
            + "&fingerprint_r5=" + HttpUtility.UrlEncode(fingerprintUtil.getTemplateBase64(patient.Fingerprint_r5)) _
            + "&fingerprint_l1=" + HttpUtility.UrlEncode(fingerprintUtil.getTemplateBase64(patient.Fingerprint_l1)) _
            + "&fingerprint_l2=" + HttpUtility.UrlEncode(fingerprintUtil.getTemplateBase64(patient.Fingerprint_l2)) _
            + "&fingerprint_l3=" + HttpUtility.UrlEncode(fingerprintUtil.getTemplateBase64(patient.Fingerprint_l3)) _
            + "&fingerprint_l4=" + HttpUtility.UrlEncode(fingerprintUtil.getTemplateBase64(patient.Fingerprint_l4)) _
            + "&fingerprint_l5=" + HttpUtility.UrlEncode(fingerprintUtil.getTemplateBase64(patient.Fingerprint_l5)) _
            + "&gender=" + patient.Gender.ToString() _
            + "&sitecode=" + patient.SiteCode _
            + getAuthRequestQueryString()

            Dim queryData As Byte() = UTF8Encoding.UTF8.GetBytes(queryString)
            Dim url As String = ConfigManager.GetConfiguarationValue("Server") + ConfigManager.GetConfiguarationValue("EnrollURL")
            Dim httpRequest = WebRequest.Create(url)

            httpRequest.Method = "POST"
            httpRequest.ContentType = "application/x-www-form-urlencoded"
            httpRequest.ContentLength = queryData.Length
            httpRequest.Timeout = ConfigManager.GetConfiguarationValue("RequestTimeOut")

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
