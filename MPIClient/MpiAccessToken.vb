Imports System.Text
Imports System.Net
Imports MPIClient.DataAccess
Imports System.Web.Script.Serialization
Imports System.Collections.Specialized
Imports System.Web
Imports System.IO

Public Class MpiAccessToken
    Public Shared token As String = ""

    Public Shared Function tokenValue() As String
        Return MpiAccessToken.token
    End Function

    Public Shared Function getToken() As String

        If String.Compare(MpiAccessToken.token, "") <> 0 Then
            Return MpiAccessToken.token
        End If

        If File.Exists(MpiAccessToken.accessTokenFileName()) = True Then
            Dim accessTokenResponse = MpiAccessToken.loadTokenFromFile()
            Console.WriteLine("Read from cached file: " & accessTokenResponse("token"))
            MpiAccessToken.token = accessTokenResponse("token")
            Return MpiAccessToken.token
        Else
            Dim jsonStr As String = MpiAccessToken.loadTokenFromServer()
            Dim jsSerializer As New JavaScriptSerializer()
            MpiAccessToken.writeTokentToFile(jsonStr)
            Dim accessTokenResponse = jsSerializer.DeserializeObject(jsonStr)
            Console.WriteLine("Requested from server: " & accessTokenResponse("token"))
            MpiAccessToken.token = accessTokenResponse("token")
            Return MpiAccessToken.token
        End If
    End Function

    Private Shared Function accessTokenFileName() As String
        Dim mydocpath As String = "c:\\" 'Directory.GetCurrentDirectory()
        Return mydocpath & "access_token.txt"
    End Function

    Public Shared Function refreshToken() As String
        Dim clientId = ConfigManager.GetConfiguarationValue("client_id")
        Dim clientSecret = ConfigManager.GetConfiguarationValue("client_secret")
        Dim url = ConfigManager.GetConfiguarationValue("access_token_url")
        Dim accessToken As Object = MpiAccessToken.loadTokenFromFile()
        Dim refreshTokenValue As String = accessToken("refresh_token")

        Dim params As New Hashtable()
        params.Add("client_id", clientId)
        params.Add("client_secret", clientSecret)
        params.Add("grant_type", "refresh_token")
        params.Add("refresh_token", refreshTokenValue)

        Dim responseBody = MpiHttp.request(url, "POST", params)

        Dim jsSerializer As New JavaScriptSerializer()
        MpiAccessToken.writeTokentToFile(responseBody)

        Dim accessTokenResponse = jsSerializer.DeserializeObject(responseBody)
        Console.WriteLine("Token refresh from server: " & accessTokenResponse("token"))
        MpiAccessToken.token = accessTokenResponse("token")
        Return MpiAccessToken.token
    End Function


    Private Shared Function loadTokenFromServer() As String

        Dim clientId = ConfigManager.GetConfiguarationValue("client_id")
        Dim clientSecret = ConfigManager.GetConfiguarationValue("client_secret")
        Dim url As String = ConfigManager.GetConfiguarationValue("access_token_url")

        Dim params As New Hashtable()
        params.Add("client_id", clientId)
        params.Add("client_secret", clientSecret)
        params.Add("grant_type", "client_credentials")

        Dim responseBody = MpiHttp.request(url, "POST", params)
        Return responseBody
    End Function

    Private Shared Function loadTokenFromFile() As Object
        Dim jsonAccessTokenStr As String = File.ReadAllText(MpiAccessToken.accessTokenFileName())
        Dim jsSerializer As New JavaScriptSerializer()
        Dim jsonResult = jsSerializer.DeserializeObject(jsonAccessTokenStr)
        Return jsonResult

    End Function

    Private Shared Sub writeTokentToFile(ByVal jsonString As String)
        Dim FileWriter As StreamWriter

        'Dim mydocpath As String = Directory.GetCurrentDirectory()
        'If (Not System.IO.Directory.Exists("acess_token")) Then
        '  System.IO.Directory.CreateDirectory("acess_token")
        'End If
        Dim fileName = MpiAccessToken.accessTokenFileName()
        IO.File.CreateText(fileName).Close()

        FileWriter = New StreamWriter(fileName, False)
        FileWriter.WriteLine(jsonString)
        FileWriter.Close()
    End Sub
End Class
