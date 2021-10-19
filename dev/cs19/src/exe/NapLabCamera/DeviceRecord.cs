using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectShowLib;

namespace NapLabCamera
{
  
  /// <summary>
  /// デバイスレコード
  /// </summary>
  public class DeviceRecord
    : IKeyValueRecord<Guid, DsDevice>
  {

    #region " --- コンストラクタ"

    /// <summary>
    /// 作成時
    /// </summary>
    public DeviceRecord(
      DsDevice inValue)
    {
      if (inValue == null) throw new ArgumentNullException("inValue");
      moValue = inValue;
      moKey = inValue.ClassID;
      msDisplayText = inValue.Name;
    }

    /// <summary>
    /// 作成時
    /// </summary>
    public DeviceRecord(
      String inDisplayText)
    {
      if (String.IsNullOrWhiteSpace(inDisplayText) == true) throw new ArgumentNullException("inDisplayText");
      moValue = null;
      moKey = Guid.Empty;
      msDisplayText = inDisplayText;
    }

    #endregion  

    #region " --- IKeyValueRecordインターフェースの実装"

    /// <summary>
    /// キー
    /// </summary>
    public Guid Key
    {
      get => moKey;
    }
    private Guid moKey;

    /// <summary>
    /// 値
    /// </summary>
    public DsDevice Value
    {
      get => moValue;
    }
    private DsDevice moValue;

    /// <summary>
    /// 表示テキスト
    /// </summary>
    public String DisplayText
    {
      get => msDisplayText;
    }
    private String msDisplayText;

    #endregion

    }

}
