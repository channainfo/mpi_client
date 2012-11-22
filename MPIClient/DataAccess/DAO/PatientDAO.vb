Imports System.Data.Common
Imports MPIClient.DataAccess.Model
Namespace DataAccess.DAO
    Public Class PatientDAO
        Inherits DatabaseAccess
        Enum Synchronization
            All
            NonSyn
        End Enum
        Public Const FINGERPRINT_IMAGE As String = "fingerprint_image"
        Public Const FINGERPRINT As String = "fingerprint"
        Public Const FINGERPRINT2 As String = "fingerprint2"
        Public Const OLD_PATIENT_ID As String = "old_patient_id"
        Public Const PATIENT_ID As String = "patient_id"
        Public Const NEW_PATIENT_ID As String = "new_patient_id"
        Public Const GENDER_COL As String = "gender"
        Public Const DATE_OF_BIRTH As String = "date_of_birth"
        Public Const SYN As String = "syn"
        Public Sub New()
            MyBase.New()
        End Sub

        Public Function Add(ByVal patient As Patient, ByRef patientID As String) As Integer
            Dim result As Integer = 0

            Dim command As DbCommand
            Try
                command = Database.CreateCommand(Constant.GeneralConstants.SP_INSERT_NEW_PATIENT)
                command.CommandType = CommandType.StoredProcedure

                Dim parameter As DbParameter

                parameter = Database.CreateParameter(Database.CreateParameterName(FINGERPRINT), DbType.Binary)
                parameter.Value = patient.Fingerprint
                command.Parameters.Add(parameter)

                parameter = Database.CreateParameter(Database.CreateParameterName(FINGERPRINT2), DbType.Binary)
                parameter.Value = patient.Fingerprint2
                command.Parameters.Add(parameter)

                parameter = Database.CreateParameter(Database.CreateParameterName(GENDER_COL), DbType.Int16)
                parameter.Value = patient.Gender
                command.Parameters.Add(parameter)

                patientID = Database.ExecuteScalar(command)
                result = 1
            Catch ex As Exception
                result = -1
            End Try

            Return result
        End Function
        Public Function Update(ByVal oldPatientID As String, ByVal patient As Patient)
            Dim result As String = 0

            Dim command As DbCommand
            Dim transaction As DbTransaction = Database.OpenConnection().BeginTransaction()
            Try


                command = Database.CreateCommand(Constant.GeneralConstants.SP_UPDATE_PATIENT)
                command.CommandType = CommandType.StoredProcedure

                Dim parameter As DbParameter

                parameter = Database.CreateParameter(Database.CreateParameterName(OLD_PATIENT_ID), DbType.String)
                parameter.Value = oldPatientID
                command.Parameters.Add(parameter)

                parameter = Database.CreateParameter(Database.CreateParameterName(NEW_PATIENT_ID), DbType.String)
                parameter.Value = patient.PatientID
                command.Parameters.Add(parameter)

                parameter = Database.CreateParameter(Database.CreateParameterName(GENDER_COL), DbType.String)
                parameter.Value = patient.Gender
                command.Parameters.Add(parameter)

                parameter = Database.CreateParameter(Database.CreateParameterName(DATE_OF_BIRTH), DbType.String)
                parameter.Value = patient.DateBirth
                command.Parameters.Add(parameter)

                parameter = Database.CreateParameter(Database.CreateParameterName(SYN), DbType.Boolean)
                parameter.Value = patient.Syn
                command.Parameters.Add(parameter)

                result = Database.ExecuteNonQuery(command, transaction)

                If patient.Visits.Count > 0 Then
                    Dim visitDao As New VisitDAO
                    visitDao.Add(patient.Visits, transaction)
                End If

                transaction.Commit()

            Catch ex As Exception
                transaction.Rollback()
                result = -1
            End Try

            Return result
        End Function
        Public Function updatePatientStatusToSyn(ByVal patientID As String) As Integer
            Dim result As String = 0

            Dim command As DbCommand
            Try
                command = Database.CreateCommand(Constant.GeneralConstants.SP_UPDATE_PATIENT_STATUS_TO_SYN)
                command.CommandType = CommandType.StoredProcedure

                Dim parameter As DbParameter

                parameter = Database.CreateParameter(Database.CreateParameterName(PATIENT_ID), DbType.String)
                parameter.Value = patientID
                command.Parameters.Add(parameter)

                result = Database.ExecuteNonQuery(command)

            Catch ex As Exception
                result = -1
            End Try

            Return result

        End Function
        Public Function updatePatientID(ByVal oldPatientID As String, ByVal newPatientID As String) As Integer
            Dim result As String = 0

            Dim command As DbCommand
            Try
                command = Database.CreateCommand(Constant.GeneralConstants.SP_UPDATE_PATIENT_ID)
                command.CommandType = CommandType.StoredProcedure

                Dim parameter As DbParameter

                parameter = Database.CreateParameter(Database.CreateParameterName(OLD_PATIENT_ID), DbType.String)
                parameter.Value = oldPatientID
                command.Parameters.Add(parameter)

                parameter = Database.CreateParameter(Database.CreateParameterName(NEW_PATIENT_ID), DbType.String)
                parameter.Value = newPatientID
                command.Parameters.Add(parameter)

                result = Database.ExecuteNonQuery(command)

            Catch ex As Exception
                result = -1
            End Try

            Return result

        End Function
        Public Function getAll(Optional ByVal synOption As Synchronization = Synchronization.All) As List(Of Patient)
            Dim reader As DbDataReader = Nothing
            If synOption = Synchronization.All Then
                reader = getDataReaderOfAllPatients()
            ElseIf synOption = Synchronization.NonSyn Then
                reader = getDataReaderOfAllNonSynPatients()
            End If
            Dim patients As List(Of Patient) = BuildPatients(reader)

            Return patients
        End Function
        Public Function getMatchedPatients(ByVal fingerPrint As Array, ByVal fingerprintUtil As FingerprintUtil, ByVal gender As Int16, Optional ByVal synOption As Synchronization = Synchronization.All) As List(Of Patient)
            Dim reader As DbDataReader = Nothing
            If synOption = Synchronization.All Then
                reader = getDataReaderOfAllPatients(gender)
            ElseIf synOption = Synchronization.NonSyn Then
                reader = getDataReaderOfAllNonSynPatients(gender)
            End If

            Dim patientList As New List(Of Patient)()
            Dim score As Integer
            fingerprintUtil.setSourceFingerprint(fingerPrint)
            Try
                While reader.Read()
                    Dim patient As New Patient()
                    patient.PatientID = Convert.ToString(reader("id"))
                    patient.FingerprintImage = Convert.ToString(reader("fingerprint_image"))
                    patient.Fingerprint = reader("fingerprint")
                    patient.Gender = Convert.ToInt16(reader("gender"))
                    patient.DateBirth = Convert.ToString(reader("date_of_birth"))
                    patient.Syn = Convert.ToBoolean(reader("syn"))
                    patient.NumVisit = Convert.ToInt32(reader("num_visit"))
                    patient.Createdate = Convert.ToString(reader("createdate"))
                    patient.Updatedate = Convert.ToString(reader("updatedate"))
                    If (fingerprintUtil.indentifyFingerprint(patient.Fingerprint, score)) Then
                        patientList.Add(patient)
                    End If
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
            Return patientList
        End Function
        Private Function getDataReaderOfAllPatients() As DbDataReader
            Dim command As DbCommand
            command = Database.CreateCommand(Constant.GeneralConstants.SP_GET_ALL_PATIENTS)
            command.CommandType = CommandType.StoredProcedure

            Dim reader As DbDataReader = Database.ExecuteReader(command)
            Return reader
        End Function
        Private Function getDataReaderOfAllPatients(ByVal gender As Int16) As DbDataReader
            Dim command As DbCommand
            command = Database.CreateCommand(Constant.GeneralConstants.SP_GET_ALL_PATIENTS_BY_GENDER)
            command.CommandType = CommandType.StoredProcedure

            Dim parameter As DbParameter

            parameter = Database.CreateParameter(Database.CreateParameterName(GENDER_COL), DbType.Int16)
            parameter.Value = gender
            command.Parameters.Add(parameter)

            Dim reader As DbDataReader = Database.ExecuteReader(command)
            Return reader
        End Function
        Private Function getDataReaderOfAllNonSynPatients() As DbDataReader
            Dim command As DbCommand
            command = Database.CreateCommand(Constant.GeneralConstants.SP_GET_ALL_NONSYN_PATIENTS)
            command.CommandType = CommandType.StoredProcedure

            Dim reader As DbDataReader = Database.ExecuteReader(command)
            Return reader
        End Function

        Private Function getDataReaderOfAllNonSynPatients(ByVal gender As Int16) As DbDataReader
            Dim command As DbCommand
            command = Database.CreateCommand(Constant.GeneralConstants.SP_GET_ALL_NONSYN_PATIENTS_BY_GENDER)
            command.CommandType = CommandType.StoredProcedure

            Dim parameter As DbParameter

            parameter = Database.CreateParameter(Database.CreateParameterName(GENDER_COL), DbType.Int16)
            parameter.Value = gender
            command.Parameters.Add(parameter)

            Dim reader As DbDataReader = Database.ExecuteReader(command)
            Return reader
        End Function
        Public Function BuildPatients(ByVal reader As DbDataReader) As List(Of Patient)
            Dim patientList As New List(Of Patient)()

            Try
                While reader.Read()
                    Dim patient As New Patient()
                    patient.PatientID = Convert.ToString(reader("id"))
                    patient.FingerprintImage = Convert.ToString(reader("fingerprint_image"))
                    patient.Fingerprint = reader("fingerprint")
                    patient.Fingerprint2 = reader("fingerprint2")
                    patient.Gender = Convert.ToString(reader("gender"))
                    patient.DateBirth = Convert.ToString(reader("date_of_birth"))
                    patient.Syn = Convert.ToBoolean(reader("syn"))
                    patient.Createdate = Convert.ToString(reader("createdate"))
                    patient.Updatedate = Convert.ToString(reader("updatedate"))

                    patientList.Add(patient)
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
            Return patientList
        End Function
    End Class

End Namespace
