Public Class prescriptiondetails
    Dim b As Integer
    Dim s1 As String
    Public Sub New(ByVal a As Integer, ByVal s As String)
        b = a
        s1 = s
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        Try
            Class1.cn.Open()
            Dim k As Integer
            Class1.cmd.CommandText = "Select max(ps_id)from prescriptiondetails"
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
            'txtdttype.Clear()
        End Try
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click

        If tbid.Text = "" Or cpdid.Text = "" Or cmbmedicin.Text = "" Or cmbdays.Text = "" Then
            ' MsgBox("Fill all fields...", MsgBoxStyle.Critical)

        End If

        Try
            Dim s1 As String
            If (chkmorning.Checked) Then
                s1 = chkmorning.Text
            Else
                s1 = "no"
            End If

            Dim s2 As String
            If (chkafter.Checked) Then
                s2 = chkafter.Text
            Else
                s2 = "no"
            End If

            Dim s3 As String
            If (chknight.Checked) Then
                s3 = chknight.Text
            Else
                s3 = "no"
            End If



            Class1.cn.Open()
            Class1.cmd.CommandText = "Insert into prescriptiondetails values(" & tbid.Text & ",'" & cmbmedicin.Text & "','" & cmbdays.Text & "','" & s1 & "','" & s2 & "','" & s3 & "'," & cpdid.Text & ")"
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
    Public Sub Showgrid()
        'Try
        '    Class1.cn.Open()
        '    Class1.dt1.Clear()
        '    Class1.cmd.CommandText = "Select * from prescriptiondetails"
        '    Class1.cmd.Connection = Class1.cn
        '    Class1.dt1.Load(Class1.cmd.ExecuteReader)
        '    dgvprescription.DataSource = Class1.dt1
        'Catch ex As Exception
        '    MessageBox.Show(ex.ToString)
        'Finally
        '    Class1.cn.Close()
        'End Try
        Try
            Class1.cn.Close()
            Class1.cn.Open()
            Class1.dt1.Clear()
            Class1.dt1.Rows.Clear()
            Class1.dt1.Columns.Clear()
            ' Class1.cmd.CommandText = "SELECT Casepaperdetails.cpd_id, Casepaperdetails.Treat_date, Casepaperdetails.c_id, Treatmentdetails.charges FROM Casepaperdetails INNER JOIN Casepaperheader ON Casepaperdetails.c_id = Casepaperheader.c_id INNER JOIN Treatmentdetails ON Casepaperdetails.Td_id = Treatmentdetails.Td_id INNER JOIN Patientdetails ON Casepaperheader.p_id = Patientdetails.p_id WHERE Patientdetails.p_name = '" & cmbpid.Text & "'"
            Class1.cmd.CommandText = "Select * from prescriptiondetails where cpd_id=" & cpdid.Text & ""
            Class1.cmd.Connection = Class1.cn
            Class1.dt1.Load(Class1.cmd.ExecuteReader)
            dgvprescription.DataSource = Class1.dt1
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()

        End Try
    End Sub

    Private Sub btnmodify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodify.Click
        Try
            Class1.cn.Open()
            Class1.cmd.CommandText = "Update prescriptiondetails set medicin_name='" & cmbmedicin.Text & "' ,No of Days='" & cmbdays.Text & "',cpd_id=" & cpdid.Text & ", where ps_id=" & tbid.Text & ""
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
            Class1.cmd.CommandText = "Delete From prescriptiondetails where ps_id=" & tbid.Text & ""
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

    Private Sub prescriptiondetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cpdid.Text = b
            tbpname.Text = s1
            btnadd.Enabled = True
            btnsave.Enabled = True
            btnmodify.Enabled = False
            btndelete.Enabled = False

            Dim cn1 As New Class1
            cn1.conn()
            Showgrid()
            'showfield()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
        End Try
    End Sub

    Private Sub dgvprescription_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvprescription.CellContentClick
        Try
            btnadd.Enabled = False
            btnsave.Enabled = False
            btnmodify.Enabled = True
            btndelete.Enabled = True
            btnclear.Enabled = True
            btnexit.Enabled = True


            tbid.Text = dgvprescription.Rows(e.RowIndex).Cells(0).Value.ToString
            cmbmedicin.Text = dgvprescription.Rows(e.RowIndex).Cells(1).Value.ToString
            cmbdays.Text = dgvprescription.Rows(e.RowIndex).Cells(2).Value.ToString
            Dim x As String = dgvprescription.Rows(e.RowIndex).Cells(3).Value.ToString
            If x = "Morning" Then
                chkmorning.Checked = True
            Else
                chkmorning.Checked = False
            End If
            Dim y As String = dgvprescription.Rows(e.RowIndex).Cells(4).Value.ToString
            If y = "Afternoon" Then
                chkafter.Checked = True
            Else
                chkafter.Checked = False
            End If
            Dim z As String = dgvprescription.Rows(e.RowIndex).Cells(5).Value.ToString
            If y = "Evening" Then
                chknight.Checked = True
            Else
                chknight.Checked = False
            End If
            cpdid.Text = dgvprescription.Rows(e.RowIndex).Cells(6).Value.ToString
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
        End Try
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class