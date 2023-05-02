using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beadando
{
    public partial class Jegyvasarlo4 : Form
    {
        private MyApplication myApp;

        DB db = new DB();
        SQLiteCommand? com;
        SQLiteDataAdapter? adapter;

        string[] megallokAjkaBPNormal = { "Ajka","Várpalota","Székesfehérvár","Velence","Érd","Budapest"};
        string[] megallokAjkaBPGyors = { "Ajka", "Székesfehérvár", "Budapest" };
        string[] megallokAjkaSzhelyNormal = { "Ajka","Devecser","Boba","Celldömölk","Sárvár","Szombathely"};
        string[] megallokAjkaSzhelyGyors = { "Ajka","Celldömölk","Szombathely"};

        bool normalJegy = Jegyvasarlo.getnormalGyorsIndex()==0;
        bool uticelBp = Jegyvasarlo.getValasztottUtvonalIndex()==0;

        public Jegyvasarlo4(MyApplication myApp)
        {
            InitializeComponent();
            this.myApp = myApp;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        private void Jegyvasarlo4_Load(object sender, EventArgs e)
        {

            if (uticelBp)
            {
                if (normalJegy)
                {
                    comboBox1.Items.AddRange(megallokAjkaBPNormal);
                }
                else
                {
                    comboBox1.Items.AddRange(megallokAjkaBPGyors);
                }
            }
            else
            {
                if (normalJegy)
                {
                    comboBox1.Items.AddRange(megallokAjkaSzhelyNormal);
                }
                else
                {
                    comboBox1.Items.AddRange(megallokAjkaSzhelyGyors);
                }
            }
            comboBox1.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string vonat = uticelBp ? "Ajka-Budapest" : "Ajka-Szombathely";
            string osztaly = normalJegy ? "Normál" : "Gyors";

            myApp.myDTO.Meddig = comboBox1.SelectedItem.ToString();

            /*MessageBox.Show(Jegyvasarlo2.getNumOfSelectedCells().ToString() + " db jegy sikeresen lefoglalva a " +
                vonat + " vonat " + osztaly + " osztályára. Úticél: " + comboBox1.SelectedItem);*/

            MessageBox.Show("Név: " + myApp.myDTO.Nev 
                + "\nVásárolt helyek száma: " + myApp.myDTO.Helyek_szama 
                + "\nFizetett összeg: " + myApp.myDTO.Osszeg 
                + "\nVolt kupon? "+ myApp.myDTO.Kupon 
                + "\nMeddig utazik: "+ myApp.myDTO.Meddig 
                + "\nVálasztott útvonal: "+ myApp.myDTO.Utvonal 
                + "\nVonat tpusa: "+myApp.myDTO.Tipus 
                + "\nVálasztott osztály: "+ myApp.myDTO.Osztaly);

            db.openConnection();
            com = new SQLiteCommand("Insert into Foglalas(nev, helyek_szama, osszeg, kupon, meddig, utvonal, tipus)" + "Values(+'" + myApp.myDTO.Nev + "','" + 
                myApp.myDTO.Helyek_szama + "','" + 
                myApp.myDTO.Osszeg + "','" + 
                myApp.myDTO.Kupon + "','" + 
                myApp.myDTO.Meddig + "','" +
                myApp.myDTO.Utvonal + "','" + 
                myApp.myDTO.Tipus+ "')", db.GetConnection());
            //com = new SQLiteCommand("Insert into Foglalas(nev) Values('" + myApp.myDTO.Nev + "', '""')", db.GetConnection());
            com.ExecuteNonQuery();
            adapter = new SQLiteDataAdapter(com);
            db.closeConnection();
        }

        private void Jegyvasarlo4_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Jegyvasarlo3 jv3 = new Jegyvasarlo3(myApp);
            this.Hide();
            jv3.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(myApp);
            this.Hide();
            form1.Show();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < comboBox1.Items.Count - 1) 
            {
                label3.Text = "500 Ft";
                double fizetendoOsszeg = Jegyvasarlo3.getOsszesen() - 500;
                myApp.myDTO.Osszeg = fizetendoOsszeg;
                label5.Text = fizetendoOsszeg.ToString();
            }
            else
            {
                label3.Text = "0 Ft";
                double fizetendoOsszeg = Jegyvasarlo3.getOsszesen();
                myApp.myDTO.Osszeg = fizetendoOsszeg;
                label5.Text = fizetendoOsszeg.ToString();
            }
        }
    }
}
