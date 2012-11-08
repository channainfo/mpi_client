Public Class GenderComboboxItem

    Private _gender As Integer
    Private _genderText As String
    Public Sub New(ByVal gender As Integer, ByVal genderText As String)
        Me._gender = gender
        Me._genderText = genderText
    End Sub

    Public ReadOnly Property Gender() As Integer
        Get
            Return _gender
        End Get
    End Property
    Public ReadOnly Property GenderText() As String
        Get
            Return _genderText
        End Get
    End Property

End Class
