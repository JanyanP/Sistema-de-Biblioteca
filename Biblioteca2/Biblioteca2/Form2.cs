using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Biblioteca2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
        }

        public void  logIn() 
        {
            var user = txtUsuario.Text;
            var pass = txtPassword.Text;

            string command = "SELECT c.tipoCuenta FROM cuenta c WHERE c.usuario = @usuario AND c.password = @password";
            var conn = new SqlConnection("Data Source=DESKTOP-58DQ63D;Initial Catalog=Biblioteca;Integrated Security=True");
            var cmd = new SqlCommand(command, conn);
            cmd.Parameters.AddWithValue("@usuario", user);
            cmd.Parameters.AddWithValue("@password", pass);
            System.Data.DataTable dt = new System.Data.DataTable();

            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            adapt.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Usuario o Password Incorrectos");
            }
            else
            {
                var tipoCuenta = Convert.ToInt32(dt.Rows[0][0]);
                frmPrincipal form1 = new frmPrincipal();
                form1.tipoCuenta = tipoCuenta;
                this.Hide();
                form1.Show();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            logIn();
        }
    }
}
