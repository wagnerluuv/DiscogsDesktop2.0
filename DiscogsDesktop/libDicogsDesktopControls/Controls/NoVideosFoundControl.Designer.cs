namespace libDicogsDesktopControls.Controls
{
    partial class NoVideosFoundControl
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
            this.labelHint = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelHint
            // 
            this.labelHint.AutoSize = true;
            this.labelHint.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHint.ForeColor = System.Drawing.Color.IndianRed;
            this.labelHint.Location = new System.Drawing.Point(28, 14);
            this.labelHint.Name = "labelHint";
            this.labelHint.Size = new System.Drawing.Size(222, 25);
            this.labelHint.TabIndex = 0;
            this.labelHint.Text = "no youtube videos found";
            // 
            // NoVideosFoundControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelHint);
            this.Name = "NoVideosFoundControl";
            this.Size = new System.Drawing.Size(280, 56);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHint;
    }
}
