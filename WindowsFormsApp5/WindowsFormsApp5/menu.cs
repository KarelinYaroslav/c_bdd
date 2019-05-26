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
    public partial class menu : Form
    {
        static int i = 0, total = 0;
        static string zakaz;
        public menu()
        {
            InitializeComponent();
           

        }
        public class men
        {
            public static string s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\WindowsFormsApp5\WindowsFormsApp5\belon_lux.mdf;Integrated Security=True";
            public static SqlConnection sqlt;

            public static SqlDataReader red = null;
            public static string loginee, selectedState;
            public static int selectedState2;



        }
       public async  void it(SqlCommand d)
        {
            
            try
            {
                listView1.Items.Clear();

                men.red = await d.ExecuteReaderAsync();
                while (await men.red.ReadAsync())
                {
                    ListViewItem et = new ListViewItem(new string[] {
                         Convert.ToString(men.red["Прайз"]),
                         Convert.ToString(men.red["Цена"])


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
                if (men.red != null && !men.red.IsClosed)
                {
                    men.red.Close();
                }
            }

        }

        
        private  void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            men.selectedState = comboBox1.SelectedItem.ToString();
            MessageBox.Show(men.selectedState);
            if (men.selectedState == "Мясные блюда")
            {
                SqlCommand otprv = new SqlCommand("SELECT * FROM[мясо]", men.sqlt);
                it(otprv);
            }
            if (men.selectedState == "Десерты")
            {
                SqlCommand otpr = new SqlCommand("SELECT * FROM[десерт]", men.sqlt);
                it(otpr);


            }
            if (men.selectedState == "Салаты")
            {
                SqlCommand otprr = new SqlCommand("SELECT * FROM[салат]", men.sqlt);
                it(otprr);
            }
            if (men.selectedState == "Супы")
            {

                SqlCommand otpr = new SqlCommand("SELECT * FROM[суп]", men.sqlt);
                it(otpr);
            }
            if (men.selectedState == "Алкоголь")
            {
                SqlCommand otpr = new SqlCommand("SELECT * FROM[алкоголь]", men.sqlt);
                it(otpr);
            }
            if (men.selectedState == "Рыбные блюда") {
                SqlCommand otpr = new SqlCommand("SELECT * FROM[рыб]", men.sqlt);
                it(otpr);
            }

        }

        private async  void menu_Load(object sender, EventArgs e)
        {
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            listView3.GridLines = true;
            listView3.FullRowSelect = true;
            listView3.View = View.Details;
            listView1.Columns.Add("Прайз");
            listView1.Columns.Add("Цена");
            listView2.GridLines = true;
            listView2.FullRowSelect = true;
            listView2.View = View.Details;
            listView2.Columns.Add("Прайз");
            listView2.Columns.Add("Цена");
            listView2.Columns.Add("Количество");
            listView3.Columns.Add("Id");
            listView3.Columns.Add("имя");
            listView3.Columns.Add("фамилия");
            listView3.Columns.Add("отчество");
            men.sqlt = new SqlConnection(men.s);
            await  men.sqlt.OpenAsync();
            SqlCommand otprv = new SqlCommand("SELECT * FROM[бронирование] ", men.sqlt);
            
            
            try
            {
                men.red = await otprv.ExecuteReaderAsync();
               
                while (await men.red.ReadAsync())
                {
                    ListViewItem et = new ListViewItem(new string[] {
                       Convert.ToString(men.red["Id"]),
                       Convert.ToString(men.red["имя"]),
                       Convert.ToString(men.red["фамилия"]),
                       Convert.ToString(men.red["отчество"])

                   });
                    listView3.Items.Add(et);
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.ToString(), exc.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (men.red != null && !men.red.IsClosed)
                {
                    men.red.Close();
                }
            }
        }

        private void menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (men.sqlt != null && men.sqlt.State != ConnectionState.Closed)
            {
                men.sqlt.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int price, quantity;
            string item;
            if (textBox1.Text != "")
            {
                price = int.Parse(listView1.SelectedItems[0].SubItems[1].Text);
                quantity = int.Parse(textBox1.Text);
                price = price * quantity;
                item = listView1.SelectedItems[0].Text;
                listView2.Items.Add(item);
                listView2.Items[i].SubItems.Add(price.ToString());
                listView2.Items[i].SubItems.Add(textBox1.Text);
                i++;
                total = total + price;
                label2.Text = "Общая сумма : "+total.ToString()+"  тенге";
                label2.Visible = true;
                
            }
            else { MessageBox.Show("Введите количество заказа !!"); }
        }

        private async   void button3_Click(object sender, EventArgs e)
        {
            int k = listView2.Items.Count;
            int x = 0;
            while (k >x) {
                zakaz += listView2.Items[x].Text+"  ";
                x++;

            }
            SqlCommand otv = new SqlCommand("UPDATE [бронирование] SET [сумма]=@su, [заказали]=@za WHERE [Id]=@Id", men.sqlt);
            otv.Parameters.AddWithValue("su", total);
            otv.Parameters.AddWithValue("za", zakaz);
            otv.Parameters.AddWithValue("Id", Convert.ToInt32(listView3.SelectedItems[0].SubItems[0].Text));

            
            try
            {
                await otv.ExecuteNonQueryAsync();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message.ToString(), ec.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems != null)
            {
                int deduct = 0;
                var confirm = MessageBox.Show("Вы уверены, что хотите отменить заказ ?", "Удаление заказа", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {

                    for (int i = 0; i < listView2.Items.Count; i++)
                    {
                        if (listView2.Items[i].Selected)
                        {

                            deduct = int.Parse(listView2.Items[i].SubItems[1].Text);
                            listView2.Items[i].Remove();
                            
                            i--;
                            
                        }
                    }

                }
                total = total - deduct;
                label2.Text = total.ToString();
                label2.Visible = true;
            }
            else
            {
                MessageBox.Show("Выберите  пункт для отмена заказа", "Отмена заказа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

  
    }

        

        

       
   


