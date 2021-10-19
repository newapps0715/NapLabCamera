using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Threading;
using DirectShowLib;

namespace NapLabCamera
{
  
  /// <summary>
  /// 共通DirectShowモジュール
  /// </summary>
  public static class ShareDirectShow
  {

    #region " --- 定義"

    // フィルター名
    const String csFilterName_Device = "Device";
    const String csFilterName_Capture = "Capture";
    const String csFilterName_SampleGrabber = "SampleGrabber";
    const String csFilterName_NullRender = "NullRender";

    #endregion

    #region " --- デバイス関連"

    /// <summary>
    /// 選択デバイスリストの作成
    /// </summary>
    public static DeviceRecord[] ShCreateSelectionDeciceList()
    {
      var oRes = new List<DeviceRecord>();

      oRes.Add(new DeviceRecord("(対象のデバイスを選択してください。)"));

      // ビデオ デバイスのリストを作成する
      var oDsList = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
      if (oDsList.Length > 0)
      {
        // デバイスの追加
        foreach (var oDsDevice in oDsList)
          oRes.Add(new DeviceRecord(oDsDevice));
      }

      return (oRes.ToArray());

    }

    #endregion

    #region " --- ICaptureGraphBuilderベース"

    /// <summary>
    /// キャプチャーグラフビルダーの作成 
    ///   デバイス -> グラフビルダー <= キャプチャー -> サンプルグラバー -> NullRender
    /// </summary>
    public static ICaptureGraphBuilder2 ShCreateCaptureGraphBuilder(
      DeviceRecord inDevice)
    {
      if (inDevice == null) throw new ArgumentNullException("inDevice");

      var nFuncRes = 0;

      // --- (キャプチャー)
      var oRes = (ICaptureGraphBuilder2)new CaptureGraphBuilder2();

      // --- (グラフビルダー)
      var oGraphBuilder = (IGraphBuilder)new FilterGraph();

      // 対象デバイスの追加
      var oDsDevice = inDevice.Value;
      if (oDsDevice == null) throw new Exception("デバイスが見つかりません。");
      var oDevice = PrvDsDeviceToBaseFilter(oDsDevice);
      nFuncRes = oGraphBuilder.AddFilter(
        oDevice
        , csFilterName_Device);
      DsError.ThrowExceptionForHR(nFuncRes);

      // グラフビルダーの関連付け
      nFuncRes = oRes.SetFiltergraph(oGraphBuilder);
      DsError.ThrowExceptionForHR(nFuncRes);

      // レンダリングフィルターの設定
      nFuncRes = oRes.RenderStream(
        PinCategory.Preview
        , MediaType.Video
        , oDevice
        , null
        , null);
      DsError.ThrowExceptionForHR(nFuncRes);

      // --- (サンプルグラバー)
      var oSampleGrabber = (ISampleGrabber)new SampleGrabber();
      var oSampleGrabberFilter = (IBaseFilter)oSampleGrabber;
      nFuncRes = oGraphBuilder.AddFilter(
        oSampleGrabberFilter
        , csFilterName_SampleGrabber);
      DsError.ThrowExceptionForHR(nFuncRes);

      // メディアタイプ設定
      var oMediaType = new AMMediaType();
      oMediaType.majorType = MediaType.Video;
      oMediaType.subType = MediaSubType.RGB24;
      oMediaType.formatType = FormatType.VideoInfo;
      nFuncRes = oSampleGrabber.SetMediaType(
        oMediaType);
      DsError.ThrowExceptionForHR(nFuncRes);
      DsUtils.FreeAMMediaType(oMediaType);

      // 各種設定
      nFuncRes = oSampleGrabber.SetOneShot(false);
      DsError.ThrowExceptionForHR(nFuncRes);

      nFuncRes = oSampleGrabber.SetBufferSamples(true);
      DsError.ThrowExceptionForHR(nFuncRes);

      // --- (NullRender)
      var oNullRender = (IBaseFilter)new NullRenderer();
      oGraphBuilder.AddFilter(
        oNullRender
        , csFilterName_NullRender);

      // --- ピン接続
      nFuncRes = oRes.RenderStream(
        PinCategory.Capture
        , MediaType.Video
        , oDevice
        , oSampleGrabberFilter
        , oNullRender);

      return (oRes);

    }

    /// <summary>
    /// 表示域のサイズ設定
    /// </summary>
    public static void ShSetWindowSize(
      ICaptureGraphBuilder2 inCaptureGraphBuilder
      , Int32 inWidth
      , Int32 inHeight
      , Int32 inLeft = 0
      , Int32 inTop = 0)
    {
      if (inCaptureGraphBuilder == null) throw new ArgumentNullException("inCaptureGraphBuilder");
      
      var nFuncRes = 0;
      var oVideoWindow = PrvGetVideoWindow(inCaptureGraphBuilder);
      if (oVideoWindow == null) throw new Exception("グラフビルダーが不正です。");

      // 表示域のサイズを設定する
      nFuncRes = oVideoWindow.SetWindowPosition(
        inLeft
        , inTop
        , inWidth
        , inHeight);
      DsError.ThrowExceptionForHR(nFuncRes);

    }

    /// <summary>
    /// ビデオ表示設定
    /// </summary>
    public static void ShSetVideoWindow(
      ICaptureGraphBuilder2 inCaptureGraphBuilder
      , Control inDisplayControl
      , Int32 inLeft = 0
      , Int32 inTop = 0)
    {
      if (inCaptureGraphBuilder == null) throw new ArgumentNullException("inCaptureGraphBuilder");
      if (inDisplayControl == null) throw new ArgumentNullException("inDisplayControl");

      var nFuncRes = 0;
      var oVideoWindow = PrvGetVideoWindow(inCaptureGraphBuilder);
      if (oVideoWindow == null) throw new Exception("グラフビルダーが不正です。");

      var oControl = inDisplayControl;

      // ウィンドウのスタイルを設定する
      nFuncRes = oVideoWindow.put_WindowStyle(
        WindowStyle.Child | WindowStyle.ClipChildren);
      DsError.ThrowExceptionForHR(nFuncRes);

      // 表示先のコントロールを設定する
      nFuncRes = oVideoWindow.put_Owner(
        oControl.Handle);
      DsError.ThrowExceptionForHR(nFuncRes);

      // 表示域のサイズを設定する
      ShSetWindowSize(
        inCaptureGraphBuilder
        , oControl.ClientSize.Width
        , oControl.ClientSize.Height
        , inLeft
        , inTop);

    }

    // ---

    /// <summary>
    /// ビデオ表示の開始
    /// </summary>
    public static void ShStartVideo(
      ICaptureGraphBuilder2 inCaptureGraphBuilder
      , Int32 inStartTime = 3000)
    {
      if (inCaptureGraphBuilder == null) throw new ArgumentNullException("inCaptureGraphBuilder");

      var nFuncRes = 0;
      var oMediaControl = PrvGetMediaControl(inCaptureGraphBuilder);
      if (oMediaControl == null) throw new Exception("グラフビルダーが不正です。");

      // ビデオデータのプレビューを開始する
      nFuncRes = oMediaControl.Run();
      DsError.ThrowExceptionForHR(nFuncRes);

      // カメラが起動するまで待つ
      if (inStartTime > 0) Thread.Sleep(inStartTime);

    }

    /// <summary>
    /// ビデオ表示の停止
    /// </summary>
    public static void ShStopVideo(
      ICaptureGraphBuilder2 inCaptureGraphBuilder)
    {
      if (inCaptureGraphBuilder == null) throw new ArgumentNullException("inCaptureGraphBuilder");

      var nFuncRes = 0;
      var oMediaControl = PrvGetMediaControl(inCaptureGraphBuilder);
      if (oMediaControl == null) throw new Exception("グラフビルダーが不正です。");

      // ビデオデータのプレビューを開始する
      nFuncRes = oMediaControl.Stop();
      DsError.ThrowExceptionForHR(nFuncRes);

    }

    // ---

    /// <summary>
    /// スナップショットの取得
    /// </summary>
    public static Bitmap ShGetSnapShot(
      ICaptureGraphBuilder2 inCaptureGraphBuilder)
    {
      if (inCaptureGraphBuilder == null) throw new ArgumentNullException("inCaptureGraphBuilder");

      var nFuncRes = 0;
      var oSampleGrabber = PrvGetSampleGrabber(inCaptureGraphBuilder);
      var pBuffer = IntPtr.Zero;

      // メディア情報の取得
      var oMediaType = new AMMediaType();
      nFuncRes = oSampleGrabber.GetConnectedMediaType(oMediaType);
      DsError.ThrowExceptionForHR(nFuncRes);

      // バッファサイズの取得
      var nBufferSize = 0;
      nFuncRes = oSampleGrabber.GetCurrentBuffer(
        ref nBufferSize
        , System.IntPtr.Zero);
      DsError.ThrowExceptionForHR(nFuncRes);

      // イメージの取得
      pBuffer = Marshal.AllocHGlobal(nBufferSize);
      nFuncRes = oSampleGrabber.GetCurrentBuffer(
        ref nBufferSize
        , pBuffer);
      DsError.ThrowExceptionForHR(nFuncRes);

      // 画像サイズの取得
      var nWidth = 0;
      var nHeight = 0;
      var oBasicVideo = PrvGetBasicVideo(inCaptureGraphBuilder);
      oBasicVideo.get_VideoWidth(out nWidth);
      oBasicVideo.get_VideoHeight(out nHeight);

      // BITMAPに変換
      //pBuffer += 40;
      var oRes = new Bitmap(
        nWidth
        , nHeight
        , nWidth * 3
        , System.Drawing.Imaging.PixelFormat.Format32bppRgb
        , pBuffer);
      oRes.RotateFlip(RotateFlipType.RotateNoneFlipY);

      return (oRes);

    }

    // ---

    /// <summary>
    /// キャプチャーグラフビルダーの解放
    /// </summary>
    public static void ShReleaseCaptureGraphBuiler(
      ICaptureGraphBuilder2 inCaptureGraphBuilder)
    {
      if (inCaptureGraphBuilder == null) return;

      var oGraphBuilder = PrvGetGraphBuilder(inCaptureGraphBuilder);
      if (oGraphBuilder != null)
      {
        IBaseFilter oFilter;

        oGraphBuilder.FindFilterByName(csFilterName_NullRender, out oFilter);
        if (oFilter != null) Marshal.ReleaseComObject(oFilter);

        oGraphBuilder.FindFilterByName(csFilterName_SampleGrabber, out oFilter);
        if (oFilter != null) Marshal.ReleaseComObject(oFilter);

        //oGraphBuilder.FindFilterByName(csFilterName_Device, out oFilter);
        //if (oFilter != null) Marshal.ReleaseComObject(oFilter);

        Marshal.ReleaseComObject(oGraphBuilder);
      }

      Marshal.ReleaseComObject(inCaptureGraphBuilder);

    }

    #endregion

    #region " --- プライベート関数"

    /// <summary>
    /// DsDevice型をIBaseFilter型に変換する
    /// </summary>
    private static IBaseFilter PrvDsDeviceToBaseFilter(
      DsDevice inDevice)
    {
      if (inDevice == null) throw new ArgumentNullException("inDevice");

      Object oRes;
      Guid oFilterID = typeof(IBaseFilter).GUID;

      // モニカを使用して、デバイスをフィルタ オブジェクトに結びつける
      inDevice.Mon.BindToObject(null, null, ref oFilterID, out oRes);

      return ((IBaseFilter)oRes);

    }

    /// <summary>
    /// グラフビルダーの取得
    /// </summary>
    private static IGraphBuilder PrvGetGraphBuilder(
      ICaptureGraphBuilder2 inValue)
    {
      if (inValue == null) return (null);

      IGraphBuilder oRes = null;
      inValue.GetFiltergraph(out oRes);

      return (oRes);

    }

    /// <summary>
    /// IMediaControlの取得
    /// </summary>
    private static IMediaControl PrvGetMediaControl(
      ICaptureGraphBuilder2 inValue) => (IMediaControl)PrvGetGraphBuilder(inValue);

    /// <summary>
    /// IVideoWindowの取得
    /// </summary>
    private static IVideoWindow PrvGetVideoWindow(
      ICaptureGraphBuilder2 inValue) => (IVideoWindow)PrvGetGraphBuilder(inValue);

    /// <summary>
    /// IBasicVideoの取得
    /// </summary>
    private static IBasicVideo PrvGetBasicVideo(
      ICaptureGraphBuilder2 inValue) => (IBasicVideo)PrvGetGraphBuilder(inValue);

    /// <summary>
    /// SampleGrabberの取得
    /// </summary>
    private static ISampleGrabber PrvGetSampleGrabber(
      ICaptureGraphBuilder2 inValue) 
    {
      var oGraphBuilder = PrvGetGraphBuilder(inValue);
      if (oGraphBuilder == null) return (null);

      var nFuncRes = 0;

      IBaseFilter oSampleGrabber = null;

      nFuncRes = oGraphBuilder.FindFilterByName(
        csFilterName_SampleGrabber
        , out oSampleGrabber);
      DsError.ThrowExceptionForHR(nFuncRes);

      return ((ISampleGrabber)oSampleGrabber);

    }

    #endregion

  }

}
