
Public Class Patientdetails

    Private Sub dgvPdetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPdetails.CellContentClick
        Try

      
            btnnew.Enabled = True
            btnsave.Enabled = True
            btnmodify.Enabled = True
            btndelete.Enabled = True
            btnclear.Enabled = True
            btnexit.Enabled = True
            btnsearch.Enabled = True

            tbid.Text = dgvPdetails.Rows(e.RowIndex).Cells(0).Value.ToString
            tbname.Text = dgvPdetails.Rows(e.RowIndex).Cells(1).Value.ToString
            tbaddress.Text = dgvPdetails.Rows(e.RowIndex).Cells(2).Value.ToString
            dtp.Text = dgvPdetails.Rows(e.RowIndex).Cells(3).Value.ToString
            cmbBg.Text = dgvPdetails.Rows(e.RowIndex).Cells(4).Value.ToString
            tbph.Text = dgvPdetails.Rows(e.RowIndex).Cells(6).Value.ToString
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub btnnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnew.Click


      


        Try
            Class1.cn.Close()
            Class1.cn.Open()
            Dim k As Integer
            Class1.cmd.CommandText = "Select max(p_id)from Patientdetails"
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
        If tbid.Text = "" Or tbname.Text = "" Or tbaddress.Text = "" Or dtp.Text = "" Or cmbBg.Text = "" Or cmbgender.Text = "" Or tbph.Text = "" Then

            MsgBox("Fill all fields...", MsgBoxStyle.Critical)

        End If
        Try
            Class1.cn.Close()
            Class1.cn.Open()



            Class1.cmd.CommandText = "Insert into Patientdetails values(" & tbid.Text & ",'" & tbname.Text & "','" & tbaddress.Text & "',@p1,'" & cmbBg.Text & "','" & cmbgender.Text & "','" & tbph.Text & "')"
            Class1.cmd.Connection = Class1.cn
            Class1.cmd.Parameters.Clear()
            Class1.cmd.Parameters.Add("@p1", SqlDbType.DateTime).Value = dtp.Text
            'If rbmale.Checked Then
            '    Class1.cmd.Parameters.AddWithValue("@p1", rbmale.Text)
            'Else
            '    Class1.cmd.Parameters.AddWithValue("@p1", rbfemail.Text)



            'End If

            'Class1.cmd.Parameters.AddWithValue("@p2", dtpdob.Text)
            Class1.cmd.ExecuteNonQuery()
            MessageBox.Show("Record save successfully", "save", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
            Showgrid()
        End Try
    End Sub

    Private Sub Patientdetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try



            Dim cn1 As New Class1
            cn1.conn()
            showfield()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Public Sub Showgrid()
        Try
            Class1.cn.Open()
            Class1.dt1.Rows.Clear()
            Class1.dt1.Columns.Clear()
            Class1.dt1.Clear()
            Class1.cmd.CommandText = "Select * from Patientdetails"
            Class1.cmd.Connection = Class1.cn
            Class1.dt1.Load(Class1.cmd.ExecuteReader)
            dgvPdetails.DataSource = Class1.dt1
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
        End Try
    End Sub

    Private Sub btnmodify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodify.Click
        Try
            Class1.cn.Open()
            Class1.cmd.CommandText = "Update Patientdetails set p_name='" & tbname.Text & "',p_address='" & tbaddress.Text & "',p_DOB=@p1,p_BloodGroup='" & cmbBg.Text & "',p_Gender='" & cmbgender.Text & "',p_priviousHistory='" & tbph.Text & "' where p_id=" & tbid.Text & ""
            Class1.cmd.Connection = Class1.cn
            'If rbmale.Checked Then
            '    Class1.cmd.Parameters.AddWithValue("@p1", rbmale.Text)
            'Else
            '    Class1.cmd.Parameters.AddWithValue("@p1", rbfemail.Text)
            'End If
            Class1.cmd.Parameters.Clear()
            Class1.cmd.Parameters.Add("@p1", SqlDbType.DateTime).Value = dtp.Text

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
            Class1.cmd.CommandText = "Delete From Patientdetails where p_id=" & tbid.Text & ""
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

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click

        'tbid.Text = ""
        tbname.Text = ""
        tbaddress.Text = ""
        cmbBg.Text = ""
        ' dtpdob.Text = ""
        'rbmale.Text = ""
        'rbfemail.Text = ""
        tbph.Text = ""
        clear()
        btnnew.Enabled = True
        dgvPdetails.DataSource = ""

    End Sub
    Public Sub clear()
        'tbid.Text = ""
        tbname.Text = ""
        tbaddress.Text = ""
        dtp.Text = ""
        cmbBg.Text = ""
        'rbmale.Text = ""
        'rbfemail.Text = ""
        tbph.Text = ""

    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        Try
            If cmbselecto.Text = "LIKE" Or cmbselecto.Text = "NOT LIKE" Then
                Class1.str = String.Format("{0} where {1}{2}'{3}%'", "Select * from Patientdetails", cmbselectf.Text, cmbselecto.Text, tbsearch.Text)
            ElseIf cmbselecto.Text = "Patientdetails" Then
                Class1.str = String.Format("{0}", "Select * from Patientdetails ", cmbselectf.Text, cmbselecto.Text, tbsearch.Text)
            Else
                Class1.str = String.Format("{0} where {1}{2}'{3}'", "Select * from Patientdetails", cmbselectf.Text, cmbselecto.Text, tbsearch.Text)

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
            dgvPdetails.DataSource = Class1.dt
            tbsearch.Clear()
        End Try
    End Sub
    Public Sub showfield()
        Try
            Class1.cn.Open()
            Class1.dt.Rows.Clear()
            Class1.dt.Columns.Clear()
            Class1.cmd.CommandText = "select * from Patientdetails"
            Class1.cmd.Connection = Class1.cn
            Class1.dt.Load(Class1.cmd.ExecuteReader)
            Dim dc As DataColumn
            For Each dc In Class1.dt.Columns
                cmbselectf.Items.Add(dc.ColumnName)

            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Class1.cn.Close()
        End Try
    End Sub



    Private Sub dtpdob_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    'Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
    '    Dim age As Integer
    '    age = DateTime.Today.Year - dtp.Value.Year
    '    tbage.Text = age.ToString
    'End Sub

    Private Sub dtp_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp.ValueChanged
        'If dtp.Text < DateAndTime.Now Then
        'MessageBox.Show("DOB must greater than current year")
        'Else
        Dim d1 As Date = Date.Now
        Dim d2 As Date = dtp.Value
        Dim span As TimeSpan = d1 - d2
        tbage.Text = Int(span.Days / 365.25)
        'End If
        'Dim age As String
        'age = DateTime.Today.Year - dtp.Value.Year
        'tbage.Text = age.ToString

0:
        ''Dim d1 As Date = Date.Now
        'Dim d2 As Date = dtp.Value
        'Dim sp As TimeSpan
        'Dim ino As Integer
        'sp = Now.Subtract(d2)
        'ino = sp.Days
        'tbage.Text = ino
    End Sub






















































    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub tbid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbid.TextChanged

    End Sub

    Private Sub tbage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbage.TextChanged

    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class