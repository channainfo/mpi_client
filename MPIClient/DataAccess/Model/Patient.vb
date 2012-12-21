Namespace DataAccess.Model
    Public Class Patient
        Public Enum GenderEnum
            Male = 1
            Female = 2
        End Enum
        Private _id As String
        Private _fingerprintImage As String
        Private _finger1Right As Array
        Private _finger2Right As Array
        Private _finger3Right As Array
        Private _finger4Right As Array
        Private _finger5Right As Array
        Private _finger1Left As Array
        Private _finger2Left As Array
        Private _finger3Left As Array
        Private _finger4Left As Array
        Private _finger5Left As Array
        Private _gender As Integer?
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
        Public Property Finger1Right() As Array
            Get
                Return _finger1Right
            End Get
            Set(ByVal value As Array)
                _finger1Right = value
            End Set
        End Property
        Public Property Finger2Right() As Array
            Get
                Return _finger2Right
            End Get
            Set(ByVal value As Array)
                _finger2Right = value
            End Set
        End Property
        Public Property Finger3Right() As Array
            Get
                Return _finger3Right
            End Get
            Set(ByVal value As Array)
                _finger3Right = value
            End Set
        End Property
        Public Property Finger4Right() As Array
            Get
                Return _finger4Right
            End Get
            Set(ByVal value As Array)
                _finger4Right = value
            End Set
        End Property
        Public Property Finger5Right() As Array
            Get
                Return _finger5Right
            End Get
            Set(ByVal value As Array)
                _finger5Right = value
            End Set
        End Property
        Public Property Finger1Left() As Array
            Get
                Return _finger1Left
            End Get
            Set(ByVal value As Array)
                _finger1Left = value
            End Set
        End Property
        Public Property Finger2Left() As Array
            Get
                Return _finger2Left
            End Get
            Set(ByVal value As Array)
                _finger2Left = value
            End Set
        End Property
        Public Property Finger3Left() As Array
            Get
                Return _finger3Left
            End Get
            Set(ByVal value As Array)
                _finger3Left = value
            End Set
        End Property
        Public Property Finger4Left() As Array
            Get
                Return _finger4Left
            End Get
            Set(ByVal value As Array)
                _finger4Left = value
            End Set
        End Property
        Public Property Finger5Left() As Array
            Get
                Return _finger5Left
            End Get
            Set(ByVal value As Array)
                _finger5Left = value
            End Set
        End Property
        Public Property Gender() As Integer?
            Get
                Return _gender
            End Get
            Set(ByVal value As Integer?)
                _gender = value
            End Set
        End Property
        Public ReadOnly Property GenderText() As String
            Get
                Dim genderEnum As GenderEnum
                If _gender Is Nothing Then
                    Return ""
                End If
                genderEnum = _gender
                Return genderEnum.ToString()
            End Get
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