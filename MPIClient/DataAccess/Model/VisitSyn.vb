Namespace DataAccess.Model
    Public Class VisitSyn
        Public Enum Service
            VCCT = 1
            OI_ART = 2
            STD = 3
        End Enum
        Private _id As String
        Private _patientID As String
        Private _age As Integer?
        Private _serviceID As Integer
        Private _siteCode As String
        Private _visitDate As String
        Private _externalCode As String
        Private _externalCode2 As String
        Private _info As String
        Private _syn As Boolean
        Private _createdate As String
        Private _updatedate As String
        Public Property visitid() As String
            Get
                Return _id
            End Get
            Set(ByVal value As String)
                _id = value
            End Set
        End Property
        Public Property patientid() As String
            Get
                Return _patientID
            End Get
            Set(ByVal value As String)
                _patientID = value
            End Set
        End Property
        Public Property age() As Integer?
            Get
                Return _age
            End Get
            Set(ByVal value As Integer?)
                _age = value
            End Set
        End Property
        Public Property serviceid() As Integer
            Get
                Return _serviceID
            End Get
            Set(ByVal value As Integer)
                _serviceID = value
            End Set
        End Property
        Public Property sitecode() As String
            Get
                Return _siteCode
            End Get
            Set(ByVal value As String)
                _siteCode = value
            End Set
        End Property
        Public Property visitdate() As String
            Get
                Return _visitDate
            End Get
            Set(ByVal value As String)
                _visitDate = value
            End Set
        End Property
        Public Property externalcode() As String
            Get
                Return _externalCode
            End Get
            Set(ByVal value As String)
                _externalCode = value
            End Set
        End Property
        Public Property ExternalCode2() As String
            Get
                Return _externalCode2
            End Get
            Set(ByVal value As String)
                _externalCode2 = value
            End Set
        End Property
        Public Property info() As String
            Get
                Return _info
            End Get
            Set(ByVal value As String)
                _info = value
            End Set
        End Property
        Public Property syn() As Boolean
            Get
                Return _syn
            End Get
            Set(ByVal value As Boolean)
                _syn = value
            End Set
        End Property
        Public ReadOnly Property servicename() As String
            Get
                Dim service As Service = _serviceID
                Return service.ToString()
            End Get
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
    End Class
End Namespace