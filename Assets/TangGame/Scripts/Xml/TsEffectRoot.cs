/**
 * TangScene Effect Root
 * 映射到特效表
 *
 * Date: 2013/11/12
 * Author: zzc
 */

using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using UnityEngine;
using TangUtils;
using TangEffect;

namespace TangGame.Xml
{

  [XmlRoot ("root")]
  [XmlLate ("ts_effect")]
  public class TsEffectRoot
  {

    [XmlElement("value")]
    public List<TsEffect> items = new List<TsEffect>();

    public static void LateProcess( object obj )
    {
      TsEffectRoot root = obj as TsEffectRoot;
      foreach( TsEffect item in root.items )
        Config.tsEffectTable.Add( item.id, item  );
    }

  }
}