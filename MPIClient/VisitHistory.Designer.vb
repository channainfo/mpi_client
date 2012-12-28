<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VisitHistory
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.visitDataGrid = New System.Windows.Forms.DataGridView
        Me.VisitBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.closeButton = New System.Windows.Forms.Button
        Me.patientIDLabel = New System.Windows.Forms.Label
        Me.dateOfBirthLabel = New System.Windows.Forms.Label
        Me.genderLabel = New System.Windows.Forms.Label
        Me.ServiceNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SiteCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VisitDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExternalCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExternalCode2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InfoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.visitDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VisitBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Patient ID:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Date of Birth:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Gender:"
        '
        'visitDataGrid
        '
        Me.visitDataGrid.AllowUserToAddRows = False
        Me.visitDataGrid.AllowUserToDeleteRows = False
        Me.visitDataGrid.AllowUserToOrderColumns = True
        Me.visitDataGrid.AutoGenerateColumns = False
        Me.visitDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.visitDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ServiceNameDataGridViewTextBoxColumn, Me.SiteCodeDataGridViewTextBoxColumn, Me.VisitDateDataGridViewTextBoxColumn, Me.ExternalCodeDataGridViewTextBoxColumn, Me.ExternalCode2, Me.InfoDataGridViewTextBoxColumn})
        Me.visitDataGrid.DataSource = Me.VisitBindingSource
        Me.visitDataGrid.Location = New System.Drawing.Point(15, 95)
        Me.visitDataGrid.Name = "visitDataGrid"
        Me.visitDataGrid.ReadOnly = True
        Me.visitDataGrid.Size = New System.Drawing.Size(643, 180)
        Me.visitDataGrid.TabIndex = 1
        '
        'VisitBindingSource
        '
        Me.VisitBindingSource.DataSource = GetType(MPIClient.DataAccess.Model.Visit)
        '
        'closeButton
        '
        Me.closeButton.Location = New System.Drawing.Point(489, 9)
        Me.closeButton.Name = "closeButton"
        Me.closeButton.Size = New System.Drawing.Size(75, 23)
        Me.closeButton.TabIndex = 2
        Me.closeButton.Text = "Close"
        Me.closeButton.UseVisualStyleBackColor = True
        '
        'patientIDLabel
        '
        Me.patientIDLabel.AutoSize = True
        Me.patientIDLabel.Location = New System.Drawing.Point(100, 9)
        Me.patientIDLabel.Name = "patientIDLabel"
        Me.patientIDLabel.Size = New System.Drawing.Size(39, 13)
        Me.patientIDLabel.TabIndex = 3
        Me.patientIDLabel.Text = "Label4"
        '
        'dateOfBirthLabel
        '
        Me.dateOfBirthLabel.AutoSize = True
        Me.dateOfBirthLabel.Location = New System.Drawing.Point(100, 34)
        Me.dateOfBirthLabel.Name = "dateOfBirthLabel"
        Me.dateOfBirthLabel.Size = New System.Drawing.Size(39, 13)
        Me.dateOfBirthLabel.TabIndex = 3
        Me.dateOfBirthLabel.Text = "Label4"
        '
        'genderLabel
        '
        Me.genderLabel.AutoSize = True
        Me.genderLabel.Location = New System.Drawing.Point(100, 59)
        Me.genderLabel.Name = "genderLabel"
        Me.genderLabel.Size = New System.Drawing.Size(39, 13)
        Me.genderLabel.TabIndex = 3
        Me.genderLabel.Text = "Label4"
        '
        'ServiceNameDataGridViewTextBoxColumn
        '
        Me.ServiceNameDataGridViewTextBoxColumn.DataPropertyName = "ServiceName"
        Me.ServiceNameDataGridViewTextBoxColumn.HeaderText = "ServiceName"
        Me.ServiceNameDataGridViewTextBoxColumn.Name = "ServiceNameDataGridViewTextBoxColumn"
        Me.ServiceNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SiteCodeDataGridViewTextBoxColumn
        '
        Me.SiteCodeDataGridViewTextBoxColumn.DataPropertyName = "SiteCode"
        Me.SiteCodeDataGridViewTextBoxColumn.HeaderText = "SiteCode"
        Me.SiteCodeDataGridViewTextBoxColumn.Name = "SiteCodeDataGridViewTextBoxColumn"
        Me.SiteCodeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'VisitDateDataGridViewTextBoxColumn
        '
        Me.VisitDateDataGridViewTextBoxColumn.DataPropertyName = "VisitDate"
        Me.VisitDateDataGridViewTextBoxColumn.HeaderText = "VisitDate"
        Me.VisitDateDataGridViewTextBoxColumn.Name = "VisitDateDataGridViewTextBoxColumn"
        Me.VisitDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ExternalCodeDataGridViewTextBoxColumn
        '
        Me.ExternalCodeDataGridViewTextBoxColumn.DataPropertyName = "ExternalCode"
        Me.ExternalCodeDataGridViewTextBoxColumn.HeaderText = "ExternalCode"
        Me.ExternalCodeDataGridViewTextBoxColumn.Name = "ExternalCodeDataGridViewTextBoxColumn"
        Me.ExternalCodeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ExternalCode2
        '
        Me.ExternalCode2.DataPropertyName = "ExternalCode2"
        Me.ExternalCode2.HeaderText = "ExternalCode2"
        Me.ExternalCode2.Name = "ExternalCode2"
        Me.ExternalCode2.ReadOnly = True
        '
        'InfoDataGridViewTextBoxColumn
        '
        Me.InfoDataGridViewTextBoxColumn.DataPropertyName = "Info"
        Me.InfoDataGridViewTextBoxColumn.HeaderText = "Info"
        Me.InfoDataGridViewTextBoxColumn.Name = "InfoDataGridViewTextBoxColumn"
        Me.InfoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'VisitHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 291)
        Me.Controls.Add(Me.genderLabel)
        Me.Controls.Add(Me.dateOfBirthLabel)
        Me.Controls.Add(Me.patientIDLabel)
        Me.Controls.Add(Me.closeButton)
        Me.Controls.Add(Me.visitDataGrid)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "VisitHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VisitHistory"
        CType(Me.visitDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VisitBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents visitDataGrid As System.Windows.Forms.DataGridView
    Friend WithEvents closeButton As System.Windows.Forms.Button
    Friend WithEvents patientIDLabel As System.Windows.Forms.Label
    Friend WithEvents dateOfBirthLabel As System.Windows.Forms.Label
    Friend WithEvents genderLabel As System.Windows.Forms.Label
    Friend WithEvents ExternalIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VisitBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ServiceNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SiteCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VisitDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExternalCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExternalCode2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InfoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
