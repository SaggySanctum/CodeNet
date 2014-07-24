using Playground.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Playground
{
    public partial class RenderForm : Form
    {
        public RenderForm()
        {
            InitializeComponent();
        }

        public void Draw(IEnumerable<Simulatable> list)
        {
            using (Graphics g = this.CreateGraphics())
            {
                g.FillRectangle(Brushes.White, new Rectangle(0, 0, 1000, 1000));
                foreach (Simulatable item in list)
                {
                    g.FillRectangle(Brushes.Red, (int)(item.X), (int)(item.Y), 10, 10);
                }
            }
        }
    }
}
