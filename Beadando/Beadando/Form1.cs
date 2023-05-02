using static System.Windows.Forms.Design.AxImporter;
using System.Data.SQLite;
using System.Data;

namespace Beadando
{
    public partial class Form1 : Form
    {

        MyApplication myApp;

        DB db = new DB();
        SQLiteCommand? command;
        SQLiteDataAdapter? adapter;
        DataTable? dt;

        public Form1(MyApplication myApp)
        {
            this.myApp = myApp;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox= false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.openConnection();
            command = new SQLiteCommand("select * from Felhasznalo where felhasznalonev='"+textBox1.Text
                +"'and jelszo='"+textBox2.Text+"'", db.GetConnection());
            dt = new DataTable();
            adapter= new SQLiteDataAdapter(command);
            adapter.Fill(dt);
            db.closeConnection();

            string? selectedItem = comboBox1.SelectedItem.ToString();

            if (dt.Rows.Count > 0)
            {
                for (int i=0; i<dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["szerepkor"].ToString() == selectedItem)
                    {
                        MessageBox.Show("Ön sikeresen belépett " + dt.Rows[i]["szerepkor"].ToString() + "ként!");
                        if (comboBox1.SelectedIndex == 0)
                        {
                            Jegyvasarlo j = new Jegyvasarlo(myApp);
                            this.Hide();
                            j.ShowDialog();
                        }
                        else
                        {
                            Rendszergazda rgazda = new Rendszergazda();
                            this.Hide();
                            rgazda.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Rossz szerepkör!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Rossz felhasználónév, vagy jelszó!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                button1_Click(sender, e);
            } 
        }
    }
}
