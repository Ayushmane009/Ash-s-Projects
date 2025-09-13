<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PatientAgewise
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.PatientdetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DCMDataSet8 = New DentalClinicMS.DCMDataSet8()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.PatientdetailsTableAdapter = New DentalClinicMS.DCMDataSet8TableAdapters.PatientdetailsTableAdapter()
        Me.DCMDataSet1 = New DentalClinicMS.DCMDataSet1()
        Me.PatientdetailsBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.PatientdetailsTableAdapter1 = New DentalClinicMS.DCMDataSet1TableAdapters.PatientdetailsTableAdapter()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DCMDataSet9 = New DentalClinicMS.DCMDataSet9()
        Me.PrescriptiondetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PrescriptiondetailsTableAdapter = New DentalClinicMS.DCMDataSet9TableAdapters.prescriptiondetailsTableAdapter()
        Me.DCMDataSet10 = New DentalClinicMS.DCMDataSet10()
        Me.PatientdetailsBindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.PatientdetailsTableAdapter2 = New DentalClinicMS.DCMDataSet10TableAdapters.PatientdetailsTableAdapter()
        CType(Me.PatientdetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DCMDataSet8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DCMDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PatientdetailsBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DCMDataSet9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrescriptiondetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DCMDataSet10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PatientdetailsBindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PatientdetailsBindingSource
        '
        Me.PatientdetailsBindingSource.DataMember = "Patientdetails"
        Me.PatientdetailsBindingSource.DataSource = Me.DCMDataSet8
        '
        'DCMDataSet8
        '
        Me.DCMDataSet8.DataSetName = "DCMDataSet8"
        Me.DCMDataSet8.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.PatientdetailsBindingSource2
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "DentalClinicMS.Report4.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 169)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1186, 519)
        Me.ReportViewer1.TabIndex = 0
        '
        'PatientdetailsTableAdapter
        '
        Me.PatientdetailsTableAdapter.ClearBeforeFill = True
        '
        'DCMDataSet1
        '
        Me.DCMDataSet1.DataSetName = "DCMDataSet1"
        Me.DCMDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PatientdetailsBindingSource1
        '
        Me.PatientdetailsBindingSource1.DataMember = "Patientdetails"
        Me.PatientdetailsBindingSource1.DataSource = Me.DCMDataSet1
        '
        'PatientdetailsTableAdapter1
        '
        Me.PatientdetailsTableAdapter1.ClearBeforeFill = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(341, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "From"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(344, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "To"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(429, 13)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 22)
        Me.DateTimePicker1.TabIndex = 3
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(429, 48)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(200, 22)
        Me.DateTimePicker2.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Button1.Location = New System.Drawing.Point(716, 36)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(86, 34)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Submit"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'DCMDataSet9
        '
        Me.DCMDataSet9.DataSetName = "DCMDataSet9"
        Me.DCMDataSet9.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PrescriptiondetailsBindingSource
        '
        Me.PrescriptiondetailsBindingSource.DataMember = "prescriptiondetails"
        Me.PrescriptiondetailsBindingSource.DataSource = Me.DCMDataSet9
        '
        'PrescriptiondetailsTableAdapter
        '
        Me.PrescriptiondetailsTableAdapter.ClearBeforeFill = True
        '
        'DCMDataSet10
        '
        Me.DCMDataSet10.DataSetName = "DCMDataSet10"
        Me.DCMDataSet10.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PatientdetailsBindingSource2
        '
        Me.PatientdetailsBindingSource2.DataMember = "Patientdetails"
        Me.PatientdetailsBindingSource2.DataSource = Me.DCMDataSet10
        '
        'PatientdetailsTableAdapter2
        '
        Me.PatientdetailsTableAdapter2.ClearBeforeFill = True
        '
        'PatientAgewise
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1186, 688)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "PatientAgewise"
        Me.Text = "s"
        CType(Me.PatientdetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DCMDataSet8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DCMDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PatientdetailsBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DCMDataSet9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrescriptiondetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DCMDataSet10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PatientdetailsBindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents PatientdetailsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DCMDataSet8 As DentalClinicMS.DCMDataSet8
    Friend WithEvents PatientdetailsTableAdapter As DentalClinicMS.DCMDataSet8TableAdapters.PatientdetailsTableAdapter
    Friend WithEvents DCMDataSet1 As DentalClinicMS.DCMDataSet1
    Friend WithEvents PatientdetailsBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents PatientdetailsTableAdapter1 As DentalClinicMS.DCMDataSet1TableAdapters.PatientdetailsTableAdapter
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DCMDataSet9 As DentalClinicMS.DCMDataSet9
    Friend WithEvents PrescriptiondetailsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PrescriptiondetailsTableAdapter As DentalClinicMS.DCMDataSet9TableAdapters.prescriptiondetailsTableAdapter
    Friend WithEvents DCMDataSet10 As DentalClinicMS.DCMDataSet10
    Friend WithEvents PatientdetailsBindingSource2 As System.Windows.Forms.BindingSource
    Friend WithEvents PatientdetailsTableAdapter2 As DentalClinicMS.DCMDataSet10TableAdapters.PatientdetailsTableAdapter
End Class
