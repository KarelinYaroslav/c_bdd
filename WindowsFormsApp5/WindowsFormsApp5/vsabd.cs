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
    public partial class vsabd : Form
    {
        public vsabd()
        {
            InitializeComponent();
             
        }
        public class me
        {
            public static string s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\WindowsFormsApp5\WindowsFormsApp5\belon_lux.mdf;Integrated Security=True";
            public static SqlConnection sqlt;

            



        }

        private async  void vsabd_Load(object sender, EventArgs e)
        {
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            listView2.GridLines = true;
            listView2.FullRowSelect = true;
            listView2.View = View.Details;
            listView3.GridLines = true;
            listView3.FullRowSelect = true;
            listView3.View = View.Details;
            listView4.GridLines = true;
            listView4.FullRowSelect = true;
            listView4.View = View.Details;
            listView5.GridLines = true;
            listView5.FullRowSelect = true;
            listView5.View = View.Details;
            listView6.GridLines = true;
            listView6.FullRowSelect = true;
            listView6.View = View.Details;
            listView7.GridLines = true;
            listView7.FullRowSelect = true;
            listView7.View = View.Details;
            listView8.GridLines = true;
            listView8.FullRowSelect = true;
            listView8.View = View.Details;
            listView3.Columns.Add("Прайз");
            listView3.Columns.Add("Цена");
            listView4.Columns.Add("Прайз");
            listView4.Columns.Add("Цена");
            listView5.Columns.Add("Прайз");
            listView5.Columns.Add("Цена");
            listView6.Columns.Add("Прайз");
            listView6.Columns.Add("Цена");
            listView7.Columns.Add("Прайз");
            listView7.Columns.Add("Цена");
            listView8.Columns.Add("Прайз");
            listView8.Columns.Add("Цена");

            listView1.Columns.Add("имя");
            listView1.Columns.Add("фамилия");
            listView1.Columns.Add("отчество");
            listView1.Columns.Add("иин");
            listView1.Columns.Add("паспорт");
            listView1.Columns.Add("дата");
            listView1.Columns.Add("стол");
            listView1.Columns.Add("количество");
            listView1.Columns.Add("принял");
            listView1.Columns.Add("сумма");
            listView1.Columns.Add("заказали");

            
            listView2.Columns.Add("login");
            listView2.Columns.Add("password");
            listView2.Columns.Add("name");
            listView2.Columns.Add("surname");
            listView2.Columns.Add("patronymic");
            listView2.Columns.Add("address");
            listView2.Columns.Add("reception");
            listView2.Columns.Add("born");
            listView2.Columns.Add("position");
            me.sqlt = new SqlConnection(me.s);
            
            await me.sqlt.OpenAsync();
            SqlCommand otprv = new SqlCommand("SELECT * FROM[logpas]", me.sqlt);
            SqlCommand otpr = new SqlCommand("SELECT * FROM[бронирование]", me.sqlt);
            SqlCommand otp = new SqlCommand("SELECT * FROM[алкоголь]", me.sqlt);
            SqlCommand ot = new SqlCommand("SELECT * FROM[десерт]", me.sqlt);
            SqlCommand o = new SqlCommand("SELECT * FROM[рыб]", me.sqlt);
            SqlCommand v = new SqlCommand("SELECT * FROM[салат]",me. sqlt);
            SqlCommand vv = new SqlCommand("SELECT * FROM[суп]", me.sqlt);
            SqlCommand vvv = new SqlCommand("SELECT * FROM[мясо]", me.sqlt);
            SqlDataReader f = null;
            SqlDataReader f2 = null;
            SqlDataReader f3 = null;
            SqlDataReader f4 = null;
            SqlDataReader f5 = null;
            SqlDataReader f6 = null;
            SqlDataReader f7 = null;
            SqlDataReader f8 = null;

            try
            {
                f = await otpr.ExecuteReaderAsync();

                while (await f.ReadAsync()) {
                    ListViewItem et = new ListViewItem(new string[] {
                       Convert.ToString(f["имя"]),
                       Convert.ToString(f["фамилия"]),
                       Convert.ToString(f["отчество"]),
                       Convert.ToString(f["иин"]),Convert.ToString(f["паспорт"]),Convert.ToString(f["дата"]),Convert.ToString(f["стол"]),
                       Convert.ToString(f["количество"]),Convert.ToString(f["принял"]),Convert.ToString(f["сумма"]),Convert.ToString(f["заказали"])
                   });
                    listView1.Items.Add(et);
                }
                f.Close();
                f2 = await otprv.ExecuteReaderAsync();
                while (await f2.ReadAsync()) {
                    ListViewItem et = new ListViewItem(new string[] {
                         Convert.ToString(f2["login"]),
                         Convert.ToString(f2["password"]),
                       Convert.ToString(f2["name"]),
                       Convert.ToString(f2["surname"]),
                       Convert.ToString(f2["patronymic"]),
                       Convert.ToString(f2["address"]),
                       Convert.ToString(f2["reception"]),Convert.ToString(f2["born"]),Convert.ToString(f2["position"])

                   });
                    listView2.Items.Add(et);

                }
                f2.Close();
                f8 = await vvv.ExecuteReaderAsync();
                while (await f8.ReadAsync()) {

                    ListViewItem et = new ListViewItem(new string[] {
                         Convert.ToString(f8["Прайз"]),
                         Convert.ToString(f8["Цена"])


                   });
                    listView3.Items.Add(et);
                }
                f8.Close();
                f4 = await ot.ExecuteReaderAsync();
                while (await f4.ReadAsync()) {
                    ListViewItem et = new ListViewItem(new string[] {
                         Convert.ToString(f4["Прайз"]),
                         Convert.ToString(f4["Цена"])


                   });
                    listView4.Items.Add(et);

                }
                f4.Close();
                f3 = await otp.ExecuteReaderAsync();
                while (await f3.ReadAsync()) {

                    ListViewItem et = new ListViewItem(new string[] {
                         Convert.ToString(f3["Прайз"]),
                         Convert.ToString(f3["Цена"])


                   });
                    listView5.Items.Add(et);
                }
                f3.Close();
                f7 = await vv.ExecuteReaderAsync();
                while (await f7.ReadAsync()) {

                    ListViewItem et = new ListViewItem(new string[] {
                         Convert.ToString(f7["Прайз"]),
                         Convert.ToString(f7["Цена"])


                   });
                    listView6.Items.Add(et);
                }
                f7.Close();
                f5 = await o.ExecuteReaderAsync();
                while (await f5.ReadAsync()) {
                    ListViewItem et = new ListViewItem(new string[] {
                         Convert.ToString(f5["Прайз"]),
                         Convert.ToString(f5["Цена"])


                   });
                    listView7.Items.Add(et);

                }
                f5.Close();
                f6 = await v.ExecuteReaderAsync();
                while (await f6.ReadAsync()) {
                    ListViewItem et = new ListViewItem(new string[] {
                         Convert.ToString(f6["Прайз"]),
                         Convert.ToString(f6["Цена"])


                   });
                    listView8.Items.Add(et);
                }
                f6.Close();



            }
            catch (Exception ed)
            {

                MessageBox.Show(ed.Message.ToString(), ed.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                MessageBox.Show("Все данные загруженны ");
            }


        }

        private void vsabd_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (me.sqlt != null && me.sqlt.State != ConnectionState.Closed)
            {
                me.sqlt.Close();
            }

        }
    }
}
