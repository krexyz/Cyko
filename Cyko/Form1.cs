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


namespace Cyko
{
     public partial class Form1 : Form
     {
          Encode encode;
          int i, numQueue, num;
          string cmdlet;
          bool running;
          int resmode;

          public Form1()
          {
               InitializeComponent();
          }

          private void Form1_Load(object sender, EventArgs e)
          {
               //cboMode.Text = "Target Quality";
               cboMode.SelectedIndex = 0;
               //cboPresets.Text = "Medium";
               cboPresets.SelectedIndex = 5;
               //cboTunes.Text = "Animation";
               cboTunes.SelectedIndex = 1;
               //cboProfiles.Text = "High";
               cboProfiles.SelectedIndex = 2;
               i = 0;
               this.listAdd.AllowDrop = true;
               //this.AllowDrop = true;
               this.listAdd.DragEnter += listAdd_DragEnter;
               this.listAdd.DragDrop += listAdd_DragDrop;

               resmode = 0;

               string exePath = Application.StartupPath;
               txtOutput.Text = exePath;

               encode = new Encode();

               encode.p.OutputDataReceived += p_DataReceived;
               encode.p.Exited += new EventHandler(p_Exited);

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
               if (cboMode.Text == "Target Quality")
               {
                    txtVideoValue.MaxLength = 2;
                    txtVideoValue.Text = "23";
               }
               else
               {
                    txtVideoValue.MaxLength = 4;
                    txtVideoValue.Text = "1000";
               }

               txtVideoValue.Focus();
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

               Settings setting;
               EncodeItem encode;

               setting = new Settings();

               setting.setMode(cboMode.SelectedIndex, Convert.ToInt32(txtVideoValue.Text));
               setting.setPreset(cboPresets.SelectedIndex);
               setting.setTunes(cboTunes.SelectedIndex);
               setting.setProfile(cboProfiles.SelectedIndex);

               setting.setPicSetting(Convert.ToInt32(txtResolution.Text), 
                    resmode, checkDenoise(), checkHardSub());

               setting.setAudio(Convert.ToInt32(txtAudioValue.Value));

               int ii;

               for (ii = 0; ii < max; ii++)
               {
                    encode = new EncodeItem(listAdd.Items[0].ToString(), txtOutput.Text, setting);
                    encode.processArg();
                    listOut.Items.Add(encode.ToString());
                    listAdd.Items.RemoveAt(0);

                    //MessageBox.Show(encode.ToString());
               }
               /*
               int max = listAdd.Items.Count;
               int crf, audioBitrate;
               int ii;
               string mode, x264, resolution, subs, containerstring;

               for (ii = 0; ii < max; ii++)
               {

                    if (cboMode.Text == "Target Quality")
                    {

                         crf = Convert.ToInt32(txtVideoValue.Text);
                         if (crf < 10 || crf > 30)
                         {
                              MessageBox.Show("CRF must be between 10 and 30", "Error");
                              txtVideoValue.Focus();
                              return;
                         }
                         mode = "-q " + txtVideoValue.Text;
                    }
                    else
                         mode = "-2 -T -b ";

                    audioBitrate = Convert.ToInt32(txtAudioValue.Value);

                    if (tglResolution.Text == "Height")
                         resolution = " -l " + txtResolution.Text;
                    else
                         resolution = " -w " + txtResolution.Text;

                    
                    int index = cboPresets.SelectedIndex;

                    x264 = "-e x264 ";

                    switch (index)
                    {
                         case 0: x264 += "--x264-preset ultrafast";
                              break;
                         case 1: x264 += "--x264-preset superfast";
                              break;
                         case 2: x264 += "--x264-preset veryfast";
                              break;
                         case 3: x264 += "--x264-preset faster";
                              break;
                         case 4: x264 += "--x264-preset fast";
                              break;
                         case 5: x264 += "--x264-preset medium";
                              break;
                         case 6: x264 += "--x264-preset slow";
                              break;
                         case 7: x264 += "--x264-preset slower";
                              break;
                         case 8: x264 += "--x264-preset veryslow";
                              break;
                         case 9: x264 += "--x264-preset placebo";
                              break;
                    }

                    index = cboTunes.SelectedIndex;

                    switch (index)
                    {
                         case 0: x264 += " --x264-tune film";
                              break;
                         case 1: x264 += " --x264-tune animation";
                              break;
                         case 2: x264 += " --x264-tune grain";
                              break;
                         case 3: x264 += " --x264-tune stillimage";
                              break;
                         case 4: x264 += " --x264-tune psnr";
                              break;
                         case 5: x264 += " --x264-tune ssim";
                              break;
                         case 6: x264 += " --x264-tune fastdecode";
                              break;
                         case 7: x264 += " --x264-tune zerolatency";
                              break;
                    }

                    index = cboProfiles.SelectedIndex;

                    switch (index)
                    {
                         case 0: x264 += " --x264-profile baseline ";
                              break;
                         case 1: x264 += " --x264-profile main ";
                              break;
                         case 2: x264 += " --x264-profile high ";
                              break;
                    }
                    
                    if (chkDenoise.Checked == true)
                         x264 += "-x nr=1000 ";

                    if (chkHardSubs.Checked == true)
                    {
                         containerstring = "-out.mp4";
                         subs = " -s 1 --subtitle-burn ";
                    }
                    else
                    {
                         subs = " -s 1,2,3,4,5,6,7,8,9 --subtitle-default ";
                         containerstring = "-out.mkv";
                    }
                    

                    string filename = Path.GetFileNameWithoutExtension(listAdd.Items[0].ToString());
                    string inputstring = " -i \"" + listAdd.Items[0].ToString() + "\" ";
                    string outputstring = " -o \"" + txtOutput.Text + "\\" + filename + containerstring + "\" -m ";
                    string audiostring = "-E fdk_aac --mixdown stereo -B " + txtAudioValue.Value.ToString();
                    string intermediate = inputstring + outputstring + x264 + mode + resolution + subs + audiostring;
                    intermediate = intermediate.Replace(@"\\", @"\");

                    //MessageBox.Show(intermediate);

                    //tabControl1.SelectedIndex = 1;

                    listOut.Items.Add(intermediate);
                    listAdd.Items.RemoveAt(0);
                     
               }
               */

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

          
          /*private void txtAudioValue_KeyPress(object sender, EventArgs e)
          {
               if (txtAudioValue.Value > 320)
                    txtAudioValue.Value = 320;
          }*/


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
               num = 1;
               btnEncode.Enabled = false;
               runHandbrake();
          }

          private void runHandbrake()
          {
               cmdlet = listOut.Items[0].ToString();

               encode.p.SynchronizingObject = this;
               encode.p.StartInfo.Arguments = cmdlet;
               //encode.p.EnableRaisingEvents = true;

               running = true;

               encode.p.Start();
               encode.p.PriorityClass = ProcessPriorityClass.BelowNormal;
               encode.p.BeginOutputReadLine();
               
          }

          void p_DataReceived(object sender, DataReceivedEventArgs e)
          {
               //this.txtOut.Text = e.Data;
               double percentage;
               int percentage2;

               if (e.Data != null)
               {
                    string outredirect = e.Data;
                    if (outredirect.Length > 5)
                         if (outredirect.Substring(0, 4) == "Enco")
                         {
                              int index2 = outredirect.IndexOf(',');
                              int index = outredirect.IndexOf('%');
                              outredirect = outredirect.Substring(index2 + 1, index - index2 - 1);
                              outredirect = outredirect.Trim();
                              this.txtOut.Text = "Encoding File " + num + " out of " + numQueue + " : " + outredirect;
                              percentage = Convert.ToDouble(outredirect);
                              percentage2 = Convert.ToInt32(percentage * 100);
                              progressBar1.Maximum = 10000;
                              progressBar1.Value = percentage2;
                         }
               }
          }

          private void p_Exited(object sender, System.EventArgs e)
          {
               //Process proc = (Process)sender;

               // Wait a short while to allow all console output to be processed and appended
               // before appending the success/fail message.
               Thread.Sleep(200);
               encode.p.CancelOutputRead();

               if (encode.p.ExitCode == 0)
               {
                    listOut.Items.RemoveAt(0);

                    if (listOut.Items.Count == 0)
                    {
                         progressBar1.Value = 10000;
                         this.txtOut.Text = "Finished encoding " + numQueue + " files.";
                         MessageBox.Show("Encoding Finished");
                         progressBar1.Value = 0;
                         running = false;
                         btnEncode.Enabled = true;
                         btnAbort.Enabled = false;
                    }
                    else
                    {
                         this.txtOut.Text = "Encoding File " + num + " out of " + numQueue + " : 100.00";
                         num++;
                         runHandbrake();
                    }
               }
               else
               {
                    MessageBox.Show("Failed");
                    running = false;
                    btnEncode.Enabled = true;
                    btnAbort.Enabled = false;
               }

               //proc.Close();
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
               if (running == true)
               {
                    encode.p.Kill();
                    encode.p.CancelOutputRead();
                    this.txtOut.Text = "Encoding Aborted.";
                    MessageBox.Show("Encoding Aborted");
                    btnEncode.Enabled = true;
                    btnAbort.Enabled = false;
               }
               running = false;
          }

          protected override void OnFormClosing(FormClosingEventArgs e)
          {
               base.OnFormClosing(e);
               if (e.CloseReason == CloseReason.WindowsShutDown) return;

               abortEncode();
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


