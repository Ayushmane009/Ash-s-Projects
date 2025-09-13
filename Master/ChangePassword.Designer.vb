<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangePassword
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtoldpassword = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btncancel = New System.Windows.Forms.Button
        Me.btnlogin = New System.Windows.Forms.Button
        Me.txtconfpassword = New System.Windows.Forms.TextBox
        Me.lblconfpassword = New System.Windows.Forms.Label
        Me.txtpassword = New System.Windows.Forms.TextBox
        Me.lblpassword = New System.Windows.Forms.Label
        Me.lbluserprofile = New System.Windows.Forms.Label
        Me.txtusername = New System.Windows.Forms.TextBox
        Me.lblusername = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtoldpassword
        '
        Me.txtoldpassword.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtoldpassword.Location = New System.Drawing.Point(171, 53)
        Me.txtoldpassword.Name = "txtoldpassword"
        Me.txtoldpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtoldpassword.Size = New System.Drawing.Size(228, 26)
        Me.txtoldpassword.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btncancel)
        Me.GroupBox1.Controls.Add(Me.btnlogin)
        Me.GroupBox1.Controls.Add(Me.txtoldpassword)
        Me.GroupBox1.Controls.Add(Me.txtconfpassword)
        Me.GroupBox1.Controls.Add(Me.lblconfpassword)
        Me.GroupBox1.Controls.Add(Me.txtpassword)
        Me.GroupBox1.Controls.Add(Me.lblpassword)
        Me.GroupBox1.Controls.Add(Me.lbluserprofile)
        Me.GroupBox1.Controls.Add(Me.txtusername)
        Me.GroupBox1.Controls.Add(Me.lblusername)
        Me.GroupBox1.Font = New System.Drawing.Font("Georgia", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(11, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(411, 206)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Change Password"
        '
        'btncancel
        '
        Me.btncancel.BackColor = System.Drawing.Color.Black
        Me.btncancel.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btncancel.ForeColor = System.Drawing.Color.White
        Me.btncancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btncancel.Location = New System.Drawing.Point(208, 157)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(79, 33)
        Me.btncancel.TabIndex = 12
        Me.btncancel.Text = "Close"
        Me.btncancel.UseVisualStyleBackColor = False
        '
        'btnlogin
        '
        Me.btnlogin.BackColor = System.Drawing.Color.Black
        Me.btnlogin.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlogin.ForeColor = System.Drawing.Color.White
        Me.btnlogin.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnlogin.Location = New System.Drawing.Point(60, 157)
        Me.btnlogin.Name = "btnlogin"
        Me.btnlogin.Size = New System.Drawing.Size(79, 33)
        Me.btnlogin.TabIndex = 11
        Me.btnlogin.Text = "Ok"
        Me.btnlogin.UseVisualStyleBackColor = False
        '
        'txtconfpassword
        '
        Me.txtconfpassword.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtconfpassword.Location = New System.Drawing.Point(171, 120)
        Me.txtconfpassword.Name = "txtconfpassword"
        Me.txtconfpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtconfpassword.Size = New System.Drawing.Size(228, 26)
        Me.txtconfpassword.TabIndex = 3
        '
        'lblconfpassword
        '
        Me.lblconfpassword.AutoSize = True
        Me.lblconfpassword.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblconfpassword.Location = New System.Drawing.Point(4, 123)
        Me.lblconfpassword.Name = "lblconfpassword"
        Me.lblconfpassword.Size = New System.Drawing.Size(157, 18)
        Me.lblconfpassword.TabIndex = 6
        Me.lblconfpassword.Text = "confirm Password"
        '
        'txtpassword
        '
        Me.txtpassword.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpassword.Location = New System.Drawing.Point(171, 85)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtpassword.Size = New System.Drawing.Size(228, 26)
        Me.txtpassword.TabIndex = 2
        '
        'lblpassword
        '
        Me.lblpassword.AutoSize = True
        Me.lblpassword.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpassword.Location = New System.Drawing.Point(4, 88)
        Me.lblpassword.Name = "lblpassword"
        Me.lblpassword.Size = New System.Drawing.Size(168, 18)
        Me.lblpassword.TabIndex = 4
        Me.lblpassword.Text = "New User Password"
        '
        'lbluserprofile
        '
        Me.lbluserprofile.AutoSize = True
        Me.lbluserprofile.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbluserprofile.Location = New System.Drawing.Point(4, 56)
        Me.lbluserprofile.Name = "lbluserprofile"
        Me.lbluserprofile.Size = New System.Drawing.Size(121, 18)
        Me.lbluserprofile.TabIndex = 2
        Me.lbluserprofile.Text = "Old Password"
        '
        'txtusername
        '
        Me.txtusername.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtusername.Location = New System.Drawing.Point(171, 19)
        Me.txtusername.Name = "txtusername"
        Me.txtusername.Size = New System.Drawing.Size(228, 26)
        Me.txtusername.TabIndex = 0
        '
        'lblusername
        '
        Me.lblusername.AutoSize = True
        Me.lblusername.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblusername.Location = New System.Drawing.Point(4, 25)
        Me.lblusername.Name = "lblusername"
        Me.lblusername.Size = New System.Drawing.Size(98, 18)
        Me.lblusername.TabIndex = 0
        Me.lblusername.Text = "User Name"
        '
        'changepassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 279)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "changepassword"
        Me.Text = "ChangePassword"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtoldpassword As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtconfpassword As System.Windows.Forms.TextBox
    Friend WithEvents lblconfpassword As System.Windows.Forms.Label
    Friend WithEvents txtpassword As System.Windows.Forms.TextBox
    Friend WithEvents lblpassword As System.Windows.Forms.Label
    Friend WithEvents lbluserprofile As System.Windows.Forms.Label
    Friend WithEvents txtusername As System.Windows.Forms.TextBox
    Friend WithEvents lblusername As System.Windows.Forms.Label
    Friend WithEvents btncancel As System.Windows.Forms.Button
    Friend WithEvents btnlogin As System.Windows.Forms.Button
End Class
