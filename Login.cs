using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace DCMS.Admin
{
    public partial class Login : Form
    {
        SqlConnection cn = new SqlConnection(@" ");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlDataReader dr;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        String strusername, strpassword;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnlogin1_Click(object sender, EventArgs e)
        {

        }
    }
}