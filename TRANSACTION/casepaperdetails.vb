Imports System.Data.SqlClient
Public Class casepaperdetails
    Dim s1 As String
    Public Sub New(ByVal a As Integer, ByVal s As String)
        Try
            InitializeComponent()
            txtcasepaperid.Text = a
            s1 = s
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
        End Try
    End Sub
    Public Sub showgrid1()
        Try
            Class1.cn.Close()
            Class1.cn.Open()
            Class1.dt2.Clear()
            Class1.dt2.Rows.Clear()
            Class1.dt2.Columns.Clear()
            ' Class1.cmd.CommandText = "SELECT Casepaperdetails.cpd_id, Casepaperdetails.Treat_date, Casepaperdetails.c_id, Treatmentdetails.charges FROM Casepaperdetails INNER JOIN Casepaperheader ON Casepaperdetails.c_id = Casepaperheader.c_id INNER JOIN Treatmentdetails ON Casepaperdetails.Td_id = Treatmentdetails.Td_id INNER JOIN Patientdetails ON Casepaperheader.p_id = Patientdetails.p_id WHERE Patientdetails.p_name = '" & cmbpid.Text & "'"
            Class1.cmd.CommandText = "SELECT * from Casepaperdetails where c_id=" & txtcasepaperid.Text & ""
            Class1.cmd.Connection = Class1.cn
            Class1.dt2.Load(Class1.cmd.ExecuteReader)
            dgvcasepaperdetail.DataSource = Class1.dt2
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()

        End Try
    End Sub
    Public Sub loadTreatment()
        Try
            Class1.cn.Open()
            Dim dt2 As New DataTable
            Class1.cmd.CommandText = "Select * from Treatmentheader"
            Class1.cmd.Connection = Class1.cn
            dt2.Load(Class1.cmd.ExecuteReader)
            cmbtid.DataSource = dt2
            cmbtid.DisplayMember = "T_name"
            cmbtid.ValueMember = "T_id"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
        End Try
    End Sub
    Public Sub loadphase()
        Try
            Class1.cn.Close()
            Class1.cn.Open()
            Dim dt2 As New DataTable
            Class1.cmd.CommandText = "SELECT  * FROM Treatmentdetails WHERE T_id in (select T_id from Treatmentheader where T_name ='" & cmbtid.Text & "')"
            Class1.cmd.Connection = Class1.cn
            dt2.Load(Class1.cmd.ExecuteReader)
            cmbphase.DataSource = dt2
            cmbphase.DisplayMember = "phase"
            cmbphase.ValueMember = "Td_id"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
        End Try
    End Sub

    Private Sub casepaperdetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim cn1 As New Class1
            cn1.conn()
            loadTreatment()
            showgrid1()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
        End Try
    End Sub

    Private Sub cmbtid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtid.SelectedIndexChanged
        Try
            loadphase()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
        End Try
    End Sub

    Private Sub cmbphase_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbphase.SelectedIndexChanged
        Try
            Class1.cn.Close()
            Class1.cn.Open()
            Dim dt2 As New DataTable
            'Class1.cmd.CommandText = "Select charges from Treatmentdetails where phase='" & cmbphase.Text & "'and T_id=" & cmbtid.SelectedValue & ""
            Class1.cmd.CommandText = "SELECT Treatmentdetails.charges FROM Treatmentdetails INNER JOIN Treatmentheader ON Treatmentdetails.T_id = Treatmentheader.T_id WHERE (Treatmentheader.T_name = '" & cmbtid.Text & "') AND (Treatmentdetails.phase = '" & cmbphase.Text & "')"
            Class1.cmd.Connection = Class1.cn

            Class1.dr = Class1.cmd.ExecuteReader

            Dim p As String
            While Class1.dr.Read
                p = Class1.dr(0).ToString()
                tbcharges.Text = p
            End While
            cmbtid.ValueMember = "T_id"
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
        End Try
    End Sub

    Private Sub btnexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexit.Click
        Me.Close()
    End Sub

    Private Sub btnnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnew.Click
        Try
            Class1.cn.Open()
            Dim k As Integer
            Class1.cmd.CommandText = "Select max(cpd_id)from Casepaperdetails"
            Class1.cmd.Connection = Class1.cn
            Class1.dr = Class1.cmd.ExecuteReader()
            If (Class1.dr.Read()) Then
                Dim str As String
                str = Class1.dr(0).ToString

                If str = "" Then
                    tbcdid.Text = "1"
                Else
                    k = Convert.ToInt32(Class1.dr(0).ToString())
                    k = k + 1
                    tbcdid.Text = k.ToString()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
            showgrid1()
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcasepaperid.TextChanged

    End Sub

    Private Sub dgvcasepaper_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvcasepaperdetail.CellContentClick
        Try
            'dgvcasepaperdetail.Enabled = False

            tbcdid.Text = dgvcasepaperdetail.Rows(e.RowIndex).Cells(0).Value.ToString
            txtcasepaperid.Text = dgvcasepaperdetail.Rows(e.RowIndex).Cells(1).Value.ToString

            Dim b As Integer
            'Dim bstr As String
            b = dgvcasepaperdetail.Rows(e.RowIndex).Cells(2).Value.ToString


            Dim ds As New DataSet
            Class1.cn.Open()
            Dim da1 As New SqlDataAdapter("Select T_id,T_name from TreatmentHeader where T_id=" & b & "", Class1.cn)
            da1.Fill(ds)
            cmbtid.DataSource = ds.Tables(0)
            cmbtid.ValueMember = "T_id"
            cmbtid.DisplayMember = "T_name"

            Dim c As Integer
            c = dgvcasepaperdetail.Rows(e.RowIndex).Cells(3).Value.ToString
            Dim ds1 As New DataSet
            Class1.cn.Open()
            Dim da2 As New SqlDataAdapter("Select Td_id,phase from Treatmentdetails where Td_id=" & c & "", Class1.cn)
            da2.Fill(ds1)
            cmbphase.DataSource = ds1.Tables(0)
            cmbphase.ValueMember = "Td_id"
            cmbphase.DisplayMember = "phase"



        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally


        End Try

    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click

        If txtcasepaperid.Text = "" Or tbcdid.Text = "" Or cmbtid.Text = "" Or dtptdate.Text = "" Then
            MsgBox("Fill all fields...", MsgBoxStyle.Critical)
        End If

        'DCM.Text = ""
        Try
            If (cbul8.Checked) Then
                DCM.Text = DCM.Text + UL.Text + ul8.Text
            End If

            If (cbul7.Checked) Then
                DCM.Text = DCM.Text + UL.Text + ul7.Text
            End If

            If (cbul6.Checked) Then
                DCM.Text = DCM.Text + UL.Text + ul6.Text
            End If
            If (cbul5.Checked) Then
                DCM.Text = DCM.Text + UL.Text + ul5.Text
            End If
            If (cbul4.Checked) Then
                DCM.Text = DCM.Text + UL.Text + ul4.Text
            End If
            If (cbul3.Checked) Then
                DCM.Text = UL.Text + ul3.Text
            End If
            If (cbul2.Checked) Then
                DCM.Text = DCM.Text + UL.Text + ul2.Text
            End If
            If (cbul1.Checked) Then
                DCM.Text = DCM.Text + UL.Text + ul1.Text
            End If

            If (cbur1.Checked) Then
                DCM.Text = DCM.Text + UR.Text + ur1.Text
            End If
            If (cbur2.Checked) Then
                DCM.Text = DCM.Text + UR.Text + ur2.Text
            End If
            If (cbur3.Checked) Then
                DCM.Text = DCM.Text + UR.Text + ur3.Text
            End If
            If (cbur4.Checked) Then
                DCM.Text = DCM.Text + UR.Text + ur4.Text
            End If
            If (cbur5.Checked) Then
                DCM.Text = DCM.Text + UR.Text + ur5.Text
            End If
            If (cbur6.Checked) Then
                DCM.Text = DCM.Text + UR.Text + ur6.Text
            End If
            If (cbur7.Checked) Then
                DCM.Text = DCM.Text + UR.Text + ur7.Text
            End If
            If (cbur8.Checked) Then
                DCM.Text = DCM.Text + UR.Text + ur8.Text
            End If
            If (cbll8.Checked) Then
                DCM.Text = DCM.Text + LL.Text + ll8.Text
            End If
            If (cbll7.Checked) Then
                DCM.Text = DCM.Text + LL.Text + ll7.Text
            End If
            If (cbll6.Checked) Then
                DCM.Text = DCM.Text + LL.Text + ll6.Text
            End If
            If (cbll5.Checked) Then
                DCM.Text = DCM.Text + LL.Text + ll5.Text
            End If
            If (cbll4.Checked) Then
                DCM.Text = DCM.Text + LL.Text + ll4.Text
            End If
            If (cbll3.Checked) Then
                DCM.Text = DCM.Text + LL.Text + ll3.Text
            End If
            If (cbll2.Checked) Then
                DCM.Text = DCM.Text + LL.Text + ll2.Text
            End If
            If (cbll1.Checked) Then
                DCM.Text = DCM.Text + LL.Text + ll1.Text
            End If
            If (cblr1.Checked) Then
                DCM.Text = DCM.Text + LR.Text + lr1.Text
            End If
            If (cblr2.Checked) Then
                DCM.Text = DCM.Text + LR.Text + lr2.Text
            End If
            If (cblr3.Checked) Then
                DCM.Text = DCM.Text + LR.Text + lr3.Text
            End If
            If (cblr4.Checked) Then
                DCM.Text = DCM.Text + LR.Text + lr4.Text
            End If
            If (cblr5.Checked) Then
                DCM.Text = DCM.Text + LR.Text + lr5.Text
            End If
            If (cblr6.Checked) Then
                DCM.Text = DCM.Text + LR.Text + lr6.Text
            End If
            If (cblr7.Checked) Then
                DCM.Text = DCM.Text + LR.Text + lr7.Text
            End If
            If (cblr8.Checked) Then
                DCM.Text = DCM.Text + LR.Text + lr8.Text
            End If
            Class1.cn.Open()
            Class1.cmd.CommandText = "insert into Casepaperdetails values (" & tbcdid.Text & "," & txtcasepaperid.Text & "," & cmbtid.SelectedValue & "," & cmbphase.SelectedValue & ",@p1,'" & DCM.Text & "')"
            Class1.cmd.Connection = Class1.cn
            Class1.cmd.Parameters.Clear()
            Class1.cmd.Parameters.Add("@p1", SqlDbType.DateTime).Value = dtptdate.Text
            Class1.cmd.ExecuteNonQuery()
            MessageBox.Show("Record save successfully", "save", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Class1.cn.Close()
            'clear()
            showgrid1()
            DCM.Text = ""
        End Try
    End Sub

    Private Sub btnmodify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmodify.Click
        Try
            Class1.cmd.CommandText = "Update Casepaperdetails set T_id=" & cmbtid.SelectedValue & ",Td_id='" & cmbphase.SelectedValue & "',Treat_date=@p1 where cpd_id=" & tbcdid.Text & ""
            Class1.cn.Open()
            Class1.cmd.Parameters.Clear()
            Class1.cmd.Parameters.Add("@p1", SqlDbType.DateTime).Value = dtptdate.Text
            'Class1.cmd.Parameters.Add("@p2", SqlDbType.DateTime).Value = dtpvd.Text
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

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            dgvcasepaperdetail.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
        End Try
    End Sub

    Private Sub btnprescription_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnprescription.Click
        Dim a As Integer = Val(tbcdid.Text)
        Dim pr As New prescriptiondetails(a, s1)
        pr.Show()
    End Sub

















    Private Sub cbul4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cbul3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cbul2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cbul1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub cbul6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub ul8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ul4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ul5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ul6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ul7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ul3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ul2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ul1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub














































































































    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub
End Class