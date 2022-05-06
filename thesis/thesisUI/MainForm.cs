using System;
using System.Windows.Forms;

namespace thesisUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Suported files|*.png;*.jpg;*.jpeg|All files|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ChildWindow window = new ChildWindow(ofd.FileName)
                {
                    MdiParent = this,
                    WindowState = FormWindowState.Maximized
                };
                window.Show();
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
            ChildWindow window = (ChildWindow)this.ActiveMdiChild;
            window.Save();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildWindow window = (ChildWindow)this.ActiveMdiChild;
            window.SaveAs();
        }
    }
}
