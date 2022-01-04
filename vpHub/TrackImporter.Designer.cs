
namespace vpHub
{
    partial class TrackImporter
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
            this.label1 = new System.Windows.Forms.Label();
            this.clistboxTracks = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDeselectAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select which tracks you would like to import:";
            // 
            // clistboxTracks
            // 
            this.clistboxTracks.CheckOnClick = true;
            this.clistboxTracks.FormattingEnabled = true;
            this.clistboxTracks.Location = new System.Drawing.Point(12, 37);
            this.clistboxTracks.Name = "clistboxTracks";
            this.clistboxTracks.Size = new System.Drawing.Size(254, 148);
            this.clistboxTracks.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(146, 191);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 31);
            this.button1.TabIndex = 2;
            this.button1.Text = "Continue";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.Location = new System.Drawing.Point(10, 191);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(130, 31);
            this.btnDeselectAll.TabIndex = 3;
            this.btnDeselectAll.Text = "Deselect All";
            this.btnDeselectAll.UseVisualStyleBackColor = true;
            this.btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // TrackImporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 228);
            this.Controls.Add(this.btnDeselectAll);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.clistboxTracks);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "TrackImporter";
            this.Text = "Track Importer";
            this.Load += new System.EventHandler(this.TrackImporter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox clistboxTracks;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDeselectAll;
    }
}