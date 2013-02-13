Imports System.Windows.Forms
Imports System.Threading

Public Class CustomMessageBox
    Private khfont As Font

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles okButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelButton.Click, cancelButton.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub InfoMessageBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        khfont = New Font("Khmer OS System", 10)
        If Thread.CurrentThread.CurrentUICulture.Name = "km-KH" Then
            okButton.Font = khfont
            cancelButton.Font = khfont
            'Me.Font = khfont
            textMessage.Font = khfont
        End If
    End Sub
    Public Function display(ByVal message As String) As DialogResult
        textMessage.Text = message
        messageBoxIcon.Image = System.Drawing.SystemIcons.Information.ToBitmap()
        Return Me.ShowDialog()
    End Function
    Public Function display(ByVal message As String, ByVal title As String) As DialogResult
        Me.Text = title
        textMessage.Text = message
        messageBoxIcon.Image = System.Drawing.SystemIcons.Information.ToBitmap()
        Return Me.ShowDialog()
    End Function
    Public Function display(ByVal message As String, ByVal title As String, ByVal iconType As MessageBoxIcon) As DialogResult
        textMessage.Text = message
        Me.Text = title
        Select Case iconType
            Case Windows.Forms.MessageBoxIcon.Information
                messageBoxIcon.Image = System.Drawing.SystemIcons.Information.ToBitmap()
            Case Windows.Forms.MessageBoxIcon.Error
                messageBoxIcon.Image = System.Drawing.SystemIcons.Error.ToBitmap()
            Case Windows.Forms.MessageBoxIcon.Warning
                messageBoxIcon.Image = System.Drawing.SystemIcons.Warning.ToBitmap()
            Case Else

        End Select

        Return Me.ShowDialog()
    End Function
    Public Function display(ByVal message As String, ByVal title As String, ByVal buttonType As MessageBoxButtons, ByVal iconType As MessageBoxIcon) As DialogResult
        textMessage.Text = message
        Me.Text = title
        Select Case iconType
            Case Windows.Forms.MessageBoxIcon.Information
                messageBoxIcon.Image = System.Drawing.SystemIcons.Information.ToBitmap()
            Case Windows.Forms.MessageBoxIcon.Error
                messageBoxIcon.Image = System.Drawing.SystemIcons.Error.ToBitmap()
            Case Windows.Forms.MessageBoxIcon.Warning
                messageBoxIcon.Image = System.Drawing.SystemIcons.Warning.ToBitmap()
            Case Windows.Forms.MessageBoxIcon.Question
                messageBoxIcon.Image = System.Drawing.SystemIcons.Question.ToBitmap()
            Case Else

        End Select


        Select Case buttonType
            Case MessageBoxButtons.OK
                okButton.Left = cancelButton.Left
                cancelButton.Visible = False
            Case MessageBoxButtons.AbortRetryIgnore
                okButton.Visible = False
            Case MessageBoxButtons.OKCancel

            Case Else

        End Select


        Return Me.ShowDialog()
    End Function
End Class
