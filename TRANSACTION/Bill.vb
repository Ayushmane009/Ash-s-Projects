Public Class Bill
    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnew.Click
        Try
            Class1.cn.Open()
            Dim k As Integer
            Class1.cmd.CommandText = "Select max(bill_no)from Billtable"
            Class1.cmd.Connection = Class1.cn
            Class1.dr = Class1.cmd.ExecuteReader()
            If (Class1.dr.Read()) Then
                Dim str As String
                str = Class1.dr(0).ToString

                If str = "" Then
                    tbbillno.Text = "1"
                Else
                    k = Convert.ToInt32(Class1.dr(0).ToString())
                    k = k + 1
                    tbbillno.Text = k.ToString()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
            Showgrid()
            clear()
        End Try
    End Sub

    Private Sub Bill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            btnnew.Enabled = True
            btnsave.Enabled = True
            'btnprint.Enabled = True
            btnexit.Enabled = True

            Dim cn1 As New Class1
            cn1.conn()
            Showgrid()
            'showfield()
            loadtype()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
        End Try
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click

        If tbbillno.Text = "" Or cmbcpdid.Text = "" Or tbpay.Text = "" Or tbdue.Text = "" Or tbstatus.Text = "" Then
            MsgBox("Fill all fields...", MsgBoxStyle.Critical)

        End If

        Try
            Class1.cn.Open()
            Class1.cmd.CommandText = "insert into Billtable values (" & tbbillno.Text & "," & cmbcpdid.SelectedValue & ",'" & tbpay.Text & "','" & tbpaid.Text & "','" & tbdue.Text & "','" & tbstatus.Text & "')"
            Class1.cmd.Connection = Class1.cn
            Class1.cmd.ExecuteNonQuery()
            MessageBox.Show("Record save successfully", "save", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
            Showgrid()
        End Try
    End Sub

    Private Sub dgvbill_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvbill.CellContentClick
       

    End Sub
    Public Sub Showgrid()
        Try
            Class1.cn.Open()
            Class1.dt1.Clear()
            Class1.dt1.Rows.Clear()
            Class1.dt1.Columns.Clear()
            Class1.cmd.CommandText = "Select * from Billtable"
            Class1.cmd.Connection = Class1.cn
            Class1.dt1.Load(Class1.cmd.ExecuteReader)
            dgvbill.DataSource = Class1.dt1
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
        End Try
    End Sub
    Public Sub loadtype()
        Try
            Class1.cn.Open()
            Dim dt2 As New DataTable

            Class1.cmd.CommandText = "Select p_id,p_name from Patientdetails where p_id in(select p_id from Casepaperheader)"
            Class1.cmd.Connection = Class1.cn
            dt2.Load(Class1.cmd.ExecuteReader)
            cmbcpdid.DataSource = dt2
            cmbcpdid.DisplayMember = "p_name"
            cmbcpdid.ValueMember = "p_id"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
        End Try
    End Sub

    Private Sub tbdue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbdue.TextChanged
        Try
            If tbdue.Text = 0 Then
                tbstatus.Text = "Complit"
            Else
                tbstatus.Text = "Incomplit"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
        End Try
    End Sub
    Private Sub tbpaid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbpaid.TextChanged
        Try
            tbdue.Text = Val(tbpay.Text) - Val(tbpaid.Text)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
        End Try
    End Sub

    Private Sub cmbcpdid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcpdid.SelectedIndexChanged
        Try
            Class1.cn.Close()
            Class1.cn.Open()
            Dim dt2 As New DataTable
            'Class1.cmd.CommandText = "Select charges from Treatmentdetails where phase='" & cmbphase.Text & "'and T_id=" & cmbtid.SelectedValue & ""
            Class1.cmd.CommandText = "SELECT  SUM(Treatmentdetails.charges) AS Expr1 FROM  Casepaperdetails INNER JOIN Treatmentdetails ON Casepaperdetails.Td_id = Treatmentdetails.Td_id INNER JOIN Casepaperheader ON Casepaperdetails.c_id = Casepaperheader.c_id INNER JOIN Patientdetails ON Casepaperheader.p_id = Patientdetails.p_id WHERE Patientdetails.p_name = '" & cmbcpdid.Text & "'"
            Class1.cmd.Connection = Class1.cn

            Class1.dr = Class1.cmd.ExecuteReader

            Dim p As String
            While Class1.dr.Read
                p = Class1.dr("Expr1").ToString()
                tbpay.Text = p
            End While
            ' cmbcpdid.ValueMember = "T_id"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
        End Try
    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub btnprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Dim a As New BillReport()
        'a.Show()
    End Sub
    Public Sub clear()
        tbpaid.Text = ""
        tbdue.Text = "0"
        'tbstatus.Text = ""


    End Sub
End Class