Imports System.Collections.Specialized
Imports MPIClient.DataAccess
Imports System.Net
Imports System.Text
Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Web

Public Class MpiHttp
    Public Shared Function request(ByVal url As String, Optional ByVal method As String = "GET", Optional ByVal params As Hashtable = Nothing, Optional ByVal headerParams As Hashtable = Nothing) As String
        Dim requestUrl As String = ConfigManager.GetConfiguarationValue("Server") + url
        Dim httpRequestObj As HttpWebRequest = Nothing

        'Contruct Request
        Dim paramStr = ""
        Dim paramData() As String = Nothing
        Dim i = 0

        If Not params Is Nothing Then
            For Each param As DictionaryEntry In params
                Dim item = ""
                If param.Value Is Nothing Then
                    item = param.Key + "="
                Else
                    item = param.Key + "=" + HttpUtility.UrlEncode(param.Value) 'Need to html url decoding
                End If

                ReDim Preserve paramData(i)
                paramData(i) = item
                i = i + 1
            Next param
            paramStr = String.Join("&", paramData)
        End If

        If (method.ToLower() = "get") Then
            requestUrl = requestUrl + "?" + paramStr
            httpRequestObj = HttpWebRequest.Create(requestUrl)
            'Construct headers
            If Not headerParams Is Nothing Then
                For Each headerParam As DictionaryEntry In headerParams
                    httpRequestObj.Headers(headerParam.Key) = headerParam.Value
                Next headerParam
            End If
        Else
            httpRequestObj = HttpWebRequest.Create(requestUrl)
            Dim Data = Encoding.ASCII.GetBytes(paramStr)
            httpRequestObj.Method = method
            httpRequestObj.ContentType = "application/x-www-form-urlencoded"
            httpRequestObj.ContentLength = Data.Length

            'Construct headers
            If Not headerParams Is Nothing Then
                For Each headerParam As DictionaryEntry In headerParams
                    httpRequestObj.Headers(headerParam.Key) = headerParam.Value
                Next headerParam
            End If

            Dim paramStream As Stream = httpRequestObj.GetRequestStream()
            paramStream.Write(Data, 0, Data.Length)
            paramStream.Close()
        End If






        

        Dim response As WebResponse = httpRequestObj.GetResponse()
        Dim responseString = New StreamReader(response.GetResponseStream()).ReadToEnd
        Console.WriteLine(responseString)
        Return responseString

    End Function
End Class
