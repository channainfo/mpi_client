﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Figerprint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Figerprint))
        Me.pictureFingerprint = New System.Windows.Forms.PictureBox
        Me.SearchButton = New System.Windows.Forms.Button
        Me.labelStatus = New System.Windows.Forms.Label
        Me.grFingerXCtrl = New AxGrFingerXLib.AxGrFingerXCtrl
        Me.closeButton = New System.Windows.Forms.Button
        Me.SynchronizationButton = New System.Windows.Forms.Button
        Me.pictureFringerprint1 = New System.Windows.Forms.PictureBox
        Me.pictureFringerprint2 = New System.Windows.Forms.PictureBox
        Me.genderCombobox = New System.Windows.Forms.ComboBox
        Me.fingerprintQuality1 = New System.Windows.Forms.Label
        Me.fingerprintQuality2 = New System.Windows.Forms.Label
        CType(Me.pictureFingerprint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grFingerXCtrl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureFringerprint1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureFringerprint2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureFingerprint
        '
        Me.pictureFingerprint.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pictureFingerprint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureFingerprint.Location = New System.Drawing.Point(12, 12)
        Me.pictureFingerprint.Name = "pictureFingerprint"
        Me.pictureFingerprint.Size = New System.Drawing.Size(340, 322)
        Me.pictureFingerprint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureFingerprint.TabIndex = 0
        Me.pictureFingerprint.TabStop = False
        '
        'SearchButton
        '
        Me.SearchButton.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.SearchButton.Location = New System.Drawing.Point(397, 55)
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.Size = New System.Drawing.Size(109, 23)
        Me.SearchButton.TabIndex = 2
        Me.SearchButton.Text = "Search"
        Me.SearchButton.UseVisualStyleBackColor = True
        '
        'labelStatus
        '
        Me.labelStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.labelStatus.AutoSize = True
        Me.labelStatus.Location = New System.Drawing.Point(107, 337)
        Me.labelStatus.Name = "labelStatus"
        Me.labelStatus.Size = New System.Drawing.Size(40, 13)
        Me.labelStatus.TabIndex = 3
        Me.labelStatus.Text = "Status:"
        '
        'grFingerXCtrl
        '
        Me.grFingerXCtrl.Enabled = True
        Me.grFingerXCtrl.Location = New System.Drawing.Point(397, 164)
        Me.grFingerXCtrl.Name = "grFingerXCtrl"
        Me.grFingerXCtrl.OcxState = CType(resources.GetObject("grFingerXCtrl.OcxState"), System.Windows.Forms.AxHost.State)
        Me.grFingerXCtrl.Size = New System.Drawing.Size(32, 32)
        Me.grFingerXCtrl.TabIndex = 4
        '
        'closeButton
        '
        Me.closeButton.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.closeButton.Location = New System.Drawing.Point(397, 113)
        Me.closeButton.Name = "closeButton"
        Me.closeButton.Size = New System.Drawing.Size(109, 23)
        Me.closeButton.TabIndex = 2
        Me.closeButton.Text = "Close"
        Me.closeButton.UseVisualStyleBackColor = True
        '
        'SynchronizationButton
        '
        Me.SynchronizationButton.Location = New System.Drawing.Point(397, 84)
        Me.SynchronizationButton.Name = "SynchronizationButton"
        Me.SynchronizationButton.Size = New System.Drawing.Size(109, 23)
        Me.SynchronizationButton.TabIndex = 5
        Me.SynchronizationButton.Text = "Synchronization"
        Me.SynchronizationButton.UseVisualStyleBackColor = True
        '
        'pictureFringerprint1
        '
        Me.pictureFringerprint1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.pictureFringerprint1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureFringerprint1.Location = New System.Drawing.Point(46, 353)
        Me.pictureFringerprint1.Name = "pictureFringerprint1"
        Me.pictureFringerprint1.Size = New System.Drawing.Size(121, 107)
        Me.pictureFringerprint1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureFringerprint1.TabIndex = 6
        Me.pictureFringerprint1.TabStop = False
        '
        'pictureFringerprint2
        '
        Me.pictureFringerprint2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.pictureFringerprint2.Location = New System.Drawing.Point(193, 353)
        Me.pictureFringerprint2.Name = "pictureFringerprint2"
        Me.pictureFringerprint2.Size = New System.Drawing.Size(121, 107)
        Me.pictureFringerprint2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureFringerprint2.TabIndex = 6
        Me.pictureFringerprint2.TabStop = False
        '
        'genderCombobox
        '
        Me.genderCombobox.FormattingEnabled = True
        Me.genderCombobox.Location = New System.Drawing.Point(397, 13)
        Me.genderCombobox.Name = "genderCombobox"
        Me.genderCombobox.Size = New System.Drawing.Size(109, 21)
        Me.genderCombobox.TabIndex = 7
        '
        'fingerprintQuality1
        '
        Me.fingerprintQuality1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.fingerprintQuality1.Location = New System.Drawing.Point(46, 463)
        Me.fingerprintQuality1.Name = "fingerprintQuality1"
        Me.fingerprintQuality1.Size = New System.Drawing.Size(121, 13)
        Me.fingerprintQuality1.TabIndex = 8
        Me.fingerprintQuality1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fingerprintQuality2
        '
        Me.fingerprintQuality2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.fingerprintQuality2.Location = New System.Drawing.Point(193, 463)
        Me.fingerprintQuality2.Name = "fingerprintQuality2"
        Me.fingerprintQuality2.Size = New System.Drawing.Size(121, 13)
        Me.fingerprintQuality2.TabIndex = 8
        Me.fingerprintQuality2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Figerprint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 483)
        Me.Controls.Add(Me.fingerprintQuality2)
        Me.Controls.Add(Me.fingerprintQuality1)
        Me.Controls.Add(Me.genderCombobox)
        Me.Controls.Add(Me.pictureFringerprint2)
        Me.Controls.Add(Me.pictureFringerprint1)
        Me.Controls.Add(Me.SynchronizationButton)
        Me.Controls.Add(Me.grFingerXCtrl)
        Me.Controls.Add(Me.labelStatus)
        Me.Controls.Add(Me.closeButton)
        Me.Controls.Add(Me.SearchButton)
        Me.Controls.Add(Me.pictureFingerprint)
        Me.Name = "Figerprint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fingerprint"
        CType(Me.pictureFingerprint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grFingerXCtrl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureFringerprint1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureFringerprint2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pictureFingerprint As System.Windows.Forms.PictureBox
    Friend WithEvents SearchButton As System.Windows.Forms.Button
    Friend WithEvents labelStatus As System.Windows.Forms.Label
    Friend WithEvents grFingerXCtrl As AxGrFingerXLib.AxGrFingerXCtrl
    Friend WithEvents closeButton As System.Windows.Forms.Button
    Friend WithEvents SynchronizationButton As System.Windows.Forms.Button
    Friend WithEvents pictureFringerprint1 As System.Windows.Forms.PictureBox
    Friend WithEvents pictureFringerprint2 As System.Windows.Forms.PictureBox
    Friend WithEvents genderCombobox As System.Windows.Forms.ComboBox
    Friend WithEvents fingerprintQuality1 As System.Windows.Forms.Label
    Friend WithEvents fingerprintQuality2 As System.Windows.Forms.Label

End Class
