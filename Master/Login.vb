Imports System.Data
Imports System.Data.SqlClient
Public Class Login
    Dim cn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim strname, strpwd As String


    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=D:\DCM\DentalClinicMS\DCM.mdf;Integrated Security=True;User Instance=True"
    End Sub


    Private Sub btnlogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlogin.Click
        If txtname.Text = "" Then
            MessageBox.Show("Enter the user Name", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtname.Focus()
        ElseIf txtpassword.Text = "" Then
            MessageBox.Show("Enter the user  password", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtname.Focus()
        End If
        cn.Open()
        cmd.CommandText = "SELECT login_name, password  FROM Loginform WHERE   login_name='" & txtname.Text & "' "
        cmd.Connection = cn
        dr = cmd.ExecuteReader()
        If dr.HasRows Then
            While dr.Read()
                strname = dr.GetString(0)
                strpwd = dr.GetString(1)
            End While
        End If

        cn.Close()

        If strname = txtname.Text And strpwd = txtpassword.Text Then
            MessageBox.Show("Login Successfully" & vbNewLine & "Welcome to DCM", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Dim l As New main()

            l.Show()
            Me.Hide()
        Else
            MessageBox.Show("Confirm your User Name Or Password", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If


    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        txtname.Clear()
        txtpassword.Clear()
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class