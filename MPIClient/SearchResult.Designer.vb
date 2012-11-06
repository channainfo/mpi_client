<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchResult
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
        Me.PatientIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GenderDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateBirthDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SynDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.CreatedateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdatedateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NumVisit = New System.Windows.Forms.DataGridViewLinkColumn
        Me.PatientBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.newPatientButton = New System.Windows.Forms.Button
        Me.closeButton = New System.Windows.Forms.Button
        Me.waitingProgress = New System.Windows.Forms.ProgressBar
        Me.countTimer = New System.Windows.Forms.Timer(Me.components)
        Me.countLabel = New System.Windows.Forms.Label
        Me.infoLabel = New System.Windows.Forms.Label
        Me.newVisitButton = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PatientBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PatientIDDataGridViewTextBoxColumn, Me.GenderDataGridViewTextBoxColumn, Me.DateBirthDataGridViewTextBoxColumn, Me.SynDataGridViewCheckBoxColumn, Me.CreatedateDataGridViewTextBoxColumn, Me.UpdatedateDataGridViewTextBoxColumn, Me.NumVisit})
        Me.DataGridView1.DataSource = Me.PatientBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(12, 12)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(735, 257)
        Me.DataGridView1.TabIndex = 0
        '
        'PatientIDDataGridViewTextBoxColumn
        '
        Me.PatientIDDataGridViewTextBoxColumn.DataPropertyName = "PatientID"
        Me.PatientIDDataGridViewTextBoxColumn.HeaderText = "PatientID"
        Me.PatientIDDataGridViewTextBoxColumn.Name = "PatientIDDataGridViewTextBoxColumn"
        Me.PatientIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'GenderDataGridViewTextBoxColumn
        '
        Me.GenderDataGridViewTextBoxColumn.DataPropertyName = "Gender"
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
        'SynDataGridViewCheckBoxColumn
        '
        Me.SynDataGridViewCheckBoxColumn.DataPropertyName = "Syn"
        Me.SynDataGridViewCheckBoxColumn.HeaderText = "Syn"
        Me.SynDataGridViewCheckBoxColumn.Name = "SynDataGridViewCheckBoxColumn"
        Me.SynDataGridViewCheckBoxColumn.ReadOnly = True
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
        'NumVisit
        '
        Me.NumVisit.DataPropertyName = "NumVisit"
        Me.NumVisit.HeaderText = "Visit History"
        Me.NumVisit.Name = "NumVisit"
        Me.NumVisit.ReadOnly = True
        '
        'PatientBindingSource
        '
        Me.PatientBindingSource.AllowNew = True
        Me.PatientBindingSource.DataSource = GetType(MPIClient.DataAccess.Model.Patient)
        '
        'newPatientButton
        '
        Me.newPatientButton.Location = New System.Drawing.Point(762, 12)
        Me.newPatientButton.Name = "newPatientButton"
        Me.newPatientButton.Size = New System.Drawing.Size(109, 23)
        Me.newPatientButton.TabIndex = 1
        Me.newPatientButton.Text = "Enroll New Patient"
        Me.newPatientButton.UseVisualStyleBackColor = True
        '
        'closeButton
        '
        Me.closeButton.Location = New System.Drawing.Point(762, 70)
        Me.closeButton.Name = "closeButton"
        Me.closeButton.Size = New System.Drawing.Size(109, 23)
        Me.closeButton.TabIndex = 1
        Me.closeButton.Text = "Close"
        Me.closeButton.UseVisualStyleBackColor = True
        '
        'waitingProgress
        '
        Me.waitingProgress.Location = New System.Drawing.Point(762, 124)
        Me.waitingProgress.Name = "waitingProgress"
        Me.waitingProgress.Size = New System.Drawing.Size(109, 23)
        Me.waitingProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.waitingProgress.TabIndex = 2
        '
        'countTimer
        '
        Me.countTimer.Interval = 1000
        '
        'countLabel
        '
        Me.countLabel.AutoSize = True
        Me.countLabel.Location = New System.Drawing.Point(807, 109)
        Me.countLabel.Name = "countLabel"
        Me.countLabel.Size = New System.Drawing.Size(13, 13)
        Me.countLabel.TabIndex = 3
        Me.countLabel.Text = "1"
        '
        'infoLabel
        '
        Me.infoLabel.AutoSize = True
        Me.infoLabel.Location = New System.Drawing.Point(293, 272)
        Me.infoLabel.Name = "infoLabel"
        Me.infoLabel.Size = New System.Drawing.Size(0, 13)
        Me.infoLabel.TabIndex = 4
        '
        'newVisitButton
        '
        Me.newVisitButton.Location = New System.Drawing.Point(762, 41)
        Me.newVisitButton.Name = "newVisitButton"
        Me.newVisitButton.Size = New System.Drawing.Size(109, 23)
        Me.newVisitButton.TabIndex = 1
        Me.newVisitButton.Text = "Enroll New Visit"
        Me.newVisitButton.UseVisualStyleBackColor = True
        '
        'SearchResult
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(883, 308)
        Me.Controls.Add(Me.infoLabel)
        Me.Controls.Add(Me.countLabel)
        Me.Controls.Add(Me.waitingProgress)
        Me.Controls.Add(Me.closeButton)
        Me.Controls.Add(Me.newVisitButton)
        Me.Controls.Add(Me.newPatientButton)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "SearchResult"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SearchResult"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PatientBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents newPatientButton As System.Windows.Forms.Button
    Friend WithEvents closeButton As System.Windows.Forms.Button
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateofbirthDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PatientBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents waitingProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents countTimer As System.Windows.Forms.Timer
    Friend WithEvents countLabel As System.Windows.Forms.Label
    Friend WithEvents infoLabel As System.Windows.Forms.Label
    Friend WithEvents PatientIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GenderDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateBirthDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SynDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CreatedateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdatedateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumVisit As System.Windows.Forms.DataGridViewLinkColumn
    Friend WithEvents newVisitButton As System.Windows.Forms.Button
End Class
