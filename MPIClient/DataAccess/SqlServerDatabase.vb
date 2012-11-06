Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Namespace DataAccess
    Public NotInheritable Class SqlServerDatabase
        Inherits Database
        Private Const PARAMETER_INDICATOR As Char = "@"c
        Public Sub New(ByVal connectionString As String)

            MyBase.New(SqlClientFactory.Instance, connectionString)
        End Sub
        Public Overrides Function CreateParameterName(ByVal parameterName As String) As String
            Dim newName As String = ""
            Dim c As Char = parameterName(0)
            If c.Equals(PARAMETER_INDICATOR) Then
                newName = parameterName
            Else
                newName = PARAMETER_INDICATOR + parameterName
            End If
            Return newName
        End Function

        Public Overrides Function CreateSchema(ByVal tableName As String) As System.Data.DataTable

            Dim SqlStmt As String = "SELECT * FROM " + tableName + " LIMIT 1"
            Dim reader As DbDataReader = ExecuteReader(SqlStmt)
            Dim dt As DataTable = reader.GetSchemaTable()
            reader.Close()
            reader.Dispose()

            Return dt

        End Function
    End Class
End Namespace