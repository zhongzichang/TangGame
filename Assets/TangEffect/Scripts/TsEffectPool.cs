/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/11/27
 * Time: 18:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using UnityEngine;
using TS = TangScene;

namespace TangEffect
{
  
  
  public class TsEffectPool {


    public const int SELECTED_ID = 1;
    public const int UPGRADE_ID = 2;
    public const int HERO_SELECTED_ID = 3;
    

    /// <summary>
    ///   特效工厂
    /// </summary>
    private TsEffectFactory factory = null;
  
    /// <summary>
    ///   被选中效果
    /// </summary>
    private GameObject selectedEffectGobj = null;

    /// <summary>
    ///   升级效果
    /// </summary>
    private GameObject upgradeEffectGobj = null;

    /// <summary>
    ///   英雄被选中的效果
    /// </summary>
    private GameObject heroSelectedEffectGobj = null;

    /// <summary>
    ///   特效游戏对象表
    /// </summary>
    private Dictionary<int, Queue<GameObject>> gobjTable = new Dictionary<int, Queue<GameObject>>();
    
    /// <summary>
    ///   构造方法
    /// </summary>
    public TsEffectPool(TsEffectFactory factory)
    {
      this.factory = factory;
    }

    /// <summary>
    ///   获取被选中效果
    /// </summary>
    public GameObject GetSelectedEffectGobj()
    {
      if( selectedEffectGobj == null )
	selectedEffectGobj = Get(SELECTED_ID);

      return selectedEffectGobj;

    }

    /// <summary>
    ///   获取英雄升级特效
    /// </summary>
    public GameObject GetUpgradeEffectGobj()
    {
      if( upgradeEffectGobj == null )
	upgradeEffectGobj = Get(UPGRADE_ID);

      return upgradeEffectGobj;
    }

    /// <summary>
    ///   获取英雄被选中的特效
    /// </summary>
    public GameObject GetHeroSelectedEffectGobj()
    {
      if( heroSelectedEffectGobj == null )
	heroSelectedEffectGobj = Get(HERO_SELECTED_ID);

      return heroSelectedEffectGobj;
    }

    
    /// <summary>
    ///   释放对一个特效游戏对象的占用
    /// </summary>
    public void Release(GameObject gobj)
    {

      // TODO 需要优化
      GameObject.Destroy(gobj);
    }
    
    /// <summary>
    ///   获取一个特效游戏对象
    /// </summary>
    public GameObject Get(int configId){

      // TODO 需要优化
      return factory.NewEffect(configId);

    }
  
  }
  
}
