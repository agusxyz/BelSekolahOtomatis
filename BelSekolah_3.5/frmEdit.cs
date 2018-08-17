using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Media;
using System.Windows.Forms;

namespace BelSekolah_3._5
{
    public partial class frmEdit : Form
    {
        string connectionString;
        SQLiteConnection connection;


        string hari;
        string idHari;
        string pathbel;
        string keterengan;
        string jam;

        SoundPlayer player;

        public int Id { get; set; }

        public frmEdit()
        {
            InitializeComponent();
            connectionString = "data source=data.db3";
        }

        private void frmEdit_Load(object sender, EventArgs e)
        {
            populateBel();
            getAllData();
            comboBoxBel.SelectedIndex = 0;

        }

        public void populateBel()
        {
            comboBoxBel.Items.Add("---SILAHKAN PILIH---");
            comboBoxBel.Items.Add("5 Menit Akhir Istirahat.wav");
            comboBoxBel.Items.Add("5 Menit Akhir Keagamaan.wav");
            comboBoxBel.Items.Add("5 Menit Akhir Ujian.wav");
            comboBoxBel.Items.Add("5 Menit Awal Keagamaan.wav");
            comboBoxBel.Items.Add("5 Menit Awal Upacara.wav");
            comboBoxBel.Items.Add("5 Menit Pelajaran ke 1.wav");
            comboBoxBel.Items.Add("Akhir Pekan.wav");
            comboBoxBel.Items.Add("Akhir Pelajaran.wav");
            comboBoxBel.Items.Add("Bel Sekolah.wav");
            comboBoxBel.Items.Add("Istirahat.wav");
            comboBoxBel.Items.Add("Pelajaran ke 1.wav");
            comboBoxBel.Items.Add("Pelajaran ke 2.wav");
            comboBoxBel.Items.Add("Pelajaran ke 3.wav");
            comboBoxBel.Items.Add("Pelajaran ke 4.wav");
            comboBoxBel.Items.Add("Pelajaran ke 5.wav");
            comboBoxBel.Items.Add("Pelajaran ke 6.wav");
            comboBoxBel.Items.Add("Pelajaran ke 7.wav");
            comboBoxBel.Items.Add("Pelajaran ke 8.wav");
            comboBoxBel.Items.Add("Upacara Bendera.wav");
            comboBoxBel.Items.Add("Waktu Ujian Habis.wav");

        }

        private void getAllData()
        {

            connection = new SQLiteConnection(connectionString);

            SQLiteCommand myCmd = new SQLiteCommand("SELECT Hari, Jam, Data, Ket, idHr FROM databel where id=@ID", connection);
            myCmd.Parameters.AddWithValue("@ID", Id);

            SQLiteDataReader Reader = null;
            connection.Open();
            Reader = myCmd.ExecuteReader();

            while (Reader.Read())
            {
                hari = Reader["Hari"].ToString();
                jam = Reader["Jam"].ToString();
                pathbel = Reader["Data"].ToString();
                keterengan = Reader["Ket"].ToString();
                idHari = Reader["idHr"].ToString();
            }

            tbKeterangan.Text = keterengan;
            tbJam.Text = jam[0].ToString() + jam[1].ToString();
            tbMenit.Text = jam[3].ToString() + jam[4].ToString();

            switch (hari)
            {
                case "SENIN":
                    checkBox1.Checked = true;
                    break;

                case "SELASA":
                    checkBox2.Checked = true;
                    break;

                case "RABU":
                    checkBox3.Checked = true;
                    break;

                case "KAMIS":
                    checkBox4.Checked = true;
                    break;

                case "JUMAT":
                    checkBox5.Checked = true;
                    break;

                case "SABTU":
                    checkBox6.Checked = true;
                    break;
            }
            connection.Close();
        }

        private void tbJam_TextChanged(object sender, EventArgs e)
        {
            int i;
            int.TryParse(tbJam.Text, out i);

            if (i > 23 && tbJam.Text != "")
            {
                tbJam.Text = "";
            }
        }

        private void tbJam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbMenit_TextChanged(object sender, EventArgs e)
        {
            int i;
            int.TryParse(tbMenit.Text, out i);

            if (i > 59 && tbMenit.Text != "")
            {
                tbMenit.Text = "";
            }
        }

        private void tbMenit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            comboBoxBel.SelectedIndex = 0;

            OpenFileDialog chofdlog = new OpenFileDialog();
            chofdlog.Filter = "Music Files (*.mp3, *.wav) | *.mp3; *.wav";
            chofdlog.FilterIndex = 1;
            chofdlog.Multiselect = false;

            if (chofdlog.ShowDialog() == DialogResult.OK)
            {
                pathbel = chofdlog.FileName;
            }
        }

        private void saveToDb()
        {
            connection = new SQLiteConnection(connectionString);

            SQLiteCommand myCmd;



            if (comboBoxBel.Text != "---SILAHKAN PILIH---")
            {
                pathbel = @"Sounds\" + comboBoxBel.Text;
            }

            jam = tbJam.Text + ":" + tbMenit.Text + ":" + tbDetik.Text;

            keterengan = tbKeterangan.Text;

            myCmd = new SQLiteCommand("UPDATE databel SET Hari = @HARI, Jam = @JAM, Data = @DATA, Ket = @KET, idHr = @IDHR WHERE id=@ID", connection);

            myCmd.Parameters.AddWithValue("@HARI", hari);
            myCmd.Parameters.AddWithValue("@JAM", jam);
            myCmd.Parameters.AddWithValue("@DATA", pathbel);
            myCmd.Parameters.AddWithValue("@KET", keterengan);
            myCmd.Parameters.AddWithValue("@IDHR", idHari);
            myCmd.Parameters.AddWithValue("@ID", Id);

            connection.Open();
            myCmd.ExecuteNonQuery();
            connection.Close();


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveToDb();
            MessageBox.Show("Data Tersimpan !");
            this.Close();
        }

        private void playSound()
        {
            if (pathbel == null && comboBoxBel.Text == "---SILAHKAN PILIH---")
            {
                MessageBox.Show("Bel belum ditentukan !");
            }
            else
            {


                if (comboBoxBel.Text != "---SILAHKAN PILIH---")
                {
                    player = new SoundPlayer(@"Sounds\" + comboBoxBel.Text);
                }
                else
                {
                    player = new SoundPlayer(pathbel);
                }

                try
                {
                    player.Play();
                } catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            playSound();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
