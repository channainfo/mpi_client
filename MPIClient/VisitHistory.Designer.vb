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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VisitHistory))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.visitDataGrid = New System.Windows.Forms.DataGridView
        Me.VisitBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.patientIDLabel = New System.Windows.Forms.Label
        Me.dateOfBirthLabel = New System.Windows.Forms.Label
        Me.genderLabel = New System.Windows.Forms.Label
        Me.ActionToolStrip = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ProgressStatus = New System.Windows.Forms.ToolStripLabel
        Me.ServiceNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SiteCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SiteName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VisitDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExternalCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExternalCode2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.InfoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.visitDataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VisitBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ActionToolStrip.SuspendLayout()
        Me.SuspendLayout()
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
        'Label3
        '
        Me.Label3.AccessibleDescription = Nothing
        Me.Label3.AccessibleName = Nothing
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'visitDataGrid
        '
        Me.visitDataGrid.AccessibleDescription = Nothing
        Me.visitDataGrid.AccessibleName = Nothing
        Me.visitDataGrid.AllowUserToAddRows = False
        Me.visitDataGrid.AllowUserToDeleteRows = False
        Me.visitDataGrid.AllowUserToOrderColumns = True
        resources.ApplyResources(Me.visitDataGrid, "visitDataGrid")
        Me.visitDataGrid.AutoGenerateColumns = False
        Me.visitDataGrid.BackgroundImage = Nothing
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.visitDataGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.visitDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.visitDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ServiceNameDataGridViewTextBoxColumn, Me.SiteCodeDataGridViewTextBoxColumn, Me.SiteName, Me.VisitDateDataGridViewTextBoxColumn, Me.ExternalCodeDataGridViewTextBoxColumn, Me.ExternalCode2, Me.InfoDataGridViewTextBoxColumn})
        Me.visitDataGrid.DataSource = Me.VisitBindingSource
        Me.visitDataGrid.Font = Nothing
        Me.visitDataGrid.Name = "visitDataGrid"
        Me.visitDataGrid.ReadOnly = True
        '
        'VisitBindingSource
        '
        Me.VisitBindingSource.DataSource = GetType(MPIClient.DataAccess.Model.Visit)
        '
        'patientIDLabel
        '
        Me.patientIDLabel.AccessibleDescription = Nothing
        Me.patientIDLabel.AccessibleName = Nothing
        resources.ApplyResources(Me.patientIDLabel, "patientIDLabel")
        Me.patientIDLabel.Font = Nothing
        Me.patientIDLabel.Name = "patientIDLabel"
        '
        'dateOfBirthLabel
        '
        Me.dateOfBirthLabel.AccessibleDescription = Nothing
        Me.dateOfBirthLabel.AccessibleName = Nothing
        resources.ApplyResources(Me.dateOfBirthLabel, "dateOfBirthLabel")
        Me.dateOfBirthLabel.Font = Nothing
        Me.dateOfBirthLabel.Name = "dateOfBirthLabel"
        '
        'genderLabel
        '
        Me.genderLabel.AccessibleDescription = Nothing
        Me.genderLabel.AccessibleName = Nothing
        resources.ApplyResources(Me.genderLabel, "genderLabel")
        Me.genderLabel.Font = Nothing
        Me.genderLabel.Name = "genderLabel"
        '
        'ActionToolStrip
        '
        Me.ActionToolStrip.AccessibleDescription = Nothing
        Me.ActionToolStrip.AccessibleName = Nothing
        resources.ApplyResources(Me.ActionToolStrip, "ActionToolStrip")
        Me.ActionToolStrip.BackgroundImage = Nothing
        Me.ActionToolStrip.Font = Nothing
        Me.ActionToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ProgressStatus})
        Me.ActionToolStrip.Name = "ActionToolStrip"
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
        'ProgressStatus
        '
        Me.ProgressStatus.AccessibleDescription = Nothing
        Me.ProgressStatus.AccessibleName = Nothing
        resources.ApplyResources(Me.ProgressStatus, "ProgressStatus")
        Me.ProgressStatus.BackgroundImage = Nothing
        Me.ProgressStatus.Name = "ProgressStatus"
        '
        'ServiceNameDataGridViewTextBoxColumn
        '
        Me.ServiceNameDataGridViewTextBoxColumn.DataPropertyName = "ServiceName"
        resources.ApplyResources(Me.ServiceNameDataGridViewTextBoxColumn, "ServiceNameDataGridViewTextBoxColumn")
        Me.ServiceNameDataGridViewTextBoxColumn.Name = "ServiceNameDataGridViewTextBoxColumn"
        Me.ServiceNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SiteCodeDataGridViewTextBoxColumn
        '
        Me.SiteCodeDataGridViewTextBoxColumn.DataPropertyName = "SiteCode"
        resources.ApplyResources(Me.SiteCodeDataGridViewTextBoxColumn, "SiteCodeDataGridViewTextBoxColumn")
        Me.SiteCodeDataGridViewTextBoxColumn.Name = "SiteCodeDataGridViewTextBoxColumn"
        Me.SiteCodeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SiteName
        '
        Me.SiteName.DataPropertyName = "SiteName"
        resources.ApplyResources(Me.SiteName, "SiteName")
        Me.SiteName.Name = "SiteName"
        Me.SiteName.ReadOnly = True
        '
        'VisitDateDataGridViewTextBoxColumn
        '
        Me.VisitDateDataGridViewTextBoxColumn.DataPropertyName = "VisitDate"
        resources.ApplyResources(Me.VisitDateDataGridViewTextBoxColumn, "VisitDateDataGridViewTextBoxColumn")
        Me.VisitDateDataGridViewTextBoxColumn.Name = "VisitDateDataGridViewTextBoxColumn"
        Me.VisitDateDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ExternalCodeDataGridViewTextBoxColumn
        '
        Me.ExternalCodeDataGridViewTextBoxColumn.DataPropertyName = "ExternalCode"
        resources.ApplyResources(Me.ExternalCodeDataGridViewTextBoxColumn, "ExternalCodeDataGridViewTextBoxColumn")
        Me.ExternalCodeDataGridViewTextBoxColumn.Name = "ExternalCodeDataGridViewTextBoxColumn"
        Me.ExternalCodeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ExternalCode2
        '
        Me.ExternalCode2.DataPropertyName = "ExternalCode2"
        resources.ApplyResources(Me.ExternalCode2, "ExternalCode2")
        Me.ExternalCode2.Name = "ExternalCode2"
        Me.ExternalCode2.ReadOnly = True
        '
        'InfoDataGridViewTextBoxColumn
        '
        Me.InfoDataGridViewTextBoxColumn.DataPropertyName = "Info"
        resources.ApplyResources(Me.InfoDataGridViewTextBoxColumn, "InfoDataGridViewTextBoxColumn")
        Me.InfoDataGridViewTextBoxColumn.Name = "InfoDataGridViewTextBoxColumn"
        Me.InfoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'VisitHistory
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
        Me.Controls.Add(Me.visitDataGrid)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = Nothing
        Me.Icon = Nothing
        Me.Name = "VisitHistory"
        CType(Me.visitDataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VisitBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ActionToolStrip.ResumeLayout(False)
        Me.ActionToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents visitDataGrid As System.Windows.Forms.DataGridView
    Friend WithEvents patientIDLabel As System.Windows.Forms.Label
    Friend WithEvents dateOfBirthLabel As System.Windows.Forms.Label
    Friend WithEvents genderLabel As System.Windows.Forms.Label
    Friend WithEvents ExternalIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VisitBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ActionToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ProgressStatus As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ServiceNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SiteCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SiteName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VisitDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExternalCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExternalCode2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InfoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
