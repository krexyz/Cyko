using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Cyko
{
    class EncodeHelper
    {
        Form1 form1;
        Process p;
        static int num = 1;
        int total;

        float percentage;

        public void runHandbrake(string args, Form1 form1)
        {
            p = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "handbrakeCli.exe",
                    Arguments = "",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                },
                EnableRaisingEvents = true
            };

            this.form1 = form1;
            total = form1.num;

            p.OutputDataReceived += p_DataReceived;
            p.Exited += new EventHandler(p_Exited);

            p.SynchronizingObject = form1;
            p.StartInfo.Arguments = args;

            p.Start();
            p.PriorityClass = ProcessPriorityClass.BelowNormal;
            p.BeginOutputReadLine();
        }

        public void abort()
        {
            p.CancelOutputRead();
            deliverOutput("Encoding Aborted");
            p.Kill();
            p.Close();
        }

        private void dataInterpret(string data)
        {
            if (data.Length > 5)
                if (data.Substring(0, 4) == "Enco")
                {
                    int index2 = data.IndexOf(',');
                    int index = data.IndexOf('%');
                    data = data.Substring(index2 + 1, index - index2 - 1);
                    data = data.Trim();
                    percentage = (float)Convert.ToDouble(data);
                }
        }

        private void deliverOutput(string message)
        {
            float percentage = this.percentage;
            deliverOutput(message,percentage);
        }

        private void deliverOutput(string message, float percentage)
        {
            form1.progress = (int)percentage * 100;
            form1.message = message;
        }

        private void p_DataReceived(object sender, DataReceivedEventArgs e)
        {
            string output;

            if (e.Data != null)
            {
                dataInterpret(e.Data);
                output = "Encoding File " + num + " out of " + total + " : " + percentage + "%";
                deliverOutput(output);
            }
        }

        private void p_Exited(object sender, System.EventArgs e)
        {
            //Process proc = (Process)sender;

            // Wait a short while to allow all console output to be processed and appended
            // before appending the success/fail message.
            string output;
            p.CancelOutputRead();
            Thread.Sleep(100);
            
            if (p.ExitCode == 0)
            {
                // add code to remove item form ListOut at index 0

                if (form1.num == 0)
                {
                    form1.progress = 10000;
                    output = "Finished encoding " + total + " files.";
                    
                    form1.progress = 0;
                    //add code to reset button encode and abort
                    num = 1;
                }
                else
                {
                    output = "Encoding File " + num + " out of " + total + " : 100.00%";
                    num++;
                    GlobalVar.dela.Invoke();
                }
                deliverOutput(output, 100);
            }
            else
            {
                output = "Failed";
                deliverOutput(output, 0);
                //add code to reset button encoding and abort
            }
            p.Close();
            //proc.Close();
        }

    }
}
