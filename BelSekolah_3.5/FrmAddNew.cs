using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Windows.Forms;
using System.Data.SQLite;

namespace BelSekolah_3._5
{
    public partial class FrmAddNew : Form
    {
        string connectionString;
        SQLiteConnection connection;

        string pathbel;
        string jam;
        string keterangan;

        SoundPlayer player;

        public FrmAddNew()
        {
            InitializeComponent();

            connectionString = "data source=data.db3";
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

        private void FrmAddNew_Load(object sender, EventArgs e)
        {
            populateBel();
            comboBoxBel.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false
                && checkBox4.Checked == false && checkBox5.Checked == false && checkBox6.Checked == false)
            {
                MessageBox.Show("Pilih Hari !");
            }
            else if (tbJam.Text == "" || tbMenit.Text == "")
            {
                MessageBox.Show("Atur Waktunya dulu !");
            }
            else if (tbKeterangan.Text == "")
            {
                MessageBox.Show("Tambahkan Keterangan");
            }
            else
            {
                saveToDb();
                MessageBox.Show("Data Tersimpan");
                uncheckAll();
                checkBox7.Checked = false;

                tbJam.Text = "";
                tbMenit.Text = "";
                tbKeterangan.Text = "";


            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == false)
            {
                uncheckAll();
            }
            else
            {
                checkAll();
            }
        }

        private void uncheckAll()
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
        }

        private void checkAll()
        {
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox3.Checked = true;
            checkBox4.Checked = true;
            checkBox5.Checked = true;
            checkBox6.Checked = true;
        }

        private void tbJam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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

        private void saveToDb()
        {
            connection = new SQLiteConnection(connectionString);

            SQLiteCommand myCmd;



            if (comboBoxBel.Text != "---SILAHKAN PILIH---")
            {
                pathbel = @"Sounds\" + comboBoxBel.Text;
            }

            jam = tbJam.Text + ":" + tbMenit.Text + ":" + tbDetik.Text;

            keterangan = tbKeterangan.Text;

            if (checkBox1.Checked == true)
            {
                myCmd = new SQLiteCommand("INSERT INTO databel VALUES(@Hari, @Jam, @Data, @Ket, @idHr, NULL)", connection);

                myCmd.Parameters.AddWithValue("@Hari", "SENIN");
                myCmd.Parameters.AddWithValue("@Jam", jam);
                myCmd.Parameters.AddWithValue("@Data", pathbel);
                myCmd.Parameters.AddWithValue("@Ket", keterangan);
                myCmd.Parameters.AddWithValue("@idHr", 1);

                connection.Open();
                myCmd.ExecuteNonQuery();
                connection.Close();
            }

            if (checkBox2.Checked == true)
            {
                myCmd = new SQLiteCommand("INSERT INTO databel VALUES(@Hari, @Jam, @Data, @Ket, @idHr, NULL)", connection);

                myCmd.Parameters.AddWithValue("@Hari", "SELASA");
                myCmd.Parameters.AddWithValue("@Jam", jam);
                myCmd.Parameters.AddWithValue("@Data", pathbel);
                myCmd.Parameters.AddWithValue("@Ket", keterangan);
                myCmd.Parameters.AddWithValue("@idHr", 2);

                connection.Open();
                myCmd.ExecuteNonQuery();
                connection.Close();
            }

            if (checkBox3.Checked == true)
            {
                myCmd = new SQLiteCommand("INSERT INTO databel VALUES(@Hari, @Jam, @Data, @Ket, @idHr, NULL)", connection);

                myCmd.Parameters.AddWithValue("@Hari", "RABU");
                myCmd.Parameters.AddWithValue("@Jam", jam);
                myCmd.Parameters.AddWithValue("@Data", pathbel);
                myCmd.Parameters.AddWithValue("@Ket", keterangan);
                myCmd.Parameters.AddWithValue("@idHr", 3);

                connection.Open();
                myCmd.ExecuteNonQuery();
                connection.Close();
            }

            if (checkBox4.Checked == true)
            {
                myCmd = new SQLiteCommand("INSERT INTO databel VALUES(@Hari, @Jam, @Data, @Ket, @idHr, NULL)", connection);

                myCmd.Parameters.AddWithValue("@Hari", "KAMIS");
                myCmd.Parameters.AddWithValue("@Jam", jam);
                myCmd.Parameters.AddWithValue("@Data", pathbel);
                myCmd.Parameters.AddWithValue("@Ket", keterangan);
                myCmd.Parameters.AddWithValue("@idHr", 4);

                connection.Open();
                myCmd.ExecuteNonQuery();
                connection.Close();
            }

            if (checkBox5.Checked == true)
            {
                myCmd = new SQLiteCommand("INSERT INTO databel VALUES(@Hari, @Jam, @Data, @Ket, @idHr, NULL)", connection);

                myCmd.Parameters.AddWithValue("@Hari", "JUMAT");
                myCmd.Parameters.AddWithValue("@Jam", jam);
                myCmd.Parameters.AddWithValue("@Data", pathbel);
                myCmd.Parameters.AddWithValue("@Ket", keterangan);
                myCmd.Parameters.AddWithValue("@idHr", 5);

                connection.Open();
                myCmd.ExecuteNonQuery();
                connection.Close();
            }

            if (checkBox6.Checked == true)
            {
                myCmd = new SQLiteCommand("INSERT INTO databel VALUES(@Hari, @Jam, @Data, @Ket, @idHr, NULL)", connection);

                myCmd.Parameters.AddWithValue("@Hari", "SABTU");
                myCmd.Parameters.AddWithValue("@Jam", jam);
                myCmd.Parameters.AddWithValue("@Data", pathbel);
                myCmd.Parameters.AddWithValue("@Ket", keterangan);
                myCmd.Parameters.AddWithValue("@idHr", 6);

                connection.Open();
                myCmd.ExecuteNonQuery();
                connection.Close();

            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            comboBoxBel.SelectedIndex = 0;

            OpenFileDialog chofdlog = new OpenFileDialog();
            chofdlog.Filter = "Wav Files (*.wav) | *.wav";
            chofdlog.FilterIndex = 1;
            chofdlog.Multiselect = false;

            if (chofdlog.ShowDialog() == DialogResult.OK)
            {
                pathbel = chofdlog.FileName;
            }
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

                player.Play();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            playSound();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.Stop();
        }
    }
}
