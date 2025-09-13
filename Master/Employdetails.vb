Public Class Employdetails
    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnew.Click
        Try
            Class1.cn.Open()
            Dim k As Integer
            Class1.cmd.CommandText = "Select max(e_id)from Employedetails"
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

        If tbid.Text = "" Or tbname.Text = "" Or tbaddress.Text = "" Or DOJ.Text = "" Or tbcont.Text = "" Or tbdesi.Text = "" Then
            MsgBox("Fill all fields...", MsgBoxStyle.Critical)
        End If

        Try
            Class1.cmd.Parameters.Clear()
            Class1.cn.Open()
            Class1.cmd.CommandText = "insert into Employedetails values (" & tbid.Text & ",'" & tbname.Text & "','" & tbaddress.Text & "',@p2," & tbcont.Text & ",'" & tbdesi.Text & "')"
            Class1.cmd.Connection = Class1.cn
            Class1.cmd.Parameters.Add("@p2", SqlDbType.DateTime).Value = DOJ.Text
            'Class1.cmd.Parameters.AddWithValue("@p3", DOJ.Text)
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
            Class1.cmd.CommandText = "Update Employedetails set e_name='" & tbname.Text & "',e_address='" & tbaddress.Text & "',e_DOJ=@p2,e_conatctno=" & tbcont.Text & ",e_desigination='" & tbdesi.Text & "' where e_id=" & tbid.Text & ""
            Class1.cn.Open()
            Class1.cmd.Parameters.Clear()
            Class1.cmd.Parameters.Add("@p2", SqlDbType.DateTime).Value = DOJ.Text
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
            Class1.cmd.CommandText = "Delete From Employedetails where e_id=" & tbid.Text & ""
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
    Public Sub Showgrid()
        Try
            Class1.cn.Open()
            Class1.dt1.Clear()
            Class1.dt1.Rows.Clear()
            Class1.dt1.Columns.Clear()
            Class1.cmd.CommandText = "Select * from Employedetails"
            Class1.cmd.Connection = Class1.cn
            Class1.dt1.Load(Class1.cmd.ExecuteReader)
            dgvemp.DataSource = Class1.dt1
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
        End Try
    End Sub

    Private Sub Employdetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            'loadtype()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
        End Try
    End Sub

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        Try
            If cmbselecto.Text = "LIKE" Or cmbselecto.Text = "NOT LIKE" Then
                Class1.str = String.Format("{0} where {1}{2}'{3}%'", "Select * from Employedetails", cmbselectf.Text, cmbselecto.Text, tbsearch.Text)
            ElseIf cmbselecto.Text = "Employedetails" Then
                Class1.str = String.Format("{0}", "Select * from Employedetails ", cmbselectf.Text, cmbselecto.Text, tbsearch.Text)
            Else
                Class1.str = String.Format("{0} where {1}{2}'{3}'", "Select * from Employedetails", cmbselectf.Text, cmbselecto.Text, tbsearch.Text)

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
            dgvemp.DataSource = Class1.dt
            tbsearch.Clear()
        End Try
    End Sub
    Public Sub showfield()
        Try
            Class1.cn.Open()
            Class1.dt.Rows.Clear()
            Class1.dt.Columns.Clear()
            Class1.cmd.CommandText = "select * from Employedetails"
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
            tbname.Text = ""
            tbaddress.Text = ""
            DOJ.Text = ""
            tbcont.Text = ""
            tbdesi.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
        End Try
    End Sub

    Private Sub dgvemp_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvemp.CellContentClick
        Try
            btnnew.Enabled = True
            btnsave.Enabled = True
            btnmodify.Enabled = True
            btndelete.Enabled = True
            btnclear.Enabled = True
            btnexit.Enabled = True
            btnsearch.Enabled = True

            tbid.Text = dgvemp.Rows(e.RowIndex).Cells(0).Value.ToString
            tbname.Text = dgvemp.Rows(e.RowIndex).Cells(1).Value.ToString
            tbaddress.Text = dgvemp.Rows(e.RowIndex).Cells(2).Value.ToString
            DOJ.Text = dgvemp.Rows(e.RowIndex).Cells(3).Value.ToString
            tbcont.Text = dgvemp.Rows(e.RowIndex).Cells(4).Value.ToString
            tbdesi.Text = dgvemp.Rows(e.RowIndex).Cells(5).Value.ToString

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
        End Try
    End Sub

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click
        Try
            tbname.Text = ""
            tbaddress.Text = ""
            DOJ.Text = ""
            tbcont.Text = ""
            tbdesi.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
        End Try
    End Sub


   
    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class