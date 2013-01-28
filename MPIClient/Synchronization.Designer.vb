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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
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
        Me.PatientBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PatientIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GenderDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateBirthDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreatedateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdatedateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ActionToolStrip.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PatientBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AccessibleDescription = Nothing
        Me.DataGridView1.AccessibleName = Nothing
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        resources.ApplyResources(Me.DataGridView1, "DataGridView1")
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.BackgroundImage = Nothing
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PatientIDDataGridViewTextBoxColumn, Me.GenderDataGridViewTextBoxColumn, Me.DateBirthDataGridViewTextBoxColumn, Me.CreatedateDataGridViewTextBoxColumn, Me.UpdatedateDataGridViewTextBoxColumn, Me.Status})
        Me.DataGridView1.DataSource = Me.PatientBindingSource
        Me.DataGridView1.Font = Nothing
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'synchronizationWorker
        '
        Me.synchronizationWorker.WorkerSupportsCancellation = True
        '
        'ActionToolStrip
        '
        Me.ActionToolStrip.AccessibleDescription = Nothing
        Me.ActionToolStrip.AccessibleName = Nothing
        resources.ApplyResources(Me.ActionToolStrip, "ActionToolStrip")
        Me.ActionToolStrip.BackgroundImage = Nothing
        Me.ActionToolStrip.Font = Nothing
        Me.ActionToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.synchronizationButton, Me.ToolStripButton1, Me.RefreshButton})
        Me.ActionToolStrip.Name = "ActionToolStrip"
        '
        'synchronizationButton
        '
        Me.synchronizationButton.AccessibleDescription = Nothing
        Me.synchronizationButton.AccessibleName = Nothing
        resources.ApplyResources(Me.synchronizationButton, "synchronizationButton")
        Me.synchronizationButton.BackgroundImage = Nothing
        Me.synchronizationButton.Image = Global.MPIClient.My.Resources.Resources.Synchronize_icon__1_
        Me.synchronizationButton.Name = "synchronizationButton"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.AccessibleDescription = Nothing
        Me.ToolStripButton1.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripButton1, "ToolStripButton1")
        Me.ToolStripButton1.BackgroundImage = Nothing
        Me.ToolStripButton1.Image = Global.MPIClient.My.Resources.Resources.Log_Out_icon__1_
        Me.ToolStripButton1.Name = "ToolStripButton1"
        '
        'RefreshButton
        '
        Me.RefreshButton.AccessibleDescription = Nothing
        Me.RefreshButton.AccessibleName = Nothing
        resources.ApplyResources(Me.RefreshButton, "RefreshButton")
        Me.RefreshButton.BackgroundImage = Nothing
        Me.RefreshButton.Image = Global.MPIClient.My.Resources.Resources.Other_Power_Restart_Metro_icon
        Me.RefreshButton.Name = "RefreshButton"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AccessibleDescription = Nothing
        Me.StatusStrip1.AccessibleName = Nothing
        resources.ApplyResources(Me.StatusStrip1, "StatusStrip1")
        Me.StatusStrip1.BackgroundImage = Nothing
        Me.StatusStrip1.Font = Nothing
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.patientFoundLabel})
        Me.StatusStrip1.Name = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.AccessibleDescription = Nothing
        Me.ToolStripStatusLabel1.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripStatusLabel1, "ToolStripStatusLabel1")
        Me.ToolStripStatusLabel1.BackgroundImage = Nothing
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        '
        'patientFoundLabel
        '
        Me.patientFoundLabel.AccessibleDescription = Nothing
        Me.patientFoundLabel.AccessibleName = Nothing
        resources.ApplyResources(Me.patientFoundLabel, "patientFoundLabel")
        Me.patientFoundLabel.BackgroundImage = Nothing
        Me.patientFoundLabel.Name = "patientFoundLabel"
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = Nothing
        Me.Label1.AccessibleName = Nothing
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        Me.Label2.AccessibleDescription = Nothing
        Me.Label2.AccessibleName = Nothing
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'NumOfTotalSynLabel
        '
        Me.NumOfTotalSynLabel.AccessibleDescription = Nothing
        Me.NumOfTotalSynLabel.AccessibleName = Nothing
        resources.ApplyResources(Me.NumOfTotalSynLabel, "NumOfTotalSynLabel")
        Me.NumOfTotalSynLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NumOfTotalSynLabel.Font = Nothing
        Me.NumOfTotalSynLabel.ForeColor = System.Drawing.Color.Blue
        Me.NumOfTotalSynLabel.Name = "NumOfTotalSynLabel"
        '
        'NumOfSuccessLabel
        '
        Me.NumOfSuccessLabel.AccessibleDescription = Nothing
        Me.NumOfSuccessLabel.AccessibleName = Nothing
        resources.ApplyResources(Me.NumOfSuccessLabel, "NumOfSuccessLabel")
        Me.NumOfSuccessLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NumOfSuccessLabel.Font = Nothing
        Me.NumOfSuccessLabel.ForeColor = System.Drawing.Color.Blue
        Me.NumOfSuccessLabel.Name = "NumOfSuccessLabel"
        '
        'Label5
        '
        Me.Label5.AccessibleDescription = Nothing
        Me.Label5.AccessibleName = Nothing
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'NumOfDuplicationLabel
        '
        Me.NumOfDuplicationLabel.AccessibleDescription = Nothing
        Me.NumOfDuplicationLabel.AccessibleName = Nothing
        resources.ApplyResources(Me.NumOfDuplicationLabel, "NumOfDuplicationLabel")
        Me.NumOfDuplicationLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NumOfDuplicationLabel.Font = Nothing
        Me.NumOfDuplicationLabel.ForeColor = System.Drawing.Color.Blue
        Me.NumOfDuplicationLabel.Name = "NumOfDuplicationLabel"
        '
        'NumOfErrorLabel
        '
        Me.NumOfErrorLabel.AccessibleDescription = Nothing
        Me.NumOfErrorLabel.AccessibleName = Nothing
        resources.ApplyResources(Me.NumOfErrorLabel, "NumOfErrorLabel")
        Me.NumOfErrorLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NumOfErrorLabel.Font = Nothing
        Me.NumOfErrorLabel.ForeColor = System.Drawing.Color.Blue
        Me.NumOfErrorLabel.Name = "NumOfErrorLabel"
        '
        'Label8
        '
        Me.Label8.AccessibleDescription = Nothing
        Me.Label8.AccessibleName = Nothing
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'PatientBindingSource
        '
        Me.PatientBindingSource.AllowNew = True
        Me.PatientBindingSource.DataSource = GetType(MPIClient.DataAccess.Model.Patient)
        '
        'PatientIDDataGridViewTextBoxColumn
        '
        Me.PatientIDDataGridViewTextBoxColumn.DataPropertyName = "PatientID"
        resources.ApplyResources(Me.PatientIDDataGridViewTextBoxColumn, "PatientIDDataGridViewTextBoxColumn")
        Me.PatientIDDataGridViewTextBoxColumn.Name = "PatientIDDataGridViewTextBoxColumn"
        Me.PatientIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GenderDataGridViewTextBoxColumn
        '
        Me.GenderDataGridViewTextBoxColumn.DataPropertyName = "GenderText"
        resources.ApplyResources(Me.GenderDataGridViewTextBoxColumn, "GenderDataGridViewTextBoxColumn")
        Me.GenderDataGridViewTextBoxColumn.Name = "GenderDataGridViewTextBoxColumn"
        Me.GenderDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DateBirthDataGridViewTextBoxColumn
        '
        Me.DateBirthDataGridViewTextBoxColumn.DataPropertyName = "DateBirth"
        resources.ApplyResources(Me.DateBirthDataGridViewTextBoxColumn, "DateBirthDataGridViewTextBoxColumn")
        Me.DateBirthDataGridViewTextBoxColumn.Name = "DateBirthDataGridViewTextBoxColumn"
        Me.DateBirthDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CreatedateDataGridViewTextBoxColumn
        '
        resources.ApplyResources(Me.CreatedateDataGridViewTextBoxColumn, "CreatedateDataGridViewTextBoxColumn")
        Me.CreatedateDataGridViewTextBoxColumn.Name = "CreatedateDataGridViewTextBoxColumn"
        Me.CreatedateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'UpdatedateDataGridViewTextBoxColumn
        '
        resources.ApplyResources(Me.UpdatedateDataGridViewTextBoxColumn, "UpdatedateDataGridViewTextBoxColumn")
        Me.UpdatedateDataGridViewTextBoxColumn.Name = "UpdatedateDataGridViewTextBoxColumn"
        Me.UpdatedateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'Status
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Status.DefaultCellStyle = DataGridViewCellStyle2
        resources.ApplyResources(Me.Status, "Status")
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        '
        'Synchronization
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Nothing
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
        Me.Font = Nothing
        Me.Icon = Nothing
        Me.Name = "Synchronization"
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
    Friend WithEvents PatientIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GenderDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateBirthDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreatedateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdatedateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
