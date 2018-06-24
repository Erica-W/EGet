namespace EGet
{
    partial class EH_Get
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EH_Get));
            this.lblUrl = new System.Windows.Forms.Label();
            this.txtTargetUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSaveDest = new System.Windows.Forms.TextBox();
            this.brnSelect = new System.Windows.Forms.Button();
            this.lblTip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(30, 73);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(65, 12);
            this.lblUrl.TabIndex = 0;
            this.lblUrl.Text = "网页地址：";
            // 
            // txtTargetUrl
            // 
            this.txtTargetUrl.Location = new System.Drawing.Point(100, 70);
            this.txtTargetUrl.Name = "txtTargetUrl";
            this.txtTargetUrl.Size = new System.Drawing.Size(363, 21);
            this.txtTargetUrl.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(98, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "注：先选择存放地址，然后输入你要爬取的本子网页地址（仅限E站）";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(494, 70);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(84, 23);
            this.btnDownload.TabIndex = 3;
            this.btnDownload.Text = "一键下载";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "存放路径：";
            // 
            // txtSaveDest
            // 
            this.txtSaveDest.Enabled = false;
            this.txtSaveDest.Location = new System.Drawing.Point(100, 28);
            this.txtSaveDest.Name = "txtSaveDest";
            this.txtSaveDest.Size = new System.Drawing.Size(363, 21);
            this.txtSaveDest.TabIndex = 5;
            // 
            // brnSelect
            // 
            this.brnSelect.Location = new System.Drawing.Point(494, 26);
            this.brnSelect.Name = "brnSelect";
            this.brnSelect.Size = new System.Drawing.Size(84, 23);
            this.brnSelect.TabIndex = 6;
            this.brnSelect.Text = "选择文件夹";
            this.brnSelect.UseVisualStyleBackColor = true;
            this.brnSelect.Click += new System.EventHandler(this.brnSelect_Click);
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.ForeColor = System.Drawing.Color.Red;
            this.lblTip.Location = new System.Drawing.Point(100, 135);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(0, 12);
            this.lblTip.TabIndex = 7;
            // 
            // EH_Get
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 177);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.brnSelect);
            this.Controls.Add(this.txtSaveDest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTargetUrl);
            this.Controls.Add(this.lblUrl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EH_Get";
            this.Text = "E站本子下载器 —— by EricaW";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox txtTargetUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSaveDest;
        private System.Windows.Forms.Button brnSelect;
        private System.Windows.Forms.Label lblTip;
    }
}