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

        public Jegyvasarlo()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Jegyvasarlo2 j2 = new Jegyvasarlo2();
            this.Hide();
            j2.Show();
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

            for (int i=0; i<dgv.Columns.Count-1; i++)
            {
                dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void Jegyvasarlo_Load(object sender, EventArgs e)
        {
            showData(dataGridView1, "Vagon_első");
            showData(dataGridView2, "Vagon_második");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Jegyvasarlo_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
