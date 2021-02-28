using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nikse.SubtitleEdit.Controls
{
    public sealed class CuesPreviewView: Panel
    {
        private float frameRate = 25f;
        private string previewText = "Subtitle text.";
        private bool showShotChange = true;

        private int leftGap = 0;
        private int leftRedZone = 7;
        private int leftGreenZone = 12;

        private int rightGap = 0;
        private int rightRedZone = 7;
        private int rightGreenZone = 12;

        public float FrameRate
        {
            get { return frameRate; }
            set { frameRate = value; Invalidate(); }
        }

        public string PreviewText
        {
            get { return previewText; }
            set { previewText = value; Invalidate(); }
        }

        public bool ShowShotChange
        {
            get { return showShotChange; }
            set { showShotChange = value; Invalidate(); }
        }

        public int LeftGap
        {
            get { return leftGap; }
            set { leftGap = value; Invalidate(); }
        }

        public int LeftRedZone
        {
            get { return leftRedZone; }
            set { leftRedZone = value; Invalidate(); }
        }

        public int LeftGreenZone
        {
            get { return leftGreenZone; }
            set { leftGreenZone = value; Invalidate(); }
        }

        public int RightGap
        {
            get { return rightGap; }
            set { rightGap = value; Invalidate(); }
        }

        public int RightRedZone
        {
            get { return rightRedZone; }
            set { rightRedZone = value; Invalidate(); }
        }

        public int RightGreenZone
        {
            get { return rightGreenZone; }
            set { rightGreenZone = value; Invalidate(); }
        }
        
        public CuesPreviewView()
        {
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // TODO test
        }
    }
}
