using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NapLabCamera
{
  public partial class FrmMenu : Form
  {

    #region " --- コンストラクタ"

    /// <summary>
    /// 作成時
    /// </summary>
    public FrmMenu()
    {
      InitializeComponent();
    }

    #endregion

    #region " --- 定義"

    /// <summary>
    /// デバイスリスト
    /// </summary>
    private DeviceRecord[] moDeviceList;

    #endregion

    #region " --- 画面イベント"

    /// <summary>
    /// ロード時
    /// </summary>
    private void FrmMenu_Load(
      object sender
      , EventArgs e)
    {

      // デバイスリストの設定
      PrvUpdateDeviceList();

    }

    /// <summary>
    /// カメラ映像試験ボタン
    /// </summary>
    private void BtnVideo_Click(
      object sender
      , EventArgs e)
    {

      try
      {
        var oDevice = PrvGetSelectDevice();
        if (oDevice == null) throw new Exception("対象デバイスが不正です。");
        if (oDevice.Value == null) throw new Exception("デバイスを選択してください。");

        var oForm = new FrmTestVideo();
        oForm.TargetDevice = oDevice;
        oForm.ShowDialog(this);

      }
      catch (Exception ex)
      {
        ShareCommon.ShDisplayException(ex);
      }

    }

    /// <summary>
    /// カメラ撮影試験ボタン
    /// </summary>
    private void BtnShot_Click(
      object sender
      , EventArgs e)
    {

      try
      {
        var oDevice = PrvGetSelectDevice();
        if (oDevice == null) throw new Exception("対象デバイスが不正です。");
        if (oDevice.Value == null) throw new Exception("デバイスを選択してください。");

        var oForm = new FrmTestShot();
        oForm.TargetDevice = oDevice;
        oForm.ShowDialog(this);

      }
      catch (Exception ex)
      {
        ShareCommon.ShDisplayException(ex);
      }

    }

    #endregion

    #region " --- プライベート関数"

    /// <summary>
    /// デバイスリストの更新
    /// </summary>
    private void PrvUpdateDeviceList()
    {
      moDeviceList = ShareDirectShow.ShCreateSelectionDeciceList();
      CmbDevice.DisplayMember = "DisplayText";
      CmbDevice.ValueMember = "Value";
      CmbDevice.DataSource = moDeviceList;
      CmbDevice.SelectedIndex = 0;
    }

    /// <summary>
    /// 選択デバイスの取得
    /// </summary>
    private DeviceRecord PrvGetSelectDevice()
    {
      var nIndex = CmbDevice.SelectedIndex;
      if (moDeviceList.Length < nIndex) return (null);
      return (moDeviceList[nIndex]);
    }

    #endregion

  }

}
