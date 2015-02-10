using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Collections;


namespace Cyko
{
     public partial class Form1 : Form
     {
         int i, numQueue;
          string cmdlet;
          bool running;
          int resmode;
          Encode encode;

          BindingList<EncodeItem> encodeItem;

          public Form1()
          {
               InitializeComponent();
               encode = new Encode();
               encodeItem = encode.encodeList;
          }

          private void Form1_Load(object sender, EventArgs e)
          {
               cboMode.SelectedIndex = s_Setting.mode;
               cboPresets.SelectedIndex = s_Setting.preset;
               cboTunes.SelectedIndex = s_Setting.tune;
               cboProfiles.SelectedIndex = s_Setting.profile;

               resmode = s_Setting.resMode;
               txtResolution.Text = s_Setting.resolution.ToString();
               txtVideoValue.Text = s_Setting.vquality.ToString();

               txtAudioValue.Value = s_Setting.audioBitrate;

               chkDenoise.Checked = s_Setting.denoise;

               i = 0;
               this.listAdd.AllowDrop = true;
               //this.AllowDrop = true;
               this.listAdd.DragEnter += listAdd_DragEnter;
               this.listAdd.DragDrop += listAdd_DragDrop;

               resmode = 0;

               string exePath = Application.StartupPath;
               txtOutput.Text = exePath;

               progressBar1.Maximum = 10000;

               listOut.DataSource = encode.encodeList;
               listOut.DisplayMember = "argument";
               listOut.ValueMember = "argument";

          }

          private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
          {

          }

          private void btnRemove_Click(object sender, EventArgs e)
          {
               if (listOut.SelectedItem != null)
                    listOut.Items.Remove(listOut.SelectedItem.ToString());
          }

          private void btnClear_Click(object sender, EventArgs e)
          {
               listOut.Items.Clear();
          }

          private void tglResolution_Click(object sender, EventArgs e)
          {
               if (tglResolution.Text == "Height")
               {
                    tglResolution.Text = "Width";
                    resmode = 1;
               }
               else
               {
                    tglResolution.Text = "Height";
                    resmode = 0;
               }
               s_Setting.resMode = resmode;
          }

          private void tmrEncodeTimer_Tick(object sender, EventArgs e)
          {
               int a = i + 1;
               txtOut.Text = "Encoding: " + a.ToString() + " of " + listOut.Items.Count.ToString() + ".";
          }

          private void button3_Click(object sender, EventArgs e)
          {
               //tmrEncodeTimer.Enabled = true;
          }

          private void cboMode_SelectedIndexChanged(object sender, EventArgs e)
          {
               switchMode();

               txtVideoValue.Focus();
          }

          private void switchMode()
          {
              if (cboMode.SelectedIndex == 0)
              {
                  txtVideoValue.MaxLength = 2;
                  txtVideoValue.Text = "23";
              }
              else
              {
                  txtVideoValue.MaxLength = 4;
                  txtVideoValue.Text = "1000";
              }
              s_Setting.mode = cboMode.SelectedIndex;
              s_Setting.vquality = Convert.ToInt32(txtVideoValue.Text);
          }

          public int getQueueNum()
          {
               return listAdd.Items.Count;
          }

          public bool checkDenoise()
          {
               if (chkDenoise.Checked == true)
                    return true;
               return false;
          }

          public bool checkHardSub()
          {
               if (chkHardSubs.Checked == true)
                    return true;
               return false;
          }

          private void btnEnqueue_Click(object sender, EventArgs e)
          {
               int max = listAdd.Items.Count;
               int crf;

               if (cboMode.Text == "Target Quality")
               {

                    crf = Convert.ToInt32(txtVideoValue.Text);
                    if (crf < 10 || crf > 30)
                    {
                         MessageBox.Show("CRF must be between 10 and 30", "Error");
                         txtVideoValue.Focus();
                         return;
                    }
               }

               int ii;

               for (ii = 0; ii < max; ii++)
               {
                   encodeItem.Add(new EncodeItem(listAdd.Items[0].ToString(), txtOutput.Text));
                    //listOut.Items.Add(encode.ToString());
                    listAdd.Items.RemoveAt(0);                    
                    //MessageBox.Show(encode.ToString());
               }

          }

          private void listAdd_DragEnter(object sender, DragEventArgs e)
          {
               if (e.Data.GetDataPresent(DataFormats.FileDrop))
               {
                    e.Effect = DragDropEffects.Copy;
               }
               else
               {
                    e.Effect = DragDropEffects.None;
               }
          }

          private void listAdd_DragDrop(object sender, DragEventArgs e)
          {
               //string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
               if (e.Data.GetDataPresent(DataFormats.FileDrop))
               {
                    string[] filePaths = (string[])(e.Data.GetData(DataFormats.FileDrop));
                    foreach (string fileLoc in filePaths)
                    {
                         // Code to read the contents of the text file
                         listAdd.Items.Add(fileLoc);

                    }
               }
          }

          private void button1_Click(object sender, EventArgs e)
          {
               DialogResult result = folderBrowserDialog1.ShowDialog();
               if (result == DialogResult.OK)
               {
                    txtOutput.Text = folderBrowserDialog1.SelectedPath;
               }
          }

          private void button2_Click(object sender, EventArgs e)
          {
               DialogResult result = openFileDialog1.ShowDialog();
               if (result == DialogResult.OK)
                    listAdd.Items.Add(openFileDialog1.FileName);
          }

          void RunWithRedirect(string cmdPath)
          {
               var proc = new Process();
               proc.StartInfo.FileName = "handbrakeCli.exe";
               proc.StartInfo.Arguments = cmdPath;
               //proc.StartInfo.RedirectStandardOutput = false;
               // set up output redirection
               proc.StartInfo.UseShellExecute = false;
               proc.StartInfo.RedirectStandardOutput = true;
               //proc.StartInfo.RedirectStandardError = true;
               proc.EnableRaisingEvents = true;
               proc.StartInfo.CreateNoWindow = true;

               // see below for output handler
               //proc.ErrorDataReceived += proc_DataReceived;
               //proc.OutputDataReceived += proc_DataReceived;

               proc.Start();

               //proc.BeginErrorReadLine();

               proc.BeginOutputReadLine();

               //proc.WaitForExit();
          }

          void proc_DataReceived(object sender, DataReceivedEventArgs e)
          {

               // output will be in string e.Data

               //edit_txtout(e.Data);
               //txtOut.Text = data2;
          }

          

          private void btnEncode_Click(object sender, EventArgs e)
          {
               numQueue = listOut.Items.Count;
               btnEncode.Enabled = false;
               encode.start();
               //runHandbrake();
          }

          private void btnAbort_Click(object sender, EventArgs e)
          {
               abortEncode();
               
               btnAbort.Enabled = false;
               if (listOut.Items.Count != 0)
                    btnEncode.Enabled = true;
          }

          void abortEncode()
          {
               if (encode.isRunning())
               {
                    encode.stop();
               }
          }

          protected override void OnFormClosing(FormClosingEventArgs e)
          {
               base.OnFormClosing(e);
               if (e.CloseReason == CloseReason.WindowsShutDown) return;

               abortEncode();
          }

          private void listAdd_SelectedIndexChanged(object sender, EventArgs e)
          {
               /*
               if (listAdd.SelectedIndex == -1)
               {
                    menu1.Items[0].Enabled = false;
                    menu1.Items[1].Enabled = false;
               }
               else
               {
                    menu1.Items[0].Enabled = true;
                    menu1.Items[1].Enabled = true;
               }
               */
          }

          private void cboPresets_SelectedIndexChanged(object sender, EventArgs e)
          {
              s_Setting.setPreset(cboPresets.SelectedIndex);
          }

          private void txtAudioValue_ValueChanged(object sender, EventArgs e)
          {
              s_Setting.audioBitrate = Convert.ToInt32(txtAudioValue.Value);
          }

          private void chkHardSubs_CheckedChanged(object sender, EventArgs e)
          {
              s_Setting.hardsubs = chkHardSubs.Checked;
          }

          private void chkDenoise_CheckedChanged(object sender, EventArgs e)
          {
              s_Setting.denoise = chkDenoise.Checked;
          }

          public string message
          {
              get { return txtOut.Text; }
              set { txtOut.Text = value; }
          }

          public int progress
          {
              get { return progressBar1.Value; }
              set { progressBar1.Value = value; }
          }

          public int num
          {
              get { return listOut.Items.Count; }
          }

          public string fileToEncode
          {
              get { return listOut.Items[0].ToString(); }
          }

          

          

          /*
          private delegate void DataRead(string data);
          private static event DataRead OnDataRead;

          static void test(string testing)
          {
               OnDataRead += data => setout(data != null ? data : "Program finished");  //MessageBox.Show(data != null ? data : "Program finished");
               Thread readingThread = new Thread(Read);
               ProcessStartInfo info = new ProcessStartInfo()
               {
                    FileName = "handbrakeCli.exe",
                    Arguments = testing,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
               };
               //using (Process process = Process.Start(info))
               {
                    Process process = Process.Start(info);
                    readingThread.Start(process);
                    process.WaitForExit();
               }
               readingThread.Join();
          }

          private static void setout(string test)
          {
               //txtOut.Text = test;
          }

          private static void Read(object parameter)
          {
               Process process = parameter as Process;
               char[] buffer = new char[1024];
               int read = 1;
               while (read > 0)
               {
                    read = process.StandardOutput.Read(buffer, 0, buffer.Length);
                    string data = read > 0 ? new string(buffer, 0, read) : null;
                    if (OnDataRead != null) OnDataRead(data);
               }
          }

          */

          /*
          public class ConsoleInputReadEventArgs : EventArgs
          {
               public ConsoleInputReadEventArgs(string input)
               {
                    this.Input = input;
               }

               public string Input { get; private set; }
          }

          public interface IConsoleAutomator
          {
               StreamWriter StandardInput { get; }

               event EventHandler<ConsoleInputReadEventArgs> StandardInputRead;
          }

          public abstract class ConsoleAutomatorBase : IConsoleAutomator
          {
               protected readonly StringBuilder inputAccumulator = new StringBuilder();

               protected readonly byte[] buffer = new byte[256];

               protected volatile bool stopAutomation;

               public StreamWriter StandardInput { get; protected set; }

               protected StreamReader StandardOutput { get; set; }

               protected StreamReader StandardError { get; set; }

               public event EventHandler<ConsoleInputReadEventArgs> StandardInputRead;

               protected void BeginReadAsync()
               {
                    if (!this.stopAutomation)
                    {
                         this.StandardOutput.BaseStream.BeginRead(this.buffer, 0, this.buffer.Length, this.ReadHappened, null);
                    }
               }

               protected virtual void OnAutomationStopped()
               {
                    this.stopAutomation = true;
                    this.StandardOutput.DiscardBufferedData();
               }

               private void ReadHappened(IAsyncResult asyncResult)
               {
                    var bytesRead = this.StandardOutput.BaseStream.EndRead(asyncResult);
                    if (bytesRead == 0)
                    {
                         this.OnAutomationStopped();
                         return;
                    }

                    var input = this.StandardOutput.CurrentEncoding.GetString(this.buffer, 0, bytesRead);
                    this.inputAccumulator.Append(input);

                    if (bytesRead < this.buffer.Length)
                    {
                         this.OnInputRead(this.inputAccumulator.ToString());
                    }

                    this.BeginReadAsync();
               }

               private void OnInputRead(string input)
               {
                    var handler = this.StandardInputRead;
                    if (handler == null)
                    {
                         return;
                    }

                    handler(this, new ConsoleInputReadEventArgs(input));
                    this.inputAccumulator.Clear();
               }
          }

          public class ConsoleAutomator : ConsoleAutomatorBase, IConsoleAutomator
          {
               public ConsoleAutomator(StreamWriter standardInput, StreamReader standardOutput)
               {
                    this.StandardInput = standardInput;
                    this.StandardOutput = standardOutput;
               }

               public void StartAutomate()
               {
                    this.stopAutomation = false;
                    this.BeginReadAsync();
               }

               public void StopAutomation()
               {
                    this.OnAutomationStopped();
               }
          }

          */

          

     }

}


