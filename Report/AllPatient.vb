Public Class AllPatient

    Private Sub AllPatient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DCMDataSet8.Patientdetails' table. You can move, or remove it, as needed.
        Me.PatientdetailsTableAdapter.Fill(Me.DCMDataSet8.Patientdetails)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class