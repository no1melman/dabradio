namespace DabRadio
{
    partial class Main
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
            this.SerialCommsListBox = new System.Windows.Forms.ListBox();
            this.RefreshSerialCommsButton = new System.Windows.Forms.Button();
            this.OnOffButton = new System.Windows.Forms.Button();
            this.ProgramListBox = new System.Windows.Forms.ListBox();
            this.VolumeUpButton = new System.Windows.Forms.Button();
            this.VolumeDownButton = new System.Windows.Forms.Button();
            this.SignalStrengthLabel = new System.Windows.Forms.Label();
            this.ProgramTextLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SerialCommsListBox
            // 
            this.SerialCommsListBox.FormattingEnabled = true;
            this.SerialCommsListBox.Location = new System.Drawing.Point(93, 12);
            this.SerialCommsListBox.Name = "SerialCommsListBox";
            this.SerialCommsListBox.Size = new System.Drawing.Size(120, 95);
            this.SerialCommsListBox.TabIndex = 1;
            this.SerialCommsListBox.SelectedIndexChanged += new System.EventHandler(this.SerialCommsListBox_SelectedIndexChanged);
            // 
            // RefreshSerialCommsButton
            // 
            this.RefreshSerialCommsButton.Location = new System.Drawing.Point(12, 41);
            this.RefreshSerialCommsButton.Name = "RefreshSerialCommsButton";
            this.RefreshSerialCommsButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshSerialCommsButton.TabIndex = 2;
            this.RefreshSerialCommsButton.Text = "Refresh";
            this.RefreshSerialCommsButton.UseVisualStyleBackColor = true;
            this.RefreshSerialCommsButton.Click += new System.EventHandler(this.RefreshSerialCommsButton_Click);
            // 
            // OnOffButton
            // 
            this.OnOffButton.BackColor = System.Drawing.Color.GreenYellow;
            this.OnOffButton.Enabled = false;
            this.OnOffButton.Location = new System.Drawing.Point(12, 12);
            this.OnOffButton.Name = "OnOffButton";
            this.OnOffButton.Size = new System.Drawing.Size(75, 23);
            this.OnOffButton.TabIndex = 4;
            this.OnOffButton.Text = "On";
            this.OnOffButton.UseVisualStyleBackColor = false;
            this.OnOffButton.Click += new System.EventHandler(this.OnOffButton_Click);
            // 
            // ProgramListBox
            // 
            this.ProgramListBox.FormattingEnabled = true;
            this.ProgramListBox.Location = new System.Drawing.Point(93, 163);
            this.ProgramListBox.Name = "ProgramListBox";
            this.ProgramListBox.Size = new System.Drawing.Size(120, 95);
            this.ProgramListBox.TabIndex = 5;
            this.ProgramListBox.SelectedIndexChanged += new System.EventHandler(this.ProgramListBox_SelectedIndexChanged);
            // 
            // VolumeUpButton
            // 
            this.VolumeUpButton.Location = new System.Drawing.Point(12, 163);
            this.VolumeUpButton.Name = "VolumeUpButton";
            this.VolumeUpButton.Size = new System.Drawing.Size(75, 23);
            this.VolumeUpButton.TabIndex = 6;
            this.VolumeUpButton.Text = "Volume ˄";
            this.VolumeUpButton.UseVisualStyleBackColor = true;
            this.VolumeUpButton.Click += new System.EventHandler(this.VolumeUpButton_Click);
            // 
            // VolumeDownButton
            // 
            this.VolumeDownButton.Location = new System.Drawing.Point(12, 205);
            this.VolumeDownButton.Name = "VolumeDownButton";
            this.VolumeDownButton.Size = new System.Drawing.Size(75, 23);
            this.VolumeDownButton.TabIndex = 7;
            this.VolumeDownButton.Text = "Volume ˅";
            this.VolumeDownButton.UseVisualStyleBackColor = true;
            this.VolumeDownButton.Click += new System.EventHandler(this.VolumeDownButton_Click);
            // 
            // SignalStrengthLabel
            // 
            this.SignalStrengthLabel.AutoSize = true;
            this.SignalStrengthLabel.Location = new System.Drawing.Point(232, 12);
            this.SignalStrengthLabel.Name = "SignalStrengthLabel";
            this.SignalStrengthLabel.Size = new System.Drawing.Size(76, 13);
            this.SignalStrengthLabel.TabIndex = 8;
            this.SignalStrengthLabel.Text = "SignalStrength";
            // 
            // ProgramTextLabel
            // 
            this.ProgramTextLabel.AutoSize = true;
            this.ProgramTextLabel.Location = new System.Drawing.Point(12, 122);
            this.ProgramTextLabel.Name = "ProgramTextLabel";
            this.ProgramTextLabel.Size = new System.Drawing.Size(66, 13);
            this.ProgramTextLabel.TabIndex = 10;
            this.ProgramTextLabel.Text = "Program text";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 325);
            this.Controls.Add(this.ProgramTextLabel);
            this.Controls.Add(this.SignalStrengthLabel);
            this.Controls.Add(this.VolumeDownButton);
            this.Controls.Add(this.VolumeUpButton);
            this.Controls.Add(this.ProgramListBox);
            this.Controls.Add(this.OnOffButton);
            this.Controls.Add(this.RefreshSerialCommsButton);
            this.Controls.Add(this.SerialCommsListBox);
            this.Name = "Main";
            this.Text = "DAB Radio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox SerialCommsListBox;
        private System.Windows.Forms.Button RefreshSerialCommsButton;
        private System.Windows.Forms.Button OnOffButton;
        private System.Windows.Forms.ListBox ProgramListBox;
        private System.Windows.Forms.Button VolumeUpButton;
        private System.Windows.Forms.Button VolumeDownButton;
        private System.Windows.Forms.Label SignalStrengthLabel;
        private System.Windows.Forms.Label ProgramTextLabel;
    }
}

