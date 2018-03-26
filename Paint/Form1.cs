using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Painter : Form
    {
        bool shouldPaint = false;
        string colorvar = "Blue";
        int brushSize = 4;

        public Painter()
        {
            InitializeComponent();
        }

        private void Painter_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) shouldPaint = true;
        }

        private void Painter_MouseUp(object sender, MouseEventArgs e)
        {
            shouldPaint = false;
        }

        private void Pinter_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip_Menu.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void Painter_MouseMove(object sender, MouseEventArgs e)
        {
            if (shouldPaint)
            {
                Graphics graphics = CreateGraphics();
                graphics.FillEllipse(new SolidBrush(Color.FromName(colorvar)), e.X, e.Y, brushSize, brushSize);
            }
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            colorvar = menuItem.Text;
            brushSize = 4;
            Cursor = Cursors.Hand;
            UpdateStatus();
        }

        private void eraseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorvar = "white";
            brushSize = 15;
            Cursor = Cursors.Cross;
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            panel_Color.BackColor = Color.FromName(colorvar);
        }

        private void clearToolStripMenuItem_click(object sender, EventArgs e)
        {
            Painter.ActiveForm.Refresh();
        }
    }
}
