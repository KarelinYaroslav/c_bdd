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
    public partial class zakazi : Form
    {
        public zakazi()
        {
            InitializeComponent();
        }
        public class za
        {
            public static string s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\WindowsFormsApp5\WindowsFormsApp5\belon_lux.mdf;Integrated Security=True";
            public static SqlConnection sqlt;

            public static SqlDataReader red = null;
            public static string selectedState;


        }


        private async  void zakazi_Load(object sender, EventArgs e)
        {
            za.sqlt = new SqlConnection(za.s);
           await  za.sqlt.OpenAsync();
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            listView1.Columns.Add("Id");
            listView1.Columns.Add("имя");
            listView1.Columns.Add("фамилия");
            listView1.Columns.Add("отчество");
            listView1.Columns.Add("дата");
            listView1.Columns.Add("количество");


        }

        private void zakazi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (za.sqlt != null && za.sqlt.State != ConnectionState.Closed)
            {
                za.sqlt.Close();
            }
        }

        private async  void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            za.selectedState = comboBox1.SelectedItem.ToString();
            MessageBox.Show(za.selectedState);
            SqlCommand otprv = new SqlCommand("SELECT * FROM[бронирование] ", za.sqlt);
            try
            {
               za. red = await otprv.ExecuteReaderAsync();
                while (await za.red.ReadAsync())
                {
                    if (Convert.ToString(za.red["стол"]) == za.selectedState)
                    {

                        ListViewItem et = new ListViewItem(new string[] {
                       Convert.ToString(za.red["Id"]),
                       Convert.ToString(za.red["имя"]),
                       Convert.ToString(za.red["фамилия"]),
                       Convert.ToString(za.red["отчество"]), Convert.ToString(za.red["дата"]), Convert.ToString(za.red["количество"])

                   });
                        listView1.Items.Add(et);
                    }
                    else { continue; }
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.ToString(), exc.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (za.red != null && !za.red.IsClosed)
                {
                    za.red.Close();
                }
            }

        }

        private async  void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                DialogResult q = MessageBox.Show("Вы хотите удалить его ?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);


                if (q == DialogResult.OK)
                {
                    SqlCommand udl = new SqlCommand("DELETE  FROM [бронирование] WHERE [Id]=@Id", za.sqlt);
                    udl.Parameters.AddWithValue("Id", Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
                    try
                    {
                        await udl.ExecuteNonQueryAsync();


                    }
                    catch (Exception ep)
                    {
                        MessageBox.Show(ep.Message.ToString(), ep.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }



                }
            }
        }
    }
    }

