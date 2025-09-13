Public Class BillReport

    Private Sub BillReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.Billtable' table. You can move, or remove it, as needed.
        Me.BilltableTableAdapter.Fill(Me.DataSet1.Billtable)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class