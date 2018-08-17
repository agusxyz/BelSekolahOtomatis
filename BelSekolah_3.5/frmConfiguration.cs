using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BelSekolah_3._5
{
    public partial class frmConfiguration : Form
    {
        string connectionString;
        SQLiteConnection connection;

        public frmConfiguration()
        {
            InitializeComponent();
            connectionString = @"data source=data.db3";
        }

        private void frmConfiguration_Load(object sender, EventArgs e)
        {
            addHari();
            comboBoxHari.SelectedIndex = 0;
            populateData();
        }

        private void addHari()
        {
            comboBoxHari.Items.Add("SEMUA HARI");
            comboBoxHari.Items.Add("SENIN");
            comboBoxHari.Items.Add("SELASA");
            comboBoxHari.Items.Add("RABU");
            comboBoxHari.Items.Add("KAMIS");
            comboBoxHari.Items.Add("JUMAT");
            comboBoxHari.Items.Add("SABTU");
        }

        private void populateData()
        {
            connection = new SQLiteConnection(connectionString);
            SQLiteDataAdapter SDA;

            if (comboBoxHari.Text == "SEMUA HARI")
            {
                SDA = new SQLiteDataAdapter("SELECT id, Hari, Jam, Ket AS Keterangan FROM databel ORDER BY Jam", connection);
            }
            else
            {
                SDA = new SQLiteDataAdapter("SELECT id, Hari, Jam, Ket AS Keterangan FROM databel WHERE Hari=@HARI ORDER BY Jam", connection);
                SDA.SelectCommand.Parameters.AddWithValue("HARI", comboBoxHari.Text);
            }


            DataTable dt = new DataTable();
            connection.Open();
            SDA.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            labelRowCount.Text = dataGridView1.RowCount.ToString();
            connection.Close();
        }

        private void comboBoxHari_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateData();
        }


        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FrmAddNew frmAddNew = new FrmAddNew();
            frmAddNew.Show();   
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            connection = new SQLiteConnection(connectionString);
            SQLiteCommand myCmd;

            if (comboBoxHari.Text == "SEMUA HARI")
            {
                DialogResult dR = MessageBox.Show("Yakin Hapus Semua data?", "Peringatan", MessageBoxButtons.YesNo);
                if (dR == DialogResult.Yes)
                {
                    myCmd = new SQLiteCommand("DELETE FROM databel", connection);
                    connection.Open();
                    myCmd.ExecuteNonQuery();
                    connection.Close();
                }

                populateData();
            }
            else
            {
                DialogResult dR = MessageBox.Show("Yakin Hapus Semua data di hari " + comboBoxHari.Text + " ?", "Peringatan", MessageBoxButtons.YesNo);
                if (dR == DialogResult.Yes)
                {
                    myCmd = new SQLiteCommand("DELETE FROM databel WHERE Hari=@HARII", connection);
                    myCmd.Parameters.AddWithValue("@HARII", comboBoxHari.Text);
                    connection.Open();
                    myCmd.ExecuteNonQuery();
                    connection.Close();
                }

                populateData();
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            connection = new SQLiteConnection(connectionString);
            SQLiteCommand myCmd = new SQLiteCommand("DELETE FROM databel WHERE id=@ID", connection);

            myCmd.Parameters.AddWithValue("@ID", dataGridView1.SelectedCells[0].Value);

            connection.Open();
            myCmd.ExecuteNonQuery();
            connection.Close();

            populateData();
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            frmEdit FrmEdit = new frmEdit();
            FrmEdit.Id = int.Parse(dataGridView1.SelectedCells[0].Value.ToString());
            FrmEdit.Show();
        }
    }
}
