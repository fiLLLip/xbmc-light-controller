using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using XbmcJson;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;
using System.Net.Sockets;

namespace xbmclightsharp
{
    public partial class MainView : Form
    {
        XbmcConnection Xbmc;
        System.Windows.Forms.Timer UpdateTimerOne = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer UpdateTimerLights = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer UpdateTimerTen = new System.Windows.Forms.Timer();
        string Ip, Port, User, Password, Version;
        int DimlevelPause;
        int DimlevelPlay;
        int DimlevelStop;
        string videoState = "stopped";
        string tempvideoState = "stopped";
        bool settingsread = false;
        ArrayList lights = new ArrayList();
        ArrayList allLights = new ArrayList();
        bool loading = false;
        Thread lightProcess;
        bool lightFinishedUpdated = true;

        public MainView()
        {
            InitializeComponent();
        }

        void UpdateTimerLights_Tick(Object myObject, EventArgs myEventArgs)
        {
            UpdateTimerLights.Stop();
            if (tempvideoState != videoState)
            {
                if (tempvideoState == "playing")
                {
                    if (lightFinishedUpdated)
                    {
                        lightProcess.Abort();
                        lightProcess = new Thread(playingstate);
                        lightProcess.Start();
                        videoState = tempvideoState;
                    }
                }
                if (tempvideoState == "paused")
                {
                    if (lightFinishedUpdated)
                    {
                        lightProcess.Abort();
                        lightProcess = new Thread(pausestate);
                        lightProcess.Start();
                        videoState = tempvideoState;
                    }
                }
                if (tempvideoState == "stopped")
                {
                    if (lightFinishedUpdated)
                    {
                        lightProcess.Abort();
                        lightProcess = new Thread(stoppedstate);
                        lightProcess.Start();
                        videoState = tempvideoState;
                    }
                }
            }
            UpdateTimerLights.Start();
        }

        public void RefreshVideoState()
        {
            bool IsPlayerActive;
            try
            {
                IsPlayerActive = Xbmc.Player.IsVideoPlayerActive();
            }
            catch
            {
                IsPlayerActive = false;
            }
            if (IsPlayerActive)
            {
                try
                {
                    tempvideoState = Xbmc.VideoPlayer.State();
                }
                catch
                {
                    tempvideoState = "stopped";
                }
            }
            else
                tempvideoState = "stopped";
        }

        void UpdateTimerOne_Tick(Object myObject, EventArgs myEventArgs)
        {
            UpdateTimerOne.Stop();
            if (Xbmc.Status.IsConnected)
            {
                RefreshVideoState();
            }
            UpdateTimerOne.Start();
        }

        void UpdateTimerTen_Tick(Object myObject, EventArgs myEventArgs)
        {
            UpdateTimerTen.Stop();
            if (Xbmc.Status.IsConnected)
            {
                lblConnected.Text = "Connected";
                lblConnected.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblConnected.Text = "Disconnected";
                lblConnected.ForeColor = System.Drawing.Color.Red;
            }
            UpdateTimerTen.Start();
        }

        public void stoppedstate()
        {
            lightFinishedUpdated = false;
            try
            {
                foreach (int[] light in allLights)
                {
                    CheckBox checkbox = this.groupBox1.Controls.Find("chkboxStop" + light[0], true).FirstOrDefault() as CheckBox;
                    if (checkbox.Checked == true)
                    {
                        int i = Convert.ToInt32(light[0]);
                        int methods = TelldusAPI.tdMethods(i, TelldusAPI.TELLSTICK_TURNON | TelldusAPI.TELLSTICK_DIM);
                        if (methods == TelldusAPI.TELLSTICK_DIM | methods == TelldusAPI.TELLSTICK_DIM + TelldusAPI.TELLSTICK_TURNON)
                        {
                            if (DimlevelStop == 0)
                                TelldusAPI.tdTurnOff(i);
                            else if (DimlevelStop == 255)
                                TelldusAPI.tdTurnOn(i);
                            else
                                TelldusAPI.tdDim(i, DimlevelStop);
                        }
                        else
                            TelldusAPI.tdTurnOn(i);
                    }
                }
            }
            catch
            {
                
            }
            lightFinishedUpdated = true;
        }

        public void pausestate()
        {
            lightFinishedUpdated = false;
            try
            {
                foreach (int[] light in allLights)
                {
                    CheckBox checkbox = this.groupBox1.Controls.Find("chkboxPause" + light[0], true).FirstOrDefault() as CheckBox;
                    if (checkbox.Checked == true)
                    {
                        int i = Convert.ToInt32(light[0]);
                        int methods = TelldusAPI.tdMethods(i, TelldusAPI.TELLSTICK_TURNON | TelldusAPI.TELLSTICK_DIM);
                        if (methods == TelldusAPI.TELLSTICK_DIM | methods == TelldusAPI.TELLSTICK_DIM + TelldusAPI.TELLSTICK_TURNON)
                        {
                            if (DimlevelPause == 0)
                                TelldusAPI.tdTurnOff(i);
                            else if (DimlevelPause == 255)
                                TelldusAPI.tdTurnOn(i);
                            else
                                TelldusAPI.tdDim(i, DimlevelPause);
                        }
                        else
                            TelldusAPI.tdTurnOn(i);
                    }
                }
            }
            catch
            {
                
            }
            lightFinishedUpdated = true;
        }

        public void playingstate()
        {
            lightFinishedUpdated = false;
            try
            {
                foreach (int[] light in allLights)
                {
                    CheckBox checkbox = this.groupBox1.Controls.Find("chkboxPlay" + light[0], true).FirstOrDefault() as CheckBox;
                    if (checkbox.Checked == true)
                    {
                        int i = Convert.ToInt32(light[0]);
                        int methods = TelldusAPI.tdMethods(i, TelldusAPI.TELLSTICK_TURNON | TelldusAPI.TELLSTICK_DIM);
                        if (methods == TelldusAPI.TELLSTICK_DIM | methods == TelldusAPI.TELLSTICK_DIM + TelldusAPI.TELLSTICK_TURNON)
                        {
                            if (DimlevelPlay == 0)
                                TelldusAPI.tdTurnOff(i);
                            else if (DimlevelPlay == 255)
                                TelldusAPI.tdTurnOn(i);
                            else
                                TelldusAPI.tdDim(i, DimlevelPlay);
                        }
                        else
                            TelldusAPI.tdTurnOff(i);
                    }
                }
            }
            catch
            {
                
            }
            lightFinishedUpdated = true;
        }

        public void load()
        {
            loading = true;
            int intNumberOfDevices = TelldusAPI.tdGetNumberOfDevices();
            int dynamicHeight = 36;
            allLights.Clear();
            lights.Clear();
            lightProcess = new Thread(stoppedstate);
            for (int i = 0; i < intNumberOfDevices; i++)
            {
                int id = TelldusAPI.tdGetDeviceId(i);
                string name = TelldusAPI.tdGetNameString(id);
                int methods = TelldusAPI.tdMethods(id, TelldusAPI.TELLSTICK_TURNON | TelldusAPI.TELLSTICK_TURNOFF | TelldusAPI.TELLSTICK_DIM);
                int[] arr = new int[2] { id, methods };
                allLights.Add(arr);
                //Generate label, checkboxes and lines
                if (methods == 16 || methods == 17 || methods == 18 || methods == 19)
                    name = name + " [dimmable]";
                System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
                lbl.Location = new System.Drawing.Point(6, dynamicHeight + (i * 20));
                lbl.Name = "lblLight_" + id.ToString();
                lbl.Size = new System.Drawing.Size(165, 14);
                lbl.TabIndex = 7;
                lbl.Text = name;
                // 
                // chkboxPlay
                //
                System.Windows.Forms.CheckBox chkboxPlay = new System.Windows.Forms.CheckBox();
                chkboxPlay.AutoSize = true;
                chkboxPlay.Location = new System.Drawing.Point(177, dynamicHeight + (i * 20));
                chkboxPlay.Name = "chkboxPlay" + id.ToString();
                chkboxPlay.Size = new System.Drawing.Size(15, 14);
                chkboxPlay.TabIndex = 1 + (i * 3);
                chkboxPlay.UseVisualStyleBackColor = true;
                chkboxPlay.CheckedChanged += new System.EventHandler(this.checkBoxChangedSave);
                // 
                // chkboxPause
                // 
                System.Windows.Forms.CheckBox chkboxPause = new System.Windows.Forms.CheckBox();
                chkboxPause.AutoSize = true;
                chkboxPause.Location = new System.Drawing.Point(213, dynamicHeight + (i * 20));
                chkboxPause.Name = "chkboxPause" + id.ToString();
                chkboxPause.Size = new System.Drawing.Size(15, 14);
                chkboxPause.TabIndex = 2 + (i * 3);
                chkboxPause.UseVisualStyleBackColor = true;
                chkboxPause.CheckedChanged += new System.EventHandler(this.checkBoxChangedSave);
                //
                // chkboxStop
                // 
                System.Windows.Forms.CheckBox chkboxStop = new System.Windows.Forms.CheckBox();
                chkboxStop.AutoSize = true;
                chkboxStop.Location = new System.Drawing.Point(253, dynamicHeight + (i * 20));
                chkboxStop.Name = "chkboxStop" + id.ToString();
                chkboxStop.Size = new System.Drawing.Size(15, 14);
                chkboxStop.TabIndex = 3 + (i * 3);
                chkboxStop.UseVisualStyleBackColor = true;
                chkboxStop.CheckedChanged += new System.EventHandler(this.checkBoxChangedSave);

                this.groupBox1.Controls.Add(lbl);
                this.groupBox1.Controls.Add(chkboxPlay);
                this.groupBox1.Controls.Add(chkboxPause);
                this.groupBox1.Controls.Add(chkboxStop);
            }

            using (StreamReader sr = new StreamReader(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + "settings.ini"))
            {
                Version = sr.ReadLine();
                Ip = sr.ReadLine();
                if (Version == "10")
                {
                    Port = sr.ReadLine();
                    User = sr.ReadLine();
                    Password = sr.ReadLine();
                }
                else
                    Port = "9090";
                

                //
                // Read values for dimlevel. Telldus API requires values from 0 to 255.
                // Values in config is stored in values from 0 to 100. Therefore multiply by 2.55
                //

                try
                {
                    DimlevelPause = Convert.ToInt32(int.Parse(sr.ReadLine()) * 2.55);
                }
                catch
                {
                    DimlevelPause = Convert.ToInt32(50 * 2.55);
                }
                try
                {
                    DimlevelPlay = Convert.ToInt32(int.Parse(sr.ReadLine()) * 2.55);
                }
                catch
                {
                    DimlevelPlay = Convert.ToInt32(50 * 2.55);
                }
                try
                {
                    DimlevelStop = Convert.ToInt32(int.Parse(sr.ReadLine()) * 2.55);
                }
                catch
                {
                    DimlevelStop = Convert.ToInt32(50 * 2.55);
                }

                sr.Close();
            }

            using (StreamReader sr = new StreamReader(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + "lights.ini"))
            {
                while (sr.Peek() != -1)
                {
                    string tempLine = sr.ReadLine().Trim();
                    if (tempLine != "")
                    {
                        try
                        {
                            string[] line = tempLine.Split(',');
                            var play = this.Controls.Find("chkboxPlay" + line[0], true).FirstOrDefault();
                            var pause = this.Controls.Find("chkboxPause" + line[0], true).FirstOrDefault();
                            var stop = this.Controls.Find("chkboxStop" + line[0], true).FirstOrDefault();
                            if (play != null && pause != null && stop != null)
                            {
                                CheckBox checkPlay = play as CheckBox;
                                CheckBox checkPause = pause as CheckBox;
                                CheckBox checkStop = stop as CheckBox;
                                if (int.Parse(line[1]) == 1)
                                    checkPlay.Checked = true;
                                if (int.Parse(line[2]) == 1)
                                    checkPause.Checked = true;
                                if (int.Parse(line[3]) == 1)
                                    checkStop.Checked = true;
                            }
                        }
                        catch(Exception e)
                        {
                            MessageBox.Show(e.ToString());
                            MessageBox.Show("Failure while reading lights.ini, please edit lightsources");
                            load();
                            return;
                        }
                    }
                }
                sr.Close();
            }

            if (Ip == null || Port == null)
            {
                if (settingsread)
                {
                    this.Close();
                    return;
                }
                else
                {
                    Settings set = new Settings();
                    set.ShowDialog();
                    settingsread = true;
                    set.Dispose();
                    load();
                    return;
                }
            }
            else
            {
                if (Version == "10")
                {
                    Xbmc = new XbmcConnection(Ip, Convert.ToInt32(Port), User, Password);

                    UpdateTimerOne.Interval = 1000;
                    UpdateTimerOne.Tick += new EventHandler(UpdateTimerOne_Tick);
                    UpdateTimerOne.Start();
                    UpdateTimerLights.Interval = 1000;
                    UpdateTimerLights.Tick += new EventHandler(UpdateTimerLights_Tick);
                    UpdateTimerLights.Start();
                    UpdateTimerTen.Interval = 10000;
                    UpdateTimerTen.Tick += new EventHandler(UpdateTimerTen_Tick);
                    UpdateTimerTen.Start();

                    if (Xbmc.Status.IsConnected)
                    {
                        lblConnected.Text = "Connected";
                        lblConnected.ForeColor = System.Drawing.Color.Green;
                    }
                }
                else //Since not version 10, it must be 11 (Eden)!
                {
                    new Thread(eden).Start();
                    UpdateTimerLights.Interval = 1000;
                    UpdateTimerLights.Tick += new EventHandler(UpdateTimerLights_Tick);
                    UpdateTimerLights.Start();
                }
                
            }
            loading = false;
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            load();   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            playingstate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pausestate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stoppedstate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Settings set = new Settings();
            set.ShowDialog();
            load();
        }

        private void notifyIconTextChange(string newtext) {
            notifyIcon.Text = "XBMC Light Updater\r\nXBMC Videostate: " + newtext;
        }

        private void MainView_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon.Visible = true;
                Hide();
                notifyIcon.BalloonTipTitle = "XBMC Light Controller Hidden";
                notifyIcon.BalloonTipText = "The application has been minimized to the taskbar.\r\nDouble click to show application.";
                notifyIcon.ShowBalloonTip(3000);
            }
            if (WindowState == FormWindowState.Normal)
                notifyIcon.Visible = false;
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void checkBoxChangedSave(object sender, EventArgs e)
        {
            if (loading == false)
            {
                button5.Enabled = true;
                button5.Text = "Save!";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (loading == false)
            {
                using (StreamWriter sw = new StreamWriter(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + "lights.ini", false))
                {
                    foreach (int[] light in allLights)
                    {
                        string line = light[0].ToString();
                        bool write = false;
                        CheckBox play = this.groupBox1.Controls.Find("chkboxPlay" + light[0], true).FirstOrDefault() as CheckBox;
                        if (play.Checked == true)
                        {
                            line += ",1";
                            write = true;
                        }
                        else
                            line += ",0";
                        CheckBox pause = this.groupBox1.Controls.Find("chkboxPause" + light[0], true).FirstOrDefault() as CheckBox;
                        if (pause.Checked == true)
                        {
                            line += ",1";
                            write = true;
                        }
                        else
                            line += ",0";
                        CheckBox stop = this.groupBox1.Controls.Find("chkboxStop" + light[0], true).FirstOrDefault() as CheckBox;
                        if (stop.Checked == true)
                        {
                            line += ",1";
                            write = true;
                        }
                        else
                            line += ",0";
                        if (write)
                            sw.WriteLine(line);
                    }
                   
                    sw.Close();
                }
            }
            button5.Enabled = false;
            button5.Text = "Saved..";
        }
        
        void eden()
        {
            Thread lightProcess = new Thread(stoppedstate);
            while (true)
            {
                try
                {
                    TcpClient tcpclient = new TcpClient(Ip, 9090);
                    NetworkStream netStream = tcpclient.GetStream();
                    labelConnectedChange("Connected", System.Drawing.Color.Green);
                    string continuedResponse;
                    string response = GetResponse(netStream, out continuedResponse);
                    if (response.IndexOf("movie") != -1 || response.IndexOf("episode") != -1)
                    {
                        if (response.IndexOf("OnPlay") != -1)
                        {
                            labelStateChange("playing");
                            tempvideoState = "playing";
                        }
                        if (response.IndexOf("OnPause") != -1)
                        {
                            labelStateChange("paused");
                            tempvideoState = "paused";
                        }
                        if (response.IndexOf("OnStop") != -1)
                        {
                            labelStateChange("stopped");
                            tempvideoState = "stopped";
                        }


                    }
                }
                catch
                {
                    labelConnectedChange("Disconnected", System.Drawing.Color.Red);
                }
            }
        }

        void labelConnectedChange(string title, Color color)
        {
            if (this.lblConnected.InvokeRequired)
            {
                this.lblConnected.Invoke(new MethodInvoker(delegate
                {
                    lblConnected.Text = title;
                    lblConnected.ForeColor = color;
                }));
            }
        }
        
        void labelStateChange(string title)
        {
            if (this.lblVideoState.InvokeRequired)
            {
                this.lblVideoState.Invoke(new MethodInvoker(delegate
                {
                    lblVideoState.Text = title;
                }));
            }
        }
        
        private static string GetResponse(NetworkStream stream, out string response)
        {
            byte[] readBuffer = new byte[32];
            var asyncReader = stream.BeginRead(readBuffer, 0, readBuffer.Length, null, null);
            WaitHandle handle = asyncReader.AsyncWaitHandle;

            // Give the reader 2seconds to respond with a value
            bool completed = handle.WaitOne(1000, false);
            if (completed)
            {
                int bytesRead = stream.EndRead(asyncReader);

                StringBuilder message = new StringBuilder();
                message.Append(Encoding.ASCII.GetString(readBuffer, 0, bytesRead));

                if (bytesRead == readBuffer.Length)
                {
                    // There's possibly more than 32 bytes to read, so get the next 
                    // section of the response
                    string continuedResponse;
                    if (GetResponse(stream, out continuedResponse) != "")
                    {
                        message.Append(continuedResponse);
                    }
                }

                response = message.ToString();
                return response;
            }
            else
            {
                int bytesRead = stream.EndRead(asyncReader);
                if (bytesRead == 0)
                {
                    // 0 bytes were returned, so the read has finished
                    response = string.Empty;
                    return response;
                }
                else
                {
                    StringBuilder message = new StringBuilder();
                    message.Append(Encoding.ASCII.GetString(readBuffer, 0, bytesRead));

                    if (bytesRead == readBuffer.Length)
                    {
                        // There's possibly more than 32 bytes to read, so get the next 
                        // section of the response
                        string continuedResponse;
                        if (GetResponse(stream, out continuedResponse) != "")
                        {
                            message.Append(continuedResponse);
                        }
                    }

                    response = message.ToString();
                    return response;
                }
            }
        }
    }

    public class TelldusAPI
    {
        public static int TELLSTICK_TURNON = 1;
        public static int TELLSTICK_TURNOFF = 2;
        public static int TELLSTICK_DIM = 16;

        [DllImport("TelldusCore.dll")]
        public static extern void tdClose();

        [DllImport("TelldusCore.dll")]
        public static extern int tdGetNumberOfDevices();

        [DllImport("TelldusCore.dll")]
        public static extern int tdTurnOn(int intDeviceId);

        [DllImport("TelldusCore.dll")]
        public static extern int tdTurnOff(int intDeviceId);

        [DllImport("TelldusCore.dll")]
        public static extern int tdMethods(int id, int methodsSupported);

        [DllImport("TelldusCore.dll")]
        public static extern int tdGetDeviceId(int intDeviceIndex);

        [DllImport("TelldusCore.dll")]
        public static extern int tdDim(int intDeviceId, int level);

        [DllImport("TelldusCore.dll")]
        private static extern IntPtr tdGetName(int intDeviceId);

        public static string tdGetNameString(int intDeviceId)
        {
            return Marshal.PtrToStringAnsi(tdGetName(intDeviceId));
        }
    }
}
