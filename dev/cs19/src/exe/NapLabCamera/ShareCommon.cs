using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace NapLabCamera
{
  
  /// <summary>
  /// 共有共通モジュール
  /// </summary>
  public static class ShareCommon
  {

    /// <summary>
    /// ディレクトリ区切り文字
    /// </summary>
    public static readonly String ShDirectorySeparator = Path.DirectorySeparatorChar.ToString();
    public static readonly String ShDirectoryNetwork = ShDirectorySeparator + ShDirectorySeparator;
    public static readonly String ShDirectoryDrive = ":" + ShDirectorySeparator;

    /// <summary>
    /// パス名の後ろに区切り記号を付加して返す
    /// </summary>
    public static String ShAddPathSeparator(
      String inValue)
    {
      if (String.IsNullOrWhiteSpace(inValue) == true) return (String.Empty);

      var sRes = inValue.Trim();
      if (sRes.EndsWith(ShDirectorySeparator) == false) sRes += ShDirectorySeparator;
      return (sRes);

    }

    /// <summary>
    /// パス名の先頭の区切り記号を取り除く
    /// </summary>
    public static String ShRemoveStartPathSeparator(
      String inValue)
    {
      if (String.IsNullOrWhiteSpace(inValue) == true) return (String.Empty);

      var sRes = inValue.Trim();
      if (sRes.StartsWith(ShDirectorySeparator) == false) return (sRes);
      return (sRes.Substring(1));

    }

    /// <summary>
    /// ファイル名を省いたパス名の取得
    /// </summary>
    public static String ShGetPathName(
      String inValue)
    {
      if (String.IsNullOrWhiteSpace(inValue) == true) return (String.Empty);

      String sRes = inValue.Trim();
      var nIndex = sRes.LastIndexOf(ShDirectorySeparator);
      if (nIndex == -1) return (sRes);
      return (sRes.Substring(0, nIndex + 1));

    }

    /// <summary>
    /// ファイル名を取得
    /// </summary>
    public static String ShGetFileName(
      String inValue)
    {
      if (String.IsNullOrWhiteSpace(inValue) == true) return (String.Empty);

      String sRes = inValue.Trim();
      var nIndex = sRes.LastIndexOf(ShDirectorySeparator);
      if (nIndex == -1) return (sRes);
      return (sRes.Substring(nIndex));

    }

    /// <summary>
    /// アプリパスの取得
    /// </summary>
    public static String ShGetAppPath()
    {
      var sRes = Assembly.GetExecutingAssembly().Location;
      return (ShGetPathName(sRes));
    }

    /// <summary>
    /// パスタイプの取得
    /// </summary>
    public static EnPathType ShGetPathType(
      String inValue)
    {
      if (String.IsNullOrWhiteSpace(inValue) == true) return (EnPathType.None);
      
      var sPathName = inValue;
      if (sPathName.StartsWith(ShDirectoryNetwork) == true) return (EnPathType.Absolute);
      if ((sPathName.Substring(1,2) == ShDirectoryDrive) == true) return (EnPathType.Absolute);
      return (EnPathType.Relative);
    }

    /// <summary>
    /// 絶対パス名の取得
    /// </summary>
    public static String ShGetAbsolutePathName(
      String inValue)
    {
      if (String.IsNullOrWhiteSpace(inValue) == true) return (ShGetAppPath());

      var sPathName = ShGetPathName(inValue);
      var nPathType = ShGetPathType(sPathName);
      if (nPathType == EnPathType.None) return (ShGetAppPath());
      if (nPathType == EnPathType.Absolute) return (sPathName);

      var sRes =ShAddPathSeparator(ShGetAppPath() + ShRemoveStartPathSeparator(sPathName));
      return (sRes);

    }

    /// <summary>
    /// 例外表示
    /// </summary>
    public static void ShDisplayException(
      Exception inException)
    {
      if (inException == null) return;

      var oSB = new StringBuilder();
      var oEX = inException;
      for (; ; )
      {
        if (oEX == null) break;
        oSB.AppendLine(oEX.Message);
        oEX = oEX.InnerException;
      }

      MessageBox.Show(
        oSB.ToString()
        , "例外"
        , MessageBoxButtons.OK
        , MessageBoxIcon.Warning);

      //MessageBox.Show(
      //  inException.StackTrace
      //  , "例外"
      //  , MessageBoxButtons.OK
      //  , MessageBoxIcon.Warning);

    }

    /// <summary>
    /// フォームタイトルの作成
    /// </summary>
    public static String ShCreateFormTitle(
      String inTitle
      , DeviceRecord inDevice)
    {
      var oRes = new StringBuilder();
      oRes.Append(inTitle);
      if (inDevice != null)
      {
        oRes.Append(" (");
        oRes.Append(inDevice.DisplayText);
        oRes.Append(')');
      }
      return (oRes.ToString());
    }
  }

}
