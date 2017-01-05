<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchResult2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SearchResult2))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ActionToolStrip = New System.Windows.Forms.ToolStrip
        Me.newPatientButton = New System.Windows.Forms.ToolStripButton
        Me.newVisitButton = New System.Windows.Forms.ToolStripButton
        Me.closeButton = New System.Windows.Forms.ToolStripButton
        Me.countLabel = New System.Windows.Forms.ToolStripLabel
        Me.waitingProgress = New System.Windows.Forms.ToolStripProgressBar
        Me.ProgressStatus = New System.Windows.Forms.ToolStripLabel
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.PatientIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GenderText = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Age = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreatedateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdatedateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NumVisit = New System.Windows.Forms.DataGridViewLinkColumn
        Me.PatientBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.countTimer = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.infoLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.patientFoundLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.ActionToolStrip.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PatientBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ActionToolStrip
        '
        Me.ActionToolStrip.AccessibleDescription = Nothing
        Me.ActionToolStrip.AccessibleName = Nothing
        resources.ApplyResources(Me.ActionToolStrip, "ActionToolStrip")
        Me.ActionToolStrip.BackgroundImage = Nothing
        Me.ActionToolStrip.Font = Nothing
        Me.ActionToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newPatientButton, Me.newVisitButton, Me.closeButton, Me.countLabel, Me.waitingProgress, Me.ProgressStatus})
        Me.ActionToolStrip.Name = "ActionToolStrip"
        '
        'newPatientButton
        '
        Me.newPatientButton.AccessibleDescription = Nothing
        Me.newPatientButton.AccessibleName = Nothing
        resources.ApplyResources(Me.newPatientButton, "newPatientButton")
        Me.newPatientButton.BackgroundImage = Nothing
        Me.newPatientButton.Image = Global.MPIClient.My.Resources.Resources.Actions_contact_new_icon
        Me.newPatientButton.Name = "newPatientButton"
        '
        'newVisitButton
        '
        Me.newVisitButton.AccessibleDescription = Nothing
        Me.newVisitButton.AccessibleName = Nothing
        resources.ApplyResources(Me.newVisitButton, "newVisitButton")
        Me.newVisitButton.BackgroundImage = Nothing
        Me.newVisitButton.Image = Global.MPIClient.My.Resources.Resources.Folder_History_icon
        Me.newVisitButton.Name = "newVisitButton"
        '
        'closeButton
        '
        Me.closeButton.AccessibleDescription = Nothing
        Me.closeButton.AccessibleName = Nothing
        resources.ApplyResources(Me.closeButton, "closeButton")
        Me.closeButton.BackgroundImage = Nothing
        Me.closeButton.Image = Global.MPIClient.My.Resources.Resources.Log_Out_icon__1_
        Me.closeButton.Name = "closeButton"
        '
        'countLabel
        '
        Me.countLabel.AccessibleDescription = Nothing
        Me.countLabel.AccessibleName = Nothing
        resources.ApplyResources(Me.countLabel, "countLabel")
        Me.countLabel.BackgroundImage = Nothing
        Me.countLabel.Name = "countLabel"
        '
        'waitingProgress
        '
        Me.waitingProgress.AccessibleDescription = Nothing
        Me.waitingProgress.AccessibleName = Nothing
        resources.ApplyResources(Me.waitingProgress, "waitingProgress")
        Me.waitingProgress.Name = "waitingProgress"
        Me.waitingProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        '
        'ProgressStatus
        '
        Me.ProgressStatus.AccessibleDescription = Nothing
        Me.ProgressStatus.AccessibleName = Nothing
        resources.ApplyResources(Me.ProgressStatus, "ProgressStatus")
        Me.ProgressStatus.BackgroundImage = Nothing
        Me.ProgressStatus.Name = "ProgressStatus"
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
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Khmer OS System", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PatientIDDataGridViewTextBoxColumn, Me.GenderText, Me.Age, Me.CreatedateDataGridViewTextBoxColumn, Me.UpdatedateDataGridViewTextBoxColumn, Me.NumVisit})
        Me.DataGridView1.DataSource = Me.PatientBindingSource
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.NullValue = Nothing
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.Font = Nothing
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'PatientIDDataGridViewTextBoxColumn
        '
        Me.PatientIDDataGridViewTextBoxColumn.DataPropertyName = "PatientID"
        resources.ApplyResources(Me.PatientIDDataGridViewTextBoxColumn, "PatientIDDataGridViewTextBoxColumn")
        Me.PatientIDDataGridViewTextBoxColumn.Name = "PatientIDDataGridViewTextBoxColumn"
        Me.PatientIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GenderText
        '
        Me.GenderText.DataPropertyName = "GenderText"
        resources.ApplyResources(Me.GenderText, "GenderText")
        Me.GenderText.Name = "GenderText"
        Me.GenderText.ReadOnly = True
        '
        'Age
        '
        Me.Age.DataPropertyName = "Age"
        resources.ApplyResources(Me.Age, "Age")
        Me.Age.Name = "Age"
        Me.Age.ReadOnly = True
        '
        'CreatedateDataGridViewTextBoxColumn
        '
        Me.CreatedateDataGridViewTextBoxColumn.DataPropertyName = "Createdate"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.CreatedateDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        resources.ApplyResources(Me.CreatedateDataGridViewTextBoxColumn, "CreatedateDataGridViewTextBoxColumn")
        Me.CreatedateDataGridViewTextBoxColumn.Name = "CreatedateDataGridViewTextBoxColumn"
        Me.CreatedateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'UpdatedateDataGridViewTextBoxColumn
        '
        Me.UpdatedateDataGridViewTextBoxColumn.DataPropertyName = "Updatedate"
        resources.ApplyResources(Me.UpdatedateDataGridViewTextBoxColumn, "UpdatedateDataGridViewTextBoxColumn")
        Me.UpdatedateDataGridViewTextBoxColumn.Name = "UpdatedateDataGridViewTextBoxColumn"
        Me.UpdatedateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NumVisit
        '
        Me.NumVisit.DataPropertyName = "NumVisit"
        resources.ApplyResources(Me.NumVisit, "NumVisit")
        Me.NumVisit.Name = "NumVisit"
        Me.NumVisit.ReadOnly = True
        '
        'PatientBindingSource
        '
        Me.PatientBindingSource.AllowNew = True
        Me.PatientBindingSource.DataSource = GetType(MPIClient.DataAccess.Model.Patient)
        '
        'countTimer
        '
        Me.countTimer.Interval = 1000
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AccessibleDescription = Nothing
        Me.StatusStrip1.AccessibleName = Nothing
        resources.ApplyResources(Me.StatusStrip1, "StatusStrip1")
        Me.StatusStrip1.BackgroundImage = Nothing
        Me.StatusStrip1.Font = Nothing
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.infoLabel, Me.ToolStripStatusLabel2, Me.patientFoundLabel})
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
        'infoLabel
        '
        Me.infoLabel.AccessibleDescription = Nothing
        Me.infoLabel.AccessibleName = Nothing
        resources.ApplyResources(Me.infoLabel, "infoLabel")
        Me.infoLabel.BackgroundImage = Nothing
        Me.infoLabel.Name = "infoLabel"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.AccessibleDescription = Nothing
        Me.ToolStripStatusLabel2.AccessibleName = Nothing
        resources.ApplyResources(Me.ToolStripStatusLabel2, "ToolStripStatusLabel2")
        Me.ToolStripStatusLabel2.BackgroundImage = Nothing
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        '
        'patientFoundLabel
        '
        Me.patientFoundLabel.AccessibleDescription = Nothing
        Me.patientFoundLabel.AccessibleName = Nothing
        resources.ApplyResources(Me.patientFoundLabel, "patientFoundLabel")
        Me.patientFoundLabel.BackgroundImage = Nothing
        Me.patientFoundLabel.Name = "patientFoundLabel"
        '
        'SearchResult2
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ActionToolStrip)
        Me.Font = Nothing
        Me.Icon = Nothing
        Me.Name = "SearchResult2"
        Me.ActionToolStrip.ResumeLayout(False)
        Me.ActionToolStrip.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PatientBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ActionToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents newPatientButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents newVisitButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents closeButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents waitingProgress As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ProgressStatus As System.Windows.Forms.ToolStripLabel
    Friend WithEvents countLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents PatientBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents countTimer As System.Windows.Forms.Timer
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents infoLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents patientFoundLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents PatientIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GenderText As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Age As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreatedateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdatedateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumVisit As System.Windows.Forms.DataGridViewLinkColumn
End Class
