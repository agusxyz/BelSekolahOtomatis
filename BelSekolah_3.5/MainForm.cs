using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Threading;

namespace BelSekolah_3._5
{
    public partial class MainForm : Form
    {
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();

        string _pathbel;

        bool doLoop = true;

        string connectionString;
        SQLiteConnection connection;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        public MainForm()
        {
            InitializeComponent();
            connectionString = @"data source = data.db3";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            loopingToolStripMenuItem.Checked = true;
            t.Interval = 1000;
            t.Tick += T_Tick;
            t.Start();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;

            string time = "";

            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }

            time += ":";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }

            time += ":";

            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }

            labelJam.Text = time;
            labelTanggal.Text = DateTime.Now.ToLongDateString();
            loadData();
        }


        private void loadData()
        {
            connection = new SQLiteConnection(connectionString);
            SQLiteCommand myCmd = new SQLiteCommand("SELECT Data from databel WHERE idHr = @IDHR AND Jam = @JAM", connection);

            string Jam = fullClock();

            int IDhr = (int)DateTime.Now.DayOfWeek;
            myCmd.Parameters.AddWithValue("@IDHR", IDhr);
            myCmd.Parameters.AddWithValue("@JAM", Jam);
            SQLiteDataReader Reader = null;
            connection.Open();
            Reader = myCmd.ExecuteReader();

            while (Reader.Read())
            {
                _pathbel = Reader["Data"].ToString();
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = _pathbel;
                player.Play();
                Thread.Sleep(1000);
                if (doLoop == true)
                {
                    SoundInfo SI = new SoundInfo();
                    int Length = SI.GetSoundLength(_pathbel);
                    Thread.Sleep(Length);
                    player.Play();
                }
            }
        }


        private string fullClock()
        {
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;

            string time = "";

            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }

            time += ":";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }

            time += ":";

            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }

            return time;
        }

        private void pengaturanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfiguration FrmConf = new frmConfiguration();
            FrmConf.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loopingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loopingToolStripMenuItem.Checked == true)
            {
                doLoop = false;
                loopingToolStripMenuItem.Checked = false;
            }
            else
            {
                doLoop = true;
                loopingToolStripMenuItem.Checked = true;
            }
        }
    }
}
