﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zynzezizer_cs
{
    public partial class Sequencer : Form
    {
        private SynthEngine synthEngine;
        private TrackInfo trackInfo;
        private Thread player;
        private int currentBeat;
        private int endBeat;

        public Sequencer(SynthEngine synthEngine, TrackInfo trackInfo)
        {
            InitializeComponent();
            this.synthEngine = synthEngine;
            this.trackInfo = trackInfo;

            if(this.trackInfo.BPM == 0)
            {
                this.trackInfo.BPM = tb_BPM.Value * 4;
            }
        }

        public TrackInfo getTrackInfo()
        {
            return trackInfo;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            lb_Notes.Items.Add("NewNote");
            trackInfo.notes.Add(new TrackNoteInfo());
            //lb_Notes.SelectedIndex = lb_Notes.Items.Count - 1;
            //UpdateNote();
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            if(lb_Notes.Items.Count > 0)
            {
                if(lb_Notes.SelectedIndex != -1)
                {
                    trackInfo.notes.RemoveAt(lb_Notes.SelectedIndex);
                    lb_Notes.Items.Remove(lb_Notes.SelectedItem);
                }
            }
        }

        private void tb_BPM_ValueChanged(object sender, EventArgs e)
        {
            lbl_BPM.Text = tb_BPM.Value.ToString();
            trackInfo.BPM = tb_BPM.Value * 4;
        }

        private void btn_Play_Click(object sender, EventArgs e)
        {
            player = new Thread(new ThreadStart(Start));
            player.IsBackground = true;
            player.Start();
        }

        private void Start()
        {
            try
            {
                int oneBeat = (int)(60000 / (float)trackInfo.BPM);
                for (int i = 0; i < 100; ++i)
                {
                    synthEngine.NoteOn(49);
                    Thread.Sleep(oneBeat);
                    synthEngine.NoteOff(49);
                    Thread.Sleep(oneBeat);
                    ++currentBeat;
                }
            }
            catch (ThreadAbortException e)
            {
                synthEngine.NoteOff(49);
            }
        }

        private void UpdateNote()
        {
            if (lb_Notes.Items.Count > 0)
            {
                if (lb_Notes.SelectedIndex != -1)
                {
                    var note = trackInfo.notes[lb_Notes.SelectedIndex];
                    note.octave = tb_Octave.Value;
                    note.currentNote = cb_Note.SelectedIndex;
                    note.beatStart = (int)nud_StartBeat.Value;
                    note.beatLength = (int)nud_Length.Value;

                    lb_Notes.Items[lb_Notes.SelectedIndex] 
                        = cb_Note.Items[cb_Note.SelectedIndex].ToString() + tb_Octave.Value + "(" + nud_StartBeat.Value + ")(" + nud_Length.Value + ")";
                }
            }
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            player.Abort();
        }

        private void tb_Octave_ValueChanged(object sender, EventArgs e)
        {
            lbl_Octave.Text = tb_Octave.Value.ToString();
            UpdateNote();
        }

        private void cb_Note_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateNote();
        }

        private void nud_StartBeat_ValueChanged(object sender, EventArgs e)
        {
            UpdateNote();
        }

        private void nud_Length_ValueChanged(object sender, EventArgs e)
        {
            UpdateNote();
        }

        private void lb_Notes_SelectedIndexChanged(object sender, MouseEventArgs e)
        {
            if (lb_Notes.Items.Count > 0)
            {
                if (lb_Notes.SelectedIndex != -1)
                {
                    var note = trackInfo.notes[lb_Notes.SelectedIndex];
                    tb_Octave.Value = note.octave;
                    cb_Note.SelectedIndex = note.currentNote;
                    nud_StartBeat.Value = note.beatStart;
                    nud_Length.Value = note.beatLength;
                }
            }
        }

        private void Sequencer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
