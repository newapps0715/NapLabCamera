
namespace NapLabCamera
{
  partial class FrmTestVideo
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
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      this.BtnStart = new System.Windows.Forms.RadioButton();
      this.BtnStop = new System.Windows.Forms.RadioButton();
      this.PicVideo = new System.Windows.Forms.PictureBox();
      this.splitContainer3 = new System.Windows.Forms.SplitContainer();
      this.PicShot = new System.Windows.Forms.PictureBox();
      this.BtnShot = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.PicVideo)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
      this.splitContainer3.Panel1.SuspendLayout();
      this.splitContainer3.Panel2.SuspendLayout();
      this.splitContainer3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.PicShot)).BeginInit();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
      this.splitContainer1.Size = new System.Drawing.Size(964, 515);
      this.splitContainer1.SplitterDistance = 466;
      this.splitContainer1.TabIndex = 1;
      // 
      // splitContainer2
      // 
      this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.splitContainer2.Location = new System.Drawing.Point(0, 0);
      this.splitContainer2.Name = "splitContainer2";
      this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer2.Panel1
      // 
      this.splitContainer2.Panel1.Controls.Add(this.BtnStart);
      this.splitContainer2.Panel1.Controls.Add(this.BtnStop);
      // 
      // splitContainer2.Panel2
      // 
      this.splitContainer2.Panel2.Controls.Add(this.PicVideo);
      this.splitContainer2.Size = new System.Drawing.Size(466, 515);
      this.splitContainer2.SplitterDistance = 34;
      this.splitContainer2.TabIndex = 0;
      // 
      // BtnStart
      // 
      this.BtnStart.Appearance = System.Windows.Forms.Appearance.Button;
      this.BtnStart.Location = new System.Drawing.Point(114, 3);
      this.BtnStart.Name = "BtnStart";
      this.BtnStart.Size = new System.Drawing.Size(105, 31);
      this.BtnStart.TabIndex = 1;
      this.BtnStart.Text = "起動";
      this.BtnStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.BtnStart.UseVisualStyleBackColor = true;
      this.BtnStart.CheckedChanged += new System.EventHandler(this.BtnStart_CheckedChanged);
      // 
      // BtnStop
      // 
      this.BtnStop.Appearance = System.Windows.Forms.Appearance.Button;
      this.BtnStop.Checked = true;
      this.BtnStop.Location = new System.Drawing.Point(3, 3);
      this.BtnStop.Name = "BtnStop";
      this.BtnStop.Size = new System.Drawing.Size(105, 31);
      this.BtnStop.TabIndex = 0;
      this.BtnStop.TabStop = true;
      this.BtnStop.Text = "停止";
      this.BtnStop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.BtnStop.UseVisualStyleBackColor = true;
      this.BtnStop.CheckedChanged += new System.EventHandler(this.BtnStop_CheckedChanged);
      // 
      // PicVideo
      // 
      this.PicVideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.PicVideo.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PicVideo.Location = new System.Drawing.Point(0, 0);
      this.PicVideo.Name = "PicVideo";
      this.PicVideo.Size = new System.Drawing.Size(466, 477);
      this.PicVideo.TabIndex = 0;
      this.PicVideo.TabStop = false;
      this.PicVideo.Resize += new System.EventHandler(this.PicVideo_Resize);
      // 
      // splitContainer3
      // 
      this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      this.splitContainer3.Location = new System.Drawing.Point(0, 0);
      this.splitContainer3.Name = "splitContainer3";
      this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer3.Panel1
      // 
      this.splitContainer3.Panel1.Controls.Add(this.PicShot);
      // 
      // splitContainer3.Panel2
      // 
      this.splitContainer3.Panel2.Controls.Add(this.BtnShot);
      this.splitContainer3.Size = new System.Drawing.Size(494, 515);
      this.splitContainer3.SplitterDistance = 476;
      this.splitContainer3.TabIndex = 0;
      // 
      // PicShot
      // 
      this.PicShot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.PicShot.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PicShot.Location = new System.Drawing.Point(0, 0);
      this.PicShot.Name = "PicShot";
      this.PicShot.Size = new System.Drawing.Size(494, 476);
      this.PicShot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.PicShot.TabIndex = 0;
      this.PicShot.TabStop = false;
      // 
      // BtnShot
      // 
      this.BtnShot.Location = new System.Drawing.Point(3, 3);
      this.BtnShot.Name = "BtnShot";
      this.BtnShot.Size = new System.Drawing.Size(107, 30);
      this.BtnShot.TabIndex = 0;
      this.BtnShot.Text = "撮影";
      this.BtnShot.UseVisualStyleBackColor = true;
      this.BtnShot.Click += new System.EventHandler(this.BtnShot_Click);
      // 
      // FrmTestVideo
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(964, 515);
      this.Controls.Add(this.splitContainer1);
      this.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
      this.Name = "FrmTestVideo";
      this.Text = "カメラ映像試験";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTestVideo_FormClosing);
      this.Load += new System.EventHandler(this.FrmTestVideo_Load);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
      this.splitContainer2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.PicVideo)).EndInit();
      this.splitContainer3.Panel1.ResumeLayout(false);
      this.splitContainer3.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
      this.splitContainer3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.PicShot)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.SplitContainer splitContainer2;
    private System.Windows.Forms.RadioButton BtnStart;
    private System.Windows.Forms.RadioButton BtnStop;
    private System.Windows.Forms.PictureBox PicVideo;
    private System.Windows.Forms.SplitContainer splitContainer3;
    private System.Windows.Forms.PictureBox PicShot;
    private System.Windows.Forms.Button BtnShot;
  }
}