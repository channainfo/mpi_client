Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Data.Common

Namespace DataAccess
    ''' <summary>
    ''' Abstract Database Service to provide database related services.
    ''' </summary>
    Public MustInherit Class Database
        Private _factory As DbProviderFactory
        Private _connectionString As String

        ''' <summary>
        ''' Constructs the Database service
        ''' </summary>
        ''' <param name="factory">Database Provider factory</param>
        ''' <param name="connectionString">Database Connection String</param>
        Protected Sub New(ByVal factory As System.Data.Common.DbProviderFactory, ByVal connectionString As String)
            _factory = factory
            _connectionString = connectionString
        End Sub

        Public MustOverride Function CreateParameterName(ByVal parameterName As String) As String

        ''' <summary>
        ''' Creates Database Connection service
        ''' </summary>
        ''' <returns>Database Connection object</returns>
        Public Function CreateConnection() As DbConnection
            Dim Conn As DbConnection = _factory.CreateConnection()
            Conn.ConnectionString = _connectionString
            Return Conn
        End Function
        ''' <summary>
        ''' Creates a database connection and establish a connection to the database
        ''' </summary>
        ''' <returns>Open Database Connection object</returns>
        Public Function OpenConnection() As DbConnection
            Dim Conn As DbConnection = CreateConnection()
            Conn.Open()
            Return Conn
        End Function
        ''' <summary>
        ''' Creates an SQL Command
        ''' </summary>
        ''' <param name="sqlStmt">Sql statement</param>
        ''' <returns>SQL Command object</returns>
        Public Function CreateCommand(ByVal sqlStmt As String) As DbCommand
            Dim Cmd As DbCommand = _factory.CreateCommand()
            Cmd.CommandText = sqlStmt
            Return Cmd
        End Function

        ''' <summary>
        ''' Creates an SQL Command
        ''' </summary>
        ''' <param name="sqlStmt">Sql statement</param>
        ''' <param name="parameters">Collection of Parameters</param>
        ''' <returns>SQL Command objec</returns>
        Public Function CreateCommand(ByVal sqlStmt As String, ByVal parameters As DbParameterCollection) As DbCommand
            Dim Cmd As DbCommand = CreateCommand(sqlStmt)
            Dim array__1 As Array = Array.CreateInstance(GetType(DbParameter), parameters.Count)
            parameters.CopyTo(array__1, 0)
            Cmd.Parameters.AddRange(array__1)
            Return Cmd
        End Function

        ''' <summary>
        ''' Creates an instance of the Database Command Parameter
        ''' </summary>
        ''' <param name="parameterName">Name Of the Parameter</param>
        ''' <param name="dataType">Data Type of the Parameter</param>
        ''' <returns></returns>
        Public Function CreateParameter(ByVal parameterName As String, ByVal dataType As DbType) As DbParameter
            Dim Parameter As DbParameter = _factory.CreateParameter()
            Parameter.ParameterName = CreateParameterName(parameterName)
            Parameter.DbType = dataType
            Return Parameter
        End Function
        ''' <summary>
        ''' Creates an instance of the Database Command Parameter
        ''' </summary>
        ''' <param name="parameterName">Name Of the Parameter</param>
        ''' <param name="dataType">Data Type of the Parameter</param>
        ''' <param name="size"></param>
        ''' <returns></returns>
        Public Function CreateParameter(ByVal parameterName As String, ByVal dataType As DbType, ByVal size As Integer) As DbParameter
            Dim Parameter As DbParameter = CreateParameter(parameterName, dataType)
            Parameter.Size = size
            Return Parameter
        End Function
        ''' <summary>
        ''' Creates an instance of the Database Command Parameter
        ''' </summary>
        ''' <param name="parameterName">Name Of the Parameter</param>
        ''' <param name="dataType">Data Type of the Parameter</param>
        ''' <param name="size">Maximum Size of the Parameter Value</param>
        ''' <param name="direction"></param>
        ''' <returns></returns>
        Public Function CreateParameter(ByVal parameterName As String, ByVal dataType As DbType, ByVal size As Integer, ByVal direction As ParameterDirection) As DbParameter
            Dim Parameter As DbParameter = CreateParameter(parameterName, dataType, size)
            Parameter.Direction = direction
            Return Parameter
        End Function
        ''' <summary>
        ''' Creates an instance of the Database Command Parameter
        ''' </summary>
        ''' <param name="parameterName">Name Of the Parameter</param>
        ''' <param name="dataType">Data Type of the Parameter</param>
        ''' <param name="sourceColumn"></param>
        ''' <returns></returns>
        Public Function CreateParameter(ByVal parameterName As String, ByVal dataType As DbType, ByVal sourceColumn As String) As DbParameter
            Dim Parameter As DbParameter = CreateParameter(parameterName, dataType)
            Parameter.SourceColumn = sourceColumn
            Return Parameter
        End Function
        ''' <summary>
        ''' Creates an instance of the Database Command Parameter
        ''' </summary>
        ''' <param name="parameterName">Name Of the Parameter</param>
        ''' <param name="dataType">Data Type of the Parameter</param>
        ''' <param name="size">Maximum Size of the Parameter Value</param>
        ''' <param name="sourceColumn"></param>
        ''' <returns></returns>
        Public Function CreateParameter(ByVal parameterName As String, ByVal dataType As DbType, ByVal size As Integer, ByVal sourceColumn As String) As DbParameter
            Dim Parameter As DbParameter = CreateParameter(parameterName, dataType, size)
            Parameter.SourceColumn = sourceColumn
            Return Parameter
        End Function

        Public Function ExecuteReader(ByVal Cmd As DbCommand) As DbDataReader
            Cmd.Connection = OpenConnection()
            Return Cmd.ExecuteReader(CommandBehavior.CloseConnection)
        End Function
        Public Function ExecuteReader(ByVal sqlStmt As String) As DbDataReader
            Dim Cmd As DbCommand = CreateCommand(sqlStmt)
            Return ExecuteReader(Cmd)
        End Function
        Public Function ExecuteScalar(ByVal cmd As DbCommand) As Object
            Dim Result As Object = Nothing
            Dim Conn As DbConnection = OpenConnection()
            cmd.Connection = Conn
            Result = cmd.ExecuteScalar()
            Conn.Close()
            Conn.Dispose()
            cmd.Dispose()

            Return Result
        End Function
        Public Function ExecuteScalar(ByVal cmd As DbCommand, ByVal transction As DbTransaction) As Object
            Dim Result As Object = Nothing
            Dim Conn As DbConnection = transction.Connection
            cmd.Connection = Conn
            cmd.Transaction = transction
            Result = cmd.ExecuteScalar()

            Return Result
        End Function

        Public Function ExecuteScalar(ByVal SQL As String) As Object
            Return ExecuteScalar(CreateCommand(SQL))
        End Function

        Public Function ExecuteNonQuery(ByVal cmd As DbCommand) As Integer
            Dim Result As Integer = 0
            Dim Conn As DbConnection = OpenConnection()
            cmd.Connection = Conn
            Result = cmd.ExecuteNonQuery()
            Conn.Close()
            Conn.Dispose()

            Return Result
        End Function

        Public Function ExecuteNonQuery(ByVal SQL As String) As Integer
            Dim result As Integer

            result = ExecuteNonQuery(CreateCommand(SQL))

            Return result
        End Function

        Public Function ExecuteNonQuery(ByVal cmd As DbCommand, ByVal transction As DbTransaction) As Integer
            Dim Result As Integer = 0
            Dim Conn As DbConnection = transction.Connection
            cmd.Connection = Conn
            cmd.Transaction = transction
            Result = cmd.ExecuteNonQuery()
            Return Result
        End Function
        Public Function FillDataset(ByVal ds As DataSet, ByVal table As String, ByVal cmd As DbCommand) As Integer
            Dim Dt As DataTable = Nothing

            Dim idx As Integer = ds.Tables.IndexOf(table)
            If idx < 0 Then
                Dt = New DataTable(table)
                ds.Tables.Add(table)
            Else
                Dt = ds.Tables(idx)
            End If
            Return FillDataset(Dt, cmd)
        End Function

        Public Function FillDataset(ByVal dt As DataTable, ByVal cmd As DbCommand) As Integer
            Dim Conn As DbConnection = OpenConnection()
            cmd.Connection = Conn
            Dim DataAdapter As DbDataAdapter = _factory.CreateDataAdapter()
            DataAdapter.SelectCommand = cmd
            Dim Result As Integer = DataAdapter.Fill(dt)
            Conn.Close()
            Conn.Dispose()
            DataAdapter.Dispose()
            Return Result
        End Function

        Public Function FillDataset(ByVal dt As DataTable, ByVal strSql As String) As Integer
            Return FillDataset(dt, CreateCommand(strSql))
        End Function

        Public Function UpdateSource(ByVal ds As DataSet, ByVal Table As String, ByVal cmdInsert As DbCommand, ByVal cmdUpdate As DbCommand, ByVal cmdDelete As DbCommand) As Integer
            Dim idx As Integer = ds.Tables.IndexOf(Table)
            If idx < 0 Then
                Return 0
            End If
            Dim Dt As DataTable = ds.Tables(idx)
            Return UpdateSource(Dt, cmdInsert, cmdUpdate, cmdDelete)
        End Function
        Public Function UpdateSource(ByVal dt As DataTable, ByVal cmdInsert As DbCommand, ByVal cmdUpdate As DbCommand, ByVal cmdDelete As DbCommand) As Integer
            Dim Result As Integer = 0
            Dim Conn As DbConnection = OpenConnection()
            Dim Transaction As DbTransaction = Conn.BeginTransaction(IsolationLevel.Serializable)
            Try
                Result = UpdateSource(dt, cmdInsert, cmdUpdate, cmdDelete, Transaction)
                Transaction.Commit()
            Catch ex As DbException

                Transaction.Rollback()
            End Try

            Conn.Close()
            Conn.Dispose()
            Transaction.Dispose()
            Return Result
        End Function
        Public Function UpdateSource(ByVal dt As DataTable, ByVal cmdInsert As DbCommand, ByVal cmdUpdate As DbCommand, ByVal cmdDelete As DbCommand, ByVal transaction As DbTransaction) As Integer
            Dim Conn As DbConnection = transaction.Connection
            Using DataAdapter As DbDataAdapter = _factory.CreateDataAdapter()
                If cmdInsert IsNot Nothing Then
                    cmdInsert.Connection = Conn
                    cmdInsert.Transaction = transaction
                    DataAdapter.InsertCommand = cmdInsert
                End If
                If cmdUpdate IsNot Nothing Then
                    cmdUpdate.Connection = Conn
                    DataAdapter.UpdateCommand = cmdUpdate
                End If
                If cmdDelete IsNot Nothing Then
                    cmdDelete.Connection = Conn
                    DataAdapter.DeleteCommand = cmdDelete
                End If
                Dim result As Integer = DataAdapter.Update(dt)
                Return result
            End Using
        End Function
        Public Shared Function CreateInstance(ByVal dataBaseTypeName As String, ByVal connectionString As String) As Database
            Dim dataBaseType As Type = Type.[GetType](dataBaseTypeName)
            If dataBaseType Is Nothing Then
                Throw New ArgumentException("Database Type is not known", "dataBaseTypeName")
            End If
            If Not GetType(Database).IsAssignableFrom(dataBaseType) Then
                Throw New ArgumentException("Invalid Database Type", "dataBaseTypeName")
            End If
            Dim parameters As Object() = {connectionString}
            Dim DB As Database = TryCast(Activator.CreateInstance(dataBaseType, parameters), Database)
            Return DB
        End Function

        ''' <summary>
        ''' Creates a Data Table representing the Database Table
        ''' </summary>
        ''' <param name="tableName">Name of the database table</param>
        ''' <returns>A datatable with representation of the Database table</returns>
        Public MustOverride Function CreateSchema(ByVal tableName As String) As DataTable

        ''' <summary>
        ''' Get the Provider Factory
        ''' </summary>
        Public ReadOnly Property ProviderFactory() As DbProviderFactory
            Get
                Return _factory
            End Get
        End Property

        'Added on 13/11/2007
        'Create Adapter for Updating DataTable
        Public Function CreateAdapter(ByVal sqlStmt As String) As DbDataAdapter
            Dim cmd As DbCommand = CreateCommand(sqlStmt)
            cmd.Connection = CreateConnection()
            Return CreateAdapter(cmd)
        End Function

        Public Function CreateAdapter(ByVal cmd As DbCommand) As DbDataAdapter
            Dim adapter As DbDataAdapter = _factory.CreateDataAdapter()
            adapter.SelectCommand = cmd
            Using cb As DbCommandBuilder = _factory.CreateCommandBuilder()
                cb.DataAdapter = adapter
            End Using
            Return adapter
        End Function

    End Class
End Namespace