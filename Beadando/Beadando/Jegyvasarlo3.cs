using System;
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
    public partial class Jegyvasarlo3 : Form
    {

        private static double osszesen = 0;
        private int foglaltJegyek = Jegyvasarlo2.getNumOfSelectedCells();

        public Jegyvasarlo3()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        public static double getOsszesen()
        {
            return osszesen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Jegyvasarlo4 j4 = new Jegyvasarlo4();
            j4.Show();
            this.Hide();
        }

        private void Jegyvasarlo3_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Jegyvasarlo2 jv2 = new Jegyvasarlo2();
            this.Hide();
            jv2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void Jegyvasarlo3_Load(object sender, EventArgs e)
        {
      
            label3.Text = foglaltJegyek.ToString();

            osszesen = Jegyvasarlo.getnormalGyorsIndex() == 0 ? 1000 * foglaltJegyek : 2000 * foglaltJegyek;

            label5.Text = osszesen.ToString();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            osszesen = Jegyvasarlo.getnormalGyorsIndex() == 0 ? 1000 * foglaltJegyek : 2000 * foglaltJegyek;

            if (textBox1.Text == "10")
            {
                osszesen = osszesen * 0.9;
            }
            else if (textBox1.Text == "20")
            {
                osszesen = osszesen * 0.8;
            }

            label5.Text = osszesen.ToString();
        }
    }
}
