Public Class Medicine

    Private Sub cmbtnm_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtnm.SelectedIndexChanged

    End Sub

    Private Sub btnnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnew.Click
        Try
            Class1.cn.Open()
            Dim k As Integer
            Class1.cmd.CommandText = "Select max(m_id)from Medicine"
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
            'Showgrid()
            ' tbname.Clear()
        End Try

        clear()
    End Sub
    Public Sub loadtreatment()
        Try
            Class1.cn.Open()
            Dim dt2 As New DataTable
            Class1.cmd.CommandText = "Select * from Treatmentheader"
            Class1.cmd.Connection = Class1.cn
            dt2.Load(Class1.cmd.ExecuteReader)
            cmbtnm.DataSource = dt2
            cmbtnm.DisplayMember = "T_name"
            cmbtnm.ValueMember = "T_id"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
        End Try
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            Class1.cn.Open()
            Class1.cmd.CommandText = "Insert into Medicine values(" & tbid.Text & ",'" & cmbtnm.Text & "','" & tbmedicine.Text & "')"
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



    Private Sub btnmodify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodify.Click
        Try
            Class1.cn.Open()
            Class1.cmd.CommandText = "Update Medicine set Treatmentname='" & cmbtnm.Text & "' where Medicinename='" & tbmedicine.Text & "' where "
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
            Class1.cmd.CommandText = "Delete From Medicine where Treatmentname=" & cmbtnm.Text & ""
            Class1.cmd.Connection = Class1.cn
            Class1.cmd.ExecuteNonQuery()
            MessageBox.Show("Delete Sucessfully....", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()

        End Try
    End Sub

    Private Sub dgvmedicine_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvmedicine.CellContentClick
        Try
            btnnew.Enabled = True
            btnsave.Enabled = True
            btnmodify.Enabled = True
            btndelete.Enabled = True
            btnclear.Enabled = True
            btnexit.Enabled = True
            ' btnsearch.Enabled = True

            cmbtnm.Text = dgvmedicine.Rows(e.RowIndex).Cells(0).Value.ToString
            tbmedicine.Text = dgvmedicine.Rows(e.RowIndex).Cells(1).Value.ToString
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
        End Try
        loadtreatment()
    End Sub
    Public Sub clear()
        tbmedicine.Text = ""
    End Sub

    Private Sub Medicine_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            btnnew.Enabled = True
            btnsave.Enabled = True
            btnmodify.Enabled = False
            btndelete.Enabled = False
            'btnsearch.Enabled = True
            Dim cn1 As New Class1
            cn1.conn()
            loadtreatment()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
        End Try
        Showgrid()
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub
    Public Sub Showgrid()
        Try
            Class1.cn.Open()
            Class1.dt1.Clear()
            Class1.dt1.Rows.Clear()
            Class1.dt1.Columns.Clear()
            Class1.cmd.CommandText = "Select * from Medicine"
            Class1.cmd.Connection = Class1.cn
            Class1.dt1.Load(Class1.cmd.ExecuteReader)
            dgvmedicine.DataSource = Class1.dt1
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbid.TextChanged

    End Sub
End Class