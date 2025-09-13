Public Class Form1

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvdtype.CellDoubleClick
        Try
            btnnew.Enabled = False
            btnsave.Enabled = False
            btnmodify.Enabled = True
            btndelete.Enabled = True
            btnclear.Enabled = True
            btnexit.Enabled = True
            btnsearch.Enabled = True

            txtdtid.Text = dgvdtype.Rows(e.RowIndex).Cells(0).Value.ToString
            txtdttype.Text = dgvdtype.Rows(e.RowIndex).Cells(1).Value.ToString
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
        End Try

    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click
        Try
            txtdtid.Text = ""
            txtdttype.Text = ""
            btnnew.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
        End Try
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
        End Try
    End Sub

    Private Sub btnnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnew.Click
        Try
            Class1.cn.Open()
            Dim k As Integer
            Class1.cmd.CommandText = "Select max(Dtype_id)from Doctortype"
            Class1.cmd.Connection = Class1.cn
            Class1.dr = Class1.cmd.ExecuteReader()

            If (Class1.dr.Read()) Then
                Dim str As String
                str = Class1.dr(0).ToString

                If str = "" Then
                    txtdtid.Text = "1"
                Else
                    k = Convert.ToInt32(Class1.dr(0).ToString())
                    k = k + 1
                    txtdtid.Text = k.ToString()
                End If
            End If
        Catch ex As Exception

            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
            Showgrid()
            txtdttype.Clear()
        End Try
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click


        If txtdtid.Text = "" Or txtdttype.Text = "" Then
            MsgBox("Fill all fields...", MsgBoxStyle.Critical)

        End If

        Try
            Class1.cn.Open()
            Class1.cmd.CommandText = "Insert into Doctortype values(" & txtdtid.Text & ",'" & txtdttype.Text & "')"
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

    Private Sub dgvdtype_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvdtype.CellContentClick

    End Sub
    Public Sub Showgrid()
        Try
            Class1.cn.Open()
            Class1.dt1.Clear()
            Class1.dt1.Rows.Clear()
            Class1.dt1.Columns.Clear()
            Class1.cmd.CommandText = "Select * from Doctortype"
            Class1.cmd.Connection = Class1.cn
            Class1.dt1.Load(Class1.cmd.ExecuteReader)
            dgvdtype.DataSource = Class1.dt1
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
        End Try
    End Sub

    Private Sub btnmodify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodify.Click
        Try
            Class1.cn.Open()
            Class1.cmd.CommandText = "Update Doctortype set Dtype='" & txtdttype.Text & "' where Dtype_id=" & txtdtid.Text & ""
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
            Class1.cmd.CommandText = "Delete From Doctortype where Dtype_id=" & txtdtid.Text & ""
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
                Class1.str = String.Format("{0} where {1}{2}'{3}%'", "Select * from Doctortype", cmbselectf.Text, cmbselecto.Text, txtdtsearch.Text)
            ElseIf cmbselecto.Text = "Doctortype" Then
                Class1.str = String.Format("{0}", "Select * from Doctortype ", cmbselectf.Text, cmbselecto.Text, txtdtsearch.Text)
            Else
                Class1.str = String.Format("{0} where {1}{2}'{3}'", "Select * from Doctortype", cmbselectf.Text, cmbselecto.Text, txtdtsearch.Text)

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
            dgvdtype.DataSource = Class1.dt
            txtdtsearch.Clear()
        End Try
    End Sub
    Public Sub showfield()
        Try
            Class1.cn.Open()
            Class1.dt.Rows.Clear()
            Class1.dt.Columns.Clear()
            Class1.cmd.CommandText = "select * from Doctortype"
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



    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class
