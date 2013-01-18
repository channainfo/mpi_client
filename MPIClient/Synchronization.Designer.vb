<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Synchronization
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Synchronization))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.PatientIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GenderDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateBirthDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreatedateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdatedateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PatientBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.synchronizationWorker = New System.ComponentModel.BackgroundWorker
        Me.grFingerXCtrl = New AxGrFingerXLib.AxGrFingerXCtrl
        Me.ActionToolStrip = New System.Windows.Forms.ToolStrip
        Me.synchronizationButton = New System.Windows.Forms.ToolStripButton
        Me.CloseButton = New System.Windows.Forms.ToolStripButton
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.patientFoundLabel = New System.Windows.Forms.ToolStripStatusLabel
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PatientBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grFingerXCtrl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ActionToolStrip.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PatientIDDataGridViewTextBoxColumn, Me.GenderDataGridViewTextBoxColumn, Me.DateBirthDataGridViewTextBoxColumn, Me.CreatedateDataGridViewTextBoxColumn, Me.UpdatedateDataGridViewTextBoxColumn, Me.Status})
        Me.DataGridView1.DataSource = Me.PatientBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(12, 48)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(866, 257)
        Me.DataGridView1.TabIndex = 3
        '
        'PatientIDDataGridViewTextBoxColumn
        '
        Me.PatientIDDataGridViewTextBoxColumn.DataPropertyName = "PatientID"
        Me.PatientIDDataGridViewTextBoxColumn.HeaderText = "MasterID"
        Me.PatientIDDataGridViewTextBoxColumn.Name = "PatientIDDataGridViewTextBoxColumn"
        Me.PatientIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GenderDataGridViewTextBoxColumn
        '
        Me.GenderDataGridViewTextBoxColumn.DataPropertyName = "GenderText"
        Me.GenderDataGridViewTextBoxColumn.HeaderText = "Gender"
        Me.GenderDataGridViewTextBoxColumn.Name = "GenderDataGridViewTextBoxColumn"
        Me.GenderDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DateBirthDataGridViewTextBoxColumn
        '
        Me.DateBirthDataGridViewTextBoxColumn.DataPropertyName = "DateBirth"
        Me.DateBirthDataGridViewTextBoxColumn.HeaderText = "DateBirth"
        Me.DateBirthDataGridViewTextBoxColumn.Name = "DateBirthDataGridViewTextBoxColumn"
        Me.DateBirthDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CreatedateDataGridViewTextBoxColumn
        '
        Me.CreatedateDataGridViewTextBoxColumn.HeaderText = "Createdate"
        Me.CreatedateDataGridViewTextBoxColumn.Name = "CreatedateDataGridViewTextBoxColumn"
        Me.CreatedateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'UpdatedateDataGridViewTextBoxColumn
        '
        Me.UpdatedateDataGridViewTextBoxColumn.HeaderText = "Updatedate"
        Me.UpdatedateDataGridViewTextBoxColumn.Name = "UpdatedateDataGridViewTextBoxColumn"
        Me.UpdatedateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        '
        'PatientBindingSource
        '
        Me.PatientBindingSource.AllowNew = True
        Me.PatientBindingSource.DataSource = GetType(MPIClient.DataAccess.Model.Patient)
        '
        'synchronizationWorker
        '
        Me.synchronizationWorker.WorkerSupportsCancellation = True
        '
        'grFingerXCtrl
        '
        Me.grFingerXCtrl.Enabled = True
        Me.grFingerXCtrl.Location = New System.Drawing.Point(826, 117)
        Me.grFingerXCtrl.Name = "grFingerXCtrl"
        Me.grFingerXCtrl.OcxState = CType(resources.GetObject("grFingerXCtrl.OcxState"), System.Windows.Forms.AxHost.State)
        Me.grFingerXCtrl.Size = New System.Drawing.Size(32, 32)
        Me.grFingerXCtrl.TabIndex = 5
        '
        'ActionToolStrip
        '
        Me.ActionToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.synchronizationButton, Me.CloseButton})
        Me.ActionToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ActionToolStrip.Name = "ActionToolStrip"
        Me.ActionToolStrip.Size = New System.Drawing.Size(890, 39)
        Me.ActionToolStrip.TabIndex = 6
        Me.ActionToolStrip.Text = "ToolStrip1"
        '
        'synchronizationButton
        '
        Me.synchronizationButton.Image = Global.MPIClient.My.Resources.Resources.Synchronize_icon__1_
        Me.synchronizationButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.synchronizationButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.synchronizationButton.Name = "synchronizationButton"
        Me.synchronizationButton.Size = New System.Drawing.Size(107, 36)
        Me.synchronizationButton.Text = "Synchronize"
        '
        'CloseButton
        '
        Me.CloseButton.Image = Global.MPIClient.My.Resources.Resources.Log_Out_icon__1_
        Me.CloseButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CloseButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(72, 36)
        Me.CloseButton.Text = "Close"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.patientFoundLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 297)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(890, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(108, 17)
        Me.ToolStripStatusLabel1.Text = "Number of Patient:"
        '
        'patientFoundLabel
        '
        Me.patientFoundLabel.Name = "patientFoundLabel"
        Me.patientFoundLabel.Size = New System.Drawing.Size(55, 17)
        Me.patientFoundLabel.Text = "................"
        '
        'Synchronization
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 319)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ActionToolStrip)
        Me.Controls.Add(Me.grFingerXCtrl)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Synchronization"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Synchronization"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PatientBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grFingerXCtrl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ActionToolStrip.ResumeLayout(False)
        Me.ActionToolStrip.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PatientBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents synchronizationWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents grFingerXCtrl As AxGrFingerXLib.AxGrFingerXCtrl
    Friend WithEvents ActionToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents synchronizationButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CloseButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PatientIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GenderDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateBirthDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreatedateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdatedateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents patientFoundLabel As System.Windows.Forms.ToolStripStatusLabel
End Class
