using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RA_API
{
    public partial class MyProgressBar : ProgressBar
    {
        public MyProgressBar()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Rectangle rect = this.ClientRectangle;
            Graphics g = pe.Graphics;
            ProgressBarRenderer.DrawHorizontalBar(g, rect);
            if(this.Value > 0)
            {
                Rectangle clip = new Rectangle(rect.X, rect.Y, (int)Math.Round(((float)this.Value / this.Maximum) * rect.Width), rect.Height);
                ProgressBarRenderer.DrawHorizontalBar(g, clip);
                g.FillRectangle(Brushes.Coral, clip);
            }
            using (Font f = new Font(FontFamily.GenericMonospace, 10))
            {
                SizeF size = g.MeasureString(string.Format("{0} %", this.Value), f);
                Point location = new Point((int)((rect.Width / 2) - (size.Width / 2)), (int)((rect.Height / 2) - (size.Height / 2) + 2));
                double percentage = ((double)this.Value / (double)this.Maximum) * 100; 
                g.DrawString(string.Format("{0} %", percentage), f, Brushes.Black, location);
            }
            //base.OnPaint(pe);
        }
    }
}
