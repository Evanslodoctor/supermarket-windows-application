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
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            Populate();
        }
        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-EVC6IPJ;Initial Catalog=SUPERMAKET;Integrated Security=True");

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                string query = "insert into CATEGORY values(" + txtCategoryId.Text + ",' " + txtCategoryName.Text + " ','" + txtCategoryDescription.Text + "')";
                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category inserted successfully");

                cnn.Close();
                // Populate();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCategoryId.Text == "" || txtCategoryName.Text == "" || txtCategoryDescription.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    cnn.Open();
                    string query = "update CATEGORY set categoryName='" + txtCategoryName.Text + "',categoryDescription='" + txtCategoryDescription.Text + "' where categoryID=" + txtCategoryId.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category updated successfully");
                    cnn.Close();
                   Populate();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCategoryId.Text == "")
                {
                    MessageBox.Show("Select Category to Delete");
                }
                else
                {
                    cnn.Open();
                    string query = "delete from CATEGORY where categoryID= " + txtCategoryId.Text + "";
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category was deleted succesfully");
                    cnn.Close();
                   // Populate();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SellersForm sel = new SellersForm();
            sel.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProductForm pro = new ProductForm();
            pro.Show();
            this.Hide();
        }
        void Populate()
        {
            try
            {
                cnn.Open();
                string query2 = "select * from PRODUCT";
                SqlDataAdapter sda = new SqlDataAdapter(query2, cnn);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                catDGV.DataSource = ds.Tables[0];

                cnn.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // txtCategoryId.Text = catDGV.SelectedRows[0].Cells[0].Value.ToString();
           // txtCategoryName.Text = catDGV.SelectedRows[0].Cells[1].Value.ToString();
           // txtCategoryDescription.Text = catDGV.SelectedRows[0].Cells[2].Value.ToString();
        }
    }
}
