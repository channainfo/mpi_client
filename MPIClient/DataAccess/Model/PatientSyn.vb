Namespace DataAccess.Model
    Public Class PatientSyn
        Public Enum GenderEnum
            Male = 1
            Female = 2
        End Enum
        Private _id As String
        Private _fingerprint_r1 As String
        Private _fingerprint_r2 As String
        Private _fingerprint_r3 As String
        Private _fingerprint_r4 As String
        Private _fingerprint_r5 As String
        Private _fingerprint_l1 As String
        Private _fingerprint_l2 As String
        Private _fingerprint_l3 As String
        Private _fingerprint_l4 As String
        Private _fingerprint_l5 As String
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

        Public Property fingerprint_r1() As String
            Get
                Return _fingerprint_r1
            End Get
            Set(ByVal value As String)
                _fingerprint_r1 = value
            End Set
        End Property
        Public Property fingerprint_r2() As String
            Get
                Return _fingerprint_r2
            End Get
            Set(ByVal value As String)
                _fingerprint_r2 = value
            End Set
        End Property
        Public Property fingerprint_r3() As String
            Get
                Return _fingerprint_r3
            End Get
            Set(ByVal value As String)
                _fingerprint_r3 = value
            End Set
        End Property
        Public Property fingerprint_r4() As String
            Get
                Return _fingerprint_r4
            End Get
            Set(ByVal value As String)
                _fingerprint_r4 = value
            End Set
        End Property
        Public Property fingerprint_r5() As String
            Get
                Return _fingerprint_r5
            End Get
            Set(ByVal value As String)
                _fingerprint_r5 = value
            End Set
        End Property
        Public Property fingerprint_l1() As String
            Get
                Return _fingerprint_l1
            End Get
            Set(ByVal value As String)
                _fingerprint_l1 = value
            End Set
        End Property
        Public Property fingerprint_l2() As String
            Get
                Return _fingerprint_l2
            End Get
            Set(ByVal value As String)
                _fingerprint_l2 = value
            End Set
        End Property
        Public Property fingerprint_l3() As String
            Get
                Return _fingerprint_l3
            End Get
            Set(ByVal value As String)
                _fingerprint_l3 = value
            End Set
        End Property
        Public Property fingerprint_l4() As String
            Get
                Return _fingerprint_l4
            End Get
            Set(ByVal value As String)
                _fingerprint_l4 = value
            End Set
        End Property
        Public Property fingerprint_l5() As String
            Get
                Return _fingerprint_l5
            End Get
            Set(ByVal value As String)
                _fingerprint_l5 = value
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

            If _visits Is Nothing Then
                _visits = New List(Of VisitSyn)
            End If

            For Each visitObject As Visit In visitsData
                Dim visitSynObject As New VisitSyn
                visitSynObject.visitid = visitObject.VisitID
                visitSynObject.visitdate = DateTime.Parse(visitObject.VisitDate).ToString("yyyy-MM-dd HH:mm:ss")
                visitSynObject.updatedate = DateTime.Parse(visitObject.Updatedate).ToString("yyyy-MM-dd HH:mm:ss")
                visitSynObject.syn = visitObject.Syn
                visitSynObject.sitecode = visitObject.SiteCode
                visitSynObject.serviceid = visitObject.ServiceID
                visitSynObject.patientid = visitObject.PatientID
                visitSynObject.info = visitObject.Info
                visitSynObject.externalcode = visitObject.ExternalCode
                visitSynObject.ExternalCode2 = visitObject.ExternalCode2
                visitSynObject.createdate = DateTime.Parse(visitObject.Createdate).ToString("yyyy-MM-dd HH:mm:ss")
                _visits.Add(visitSynObject)
            Next

        End Sub
    End Class
End Namespace
