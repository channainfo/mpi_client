Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace DataAccess
    Public Class ConfigManager
        Public Const CONFIG_DATABASE_TYPE As String = "DBType"
        Public Const CONFIG_CONNECTION_STRING As String = "CoreDSN"

        Public Shared Function GetConfiguarationValue(ByVal key As String) As String
            Return System.Configuration.ConfigurationManager.AppSettings(key)
        End Function

        Public Shared Function GetConnectionString(ByVal key As String) As String
            Return System.Configuration.ConfigurationManager.ConnectionStrings(key).ConnectionString
        End Function
    End Class
End Namespace

