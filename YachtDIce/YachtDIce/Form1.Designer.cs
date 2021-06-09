
namespace YachtDIce
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.MyPanel = new System.Windows.Forms.Panel();
            this.CounterPanel = new System.Windows.Forms.Panel();
            this.DicePanel = new System.Windows.Forms.Panel();
            this.Rolling = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TurnLabel = new System.Windows.Forms.Label();
            this.RollingNumLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MyPanel
            // 
            this.MyPanel.Location = new System.Drawing.Point(12, 67);
            this.MyPanel.Name = "MyPanel";
            this.MyPanel.Size = new System.Drawing.Size(315, 604);
            this.MyPanel.TabIndex = 0;
            // 
            // CounterPanel
            // 
            this.CounterPanel.Location = new System.Drawing.Point(333, 67);
            this.CounterPanel.Name = "CounterPanel";
            this.CounterPanel.Size = new System.Drawing.Size(154, 604);
            this.CounterPanel.TabIndex = 1;
            // 
            // DicePanel
            // 
            this.DicePanel.Location = new System.Drawing.Point(517, 166);
            this.DicePanel.Name = "DicePanel";
            this.DicePanel.Size = new System.Drawing.Size(635, 370);
            this.DicePanel.TabIndex = 2;
            // 
            // Rolling
            // 
            this.Rolling.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rolling.Location = new System.Drawing.Point(754, 542);
            this.Rolling.Name = "Rolling";
            this.Rolling.Size = new System.Drawing.Size(189, 54);
            this.Rolling.TabIndex = 3;
            this.Rolling.Text = "Rolling";
            this.Rolling.UseVisualStyleBackColor = true;
            this.Rolling.Click += new System.EventHandler(this.Rolling_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(771, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 63);
            this.label1.TabIndex = 4;
            this.label1.Text = "Yacht";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(353, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 31);
            this.label2.TabIndex = 5;
            this.label2.Text = "opponent";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(210, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 31);
            this.label3.TabIndex = 6;
            this.label3.Text = "My";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(69, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 31);
            this.label4.TabIndex = 7;
            this.label4.Text = "/12";
            // 
            // TurnLabel
            // 
            this.TurnLabel.AutoSize = true;
            this.TurnLabel.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TurnLabel.Location = new System.Drawing.Point(32, 33);
            this.TurnLabel.Name = "TurnLabel";
            this.TurnLabel.Size = new System.Drawing.Size(24, 31);
            this.TurnLabel.TabIndex = 8;
            this.TurnLabel.Text = "1";
            // 
            // RollingNumLabel
            // 
            this.RollingNumLabel.AutoSize = true;
            this.RollingNumLabel.Font = new System.Drawing.Font("MV Boli", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RollingNumLabel.Location = new System.Drawing.Point(816, 105);
            this.RollingNumLabel.Name = "RollingNumLabel";
            this.RollingNumLabel.Size = new System.Drawing.Size(54, 58);
            this.RollingNumLabel.TabIndex = 9;
            this.RollingNumLabel.Text = "3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 683);
            this.Controls.Add(this.RollingNumLabel);
            this.Controls.Add(this.TurnLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Rolling);
            this.Controls.Add(this.DicePanel);
            this.Controls.Add(this.CounterPanel);
            this.Controls.Add(this.MyPanel);
            this.Name = "Form1";
            this.Text = "Rolling";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel MyPanel;
        private System.Windows.Forms.Panel CounterPanel;
        private System.Windows.Forms.Panel DicePanel;
        private System.Windows.Forms.Button Rolling;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label TurnLabel;
        private System.Windows.Forms.Label RollingNumLabel;
    }
}

