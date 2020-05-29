using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Zynzezizer_cs.UI.PianoKeys
{
    class PianoLeftKey : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            int width = ClientSize.Width;
            int height = ClientSize.Height;

            Point[] myArray =
            {
                 new Point(0, 0),
                 new Point(width, 0),
                 new Point(width, height),
                 new Point(width * 3/5, height),
                 new Point(width * 3/5, height * 2/3),
                 new Point(0, height * 2/3)
             };

            // Create a GraphicsPath object and add a polygon.
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddPolygon(myArray);
            this.Region = new System.Drawing.Region(myPath);

            base.OnPaint(pevent);
        }
    }
}
