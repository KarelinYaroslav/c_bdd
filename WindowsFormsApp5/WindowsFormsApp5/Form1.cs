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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public  class  Globals {
            public  static  string s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\WindowsFormsApp5\WindowsFormsApp5\belon_lux.mdf;Integrated Security=True";
            public    static SqlConnection sqlt;
            public    static SqlDataReader red = null;
            public   static string loginn, passwordd,name,surname,patronymic,reception,born,position,address;
            public static bool auto = false;



        }

        private   void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private  async void button1_Click(object sender, EventArgs e)
        {
            Globals.sqlt = new SqlConnection(Globals.s);
            await Globals.sqlt.OpenAsync();
            Globals.loginn = textBox1.Text;
            Globals.passwordd = textBox2.Text;
            SqlCommand otprv = new SqlCommand("SELECT * FROM[logpas] ", Globals.sqlt);
            Globals.red= await otprv.ExecuteReaderAsync();
            try {
                while (await Globals.red.ReadAsync()) {
                    if (Convert.ToString( Globals.red["login"]) == Globals.loginn && Convert.ToString( Globals.red["password"]) == Globals.passwordd)
                    {
                        Globals.auto = true;
                        Globals.name = Convert.ToString( Globals.red["name"]);
                        Globals.patronymic =Convert.ToString(  Globals.red["patronymic"]);
                        Globals.surname =Convert.ToString( Globals.red["surname"]);
                        Globals.position =Convert.ToString( Globals.red["position"]);
                        Globals.reception =Convert.ToString( Globals.red["reception"]);
                        Globals.born = Convert.ToString(Globals.red["born"]);
                        Globals.address = Convert.ToString(Globals.red["address"]);
                        break;

                    }
                    else {

                        continue; }

                }
            }
            catch (Exception el) {
                MessageBox.Show(el.Message.ToString(), el.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally {
                if (Globals.red != null && !Globals.red.IsClosed) { Globals.red.Close(); }

            }
            if (Globals.auto == true) { MessageBox.Show("Все верно");

                main_belon b = new main_belon(Globals.loginn, Globals.name, Globals.surname, Globals.patronymic, Globals.reception, Globals.born, Globals.position,Globals.address);
                Hide();
                b.Show();

 

            }

            else { MessageBox.Show("Не правильные данные"); }



        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Globals.sqlt != null && Globals.sqlt.State != ConnectionState.Closed) {
                Globals.sqlt.Close();
            }
        }
    }
}
