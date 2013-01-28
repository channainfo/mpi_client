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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ManualSyn))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.PatientBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.genderLabel = New System.Windows.Forms.Label
        Me.dateOfBirthLabel = New System.Windows.Forms.Label
        Me.patientIDLabel = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ActionToolStrip = New System.Windows.Forms.ToolStrip
        Me.synchronizeButton = New System.Windows.Forms.ToolStripButton
        Me.closeButton = New System.Windows.Forms.ToolStripButton
        Me.PatientIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GenderDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateBirthDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreatedateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdatedateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PatientBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ActionToolStrip.SuspendLayout()
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PatientIDDataGridViewTextBoxColumn, Me.GenderDataGridViewTextBoxColumn, Me.DateBirthDataGridViewTextBoxColumn, Me.CreatedateDataGridViewTextBoxColumn, Me.UpdatedateDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.PatientBindingSource
        Me.DataGridView1.Font = Nothing
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'PatientBindingSource
        '
        Me.PatientBindingSource.AllowNew = True
        Me.PatientBindingSource.DataSource = GetType(MPIClient.DataAccess.Model.Patient)
        '
        'genderLabel
        '
        Me.genderLabel.AccessibleDescription = Nothing
        Me.genderLabel.AccessibleName = Nothing
        resources.ApplyResources(Me.genderLabel, "genderLabel")
        Me.genderLabel.Font = Nothing
        Me.genderLabel.Name = "genderLabel"
        '
        'dateOfBirthLabel
        '
        Me.dateOfBirthLabel.AccessibleDescription = Nothing
        Me.dateOfBirthLabel.AccessibleName = Nothing
        resources.ApplyResources(Me.dateOfBirthLabel, "dateOfBirthLabel")
        Me.dateOfBirthLabel.Font = Nothing
        Me.dateOfBirthLabel.Name = "dateOfBirthLabel"
        '
        'patientIDLabel
        '
        Me.patientIDLabel.AccessibleDescription = Nothing
        Me.patientIDLabel.AccessibleName = Nothing
        resources.ApplyResources(Me.patientIDLabel, "patientIDLabel")
        Me.patientIDLabel.Font = Nothing
        Me.patientIDLabel.Name = "patientIDLabel"
        '
        'Label3
        '
        Me.Label3.AccessibleDescription = Nothing
        Me.Label3.AccessibleName = Nothing
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label2
        '
        Me.Label2.AccessibleDescription = Nothing
        Me.Label2.AccessibleName = Nothing
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label1
        '
        Me.Label1.AccessibleDescription = Nothing
        Me.Label1.AccessibleName = Nothing
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'ActionToolStrip
        '
        Me.ActionToolStrip.AccessibleDescription = Nothing
        Me.ActionToolStrip.AccessibleName = Nothing
        resources.ApplyResources(Me.ActionToolStrip, "ActionToolStrip")
        Me.ActionToolStrip.BackgroundImage = Nothing
        Me.ActionToolStrip.Font = Nothing
        Me.ActionToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.synchronizeButton, Me.closeButton})
        Me.ActionToolStrip.Name = "ActionToolStrip"
        '
        'synchronizeButton
        '
        Me.synchronizeButton.AccessibleDescription = Nothing
        Me.synchronizeButton.AccessibleName = Nothing
        resources.ApplyResources(Me.synchronizeButton, "synchronizeButton")
        Me.synchronizeButton.BackgroundImage = Nothing
        Me.synchronizeButton.Image = Global.MPIClient.My.Resources.Resources.Synchronize_icon__1_
        Me.synchronizeButton.Name = "synchronizeButton"
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
        Me.CreatedateDataGridViewTextBoxColumn.DataPropertyName = "Createdate"
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
        'ManualSyn
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.ActionToolStrip)
        Me.Controls.Add(Me.genderLabel)
        Me.Controls.Add(Me.dateOfBirthLabel)
        Me.Controls.Add(Me.patientIDLabel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Font = Nothing
        Me.Icon = Nothing
        Me.Name = "ManualSyn"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PatientBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ActionToolStrip.ResumeLayout(False)
        Me.ActionToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents PatientBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents genderLabel As System.Windows.Forms.Label
    Friend WithEvents dateOfBirthLabel As System.Windows.Forms.Label
    Friend WithEvents patientIDLabel As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ActionToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents synchronizeButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents closeButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PatientIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GenderDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateBirthDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreatedateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdatedateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
