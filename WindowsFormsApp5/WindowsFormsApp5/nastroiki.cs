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
    public partial class nastroiki : Form
    {
        public nastroiki(string logine, string namee, string surnamee, string patronymice, string receptione, string borne, string positione, string adresse)
        {
            kt.bornee = borne;
            kt.loginee = logine;
            kt.nameee = namee;
            kt.patronymicee = patronymice;
            kt.positionee = positione;
            kt.receptionee = receptione;
            kt.surnameee = surnamee;
            kt.addressee = adresse;
            InitializeComponent();
            
        }
        
        public class kt
        {
            public static string s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\WindowsFormsApp5\WindowsFormsApp5\belon_lux.mdf;Integrated Security=True";
            public static SqlConnection sqlt;
            public static SqlDataReader red = null;
            public static string loginee, nameee, surnameee, patronymicee, receptionee, bornee, positionee, addressee;
            public static int Id;

        }

        private async void nastroiki_Load(object sender, EventArgs e)
        {

            kt.sqlt = new SqlConnection(kt.s);
            await kt.sqlt.OpenAsync();
            SqlCommand otprv = new SqlCommand("SELECT * FROM[logpas]", kt.sqlt);
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            listView1.Columns.Add("Id");
            listView1.Columns.Add("login");
            listView1.Columns.Add("password");
            listView1.Columns.Add("name");
            listView1.Columns.Add("surname");
            listView1.Columns.Add("patronymic");
            listView1.Columns.Add("address");
            listView1.Columns.Add("reception");
            listView1.Columns.Add("born");
            listView1.Columns.Add("position");
            


            try
            {

                kt.red = await otprv.ExecuteReaderAsync();
                while (await kt.red.ReadAsync())
                {
                    ListViewItem et = new ListViewItem(new string[] {
                         Convert.ToString(kt.red["Id"]),
                         Convert.ToString(kt.red["login"]),
                         Convert.ToString(kt.red["password"]),
                       Convert.ToString(kt.red["name"]),
                       Convert.ToString(kt.red["surname"]),
                       Convert.ToString(kt.red["patronymic"]),
                       Convert.ToString(kt.red["address"]),
                       Convert.ToString(kt.red["reception"]),Convert.ToString(kt.red["born"]),Convert.ToString(kt.red["position"])

                   });
                    listView1.Items.Add(et);

                }

            }
            catch (Exception ed)
            {

                MessageBox.Show(ed.Message.ToString(), ed.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (kt.red != null && !kt.red.IsClosed)
                {
                    kt.red.Close();
                }
            }

        }
       
        private void nastroiki_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kt.sqlt != null && kt.sqlt.State != ConnectionState.Closed)
            {
                kt.sqlt.Close();
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                kt.Id = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
                SqlCommand ot = new SqlCommand("SELECT[name], [surname], [patronymic], [address], [reception], [born], [position], [login], [password] FROM[logpas] WHERE[Id] = @Id", kt.sqlt);
                ot.Parameters.AddWithValue("Id", kt.Id);

                try
                {

                    kt.red = await ot.ExecuteReaderAsync();
                    while (await kt.red.ReadAsync())
                    {

                        textBox1.Text = Convert.ToString(kt.red["name"]);
                        textBox2.Text = Convert.ToString(kt.red["surname"]);
                        textBox3.Text = Convert.ToString(kt.red["patronymic"]);
                        textBox4.Text = Convert.ToString(kt.red["reception"]);
                        textBox5.Text = Convert.ToString(kt.red["born"]);
                        textBox6.Text = Convert.ToString(kt.red["position"]);
                        textBox7.Text = Convert.ToString(kt.red["address"]);
                        textBox8.Text = Convert.ToString(kt.red["login"]);
                        textBox9.Text = Convert.ToString(kt.red["password"]);
                    }
                }
                catch (Exception el)
                {

                    MessageBox.Show(el.Message.ToString(), el.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    if (kt.red != null && !kt.red.IsClosed)
                    {
                        kt.red.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Вы не выделили сотрудника");
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            SqlCommand upd = new SqlCommand("UPDATE [logpas] SET [name]=@name, [surname]=@surname, [patronymic]=@patronymic, [reception]=@reception, [born]=@born, [position]=@position, [address]=@address, [login]=@login, [password]=@password WHERE [Id]=@Id", kt.sqlt);
            upd.Parameters.AddWithValue("name", textBox1.Text);
            upd.Parameters.AddWithValue("surname", textBox2.Text);
            upd.Parameters.AddWithValue("patronymic", textBox3.Text);
            upd.Parameters.AddWithValue("reception", Convert.ToDateTime(textBox4.Text));
            upd.Parameters.AddWithValue("born", Convert.ToDateTime(textBox5.Text));
            upd.Parameters.AddWithValue("position", textBox6.Text);
            upd.Parameters.AddWithValue("address", textBox7.Text);
            upd.Parameters.AddWithValue("Id", kt.Id);
            upd.Parameters.AddWithValue("login", textBox8.Text);
            upd.Parameters.AddWithValue("password", textBox9.Text);

            try
            {
                await upd.ExecuteNonQueryAsync();
            }
            catch (Exception el)
            {
                MessageBox.Show(el.Message.ToString(), el.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private async void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            SqlCommand otprv = new SqlCommand("SELECT * FROM[logpas]", kt.sqlt);

            try
            {

                kt.red = await otprv.ExecuteReaderAsync();
                while (await kt.red.ReadAsync())
                {
                    ListViewItem et = new ListViewItem(new string[] {
                         Convert.ToString(kt.red["Id"]),
                         Convert.ToString(kt.red["login"]),
                         Convert.ToString(kt.red["password"]),
                       Convert.ToString(kt.red["name"]),
                       Convert.ToString(kt.red["surname"]),
                       Convert.ToString(kt.red["patronymic"]),
                       Convert.ToString(kt.red["address"]),
                       Convert.ToString(kt.red["reception"]),Convert.ToString(kt.red["born"]),Convert.ToString(kt.red["position"])

                   });
                    listView1.Items.Add(et);

                }

            }
            catch (Exception ed)
            {

                MessageBox.Show(ed.Message.ToString(), ed.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (kt.red != null && !kt.red.IsClosed)
                {
                    kt.red.Close();
                }

            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                DialogResult q = MessageBox.Show("Вы хотите удалить его ?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (q == DialogResult.OK)
                {
                    SqlCommand udl = new SqlCommand("DELETE  FROM [logpas] WHERE [Id]=@Id", kt.sqlt);
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

        private async void button4_Click(object sender, EventArgs e)
        {
            SqlCommand otv = new SqlCommand("INSERT INTO [logpas](name,surname,patronymic,reception,born,position,address,login,password)VALUES(@name,@surname,@patronymic,@reception,@born,@position,@address,@login,@PASSWORD)", kt.sqlt);
            otv.Parameters.AddWithValue("name", textBox1.Text);
            otv.Parameters.AddWithValue("surname", textBox2.Text);
            otv.Parameters.AddWithValue("patronymic", textBox3.Text);
            otv.Parameters.AddWithValue("reception", Convert.ToDateTime(textBox4.Text));
            otv.Parameters.AddWithValue("born", Convert.ToDateTime(textBox5.Text));
            otv.Parameters.AddWithValue("position", textBox6.Text);
            otv.Parameters.AddWithValue("address", textBox7.Text);
            otv.Parameters.AddWithValue("login", textBox8.Text);
            otv.Parameters.AddWithValue("password", textBox9.Text);

            try
            {
                await otv.ExecuteNonQueryAsync();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message.ToString(), ec.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private async  void button5_Click_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                DialogResult q = MessageBox.Show("Вы хотите удалить его ?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);


                if (q == DialogResult.OK)
                {
                    SqlCommand udl = new SqlCommand("DELETE  FROM [logpas] WHERE [Id]=@Id", kt.sqlt);
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

        private  async  void button6_Click_1(object sender, EventArgs e)
        {
            
            SqlCommand upd = new SqlCommand("UPDATE [logpas] SET [password]=@password WHERE [Id]=@Id", kt.sqlt);
            if (listView1.SelectedItems.Count > 0) {
                upd.Parameters.AddWithValue("password", textBox9.Text);
                upd.Parameters.AddWithValue("Id", Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
                try
                {
                    await upd.ExecuteNonQueryAsync();

                }
                catch (Exception el)
                {
                    MessageBox.Show(el.Message.ToString(), el.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

                } }
        }

        

       
    }
    }
