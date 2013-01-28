<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomMessageBox
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomMessageBox))
        Me.okButton = New System.Windows.Forms.Button
        Me.messageBoxIcon = New System.Windows.Forms.PictureBox
        Me.textMessage = New System.Windows.Forms.Label
        Me.cancelButton = New System.Windows.Forms.Button
        CType(Me.messageBoxIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'okButton
        '
        Me.okButton.AccessibleDescription = Nothing
        Me.okButton.AccessibleName = Nothing
        resources.ApplyResources(Me.okButton, "okButton")
        Me.okButton.BackgroundImage = Nothing
        Me.okButton.Font = Nothing
        Me.okButton.Name = "okButton"
        '
        'messageBoxIcon
        '
        Me.messageBoxIcon.AccessibleDescription = Nothing
        Me.messageBoxIcon.AccessibleName = Nothing
        resources.ApplyResources(Me.messageBoxIcon, "messageBoxIcon")
        Me.messageBoxIcon.BackgroundImage = Nothing
        Me.messageBoxIcon.Font = Nothing
        Me.messageBoxIcon.ImageLocation = Nothing
        Me.messageBoxIcon.Name = "messageBoxIcon"
        Me.messageBoxIcon.TabStop = False
        '
        'textMessage
        '
        Me.textMessage.AccessibleDescription = Nothing
        Me.textMessage.AccessibleName = Nothing
        resources.ApplyResources(Me.textMessage, "textMessage")
        Me.textMessage.Font = Nothing
        Me.textMessage.Name = "textMessage"
        '
        'cancelButton
        '
        Me.cancelButton.AccessibleDescription = Nothing
        Me.cancelButton.AccessibleName = Nothing
        resources.ApplyResources(Me.cancelButton, "cancelButton")
        Me.cancelButton.BackgroundImage = Nothing
        Me.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cancelButton.Font = Nothing
        Me.cancelButton.Name = "cancelButton"
        '
        'CustomMessageBox
        '
        Me.AcceptButton = Me.okButton
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.okButton)
        Me.Controls.Add(Me.textMessage)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.messageBoxIcon)
        Me.Font = Nothing
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = Nothing
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CustomMessageBox"
        Me.ShowInTaskbar = False
        CType(Me.messageBoxIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents okButton As System.Windows.Forms.Button
    Friend WithEvents messageBoxIcon As System.Windows.Forms.PictureBox
    Friend WithEvents textMessage As System.Windows.Forms.Label
    Friend WithEvents cancelButton As System.Windows.Forms.Button

End Class
