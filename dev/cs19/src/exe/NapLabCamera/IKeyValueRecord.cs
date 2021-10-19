using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapLabCamera
{

  /// <summary>
  /// キーと値のインターフェース
  /// </summary>
  public class IKeyValueRecord<TKey,TValue>
  {

    #region " --- プロパティ"

    /// <summary>
    /// キー
    /// </summary>
    TKey Key
    {
      get;
    }

    /// <summary>
    /// 値
    /// </summary>
    TValue Value
    {
      get;
    }

    /// <summary>
    /// 表示テキスト
    /// </summary>
    String DisplayText
    {
      get;
    }

    #endregion

  }

}
