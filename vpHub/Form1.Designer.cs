
namespace vpHub
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.rtbSheet = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trelloFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shiftsPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbShiftPositionBeginning = new System.Windows.Forms.ToolStripMenuItem();
            this.cbShiftPositionEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.boldsPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbBoldPositionBeginning = new System.Windows.Forms.ToolStripMenuItem();
            this.cbBoldPositionEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.nTransposition = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nTransposition)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenFile.AutoSize = true;
            this.btnOpenFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOpenFile.BackColor = System.Drawing.SystemColors.Control;
            this.btnOpenFile.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOpenFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOpenFile.Location = new System.Drawing.Point(12, 350);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(142, 42);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "Open File...";
            this.btnOpenFile.UseVisualStyleBackColor = false;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // rtbSheet
            // 
            this.rtbSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbSheet.BackColor = System.Drawing.SystemColors.Control;
            this.rtbSheet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbSheet.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rtbSheet.Location = new System.Drawing.Point(12, 24);
            this.rtbSheet.Name = "rtbSheet";
            this.rtbSheet.ReadOnly = true;
            this.rtbSheet.Size = new System.Drawing.Size(340, 315);
            this.rtbSheet.TabIndex = 1;
            this.rtbSheet.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sheetToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(364, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sheetToolStripMenuItem
            // 
            this.sheetToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.sheetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trelloFormatToolStripMenuItem,
            this.copyToClipboardToolStripMenuItem});
            this.sheetToolStripMenuItem.Name = "sheetToolStripMenuItem";
            this.sheetToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.sheetToolStripMenuItem.Text = "Sheet";
            // 
            // trelloFormatToolStripMenuItem
            // 
            this.trelloFormatToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.trelloFormatToolStripMenuItem.Name = "trelloFormatToolStripMenuItem";
            this.trelloFormatToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.trelloFormatToolStripMenuItem.Text = "Trello Format";
            this.trelloFormatToolStripMenuItem.CheckedChanged += new System.EventHandler(this.trelloFormatToolStripMenuItem_CheckedChanged);
            this.trelloFormatToolStripMenuItem.Click += new System.EventHandler(this.trelloFormatToolStripMenuItem_Click);
            // 
            // copyToClipboardToolStripMenuItem
            // 
            this.copyToClipboardToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.copyToClipboardToolStripMenuItem.Name = "copyToClipboardToolStripMenuItem";
            this.copyToClipboardToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.copyToClipboardToolStripMenuItem.Text = "Copy to Clipboard";
            this.copyToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyToClipboardToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shiftsPositionToolStripMenuItem,
            this.boldsPositionToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // shiftsPositionToolStripMenuItem
            // 
            this.shiftsPositionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbShiftPositionBeginning,
            this.cbShiftPositionEnd});
            this.shiftsPositionToolStripMenuItem.Name = "shiftsPositionToolStripMenuItem";
            this.shiftsPositionToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.shiftsPositionToolStripMenuItem.Text = "Shifts Position";
            // 
            // cbShiftPositionBeginning
            // 
            this.cbShiftPositionBeginning.Checked = true;
            this.cbShiftPositionBeginning.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShiftPositionBeginning.Name = "cbShiftPositionBeginning";
            this.cbShiftPositionBeginning.Size = new System.Drawing.Size(128, 22);
            this.cbShiftPositionBeginning.Text = "Beginning";
            this.cbShiftPositionBeginning.CheckedChanged += new System.EventHandler(this.cbShiftPositionBeginning_CheckedChanged);
            this.cbShiftPositionBeginning.Click += new System.EventHandler(this.cbShiftPositionBeginning_Click);
            // 
            // cbShiftPositionEnd
            // 
            this.cbShiftPositionEnd.Name = "cbShiftPositionEnd";
            this.cbShiftPositionEnd.Size = new System.Drawing.Size(128, 22);
            this.cbShiftPositionEnd.Text = "End";
            this.cbShiftPositionEnd.CheckedChanged += new System.EventHandler(this.cbShiftPositionEnd_CheckedChanged);
            this.cbShiftPositionEnd.Click += new System.EventHandler(this.cbShiftPositionEnd_Click);
            // 
            // boldsPositionToolStripMenuItem
            // 
            this.boldsPositionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbBoldPositionBeginning,
            this.cbBoldPositionEnd});
            this.boldsPositionToolStripMenuItem.Name = "boldsPositionToolStripMenuItem";
            this.boldsPositionToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.boldsPositionToolStripMenuItem.Text = "Bolds Position";
            // 
            // cbBoldPositionBeginning
            // 
            this.cbBoldPositionBeginning.Checked = true;
            this.cbBoldPositionBeginning.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBoldPositionBeginning.Name = "cbBoldPositionBeginning";
            this.cbBoldPositionBeginning.Size = new System.Drawing.Size(128, 22);
            this.cbBoldPositionBeginning.Text = "Beginning";
            this.cbBoldPositionBeginning.CheckedChanged += new System.EventHandler(this.cbBoldPositionBeginning_CheckedChanged);
            this.cbBoldPositionBeginning.Click += new System.EventHandler(this.cbBoldPositionBeginning_Click);
            // 
            // cbBoldPositionEnd
            // 
            this.cbBoldPositionEnd.Name = "cbBoldPositionEnd";
            this.cbBoldPositionEnd.Size = new System.Drawing.Size(128, 22);
            this.cbBoldPositionEnd.Text = "End";
            this.cbBoldPositionEnd.CheckedChanged += new System.EventHandler(this.cbBoldPositionEnd_CheckedChanged);
            this.cbBoldPositionEnd.Click += new System.EventHandler(this.cbBoldPositionEnd_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(160, 357);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "Transpose by:";
            // 
            // nTransposition
            // 
            this.nTransposition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nTransposition.BackColor = System.Drawing.SystemColors.Control;
            this.nTransposition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nTransposition.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nTransposition.Location = new System.Drawing.Point(307, 355);
            this.nTransposition.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nTransposition.Minimum = new decimal(new int[] {
            24,
            0,
            0,
            -2147483648});
            this.nTransposition.Name = "nTransposition";
            this.nTransposition.Size = new System.Drawing.Size(45, 36);
            this.nTransposition.TabIndex = 4;
            this.nTransposition.ValueChanged += new System.EventHandler(this.nTransposition_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(364, 398);
            this.Controls.Add(this.nTransposition);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbSheet);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(380, 120);
            this.Name = "Form1";
            this.Text = "MIDI Converter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nTransposition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.RichTextBox rtbSheet;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trelloFormatToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nTransposition;
        private System.Windows.Forms.ToolStripMenuItem shiftsPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cbShiftPositionBeginning;
        private System.Windows.Forms.ToolStripMenuItem cbShiftPositionEnd;
        private System.Windows.Forms.ToolStripMenuItem boldsPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cbBoldPositionBeginning;
        private System.Windows.Forms.ToolStripMenuItem cbBoldPositionEnd;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

