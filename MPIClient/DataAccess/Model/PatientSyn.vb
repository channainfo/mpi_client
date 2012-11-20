Namespace DataAccess.Model
    Public Class PatientSyn
        Public Enum GenderEnum
            Male = 1
            Female = 2
        End Enum
        Private _id As String
        Private _fingerprint As String
        Private _fingerprint2 As String
        Private _gender As Integer
        Private _dateOfBirth As String
        Private _createdate As String
        Private _updatedate As String
        Private _visits As List(Of VisitSyn)
        Public Property patientid() As String
            Get
                Return _id
            End Get
            Set(ByVal value As String)
                _id = value
            End Set
        End Property

        Public Property fingerprint() As String
            Get
                Return _fingerprint
            End Get
            Set(ByVal value As String)
                _fingerprint = value
            End Set
        End Property
        Public Property fingerprint2() As String
            Get
                Return _fingerprint2
            End Get
            Set(ByVal value As String)
                _fingerprint2 = value
            End Set
        End Property
        Public Property gender() As Integer
            Get
                Return _gender
            End Get
            Set(ByVal value As Integer)
                _gender = value
            End Set
        End Property
        
        Public Property datebirth() As String
            Get
                Return _dateOfBirth
            End Get
            Set(ByVal value As String)
                _dateOfBirth = value
            End Set
        End Property

        Public Property createdate() As String
            Get
                Return _createdate
            End Get
            Set(ByVal value As String)
                _createdate = value
            End Set
        End Property
        Public Property updatedate() As String
            Get
                Return _updatedate
            End Get
            Set(ByVal value As String)
                _updatedate = value
            End Set
        End Property

        Public Property visits() As List(Of VisitSyn)
            Get
                Return _visits
            End Get
            Set(ByVal value As List(Of VisitSyn))
                _visits = value
            End Set
        End Property

        Public Sub addVisits(ByVal visitsData As List(Of Visit))
            Dim visitSynObject As New VisitSyn
            For Each visitObject As Visit In visitsData
                visitSynObject.visitid = visitObject.VisitID
                visitSynObject.visitdate = visitObject.VisitDate
                visitSynObject.updatedate = visitObject.Updatedate
                visitSynObject.syn = visitObject.Syn
                visitSynObject.sitecode = visitObject.SiteCode
                visitSynObject.serviceid = visitObject.ServiceID
                visitSynObject.patientid = visitObject.PatientID
                visitSynObject.info = visitObject.Info
                visitSynObject.externalcode = visitObject.ExternalCode
                visitSynObject.createdate = visitObject.Createdate
                _visits.Add(visitSynObject)
            Next

        End Sub
    End Class
End Namespace
