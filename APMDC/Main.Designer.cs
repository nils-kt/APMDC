
using System;

namespace APMDC
{
    partial class Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            taskIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.rightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.quit = new System.Windows.Forms.ToolStripMenuItem();
            this.supportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itunesversion = new System.Windows.Forms.ToolStripMenuItem();
            this.generateIssue = new System.Windows.Forms.ToolStripMenuItem();
            this.apmdcversion = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.save = new System.Windows.Forms.Button();
            this.shareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // taskIcon
            // 
            taskIcon.ContextMenuStrip = this.rightClick;
            taskIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("taskIcon.Icon")));
            taskIcon.Text = "Apple Music Discord Rich Presence";
            taskIcon.Visible = true;
            // 
            // rightClick
            // 
            this.rightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shareToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.supportToolStripMenuItem,
            this.quit});
            this.rightClick.Name = "rightClick";
            this.rightClick.Size = new System.Drawing.Size(181, 114);
            // 
            // quit
            // 
            this.quit.Image = ((System.Drawing.Image)(resources.GetObject("quit.Image")));
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(180, 22);
            this.quit.Text = "Quit";
            this.quit.Click += new System.EventHandler(this.quit_Click);
            // 
            // supportToolStripMenuItem
            // 
            this.supportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itunesversion,
            this.apmdcversion,
            this.generateIssue});
            this.supportToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("supportToolStripMenuItem.Image")));
            this.supportToolStripMenuItem.Name = "supportToolStripMenuItem";
            this.supportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.supportToolStripMenuItem.Text = "Support";
            // 
            // itunesversion
            // 
            this.itunesversion.Enabled = false;
            this.itunesversion.Image = ((System.Drawing.Image)(resources.GetObject("itunesversion.Image")));
            this.itunesversion.Name = "itunesversion";
            this.itunesversion.Size = new System.Drawing.Size(180, 22);
            this.itunesversion.Text = "itunesversion";
            // 
            // generateIssue
            // 
            this.generateIssue.Image = ((System.Drawing.Image)(resources.GetObject("generateIssue.Image")));
            this.generateIssue.Name = "generateIssue";
            this.generateIssue.Size = new System.Drawing.Size(180, 22);
            this.generateIssue.Text = "Generate Issue";
            this.generateIssue.Click += new System.EventHandler(this.generateIssue_Click);
            // 
            // apmdcversion
            // 
            this.apmdcversion.Enabled = false;
            this.apmdcversion.Image = ((System.Drawing.Image)(resources.GetObject("apmdcversion.Image")));
            this.apmdcversion.Name = "apmdcversion";
            this.apmdcversion.Size = new System.Drawing.Size(180, 22);
            this.apmdcversion.Text = "apmdcversion";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("settingsToolStripMenuItem.Image")));
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(161, 127);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(81, 22);
            this.save.TabIndex = 1;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // shareToolStripMenuItem
            // 
            this.shareToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("shareToolStripMenuItem.Image")));
            this.shareToolStripMenuItem.Name = "shareToolStripMenuItem";
            this.shareToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.shareToolStripMenuItem.Text = "Share";
            this.shareToolStripMenuItem.Click += new System.EventHandler(this.shareToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 161);
            this.Controls.Add(this.save);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(270, 200);
            this.MinimumSize = new System.Drawing.Size(270, 200);
            this.Name = "Main";
            this.ShowInTaskbar = false;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Closed += new System.EventHandler(this.Main_Closed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.rightClick.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public static System.Windows.Forms.NotifyIcon taskIcon;
        private System.Windows.Forms.ContextMenuStrip rightClick;
        private System.Windows.Forms.ToolStripMenuItem quit;
        private System.Windows.Forms.ToolStripMenuItem supportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itunesversion;
        private System.Windows.Forms.ToolStripMenuItem generateIssue;
        private System.Windows.Forms.ToolStripMenuItem apmdcversion;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.ToolStripMenuItem shareToolStripMenuItem;
    }
}

