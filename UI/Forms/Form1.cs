using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Zynzezizer_cs
{
    public partial class Form1 : Form
    {
        private PianoRoll pianoRoll;
        private Synthesizers synthesizers;
        private Sequencer sequencer;
        private TrackInfo trackInfo;
        private SynthEngine synthEngine;
        private AsioOut audioOutput;

        public Form1()
        {
            InitializeComponent();
            InitAudio();
        }

        private void InitAudio()
        {
            synthEngine = new SynthEngine(48000, 32) { Amplitude = 0.1f };
            trackInfo = new TrackInfo();

            audioOutput = new AsioOut();
            audioOutput.Init(synthEngine);
            audioOutput.Play();
        }

        private void pianoRollToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (pianoRoll == null)
            {
                pianoRoll = new PianoRoll(synthEngine);
                pianoRoll.MdiParent = this;
                pianoRoll.Show();
            }
            else if(!pianoRoll.Visible)
            {
                pianoRoll.Show();
            }
        }

        private void synthesizerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(synthesizers == null)
            {
                synthesizers = new Synthesizers(synthEngine);
                synthesizers.MdiParent = this;
                synthesizers.Show();
            }
            else if(!synthesizers.Visible)
            {
                synthesizers.Show();
            }
        }

        private void sequencerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sequencer == null)
            {
                sequencer = new Sequencer(synthEngine, trackInfo);
                sequencer.MdiParent = this;
                sequencer.Show();
            }
            else if (!sequencer.Visible)
            {
                sequencer.Show();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            audioOutput.Stop();
        }
    }
}
