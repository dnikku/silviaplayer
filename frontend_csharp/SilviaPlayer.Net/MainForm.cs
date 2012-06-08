using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SilviaPlayer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            uxChannels.Items.AddRange(new AvailableChannels().GetChannels());

            NormalView(null, null);

            if (!DesignMode)
                uxPlayerCtl.CreatePlayer();
        }

        private void MinimalView(object sender, EventArgs e)
        {
            uxChannels.Hide();
            uxUrl.Hide();

            FormBorderStyle = FormBorderStyle.SizableToolWindow;
        }

        private void NormalView(object sender, EventArgs e)
        {
            uxChannels.Show();
            uxUrl.Show();

            TopMost = false;
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Normal;
        }

        private void FullScreenView(object sender, EventArgs e)
        {
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }

        private void uxChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            uxUrl.Text = ((Channel) uxChannels.SelectedItem).Url;
            uxPlayerCtl.Play(uxUrl.Text);
        }

        private void SetAlwaysOnTop(object sender, EventArgs e)
        {
            TopMost = alwaysOnTopToolStripMenuItem.Checked;
        }
    }
}
