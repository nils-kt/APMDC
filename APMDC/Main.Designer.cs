
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
            this.taskIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.rightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.quit = new System.Windows.Forms.ToolStripMenuItem();
            this.rightClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // taskIcon
            // 
            this.taskIcon.ContextMenuStrip = this.rightClick;
            this.taskIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("taskIcon.Icon")));
            this.taskIcon.Text = "Apple Music Discord Rich Presence";
            this.taskIcon.Visible = true;
            // 
            // rightClick
            // 
            this.rightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quit});
            this.rightClick.Name = "rightClick";
            this.rightClick.Size = new System.Drawing.Size(181, 48);
            this.rightClick.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.rightClick_ItemClicked);
            // 
            // quit
            // 
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(180, 22);
            this.quit.Text = "Quit";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 161);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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

        private System.Windows.Forms.NotifyIcon taskIcon;
        private System.Windows.Forms.ContextMenuStrip rightClick;
        private System.Windows.Forms.ToolStripMenuItem quit;
    }
}

