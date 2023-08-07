using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CURDF_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-6TVP83S;Initial Catalog=CRUD_Form;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into ut values (@id,@name,@age)", con);
            cmd.Parameters.AddWithValue("@id",int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@name",textBox2.Text);
            cmd.Parameters.AddWithValue("@age",int.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Sucssesfully Inserted");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-6TVP83S;Initial Catalog=CRUD_Form;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update ut set name=@name,age=@age where id= @id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@name", textBox2.Text);
            cmd.Parameters.AddWithValue("@age", int.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Sucssesfully Updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-6TVP83S;Initial Catalog=CRUD_Form;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete ut where id=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));

            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Sucssesfully Deleted");

        }

        private void button4_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-6TVP83S;Initial Catalog=CRUD_Form;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from ut", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);//bridge of data source and data table help to update data insert data
            DataTable dt = new DataTable();
            da.Fill(dt);//fill method is used to refresh or add the data
            dataGridView1.DataSource = dt;
        }
    }

    }

