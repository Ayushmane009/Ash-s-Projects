Public Class Treatmentdetails

    
    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    'Private Sub btnnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Class1.cn.Open()
    '    Dim k As Integer
    '    Class1.cmd.CommandText = "Select max(Td_id)from Treatmentdetails"
    '    Class1.cmd.Connection = Class1.cn
    '    Class1.dr = Class1.cmd.ExecuteReader()
    '    If (Class1.dr.Read()) Then
    '        Dim str As String
    '        str = Class1.dr(0).ToString

    '        If str = "" Then
    '            tbid.Text = "1"
    '        Else
    '            k = Convert.ToInt32(Class1.dr(0).ToString())
    '            k = k + 1
    '            tbid.Text = k.ToString()
    '        End If
    '    End If
    '    Class1.cn.Close()
    '    Showgrid()
    '    clear()
    'End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click


        If tbid.Text = "" Or cmbthid.Text = "" Or cmbphase.Text = "" Or tbch.Text = "" Or tbnod.Text = "" Then
            MsgBox("Fill all fields...", MsgBoxStyle.Critical)

        End If




        Try
            Class1.cn.Open()
            Class1.cmd.CommandText = "Insert into Treatmentdetails values(" & tbid.Text & "," & cmbthid.SelectedIndex + 1 & ",'" & cmbphase.Text & "' ," & tbch.Text & " ," & tbnod.Text & " )"
            Class1.cmd.Connection = Class1.cn
            Class1.cmd.ExecuteNonQuery()
            MessageBox.Show("Record save successfully", "save", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
            'cmbthid.ValueMember = "T_id"
            Showgrid()
        End Try
    End Sub
    Public Sub Showgrid()
        Try
            Class1.cn.Open()
            Class1.dt1.Clear()
            Class1.dt1.Rows.Clear()
            Class1.dt1.Columns.Clear()
            Class1.cmd.CommandText = "Select * from Treatmentdetails"
            Class1.cmd.Connection = Class1.cn
            Class1.dt1.Load(Class1.cmd.ExecuteReader)
            dgvtinfo.DataSource = Class1.dt1
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
        End Try
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        Try
            Class1.cn.Open()
            Class1.cmd.CommandText = "Delete From Treatmentdetails where Td_id=" & tbid.Text & ""
            Class1.cmd.Connection = Class1.cn
            Class1.cmd.ExecuteNonQuery()
            MessageBox.Show("Delete Sucessfully....", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
            Showgrid()
            'clear()
        End Try
    End Sub

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        Try
            If cmbselecto.Text = "LIKE" Or cmbselecto.Text = "NOT LIKE" Then
                Class1.str = String.Format("{0} where {1}{2}'{3}%'", "Select * from Treatmentdetails", cmbselectf.Text, cmbselecto.Text, tbsearch.Text)
            ElseIf cmbselecto.Text = "Treatmentdetails" Then
                Class1.str = String.Format("{0}", "Select * from Treatmentdetails ", cmbselectf.Text, cmbselecto.Text, tbsearch.Text)
            Else
                Class1.str = String.Format("{0} where {1}{2}'{3}'", "Select * from Treatmentdetails", cmbselectf.Text, cmbselecto.Text, tbsearch.Text)

            End If
            Class1.cn.Open()
            Class1.dt.Clear()
            Class1.cmd.CommandText = Class1.str
            Class1.cmd.Connection = Class1.cn
            Class1.dt.Load(Class1.cmd.ExecuteReader)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
            dgvtinfo.DataSource = Class1.dt
            tbsearch.Clear()
        End Try
    End Sub

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click
        Try
            tbid.Text = ""
            cmbthid.Text = ""
            cmbphase.Text = ""
            tbch.Text = ""
            tbnod.Text = ""
            btnnew.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
        End Try
    End Sub

    Private Sub dgvtinfo_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvtinfo.CellContentClick
        Try
            btnnew.Enabled = True
            btnsave.Enabled = True
            btnmodify.Enabled = True
            btndelete.Enabled = True
            btnclear.Enabled = True
            btnexit.Enabled = True
            btnsearch.Enabled = True

            tbid.Text = dgvtinfo.Rows(e.RowIndex).Cells(0).Value.ToString
            Dim b As Integer
            Dim bstr As String
            b = dgvtinfo.Rows(e.RowIndex).Cells(1).Value.ToString
            Class1.cn.Open()
            Class1.cmd.CommandText = "Select T_name from Treatmentheader where T_id=" & b & " "
            Class1.cmd.Connection = Class1.cn
            Class1.dr = Class1.cmd.ExecuteReader
            While Class1.dr.Read
                bstr = Class1.dr("T_name")
                cmbthid.Text = bstr
            End While
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
            'cmbthid.Text = dgvtinfo.Rows(e.RowIndex).Cells(1).Value.ToString
            cmbphase.Text = dgvtinfo.Rows(e.RowIndex).Cells(2).Value.ToString
            tbch.Text = dgvtinfo.Rows(e.RowIndex).Cells(3).Value.ToString
            tbnod.Text = dgvtinfo.Rows(e.RowIndex).Cells(4).Value.ToString
        End Try
    End Sub

    Private Sub Treatmentdetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            btnnew.Enabled = True
            btnsave.Enabled = True
            btnmodify.Enabled = False
            btndelete.Enabled = False
            btnsearch.Enabled = True
            Dim cn1 As New Class1
            cn1.conn()
            Showgrid()
            showfield()
            loadtype()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally

        End Try
    End Sub
    Public Sub showfield()
        Try
            Class1.cn.Open()
            Class1.dt.Rows.Clear()
            Class1.dt.Columns.Clear()
            Class1.cmd.CommandText = "select * from Treatmentdetails"
            Class1.cmd.Connection = Class1.cn
            Class1.dt.Load(Class1.cmd.ExecuteReader)
            Dim dc As DataColumn
            For Each dc In Class1.dt.Columns
                cmbselectf.Items.Add(dc.ColumnName)

            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
        End Try
    End Sub

    Private Sub btnmodify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodify.Click
        Try
            Class1.cn.Open()
            Class1.cmd.CommandText = "Update Treatmentdetails set T_id=" & cmbthid.SelectedValue & ",phase='" & cmbphase.Text & "',charges='" & tbch.Text & "',NoOfdays='" & tbnod.Text & "' where Td_id=" & tbid.Text & ""
            Class1.cmd.Connection = Class1.cn
            Class1.cmd.ExecuteNonQuery()
            MessageBox.Show("Update Sucessfully....", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
            Showgrid()
        End Try
    End Sub
    Public Sub clear()
        'tbid.Text = ""
        'cmbthid.Text = ""
        Try
            cmbphase.Text = ""
            tbch.Text = ""
            tbnod.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub loadtype()
        Try
            Class1.cn.Open()
            Dim dt2 As New DataTable

            Class1.cmd.CommandText = "Select * from Treatmentheader"
            Class1.cmd.Connection = Class1.cn
            dt2.Load(Class1.cmd.ExecuteReader)
            cmbthid.DataSource = dt2
            cmbthid.DisplayMember = "T_name"
            cmbthid.ValueMember = "T_id"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
        End Try
    End Sub

    Private Sub btnnew_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnew.Click
        Try
            Class1.cn.Open()
            Dim k As Integer
            Class1.cmd.CommandText = "Select max(Td_id)from Treatmentdetails"
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
            Showgrid()
            clear()
        End Try
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub cmbthid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbthid.SelectedIndexChanged

    End Sub

    Private Sub cmbphase_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbphase.SelectedIndexChanged

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class