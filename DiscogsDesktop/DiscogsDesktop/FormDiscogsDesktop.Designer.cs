namespace DiscogsDesktop
{
    sealed partial class FormDiscogsDesktop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDiscogsDesktop));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButtonSettings = new System.Windows.Forms.ToolStripDropDownButton();
            this.tokenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maxItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxMaxItems = new System.Windows.Forms.ToolStripTextBox();
            this.tableFontSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBoxTableFontSize = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.deleteFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelView = new System.Windows.Forms.Panel();
            this.syncCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButtonSettings,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(851, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButtonSettings
            // 
            this.toolStripDropDownButtonSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tokenToolStripMenuItem,
            this.folderToolStripMenuItem,
            this.maxItemsToolStripMenuItem,
            this.tableFontSizeToolStripMenuItem});
            this.toolStripDropDownButtonSettings.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonSettings.Image")));
            this.toolStripDropDownButtonSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonSettings.Name = "toolStripDropDownButtonSettings";
            this.toolStripDropDownButtonSettings.Size = new System.Drawing.Size(61, 22);
            this.toolStripDropDownButtonSettings.Text = "settings";
            // 
            // tokenToolStripMenuItem
            // 
            this.tokenToolStripMenuItem.Name = "tokenToolStripMenuItem";
            this.tokenToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.tokenToolStripMenuItem.Text = "token";
            this.tokenToolStripMenuItem.Click += new System.EventHandler(this.tokenToolStripMenuItemClick);
            // 
            // folderToolStripMenuItem
            // 
            this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            this.folderToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.folderToolStripMenuItem.Text = "folder";
            this.folderToolStripMenuItem.Click += new System.EventHandler(this.folderToolStripMenuItemClick);
            // 
            // maxItemsToolStripMenuItem
            // 
            this.maxItemsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxMaxItems});
            this.maxItemsToolStripMenuItem.Name = "maxItemsToolStripMenuItem";
            this.maxItemsToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.maxItemsToolStripMenuItem.Text = "export field in title";
            this.maxItemsToolStripMenuItem.ToolTipText = "defines how many items will bei displayed when a search is submitted";
            // 
            // toolStripTextBoxMaxItems
            // 
            this.toolStripTextBoxMaxItems.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxMaxItems.Name = "toolStripTextBoxMaxItems";
            this.toolStripTextBoxMaxItems.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxMaxItems.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBoxMaxItemsKeyPress);
            // 
            // tableFontSizeToolStripMenuItem
            // 
            this.tableFontSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBoxTableFontSize});
            this.tableFontSizeToolStripMenuItem.Name = "tableFontSizeToolStripMenuItem";
            this.tableFontSizeToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.tableFontSizeToolStripMenuItem.Text = "table font size";
            // 
            // toolStripTextBoxTableFontSize
            // 
            this.toolStripTextBoxTableFontSize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBoxTableFontSize.Name = "toolStripTextBoxTableFontSize";
            this.toolStripTextBoxTableFontSize.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBoxTableFontSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripTextBoxTableFontSizeKeyPress);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.syncCollectionToolStripMenuItem,
            this.clearCacheToolStripMenuItem,
            this.deleteFilesToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(58, 22);
            this.toolStripDropDownButton1.Text = "actions";
            // 
            // deleteFilesToolStripMenuItem
            // 
            this.deleteFilesToolStripMenuItem.Name = "deleteFilesToolStripMenuItem";
            this.deleteFilesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteFilesToolStripMenuItem.Text = "delete files";
            this.deleteFilesToolStripMenuItem.Click += new System.EventHandler(this.deleteFilesToolStripMenuItemClick);
            // 
            // clearCacheToolStripMenuItem
            // 
            this.clearCacheToolStripMenuItem.Name = "clearCacheToolStripMenuItem";
            this.clearCacheToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearCacheToolStripMenuItem.Text = "clear cache";
            this.clearCacheToolStripMenuItem.Click += new System.EventHandler(this.clearCacheToolStripMenuItemClick);
            // 
            // panelView
            // 
            this.panelView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelView.Location = new System.Drawing.Point(0, 25);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(851, 428);
            this.panelView.TabIndex = 1;
            // 
            // syncCollectionToolStripMenuItem
            // 
            this.syncCollectionToolStripMenuItem.Name = "syncCollectionToolStripMenuItem";
            this.syncCollectionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.syncCollectionToolStripMenuItem.Text = "sync collection";
            this.syncCollectionToolStripMenuItem.Click += new System.EventHandler(this.syncCollectionToolStripMenuItemClick);
            // 
            // FormDiscogsDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 453);
            this.Controls.Add(this.panelView);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormDiscogsDesktop";
            this.Text = "DiscogsDesktop";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonSettings;
        private System.Windows.Forms.ToolStripMenuItem tokenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
        private System.Windows.Forms.Panel panelView;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem deleteFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maxItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxMaxItems;
        private System.Windows.Forms.ToolStripMenuItem tableFontSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxTableFontSize;
        private System.Windows.Forms.ToolStripMenuItem clearCacheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem syncCollectionToolStripMenuItem;
    }
}

