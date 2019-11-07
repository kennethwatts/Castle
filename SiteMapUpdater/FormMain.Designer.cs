namespace SiteMapUpdater
{
    partial class FormMain
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
            this.labelSiteMapOld = new System.Windows.Forms.Label();
            this.textBoxSiteMapOld = new System.Windows.Forms.TextBox();
            this.buttonBrowseSiteMapOld = new System.Windows.Forms.Button();
            this.buttonBrowseOutputPath = new System.Windows.Forms.Button();

            //for new  button
            this.labelSiteMapNew = new System.Windows.Forms.Label();
            this.textBoxSiteMapNew = new System.Windows.Forms.TextBox();
            this.buttonBrowseSiteMapNew = new System.Windows.Forms.Button();
           


            this.textBoxOutputPath = new System.Windows.Forms.TextBox();
            this.labelOutputPath = new System.Windows.Forms.Label();
            this.buttonGo = new System.Windows.Forms.Button();
            this.ofdSiteMapUpdater = new System.Windows.Forms.OpenFileDialog();
            this.fbdOutput = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // labelDataContract
            // 
            this.labelSiteMapOld.AutoSize = true;
            this.labelSiteMapOld.Location = new System.Drawing.Point(3, 13);
            this.labelSiteMapOld.Name = "labelOldFile";
            this.labelSiteMapOld.Size = new System.Drawing.Size(73, 13);
            this.labelSiteMapOld.TabIndex = 0;
            this.labelSiteMapOld.Text = "Old File";
            // 
            // textBoxDataContract
            // 
            this.textBoxSiteMapOld.Location = new System.Drawing.Point(82, 10);
            this.textBoxSiteMapOld.Name = "textBoxOldFile";
            this.textBoxSiteMapOld.Size = new System.Drawing.Size(348, 20);
            this.textBoxSiteMapOld.TabIndex = 1;
            this.textBoxSiteMapOld.Text = ".\\SiteMapFiles\\XtxGetXphaStudent.cs";
            // 
            // buttonBrowseDataContract
            // 
            this.buttonBrowseSiteMapOld.Location = new System.Drawing.Point(436, 10);
            this.buttonBrowseSiteMapOld.Name = "buttonBrowseOldFile";
            this.buttonBrowseSiteMapOld.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseSiteMapOld.TabIndex = 2;
            this.buttonBrowseSiteMapOld.Text = "Browse...";
            this.buttonBrowseSiteMapOld.UseVisualStyleBackColor = true;
            this.buttonBrowseSiteMapOld.Click += new System.EventHandler(this.buttonBrowseSiteMapOld_Click);
            // 
            // buttonBrowseOutputPath
            // 
            this.buttonBrowseOutputPath.Location = new System.Drawing.Point(436, 60);
            this.buttonBrowseOutputPath.Name = "buttonBrowseOutputPath";
            this.buttonBrowseOutputPath.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseOutputPath.TabIndex = 5;
            this.buttonBrowseOutputPath.Text = "Browse...";
            this.buttonBrowseOutputPath.UseVisualStyleBackColor = true;
            this.buttonBrowseOutputPath.Click += new System.EventHandler(this.buttonBrowseOutputPath_Click);


            // labelDataContract for new button
            // 
            this.labelSiteMapNew.AutoSize = true;
            this.labelSiteMapNew.Location = new System.Drawing.Point(3, 36);
            this.labelSiteMapNew.Name = "labelNewFile";
            this.labelSiteMapNew.Size = new System.Drawing.Size(73, 13);
            this.labelSiteMapNew.TabIndex = 3;
            this.labelSiteMapNew.Text = "New File";
            // 
            // textBoxDataContractOld
            // 
            this.textBoxSiteMapNew.Location = new System.Drawing.Point(82, 36);
            this.textBoxSiteMapNew.Name = "textBoxNewFile";
            this.textBoxSiteMapNew.Size = new System.Drawing.Size(348, 20);
            this.textBoxSiteMapNew.TabIndex = 4;
            this.textBoxSiteMapNew.Text = ".\\SiteMapFiles\\XtxGetXphaStudent.cs";
            // 
            // buttonBrowseDataContractOld
            // 
            this.buttonBrowseSiteMapNew.Location = new System.Drawing.Point(436, 36);
            this.buttonBrowseSiteMapNew.Name = "buttonBrowseNewFile";
            this.buttonBrowseSiteMapNew.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseSiteMapNew.TabIndex = 5;
            this.buttonBrowseSiteMapNew.Text = "Browse...";
            this.buttonBrowseSiteMapNew.UseVisualStyleBackColor = true;
            this.buttonBrowseSiteMapNew.Click += new System.EventHandler(this.buttonBrowseSiteMapNew_Click);
          




            // 
            // textBoxOutputPath
            // 
            this.textBoxOutputPath.Location = new System.Drawing.Point(82, 60);
            this.textBoxOutputPath.Name = "textBoxOutputPath";
            this.textBoxOutputPath.Size = new System.Drawing.Size(348, 20);
            this.textBoxOutputPath.TabIndex = 8;
            this.textBoxOutputPath.Text = ".\\Output";
            // 
            // labelOutputPath
            // 
            this.labelOutputPath.AutoSize = true;
            this.labelOutputPath.Location = new System.Drawing.Point(3, 60);
            this.labelOutputPath.Name = "labelOutputPath";
            this.labelOutputPath.Size = new System.Drawing.Size(63, 13);
            this.labelOutputPath.TabIndex = 9;
            this.labelOutputPath.Text = "Output Path";
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(215, 82);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(75, 23);
            this.buttonGo.TabIndex = 6;
            this.buttonGo.Text = "Go!";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // ofdDataContract
            // 
            this.ofdSiteMapUpdater.FileName = "SiteMapUpdater.cs";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 114);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.buttonBrowseOutputPath);
            this.Controls.Add(this.textBoxOutputPath);
            this.Controls.Add(this.labelOutputPath);
            this.Controls.Add(this.buttonBrowseSiteMapOld);
            this.Controls.Add(this.textBoxSiteMapOld);
            this.Controls.Add(this.labelSiteMapOld);
            this.Controls.Add(this.buttonBrowseSiteMapNew);
            this.Controls.Add(this.textBoxSiteMapNew);
            this.Controls.Add(this.labelSiteMapNew);
           


            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SiteMapUpdater";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSiteMapOld;
        private System.Windows.Forms.TextBox textBoxSiteMapOld;
        private System.Windows.Forms.Button buttonBrowseSiteMapOld;
        private System.Windows.Forms.Button buttonBrowseOutputPath;

        private System.Windows.Forms.Label labelSiteMapNew;
        private System.Windows.Forms.TextBox textBoxSiteMapNew;
        private System.Windows.Forms.Button buttonBrowseSiteMapNew;
        


        private System.Windows.Forms.TextBox textBoxOutputPath;
        private System.Windows.Forms.Label labelOutputPath;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.OpenFileDialog ofdSiteMapUpdater;
       

        private System.Windows.Forms.FolderBrowserDialog fbdOutput;
    }
}

