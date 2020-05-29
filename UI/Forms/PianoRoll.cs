using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using NAudio.Wave;
using Zynzezizer_cs.UI.PianoKeys;

namespace Zynzezizer_cs
{
    public partial class PianoRoll : Form
    {
        private static string Notes = "CBAGFED";

        private SynthEngine synthEngine;

        public PianoRoll(SynthEngine synthEngine)
        {
            InitializeComponent();
            this.synthEngine = synthEngine;
        }

        private void PianoRoll_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void PianoRoll_Load(object sender, EventArgs e)
        {
            var rowCount = 88;

            int buttonWidth = 50;
            int buttonHeight = 30;

            int octave = 8;
            int buttonLocation = 0;
            int noteId = 0;

            bool isNextSharp = false;

            for (int i = 0; i < rowCount; i++)
            {
                var currentNote = Notes[noteId % Notes.Length].ToString();

                Button button;

                if (isNextSharp)
                {
                    button = new Button();
                    button.Size = new Size(buttonWidth * 2 / 3, buttonHeight * 2 / 3);
                    button.Location = new Point(0, (buttonLocation * buttonHeight) - (buttonHeight * 1 / 3));
                    button.BackColor = Color.Black;
                    button.ForeColor = Color.White;
                    currentNote += (isNextSharp ? "#" : "");
                    isNextSharp = false;
                }
                else
                {
                    if (currentNote == "F" || currentNote == "C")
                    {
                        button = new PianoRightKey();
                    }
                    else if (currentNote == "E" || currentNote == "B")
                    {
                        button = new PianoLeftKey();
                        isNextSharp = true;
                    }
                    else
                    {
                        button = new PianoMiddleKey();
                        isNextSharp = true;
                    }
                    ++noteId;
                    button.Size = new Size(buttonWidth, buttonHeight);
                    button.Location = new Point(0, buttonLocation * buttonHeight);
                    ++buttonLocation;
                }

                if (currentNote == "C")
                {
                    --octave;
                    currentNote += octave.ToString();
                }

                button.Text = currentNote;
                button.Padding = new Padding(0);
                button.Name = string.Format("b{0}", rowCount - i - 1);

                button.MouseEnter += (o, me) =>
                {
                    int note = int.Parse(((Button)o).Name.Substring(1));
                    synthEngine.NoteOn(note);
                };

                button.MouseLeave += (o, me) =>
                {
                    var toParse = ((Button)o).Name.Substring(1);
                    int note = int.Parse(toParse);
                    synthEngine.NoteOff(note);
                };

                Controls.Add(button);
            }
        }
    }
}
