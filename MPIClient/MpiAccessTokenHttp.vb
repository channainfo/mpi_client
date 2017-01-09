Public Class MpiAccessTokenHttp
    Public Shared Function request(ByRef url As String, Optional ByVal method As String = "GET", Optional ByVal params As Hashtable = Nothing, Optional ByVal headerParams As Hashtable = Nothing) As String
        If headerParams Is Nothing Then
            headerParams = New Hashtable()
        End If
        headerParams.Add("token", MpiAccessToken.getToken())

        Dim responseString As String = MpiHttp.request(url, method, params, headerParams)
        Return responseString
    End Function
End Class
