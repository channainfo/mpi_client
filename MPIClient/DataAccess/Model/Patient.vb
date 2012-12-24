Imports System.Reflection

Namespace DataAccess.Model
    Public Class Patient
        Public Enum GenderEnum
            Male = 1
            Female = 2
        End Enum
        Private _id As String
        Private _fingerprintImage As String
        Private _fingerprint_r1 As Array
        Private _fingerprint_r2 As Array
        Private _fingerprint_r3 As Array
        Private _fingerprint_r4 As Array
        Private _fingerprint_r5 As Array
        Private _fingerprint_l1 As Array
        Private _fingerprint_l2 As Array
        Private _fingerprint_l3 As Array
        Private _fingerprint_l4 As Array
        Private _fingerprint_l5 As Array
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
        Public Property Fingerprint_r1() As Array
            Get
                Return _fingerprint_r1
            End Get
            Set(ByVal value As Array)
                _fingerprint_r1 = value
            End Set
        End Property
        Public Property Fingerprint_r2() As Array
            Get
                Return _fingerprint_r2
            End Get
            Set(ByVal value As Array)
                _fingerprint_r2 = value
            End Set
        End Property
        Public Property Fingerprint_r3() As Array
            Get
                Return _fingerprint_r3
            End Get
            Set(ByVal value As Array)
                _fingerprint_r3 = value
            End Set
        End Property
        Public Property Fingerprint_r4() As Array
            Get
                Return _fingerprint_r4
            End Get
            Set(ByVal value As Array)
                _fingerprint_r4 = value
            End Set
        End Property
        Public Property Fingerprint_r5() As Array
            Get
                Return _fingerprint_r5
            End Get
            Set(ByVal value As Array)
                _fingerprint_r5 = value
            End Set
        End Property
        Public Property Fingerprint_l1() As Array
            Get
                Return _fingerprint_l1
            End Get
            Set(ByVal value As Array)
                _fingerprint_l1 = value
            End Set
        End Property
        Public Property Fingerprint_l2() As Array
            Get
                Return _fingerprint_l2
            End Get
            Set(ByVal value As Array)
                _fingerprint_l2 = value
            End Set
        End Property
        Public Property Fingerprint_l3() As Array
            Get
                Return _fingerprint_l3
            End Get
            Set(ByVal value As Array)
                _fingerprint_l3 = value
            End Set
        End Property
        Public Property Fingerprint_l4() As Array
            Get
                Return _fingerprint_l4
            End Get
            Set(ByVal value As Array)
                _fingerprint_l4 = value
            End Set
        End Property
        Public Property Fingerprint_l5() As Array
            Get
                Return _fingerprint_l5
            End Get
            Set(ByVal value As Array)
                _fingerprint_l5 = value
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
        Public Function getFingerprintsInPriority() As List(Of Array)
            Dim result As New List(Of Array)
            If Not Fingerprint_r1 Is Nothing Then
                result.Add(Fingerprint_r1)
            End If
            If Not Fingerprint_l1 Is Nothing Then
                result.Add(Fingerprint_l1)
            End If
            If Not Fingerprint_r2 Is Nothing Then
                result.Add(Fingerprint_r2)
            End If
            If Not Fingerprint_l2 Is Nothing Then
                result.Add(Fingerprint_l2)
            End If
            If Not Fingerprint_r3 Is Nothing Then
                result.Add(Fingerprint_r3)
            End If
            If Not Fingerprint_l3 Is Nothing Then
                result.Add(Fingerprint_l3)
            End If
            If Not Fingerprint_r4 Is Nothing Then
                result.Add(Fingerprint_r4)
            End If
            If Not Fingerprint_l4 Is Nothing Then
                result.Add(Fingerprint_l4)
            End If
            If Not Fingerprint_r5 Is Nothing Then
                result.Add(Fingerprint_r5)
            End If
            If Not Fingerprint_l5 Is Nothing Then
                result.Add(Fingerprint_l5)
            End If
            Return result
        End Function
    End Class
End Namespace