using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using DirectShowLib;

namespace NapLabCamera
{
  public partial class FrmTestShot : Form
  {

    #region " --- コンストラクタ"

    /// <summary>
    /// 作成時
    /// </summary>
    public FrmTestShot()
    {
      InitializeComponent();
    }

    #endregion

    #region " --- 定数"

    /// <summary>
    /// 定数
    /// </summary>
    const String csFormTitle = "カメラ撮影試験";

    /// <summary>
    /// イメージファイルの先頭文字列
    /// </summary>
    const String csImageFileFirst = "SS_";
    const String csImageFileExp = "png";
    private readonly ImageFormat ceImageFileFormat = ImageFormat.Png;

    /// <summary>
    /// フォームモード
    /// </summary>
    enum EnFormMode
    {
      NoneDevice,
      Initial,
      Ready,
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
      set => PrvSetCurrentFormMode(value);
    }
    private EnFormMode meCurrentFormMode = EnFormMode.NoneDevice;

    #endregion

    #region " --- 定義"

    /// <summary>
    /// キャプチャーグラフビルダー
    /// </summary>
    private ICaptureGraphBuilder2 moCaptureGraphBuilder;

    /// <summary>
    /// 保存先フォルダー
    /// </summary>
    private String msSaveFolder;

    #endregion

    #region " --- 画面イベント"

    /// <summary>
    /// ロード時
    /// </summary>
    private void FrmTestShot_Load(
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
        CurrentFormMode = EnFormMode.Initial;

      // グラフビルダーの生成
      if (oDevice != null)
      {
        moCaptureGraphBuilder = ShareDirectShow.ShCreateCaptureGraphBuilder(oDevice);
        ShareDirectShow.ShSetVideoWindow(
          moCaptureGraphBuilder
          , this
          , this.ClientSize.Width * -1
          , this.ClientSize.Height  * -1);
      }

    }

    /// <summary>
    /// フォーム終了時
    /// </summary>
    private void FrmTestShot_FormClosing(
      object sender
      , FormClosingEventArgs e)
    {

      try
      {
        // カメラ起動中の場合は停止する
        if (CurrentFormMode == EnFormMode.Ready)
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
    /// 撮影準備ボタン
    /// </summary>
    private void BtnStandby_Click(
      object sender
      , EventArgs e)
    {

      try
      {
        PrvAddLogMsg("撮影準備をしています...");

        // 保存先の取得
        msSaveFolder = ShareCommon.ShGetAbsolutePathName(TxtSaveFolder.Text);
        Directory.CreateDirectory(msSaveFolder);

        // 開始
        ShareDirectShow.ShStartVideo(moCaptureGraphBuilder);

        CurrentFormMode = EnFormMode.Ready;

        PrvAddLogMsg("撮影準備が完了しました。");
        PrvAddLogMsg("保存先：" + msSaveFolder);
        PrvAddLogMsg("-----------------------------");

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

        // ファイル保存
        var sFileName = PrvCreateImageFileName(msSaveFolder, csImageFileExp);
        oSnapShot.Save(sFileName, ceImageFileFormat);

        PrvAddLogMsg("撮影：" + ShareCommon.ShGetFileName(sFileName));

      }
      catch (Exception ex)
      {
        ShareCommon.ShDisplayException(ex);
      }

    }

    /// <summary>
    /// 撮影終了ボタン
    /// </summary>
    private void BtnEnd_Click(
      object sender
      , EventArgs e)
    {

      try
      {
        // 停止
        ShareDirectShow.ShStopVideo(moCaptureGraphBuilder);

        CurrentFormMode = EnFormMode.Initial;

        PrvAddLogMsg("撮影を終了しました。");
        PrvAddLogMsg("-----------------------------");

      }
      catch (Exception ex)
      {
        ShareCommon.ShDisplayException(ex);
      }

    }

    #endregion

    #region " --- プライベート関数"

    /// <summary>
    /// フォームモードの設定
    /// </summary>
    private void PrvSetCurrentFormMode(
      EnFormMode inValue)
    {

      switch (inValue)
      {
        case EnFormMode.NoneDevice:
          TxtSaveFolder.Enabled = false;
          BtnStandby.Enabled = false;
          BtnShot.Enabled = false;
          BtnEnd.Enabled = false;
          break;

        case EnFormMode.Initial:
          TxtSaveFolder.Enabled = true;
          BtnStandby.Enabled = true;
          BtnShot.Enabled = false;
          BtnEnd.Enabled = false;
          break;

        case EnFormMode.Ready:
          TxtSaveFolder.Enabled = false;
          BtnStandby.Enabled = false;
          BtnShot.Enabled = true;
          BtnEnd.Enabled = true;
          break;

        default:
          TxtSaveFolder.Enabled = false;
          BtnStandby.Enabled = false;
          BtnShot.Enabled = false;
          BtnEnd.Enabled = false;
          break;

      }

    }

    /// <summary>
    /// イメージファイル名の取得
    /// </summary>
    private String PrvCreateImageFileName(
      String inFolder
      , String inExp)
    {
      var sRes = "";
      var sFolder = ShareCommon.ShAddPathSeparator(inFolder);
      var sExp = "." + inExp;

      var nIndex = 0;
      var sTimeStamp = csImageFileFirst + DateTime.Now.ToString("yyyy-mm-dd HH-mm-ss");
      for (; ; )
      {
        if (nIndex == 0)
          sRes = sFolder + sTimeStamp + sExp;
        else
          sRes = sFolder + sTimeStamp + "(" + nIndex.ToString() + ")" + sExp;

        if (File.Exists(sRes) == false) break;
        nIndex++;
      }

      return (sRes);

    }

    /// <summary>
    /// ログメッセージの作成
    /// </summary>
    private String PrvCreateLogMessage(
      String inMsg)
    {
      var oRes = new StringBuilder();
      oRes.Append(DateTime.Now.ToString("yyyy/mm/dd HH:mm:ss"));
      oRes.Append(' ');
      if (String.IsNullOrWhiteSpace(inMsg) == false)
        oRes.Append(inMsg);
      return (oRes.ToString());
    }

    /// <summary>
    /// ログメッセージの追加
    /// </summary>
    private void PrvAddLogMsg(
      String inMsg)
    {
      var sMsg = PrvCreateLogMessage(inMsg);
      LstLog.Items.Add(sMsg);
      LstLog.Refresh();
    }

    #endregion

  }

}
