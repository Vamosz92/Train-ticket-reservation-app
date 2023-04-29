using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beadando
{
    public partial class Jegyvasarlo4 : Form
    {
        string[] megallokAjkaBPNormal = { "Ajka","Várpalota","Székesfehérvár","Velence","Érd","Budapest"};
        string[] megallokAjkaBPGyors = { "Ajka", "Székesfehérvár", "Budapest" };
        string[] megallokAjkaSzhelyNormal = { "Ajka","Devecser","Boba","Celldömölk","Sárvár","Szombathely"};
        string[] megallokAjkaSzhelyGyors = { "Ajka","Celldömölk","Szombathely"};

        bool normalJegy = Jegyvasarlo.getnormalGyorsIndex()==0;
        bool uticelBp = Jegyvasarlo.getValasztottUtvonalIndex()==0;

        public Jegyvasarlo4()
        {
            InitializeComponent();
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vonat = uticelBp ? "Ajka-Budapest" : "Ajka-Szombathely";
            string osztaly = normalJegy ? "Normál" : "Gyors";

            MessageBox.Show(Jegyvasarlo2.getNumOfSelectedCells().ToString() + " db jegy sikeresen lefoglalva a " +
                vonat + " vonat " + osztaly + " osztályára. Úticél: " + comboBox1.SelectedItem);
        }

        private void Jegyvasarlo4_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Jegyvasarlo3 jv3 = new Jegyvasarlo3();
            this.Hide();
            jv3.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < comboBox1.Items.Count - 1) 
            {
                label3.Text = "500 Ft";
                double fizetendoOsszeg = Jegyvasarlo3.getOsszesen() - 500;
                label5.Text = fizetendoOsszeg.ToString();
            }
            else
            {
                label3.Text = "0 Ft";
                double fizetendoOsszeg = Jegyvasarlo3.getOsszesen();
                label5.Text = fizetendoOsszeg.ToString();
            }
        }
    }
}
