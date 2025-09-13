Public Class AllDoctorReport

    Private Sub AllDoctorReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.Doctordetails' table. You can move, or remove it, as needed.
        Me.DoctordetailsTableAdapter.Fill(Me.DataSet1.Doctordetails)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class