namespace RSVPReader
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnResume = new Button();
            btnPause = new Button();
            btnStop = new Button();
            btnStart = new Button();
            btnUpload = new Button();
            btnJump = new Button();
            txtJumpTo = new TextBox();
            numWpm = new NumericUpDown();
            lblRsvp = new Label();
            lblStatus = new Label();
            cmbChapters = new ComboBox();
            exitButton = new Button();
            ((System.ComponentModel.ISupportInitialize)numWpm).BeginInit();
            SuspendLayout();
            // 
            // btnResume
            // 
            btnResume.Location = new Point(406, 415);
            btnResume.Name = "btnResume";
            btnResume.Size = new Size(75, 23);
            btnResume.TabIndex = 0;
            btnResume.Text = "Resume";
            btnResume.UseVisualStyleBackColor = true;
            btnResume.Click += btnResume_Click;
            // 
            // btnPause
            // 
            btnPause.Location = new Point(487, 415);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(75, 23);
            btnPause.TabIndex = 1;
            btnPause.Text = "Pause";
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += btnPause_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(568, 415);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(325, 415);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 3;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(12, 12);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(75, 23);
            btnUpload.TabIndex = 4;
            btnUpload.Text = "Upload";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // btnJump
            // 
            btnJump.Location = new Point(118, 415);
            btnJump.Name = "btnJump";
            btnJump.Size = new Size(75, 23);
            btnJump.TabIndex = 5;
            btnJump.Text = "Jump To";
            btnJump.UseVisualStyleBackColor = true;
            btnJump.Click += btnJump_Click;
            // 
            // txtJumpTo
            // 
            txtJumpTo.Location = new Point(12, 415);
            txtJumpTo.Name = "txtJumpTo";
            txtJumpTo.Size = new Size(100, 23);
            txtJumpTo.TabIndex = 6;
            // 
            // numWpm
            // 
            numWpm.Location = new Point(199, 415);
            numWpm.Name = "numWpm";
            numWpm.Size = new Size(120, 23);
            numWpm.TabIndex = 7;
            numWpm.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // lblRsvp
            // 
            lblRsvp.AutoSize = true;
            lblRsvp.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblRsvp.Location = new Point(362, 157);
            lblRsvp.Name = "lblRsvp";
            lblRsvp.Size = new Size(68, 30);
            lblRsvp.TabIndex = 8;
            lblRsvp.Text = "label1";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(93, 20);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(38, 15);
            lblStatus.TabIndex = 9;
            lblStatus.Text = "label1";
            // 
            // cmbChapters
            // 
            cmbChapters.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbChapters.FormattingEnabled = true;
            cmbChapters.Location = new Point(13, 444);
            cmbChapters.Name = "cmbChapters";
            cmbChapters.Size = new Size(121, 23);
            cmbChapters.TabIndex = 10;
            cmbChapters.SelectedIndexChanged += cmbChapters_SelectedIndexChanged;
            // 
            // exitButton
            // 
            exitButton.Location = new Point(723, 456);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(75, 23);
            exitButton.TabIndex = 11;
            exitButton.Text = "exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 480);
            Controls.Add(exitButton);
            Controls.Add(cmbChapters);
            Controls.Add(lblStatus);
            Controls.Add(lblRsvp);
            Controls.Add(numWpm);
            Controls.Add(txtJumpTo);
            Controls.Add(btnJump);
            Controls.Add(btnUpload);
            Controls.Add(btnStart);
            Controls.Add(btnStop);
            Controls.Add(btnPause);
            Controls.Add(btnResume);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            ((System.ComponentModel.ISupportInitialize)numWpm).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnResume;
        private Button btnPause;
        private Button btnStop;
        private Button btnStart;
        private Button btnUpload;
        private Button btnJump;
        private TextBox txtJumpTo;
        private NumericUpDown numWpm;
        private Label lblRsvp;
        private Label lblStatus;
        private ComboBox cmbChapters;
        private Button exitButton;
    }
}
