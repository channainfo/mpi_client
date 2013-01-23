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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.CreatedateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdatedateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.synchronizationWorker = New System.ComponentModel.BackgroundWorker
        Me.ActionToolStrip = New System.Windows.Forms.ToolStrip
        Me.synchronizationButton = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.RefreshButton = New System.Windows.Forms.ToolStripButton
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.patientFoundLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.NumOfTotalSynLabel = New System.Windows.Forms.Label
        Me.NumOfSuccessLabel = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.NumOfDuplicationLabel = New System.Windows.Forms.Label
        Me.NumOfErrorLabel = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.PatientIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GenderDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateBirthDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PatientBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ActionToolStrip.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PatientBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.DataGridView1.Size = New System.Drawing.Size(663, 257)
        Me.DataGridView1.TabIndex = 3
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
        'synchronizationWorker
        '
        Me.synchronizationWorker.WorkerSupportsCancellation = True
        '
        'ActionToolStrip
        '
        Me.ActionToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.synchronizationButton, Me.ToolStripButton1, Me.RefreshButton})
        Me.ActionToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ActionToolStrip.Name = "ActionToolStrip"
        Me.ActionToolStrip.Size = New System.Drawing.Size(891, 39)
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
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.MPIClient.My.Resources.Resources.Log_Out_icon__1_
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(72, 36)
        Me.ToolStripButton1.Text = "Close"
        '
        'RefreshButton
        '
        Me.RefreshButton.Image = Global.MPIClient.My.Resources.Resources.Other_Power_Restart_Metro_icon
        Me.RefreshButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.RefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RefreshButton.Name = "RefreshButton"
        Me.RefreshButton.Size = New System.Drawing.Size(82, 36)
        Me.RefreshButton.Text = "Refresh"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.patientFoundLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 297)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(891, 22)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(704, 133)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Total of Synchronization:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(704, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Number of Succees:"
        '
        'NumOfTotalSynLabel
        '
        Me.NumOfTotalSynLabel.AutoSize = True
        Me.NumOfTotalSynLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NumOfTotalSynLabel.ForeColor = System.Drawing.Color.Blue
        Me.NumOfTotalSynLabel.Location = New System.Drawing.Point(856, 133)
        Me.NumOfTotalSynLabel.Name = "NumOfTotalSynLabel"
        Me.NumOfTotalSynLabel.Size = New System.Drawing.Size(13, 13)
        Me.NumOfTotalSynLabel.TabIndex = 8
        Me.NumOfTotalSynLabel.Text = "0"
        '
        'NumOfSuccessLabel
        '
        Me.NumOfSuccessLabel.AutoSize = True
        Me.NumOfSuccessLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NumOfSuccessLabel.ForeColor = System.Drawing.Color.Blue
        Me.NumOfSuccessLabel.Location = New System.Drawing.Point(856, 48)
        Me.NumOfSuccessLabel.Name = "NumOfSuccessLabel"
        Me.NumOfSuccessLabel.Size = New System.Drawing.Size(13, 13)
        Me.NumOfSuccessLabel.TabIndex = 8
        Me.NumOfSuccessLabel.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(704, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(115, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Number of Duplication:"
        '
        'NumOfDuplicationLabel
        '
        Me.NumOfDuplicationLabel.AutoSize = True
        Me.NumOfDuplicationLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NumOfDuplicationLabel.ForeColor = System.Drawing.Color.Blue
        Me.NumOfDuplicationLabel.Location = New System.Drawing.Point(856, 75)
        Me.NumOfDuplicationLabel.Name = "NumOfDuplicationLabel"
        Me.NumOfDuplicationLabel.Size = New System.Drawing.Size(13, 13)
        Me.NumOfDuplicationLabel.TabIndex = 8
        Me.NumOfDuplicationLabel.Text = "0"
        '
        'NumOfErrorLabel
        '
        Me.NumOfErrorLabel.AutoSize = True
        Me.NumOfErrorLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NumOfErrorLabel.ForeColor = System.Drawing.Color.Blue
        Me.NumOfErrorLabel.Location = New System.Drawing.Point(856, 104)
        Me.NumOfErrorLabel.Name = "NumOfErrorLabel"
        Me.NumOfErrorLabel.Size = New System.Drawing.Size(13, 13)
        Me.NumOfErrorLabel.TabIndex = 8
        Me.NumOfErrorLabel.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(704, 104)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Number of Error:"
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
        'PatientBindingSource
        '
        Me.PatientBindingSource.AllowNew = True
        Me.PatientBindingSource.DataSource = GetType(MPIClient.DataAccess.Model.Patient)
        '
        'Synchronization
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(891, 319)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.NumOfErrorLabel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NumOfDuplicationLabel)
        Me.Controls.Add(Me.NumOfSuccessLabel)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.NumOfTotalSynLabel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ActionToolStrip)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "Synchronization"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Synchronization"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ActionToolStrip.ResumeLayout(False)
        Me.ActionToolStrip.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.PatientBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PatientBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents synchronizationWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents ActionToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents synchronizationButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents RefreshButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PatientIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GenderDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateBirthDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreatedateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdatedateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents patientFoundLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NumOfTotalSynLabel As System.Windows.Forms.Label
    Friend WithEvents NumOfSuccessLabel As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NumOfDuplicationLabel As System.Windows.Forms.Label
    Friend WithEvents NumOfErrorLabel As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
