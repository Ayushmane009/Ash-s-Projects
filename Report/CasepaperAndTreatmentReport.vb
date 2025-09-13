Public Class CasepaperAndTreatmentReport

    Private Sub CasepaperAndTreatmentReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DCMDataSet6.Casepaperheader' table. You can move, or remove it, as needed.
        Me.CasepaperheaderTableAdapter.Fill(Me.DCMDataSet6.Casepaperheader)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class