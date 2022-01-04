using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MidiParser;
using DarkUI.Forms;

namespace vpHub
{   
    public partial class Form1 : DarkForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Sheet originalSheet = new Sheet();
        public Sheet currentSheet = new Sheet();
        int firstTime = 1;

        int lastTransposition = 0;
        private void PopulateRichTextBox(Sheet sheet, bool trelloMode = false)
        {
            int transposition = Decimal.ToInt32(nTransposition.Value);
            if (transposition != lastTransposition)
            { 
                sheet = Sheet.Transpose(originalSheet, transposition - lastTransposition);
                lastTransposition = transposition;
            }
            rtbSheet.Text = "";
            Font regularFont = new Font(this.Font, FontStyle.Regular);
            Font boldFont = new Font(this.Font, FontStyle.Bold);

            var shiftBeginning = cbShiftPositionBeginning.Checked;
            var boldBeginning = cbBoldPositionBeginning.Checked;

            var positionSettings = new bool[] { shiftBeginning, boldBeginning };
            //if (sheet.SpecialPositions != positionSettings) // update
            sheet.SpecialPositions = positionSettings;
            sheet.SortSheet();
            //sheet.SpecialPositions = positionSettings;

            currentSheet = sheet;

            if (trelloMode == true)
            {
                var trelloStr = "";
                for (int ic = 0; ic < sheet.Chords.Count; ic++)
                {
                    var chord = sheet.Chords[ic];
                    var ChordSize = chord.GetSize();
                    if (ChordSize > 1) { trelloStr += "["; }
                    for (int i = 0; i < ChordSize; i++)
                    {
                        if (chord.Notes[i].BaseChar == '*')
                        {
                            trelloStr += "\\*";
                            if(ChordSize == 1) { trelloStr += " "; }
                            continue;
                        }
                        if(ChordSize > 1 && i == 0 && chord.Notes[i].OutOfRange && !chord.Notes[i + 1].OutOfRange)
                        {
                            trelloStr += "**" + chord.Notes[i].BaseChar + "**";
                            continue;
                        }
                        if (chord.Notes[i].OutOfRange == true)
                        {
                            if (i + 1 != ChordSize && i != 0)
                            {
                                var current = chord.Notes[i];
                                var next = chord.Notes[i + 1];
                                var previous = chord.Notes[i - 1];

                                if (previous.OutOfRange)
                                {
                                    if (current.OutOfRange)
                                    {
                                        trelloStr += $"{current.BaseChar}";
                                        if (!next.OutOfRange)
                                            trelloStr += "**";
                                    }
                                }

                                else if (ChordSize > 1 && i == 0)
                                {
                                    if (chord.Notes[i].OutOfRange)
                                    {
                                        trelloStr += "**" + current.BaseChar + "**";
                                    }
                                }
                                else
                                    trelloStr += $"**{current.BaseChar}";
                            }
                            else
                            {
                                if (ChordSize != 0) {
                                    trelloStr += $"**{chord.Notes[i].BaseChar}";
                                }
                                else if(ChordSize > 1 && i == 0)
                                {
                                    if (chord.Notes[i].OutOfRange)
                                    {
                                        trelloStr += "**";
                                    }
                                }
                                if(ChordSize == 1 && chord.Notes[i].OutOfRange)
                                {
                                    trelloStr += "**";
                                }
                            }
                        }
                        else if (chord.Notes[i].OutOfRange == false)
                        {
                            if (chord.Notes[i].BaseChar == '*')
                            {
                                trelloStr += "//*";
                                if (ChordSize == 1) { trelloStr += " "; }
                                continue;
                            }
                            if(i > 0)
                            {
                                if(chord.Notes[i - 1].OutOfRange)
                                {
                                    //trelloStr += "**";
                                }
                            }
                            trelloStr += chord.Notes[i].BaseChar;
                        }
                    }
                    if (ChordSize > 1) { trelloStr += "] "; }
                    else
                    {
                        trelloStr += " ";
                    }
                }
                rtbSheet.SelectionFont = regularFont;
                rtbSheet.Font = regularFont;
                rtbSheet.Text = trelloStr;
                return;
            }

            for (int ic = 0; ic < sheet.Chords.Count; ic++)
            {
                var chord = sheet.Chords[ic];
                //chord.SortChord(shiftBeginning, boldBeginning);
                var ChordSize = chord.GetSize();
                if (ChordSize == 1)
                {
                    if (chord.Notes[0].OutOfRange == true)
                    {
                        rtbSheet.SelectionFont = boldFont;
                    }
                    else // not out of range, don't bold
                    {
                        rtbSheet.SelectionFont = regularFont;
                    }
                    rtbSheet.AppendText(chord.Notes[0].BaseChar + " ");
                }
                else if (ChordSize > 1) // long chord
                {
                    rtbSheet.SelectionFont = regularFont;
                    rtbSheet.AppendText("[");
                    for(int i = 0; i < chord.Notes.Count; i++)
                    {
                        var note = chord.Notes[i];
                        if (note.OutOfRange == true) //BOLD IT
                        {
                            rtbSheet.SelectionFont = boldFont;
                        }
                        else // not out of range, NOT BOLD
                        {
                            rtbSheet.SelectionFont = regularFont;
                        }
                        rtbSheet.AppendText(Char.ToString(note.BaseChar));
                    }
                    rtbSheet.SelectionFont = regularFont;
                    rtbSheet.AppendText("] ");
                }
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "MID/I files (*.mid, *.midi)|*.mid;*.midi";
                
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {   
                    var filePath = openFileDialog.FileName;
                    var midiFile = new MidiFile(filePath);
                    List<int> selectedTrackIndexes;
                    using (var trackForm = new TrackImporter(midiFile))
                    {
                        { 
                            trackForm.ShowDialog();
                            selectedTrackIndexes = trackForm.tracksSelected;
                        }
                    }
                    Sheet sheet = MidiConverter.ConvertMidi(midiFile, selectedTrackIndexes);
                    sheet.SortSheet();

                    //rtbSheet.SelectionFont = new Font(this.Font, FontStyle.Bold);
                    /*var color = new Color();
                    color = Color.FromArgb(255, 255, 0, 0);
                    rtbSheet.SelectionColor = color;*/

                    originalSheet = sheet;

                    lastTransposition = 0;

                    firstTime = 1;
                    nTransposition.Value = 0;
                    PopulateRichTextBox(sheet, trelloFormatToolStripMenuItem.Checked);
                    firstTime = 0;
                }
            }
        }

        private void trelloFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trelloFormatToolStripMenuItem.Checked = !trelloFormatToolStripMenuItem.Checked;
        }

        private void trelloFormatToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            PopulateRichTextBox(currentSheet, trelloFormatToolStripMenuItem.Checked);
        }

        private void nTransposition_ValueChanged(object sender, EventArgs e)
        {
            if (firstTime != 1)
                PopulateRichTextBox(currentSheet, trelloFormatToolStripMenuItem.Checked);
        }

        private void cbShiftPositionBeginning_Click(object sender, EventArgs e)
        {
            cbShiftPositionBeginning.Checked = !cbShiftPositionBeginning.Checked;
        }

        private void cbShiftPositionBeginning_CheckedChanged(object sender, EventArgs e)
        {
            cbShiftPositionEnd.Checked = !cbShiftPositionBeginning.Checked; // Flip the other one
            PopulateRichTextBox(currentSheet, trelloFormatToolStripMenuItem.Checked); // only need one cause one is always going to be changed when the other is
        }

        private void cbShiftPositionEnd_Click(object sender, EventArgs e)
        {
            cbShiftPositionEnd.Checked = !cbShiftPositionEnd.Checked;
        }

        private void cbShiftPositionEnd_CheckedChanged(object sender, EventArgs e)
        {
            cbShiftPositionBeginning.Checked = !cbShiftPositionEnd.Checked; // Flip the other one
        }

        private void cbBoldPositionBeginning_Click(object sender, EventArgs e)
        {
            cbBoldPositionBeginning.Checked = !cbBoldPositionBeginning.Checked;
        }

        private void cbBoldPositionBeginning_CheckedChanged(object sender, EventArgs e)
        {
            cbBoldPositionEnd.Checked = !cbBoldPositionBeginning.Checked; // Flip the other one
            PopulateRichTextBox(currentSheet, trelloFormatToolStripMenuItem.Checked); // only need one cause one is always going to be changed when the other is
        }

        private void cbBoldPositionEnd_Click(object sender, EventArgs e)
        {
            cbBoldPositionEnd.Checked = !cbBoldPositionEnd.Checked;
        }

        private void cbBoldPositionEnd_CheckedChanged(object sender, EventArgs e)
        {
            cbBoldPositionBeginning.Checked = !cbBoldPositionEnd.Checked;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //AllocConsole();
        }

        /*[DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();*/

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox1().Show();
        }

        private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbSheet.SelectAll();
            rtbSheet.Copy();
            rtbSheet.DeselectAll();
        }
    }
}