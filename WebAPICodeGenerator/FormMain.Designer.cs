namespace WebAPICodeGenerator
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
            this.labelDataContract = new System.Windows.Forms.Label();
            this.textBoxDataContract = new System.Windows.Forms.TextBox();
            this.buttonBrowseDataContract = new System.Windows.Forms.Button();
            this.buttonBrowseOutputPath = new System.Windows.Forms.Button();
            this.textBoxOutputPath = new System.Windows.Forms.TextBox();
            this.labelOutputPath = new System.Windows.Forms.Label();
            this.buttonGo = new System.Windows.Forms.Button();
            this.ofdDataContract = new System.Windows.Forms.OpenFileDialog();
            this.fbdOutput = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // labelDataContract
            // 
            this.labelDataContract.AutoSize = true;
            this.labelDataContract.Location = new System.Drawing.Point(3, 13);
            this.labelDataContract.Name = "labelDataContract";
            this.labelDataContract.Size = new System.Drawing.Size(73, 13);
            this.labelDataContract.TabIndex = 0;
            this.labelDataContract.Text = "Data Contract";
            // 
            // textBoxDataContract
            // 
            this.textBoxDataContract.Location = new System.Drawing.Point(82, 10);
            this.textBoxDataContract.Name = "textBoxDataContract";
            this.textBoxDataContract.Size = new System.Drawing.Size(348, 20);
            this.textBoxDataContract.TabIndex = 1;
            this.textBoxDataContract.Text = ".\\Data Contracts\\XtxGetXphaStudent.cs";
            // 
            // buttonBrowseDataContract
            // 
            this.buttonBrowseDataContract.Location = new System.Drawing.Point(436, 10);
            this.buttonBrowseDataContract.Name = "buttonBrowseDataContract";
            this.buttonBrowseDataContract.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseDataContract.TabIndex = 2;
            this.buttonBrowseDataContract.Text = "Browse...";
            this.buttonBrowseDataContract.UseVisualStyleBackColor = true;
            this.buttonBrowseDataContract.Click += new System.EventHandler(this.buttonBrowseDataContract_Click);
            // 
            // buttonBrowseOutputPath
            // 
            this.buttonBrowseOutputPath.Location = new System.Drawing.Point(436, 36);
            this.buttonBrowseOutputPath.Name = "buttonBrowseOutputPath";
            this.buttonBrowseOutputPath.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseOutputPath.TabIndex = 5;
            this.buttonBrowseOutputPath.Text = "Browse...";
            this.buttonBrowseOutputPath.UseVisualStyleBackColor = true;
            this.buttonBrowseOutputPath.Click += new System.EventHandler(this.buttonBrowseOutputPath_Click);
            // 
            // textBoxOutputPath
            // 
            this.textBoxOutputPath.Location = new System.Drawing.Point(82, 36);
            this.textBoxOutputPath.Name = "textBoxOutputPath";
            this.textBoxOutputPath.Size = new System.Drawing.Size(348, 20);
            this.textBoxOutputPath.TabIndex = 4;
            this.textBoxOutputPath.Text = ".\\Output";
            // 
            // labelOutputPath
            // 
            this.labelOutputPath.AutoSize = true;
            this.labelOutputPath.Location = new System.Drawing.Point(12, 41);
            this.labelOutputPath.Name = "labelOutputPath";
            this.labelOutputPath.Size = new System.Drawing.Size(64, 13);
            this.labelOutputPath.TabIndex = 3;
            this.labelOutputPath.Text = "Output Path";
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(219, 62);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(75, 23);
            this.buttonGo.TabIndex = 6;
            this.buttonGo.Text = "Go!";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // ofdDataContract
            // 
            this.ofdDataContract.FileName = "DataContract.cs";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 94);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.buttonBrowseOutputPath);
            this.Controls.Add(this.textBoxOutputPath);
            this.Controls.Add(this.labelOutputPath);
            this.Controls.Add(this.buttonBrowseDataContract);
            this.Controls.Add(this.textBoxDataContract);
            this.Controls.Add(this.labelDataContract);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Web API Code Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDataContract;
        private System.Windows.Forms.TextBox textBoxDataContract;
        private System.Windows.Forms.Button buttonBrowseDataContract;
        private System.Windows.Forms.Button buttonBrowseOutputPath;
        private System.Windows.Forms.TextBox textBoxOutputPath;
        private System.Windows.Forms.Label labelOutputPath;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.OpenFileDialog ofdDataContract;
        private System.Windows.Forms.FolderBrowserDialog fbdOutput;
    }
}

