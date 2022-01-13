
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
            this.textBoxMin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDelta = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // portsBox
            // 
            this.portsBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.portsBox.FormattingEnabled = true;
            this.portsBox.Location = new System.Drawing.Point(153, 98);
            this.portsBox.Name = "portsBox";
            this.portsBox.Size = new System.Drawing.Size(121, 23);
            this.portsBox.TabIndex = 1;
            // 
            // labelPort
            // 
            this.labelPort.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(150, 66);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(55, 15);
            this.labelPort.TabIndex = 0;
            this.labelPort.Text = "label1";
            // 
            // portsChoose
            // 
            this.portsChoose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.portsChoose.Location = new System.Drawing.Point(153, 141);
            this.portsChoose.Name = "portsChoose";
            this.portsChoose.Size = new System.Drawing.Size(116, 55);
            this.portsChoose.TabIndex = 2;
            this.portsChoose.Text = "Start";
            this.portsChoose.UseVisualStyleBackColor = true;
            this.portsChoose.Click += new System.EventHandler(this.portsChoose_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonStop.Location = new System.Drawing.Point(275, 142);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(116, 54);
            this.buttonStop.TabIndex = 3;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // morseDataLabel
            // 
            this.morseDataLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.morseDataLabel.AutoSize = true;
            this.morseDataLabel.Font = new System.Drawing.Font("宋体", 15F);
            this.morseDataLabel.Location = new System.Drawing.Point(148, 246);
            this.morseDataLabel.Name = "morseDataLabel";
            this.morseDataLabel.Size = new System.Drawing.Size(272, 25);
            this.morseDataLabel.TabIndex = 4;
            this.morseDataLabel.Text = "Information output: ";
            // 
            // labelTemp1
            // 
            this.labelTemp1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTemp1.AutoSize = true;
            this.labelTemp1.Location = new System.Drawing.Point(552, 280);
            this.labelTemp1.Name = "labelTemp1";
            this.labelTemp1.Size = new System.Drawing.Size(0, 15);
            this.labelTemp1.TabIndex = 5;
            // 
            // labelTemp2
            // 
            this.labelTemp2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTemp2.AutoSize = true;
            this.labelTemp2.Location = new System.Drawing.Point(552, 329);
            this.labelTemp2.Name = "labelTemp2";
            this.labelTemp2.Size = new System.Drawing.Size(0, 15);
            this.labelTemp2.TabIndex = 6;
            // 
            // textBoxMin
            // 
            this.textBoxMin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxMin.Location = new System.Drawing.Point(625, 68);
            this.textBoxMin.Name = "textBoxMin";
            this.textBoxMin.Size = new System.Drawing.Size(100, 25);
            this.textBoxMin.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(622, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Lower Bound";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(622, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Threshold";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBoxDelta
            // 
            this.textBoxDelta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxDelta.Location = new System.Drawing.Point(625, 114);
            this.textBoxDelta.Name = "textBoxDelta";
            this.textBoxDelta.Size = new System.Drawing.Size(100, 25);
            this.textBoxDelta.TabIndex = 10;
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonClear.Location = new System.Drawing.Point(153, 286);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(116, 51);
            this.buttonClear.TabIndex = 11;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.textBoxDelta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxMin);
            this.Controls.Add(this.labelTemp2);
            this.Controls.Add(this.labelTemp1);
            this.Controls.Add(this.morseDataLabel);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.portsChoose);
            this.Controls.Add(this.portsBox);
            this.Controls.Add(this.labelPort);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Communication";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
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
        private System.Windows.Forms.TextBox textBoxMin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDelta;
        private System.Windows.Forms.Button buttonClear;
    }
}

