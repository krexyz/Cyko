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
          int i;

          public Form1()
          {
               InitializeComponent();
          }

          

          private void Form1_Load(object sender, EventArgs e)
          {
               cboMode.Text = "Target Quality";
               cboPresets.Text = "Medium";
               cboTunes.Text = "Animation";
               cboProfiles.Text = "High";
               i = 0;
               this.listAdd.AllowDrop = true;
               //this.AllowDrop = true;
               this.listAdd.DragEnter += listAdd_DragEnter;
               this.listAdd.DragDrop += listAdd_DragDrop;

               string exePath = Application.StartupPath;
               txtOutput.Text = exePath;

               

                             
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
                    tglResolution.Text = "Width";
               else
                    tglResolution.Text = "Height";
          }

          private void tmrEncodeTimer_Tick(object sender, EventArgs e)
          {
               int a = i + 1;
               txtOut.Text = "Encoding: " + a.ToString() + " of " + listOut.Items.Count.ToString() + ".";
          }

          private void button3_Click(object sender, EventArgs e)
          {
               tmrEncodeTimer.Enabled = true;
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

          private void btnEnqueue_Click(object sender, EventArgs e)
          {
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

                    string filename = Path.GetFileNameWithoutExtension (listAdd.Items[0].ToString());
                    string inputstring =  " -i \"" + listAdd.Items[0].ToString() + "\" " ;
                    string outputstring = " -o \"" + txtOutput.Text + "\\" + filename + containerstring +"\" -m ";
                    string audiostring = "-E fdk_aac --mixdown stereo -B " + txtAudioValue.Value.ToString();
                    string intermediate = inputstring + outputstring + x264 + mode + resolution + subs + audiostring;
                    intermediate = intermediate.Replace(@"\\", @"\");
                    
                    

                    MessageBox.Show(intermediate);

                    //tabControl1.SelectedIndex = 1;

                    listOut.Items.Add(intermediate);
                    listAdd.Items.RemoveAt(0);

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
                         this.txtOut.Text = outredirect;
                         percentage = Convert.ToDouble(outredirect);
                         percentage2 = Convert.ToInt32(percentage);
                         progressBar1.Maximum = 100;
                         progressBar1.Value = percentage2;
                    }
               }
          }

          private void btnEncode_Click(object sender, EventArgs e)
          {
               string cmdlet = listOut.Items[0].ToString();
               Process p = new Process()
               {
                    StartInfo = new ProcessStartInfo()
                    {
                         FileName = "handbrakeCli.exe",
                         Arguments = cmdlet,
                         RedirectStandardOutput = true,
                         UseShellExecute = false,
                         CreateNoWindow = true,
                    },
                    EnableRaisingEvents = true,
                    SynchronizingObject = this
               };
               
               p.StartInfo.Arguments = cmdlet;
               p.OutputDataReceived += p_DataReceived;
               string outputredirect;
               p.Start();
               p.BeginOutputReadLine();
               p.Exited += new EventHandler(ProcExited);
               //test(cmdlet);


               //OnDataRead += data => this.txtOut.AppendText(data != null ? data : "Program finished"); /*Console.WriteLine*/ //MessageBox.Show(data != null ? data : "Program finished");
               /*
               Thread readingThread = new Thread(Read);
               FixedProcess p = new FixedProcess()
               {
                    StartInfo = new ProcessStartInfo()
                    {
                         FileName = "handbrakeCli.exe",
                         Arguments = cmdlet,
                         RedirectStandardOutput = true,
                         UseShellExecute = false,
                         CreateNoWindow = true,
                    },
                    EnableRaisingEvents = true,
                    SynchronizingObject = this
               };
               string outredirect;
               //string[] redirectstr;
               //int percentage;
               p.OutputDataReceived += (s, ea) =>
               {
                    outredirect = ea.Data;



                    if (outredirect.Length > 5)
                    {
                         if (outredirect.Substring(0, 4) == "Enco")
                         {
                              int index2 = outredirect.IndexOf(',');
                              int index = outredirect.IndexOf('%');
                              outredirect = outredirect.Substring(index2 + 1, index - index2 - 1);
                              outredirect = outredirect.Trim();
                              this.txtOut.Text = outredirect;
                              // percentage = Convert.ToInt32(outredirect);

                              //progressBar1.Maximum = 100;
                              //progressBar1.Step = percentage;
                         }
                    }
               };
                    
               
               p.Start();
               p.BeginOutputReadLine();
               */
               /*
               //using (Process process = Process.Start(info))
               {
                    Process process = Process.Start(info);
                    readingThread.Start(process);
                    process.WaitForExit();
               }
               readingThread.Join();
                */
               //RunWithRedirect(cmdlet);

               /*

               var processStartInfo = new ProcessStartInfo
               {
                    FileName = "HandbrakeCLI.exe",
                    Arguments = cmdlet,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
               };

               var process = Process.Start(processStartInfo);
               var automator  = new ConsoleAutomator(process.StandardInput, process.StandardOutput);
               
               automator.StandardInputRead += AutomatorStandardInputRead;
               automator.StartAutomate();

               process.WaitForExit();
               automator.StandardInputRead -= AutomatorStandardInputRead;
               process.Close();
               */


          }

          
          private delegate void DataRead(string data);
          private static event DataRead OnDataRead;

          static void test(string testing)
          {
               OnDataRead += data => setout(data != null ? data : "Program finished"); /*Console.WriteLine*/ //MessageBox.Show(data != null ? data : "Program finished");
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

          private void ProcExited(object sender, System.EventArgs e)
          {
               Process proc = (Process)sender;

               // Wait a short while to allow all console output to be processed and appended
               // before appending the success/fail message.
               Thread.Sleep(40);

               if (proc.ExitCode == 0)
               {
                    MessageBox.Show("Encoding Finished");
               }
               else
               {
                    MessageBox.Show("Failed");
               }

               proc.Close();
          }
          
          }

     }

   

