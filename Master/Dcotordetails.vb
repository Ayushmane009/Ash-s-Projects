Public Class Dcotordetails
    Private Sub dgvDdetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDdetails.CellContentClick
        Try
            btnnew.Enabled = False
            btnsave.Enabled = False
            btnmodify.Enabled = True
            btndelete.Enabled = True
            btnclear.Enabled = True
            btnexit.Enabled = True
            btnsearch.Enabled = True

            tbid.Text = dgvDdetails.Rows(e.RowIndex).Cells(0).Value.ToString

            Dim b As Integer
            Dim bstr As String
            b = dgvDdetails.Rows(e.RowIndex).Cells(1).Value.ToString
            Class1.cn.Open()
            Class1.cmd.CommandText = "Select Dtype from Doctortype where Dtype_id=" & b & " "
            Class1.cmd.Connection = Class1.cn
            Class1.dr = Class1.cmd.ExecuteReader
            While Class1.dr.Read
                bstr = Class1.dr("Dtype")
                cmbdtypename.Text = bstr
            End While

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
            tbname.Text = dgvDdetails.Rows(e.RowIndex).Cells(2).Value.ToString
            tbaddress.Text = dgvDdetails.Rows(e.RowIndex).Cells(3).Value.ToString
            tbemail.Text = dgvDdetails.Rows(e.RowIndex).Cells(4).Value.ToString
            tbquali.Text = dgvDdetails.Rows(e.RowIndex).Cells(5).Value.ToString
            tbcont.Text = dgvDdetails.Rows(e.RowIndex).Cells(6).Value.ToString
            cmbspaciality.Text = dgvDdetails.Rows(e.RowIndex).Cells(7).Value.ToString
        End Try
    End Sub


    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click
        Try
            tbid.Text = ""
            cmbdtypename.Text = ""
            tbname.Text = ""
            tbaddress.Text = ""
            tbemail.Text = ""
            tbquali.Text = ""
            tbcont.Text = ""
            clear()
            btnnew.Enabled = True
            btnsave.Enabled = True
            ' dgvDdetails.DataSource = ""
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
        End Try
    End Sub

    Private Sub Dcotordetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub btnnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnew.Click
        Try
            Class1.cn.Open()
            Dim k As Integer
            Class1.cmd.CommandText = "Select max(D_id)from Doctordetails"
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

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click

        If tbid.Text = "" Or cmbdtypename.Text = "" Or tbname.Text = "" Or tbaddress.Text = "" Or tbemail.Text = "" Or tbquali.Text = "" Or tbcont.Text = "" Or cmbspaciality.Text = "" Then
            MsgBox("Fill all fields...", MsgBoxStyle.Critical)

        else
        Try
            Class1.cn.Open()
            Class1.cmd.CommandText = "insert into Doctordetails values (" & tbid.Text & ",'" & cmbdtypename.SelectedValue & "','" & tbname.Text & "','" & tbaddress.Text & "','" & tbemail.Text & "','" & tbquali.Text & "','" & tbcont.Text & "','" & cmbspaciality.Text & "')"
            Class1.cmd.Connection = Class1.cn
                Class1.cmd.ExecuteNonQuery()
            MessageBox.Show("Record save successfully", "save", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
            Showgrid()
            End Try
        End If
    End Sub
    Public Sub Showgrid()
        Try
            Class1.cn.Open()
            Class1.dt1.Clear()
            Class1.dt1.Rows.Clear()
            Class1.dt1.Columns.Clear()
            Class1.cmd.CommandText = "Select * from Doctordetails"
            Class1.cmd.Connection = Class1.cn
            Class1.dt1.Load(Class1.cmd.ExecuteReader)
            dgvDdetails.DataSource = Class1.dt1
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

            Class1.cmd.CommandText = "Select * from Doctortype"
            Class1.cmd.Connection = Class1.cn
            dt2.Load(Class1.cmd.ExecuteReader)
            cmbdtypename.DataSource = dt2
            cmbdtypename.DisplayMember = "Dtype"
            cmbdtypename.ValueMember = "Dtype_id"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
        End Try
    End Sub


    Private Sub btnmodify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodify.Click
        Try
            Class1.cn.Open()
            Class1.cmd.CommandText = "Update Doctordetails set D_name='" & tbname.Text & "',Dtype_id=" & cmbdtypename.SelectedIndex + 1 & ",D_address='" & tbaddress.Text & "',D_email='" & tbemail.Text & "',D_qualification='" & tbquali.Text & "',D_contactNo='" & tbcont.Text & "',D_Spaciality='" & cmbspaciality.Text & "' where D_id=" & tbid.Text & ""
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

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        Try
            Class1.cn.Open()
            Class1.cmd.CommandText = "Delete From Doctordetails where D_id=" & tbid.Text & ""
            Class1.cmd.Connection = Class1.cn
            Class1.cmd.ExecuteNonQuery()
            MessageBox.Show("Delete Sucessfully....", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
            Showgrid()
        End Try
    End Sub

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        Try
            If cmbselecto.Text = "LIKE" Or cmbselecto.Text = "NOT LIKE" Then
                Class1.str = String.Format("{0} where {1}{2}'{3}%'", "Select * from Doctordetails", cmbselectf.Text, cmbselecto.Text, tbsearch.Text)
            ElseIf cmbselecto.Text = "Doctordetails" Then
                Class1.str = String.Format("{0}", "Select * from Doctordetails ", cmbselectf.Text, cmbselecto.Text, tbsearch.Text)
            Else
                Class1.str = String.Format("{0} where {1}{2}'{3}'", "Select * from Doctordetails", cmbselectf.Text, cmbselecto.Text, tbsearch.Text)

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
            dgvDdetails.DataSource = Class1.dt
            tbsearch.Clear()
        End Try
    End Sub
    Public Sub showfield()
        Try
            Class1.cn.Open()
            Class1.dt.Rows.Clear()
            Class1.dt.Columns.Clear()
            Class1.cmd.CommandText = "select * from Doctordetails"
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
    Public Sub clear()
        'tbid.Text = ""
        Try
            cmbdtypename.Text = ""
            tbname.Text = ""
            tbaddress.Text = ""
            tbemail.Text = ""
            tbquali.Text = ""
            tbcont.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
        End Try
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub cmbdtypename_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdtypename.SelectedIndexChanged

    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class