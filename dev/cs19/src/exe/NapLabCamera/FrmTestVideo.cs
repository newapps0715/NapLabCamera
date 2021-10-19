using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DirectShowLib;

namespace NapLabCamera
{
  public partial class FrmTestVideo : Form
  {

    #region " --- コンストラクタ"

    /// <summary>
    /// 作成時
    /// </summary>
    public FrmTestVideo()
    {
      InitializeComponent();
    }

    #endregion

    #region " --- 定数"

    /// <summary>
    /// 定数
    /// </summary>
    const String csFormTitle = "カメラ映像試験";

    /// <summary>
    /// フォームモード
    /// </summary>
    enum EnFormMode
    {
      NoneDevice,
      CameraStop,
      CameraStart,
    }

    #endregion

    #region " --- プロパティ"

    /// <summary>
    /// 対象デバイス
    /// </summary>
    public DeviceRecord TargetDevice
    {
      get => moTargetDevice;
      set => moTargetDevice = value;
    }
    private DeviceRecord moTargetDevice;

    /// <summary>
    /// 現在のフォームモード
    /// </summary>
    private EnFormMode CurrentFormMode
    {
      get => meCurrentFormMode;
      set => SetCurrentFormMode(value);
    }
    private EnFormMode meCurrentFormMode = EnFormMode.NoneDevice;

    #endregion

    #region " --- 定義"

    /// <summary>
    /// キャプチャーグラフビルダー
    /// </summary>
    private ICaptureGraphBuilder2 moCaptureGraphBuilder;

    #endregion

    #region " --- 画面イベント"

    /// <summary>
    /// ロード時
    /// </summary>
    private void FrmTestVideo_Load(
      object sender
      , EventArgs e)
    {
      var oDevice = TargetDevice;

      // タイトルの設定
      Text = ShareCommon.ShCreateFormTitle(csFormTitle, oDevice);
      
      // 画面状態の設定
      if (oDevice == null)
        CurrentFormMode = EnFormMode.NoneDevice;
      else
        CurrentFormMode = EnFormMode.CameraStop;

      // グラフビルダーの生成
      if (oDevice != null)
      {
        moCaptureGraphBuilder = ShareDirectShow.ShCreateCaptureGraphBuilder(oDevice);
        ShareDirectShow.ShSetVideoWindow(moCaptureGraphBuilder, PicVideo);
      }

    }

    /// <summary>
    /// 終了時
    /// </summary>
    private void FrmTestVideo_FormClosing(
      object sender
      , FormClosingEventArgs e)
    {

      try
      {
        // カメラ起動中の場合は停止する
        if (CurrentFormMode == EnFormMode.CameraStart)
          ShareDirectShow.ShStopVideo(moCaptureGraphBuilder);

        // 解放
        ShareDirectShow.ShReleaseCaptureGraphBuiler(moCaptureGraphBuilder);

        CurrentFormMode = EnFormMode.NoneDevice;

      }
      catch
      {
      }

    }

    // ---

    /// <summary>
    /// 起動ボタン
    /// </summary>
    private void BtnStart_CheckedChanged(
      object sender
      , EventArgs e)
    {

      try
      {
        // 開始
        ShareDirectShow.ShStartVideo(moCaptureGraphBuilder);

        CurrentFormMode = EnFormMode.CameraStart;

      }
      catch(Exception ex)
      {
        ShareCommon.ShDisplayException(ex);
      }

    }

    /// <summary>
    /// 停止ボタン
    /// </summary>
    private void BtnStop_CheckedChanged(
      object sender
      , EventArgs e)
    {

      try
      {
        // 停止
        ShareDirectShow.ShStopVideo(moCaptureGraphBuilder);

        PicVideo.Image = null;
        CurrentFormMode = EnFormMode.CameraStop;

      }
      catch (Exception ex)
      {
        ShareCommon.ShDisplayException(ex);
      }

    }

    /// <summary>
    /// 撮影ボタン
    /// </summary>
    private void BtnShot_Click(
      object sender
      , EventArgs e)
    {

      try
      {
        // スナップショットの取得
        var oSnapShot = ShareDirectShow.ShGetSnapShot(moCaptureGraphBuilder);

        PicShot.Image = oSnapShot;

      }
      catch (Exception ex)
      {
        PicShot.Image = null;
        ShareCommon.ShDisplayException(ex);
      }

    }

    /// <summary>
    /// ビデオリサイズ
    /// </summary>
    private void PicVideo_Resize(
      object sender
      , EventArgs e)
    {

      try
      {
        // サイズ変更
        ShareDirectShow.ShSetWindowSize(
          moCaptureGraphBuilder
          , PicVideo.ClientSize.Width
          , PicVideo.ClientSize.Height);

      }
      catch 
      {
      }

    }

    #endregion

    #region " --- プライベート関数"

    /// <summary>
    /// フォームモードの設定
    /// </summary>
    private void SetCurrentFormMode(
      EnFormMode inValue)
    {

      switch(inValue)
      {
        case EnFormMode.NoneDevice:
          BtnStart.Enabled = false;
          BtnStop.Enabled = false;
          BtnShot.Enabled = false;
          break;

        case EnFormMode.CameraStop:
          BtnStart.Enabled = true;
          BtnStop.Enabled = true;
          BtnShot.Enabled = false;
          break;

        case EnFormMode.CameraStart:
          BtnStart.Enabled = true;
          BtnStop.Enabled = true;
          BtnShot.Enabled = true;
          break;

        default:
          BtnStart.Enabled = false;
          BtnStop.Enabled = false;
          BtnShot.Enabled = false;
          break;

      }

    }

    #endregion

  }

}
