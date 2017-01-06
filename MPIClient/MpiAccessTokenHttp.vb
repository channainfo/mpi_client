Public Class MpiAccessTokenHttp
    Public Shared Function request(ByRef url As String, Optional ByVal method As String = "GET", Optional ByVal params As Hashtable = Nothing) As String
        Dim headerParams As New Hashtable()
        headerParams.Add("token", MpiAccessToken.getToken())

        Dim responseString As String = MpiHttp.request(url, method, params, headerParams)
        Return responseString
    End Function
End Class
