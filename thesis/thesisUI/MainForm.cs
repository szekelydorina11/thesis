using System;
using System.Windows.Forms;

namespace thesisUI
{
    public partial class MainForm : Form
    {
        bool isOpen = false;
        public MainForm()
        {
            InitializeComponent();
            if (isOpen == false)
            {
                tileToolStripMenuItem.Enabled = false;
                exitToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
                //saveToolStripMenuItem.Enabled = false;
                windowsToolStripMenuItem.Enabled = false;
            }
            else
            {
                tileToolStripMenuItem.Enabled = true;
                exitToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                //saveToolStripMenuItem.Enabled = true;
                saveToolStripMenuItem.Visible = false;
                windowsToolStripMenuItem.Enabled = true;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Suported files|*.png;*.jpg;*.jpeg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ChildWindow window = new ChildWindow(ofd.FileName)
                {
                    MdiParent = this,
                    WindowState = FormWindowState.Maximized
                };
                window.Show();
                isOpen = true;
                tileToolStripMenuItem.Enabled = true;
                exitToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                //saveToolStripMenuItem.Enabled = true;
                saveToolStripMenuItem.Visible = false;
                windowsToolStripMenuItem.Enabled = true;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Biztosan ki akarsz lépni?", "Kérdés", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);

        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);

        }

        private void arrangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildWindow window = null;
            if (window != null)
            {
                window = (ChildWindow)this.ActiveMdiChild;
                window.Save();
            }
            else
            {
                MessageBox.Show("Tölts be egy képet!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildWindow window = null;
            if (window != null)
            {
                window = (ChildWindow)this.ActiveMdiChild;
                window.Save();
            }
            else
            {
                MessageBox.Show("Tölts be egy képet!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
