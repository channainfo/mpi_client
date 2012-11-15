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
        Private _visits As List(Of Visit)
        Public Property PatientID() As String
            Get
                Return _id
            End Get
            Set(ByVal value As String)
                _id = value
            End Set
        End Property

        Public Property Fingerprint() As String
            Get
                Return _fingerprint
            End Get
            Set(ByVal value As String)
                _fingerprint = value
            End Set
        End Property
        Public Property Fingerprint2() As String
            Get
                Return _fingerprint2
            End Get
            Set(ByVal value As String)
                _fingerprint2 = value
            End Set
        End Property
        Public Property Gender() As Integer
            Get
                Return _gender
            End Get
            Set(ByVal value As Integer)
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

        Public Property Visits() As List(Of Visit)
            Get
                Return _visits
            End Get
            Set(ByVal value As List(Of Visit))
                _visits = value
            End Set
        End Property

    End Class
End Namespace
