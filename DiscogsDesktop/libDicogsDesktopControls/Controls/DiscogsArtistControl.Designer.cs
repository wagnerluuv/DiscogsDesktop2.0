﻿namespace libDicogsDesktopControls.Controls
{
    partial class DiscogsArtistControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.linkLabelViewInbrowser = new System.Windows.Forms.LinkLabel();
            this.dataGridViewReleases = new System.Windows.Forms.DataGridView();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.panelRelease = new System.Windows.Forms.Panel();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.buttonExportReleases = new System.Windows.Forms.Button();
            this.buttonDownloadAllReleasesInList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReleases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkLabelViewInbrowser
            // 
            this.linkLabelViewInbrowser.AutoSize = true;
            this.linkLabelViewInbrowser.Location = new System.Drawing.Point(3, 221);
            this.linkLabelViewInbrowser.Name = "linkLabelViewInbrowser";
            this.linkLabelViewInbrowser.Size = new System.Drawing.Size(88, 13);
            this.linkLabelViewInbrowser.TabIndex = 13;
            this.linkLabelViewInbrowser.TabStop = true;
            this.linkLabelViewInbrowser.Text = "view in browser";
            this.linkLabelViewInbrowser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelViewInbrowserLinkClicked);
            // 
            // dataGridViewReleases
            // 
            this.dataGridViewReleases.AllowUserToAddRows = false;
            this.dataGridViewReleases.AllowUserToDeleteRows = false;
            this.dataGridViewReleases.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewReleases.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewReleases.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewReleases.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewReleases.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewReleases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReleases.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewReleases.Location = new System.Drawing.Point(3, 31);
            this.dataGridViewReleases.MultiSelect = false;
            this.dataGridViewReleases.Name = "dataGridViewReleases";
            this.dataGridViewReleases.ReadOnly = true;
            this.dataGridViewReleases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReleases.Size = new System.Drawing.Size(619, 173);
            this.dataGridViewReleases.TabIndex = 10;
            this.dataGridViewReleases.SelectionChanged += new System.EventHandler(this.dataGridViewReleasesSelectionChanged);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(109, 3);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 12;
            this.buttonSearch.Text = "search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearchClick);
            // 
            // panelRelease
            // 
            this.panelRelease.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRelease.Location = new System.Drawing.Point(3, 3);
            this.panelRelease.Name = "panelRelease";
            this.panelRelease.Size = new System.Drawing.Size(619, 199);
            this.panelRelease.TabIndex = 11;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(3, 3);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(100, 22);
            this.textBoxSearch.TabIndex = 9;
            this.textBoxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSearchKeyPress);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(179, 48);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.buttonExportReleases);
            this.splitContainer.Panel1.Controls.Add(this.buttonDownloadAllReleasesInList);
            this.splitContainer.Panel1.Controls.Add(this.dataGridViewReleases);
            this.splitContainer.Panel1.Controls.Add(this.textBoxSearch);
            this.splitContainer.Panel1.Controls.Add(this.buttonSearch);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panelRelease);
            this.splitContainer.Size = new System.Drawing.Size(625, 416);
            this.splitContainer.SplitterDistance = 207;
            this.splitContainer.TabIndex = 14;
            // 
            // buttonExportReleases
            // 
            this.buttonExportReleases.Location = new System.Drawing.Point(330, 3);
            this.buttonExportReleases.Name = "buttonExportReleases";
            this.buttonExportReleases.Size = new System.Drawing.Size(127, 23);
            this.buttonExportReleases.TabIndex = 14;
            this.buttonExportReleases.TabStop = false;
            this.buttonExportReleases.Text = "export all releases";
            this.buttonExportReleases.UseVisualStyleBackColor = true;
            this.buttonExportReleases.Click += new System.EventHandler(this.buttonExportReleasesClick);
            // 
            // buttonDownloadAllReleasesInList
            // 
            this.buttonDownloadAllReleasesInList.Location = new System.Drawing.Point(190, 3);
            this.buttonDownloadAllReleasesInList.Name = "buttonDownloadAllReleasesInList";
            this.buttonDownloadAllReleasesInList.Size = new System.Drawing.Size(134, 23);
            this.buttonDownloadAllReleasesInList.TabIndex = 13;
            this.buttonDownloadAllReleasesInList.TabStop = false;
            this.buttonDownloadAllReleasesInList.Text = "download all releases";
            this.buttonDownloadAllReleasesInList.UseVisualStyleBackColor = true;
            this.buttonDownloadAllReleasesInList.Click += new System.EventHandler(this.buttonDownloadAllReleasesInListClick);
            // 
            // DiscogsArtistControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.linkLabelViewInbrowser);
            this.Name = "DiscogsArtistControl";
            this.Size = new System.Drawing.Size(807, 467);
            this.Controls.SetChildIndex(this.linkLabelViewInbrowser, 0);
            this.Controls.SetChildIndex(this.splitContainer, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReleases)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabelViewInbrowser;
        private System.Windows.Forms.DataGridView dataGridViewReleases;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Panel panelRelease;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button buttonExportReleases;
        private System.Windows.Forms.Button buttonDownloadAllReleasesInList;
    }
}
