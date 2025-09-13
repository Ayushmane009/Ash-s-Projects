Imports System.Data
Imports System.Data.SqlClient
Public Class ChangePassword
    Dim cn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim strname As String = ""
    Dim strpwd As String = ""

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.Close()
    End Sub

    

    Private Sub changepassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cn.ConnectionString = "Data Source=.\SQLEXPRESS;AttachDbFilename=D:\DCM\DentalClinicMS\DCM.mdf;Integrated Security=True;User Instance=True"
    End Sub

    Private Sub btnlogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlogin.Click
        If txtusername.Text = "" Then
            MessageBox.Show("Enter the user Name", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtusername.Focus()
        ElseIf txtoldpassword.Text = "" Then
            MessageBox.Show("Enter the user old password", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtoldpassword.Focus()
            'ElseIf txtpassword.Text = "" Then
            '    MessageBox.Show("New Password must be enter", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    'txtpassword.Clear()
            '    txtpassword.Focus()
            'ElseIf txtconfpassword.Text = "" Then
            '    MessageBox.Show("Confirm Password must be enter", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    ' txtconfpassword.Clear()
            '    txtconfpassword.Focus()
        ElseIf Not txtpassword.Text = txtconfpassword.Text Then
            MessageBox.Show("Enter the Password and confirm Password is same", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Information)

            txtpassword.Focus()
        End If
        ' Else
        cn.Close()
        cn.Open()


        cmd.CommandText = "SELECT login_name, password  FROM Loginform WHERE   login_name='" & txtusername.Text & "' "
        cmd.Connection = cn
        dr = cmd.ExecuteReader()
        If dr.HasRows Then
            While dr.Read()
                strname = dr.GetString(0)
                strpwd = dr.GetString(1)
            End While
        End If
        MessageBox.Show(strname)
        cn.Close()

        If Not txtusername.Text = strname And Not txtoldpassword.Text = strpwd Then
            MessageBox.Show("Enter the correct user Name & old password", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtoldpassword.Focus()
        Else

            cn.Open()
            cmd.CommandText = "Update Loginform Set login_name='" & txtusername.Text & "', password= '" & txtpassword.Text & "' where login_name='" & txtusername.Text & "'"
            cmd.Connection = cn
            cmd.ExecuteNonQuery()
            MessageBox.Show("Password is changed sucessfullly", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cn.Close()
        End If
        'End If
        txtusername.Clear()
        txtoldpassword.Clear()
        txtconfpassword.Clear()
        txtpassword.Clear()
        txtusername.Focus()
    End Sub
End Class