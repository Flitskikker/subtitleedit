using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nikse.SubtitleEdit.Core.Common;
using Nikse.SubtitleEdit.Logic;

namespace Nikse.SubtitleEdit.Controls
{
    public sealed class CuesPreviewView: Panel
    {
        private float _frameRate = 25f;
        private string _previewText = "Subtitle text.";
        private bool _showShotChange = true;

        private int _leftGap = 0;
        private int _leftRedZone = 7;
        private int _leftGreenZone = 12;

        private int _rightGap = 0;
        private int _rightRedZone = 7;
        private int _rightGreenZone = 12;

        public float FrameRate
        {
            get { return _frameRate; }
            set { _frameRate = value; Invalidate(); }
        }

        public string PreviewText
        {
            get { return _previewText; }
            set { _previewText = value; Invalidate(); }
        }

        public bool ShowShotChange
        {
            get { return _showShotChange; }
            set { _showShotChange = value; Invalidate(); }
        }

        public int LeftGap
        {
            get { return _leftGap; }
            set { _leftGap = value; Invalidate(); }
        }

        public int LeftRedZone
        {
            get { return _leftRedZone; }
            set { _leftRedZone = value; Invalidate(); }
        }

        public int LeftGreenZone
        {
            get { return _leftGreenZone; }
            set { _leftGreenZone = value; Invalidate(); }
        }

        public int RightGap
        {
            get { return _rightGap; }
            set { _rightGap = value; Invalidate(); }
        }

        public int RightRedZone
        {
            get { return _rightRedZone; }
            set { _rightRedZone = value; Invalidate(); }
        }

        public int RightGreenZone
        {
            get { return _rightGreenZone; }
            set { _rightGreenZone = value; Invalidate(); }
        }
        
        public CuesPreviewView()
        {
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            using (var brush = new SolidBrush(Color.White))
            {
                float width = this.Size.Width;
                float height = this.Size.Height;

                // Background
                brush.Color = Color.Gray;
                e.Graphics.FillRectangle(brush, 0, 0, width, height);

                // Green zones
                brush.Color = Color.Green;
                e.Graphics.FillRectangle(brush, (width / 2) - FramesToPixels(this.LeftGreenZone), 0, FramesToPixels(this.LeftGreenZone), height);
                e.Graphics.FillRectangle(brush, width / 2, 0, FramesToPixels(this.RightGreenZone), height);

                // Red zone
                brush.Color = Color.Firebrick;
                e.Graphics.FillRectangle(brush, (width / 2) - FramesToPixels(this.LeftRedZone), 0, FramesToPixels(this.LeftRedZone), height);
                e.Graphics.FillRectangle(brush, width / 2, 0, FramesToPixels(this.RightRedZone), height);

                // Subtitle
                brush.Color = Color.FromArgb(153, 0, 0, 0);
                e.Graphics.FillRectangle(brush, 0, 0, (width / 2) - FramesToPixels(this.LeftGap), height);
                e.Graphics.FillRectangle(brush, (width / 2) + FramesToPixels(this.RightGap), 0, (width / 2) - FramesToPixels(this.RightGap), height);

                brush.Color = Color.White;
                if (this.LeftGap <= 12)
                {
                    e.Graphics.DrawString(GetSubtitleLabel(1000, GetLeftOutCue()), UiUtil.GetDefaultFont(), brush, new RectangleF(5, 5, (width / 2) - FramesToPixels(this.LeftGap) - 10, height - 10));
                }
                if (this.RightGap <= 12)
                {
                    e.Graphics.DrawString(GetSubtitleLabel(GetRightInCue(), 5000), UiUtil.GetDefaultFont(), brush, new RectangleF((width / 2) + FramesToPixels(this.RightGap) + 5, 5, (width / 2) - FramesToPixels(this.RightGap) - 10, height - 10));
                }

                // Shot change
                if (this.ShowShotChange)
                {
                    brush.Color = Color.PaleGreen;
                    e.Graphics.FillRectangle(brush, (width / 2) - (1.5f), 0, 3f, height);
                }
            }
        }

        private float FramesToPixels(float frames)
        {
            return (Size.Width / (this.FrameRate * 3)) * frames;
        }

        private double GetLeftOutCue()
        {
            return 3000 - (this.LeftGap * (1000 / this.FrameRate));
        }

        private double GetRightInCue()
        {
            return 3000 + (this.RightGap * (1000 / this.FrameRate));
        }

        private string GetSubtitleLabel(double start, double end)
        {
            var timeCodeStart = new TimeCode(start);
            var timeCodeEnd = new TimeCode(end);
            return timeCodeStart.ToString() + " --> " + timeCodeEnd.ToString() + Environment.NewLine + this.PreviewText;
        }
    }
}
