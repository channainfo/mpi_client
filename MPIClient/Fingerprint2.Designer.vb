Imports System.Threading
Imports System.Globalization

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fingerprint2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Fingerprint2))
        Me.ActionToolStrip = New System.Windows.Forms.ToolStrip
        Me.SearchButton = New System.Windows.Forms.ToolStripButton
        Me.SynchronizationButton = New System.Windows.Forms.ToolStripButton
        Me.initializeButton = New System.Windows.Forms.ToolStripButton
        Me.CloseButton = New System.Windows.Forms.ToolStripButton
        Me.quality1Left = New System.Windows.Forms.Label
        Me.quality2left = New System.Windows.Forms.Label
        Me.quality3left = New System.Windows.Forms.Label
        Me.quality4left = New System.Windows.Forms.Label
        Me.quality5left = New System.Windows.Forms.Label
        Me.quality1right = New System.Windows.Forms.Label
        Me.quality2right = New System.Windows.Forms.Label
        Me.quality3right = New System.Windows.Forms.Label
        Me.quality4right = New System.Windows.Forms.Label
        Me.quality5right = New System.Windows.Forms.Label
        Me.labelStatus = New System.Windows.Forms.Label
        Me.grFingerXCtrl = New AxGrFingerXLib.AxGrFingerXCtrl
        Me.genderCombobox = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.clearAllButton = New System.Windows.Forms.Button
        Me.removeButton = New System.Windows.Forms.Button
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.finger5left = New System.Windows.Forms.PictureBox
        Me.finger4left = New System.Windows.Forms.PictureBox
        Me.finger3left = New System.Windows.Forms.PictureBox
        Me.finger2left = New System.Windows.Forms.PictureBox
        Me.finger5right = New System.Windows.Forms.PictureBox
        Me.finger4right = New System.Windows.Forms.PictureBox
        Me.finger3right = New System.Windows.Forms.PictureBox
        Me.finger2right = New System.Windows.Forms.PictureBox
        Me.finger1right = New System.Windows.Forms.PictureBox
        Me.finger1Left = New System.Windows.Forms.PictureBox
        Me.pictureFingerprint = New System.Windows.Forms.PictureBox
        Me.RightPalmPic = New System.Windows.Forms.PictureBox
        Me.LeftPalmPic = New System.Windows.Forms.PictureBox
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ActionToolStrip.SuspendLayout()
        CType(Me.grFingerXCtrl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.finger5left, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.finger4left, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.finger3left, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.finger2left, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.finger5right, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.finger4right, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.finger3right, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.finger2right, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.finger1right, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.finger1Left, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureFingerprint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RightPalmPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LeftPalmPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ActionToolStrip
        '
        Me.ActionToolStrip.AccessibleDescription = Nothing
        Me.ActionToolStrip.AccessibleName = Nothing
        resources.ApplyResources(Me.ActionToolStrip, "ActionToolStrip")
        Me.ActionToolStrip.BackgroundImage = Nothing
        Me.ActionToolStrip.Font = Nothing
        Me.ActionToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SearchButton, Me.SynchronizationButton, Me.initializeButton, Me.CloseButton, Me.ToolStripButton1})
        Me.ActionToolStrip.Name = "ActionToolStrip"
        '
        'SearchButton
        '
        Me.SearchButton.AccessibleDescription = Nothing
        Me.SearchButton.AccessibleName = Nothing
        resources.ApplyResources(Me.SearchButton, "SearchButton")
        Me.SearchButton.BackgroundImage = Nothing
        Me.SearchButton.Image = Global.MPIClient.My.Resources.Resources.search_green_neon_icon__1_
        Me.SearchButton.Name = "SearchButton"
        '
        'SynchronizationButton
        '
        Me.SynchronizationButton.AccessibleDescription = Nothing
        Me.SynchronizationButton.AccessibleName = Nothing
        resources.ApplyResources(Me.SynchronizationButton, "SynchronizationButton")
        Me.SynchronizationButton.BackgroundImage = Nothing
        Me.SynchronizationButton.Image = Global.MPIClient.My.Resources.Resources.Synchronize_icon__1_
        Me.SynchronizationButton.Name = "SynchronizationButton"
        '
        'initializeButton
        '
        Me.initializeButton.AccessibleDescription = Nothing
        Me.initializeButton.AccessibleName = Nothing
        resources.ApplyResources(Me.initializeButton, "initializeButton")
        Me.initializeButton.BackgroundImage = Nothing
        Me.initializeButton.Image = Global.MPIClient.My.Resources.Resources.Other_Power_Restart_Metro_icon
        Me.initializeButton.Name = "initializeButton"
        '
        'CloseButton
        '
        Me.CloseButton.AccessibleDescription = Nothing
        Me.CloseButton.AccessibleName = Nothing
        resources.ApplyResources(Me.CloseButton, "CloseButton")
        Me.CloseButton.BackgroundImage = Nothing
        Me.CloseButton.Image = Global.MPIClient.My.Resources.Resources.Log_Out_icon__1_
        Me.CloseButton.Name = "CloseButton"
        '
        'quality1Left
        '
        Me.quality1Left.AccessibleDescription = Nothing
        Me.quality1Left.AccessibleName = Nothing
        resources.ApplyResources(Me.quality1Left, "quality1Left")
        Me.quality1Left.Name = "quality1Left"
        '
        'quality2left
        '
        Me.quality2left.AccessibleDescription = Nothing
        Me.quality2left.AccessibleName = Nothing
        resources.ApplyResources(Me.quality2left, "quality2left")
        Me.quality2left.Name = "quality2left"
        '
        'quality3left
        '
        Me.quality3left.AccessibleDescription = Nothing
        Me.quality3left.AccessibleName = Nothing
        resources.ApplyResources(Me.quality3left, "quality3left")
        Me.quality3left.Name = "quality3left"
        '
        'quality4left
        '
        Me.quality4left.AccessibleDescription = Nothing
        Me.quality4left.AccessibleName = Nothing
        resources.ApplyResources(Me.quality4left, "quality4left")
        Me.quality4left.Name = "quality4left"
        '
        'quality5left
        '
        Me.quality5left.AccessibleDescription = Nothing
        Me.quality5left.AccessibleName = Nothing
        resources.ApplyResources(Me.quality5left, "quality5left")
        Me.quality5left.Name = "quality5left"
        '
        'quality1right
        '
        Me.quality1right.AccessibleDescription = Nothing
        Me.quality1right.AccessibleName = Nothing
        resources.ApplyResources(Me.quality1right, "quality1right")
        Me.quality1right.Name = "quality1right"
        '
        'quality2right
        '
        Me.quality2right.AccessibleDescription = Nothing
        Me.quality2right.AccessibleName = Nothing
        resources.ApplyResources(Me.quality2right, "quality2right")
        Me.quality2right.Name = "quality2right"
        '
        'quality3right
        '
        Me.quality3right.AccessibleDescription = Nothing
        Me.quality3right.AccessibleName = Nothing
        resources.ApplyResources(Me.quality3right, "quality3right")
        Me.quality3right.Name = "quality3right"
        '
        'quality4right
        '
        Me.quality4right.AccessibleDescription = Nothing
        Me.quality4right.AccessibleName = Nothing
        resources.ApplyResources(Me.quality4right, "quality4right")
        Me.quality4right.Name = "quality4right"
        '
        'quality5right
        '
        Me.quality5right.AccessibleDescription = Nothing
        Me.quality5right.AccessibleName = Nothing
        resources.ApplyResources(Me.quality5right, "quality5right")
        Me.quality5right.Name = "quality5right"
        '
        'labelStatus
        '
        Me.labelStatus.AccessibleDescription = Nothing
        Me.labelStatus.AccessibleName = Nothing
        resources.ApplyResources(Me.labelStatus, "labelStatus")
        Me.labelStatus.Name = "labelStatus"
        '
        'grFingerXCtrl
        '
        Me.grFingerXCtrl.AccessibleDescription = Nothing
        Me.grFingerXCtrl.AccessibleName = Nothing
        resources.ApplyResources(Me.grFingerXCtrl, "grFingerXCtrl")
        Me.grFingerXCtrl.Font = Nothing
        Me.grFingerXCtrl.Name = "grFingerXCtrl"
        Me.grFingerXCtrl.OcxState = CType(resources.GetObject("grFingerXCtrl.OcxState"), System.Windows.Forms.AxHost.State)
        '
        'genderCombobox
        '
        Me.genderCombobox.AccessibleDescription = Nothing
        Me.genderCombobox.AccessibleName = Nothing
        resources.ApplyResources(Me.genderCombobox, "genderCombobox")
        Me.genderCombobox.BackgroundImage = Nothing
        Me.genderCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.genderCombobox.FormattingEnabled = True
        Me.genderCombobox.Name = "genderCombobox"
        Me.genderCombobox.TabStop = False
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = Nothing
        Me.Label1.AccessibleName = Nothing
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'clearAllButton
        '
        Me.clearAllButton.AccessibleDescription = Nothing
        Me.clearAllButton.AccessibleName = Nothing
        resources.ApplyResources(Me.clearAllButton, "clearAllButton")
        Me.clearAllButton.BackgroundImage = Nothing
        Me.clearAllButton.Name = "clearAllButton"
        Me.clearAllButton.UseVisualStyleBackColor = True
        '
        'removeButton
        '
        Me.removeButton.AccessibleDescription = Nothing
        Me.removeButton.AccessibleName = Nothing
        resources.ApplyResources(Me.removeButton, "removeButton")
        Me.removeButton.BackgroundImage = Nothing
        Me.removeButton.Name = "removeButton"
        Me.removeButton.UseVisualStyleBackColor = True
        '
        'PictureBox4
        '
        Me.PictureBox4.AccessibleDescription = Nothing
        Me.PictureBox4.AccessibleName = Nothing
        resources.ApplyResources(Me.PictureBox4, "PictureBox4")
        Me.PictureBox4.BackgroundImage = Nothing
        Me.PictureBox4.Font = Nothing
        Me.PictureBox4.Image = Global.MPIClient.My.Resources.Resources.Right1
        Me.PictureBox4.ImageLocation = Nothing
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.AccessibleDescription = Nothing
        Me.PictureBox3.AccessibleName = Nothing
        resources.ApplyResources(Me.PictureBox3, "PictureBox3")
        Me.PictureBox3.BackgroundImage = Nothing
        Me.PictureBox3.Font = Nothing
        Me.PictureBox3.Image = Global.MPIClient.My.Resources.Resources.Left1
        Me.PictureBox3.ImageLocation = Nothing
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.TabStop = False
        '
        'finger5left
        '
        Me.finger5left.AccessibleDescription = Nothing
        Me.finger5left.AccessibleName = Nothing
        resources.ApplyResources(Me.finger5left, "finger5left")
        Me.finger5left.BackColor = System.Drawing.SystemColors.Control
        Me.finger5left.BackgroundImage = Nothing
        Me.finger5left.Cursor = System.Windows.Forms.Cursors.Hand
        Me.finger5left.Font = Nothing
        Me.finger5left.ImageLocation = Nothing
        Me.finger5left.Name = "finger5left"
        Me.finger5left.TabStop = False
        '
        'finger4left
        '
        Me.finger4left.AccessibleDescription = Nothing
        Me.finger4left.AccessibleName = Nothing
        resources.ApplyResources(Me.finger4left, "finger4left")
        Me.finger4left.BackColor = System.Drawing.SystemColors.Control
        Me.finger4left.BackgroundImage = Nothing
        Me.finger4left.Cursor = System.Windows.Forms.Cursors.Hand
        Me.finger4left.Font = Nothing
        Me.finger4left.ImageLocation = Nothing
        Me.finger4left.Name = "finger4left"
        Me.finger4left.TabStop = False
        '
        'finger3left
        '
        Me.finger3left.AccessibleDescription = Nothing
        Me.finger3left.AccessibleName = Nothing
        resources.ApplyResources(Me.finger3left, "finger3left")
        Me.finger3left.BackColor = System.Drawing.SystemColors.Control
        Me.finger3left.BackgroundImage = Nothing
        Me.finger3left.Cursor = System.Windows.Forms.Cursors.Hand
        Me.finger3left.Font = Nothing
        Me.finger3left.ImageLocation = Nothing
        Me.finger3left.Name = "finger3left"
        Me.finger3left.TabStop = False
        '
        'finger2left
        '
        Me.finger2left.AccessibleDescription = Nothing
        Me.finger2left.AccessibleName = Nothing
        resources.ApplyResources(Me.finger2left, "finger2left")
        Me.finger2left.BackColor = System.Drawing.SystemColors.Control
        Me.finger2left.BackgroundImage = Nothing
        Me.finger2left.Cursor = System.Windows.Forms.Cursors.Hand
        Me.finger2left.Font = Nothing
        Me.finger2left.ImageLocation = Nothing
        Me.finger2left.Name = "finger2left"
        Me.finger2left.TabStop = False
        '
        'finger5right
        '
        Me.finger5right.AccessibleDescription = Nothing
        Me.finger5right.AccessibleName = Nothing
        resources.ApplyResources(Me.finger5right, "finger5right")
        Me.finger5right.BackColor = System.Drawing.SystemColors.Control
        Me.finger5right.BackgroundImage = Nothing
        Me.finger5right.Cursor = System.Windows.Forms.Cursors.Hand
        Me.finger5right.Font = Nothing
        Me.finger5right.ImageLocation = Nothing
        Me.finger5right.Name = "finger5right"
        Me.finger5right.TabStop = False
        '
        'finger4right
        '
        Me.finger4right.AccessibleDescription = Nothing
        Me.finger4right.AccessibleName = Nothing
        resources.ApplyResources(Me.finger4right, "finger4right")
        Me.finger4right.BackColor = System.Drawing.SystemColors.Control
        Me.finger4right.BackgroundImage = Nothing
        Me.finger4right.Cursor = System.Windows.Forms.Cursors.Hand
        Me.finger4right.Font = Nothing
        Me.finger4right.ImageLocation = Nothing
        Me.finger4right.Name = "finger4right"
        Me.finger4right.TabStop = False
        '
        'finger3right
        '
        Me.finger3right.AccessibleDescription = Nothing
        Me.finger3right.AccessibleName = Nothing
        resources.ApplyResources(Me.finger3right, "finger3right")
        Me.finger3right.BackColor = System.Drawing.SystemColors.Control
        Me.finger3right.BackgroundImage = Nothing
        Me.finger3right.Cursor = System.Windows.Forms.Cursors.Hand
        Me.finger3right.Font = Nothing
        Me.finger3right.ImageLocation = Nothing
        Me.finger3right.Name = "finger3right"
        Me.finger3right.TabStop = False
        '
        'finger2right
        '
        Me.finger2right.AccessibleDescription = Nothing
        Me.finger2right.AccessibleName = Nothing
        resources.ApplyResources(Me.finger2right, "finger2right")
        Me.finger2right.BackColor = System.Drawing.SystemColors.Control
        Me.finger2right.BackgroundImage = Nothing
        Me.finger2right.Cursor = System.Windows.Forms.Cursors.Hand
        Me.finger2right.Font = Nothing
        Me.finger2right.ImageLocation = Nothing
        Me.finger2right.Name = "finger2right"
        Me.finger2right.TabStop = False
        '
        'finger1right
        '
        Me.finger1right.AccessibleDescription = Nothing
        Me.finger1right.AccessibleName = Nothing
        resources.ApplyResources(Me.finger1right, "finger1right")
        Me.finger1right.BackColor = System.Drawing.SystemColors.Control
        Me.finger1right.BackgroundImage = Nothing
        Me.finger1right.Cursor = System.Windows.Forms.Cursors.Hand
        Me.finger1right.Font = Nothing
        Me.finger1right.ImageLocation = Nothing
        Me.finger1right.Name = "finger1right"
        Me.finger1right.TabStop = False
        '
        'finger1Left
        '
        Me.finger1Left.AccessibleDescription = Nothing
        Me.finger1Left.AccessibleName = Nothing
        resources.ApplyResources(Me.finger1Left, "finger1Left")
        Me.finger1Left.BackColor = System.Drawing.SystemColors.Control
        Me.finger1Left.BackgroundImage = Nothing
        Me.finger1Left.Cursor = System.Windows.Forms.Cursors.Hand
        Me.finger1Left.Font = Nothing
        Me.finger1Left.ImageLocation = Nothing
        Me.finger1Left.Name = "finger1Left"
        Me.finger1Left.TabStop = False
        '
        'pictureFingerprint
        '
        Me.pictureFingerprint.AccessibleDescription = Nothing
        Me.pictureFingerprint.AccessibleName = Nothing
        resources.ApplyResources(Me.pictureFingerprint, "pictureFingerprint")
        Me.pictureFingerprint.BackgroundImage = Nothing
        Me.pictureFingerprint.Font = Nothing
        Me.pictureFingerprint.ImageLocation = Nothing
        Me.pictureFingerprint.Name = "pictureFingerprint"
        Me.pictureFingerprint.TabStop = False
        '
        'RightPalmPic
        '
        Me.RightPalmPic.AccessibleDescription = Nothing
        Me.RightPalmPic.AccessibleName = Nothing
        resources.ApplyResources(Me.RightPalmPic, "RightPalmPic")
        Me.RightPalmPic.BackgroundImage = Nothing
        Me.RightPalmPic.Font = Nothing
        Me.RightPalmPic.Image = Global.MPIClient.My.Resources.Resources.right
        Me.RightPalmPic.ImageLocation = Nothing
        Me.RightPalmPic.Name = "RightPalmPic"
        Me.RightPalmPic.TabStop = False
        '
        'LeftPalmPic
        '
        Me.LeftPalmPic.AccessibleDescription = Nothing
        Me.LeftPalmPic.AccessibleName = Nothing
        resources.ApplyResources(Me.LeftPalmPic, "LeftPalmPic")
        Me.LeftPalmPic.BackgroundImage = Nothing
        Me.LeftPalmPic.Font = Nothing
        Me.LeftPalmPic.Image = Global.MPIClient.My.Resources.Resources.left
        Me.LeftPalmPic.ImageLocation = Nothing
        Me.LeftPalmPic.Name = "LeftPalmPic"
        Me.LeftPalmPic.TabStop = False
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.AccessibleDescription = Nothing
        Me.ToolStripButton1.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripButton1, "ToolStripButton1")
        Me.ToolStripButton1.BackgroundImage = Nothing
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Name = "ToolStripButton1"
        '
        'Fingerprint2
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.removeButton)
        Me.Controls.Add(Me.clearAllButton)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.genderCombobox)
        Me.Controls.Add(Me.grFingerXCtrl)
        Me.Controls.Add(Me.labelStatus)
        Me.Controls.Add(Me.finger5left)
        Me.Controls.Add(Me.finger4left)
        Me.Controls.Add(Me.finger3left)
        Me.Controls.Add(Me.quality5left)
        Me.Controls.Add(Me.finger2left)
        Me.Controls.Add(Me.quality4left)
        Me.Controls.Add(Me.finger5right)
        Me.Controls.Add(Me.finger4right)
        Me.Controls.Add(Me.finger3right)
        Me.Controls.Add(Me.finger2right)
        Me.Controls.Add(Me.finger1right)
        Me.Controls.Add(Me.quality5right)
        Me.Controls.Add(Me.finger1Left)
        Me.Controls.Add(Me.quality4right)
        Me.Controls.Add(Me.quality3left)
        Me.Controls.Add(Me.quality3right)
        Me.Controls.Add(Me.pictureFingerprint)
        Me.Controls.Add(Me.quality2right)
        Me.Controls.Add(Me.quality2left)
        Me.Controls.Add(Me.quality1right)
        Me.Controls.Add(Me.RightPalmPic)
        Me.Controls.Add(Me.quality1Left)
        Me.Controls.Add(Me.LeftPalmPic)
        Me.Controls.Add(Me.ActionToolStrip)
        Me.Font = Nothing
        Me.Icon = Nothing
        Me.Name = "Fingerprint2"
        Me.ActionToolStrip.ResumeLayout(False)
        Me.ActionToolStrip.PerformLayout()
        CType(Me.grFingerXCtrl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.finger5left, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.finger4left, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.finger3left, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.finger2left, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.finger5right, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.finger4right, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.finger3right, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.finger2right, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.finger1right, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.finger1Left, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureFingerprint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RightPalmPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LeftPalmPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ActionToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents SearchButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SynchronizationButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CloseButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents LeftPalmPic As System.Windows.Forms.PictureBox
    Friend WithEvents quality1Left As System.Windows.Forms.Label
    Friend WithEvents RightPalmPic As System.Windows.Forms.PictureBox
    Friend WithEvents pictureFingerprint As System.Windows.Forms.PictureBox
    Friend WithEvents finger1Left As System.Windows.Forms.PictureBox
    Friend WithEvents quality2left As System.Windows.Forms.Label
    Friend WithEvents finger2left As System.Windows.Forms.PictureBox
    Friend WithEvents quality3left As System.Windows.Forms.Label
    Friend WithEvents finger3left As System.Windows.Forms.PictureBox
    Friend WithEvents quality4left As System.Windows.Forms.Label
    Friend WithEvents finger4left As System.Windows.Forms.PictureBox
    Friend WithEvents quality5left As System.Windows.Forms.Label
    Friend WithEvents finger5left As System.Windows.Forms.PictureBox
    Friend WithEvents quality1right As System.Windows.Forms.Label
    Friend WithEvents finger1right As System.Windows.Forms.PictureBox
    Friend WithEvents quality2right As System.Windows.Forms.Label
    Friend WithEvents finger2right As System.Windows.Forms.PictureBox
    Friend WithEvents quality3right As System.Windows.Forms.Label
    Friend WithEvents finger3right As System.Windows.Forms.PictureBox
    Friend WithEvents quality4right As System.Windows.Forms.Label
    Friend WithEvents finger4right As System.Windows.Forms.PictureBox
    Friend WithEvents quality5right As System.Windows.Forms.Label
    Friend WithEvents finger5right As System.Windows.Forms.PictureBox
    Friend WithEvents labelStatus As System.Windows.Forms.Label
    Friend WithEvents grFingerXCtrl As AxGrFingerXLib.AxGrFingerXCtrl
    Friend WithEvents genderCombobox As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents clearAllButton As System.Windows.Forms.Button
    Friend WithEvents removeButton As System.Windows.Forms.Button
    Friend WithEvents initializeButton As System.Windows.Forms.ToolStripButton

    Public Sub New()

        Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("km-KH")

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
