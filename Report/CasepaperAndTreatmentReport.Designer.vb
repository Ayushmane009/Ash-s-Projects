<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CasepaperAndTreatmentReport
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
        Me.DCMDataSet6 = New DentalClinicMS.DCMDataSet6()
        Me.CasepaperheaderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CasepaperheaderTableAdapter = New DentalClinicMS.DCMDataSet6TableAdapters.CasepaperheaderTableAdapter()
        CType(Me.DCMDataSet6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CasepaperheaderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.CasepaperheaderBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "DentalClinicMS.Report6.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(165, 101)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(731, 382)
        Me.ReportViewer1.TabIndex = 0
        '
        'DCMDataSet6
        '
        Me.DCMDataSet6.DataSetName = "DCMDataSet6"
        Me.DCMDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CasepaperheaderBindingSource
        '
        Me.CasepaperheaderBindingSource.DataMember = "Casepaperheader"
        Me.CasepaperheaderBindingSource.DataSource = Me.DCMDataSet6
        '
        'CasepaperheaderTableAdapter
        '
        Me.CasepaperheaderTableAdapter.ClearBeforeFill = True
        '
        'CasepaperAndTreatmentReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 632)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "CasepaperAndTreatmentReport"
        Me.Text = "CasepaperAndTreatmentReport"
        CType(Me.DCMDataSet6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CasepaperheaderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents CasepaperheaderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DCMDataSet6 As DentalClinicMS.DCMDataSet6
    Friend WithEvents CasepaperheaderTableAdapter As DentalClinicMS.DCMDataSet6TableAdapters.CasepaperheaderTableAdapter
End Class
