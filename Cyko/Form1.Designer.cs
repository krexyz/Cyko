namespace Cyko
{
     partial class Form1
     {
          /// <summary>
          /// Required designer variable.
          /// </summary>
          private System.ComponentModel.IContainer components = null;

          /// <summary>
          /// Clean up any resources being used.
          /// </summary>
          /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
          protected override void Dispose(bool disposing)
          {
               if (disposing && (components != null))
               {
                    components.Dispose();
               }
               base.Dispose(disposing);
          }

          #region Windows Form Designer generated code

          /// <summary>
          /// Required method for Designer support - do not modify
          /// the contents of this method with the code editor.
          /// </summary>
          private void InitializeComponent()
          {
               this.components = new System.ComponentModel.Container();
               this.tabControl1 = new System.Windows.Forms.TabControl();
               this.tabInput = new System.Windows.Forms.TabPage();
               this.button3 = new System.Windows.Forms.Button();
               this.txtScanStatus = new System.Windows.Forms.TextBox();
               this.btnEnqueue = new System.Windows.Forms.Button();
               this.groupBox4 = new System.Windows.Forms.GroupBox();
               this.cboProfiles = new System.Windows.Forms.ComboBox();
               this.groupBox3 = new System.Windows.Forms.GroupBox();
               this.cboTunes = new System.Windows.Forms.ComboBox();
               this.groupBox2 = new System.Windows.Forms.GroupBox();
               this.cboPresets = new System.Windows.Forms.ComboBox();
               this.groupBox1 = new System.Windows.Forms.GroupBox();
               this.txtAudioValue = new System.Windows.Forms.NumericUpDown();
               this.chkDenoise = new System.Windows.Forms.CheckBox();
               this.chkHardSubs = new System.Windows.Forms.CheckBox();
               this.label4 = new System.Windows.Forms.Label();
               this.txtResolution = new System.Windows.Forms.TextBox();
               this.tglResolution = new System.Windows.Forms.Button();
               this.label3 = new System.Windows.Forms.Label();
               this.txtVideoValue = new System.Windows.Forms.TextBox();
               this.label2 = new System.Windows.Forms.Label();
               this.cboMode = new System.Windows.Forms.ComboBox();
               this.button2 = new System.Windows.Forms.Button();
               this.txtOutput = new System.Windows.Forms.TextBox();
               this.button1 = new System.Windows.Forms.Button();
               this.label1 = new System.Windows.Forms.Label();
               this.listAdd = new System.Windows.Forms.ListBox();
               this.tabQueue = new System.Windows.Forms.TabPage();
               this.txtOut = new System.Windows.Forms.TextBox();
               this.chkShutdown = new System.Windows.Forms.CheckBox();
               this.chkShowConsole = new System.Windows.Forms.CheckBox();
               this.btnAbort = new System.Windows.Forms.Button();
               this.btnClear = new System.Windows.Forms.Button();
               this.btnRemove = new System.Windows.Forms.Button();
               this.btnEncode = new System.Windows.Forms.Button();
               this.listOut = new System.Windows.Forms.ListBox();
               this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
               this.tmrEncodeTimer = new System.Windows.Forms.Timer(this.components);
               this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
               this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
               this.tabControl1.SuspendLayout();
               this.tabInput.SuspendLayout();
               this.groupBox4.SuspendLayout();
               this.groupBox3.SuspendLayout();
               this.groupBox2.SuspendLayout();
               this.groupBox1.SuspendLayout();
               ((System.ComponentModel.ISupportInitialize)(this.txtAudioValue)).BeginInit();
               this.tabQueue.SuspendLayout();
               this.SuspendLayout();
               // 
               // tabControl1
               // 
               this.tabControl1.Controls.Add(this.tabInput);
               this.tabControl1.Controls.Add(this.tabQueue);
               this.tabControl1.Location = new System.Drawing.Point(12, 12);
               this.tabControl1.Name = "tabControl1";
               this.tabControl1.SelectedIndex = 0;
               this.tabControl1.Size = new System.Drawing.Size(603, 406);
               this.tabControl1.TabIndex = 1;
               // 
               // tabInput
               // 
               this.tabInput.Controls.Add(this.button3);
               this.tabInput.Controls.Add(this.txtScanStatus);
               this.tabInput.Controls.Add(this.btnEnqueue);
               this.tabInput.Controls.Add(this.groupBox4);
               this.tabInput.Controls.Add(this.groupBox3);
               this.tabInput.Controls.Add(this.groupBox2);
               this.tabInput.Controls.Add(this.groupBox1);
               this.tabInput.Controls.Add(this.button2);
               this.tabInput.Controls.Add(this.txtOutput);
               this.tabInput.Controls.Add(this.button1);
               this.tabInput.Controls.Add(this.label1);
               this.tabInput.Controls.Add(this.listAdd);
               this.tabInput.Location = new System.Drawing.Point(4, 22);
               this.tabInput.Name = "tabInput";
               this.tabInput.Padding = new System.Windows.Forms.Padding(3);
               this.tabInput.Size = new System.Drawing.Size(595, 380);
               this.tabInput.TabIndex = 0;
               this.tabInput.Text = "Inputs";
               this.tabInput.UseVisualStyleBackColor = true;
               // 
               // button3
               // 
               this.button3.Location = new System.Drawing.Point(3, 359);
               this.button3.Name = "button3";
               this.button3.Size = new System.Drawing.Size(75, 23);
               this.button3.TabIndex = 8;
               this.button3.Text = "Testing";
               this.button3.UseVisualStyleBackColor = true;
               this.button3.Click += new System.EventHandler(this.button3_Click);
               // 
               // txtScanStatus
               // 
               this.txtScanStatus.Location = new System.Drawing.Point(18, 333);
               this.txtScanStatus.Name = "txtScanStatus";
               this.txtScanStatus.Size = new System.Drawing.Size(405, 20);
               this.txtScanStatus.TabIndex = 2;
               // 
               // btnEnqueue
               // 
               this.btnEnqueue.Location = new System.Drawing.Point(445, 319);
               this.btnEnqueue.Name = "btnEnqueue";
               this.btnEnqueue.Size = new System.Drawing.Size(126, 46);
               this.btnEnqueue.TabIndex = 7;
               this.btnEnqueue.Text = "Add to Queue";
               this.btnEnqueue.UseVisualStyleBackColor = true;
               this.btnEnqueue.Click += new System.EventHandler(this.btnEnqueue_Click);
               // 
               // groupBox4
               // 
               this.groupBox4.Controls.Add(this.cboProfiles);
               this.groupBox4.Location = new System.Drawing.Point(410, 268);
               this.groupBox4.Name = "groupBox4";
               this.groupBox4.Size = new System.Drawing.Size(179, 45);
               this.groupBox4.TabIndex = 6;
               this.groupBox4.TabStop = false;
               this.groupBox4.Text = "Profiles";
               // 
               // cboProfiles
               // 
               this.cboProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
               this.cboProfiles.FormattingEnabled = true;
               this.cboProfiles.Items.AddRange(new object[] {
            "Baseline",
            "Main",
            "High"});
               this.cboProfiles.Location = new System.Drawing.Point(18, 18);
               this.cboProfiles.Name = "cboProfiles";
               this.cboProfiles.Size = new System.Drawing.Size(143, 21);
               this.cboProfiles.TabIndex = 0;
               // 
               // groupBox3
               // 
               this.groupBox3.Controls.Add(this.cboTunes);
               this.groupBox3.Location = new System.Drawing.Point(209, 268);
               this.groupBox3.Name = "groupBox3";
               this.groupBox3.Size = new System.Drawing.Size(179, 45);
               this.groupBox3.TabIndex = 1;
               this.groupBox3.TabStop = false;
               this.groupBox3.Text = "Tunes";
               // 
               // cboTunes
               // 
               this.cboTunes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
               this.cboTunes.FormattingEnabled = true;
               this.cboTunes.Items.AddRange(new object[] {
            "Film",
            "Animation",
            "Grain",
            "Still Image",
            "PSNR",
            "SSIM",
            "Fast Decode",
            "Zero Latency"});
               this.cboTunes.Location = new System.Drawing.Point(18, 18);
               this.cboTunes.Name = "cboTunes";
               this.cboTunes.Size = new System.Drawing.Size(143, 21);
               this.cboTunes.TabIndex = 0;
               this.cboTunes.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
               // 
               // groupBox2
               // 
               this.groupBox2.Controls.Add(this.cboPresets);
               this.groupBox2.Location = new System.Drawing.Point(9, 268);
               this.groupBox2.Name = "groupBox2";
               this.groupBox2.Size = new System.Drawing.Size(179, 45);
               this.groupBox2.TabIndex = 0;
               this.groupBox2.TabStop = false;
               this.groupBox2.Text = "Presets";
               // 
               // cboPresets
               // 
               this.cboPresets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
               this.cboPresets.FormattingEnabled = true;
               this.cboPresets.Items.AddRange(new object[] {
            "Ultra Fast",
            "Super Fast",
            "Very Fast",
            "Faster",
            "Fast",
            "Medium",
            "Slow",
            "Slower",
            "Very Slow",
            "Placebo"});
               this.cboPresets.Location = new System.Drawing.Point(18, 18);
               this.cboPresets.Name = "cboPresets";
               this.cboPresets.Size = new System.Drawing.Size(143, 21);
               this.cboPresets.TabIndex = 0;
               // 
               // groupBox1
               // 
               this.groupBox1.Controls.Add(this.txtAudioValue);
               this.groupBox1.Controls.Add(this.chkDenoise);
               this.groupBox1.Controls.Add(this.chkHardSubs);
               this.groupBox1.Controls.Add(this.label4);
               this.groupBox1.Controls.Add(this.txtResolution);
               this.groupBox1.Controls.Add(this.tglResolution);
               this.groupBox1.Controls.Add(this.label3);
               this.groupBox1.Controls.Add(this.txtVideoValue);
               this.groupBox1.Controls.Add(this.label2);
               this.groupBox1.Controls.Add(this.cboMode);
               this.groupBox1.Location = new System.Drawing.Point(9, 187);
               this.groupBox1.Name = "groupBox1";
               this.groupBox1.Size = new System.Drawing.Size(580, 75);
               this.groupBox1.TabIndex = 5;
               this.groupBox1.TabStop = false;
               this.groupBox1.Text = "Basics";
               // 
               // txtAudioValue
               // 
               this.txtAudioValue.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
               this.txtAudioValue.Location = new System.Drawing.Point(356, 33);
               this.txtAudioValue.Maximum = new decimal(new int[] {
            320,
            0,
            0,
            0});
               this.txtAudioValue.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            0});
               this.txtAudioValue.Name = "txtAudioValue";
               this.txtAudioValue.Size = new System.Drawing.Size(58, 20);
               this.txtAudioValue.TabIndex = 18;
               this.txtAudioValue.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
               // 
               // chkDenoise
               // 
               this.chkDenoise.AutoSize = true;
               this.chkDenoise.Location = new System.Drawing.Point(457, 42);
               this.chkDenoise.Name = "chkDenoise";
               this.chkDenoise.Size = new System.Drawing.Size(65, 17);
               this.chkDenoise.TabIndex = 17;
               this.chkDenoise.Text = "Denoise";
               this.chkDenoise.UseVisualStyleBackColor = true;
               // 
               // chkHardSubs
               // 
               this.chkHardSubs.AutoSize = true;
               this.chkHardSubs.Location = new System.Drawing.Point(457, 19);
               this.chkHardSubs.Name = "chkHardSubs";
               this.chkHardSubs.Size = new System.Drawing.Size(108, 17);
               this.chkHardSubs.TabIndex = 16;
               this.chkHardSubs.Text = "Hard Subs (.mp4)";
               this.chkHardSubs.UseVisualStyleBackColor = true;
               // 
               // label4
               // 
               this.label4.AutoSize = true;
               this.label4.Location = new System.Drawing.Point(353, 16);
               this.label4.Name = "label4";
               this.label4.Size = new System.Drawing.Size(67, 13);
               this.label4.TabIndex = 14;
               this.label4.Text = "Audio Bitrate";
               // 
               // txtResolution
               // 
               this.txtResolution.Location = new System.Drawing.Point(281, 34);
               this.txtResolution.Name = "txtResolution";
               this.txtResolution.Size = new System.Drawing.Size(59, 20);
               this.txtResolution.TabIndex = 13;
               this.txtResolution.Text = "720";
               // 
               // tglResolution
               // 
               this.tglResolution.Location = new System.Drawing.Point(200, 32);
               this.tglResolution.Name = "tglResolution";
               this.tglResolution.Size = new System.Drawing.Size(75, 23);
               this.tglResolution.TabIndex = 12;
               this.tglResolution.Text = "Height";
               this.tglResolution.UseVisualStyleBackColor = true;
               this.tglResolution.Click += new System.EventHandler(this.tglResolution_Click);
               // 
               // label3
               // 
               this.label3.AutoSize = true;
               this.label3.Location = new System.Drawing.Point(197, 16);
               this.label3.Name = "label3";
               this.label3.Size = new System.Drawing.Size(57, 13);
               this.label3.TabIndex = 11;
               this.label3.Text = "Resolution";
               // 
               // txtVideoValue
               // 
               this.txtVideoValue.Location = new System.Drawing.Point(118, 33);
               this.txtVideoValue.Name = "txtVideoValue";
               this.txtVideoValue.Size = new System.Drawing.Size(49, 20);
               this.txtVideoValue.TabIndex = 10;
               this.txtVideoValue.Text = "23";
               // 
               // label2
               // 
               this.label2.AutoSize = true;
               this.label2.Location = new System.Drawing.Point(6, 16);
               this.label2.Name = "label2";
               this.label2.Size = new System.Drawing.Size(66, 13);
               this.label2.TabIndex = 9;
               this.label2.Text = "Rate Control";
               // 
               // cboMode
               // 
               this.cboMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
               this.cboMode.FormattingEnabled = true;
               this.cboMode.Items.AddRange(new object[] {
            "Target Quality",
            "Target Bitrate"});
               this.cboMode.Location = new System.Drawing.Point(6, 32);
               this.cboMode.Name = "cboMode";
               this.cboMode.Size = new System.Drawing.Size(106, 21);
               this.cboMode.TabIndex = 8;
               this.cboMode.SelectedIndexChanged += new System.EventHandler(this.cboMode_SelectedIndexChanged);
               // 
               // button2
               // 
               this.button2.Location = new System.Drawing.Point(466, 158);
               this.button2.Name = "button2";
               this.button2.Size = new System.Drawing.Size(123, 23);
               this.button2.TabIndex = 4;
               this.button2.Text = "Add Source Files";
               this.button2.UseVisualStyleBackColor = true;
               this.button2.Click += new System.EventHandler(this.button2_Click);
               // 
               // txtOutput
               // 
               this.txtOutput.Location = new System.Drawing.Point(127, 160);
               this.txtOutput.Name = "txtOutput";
               this.txtOutput.Size = new System.Drawing.Size(333, 20);
               this.txtOutput.TabIndex = 3;
               // 
               // button1
               // 
               this.button1.Location = new System.Drawing.Point(9, 158);
               this.button1.Name = "button1";
               this.button1.Size = new System.Drawing.Size(112, 23);
               this.button1.TabIndex = 2;
               this.button1.Text = "Output Location";
               this.button1.UseVisualStyleBackColor = true;
               this.button1.Click += new System.EventHandler(this.button1_Click);
               // 
               // label1
               // 
               this.label1.AutoSize = true;
               this.label1.Location = new System.Drawing.Point(6, 8);
               this.label1.Name = "label1";
               this.label1.Size = new System.Drawing.Size(286, 13);
               this.label1.TabIndex = 1;
               this.label1.Text = "Add video files to the list below, then click \"Add to Queue\".";
               // 
               // listAdd
               // 
               this.listAdd.AllowDrop = true;
               this.listAdd.BackColor = System.Drawing.SystemColors.Window;
               this.listAdd.FormattingEnabled = true;
               this.listAdd.Location = new System.Drawing.Point(6, 26);
               this.listAdd.Name = "listAdd";
               this.listAdd.Size = new System.Drawing.Size(583, 121);
               this.listAdd.TabIndex = 0;
               // 
               // tabQueue
               // 
               this.tabQueue.Controls.Add(this.txtOut);
               this.tabQueue.Controls.Add(this.chkShutdown);
               this.tabQueue.Controls.Add(this.chkShowConsole);
               this.tabQueue.Controls.Add(this.btnAbort);
               this.tabQueue.Controls.Add(this.btnClear);
               this.tabQueue.Controls.Add(this.btnRemove);
               this.tabQueue.Controls.Add(this.btnEncode);
               this.tabQueue.Controls.Add(this.listOut);
               this.tabQueue.Location = new System.Drawing.Point(4, 22);
               this.tabQueue.Name = "tabQueue";
               this.tabQueue.Padding = new System.Windows.Forms.Padding(3);
               this.tabQueue.Size = new System.Drawing.Size(595, 380);
               this.tabQueue.TabIndex = 1;
               this.tabQueue.Text = "Queue";
               this.tabQueue.UseVisualStyleBackColor = true;
               // 
               // txtOut
               // 
               this.txtOut.Location = new System.Drawing.Point(15, 241);
               this.txtOut.Name = "txtOut";
               this.txtOut.Size = new System.Drawing.Size(565, 20);
               this.txtOut.TabIndex = 7;
               // 
               // chkShutdown
               // 
               this.chkShutdown.AutoSize = true;
               this.chkShutdown.Location = new System.Drawing.Point(397, 208);
               this.chkShutdown.Name = "chkShutdown";
               this.chkShutdown.Size = new System.Drawing.Size(183, 17);
               this.chkShutdown.TabIndex = 6;
               this.chkShutdown.Text = "Shutdown When Done Encoding";
               this.chkShutdown.UseVisualStyleBackColor = true;
               // 
               // chkShowConsole
               // 
               this.chkShowConsole.AutoSize = true;
               this.chkShowConsole.Checked = true;
               this.chkShowConsole.CheckState = System.Windows.Forms.CheckState.Checked;
               this.chkShowConsole.Location = new System.Drawing.Point(15, 208);
               this.chkShowConsole.Name = "chkShowConsole";
               this.chkShowConsole.Size = new System.Drawing.Size(174, 17);
               this.chkShowConsole.TabIndex = 5;
               this.chkShowConsole.Text = "Show Console When Encoding";
               this.chkShowConsole.UseVisualStyleBackColor = true;
               // 
               // btnAbort
               // 
               this.btnAbort.Location = new System.Drawing.Point(456, 159);
               this.btnAbort.Name = "btnAbort";
               this.btnAbort.Size = new System.Drawing.Size(124, 34);
               this.btnAbort.TabIndex = 4;
               this.btnAbort.Text = "Abort Encoding";
               this.btnAbort.UseVisualStyleBackColor = true;
               // 
               // btnClear
               // 
               this.btnClear.Location = new System.Drawing.Point(338, 159);
               this.btnClear.Name = "btnClear";
               this.btnClear.Size = new System.Drawing.Size(90, 34);
               this.btnClear.TabIndex = 3;
               this.btnClear.Text = "Clear";
               this.btnClear.UseVisualStyleBackColor = true;
               this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
               // 
               // btnRemove
               // 
               this.btnRemove.Location = new System.Drawing.Point(242, 159);
               this.btnRemove.Name = "btnRemove";
               this.btnRemove.Size = new System.Drawing.Size(90, 34);
               this.btnRemove.TabIndex = 2;
               this.btnRemove.Text = "Remove";
               this.btnRemove.UseVisualStyleBackColor = true;
               this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
               // 
               // btnEncode
               // 
               this.btnEncode.Location = new System.Drawing.Point(15, 159);
               this.btnEncode.Name = "btnEncode";
               this.btnEncode.Size = new System.Drawing.Size(189, 34);
               this.btnEncode.TabIndex = 1;
               this.btnEncode.Text = "Encode";
               this.btnEncode.UseVisualStyleBackColor = true;
               this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
               // 
               // listOut
               // 
               this.listOut.FormattingEnabled = true;
               this.listOut.Location = new System.Drawing.Point(6, 6);
               this.listOut.Name = "listOut";
               this.listOut.Size = new System.Drawing.Size(583, 147);
               this.listOut.TabIndex = 0;
               // 
               // contextMenuStrip1
               // 
               this.contextMenuStrip1.Name = "contextMenuStrip1";
               this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
               // 
               // tmrEncodeTimer
               // 
               this.tmrEncodeTimer.Tick += new System.EventHandler(this.tmrEncodeTimer_Tick);
               // 
               // openFileDialog1
               // 
               this.openFileDialog1.FileName = "openFileDialog1";
               // 
               // Form1
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(627, 430);
               this.Controls.Add(this.tabControl1);
               this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
               this.MaximizeBox = false;
               this.Name = "Form1";
               this.Text = "Cyko";
               this.Load += new System.EventHandler(this.Form1_Load);
               this.tabControl1.ResumeLayout(false);
               this.tabInput.ResumeLayout(false);
               this.tabInput.PerformLayout();
               this.groupBox4.ResumeLayout(false);
               this.groupBox3.ResumeLayout(false);
               this.groupBox2.ResumeLayout(false);
               this.groupBox1.ResumeLayout(false);
               this.groupBox1.PerformLayout();
               ((System.ComponentModel.ISupportInitialize)(this.txtAudioValue)).EndInit();
               this.tabQueue.ResumeLayout(false);
               this.tabQueue.PerformLayout();
               this.ResumeLayout(false);

          }

          #endregion

          private System.Windows.Forms.TabControl tabControl1;
          private System.Windows.Forms.TabPage tabInput;
          private System.Windows.Forms.ListBox listAdd;
          private System.Windows.Forms.TabPage tabQueue;
          private System.Windows.Forms.Label label1;
          private System.Windows.Forms.GroupBox groupBox2;
          private System.Windows.Forms.GroupBox groupBox1;
          private System.Windows.Forms.Button button2;
          private System.Windows.Forms.TextBox txtOutput;
          private System.Windows.Forms.Button button1;
          private System.Windows.Forms.GroupBox groupBox4;
          private System.Windows.Forms.ComboBox cboProfiles;
          private System.Windows.Forms.GroupBox groupBox3;
          private System.Windows.Forms.ComboBox cboTunes;
          private System.Windows.Forms.ComboBox cboPresets;
          private System.Windows.Forms.TextBox txtScanStatus;
          private System.Windows.Forms.Button btnEnqueue;
          private System.Windows.Forms.CheckBox chkDenoise;
          private System.Windows.Forms.CheckBox chkHardSubs;
          private System.Windows.Forms.Label label4;
          private System.Windows.Forms.TextBox txtResolution;
          private System.Windows.Forms.Button tglResolution;
          private System.Windows.Forms.Label label3;
          private System.Windows.Forms.TextBox txtVideoValue;
          private System.Windows.Forms.Label label2;
          private System.Windows.Forms.ComboBox cboMode;
          private System.Windows.Forms.TextBox txtOut;
          private System.Windows.Forms.CheckBox chkShutdown;
          private System.Windows.Forms.CheckBox chkShowConsole;
          private System.Windows.Forms.Button btnAbort;
          private System.Windows.Forms.Button btnClear;
          private System.Windows.Forms.Button btnRemove;
          private System.Windows.Forms.Button btnEncode;
          private System.Windows.Forms.ListBox listOut;
          private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
          private System.Windows.Forms.Timer tmrEncodeTimer;
          private System.Windows.Forms.Button button3;
          private System.Windows.Forms.NumericUpDown txtAudioValue;
          private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
          private System.Windows.Forms.OpenFileDialog openFileDialog1;
     }
}

