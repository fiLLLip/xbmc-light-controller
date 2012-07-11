using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace xbmclightsharp
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtIP.Text == "")
            {
                MessageBox.Show("Please enter IP");
            }
            else if (radioDharma.Checked && txtPort.Text == "")
            {
                MessageBox.Show("Please enter Port");
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + "settings.ini", false))
                {
                    if (radioDharma.Checked)
                        sw.WriteLine("10");
                    else //since not Dharma (v10), then it is Eden (v11)
                        sw.WriteLine("11");
                    sw.WriteLine(txtIP.Text);
                    if (radioDharma.Checked) //Only write this information if Dharma (v10)
                    {
                        sw.WriteLine(txtPort.Text);
                        sw.WriteLine(txtUser.Text);
                        sw.WriteLine(txtPassword.Text);
                    }
                    sw.WriteLine(trackDimLevelPause.Value);
                    sw.WriteLine(trackDimLevelPlay.Value);
                    sw.WriteLine(trackDimLevelStop.Value);
                    sw.Close();
                }
                this.Close();
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + "settings.ini"))
            {
                try
                {
                    string version = sr.ReadLine();
                    txtIP.Text = sr.ReadLine();
                    if (version == "10")
                    {
                        txtPort.Text = sr.ReadLine();
                        txtUser.Text = sr.ReadLine();
                        txtPassword.Text = sr.ReadLine();
                    }
                    else
                    {
                        radioEden.Checked = true;
                    }
                    trackDimLevelPause.Value = int.Parse(sr.ReadLine());
                    trackDimLevelPlay.Value = int.Parse(sr.ReadLine());
                    trackDimLevelStop.Value = int.Parse(sr.ReadLine());
                    sr.Close();
                }
                catch
                { }
            }
            
            //Initialize labels  to value if not changed in start
            lblDimPause.Text = trackDimLevelPause.Value.ToString() + "%";
            lblDimPlay.Text = trackDimLevelPlay.Value.ToString() + "%";
            lblDimStop.Text = trackDimLevelStop.Value.ToString() + "%";
        }

        private void trackDimLevelPause_ValueChanged(object sender, EventArgs e)
        {
            lblDimPause.Text = trackDimLevelPause.Value.ToString() + "%";
        }

        private void trackDimLevelPlay_ValueChanged(object sender, EventArgs e)
        {
            lblDimPlay.Text = trackDimLevelPlay.Value.ToString() + "%";
        }

        private void trackDimLevelStop_ValueChanged(object sender, EventArgs e)
        {
            lblDimStop.Text = trackDimLevelStop.Value.ToString() + "%";
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioEden.Checked)
            {
                txtPort.Visible = false;
                txtPassword.Visible = false;
                txtUser.Visible = false;
            }
            else
            {
                txtPort.Visible = true;
                txtPassword.Visible = true;
                txtUser.Visible = true;
            }
        }

    }
}
