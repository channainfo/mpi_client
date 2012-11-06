<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManualSyn
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
        Me.CreatedateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdatedateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PatientBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.genderLabel = New System.Windows.Forms.Label
        Me.dateOfBirthLabel = New System.Windows.Forms.Label
        Me.patientIDLabel = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.synchronizationButton = New System.Windows.Forms.Button
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PatientIDDataGridViewTextBoxColumn, Me.GenderDataGridViewTextBoxColumn, Me.DateBirthDataGridViewTextBoxColumn, Me.CreatedateDataGridViewTextBoxColumn, Me.UpdatedateDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.PatientBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(12, 90)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(569, 257)
        Me.DataGridView1.TabIndex = 4
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
        'genderLabel
        '
        Me.genderLabel.AutoSize = True
        Me.genderLabel.Location = New System.Drawing.Point(100, 59)
        Me.genderLabel.Name = "genderLabel"
        Me.genderLabel.Size = New System.Drawing.Size(39, 13)
        Me.genderLabel.TabIndex = 8
        Me.genderLabel.Text = "Label4"
        '
        'dateOfBirthLabel
        '
        Me.dateOfBirthLabel.AutoSize = True
        Me.dateOfBirthLabel.Location = New System.Drawing.Point(100, 34)
        Me.dateOfBirthLabel.Name = "dateOfBirthLabel"
        Me.dateOfBirthLabel.Size = New System.Drawing.Size(39, 13)
        Me.dateOfBirthLabel.TabIndex = 9
        Me.dateOfBirthLabel.Text = "Label4"
        '
        'patientIDLabel
        '
        Me.patientIDLabel.AutoSize = True
        Me.patientIDLabel.Location = New System.Drawing.Point(100, 9)
        Me.patientIDLabel.Name = "patientIDLabel"
        Me.patientIDLabel.Size = New System.Drawing.Size(39, 13)
        Me.patientIDLabel.TabIndex = 10
        Me.patientIDLabel.Text = "Label4"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Gender:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Date of Birth:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Patient ID:"
        '
        'synchronizationButton
        '
        Me.synchronizationButton.Location = New System.Drawing.Point(506, 9)
        Me.synchronizationButton.Name = "synchronizationButton"
        Me.synchronizationButton.Size = New System.Drawing.Size(75, 23)
        Me.synchronizationButton.TabIndex = 11
        Me.synchronizationButton.Text = "Synchronize"
        Me.synchronizationButton.UseVisualStyleBackColor = True
        '
        'ManualSyn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(597, 367)
        Me.Controls.Add(Me.synchronizationButton)
        Me.Controls.Add(Me.genderLabel)
        Me.Controls.Add(Me.dateOfBirthLabel)
        Me.Controls.Add(Me.patientIDLabel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "ManualSyn"
        Me.Text = "ManualSyn"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PatientBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents PatientIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GenderDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateBirthDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreatedateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdatedateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PatientBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents genderLabel As System.Windows.Forms.Label
    Friend WithEvents dateOfBirthLabel As System.Windows.Forms.Label
    Friend WithEvents patientIDLabel As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents synchronizationButton As System.Windows.Forms.Button
End Class
