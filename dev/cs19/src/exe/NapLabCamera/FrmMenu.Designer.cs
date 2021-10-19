
namespace NapLabCamera
{
  partial class FrmMenu
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
      this.CmbDevice = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.BtnVideo = new System.Windows.Forms.Button();
      this.BtnShot = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // CmbDevice
      // 
      this.CmbDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.CmbDevice.FormattingEnabled = true;
      this.CmbDevice.Location = new System.Drawing.Point(189, 10);
      this.CmbDevice.Name = "CmbDevice";
      this.CmbDevice.Size = new System.Drawing.Size(396, 32);
      this.CmbDevice.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 13);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(170, 24);
      this.label1.TabIndex = 1;
      this.label1.Text = "カメラデバイス選択：";
      // 
      // BtnVideo
      // 
      this.BtnVideo.Location = new System.Drawing.Point(17, 48);
      this.BtnVideo.Name = "BtnVideo";
      this.BtnVideo.Size = new System.Drawing.Size(568, 40);
      this.BtnVideo.TabIndex = 2;
      this.BtnVideo.Text = "カメラ映像試験";
      this.BtnVideo.UseVisualStyleBackColor = true;
      this.BtnVideo.Click += new System.EventHandler(this.BtnVideo_Click);
      // 
      // BtnShot
      // 
      this.BtnShot.Location = new System.Drawing.Point(17, 94);
      this.BtnShot.Name = "BtnShot";
      this.BtnShot.Size = new System.Drawing.Size(568, 40);
      this.BtnShot.TabIndex = 3;
      this.BtnShot.Text = "カメラ撮影試験";
      this.BtnShot.UseVisualStyleBackColor = true;
      this.BtnShot.Click += new System.EventHandler(this.BtnShot_Click);
      // 
      // FrmMenu
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(597, 141);
      this.Controls.Add(this.BtnShot);
      this.Controls.Add(this.BtnVideo);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.CmbDevice);
      this.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
      this.MaximizeBox = false;
      this.Name = "FrmMenu";
      this.Text = "カメラ制御試験メニュー";
      this.Load += new System.EventHandler(this.FrmMenu_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox CmbDevice;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button BtnVideo;
    private System.Windows.Forms.Button BtnShot;
  }
}