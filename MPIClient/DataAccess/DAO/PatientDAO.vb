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
        Public Const FINGERPRINT_R1 As String = "fingerprint_r1"
        Public Const FINGERPRINT_R2 As String = "fingerprint_r2"
        Public Const FINGERPRINT_R3 As String = "fingerprint_r3"
        Public Const FINGERPRINT_R4 As String = "fingerprint_r4"
        Public Const FINGERPRINT_R5 As String = "fingerprint_r5"
        Public Const FINGERPRINT_L1 As String = "fingerprint_l1"
        Public Const FINGERPRINT_L2 As String = "fingerprint_l2"
        Public Const FINGERPRINT_L3 As String = "fingerprint_l3"
        Public Const FINGERPRINT_L4 As String = "fingerprint_l4"
        Public Const FINGERPRINT_L5 As String = "fingerprint_l5"

        Public Const OLD_PATIENT_ID As String = "old_patient_id"
        Public Const PATIENT_ID As String = "patient_id"
        Public Const NEW_PATIENT_ID As String = "new_patient_id"
        Public Const GENDER_COL As String = "gender"
        Public Const AGE_COL As String = "age"
        Public Const SITE_CODE As String = "site_code"
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

                parameter = Database.CreateParameter(Database.CreateParameterName(FINGERPRINT_R1), DbType.Binary)
                parameter.Value = patient.Fingerprint_r1
                command.Parameters.Add(parameter)

                parameter = Database.CreateParameter(Database.CreateParameterName(FINGERPRINT_R2), DbType.Binary)
                parameter.Value = patient.Fingerprint_r2
                command.Parameters.Add(parameter)

                parameter = Database.CreateParameter(Database.CreateParameterName(FINGERPRINT_R3), DbType.Binary)
                parameter.Value = patient.Fingerprint_r3
                command.Parameters.Add(parameter)

                parameter = Database.CreateParameter(Database.CreateParameterName(FINGERPRINT_R4), DbType.Binary)
                parameter.Value = patient.Fingerprint_r4
                command.Parameters.Add(parameter)
                parameter = Database.CreateParameter(Database.CreateParameterName(FINGERPRINT_R5), DbType.Binary)
                parameter.Value = patient.Fingerprint_r5
                command.Parameters.Add(parameter)

                parameter = Database.CreateParameter(Database.CreateParameterName(FINGERPRINT_L1), DbType.Binary)
                parameter.Value = patient.Fingerprint_l1
                command.Parameters.Add(parameter)
                parameter = Database.CreateParameter(Database.CreateParameterName(FINGERPRINT_L2), DbType.Binary)
                parameter.Value = patient.Fingerprint_l2
                command.Parameters.Add(parameter)

                parameter = Database.CreateParameter(Database.CreateParameterName(FINGERPRINT_L3), DbType.Binary)
                parameter.Value = patient.Fingerprint_l3
                command.Parameters.Add(parameter)
                parameter = Database.CreateParameter(Database.CreateParameterName(FINGERPRINT_L4), DbType.Binary)
                parameter.Value = patient.Fingerprint_l4
                command.Parameters.Add(parameter)

                parameter = Database.CreateParameter(Database.CreateParameterName(FINGERPRINT_L5), DbType.Binary)
                parameter.Value = patient.Fingerprint_l5
                command.Parameters.Add(parameter)

                parameter = Database.CreateParameter(Database.CreateParameterName(GENDER_COL), DbType.Int32)
                parameter.Value = patient.Gender
                command.Parameters.Add(parameter)

                parameter = Database.CreateParameter(Database.CreateParameterName(SITE_CODE), DbType.String)
                parameter.Value = patient.SiteCode
                command.Parameters.Add(parameter)

                patientID = Database.ExecuteScalar(command)
                result = 1
            Catch ex As Exception
                result = -1
            End Try

            Return result
        End Function
        Public Function Update(ByVal oldPatientID As String, ByVal patient As Patient, Optional ByVal isDeleteVisits As Boolean = True) As Integer
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

                parameter = Database.CreateParameter(Database.CreateParameterName(AGE_COL), DbType.Int32)
                parameter.Value = patient.Age
                command.Parameters.Add(parameter)

                parameter = Database.CreateParameter(Database.CreateParameterName(SITE_CODE), DbType.String)
                parameter.Value = patient.SiteCode
                command.Parameters.Add(parameter)

                parameter = Database.CreateParameter(Database.CreateParameterName(DATE_OF_BIRTH), DbType.String)
                parameter.Value = patient.DateBirth
                command.Parameters.Add(parameter)

                parameter = Database.CreateParameter(Database.CreateParameterName(SYN), DbType.Boolean)
                parameter.Value = patient.Syn
                command.Parameters.Add(parameter)

                result = Database.ExecuteNonQuery(command, transaction)
                Dim visitDao As New VisitDAO
                If isDeleteVisits Then
                    visitDao.deletePatientVisits(oldPatientID, transaction)
                End If

                If patient.Visits.Count > 0 Then
                    If visitDao.Add(patient.Visits, transaction) <= 0 Then
                        transaction.Rollback()
                        Return -1
                    End If
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
        Public Function updatePatientAge(ByVal patientID As String, ByVal age As Integer) As Integer
            Dim result As String = 0

            Dim command As DbCommand
            Try
                command = Database.CreateCommand(Constant.GeneralConstants.SP_UPDATE_PATIENT_AGE)
                command.CommandType = CommandType.StoredProcedure

                Dim parameter As DbParameter

                parameter = Database.CreateParameter(Database.CreateParameterName(PATIENT_ID), DbType.String)
                parameter.Value = patientID
                command.Parameters.Add(parameter)

                parameter = Database.CreateParameter(Database.CreateParameterName(AGE_COL), DbType.Int32)
                parameter.Value = age
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
        Public Function getMatchedPatients(ByVal fingerPrint As Array, ByVal fingerprintUtil As FingerprintUtil, ByVal gender As Int32, Optional ByVal synOption As Synchronization = Synchronization.All) As List(Of Patient)
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
                    Dim patient As Patient
                    patient = buildPatient(reader)
                    'patient.PatientID = Convert.ToString(reader("id"))
                    'patient.FingerprintImage = Convert.ToString(reader("fingerprint_image"))
                    ''patient.Fingerprint_r1 = reader(FINGERPRINT_R1)
                    'patient.Gender = Convert.ToInt32(reader("gender"))
                    'patient.DateBirth = Convert.ToString(reader("date_of_birth"))
                    'patient.Syn = Convert.ToBoolean(reader("syn"))
                    'patient.NumVisit = Convert.ToInt32(reader("num_visit"))
                    'patient.Createdate = Convert.ToString(reader("createdate"))
                    'patient.Updatedate = Convert.ToString(reader("updatedate"))

                    If (fingerprintUtil.indentifyFingerprint(patient.Fingerprint_r1, score)) Then
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
        Public Function getMatchedPatients(ByVal sourePatient As Patient, ByVal fingerprintUtil As FingerprintUtil, ByVal gender As Int32, Optional ByVal synOption As Synchronization = Synchronization.All) As List(Of Patient)
            Dim reader As DbDataReader = Nothing
            If synOption = Synchronization.All Then
                reader = getDataReaderOfAllPatients(gender)
            ElseIf synOption = Synchronization.NonSyn Then
                reader = getDataReaderOfAllNonSynPatients(gender)
            End If

            Dim patientList As New List(Of Patient)()
            Dim score As Integer
            fingerprintUtil.setSourceFingerprint(sourePatient.getFingerprintsInPriority(0))
            Try
                While reader.Read()
                    Dim patient As Patient
                    patient = buildPatient(reader)
                    Dim queryFingerprint As Array = fingerprintUtil.getQueryFingerprintInPriority(sourePatient, patient)(0)
                    If (fingerprintUtil.indentifyFingerprint(queryFingerprint, score)) Then
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
        Private Function getDataReaderOfAllPatients(ByVal gender As Int32) As DbDataReader
            Dim command As DbCommand
            command = Database.CreateCommand(Constant.GeneralConstants.SP_GET_ALL_PATIENTS_BY_GENDER)
            command.CommandType = CommandType.StoredProcedure

            Dim parameter As DbParameter

            parameter = Database.CreateParameter(Database.CreateParameterName(GENDER_COL), DbType.Int32)
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

        Private Function getDataReaderOfAllNonSynPatients(ByVal gender As Int32) As DbDataReader
            Dim command As DbCommand
            command = Database.CreateCommand(Constant.GeneralConstants.SP_GET_ALL_NONSYN_PATIENTS_BY_GENDER)
            command.CommandType = CommandType.StoredProcedure

            Dim parameter As DbParameter

            parameter = Database.CreateParameter(Database.CreateParameterName(GENDER_COL), DbType.Int32)
            parameter.Value = gender
            command.Parameters.Add(parameter)

            Dim reader As DbDataReader = Database.ExecuteReader(command)
            Return reader
        End Function
        Private Shared Function buildPatient(ByVal reader As DbDataReader) As Patient
            Dim patient As New Patient()
            patient.PatientID = Convert.ToString(reader("id"))
            patient.FingerprintImage = Convert.ToString(reader("fingerprint_image"))
            patient.Fingerprint_r1 = IIf(IsDBNull(reader(FINGERPRINT_R1)), Nothing, reader(FINGERPRINT_R1))
            patient.Fingerprint_r2 = IIf(IsDBNull(reader(FINGERPRINT_R2)), Nothing, reader(FINGERPRINT_R2))
            patient.Fingerprint_r3 = IIf(IsDBNull(reader(FINGERPRINT_R3)), Nothing, reader(FINGERPRINT_R3))
            patient.Fingerprint_r4 = IIf(IsDBNull(reader(FINGERPRINT_R4)), Nothing, reader(FINGERPRINT_R4))
            patient.Fingerprint_r5 = IIf(IsDBNull(reader(FINGERPRINT_R5)), Nothing, reader(FINGERPRINT_R5))
            patient.Fingerprint_l1 = IIf(IsDBNull(reader(FINGERPRINT_L1)), Nothing, reader(FINGERPRINT_L1))
            patient.Fingerprint_l2 = IIf(IsDBNull(reader(FINGERPRINT_L2)), Nothing, reader(FINGERPRINT_L2))
            patient.Fingerprint_l3 = IIf(IsDBNull(reader(FINGERPRINT_L3)), Nothing, reader(FINGERPRINT_L3))
            patient.Fingerprint_l4 = IIf(IsDBNull(reader(FINGERPRINT_L4)), Nothing, reader(FINGERPRINT_L4))
            patient.Fingerprint_l5 = IIf(IsDBNull(reader(FINGERPRINT_L5)), Nothing, reader(FINGERPRINT_L5))
            patient.Gender = Convert.ToString(reader("gender"))
            patient.Age = IIf(IsDBNull(reader(AGE_COL)), Nothing, reader(AGE_COL))
            patient.DateBirth = Convert.ToString(reader("date_of_birth"))
            patient.Syn = Convert.ToBoolean(reader("syn"))
            patient.NumVisit = Convert.ToInt32(reader("num_visit"))
            patient.Createdate = Convert.ToString(reader("createdate"))
            patient.Updatedate = Convert.ToString(reader("updatedate"))
            Return patient
        End Function
        Public Function BuildPatients(ByVal reader As DbDataReader) As List(Of Patient)
            Dim patientList As New List(Of Patient)()

            Try
                While reader.Read()
                    Dim patient As Patient = buildPatient(reader)

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
