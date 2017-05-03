namespace FinalProjectVersion2._0
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
            this.terminatedLeasesPanel = new System.Windows.Forms.Panel();
            this.terminatedLeasesLabel = new System.Windows.Forms.Label();
            this.newLeasesPanel = new System.Windows.Forms.Panel();
            this.newLeasesLabel = new System.Windows.Forms.Label();
            this.goButton = new System.Windows.Forms.Button();
            this.instructionsButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.terminatedLeasesPanel.SuspendLayout();
            this.newLeasesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // terminatedLeasesPanel
            // 
            this.terminatedLeasesPanel.AllowDrop = true;
            this.terminatedLeasesPanel.BackColor = System.Drawing.Color.LightGray;
            this.terminatedLeasesPanel.Controls.Add(this.terminatedLeasesLabel);
            this.terminatedLeasesPanel.Location = new System.Drawing.Point(12, 153);
            this.terminatedLeasesPanel.Name = "terminatedLeasesPanel";
            this.terminatedLeasesPanel.Size = new System.Drawing.Size(386, 254);
            this.terminatedLeasesPanel.TabIndex = 1;
            this.terminatedLeasesPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.terminatedLeasesPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            // 
            // terminatedLeasesLabel
            // 
            this.terminatedLeasesLabel.AutoSize = true;
            this.terminatedLeasesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.terminatedLeasesLabel.Location = new System.Drawing.Point(59, 109);
            this.terminatedLeasesLabel.Name = "terminatedLeasesLabel";
            this.terminatedLeasesLabel.Size = new System.Drawing.Size(266, 25);
            this.terminatedLeasesLabel.TabIndex = 0;
            this.terminatedLeasesLabel.Text = "Terminated Leases Report";
            // 
            // newLeasesPanel
            // 
            this.newLeasesPanel.AllowDrop = true;
            this.newLeasesPanel.BackColor = System.Drawing.Color.LightGray;
            this.newLeasesPanel.Controls.Add(this.newLeasesLabel);
            this.newLeasesPanel.Location = new System.Drawing.Point(422, 153);
            this.newLeasesPanel.Name = "newLeasesPanel";
            this.newLeasesPanel.Size = new System.Drawing.Size(386, 254);
            this.newLeasesPanel.TabIndex = 2;
            this.newLeasesPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.newLeasesPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            // 
            // newLeasesLabel
            // 
            this.newLeasesLabel.AutoSize = true;
            this.newLeasesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newLeasesLabel.Location = new System.Drawing.Point(99, 109);
            this.newLeasesLabel.Name = "newLeasesLabel";
            this.newLeasesLabel.Size = new System.Drawing.Size(199, 25);
            this.newLeasesLabel.TabIndex = 0;
            this.newLeasesLabel.Text = "New Leases Report";
            // 
            // goButton
            // 
            this.goButton.Enabled = false;
            this.goButton.Location = new System.Drawing.Point(707, 423);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(101, 38);
            this.goButton.TabIndex = 0;
            this.goButton.Text = "Go!";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Visible = false;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // instructionsButton
            // 
            this.instructionsButton.Location = new System.Drawing.Point(12, 423);
            this.instructionsButton.Name = "instructionsButton";
            this.instructionsButton.Size = new System.Drawing.Size(101, 38);
            this.instructionsButton.TabIndex = 3;
            this.instructionsButton.Text = "Instructions";
            this.instructionsButton.UseVisualStyleBackColor = true;
            this.instructionsButton.Click += new System.EventHandler(this.instructionsButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FinalProjectVersion2._0.Resource1.colorado_property_management;
            this.pictureBox1.Location = new System.Drawing.Point(12, -6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(278, 139);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 473);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.instructionsButton);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.newLeasesPanel);
            this.Controls.Add(this.terminatedLeasesPanel);
            this.Name = "Form1";
            this.Text = "Change In Rent Calculator";
            this.terminatedLeasesPanel.ResumeLayout(false);
            this.terminatedLeasesPanel.PerformLayout();
            this.newLeasesPanel.ResumeLayout(false);
            this.newLeasesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel terminatedLeasesPanel;
        private System.Windows.Forms.Panel newLeasesPanel;
        private System.Windows.Forms.Label terminatedLeasesLabel;
        private System.Windows.Forms.Label newLeasesLabel;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Button instructionsButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

