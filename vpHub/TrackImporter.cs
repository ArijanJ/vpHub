using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MidiParser;

namespace vpHub
{
    public partial class TrackImporter : Form
    {
        MidiFile midiFile;
        public List<int> tracksSelected = new List<int>();
        public TrackImporter(MidiFile midi)
        {
            InitializeComponent();
            midiFile = midi;
        }

        private void TrackImporter_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < midiFile.TracksCount; i++) 
            {
                var result = $"Track {i}: {midiFile.Tracks[i].MidiEvents.Count()} events";
                clistboxTracks.Items.Add(result);
                clistboxTracks.SetItemChecked(i, true);
            }
        }

        private void button1_Click(object sender, EventArgs e) // Submit button
        {
            int listboxCount = clistboxTracks.Items.Count;
            if(listboxCount == 0)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show("Please import at least one track.", "Import error", buttons);
                //if (result == System.Windows.Forms.DialogResult.OK) { }
            }
            for (int i = 0; i < listboxCount; i++)
            {
                if (clistboxTracks.GetItemChecked(i))
                {
                    tracksSelected.Add(i);
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnDeselectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clistboxTracks.Items.Count; i++)
            {
                clistboxTracks.SetItemChecked(i, false);
            }
        }
    }
}
