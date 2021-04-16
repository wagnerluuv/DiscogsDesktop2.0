using System;
using JetBrains.Annotations;

namespace libDicogsDesktopControls.Controls
{
    sealed partial class HomeViewControl
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearchPattern = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelSelected = new System.Windows.Forms.Panel();
            this.soundPlayer1 = new libDicogsDesktopControls.Controls.SoundPlayerControl();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.labelUserName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonCollection = new System.Windows.Forms.RadioButton();
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            this.buttonDownloadAllReleasesInList = new System.Windows.Forms.Button();
            this.buttonExportReleases = new System.Windows.Forms.Button();
            this.textBoxotherUser = new System.Windows.Forms.TextBox();
            this.buttonFindUserCollection = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(118, 5);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 0;
            this.buttonSearch.TabStop = false;
            this.buttonSearch.Text = "search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.button1Click);
            // 
            // textBoxSearchPattern
            // 
            this.textBoxSearchPattern.Location = new System.Drawing.Point(12, 5);
            this.textBoxSearchPattern.Name = "textBoxSearchPattern";
            this.textBoxSearchPattern.Size = new System.Drawing.Size(100, 22);
            this.textBoxSearchPattern.TabIndex = 0;
            this.textBoxSearchPattern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSearchPatternKeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(708, 704);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1SelectionChanged);
            // 
            // panelSelected
            // 
            this.panelSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSelected.Location = new System.Drawing.Point(2, 0);
            this.panelSelected.Name = "panelSelected";
            this.panelSelected.Size = new System.Drawing.Size(698, 616);
            this.panelSelected.TabIndex = 3;
            // 
            // soundPlayer1
            // 
            this.soundPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.soundPlayer1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soundPlayer1.Location = new System.Drawing.Point(2, 622);
            this.soundPlayer1.Name = "soundPlayer1";
            this.soundPlayer1.Size = new System.Drawing.Size(701, 82);
            this.soundPlayer1.TabIndex = 4;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(3, 32);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panelSelected);
            this.splitContainer.Panel2.Controls.Add(this.soundPlayer1);
            this.splitContainer.Size = new System.Drawing.Size(1415, 704);
            this.splitContainer.SplitterDistance = 708;
            this.splitContainer.TabIndex = 5;
            // 
            // labelUserName
            // 
            this.labelUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUserName.Location = new System.Drawing.Point(1165, 5);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(250, 24);
            this.labelUserName.TabIndex = 6;
            this.labelUserName.Text = "logged in as:";
            this.labelUserName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonCollection);
            this.panel1.Controls.Add(this.radioButtonAll);
            this.panel1.Location = new System.Drawing.Point(199, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(128, 26);
            this.panel1.TabIndex = 7;
            // 
            // radioButtonCollection
            // 
            this.radioButtonCollection.AutoSize = true;
            this.radioButtonCollection.Location = new System.Drawing.Point(46, 6);
            this.radioButtonCollection.Name = "radioButtonCollection";
            this.radioButtonCollection.Size = new System.Drawing.Size(75, 17);
            this.radioButtonCollection.TabIndex = 1;
            this.radioButtonCollection.Text = "collection";
            this.radioButtonCollection.UseVisualStyleBackColor = true;
            this.radioButtonCollection.CheckedChanged += new System.EventHandler(this.radioButtonCollectionCheckedChanged);
            // 
            // radioButtonAll
            // 
            this.radioButtonAll.AutoSize = true;
            this.radioButtonAll.Checked = true;
            this.radioButtonAll.Location = new System.Drawing.Point(3, 6);
            this.radioButtonAll.Name = "radioButtonAll";
            this.radioButtonAll.Size = new System.Drawing.Size(37, 17);
            this.radioButtonAll.TabIndex = 0;
            this.radioButtonAll.TabStop = true;
            this.radioButtonAll.Text = "all";
            this.radioButtonAll.UseVisualStyleBackColor = true;
            // 
            // buttonDownloadAllReleasesInList
            // 
            this.buttonDownloadAllReleasesInList.Location = new System.Drawing.Point(496, 6);
            this.buttonDownloadAllReleasesInList.Name = "buttonDownloadAllReleasesInList";
            this.buttonDownloadAllReleasesInList.Size = new System.Drawing.Size(171, 23);
            this.buttonDownloadAllReleasesInList.TabIndex = 8;
            this.buttonDownloadAllReleasesInList.TabStop = false;
            this.buttonDownloadAllReleasesInList.Text = "download all releases in list";
            this.buttonDownloadAllReleasesInList.UseVisualStyleBackColor = true;
            this.buttonDownloadAllReleasesInList.Click += new System.EventHandler(this.buttonDownloadAllReleasesInListClick);
            // 
            // buttonExportReleases
            // 
            this.buttonExportReleases.Location = new System.Drawing.Point(673, 6);
            this.buttonExportReleases.Name = "buttonExportReleases";
            this.buttonExportReleases.Size = new System.Drawing.Size(171, 23);
            this.buttonExportReleases.TabIndex = 9;
            this.buttonExportReleases.TabStop = false;
            this.buttonExportReleases.Text = "export all releases in list";
            this.buttonExportReleases.UseVisualStyleBackColor = true;
            this.buttonExportReleases.Click += new System.EventHandler(this.buttonExportReleasesClick);
            // 
            // textBoxotherUser
            // 
            this.textBoxotherUser.Location = new System.Drawing.Point(333, 5);
            this.textBoxotherUser.Name = "textBoxotherUser";
            this.textBoxotherUser.Size = new System.Drawing.Size(128, 22);
            this.textBoxotherUser.TabIndex = 10;
            // 
            // buttonFindUserCollection
            // 
            this.buttonFindUserCollection.Location = new System.Drawing.Point(465, 4);
            this.buttonFindUserCollection.Name = "buttonFindUserCollection";
            this.buttonFindUserCollection.Size = new System.Drawing.Size(25, 23);
            this.buttonFindUserCollection.TabIndex = 11;
            this.buttonFindUserCollection.TabStop = false;
            this.buttonFindUserCollection.Text = "export all releases in list";
            this.buttonFindUserCollection.UseVisualStyleBackColor = true;
            this.buttonFindUserCollection.Click += new System.EventHandler(this.buttonFindUserCollection_Click);
            // 
            // HomeViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonFindUserCollection);
            this.Controls.Add(this.textBoxotherUser);
            this.Controls.Add(this.buttonExportReleases);
            this.Controls.Add(this.buttonDownloadAllReleasesInList);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.textBoxSearchPattern);
            this.Controls.Add(this.buttonSearch);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "HomeViewControl";
            this.Size = new System.Drawing.Size(1418, 739);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearchPattern;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panelSelected;
        private Controls.SoundPlayerControl soundPlayer1;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonCollection;
        private System.Windows.Forms.RadioButton radioButtonAll;
        private System.Windows.Forms.Button buttonDownloadAllReleasesInList;
        private System.Windows.Forms.Button buttonExportReleases;
        private System.Windows.Forms.TextBox textBoxotherUser;
        private System.Windows.Forms.Button buttonFindUserCollection;
    }
}
