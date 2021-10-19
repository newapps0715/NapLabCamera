
namespace NapLabCamera
{
  partial class FrmTestShot
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
      this.label1 = new System.Windows.Forms.Label();
      this.TxtSaveFolder = new System.Windows.Forms.TextBox();
      this.BtnStandby = new System.Windows.Forms.Button();
      this.BtnShot = new System.Windows.Forms.Button();
      this.BtnEnd = new System.Windows.Forms.Button();
      this.LstLog = new System.Windows.Forms.ListBox();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(74, 24);
      this.label1.TabIndex = 0;
      this.label1.Text = "保存先：";
      // 
      // TxtSaveFolder
      // 
      this.TxtSaveFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.TxtSaveFolder.Location = new System.Drawing.Point(92, 6);
      this.TxtSaveFolder.Name = "TxtSaveFolder";
      this.TxtSaveFolder.Size = new System.Drawing.Size(703, 31);
      this.TxtSaveFolder.TabIndex = 1;
      this.TxtSaveFolder.Text = "SnapShot";
      // 
      // BtnStandby
      // 
      this.BtnStandby.Location = new System.Drawing.Point(92, 43);
      this.BtnStandby.Name = "BtnStandby";
      this.BtnStandby.Size = new System.Drawing.Size(113, 32);
      this.BtnStandby.TabIndex = 2;
      this.BtnStandby.Text = "撮影準備";
      this.BtnStandby.UseVisualStyleBackColor = true;
      this.BtnStandby.Click += new System.EventHandler(this.BtnStandby_Click);
      // 
      // BtnShot
      // 
      this.BtnShot.Location = new System.Drawing.Point(211, 43);
      this.BtnShot.Name = "BtnShot";
      this.BtnShot.Size = new System.Drawing.Size(113, 32);
      this.BtnShot.TabIndex = 3;
      this.BtnShot.Text = "撮影";
      this.BtnShot.UseVisualStyleBackColor = true;
      this.BtnShot.Click += new System.EventHandler(this.BtnShot_Click);
      // 
      // BtnEnd
      // 
      this.BtnEnd.Location = new System.Drawing.Point(330, 43);
      this.BtnEnd.Name = "BtnEnd";
      this.BtnEnd.Size = new System.Drawing.Size(113, 32);
      this.BtnEnd.TabIndex = 4;
      this.BtnEnd.Text = "撮影終了";
      this.BtnEnd.UseVisualStyleBackColor = true;
      this.BtnEnd.Click += new System.EventHandler(this.BtnEnd_Click);
      // 
      // LstLog
      // 
      this.LstLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.LstLog.FormattingEnabled = true;
      this.LstLog.ItemHeight = 24;
      this.LstLog.Location = new System.Drawing.Point(2, 81);
      this.LstLog.Name = "LstLog";
      this.LstLog.Size = new System.Drawing.Size(793, 388);
      this.LstLog.TabIndex = 5;
      // 
      // FrmTestShot
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(799, 487);
      this.Controls.Add(this.LstLog);
      this.Controls.Add(this.BtnEnd);
      this.Controls.Add(this.BtnShot);
      this.Controls.Add(this.BtnStandby);
      this.Controls.Add(this.TxtSaveFolder);
      this.Controls.Add(this.label1);
      this.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
      this.Name = "FrmTestShot";
      this.Text = "カメラ撮影試験";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTestShot_FormClosing);
      this.Load += new System.EventHandler(this.FrmTestShot_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox TxtSaveFolder;
    private System.Windows.Forms.Button BtnStandby;
    private System.Windows.Forms.Button BtnShot;
    private System.Windows.Forms.Button BtnEnd;
    private System.Windows.Forms.ListBox LstLog;
  }
}