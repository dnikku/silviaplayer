namespace SilviaPlayer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.uxChannels = new System.Windows.Forms.ListBox();
            this.uxUrl = new System.Windows.Forms.TextBox();
            this.uxContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uxPlayerCtl = new SilviaPlayer.PlayerContainer();
            this.uxContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxChannels
            // 
            this.uxChannels.Dock = System.Windows.Forms.DockStyle.Right;
            this.uxChannels.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxChannels.FormattingEnabled = true;
            this.uxChannels.ItemHeight = 23;
            this.uxChannels.Location = new System.Drawing.Point(339, 0);
            this.uxChannels.Name = "uxChannels";
            this.uxChannels.Size = new System.Drawing.Size(177, 273);
            this.uxChannels.TabIndex = 0;
            this.uxChannels.SelectedIndexChanged += new System.EventHandler(this.uxChannels_SelectedIndexChanged);
            // 
            // uxUrl
            // 
            this.uxUrl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uxUrl.Location = new System.Drawing.Point(0, 273);
            this.uxUrl.Name = "uxUrl";
            this.uxUrl.Size = new System.Drawing.Size(516, 20);
            this.uxUrl.TabIndex = 1;
            // 
            // uxContextMenu
            // 
            this.uxContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.alwaysOnTopToolStripMenuItem});
            this.uxContextMenu.Name = "uxContextMenu";
            this.uxContextMenu.Size = new System.Drawing.Size(155, 92);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem1.Text = "Minimal View";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.MinimalView);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem2.Text = "Normal View";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.NormalView);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem3.Text = "Full Screen";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.FullScreenView);
            // 
            // alwaysOnTopToolStripMenuItem
            // 
            this.alwaysOnTopToolStripMenuItem.CheckOnClick = true;
            this.alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
            this.alwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.alwaysOnTopToolStripMenuItem.Text = "Always On Top";
            this.alwaysOnTopToolStripMenuItem.Click += new System.EventHandler(this.SetAlwaysOnTop);
            // 
            // uxPlayerCtl
            // 
            this.uxPlayerCtl.BackColor = System.Drawing.Color.Black;
            this.uxPlayerCtl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxPlayerCtl.Location = new System.Drawing.Point(0, 0);
            this.uxPlayerCtl.Name = "uxPlayerCtl";
            this.uxPlayerCtl.Size = new System.Drawing.Size(339, 273);
            this.uxPlayerCtl.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 293);
            this.ContextMenuStrip = this.uxContextMenu;
            this.Controls.Add(this.uxPlayerCtl);
            this.Controls.Add(this.uxChannels);
            this.Controls.Add(this.uxUrl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "SilviaPlayer.Net";
            this.uxContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox uxChannels;
        private System.Windows.Forms.TextBox uxUrl;
        private PlayerContainer uxPlayerCtl;
        private System.Windows.Forms.ContextMenuStrip uxContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem;
    }
}