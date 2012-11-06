Namespace DataAccess.Model
    Public Class Patient

        Private _id As String
        Private _fingerprintImage As String
        Private _fingerprint As Array
        Private _gender As String
        Private _dateOfBirth As String
        Private _syn As Boolean
        Private _createdate As String
        Private _updatedate As String
        Private _numVisit As Integer = 0
        Private _visits As List(Of Visit)
        Public Property PatientID() As String
            Get
                Return _id
            End Get
            Set(ByVal value As String)
                _id = value
            End Set
        End Property
        Public Property FingerprintImage() As String
            Get
                Return _fingerprintImage
            End Get
            Set(ByVal value As String)
                _fingerprintImage = value
            End Set
        End Property
        Public Property Fingerprint() As Array
            Get
                Return _fingerprint
            End Get
            Set(ByVal value As Array)
                _fingerprint = value
            End Set
        End Property
        Public Property Gender() As String
            Get
                Return _gender
            End Get
            Set(ByVal value As String)
                _gender = value
            End Set
        End Property
        Public Property DateBirth() As String
            Get
                Return _dateOfBirth
            End Get
            Set(ByVal value As String)
                _dateOfBirth = value
            End Set
        End Property
        Public Property Syn() As Boolean
            Get
                Return _syn
            End Get
            Set(ByVal value As Boolean)
                _syn = value
            End Set
        End Property
        Public Property Createdate() As String
            Get
                Return _createdate
            End Get
            Set(ByVal value As String)
                _createdate = value
            End Set
        End Property
        Public Property Updatedate() As String
            Get
                Return _updatedate
            End Get
            Set(ByVal value As String)
                _updatedate = value
            End Set
        End Property
        Public Property NumVisit() As Integer
            Get
                Return _numVisit
            End Get
            Set(ByVal value As Integer)
                _numVisit = value
            End Set
        End Property
        Public Property Visits() As List(Of Visit)
            Get
                Return _visits
            End Get
            Set(ByVal value As List(Of Visit))
                _visits = value
                NumVisit = value.Count
            End Set
        End Property

    End Class
End Namespace