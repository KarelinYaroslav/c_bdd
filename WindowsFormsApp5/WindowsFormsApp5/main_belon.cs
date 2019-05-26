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
    public partial class main_belon : Form
    {
        
        public main_belon(string logine ,string namee, string surnamee,string  patronymice, string receptione, string borne,  string positione,string adresse)
        {
            ma.bornee = borne;
            ma.loginee = logine;
            ma.nameee = namee;
            ma.patronymicee = patronymice;
            ma.positionee = positione;
            ma.receptionee = receptione;
            ma.surnameee = surnamee;
            ma.addressee = adresse;
            InitializeComponent();
        }
        public class ma {
           public static  string loginee, nameee,  surnameee, patronymicee, receptionee,  bornee, positionee,addressee;

        }

        private void main_belon_Load(object sender, EventArgs e)
        {
           
            label1.Text = "hello"+"  " + ma.nameee + "  "+ma.surnameee+"  "+ma.patronymicee;

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            nastroiki h = new nastroiki(ma.loginee, ma.nameee, ma.surnameee, ma.patronymicee, ma.receptionee, ma.bornee, ma.positionee, ma.addressee);
            h.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            bronirovanie d = new bronirovanie(ma.loginee);
            d.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            menu g = new menu();
            g.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            zakazi f = new zakazi();
            f.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            vsabd x = new vsabd();
            x.Show();
        }
    }
}
