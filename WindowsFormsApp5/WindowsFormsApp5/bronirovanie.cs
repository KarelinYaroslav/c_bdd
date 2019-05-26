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

namespace WindowsFormsApp5
{
    public partial class bronirovanie : Form
    {
        public bronirovanie(string login)
        {
            bron.loginee = login;
            InitializeComponent();

        }
        public class bron
        {
            public static string s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\WindowsFormsApp5\WindowsFormsApp5\belon_lux.mdf;Integrated Security=True";
            public static SqlConnection sqlt;

            public static SqlDataReader red,red2 = null;
            public static string loginee;
            

        }

        private async  void button1_Click(object sender, EventArgs e)
        {
            SqlCommand otv = new SqlCommand("INSERT INTO [бронирование](имя,фамилия,отчество,принял,иин,паспорт,дата,стол,количество)VALUES(@name,@surname,@familia,@prinal,@iin,@passport,@dataa,@stol,@col)", bron.sqlt);
            otv.Parameters.AddWithValue("name", textBox1.Text);
            otv.Parameters.AddWithValue("surname", textBox2.Text);
            otv.Parameters.AddWithValue("familia", textBox3.Text);
            otv.Parameters.AddWithValue("prinal", bron.loginee);
            otv.Parameters.AddWithValue("iin", textBox4.Text);
            otv.Parameters.AddWithValue("passport", textBox5.Text);
            otv.Parameters.AddWithValue("dataa", Convert.ToDateTime(textBox6.Text));
            otv.Parameters.AddWithValue("stol", Convert.ToInt32(textBox7.Text));
            otv.Parameters.AddWithValue("col", Convert.ToInt32(textBox8.Text));
           


            try
            {
                await otv.ExecuteNonQueryAsync();
                

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message.ToString(), ec.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private async  void bronirovanie_Load(object sender, EventArgs e)
        {

            bron.sqlt = new SqlConnection(bron.s);
            await bron.sqlt.OpenAsync();
           
         


        }

        private void bronirovanie_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bron.sqlt != null && bron.sqlt.State != ConnectionState.Closed)
            {
                bron.sqlt.Close();
            }
        }
    }
}
