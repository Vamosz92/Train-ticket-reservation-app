using System;
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
    public partial class Jegyvasarlo2 : Form
    {
        private MyApplication myApp;

        DB db = new DB();
        SQLiteCommand? com;
        SQLiteDataAdapter? adapter;
        DataTable? dt;
        private static int numOfSelectedCells;

        //próba
        private int[,] matrix = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

        public static int getNumOfSelectedCells()
        {
            return numOfSelectedCells;
        }


        public Jegyvasarlo2(MyApplication myApp)
        {
            InitializeComponent();
            this.myApp = myApp;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }
       
        public void showData(DataGridView dgv, string TableName)
        {
            db.openConnection();
            com = new SQLiteCommand("Select sor, oszlop from " + TableName, db.GetConnection());
            com.ExecuteNonQuery();
            adapter = new SQLiteDataAdapter(com);
            dt = new DataTable();
            adapter.Fill(dt);
            db.closeConnection();
            dgv.DataSource = dt;

            for (int i = 0; i < dgv.Columns.Count - 1; i++)
            {
                dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        public void showData2()
        {
            // létrehozzuk a mátrixot
            int[,] matrix = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            // létrehozzuk a DataGridView-t
            //dataGridView1.Dock = DockStyle.Fill;
            Controls.Add(dataGridView1);

            // hozzáadjuk a DataGridView-hoz a megfelelő számú oszlopot és sort
            dataGridView1.ColumnCount = matrix.GetLength(1);
            dataGridView1.RowCount = matrix.GetLength(0);

            // feltöltjük a DataGridView celláit a mátrix elemeivel
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = matrix[i, j];

                    // beállítjuk, hogy a cellák kattinthatóak legyenek
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.LightGray;
                    dataGridView1.Rows[i].Cells[j].Style.SelectionBackColor = Color.DarkGray;
                    dataGridView1.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    dataGridView1.Rows[i].Cells[j].Style.SelectionForeColor = Color.White;
                    dataGridView1.Rows[i].Cells[j].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Rows[i].Cells[j].Style.WrapMode = DataGridViewTriState.True;
                    dataGridView1.Rows[i].Cells[j].ReadOnly = true;
                }
            }
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            
        }

        private void Jegyvasarlo2_Load(object sender, EventArgs e)
        {
            /*DataTable dt = new DataTable();
            dataGridView1 = new DataGridView();
            //dataGridView1.DataSource = matrix;
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Age", typeof(int));
            dt.Rows.Add("John", 25);
            dt.Rows.Add("Mary", 30);
            dataGridView1.DataSource = dt;*/


            //showData(dataGridView1, "Vagon_első");
            showData2();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            numOfSelectedCells = dataGridView1.SelectedCells.Count;

            myApp.myDTO.Helyek_szama = numOfSelectedCells;

            this.Hide();
            Jegyvasarlo3 j3 = new Jegyvasarlo3(myApp);
            j3.Show();
        }

        private void Jegyvasarlo2_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Jegyvasarlo jegyvasarlo1 = new Jegyvasarlo(myApp);
            jegyvasarlo1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(myApp);
            this.Hide();
            form1.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
