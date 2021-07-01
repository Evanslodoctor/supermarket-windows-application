using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-EVC6IPJ;Initial Catalog=SUPERMAKET;Integrated Security=True");

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please Enter the username and password");
            }
            else
            {
                if (roleCB.SelectedIndex > -1)
                {
                    if (roleCB.SelectedItem.ToString() == "ADMIN")
                    {
                        if (txtUserName.Text == "Admin" && txtPassword.Text == "Admin")
                        {
                            ProductForm bd = new ProductForm();
                            bd.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Admin user name or password");
                        }

                    }
                    else
                    {
                        // MessageBox.Show("you're in a seller section");
                        cnn.Open();
                        SqlDataAdapter ad = new SqlDataAdapter("select count(8) from Sellers where sellerName='"+txtUserName.Text+"' AND sellerPassword='"+txtPassword.Text+"'",cnn);
                        DataTable dt = new DataTable();
                        
                        ad.Fill(dt);
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            SellingForm sell = new SellingForm();
                            sell.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect user Name or Password");
                        }
                        cnn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Select role");
                }
            }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
