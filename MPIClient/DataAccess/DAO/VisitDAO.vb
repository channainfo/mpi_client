Imports System.Data.Common
Imports MPIClient.DataAccess.Model

Namespace DataAccess.DAO
    Public Class VisitDAO
        Inherits DatabaseAccess
        Enum Synchronization
            All
            NonSyn
        End Enum
        Public Const ID As String = "id"
        Public Const PATIENT_ID As String = "patient_id"
        Public Const AGE As String = "age"
        Public Const SERVICE_ID As String = "service_id"
        Public Const SITE_CODE As String = "site_code"
        Public Const VISIT_DATE As String = "visit_date"
        Public Const EXTERNAL_CODE As String = "external_code"
        Public Const EXTERNAL_CODE2 As String = "external_code2"
        Public Const INFO As String = "info"
        Public Const SYN As String = "syn"
        Private Const OLD_VISIT_ID As String = "old_visit_id"
        Private Const NEW_VISIT_ID As String = "new_visit_id"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Function Add(ByVal visit As Visit, ByRef visitID As String) As Integer
            Dim result As Integer = 0

            Dim command As DbCommand
            Try
                command = Database.CreateCommand(Constant.GeneralConstants.SP_INSERT_NEW_VISIT)
                command.CommandType = CommandType.StoredProcedure

                Dim parameter As DbParameter

                parameter = Database.CreateParameter(Database.CreateParameterName(PATIENT_ID), DbType.String)
                parameter.Value = visit.PatientID
                command.Parameters.Add(parameter)

                parameter = Database.CreateParameter(Database.CreateParameterName(AGE), DbType.Int32)
                parameter.Value = visit.Age
                command.Parameters.Add(parameter)

                parameter = Database.CreateParameter(Database.CreateParameterName(SERVICE_ID), DbType.String)
                parameter.Value = visit.ServiceID
                command.Parameters.Add(parameter)

                parameter = Database.CreateParameter(Database.CreateParameterName(SITE_CODE), DbType.String)
                parameter.Value = visit.SiteCode
                command.Parameters.Add(parameter)

                parameter = Database.CreateParameter(Database.CreateParameterName(VISIT_DATE), DbType.String)
                parameter.Value = visit.VisitDate
                command.Parameters.Add(parameter)

                parameter = Database.CreateParameter(Database.CreateParameterName(EXTERNAL_CODE), DbType.String)
                parameter.Value = visit.ExternalCode
                command.Parameters.Add(parameter)

                parameter = Database.CreateParameter(Database.CreateParameterName(EXTERNAL_CODE2), DbType.String)
                parameter.Value = visit.ExternalCode2
                command.Parameters.Add(parameter)

                parameter = Database.CreateParameter(Database.CreateParameterName(INFO), DbType.String)
                parameter.Value = visit.Info
                command.Parameters.Add(parameter)

                visitID = Database.ExecuteScalar(command)
                result = 1
            Catch ex As Exception
                result = -1
            End Try

            Return result
        End Function
        Public Function Add(ByVal visits As List(Of Visit), ByVal transaction As DbTransaction) As Integer

            Dim datatable As New DataTable("visit")
            datatable.Columns.Add(ID)
            datatable.Columns.Add(PATIENT_ID)
            datatable.Columns.Add(AGE)
            datatable.Columns.Add(SERVICE_ID)
            datatable.Columns.Add(SITE_CODE)
            datatable.Columns.Add(VISIT_DATE)
            datatable.Columns.Add(EXTERNAL_CODE)
            datatable.Columns.Add(EXTERNAL_CODE2)
            datatable.Columns.Add(INFO)
            datatable.Columns.Add(SYN)
            Dim row As DataRow
            For Each visit As Visit In visits
                row = datatable.NewRow
                row(ID) = visit.VisitID
                row(PATIENT_ID) = visit.PatientID
                row(AGE) = visit.Age
                row(SERVICE_ID) = visit.ServiceID
                row(SITE_CODE) = visit.SiteCode
                row(VISIT_DATE) = visit.VisitDate
                row(EXTERNAL_CODE) = visit.ExternalCode
                row(EXTERNAL_CODE2) = visit.ExternalCode2
                row(INFO) = visit.Info
                row(SYN) = 1
                datatable.Rows.Add(row)
            Next
            Dim command As DbCommand = Database.CreateCommand(Constant.GeneralConstants.SP_INSERT_NEW_VISIT_WITH_GIVEN_ID)
            command.CommandType = CommandType.StoredProcedure

            Dim parameter As DbParameter

            parameter = Database.CreateParameter(ID, DbType.String)
            parameter.SourceColumn = ID
            command.Parameters.Add(parameter)

            parameter = Database.CreateParameter(Database.CreateParameterName(PATIENT_ID), DbType.String)
            parameter.SourceColumn = PATIENT_ID
            command.Parameters.Add(parameter)

            parameter = Database.CreateParameter(Database.CreateParameterName(AGE), DbType.Int32)
            parameter.SourceColumn = AGE
            command.Parameters.Add(parameter)

            parameter = Database.CreateParameter(Database.CreateParameterName(SERVICE_ID), DbType.String)
            parameter.SourceColumn = SERVICE_ID
            command.Parameters.Add(parameter)

            parameter = Database.CreateParameter(Database.CreateParameterName(SITE_CODE), DbType.String)
            parameter.SourceColumn = SITE_CODE
            command.Parameters.Add(parameter)

            parameter = Database.CreateParameter(Database.CreateParameterName(VISIT_DATE), DbType.String)
            parameter.SourceColumn = VISIT_DATE
            command.Parameters.Add(parameter)

            parameter = Database.CreateParameter(Database.CreateParameterName(EXTERNAL_CODE), DbType.String)
            parameter.SourceColumn = EXTERNAL_CODE
            command.Parameters.Add(parameter)

            parameter = Database.CreateParameter(Database.CreateParameterName(EXTERNAL_CODE2), DbType.String)
            parameter.SourceColumn = EXTERNAL_CODE2
            command.Parameters.Add(parameter)

            parameter = Database.CreateParameter(Database.CreateParameterName(INFO), DbType.String)
            parameter.SourceColumn = INFO
            command.Parameters.Add(parameter)

            parameter = Database.CreateParameter(Database.CreateParameterName(SYN), DbType.Int32)
            parameter.SourceColumn = SYN
            command.Parameters.Add(parameter)

            Return Database.UpdateSource(datatable, command, Nothing, Nothing, transaction)

        End Function

        Public Function getAll(ByVal patientID As String, Optional ByVal synOption As Synchronization = Synchronization.All) As List(Of Visit)

            Dim reader As DbDataReader = Nothing
            If synOption = Synchronization.All Then
                reader = getDataReaderOfAllVisits(patientID)
            ElseIf synOption = Synchronization.NonSyn Then
                reader = getDataReaderOfAllNonSynVisits(patientID)
            End If
            Dim visits As List(Of Visit) = buildVisits(reader)

            Return visits
        End Function
        Private Function getDataReaderOfAllVisits(ByVal patientID As String) As DbDataReader
            Dim command As DbCommand = Database.CreateCommand(Constant.GeneralConstants.SP_GET_ALL_VISITS)
            command.CommandType = CommandType.StoredProcedure

            Dim parameter As DbParameter = Database.CreateParameter(Database.CreateParameterName(PATIENT_ID), DbType.String)
            parameter.Value = patientID
            command.Parameters.Add(parameter)

            Dim reader As DbDataReader = Database.ExecuteReader(command)
            Return reader
        End Function
        Private Function getDataReaderOfAllNonSynVisits(ByVal patientID As String) As DbDataReader
            Dim command As DbCommand = Database.CreateCommand(Constant.GeneralConstants.SP_GET_ALL_NON_SYN_VISITS)
            command.CommandType = CommandType.StoredProcedure

            Dim parameter As DbParameter = Database.CreateParameter(Database.CreateParameterName(PATIENT_ID), DbType.String)
            parameter.Value = patientID
            command.Parameters.Add(parameter)

            Dim reader As DbDataReader = Database.ExecuteReader(command)
            Return reader
        End Function
        Private Function buildVisits(ByVal reader As DbDataReader) As List(Of Visit)
            Dim visitList As New List(Of Visit)()

            Try
                While reader.Read()
                    Dim visit As New Visit()
                    visit.VisitID = Convert.ToString(reader("id"))
                    visit.Age = IIf(IsDBNull(reader(AGE)), Nothing, reader(AGE))
                    visit.PatientID = Convert.ToString(reader(PATIENT_ID))
                    visit.ServiceID = Convert.ToInt32(reader(SERVICE_ID))
                    visit.SiteCode = Convert.ToString(reader(SITE_CODE))
                    visit.VisitDate = Convert.ToString(reader(VISIT_DATE))
                    visit.ExternalCode = Convert.ToString(reader(EXTERNAL_CODE))
                    visit.ExternalCode2 = Convert.ToString(reader(EXTERNAL_CODE2))
                    visit.Info = Convert.ToString(reader(INFO))
                    visit.Syn = Convert.ToBoolean(reader("syn"))
                    visit.Createdate = Convert.ToString(reader("createdate"))
                    visit.Updatedate = Convert.ToString(reader("updatedate"))

                    visitList.Add(visit)
                End While
            Catch ex As Exception
                Throw ex
            Finally
                If reader IsNot Nothing Then
                    If Not reader.IsClosed Then
                        reader.Close()
                    End If
                    reader.Dispose()
                End If
            End Try
            Return visitList
        End Function

        Public Function updateVisitID(ByVal oldVisitID As String, ByVal newVisitID As String) As Integer
            Dim result As String = 0

            Dim command As DbCommand
            Try
                command = Database.CreateCommand(Constant.GeneralConstants.SP_UPDATE_VISIT_ID)
                command.CommandType = CommandType.StoredProcedure

                Dim parameter As DbParameter

                parameter = Database.CreateParameter(Database.CreateParameterName(OLD_VISIT_ID), DbType.String)
                parameter.Value = oldVisitID
                command.Parameters.Add(parameter)

                parameter = Database.CreateParameter(Database.CreateParameterName(NEW_VISIT_ID), DbType.String)
                parameter.Value = newVisitID
                command.Parameters.Add(parameter)

                result = Database.ExecuteNonQuery(command)

            Catch ex As Exception
                result = -1
            End Try

            Return result

        End Function
        Public Function deletePatientVisits(ByVal patientID As String, ByVal transaction As DbTransaction) As Integer
            Dim result As Integer

            Dim command As DbCommand
            Try
                command = Database.CreateCommand(Constant.GeneralConstants.SP_DELETE_PATIENT_VISITS)
                command.CommandType = CommandType.StoredProcedure

                Dim parameter As DbParameter

                parameter = Database.CreateParameter(Database.CreateParameterName(PATIENT_ID), DbType.String)
                parameter.Value = patientID
                command.Parameters.Add(parameter)

                result = Database.ExecuteNonQuery(command, transaction)

            Catch ex As Exception
                result = -1
            End Try

        End Function

    End Class
End Namespace

