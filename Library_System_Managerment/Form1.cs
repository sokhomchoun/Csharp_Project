using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Library_System_Managerment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // connected to sql server
        SqlConnection con = new SqlConnection("data source=LAPTOP-B0VSAKO6\\SQLEXPRESS01; initial catalog=Csharp_Library; trusted_connection=true; encrypt=false");
        private void btnLogin_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_login", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = txtUser.Text;
            cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = txtPass.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                // link to dashboard
                Dashboard dash = new Dashboard();
                dash.Show();
                this.Hide();

            }else{
                MessageBox.Show("Faild login please required again !");
            }
            con.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}