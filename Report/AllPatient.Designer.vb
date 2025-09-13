<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AllPatient
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
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.DCMDataSet8 = New DentalClinicMS.DCMDataSet8()
        Me.PatientdetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PatientdetailsTableAdapter = New DentalClinicMS.DCMDataSet8TableAdapters.PatientdetailsTableAdapter()
        CType(Me.DCMDataSet8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PatientdetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.PatientdetailsBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "DentalClinicMS.Report2.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1142, 704)
        Me.ReportViewer1.TabIndex = 0
        '
        'DCMDataSet8
        '
        Me.DCMDataSet8.DataSetName = "DCMDataSet8"
        Me.DCMDataSet8.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PatientdetailsBindingSource
        '
        Me.PatientdetailsBindingSource.DataMember = "Patientdetails"
        Me.PatientdetailsBindingSource.DataSource = Me.DCMDataSet8
        '
        'PatientdetailsTableAdapter
        '
        Me.PatientdetailsTableAdapter.ClearBeforeFill = True
        '
        'AllPatient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 704)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "AllPatient"
        Me.Text = "s"
        CType(Me.DCMDataSet8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PatientdetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents PatientdetailsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DCMDataSet8 As DentalClinicMS.DCMDataSet8
    Friend WithEvents PatientdetailsTableAdapter As DentalClinicMS.DCMDataSet8TableAdapters.PatientdetailsTableAdapter
End Class
