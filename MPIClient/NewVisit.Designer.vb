<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewVisit
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
        Me.patientIDLabel = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.serviceIDTextBox = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.siteCodeTextBox = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.visitDateTextBox = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.externalCodeTextBox = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.infoTextBox = New System.Windows.Forms.TextBox
        Me.saveButton = New System.Windows.Forms.Button
        Me.infoLabel = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'patientIDLabel
        '
        Me.patientIDLabel.AutoSize = True
        Me.patientIDLabel.Location = New System.Drawing.Point(100, 9)
        Me.patientIDLabel.Name = "patientIDLabel"
        Me.patientIDLabel.Size = New System.Drawing.Size(39, 13)
        Me.patientIDLabel.TabIndex = 9
        Me.patientIDLabel.Text = "Label4"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Patient ID:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Service ID:"
        '
        'serviceIDTextBox
        '
        Me.serviceIDTextBox.Location = New System.Drawing.Point(103, 34)
        Me.serviceIDTextBox.Name = "serviceIDTextBox"
        Me.serviceIDTextBox.Size = New System.Drawing.Size(100, 20)
        Me.serviceIDTextBox.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Site Code:"
        '
        'siteCodeTextBox
        '
        Me.siteCodeTextBox.Location = New System.Drawing.Point(103, 60)
        Me.siteCodeTextBox.Name = "siteCodeTextBox"
        Me.siteCodeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.siteCodeTextBox.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 89)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Visit Date:"
        '
        'visitDateTextBox
        '
        Me.visitDateTextBox.Location = New System.Drawing.Point(103, 86)
        Me.visitDateTextBox.Name = "visitDateTextBox"
        Me.visitDateTextBox.Size = New System.Drawing.Size(100, 20)
        Me.visitDateTextBox.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 115)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "External Code:"
        '
        'externalCodeTextBox
        '
        Me.externalCodeTextBox.Location = New System.Drawing.Point(103, 112)
        Me.externalCodeTextBox.Name = "externalCodeTextBox"
        Me.externalCodeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.externalCodeTextBox.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 141)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Info:"
        '
        'infoTextBox
        '
        Me.infoTextBox.Location = New System.Drawing.Point(103, 138)
        Me.infoTextBox.Name = "infoTextBox"
        Me.infoTextBox.Size = New System.Drawing.Size(100, 20)
        Me.infoTextBox.TabIndex = 4
        '
        'saveButton
        '
        Me.saveButton.Location = New System.Drawing.Point(103, 178)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(75, 23)
        Me.saveButton.TabIndex = 5
        Me.saveButton.Text = "Save"
        Me.saveButton.UseVisualStyleBackColor = True
        '
        'infoLabel
        '
        Me.infoLabel.AutoSize = True
        Me.infoLabel.Location = New System.Drawing.Point(37, 219)
        Me.infoLabel.Name = "infoLabel"
        Me.infoLabel.Size = New System.Drawing.Size(35, 13)
        Me.infoLabel.TabIndex = 9
        Me.infoLabel.Text = "status"
        '
        'NewVisit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(225, 253)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.infoTextBox)
        Me.Controls.Add(Me.externalCodeTextBox)
        Me.Controls.Add(Me.visitDateTextBox)
        Me.Controls.Add(Me.siteCodeTextBox)
        Me.Controls.Add(Me.serviceIDTextBox)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.infoLabel)
        Me.Controls.Add(Me.patientIDLabel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Name = "NewVisit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NewVisit"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents patientIDLabel As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents serviceIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents siteCodeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents visitDateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents externalCodeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents infoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents saveButton As System.Windows.Forms.Button
    Friend WithEvents infoLabel As System.Windows.Forms.Label
End Class
