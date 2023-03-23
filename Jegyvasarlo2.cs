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
    public partial class Jegyvasarlo2 : Form
    {
        //próba
        private int[,] matrix = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        

        public Jegyvasarlo2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        private void Jegyvasarlo2_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dataGridView1 = new DataGridView();
            //dataGridView1.DataSource = matrix;
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Age", typeof(int));
            dt.Rows.Add("John", 25);
            dt.Rows.Add("Mary", 30);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Jegyvasarlo3 j3 = new Jegyvasarlo3();
            j3.Show();
        }

        private void Jegyvasarlo2_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
