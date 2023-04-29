using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Beadando
{
    public partial class Jegyvasarlo : Form
    {
        DB db = new DB();
        SQLiteCommand com;
        SQLiteDataAdapter adapter;
        DataTable dt;

        private static int valasztottUtvonalIndex;
        private static int normalGyorsIndex;

        static public int getValasztottUtvonalIndex()
        {
            return valasztottUtvonalIndex;
        }

        static public int getnormalGyorsIndex()
        {
            return normalGyorsIndex;
        }

        public Jegyvasarlo()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            valasztottUtvonalIndex = comboBox1.SelectedIndex;
            normalGyorsIndex = comboBox2.SelectedIndex;
            Jegyvasarlo2 j2 = new Jegyvasarlo2();
            this.Hide();
            j2.Show();
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Jegyvasarlo_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Jegyvasarlo_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;   
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }
    }
}
