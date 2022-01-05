
namespace MorseProject
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.portsBox = new System.Windows.Forms.ComboBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.portsChoose = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.morseDataLabel = new System.Windows.Forms.Label();
            this.labelTemp1 = new System.Windows.Forms.Label();
            this.labelTemp2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // portsBox
            // 
            this.portsBox.FormattingEnabled = true;
            this.portsBox.Location = new System.Drawing.Point(78, 83);
            this.portsBox.Name = "portsBox";
            this.portsBox.Size = new System.Drawing.Size(121, 23);
            this.portsBox.TabIndex = 1;
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(75, 51);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(55, 15);
            this.labelPort.TabIndex = 0;
            this.labelPort.Text = "label1";
            // 
            // portsChoose
            // 
            this.portsChoose.Location = new System.Drawing.Point(255, 51);
            this.portsChoose.Name = "portsChoose";
            this.portsChoose.Size = new System.Drawing.Size(116, 55);
            this.portsChoose.TabIndex = 2;
            this.portsChoose.Text = "开始";
            this.portsChoose.UseVisualStyleBackColor = true;
            this.portsChoose.Click += new System.EventHandler(this.portsChoose_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(255, 130);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(116, 54);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Text = "停止";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // morseDataLabel
            // 
            this.morseDataLabel.AutoSize = true;
            this.morseDataLabel.Font = new System.Drawing.Font("宋体", 15F);
            this.morseDataLabel.Location = new System.Drawing.Point(75, 259);
            this.morseDataLabel.Name = "morseDataLabel";
            this.morseDataLabel.Size = new System.Drawing.Size(187, 25);
            this.morseDataLabel.TabIndex = 4;
            this.morseDataLabel.Text = "收到的信息为：";
            // 
            // labelTemp1
            // 
            this.labelTemp1.AutoSize = true;
            this.labelTemp1.Location = new System.Drawing.Point(490, 290);
            this.labelTemp1.Name = "labelTemp1";
            this.labelTemp1.Size = new System.Drawing.Size(55, 15);
            this.labelTemp1.TabIndex = 5;
            this.labelTemp1.Text = "label1";
            // 
            // labelTemp2
            // 
            this.labelTemp2.AutoSize = true;
            this.labelTemp2.Location = new System.Drawing.Point(490, 336);
            this.labelTemp2.Name = "labelTemp2";
            this.labelTemp2.Size = new System.Drawing.Size(55, 15);
            this.labelTemp2.TabIndex = 6;
            this.labelTemp2.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelTemp2);
            this.Controls.Add(this.labelTemp1);
            this.Controls.Add(this.morseDataLabel);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.portsChoose);
            this.Controls.Add(this.portsBox);
            this.Controls.Add(this.labelPort);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox portsBox;
        private System.Windows.Forms.Label labelPort;
        protected System.Windows.Forms.Button portsChoose;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label morseDataLabel;
        private System.Windows.Forms.Label labelTemp1;
        private System.Windows.Forms.Label labelTemp2;
    }
}

