using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zynzezizer_cs
{
    class LFO
    {
        public Func<float, float> Function { get; set; }
        public float Amplitude;
        public float frequency;
    }
}
