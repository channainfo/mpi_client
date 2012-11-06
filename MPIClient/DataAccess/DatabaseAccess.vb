Imports System
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data
Imports System.Data.Common
Imports System.Text

Namespace DataAccess
    Public Class DatabaseAccess
        Protected _db As Database
        'public event ProcessDoneHandler UpdateCompleted;

        Public Sub New()
            _db = Database.CreateInstance(ConfigManager.GetConfiguarationValue(ConfigManager.CONFIG_DATABASE_TYPE), ConfigManager.GetConnectionString(ConfigManager.CONFIG_CONNECTION_STRING))
        End Sub

        Public ReadOnly Property Database() As Database
            Get
                Return _db
            End Get
        End Property

    End Class
End Namespace