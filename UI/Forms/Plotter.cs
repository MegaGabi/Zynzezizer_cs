using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zynzezizer_cs
{
    public partial class Plotter : Form
    {
        public Plotter(Func<float, float> toGraph)
        {
            InitializeComponent();

            int sampleRate = 1000;
            var osc = new FilteredOscillator(sampleRate);
            osc.Function = toGraph;
            float[] result = new float[sampleRate * 2];
            osc.Frequency = 4;
            osc.NoteOn();
            osc.Read(result, 0, result.Length);

            for (int i = 0; i < result.Length; ++i)
            { 
                chrt_Plot.Series["Graph"].Points.AddXY(i, result[i]);
            }
        }
    }
}
