/**
 * TangScene Effect Factory
 * 
 * 
 * Date: 2013/11/2
 * Author: zzc
 */

using UnityEngine;
using System.Collections.Generic;
using Tang;
using TangScene;

namespace TangEffect
{

  public class TsEffectFactory
  {
    

    /// <summary>
    ///   特效表
    /// </summary>
    private Dictionary<int ,TsObject> effectTable = null;


    /// <summary>
    ///   私有化构造方法，请使用 NewInstance(List<TsEffect effectList) 方法来创建实例
    /// </summary>
    private TsEffectFactory( Dictionary<int, TsObject> effectTable )
    {
      this.effectTable = effectTable;
    }

    /// <summary>
    ///   创建一个工厂实例
    /// </summary>
    public static TsEffectFactory NewInstance( List<TsEffect> effectList )
    {

      Dictionary<int ,TsObject> effectTable = new Dictionary<int, TsObject>();
      foreach(TsEffect item in effectList)
      {
        TsObject tsobj = new TsObject();
        tsobj.name = item.name;
        tsobj.animation = AnimationFactory.SimpleAnimation(false, item.assetSetId );
        tsobj.scripts = item.scripts;
        effectTable.Add(item.id, tsobj);
      }
      return new TsEffectFactory(effectTable);
    }

    /// <summary>
    ///   创建一个特效游戏对象
    /// </summary>
    public GameObject NewEffect(int id)
    {
      if( effectTable.ContainsKey(id) )
        return GameObjectFactory.Instance.NewGobj(effectTable[id]);
      else
        return null;
    }

  }
}