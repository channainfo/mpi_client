<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewPatient
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewPatient))
        Me.Label4 = New System.Windows.Forms.Label
        Me.genderCombobox = New System.Windows.Forms.ComboBox
        Me.enrollButton = New System.Windows.Forms.Button
        Me.infoLabel = New System.Windows.Forms.Label
        Me.grFingerXCtrl = New AxGrFingerXLib.AxGrFingerXCtrl
        CType(Me.grFingerXCtrl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Gender:"
        '
        'genderCombobox
        '
        Me.genderCombobox.FormattingEnabled = True
        Me.genderCombobox.Location = New System.Drawing.Point(103, 12)
        Me.genderCombobox.Name = "genderCombobox"
        Me.genderCombobox.Size = New System.Drawing.Size(109, 21)
        Me.genderCombobox.TabIndex = 14
        '
        'enrollButton
        '
        Me.enrollButton.Location = New System.Drawing.Point(103, 44)
        Me.enrollButton.Name = "enrollButton"
        Me.enrollButton.Size = New System.Drawing.Size(75, 23)
        Me.enrollButton.TabIndex = 15
        Me.enrollButton.Text = "Enroll"
        Me.enrollButton.UseVisualStyleBackColor = True
        '
        'infoLabel
        '
        Me.infoLabel.AutoSize = True
        Me.infoLabel.Location = New System.Drawing.Point(58, 75)
        Me.infoLabel.Name = "infoLabel"
        Me.infoLabel.Size = New System.Drawing.Size(0, 13)
        Me.infoLabel.TabIndex = 16
        '
        'grFingerXCtrl
        '
        Me.grFingerXCtrl.Enabled = True
        Me.grFingerXCtrl.Location = New System.Drawing.Point(15, 35)
        Me.grFingerXCtrl.Name = "grFingerXCtrl"
        Me.grFingerXCtrl.OcxState = CType(resources.GetObject("grFingerXCtrl.OcxState"), System.Windows.Forms.AxHost.State)
        Me.grFingerXCtrl.Size = New System.Drawing.Size(32, 32)
        Me.grFingerXCtrl.TabIndex = 17
        '
        'NewPatient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(235, 98)
        Me.Controls.Add(Me.grFingerXCtrl)
        Me.Controls.Add(Me.infoLabel)
        Me.Controls.Add(Me.enrollButton)
        Me.Controls.Add(Me.genderCombobox)
        Me.Controls.Add(Me.Label4)
        Me.Name = "NewPatient"
        Me.Text = "NewPatient"
        CType(Me.grFingerXCtrl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents genderCombobox As System.Windows.Forms.ComboBox
    Friend WithEvents enrollButton As System.Windows.Forms.Button
    Friend WithEvents infoLabel As System.Windows.Forms.Label
    Friend WithEvents grFingerXCtrl As AxGrFingerXLib.AxGrFingerXCtrl
End Class
