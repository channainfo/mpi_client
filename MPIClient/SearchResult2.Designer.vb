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
        Me.ActionToolStrip = New System.Windows.Forms.ToolStrip
        Me.newPatientButton = New System.Windows.Forms.ToolStripButton
        Me.newVisitButton = New System.Windows.Forms.ToolStripButton
        Me.closeButton = New System.Windows.Forms.ToolStripButton
        Me.countLabel = New System.Windows.Forms.ToolStripLabel
        Me.waitingProgress = New System.Windows.Forms.ToolStripProgressBar
        Me.ProgressStatus = New System.Windows.Forms.ToolStripLabel
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.GenderText = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Age = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NumVisit = New System.Windows.Forms.DataGridViewLinkColumn
        Me.countTimer = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.infoLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.PatientIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreatedateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdatedateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PatientBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ActionToolStrip.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PatientBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ActionToolStrip
        '
        Me.ActionToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newPatientButton, Me.newVisitButton, Me.closeButton, Me.countLabel, Me.waitingProgress, Me.ProgressStatus})
        Me.ActionToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ActionToolStrip.Name = "ActionToolStrip"
        Me.ActionToolStrip.Size = New System.Drawing.Size(950, 39)
        Me.ActionToolStrip.TabIndex = 1
        Me.ActionToolStrip.Text = "ToolStrip1"
        '
        'newPatientButton
        '
        Me.newPatientButton.Image = Global.MPIClient.My.Resources.Resources.Actions_contact_new_icon
        Me.newPatientButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.newPatientButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.newPatientButton.Name = "newPatientButton"
        Me.newPatientButton.Size = New System.Drawing.Size(107, 36)
        Me.newPatientButton.Text = "New Patient"
        '
        'newVisitButton
        '
        Me.newVisitButton.Image = Global.MPIClient.My.Resources.Resources.Folder_History_icon
        Me.newVisitButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.newVisitButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.newVisitButton.Name = "newVisitButton"
        Me.newVisitButton.Size = New System.Drawing.Size(92, 36)
        Me.newVisitButton.Text = "New Visit"
        '
        'closeButton
        '
        Me.closeButton.Image = Global.MPIClient.My.Resources.Resources.Log_Out_icon__1_
        Me.closeButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.closeButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.closeButton.Name = "closeButton"
        Me.closeButton.Size = New System.Drawing.Size(61, 36)
        Me.closeButton.Text = "Exit"
        '
        'countLabel
        '
        Me.countLabel.Name = "countLabel"
        Me.countLabel.Size = New System.Drawing.Size(13, 36)
        Me.countLabel.Text = "1"
        '
        'waitingProgress
        '
        Me.waitingProgress.Name = "waitingProgress"
        Me.waitingProgress.Size = New System.Drawing.Size(100, 36)
        Me.waitingProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        '
        'ProgressStatus
        '
        Me.ProgressStatus.Name = "ProgressStatus"
        Me.ProgressStatus.Size = New System.Drawing.Size(0, 36)
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PatientIDDataGridViewTextBoxColumn, Me.GenderText, Me.Age, Me.CreatedateDataGridViewTextBoxColumn, Me.UpdatedateDataGridViewTextBoxColumn, Me.NumVisit})
        Me.DataGridView1.DataSource = Me.PatientBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(12, 52)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(926, 379)
        Me.DataGridView1.TabIndex = 2
        '
        'GenderText
        '
        Me.GenderText.DataPropertyName = "GenderText"
        Me.GenderText.HeaderText = "Gender"
        Me.GenderText.Name = "GenderText"
        Me.GenderText.ReadOnly = True
        '
        'Age
        '
        Me.Age.DataPropertyName = "Age"
        Me.Age.HeaderText = "Age"
        Me.Age.Name = "Age"
        Me.Age.ReadOnly = True
        '
        'NumVisit
        '
        Me.NumVisit.DataPropertyName = "NumVisit"
        Me.NumVisit.HeaderText = "Visit History"
        Me.NumVisit.Name = "NumVisit"
        Me.NumVisit.ReadOnly = True
        '
        'countTimer
        '
        Me.countTimer.Interval = 1000
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.infoLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 454)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(950, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(42, 17)
        Me.ToolStripStatusLabel1.Text = "Status:"
        '
        'infoLabel
        '
        Me.infoLabel.Name = "infoLabel"
        Me.infoLabel.Size = New System.Drawing.Size(0, 17)
        '
        'PatientIDDataGridViewTextBoxColumn
        '
        Me.PatientIDDataGridViewTextBoxColumn.DataPropertyName = "PatientID"
        Me.PatientIDDataGridViewTextBoxColumn.HeaderText = "PatientID"
        Me.PatientIDDataGridViewTextBoxColumn.Name = "PatientIDDataGridViewTextBoxColumn"
        Me.PatientIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CreatedateDataGridViewTextBoxColumn
        '
        Me.CreatedateDataGridViewTextBoxColumn.DataPropertyName = "Createdate"
        Me.CreatedateDataGridViewTextBoxColumn.HeaderText = "Createdate"
        Me.CreatedateDataGridViewTextBoxColumn.Name = "CreatedateDataGridViewTextBoxColumn"
        Me.CreatedateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'UpdatedateDataGridViewTextBoxColumn
        '
        Me.UpdatedateDataGridViewTextBoxColumn.DataPropertyName = "Updatedate"
        Me.UpdatedateDataGridViewTextBoxColumn.HeaderText = "Updatedate"
        Me.UpdatedateDataGridViewTextBoxColumn.Name = "UpdatedateDataGridViewTextBoxColumn"
        Me.UpdatedateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PatientBindingSource
        '
        Me.PatientBindingSource.AllowNew = True
        Me.PatientBindingSource.DataSource = GetType(MPIClient.DataAccess.Model.Patient)
        '
        'SearchResult2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(950, 476)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ActionToolStrip)
        Me.Name = "SearchResult2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search Result"
        Me.ActionToolStrip.ResumeLayout(False)
        Me.ActionToolStrip.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.PatientBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents PatientIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GenderText As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Age As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreatedateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdatedateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumVisit As System.Windows.Forms.DataGridViewLinkColumn
End Class
