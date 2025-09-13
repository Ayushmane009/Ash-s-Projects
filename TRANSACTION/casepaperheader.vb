Public Class casepaperheader

    Public Sub showgrid1()
        Try
            Class1.cn.Close()
            Class1.cn.Open()
            Class1.dt3.Clear()
            Class1.dt3.Rows.Clear()
            Class1.dt3.Columns.Clear()
            ' Class1.cmd.CommandText = "SELECT Casepaperdetails.cpd_id, Casepaperdetails.Treat_date, Casepaperdetails.c_id, Treatmentdetails.charges FROM Casepaperdetails INNER JOIN Casepaperheader ON Casepaperdetails.c_id = Casepaperheader.c_id INNER JOIN Treatmentdetails ON Casepaperdetails.Td_id = Treatmentdetails.Td_id INNER JOIN Patientdetails ON Casepaperheader.p_id = Patientdetails.p_id WHERE Patientdetails.p_name = '" & cmbpid.Text & "'"
            Class1.cmd.CommandText = "SELECT * from Casepaperheader"
            Class1.cmd.Connection = Class1.cn
            Class1.dt3.Load(Class1.cmd.ExecuteReader)
            dgvcasepaper1.DataSource = Class1.dt3
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
            Dim tot As String = 0

            ''For i As Integer = 0 To dgvcasepaper.RowCount - 1
            ''    tot = tot + dgvcasepaper.Rows(i).Cells(5).Value
            ''Next
            ''tbgrandtotal.Text = tot
            ''tbcharges.Focus()
        End Try
    End Sub
    Private Sub btnaddnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnaddnew.Click
        Try
            buttons()
            btnsaveheder.Enabled = True
            btnmodify.Enabled = True
            'btndelete.Enabled = True
            btnrenew.Enabled = True
            Class1.cn.Open()
            Dim k As Integer
            Class1.cmd.CommandText = "Select max(c_id)from Casepaperheader"
            Class1.cmd.Connection = Class1.cn
            Class1.dr = Class1.cmd.ExecuteReader()
            If (Class1.dr.Read()) Then
                Dim str As String
                str = Class1.dr(0).ToString

                If str = "" Then
                    tbid.Text = "1"
                Else
                    k = Convert.ToInt32(Class1.dr(0).ToString())
                    k = k + 1
                    tbid.Text = k.ToString()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
            showgrid1()
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
    Public Sub loadtype()
        Try
            Class1.cn.Open()
            Dim dt2 As New DataTable
            Class1.cmd.CommandText = "Select * from Patientdetails"
            Class1.cmd.Connection = Class1.cn
            dt2.Load(Class1.cmd.ExecuteReader)
            cmbpid.DataSource = dt2
            cmbpid.DisplayMember = "p_name"
            cmbpid.ValueMember = "p_id"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
        End Try
    End Sub

    Public Sub buttons()
        btnaddnew.Enabled = False
        btnsaveheder.Enabled = False
        btnmodify.Enabled = False
        btnrenew.Enabled = False
        'btndelete.Enabled = False
        Button4.Enabled = False
    End Sub

    Public Sub loadDoctor()
        Try
            Class1.cn.Open()
            Dim dt2 As New DataTable
            Class1.cmd.CommandText = "Select * from Doctordetails"
            Class1.cmd.Connection = Class1.cn
            dt2.Load(Class1.cmd.ExecuteReader)
            cmbdid.DataSource = dt2
            cmbdid.DisplayMember = "D_name"
            cmbdid.ValueMember = "D_id"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
        End Try
    End Sub
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim cn1 As New Class1
            cn1.conn()
            loadtype()
            loadDoctor()
            showgrid1()
            buttons()
            'showfield()
            btnaddnew.Enabled = True
            Button3.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
        End Try
    End Sub

    Private Sub btnsaveheder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsaveheder.Click

        If tbid.Text = "" Or dtpvd.Text = "" Or cmbdid.Text = "" Or cmbpid.Text = "" Or txtdiagnos.Text = "" Or tbfee.Text = "" Then
            MsgBox("Fill all fields...", MsgBoxStyle.Critical)

        End If

        Try
            buttons()
            Button4.Enabled = True
            Class1.cn.Open()
            Class1.cmd.CommandText = "insert into Casepaperheader values (" & tbid.Text & ",@p1,@p2," & cmbdid.SelectedValue & "," & cmbpid.SelectedValue & ",'" & txtdiagnos.Text & "','" & tbfee.Text & "')"
            Class1.cmd.Connection = Class1.cn
            Class1.cmd.Parameters.Clear()
            Class1.cmd.Parameters.Add("@p1", SqlDbType.DateTime).Value = dtpd.Text
            Class1.cmd.Parameters.Add("@p2", SqlDbType.DateTime).Value = dtpvd.Text
            Class1.cmd.ExecuteNonQuery()
            MessageBox.Show("Record save successfully", "save", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
            'Showgrid()
            showgrid1()
        End Try
    End Sub





    'Private Sub dgvcasepaper_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    tbid.Text = dgvcasepaper.Rows(e.RowIndex).Cells(0).Value.ToString
    '    dtpd.Text = dgvcasepaper.Rows(e.RowIndex).Cells(1).Value.ToString
    '    dtpvd.Text = dgvcasepaper.Rows(e.RowIndex).Cells(2).Value.ToString
    '    cmbdid.Text = dgvcasepaper.Rows(e.RowIndex).Cells(3).Value.ToString
    '    cmbpid.Text = dgvcasepaper.Rows(e.RowIndex).Cells(4).Value.ToString
    '    txtdiagnos.Text = dgvcasepaper.Rows(e.RowIndex).Cells(5).Value.ToString
    '    tbfee.Text = dgvcasepaper.Rows(e.RowIndex).Cells(6).Value.ToString
    'End Sub

    Private Sub casepaperh_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles casepaperh.Enter

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            buttons()
            btnaddnew.Enabled = True
            Dim a As Integer = Val(tbid.Text)
            Dim s As String = cmbpid.Text
            Dim cd As New casepaperdetails(a, s)
            cd.Show()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
        End Try
    End Sub

    Private Sub dgvcasepaper_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvcasepaper1.CellContentClick
        Try
            buttons()
            btnmodify.Enabled = True
            btnrenew.Enabled = True
            'btndelete.Enabled = True
            Button4.Enabled = True
            tbid.Text = dgvcasepaper1.Rows(e.RowIndex).Cells(0).Value.ToString
            dtpd.Text = dgvcasepaper1.Rows(e.RowIndex).Cells(1).Value.ToString
            dtpvd.Text = dgvcasepaper1.Rows(e.RowIndex).Cells(2).Value.ToString

            Dim b As Integer

            Dim bstr As String
            b = dgvcasepaper1.Rows(e.RowIndex).Cells(3).Value.ToString
            Class1.cn.Close()
            Class1.cn.Open()

            Class1.cmd.CommandText = "Select D_name from Doctordetails where D_id=" & b & " "
            Class1.cmd.Connection = Class1.cn
            Class1.dr = Class1.cmd.ExecuteReader
            While Class1.dr.Read
                bstr = Class1.dr("D_name")
                cmbdid.Text = bstr
            End While
            Class1.cn.Close()

            'cmbdid.Text = dgvcasepaper.Rows(e.RowIndex).Cells(3).Value.ToString
            'cmbpid.Text = dgvcasepaper.Rows(e.RowIndex).Cells(4).Value.ToString
            Dim c As Integer

            Dim str As String
            c = dgvcasepaper1.Rows(e.RowIndex).Cells(4).Value.ToString
            Class1.cn.Open()
            Class1.cmd.CommandText = "Select p_name from Patientdetails where p_id=" & c & " "
            Class1.cmd.Connection = Class1.cn
            Class1.dr = Class1.cmd.ExecuteReader
            While Class1.dr.Read
                str = Class1.dr("p_name")
                cmbpid.Text = str
            End While
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
            txtdiagnos.Text = dgvcasepaper1.Rows(e.RowIndex).Cells(5).Value.ToString
            tbfee.Text = dgvcasepaper1.Rows(e.RowIndex).Cells(6).Value.ToString
        End Try
    End Sub


    Private Sub btnmodify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodify.Click
        Try
            buttons()
            btnaddnew.Enabled = True
            Class1.cmd.CommandText = "Update Casepaperheader set c_date=@p1,c_validitydate=@p2,D_id=" & cmbdid.SelectedValue & ",p_id=" & cmbpid.SelectedValue & ",Diagnosis='" & txtdiagnos.Text & "',c_fee='" & tbfee.Text & "' where c_id=" & tbid.Text & ""
            Class1.cn.Open()
            Class1.cmd.Parameters.Clear()
            Class1.cmd.Parameters.Add("@p1", SqlDbType.DateTime).Value = dtpd.Text
            Class1.cmd.Parameters.Add("@p2", SqlDbType.DateTime).Value = dtpvd.Text
            Class1.cmd.Connection = Class1.cn
            Class1.cmd.ExecuteNonQuery()
            MessageBox.Show("Update Sucessfully....", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
            showgrid1()
        End Try
    End Sub


    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        '    Class1.cn.Open()
        '    Class1.cmd.CommandText = "Delete From Casepaperheader where c_id=" & tbid.Text & ""
        '    Class1.cmd.Connection = Class1.cn
        '    Class1.cmd.ExecuteNonQuery()
        '    MessageBox.Show("Delete Sucessfully....", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Catch ex As Exception
        '    MessageBox.Show(ex.ToString)
        'Finally
        '    Class1.cn.Close()
        '    showgrid1()
        'End Try
    End Sub

    Private Sub dtpd_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpd.ValueChanged

        dtpvd.Text = dtpd.Value.AddMonths(2)

    End Sub

    Private Sub dtpvd_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpvd.ValueChanged

        'If dtpvd.Text < DateAndTime.Now Then
        '    MessageBox.Show("Your Casepaper is Expire")
        '    btnrenew.Enabled = True

        'End If
    
    End Sub

    Private Sub btnrenew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrenew.Click
        dtpd.Text = DateAndTime.Now.Date
        dtpvd.Text = dtpd.Value.AddMonths(2)

        Class1.cmd.CommandText = "Update Casepaperheader set c_date=@p1,c_validitydate=@p2,D_id=" & cmbdid.SelectedValue & ",p_id=" & cmbpid.SelectedValue & ",Diagnosis='" & txtdiagnos.Text & "',c_fee='" & tbfee.Text & "' where c_id=" & tbid.Text & ""
        Class1.cn.Open()
        Class1.cmd.Parameters.Clear()
        Class1.cmd.Parameters.Add("@p1", SqlDbType.DateTime).Value = DateAndTime.Now.Date
        Class1.cmd.Parameters.Add("@p2", SqlDbType.DateTime).Value = dtpvd.Text
        Class1.cmd.Connection = Class1.cn
        Class1.cmd.ExecuteNonQuery()
        MessageBox.Show("Renewed Sucessfully....", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
       
        Class1.cn.Close()
        showgrid1()

    End Sub

    Private Sub tbid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbid.TextChanged
        Try
            dtpd.Text = DateAndTime.Now
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
        End Try
    End Sub

    Private Sub cmbdid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdid.SelectedIndexChanged

    End Sub

    Private Sub dtpd_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'dtpvd.Text = dtpd.Value.AddMonths(2)
    End Sub

    Private Sub dtpvd_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If dtpvd.Text < DateAndTime.Now Then
            MessageBox.Show("Your Casepaper is Expire")
            btnrenew.Enabled = True

        End If

    End Sub

  
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If dtpvd.Text < DateAndTime.Now Then
            MessageBox.Show("Your Casepaper is Expire")
            btnrenew.Enabled = True

        End If

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    'Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    

    ''End Sub
    ''Public Sub showfield()
    ''    Try
    ''        Class1.cn.Open()
    ''        Class1.dt.Rows.Clear()
    ''        Class1.dt.Columns.Clear()
    ''        Class1.cmd.CommandText = "select * from Casepaperheader"
    ''        Class1.cmd.Connection = Class1.cn
    ''        Class1.dt.Load(Class1.cmd.ExecuteReader)
    ''        Dim dc As DataColumn
    ''        For Each dc In Class1.dt.Columns
    ''            cmbselectf.Items.Add(dc.ColumnName)

    ''        Next
    ''    Catch ex As Exception
    ''        MessageBox.Show(ex.ToString)
    ''        Class1.cn.Close()
    ''    End Try
    ''End Sub

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        Try
            If cmbselecto.Text = "LIKE" Or cmbselecto.Text = "NOT LIKE" Then
                Class1.str = String.Format("{0} where {1}{2}'{3}%'", "Select * from casepaperheaderview", cmbselectf.Text, cmbselecto.Text, tbsearch.Text)
            ElseIf cmbselecto.Text = "casepaperheaderview" Then
                Class1.str = String.Format("{0}", "Select * from casepaperheaderview ", cmbselectf.Text, cmbselecto.Text, tbsearch.Text)
            Else
                Class1.str = String.Format("{0} where {1}{2}'{3}'", "Select * from casepaperheaderview", cmbselectf.Text, cmbselecto.Text, tbsearch.Text)

            End If
            Class1.cn.Close()
            Class1.cn.Open()
            Class1.dt.Rows.Clear()
            Class1.dt.Columns.Clear()
            Class1.dt.Clear()
            Class1.cmd.CommandText = Class1.str
            Class1.cmd.Connection = Class1.cn
            Class1.dt.Load(Class1.cmd.ExecuteReader)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
            dgvcasepaper1.DataSource = Class1.dt
            tbsearch.Clear()
        End Try
    End Sub

    Private Sub cmbpid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbpid.SelectedIndexChanged

    End Sub
End Class