using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zynzezizer_cs
{
    public class TrackNoteInfo
    {
        public int currentNote;
        public int octave;
        public int beatLength;
        public int beatStart;
    }

    public class TrackInfo
    {
        public int BPM;
        public List<TrackNoteInfo> notes;

        public TrackInfo()
        {
            notes = new List<TrackNoteInfo>();
            BPM = 0;
        }
    }
}
