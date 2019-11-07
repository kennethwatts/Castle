namespace APIFileMerger
{
    partial
        class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed;
        /// otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region WindowsForm Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.oldUnModFile = new System.Windows.Forms.Label();
            this.textBoxOldUnModFile = new System.Windows.Forms.TextBox();
            this.buttonBrowseOldUnModFile = new System.Windows.Forms.Button();
            this.oldModFile = new System.Windows.Forms.Label();
            this.textBoxOldModFile = new System.Windows.Forms.TextBox();
            this.buttonBrowseOldModFile = new System.Windows.Forms.Button();
            this.newUnModFile = new System.Windows.Forms.Label();
            this.textBoxNewUnModFile = new System.Windows.Forms.TextBox();
            this.buttonBrowseNewUnModFile = new System.Windows.Forms.Button();
            this.buttonGo = new System.Windows.Forms.Button();
            this.ofdAPIFileMerger = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            //
            // oldUnModFile
            //
            this.oldUnModFile.AutoSize = true;
            this.oldUnModFile.Location = new System.Drawing.Point(3, 13);
            this.oldUnModFile.Name = "oldUnModFolder";
            this.oldUnModFile.Size = new System.Drawing.Size(74, 13);
            this.oldUnModFile.TabIndex = 0;
            this.oldUnModFile.Text = "OldUnModFolder";
            //
            // textBoxOldUnModFile
            //
            this.textBoxOldUnModFile.Location = new System.Drawing.Point(94, 10);
            this.textBoxOldUnModFile.Name = "textBoxOldUnModFolder";
            this.textBoxOldUnModFile.Size = new System.Drawing.Size(330, 20);
            this.textBoxOldUnModFile.TabIndex = 1;
            this.textBoxOldUnModFile.Text = ".\\APIMergerFiles\\XtxGetAPIFile.csproj";
            this.textBoxOldUnModFile.TextChanged += new System.EventHandler(this.textBoxOldUnModFile_TextChanged);
            //
            // buttonBrowseOldUnModFile
            //
            this.buttonBrowseOldUnModFile.Location = new System.Drawing.Point(436, 10);
            this.buttonBrowseOldUnModFile.Name = "buttonBrowseOldUnModFile";
            this.buttonBrowseOldUnModFile.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseOldUnModFile.TabIndex = 2;
            this.buttonBrowseOldUnModFile.Text = "Browse...";
            this.buttonBrowseOldUnModFile.UseVisualStyleBackColor = true;
            this.buttonBrowseOldUnModFile.Click += new System.EventHandler(this.buttonBrowseOldUnModFile_Click);

            //
            // oldModFile
            //
            this.oldModFile.AutoSize = true;
            this.oldModFile.Location = new System.Drawing.Point(3, 36);
            this.oldModFile.Name = "oldModFolder";
            this.oldModFile.Size = new System.Drawing.Size(66, 13);
            this.oldModFile.TabIndex = 3;
            this.oldModFile.Text = "Old Mod Folder";
            //
            // textBoxOldModFile
            //
            this.textBoxOldModFile.Location = new System.Drawing.Point(94, 36);
            this.textBoxOldModFile.Name = "textBoxOldModFolder";
            this.textBoxOldModFile.Size = new System.Drawing.Size(330, 20);
            this.textBoxOldModFile.TabIndex = 4;
            this.textBoxOldModFile.Text = ".\\APIMergerFiles\\XtxGetAPIFile.csproj";
            //
            // buttonBrowseOldModFile
            //
            this.buttonBrowseOldModFile.Location = new System.Drawing.Point(436, 36);
            this.buttonBrowseOldModFile.Name = "buttonBrowseOldModFile";
            this.buttonBrowseOldModFile.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseOldModFile.TabIndex = 5;
            this.buttonBrowseOldModFile.Text = "Browse...";
            this.buttonBrowseOldModFile.UseVisualStyleBackColor = true;
            this.buttonBrowseOldModFile.Click += new System.EventHandler(this.buttonBrowseOldModFile_Click);
            //
            // newUnModFile
            //
            this.newUnModFile.AutoSize = true;
            this.newUnModFile.Location = new System.Drawing.Point(3, 60);
            this.newUnModFile.Name = "newUnModFolder";
            this.newUnModFile.Size = new System.Drawing.Size(64, 13);
            this.newUnModFile.TabIndex = 9;
            this.newUnModFile.Text = "NewUnModFolder";
            //
            // textBoxNewUnModFile
            //
            this.textBoxNewUnModFile.Location = new System.Drawing.Point(94, 60);
            this.textBoxNewUnModFile.Name = "textBoxNewUnModFolder";
            this.textBoxNewUnModFile.Size = new System.Drawing.Size(330, 20);
            this.textBoxNewUnModFile.TabIndex = 8;
            this.textBoxNewUnModFile.Text = ".\\APIMergerFiles\\XtxGetAPIFile.csproj";

            //
            // buttonBrowseNewUnModFile
            //
            this.buttonBrowseNewUnModFile.Location = new System.Drawing.Point(436, 60);
            this.buttonBrowseNewUnModFile.Name = "buttonBrowseNewUnModFile";
            this.buttonBrowseNewUnModFile.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseNewUnModFile.TabIndex = 5;
            this.buttonBrowseNewUnModFile.Text = "Browse...";
            this.buttonBrowseNewUnModFile.UseVisualStyleBackColor = true;
            this.buttonBrowseNewUnModFile.Click += new System.EventHandler(this.buttonBrowseNewUnModFile_Click);

        
            //
            // buttonGo
            //
            this.buttonGo.Location = new System.Drawing.Point(215, 105);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(75, 23);
            this.buttonGo.TabIndex = 6;
            this.buttonGo.Text = "Go!";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            //
            // ofdAPIFileMerger
            //
            this.ofdAPIFileMerger.SelectedPath = "APIFileMerger.cs";
            //
            // FormMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 130);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.buttonBrowseOldUnModFile);
            this.Controls.Add(this.textBoxOldUnModFile);
            this.Controls.Add(this.oldUnModFile);
            this.Controls.Add(this.buttonBrowseOldModFile);
            this.Controls.Add(this.textBoxOldModFile);
            this.Controls.Add(this.oldModFile);
            this.Controls.Add(this.buttonBrowseNewUnModFile);
            this.Controls.Add(this.textBoxNewUnModFile);
            this.Controls.Add(this.newUnModFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "APIFileMerger";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label oldUnModFile;
        private System.Windows.Forms.TextBox textBoxOldUnModFile;
        private System.Windows.Forms.Button buttonBrowseOldUnModFile;

        private System.Windows.Forms.Label oldModFile;
        private System.Windows.Forms.TextBox textBoxOldModFile;
        private System.Windows.Forms.Button buttonBrowseOldModFile;

        private System.Windows.Forms.Label newUnModFile;
        private System.Windows.Forms.TextBox textBoxNewUnModFile;
        private System.Windows.Forms.Button buttonBrowseNewUnModFile;

       
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.FolderBrowserDialog ofdAPIFileMerger;

        
    }
}

