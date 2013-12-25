/**
 * Tang Effect APIs
 * Date: 2013/11/6
 * Author: zzc
 */

using System;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using TS = TangScene;


namespace TangEffect
{
  public class TE
  {

    /// <summary>
    ///   TE游戏对象名称
    /// </summary>
    public const string GOBJ_NAME = "TE";

    /// <summary>
    ///   特效的默认生存时间
    /// </summary>
    public const float DEFAULT_LIFETIME = 3F;

    /// <summary>
    ///   飞行特效默认的半径
    /// </summary>
    public const float DEFAULT_RADIUS = 10F;
    
    /// <summary>
    ///   特效游戏对象池
    /// </summary>
    private static TsEffectPool pool;


    public static GameObject EnsureTEGobj(List<TsEffect> tsEffectList)
    {

      if( tsEffectList != null )
	{
	  TsEffectFactory factory = TsEffectFactory.NewInstance( tsEffectList );
	  pool = new TsEffectPool( factory );
	}

      if( Cache.teGobj == null )
      {
        Cache.teGobj = GameObject.Find( GOBJ_NAME );
        if( Cache.teGobj == null )
          Cache.teGobj = NewTEGobj();
      }
      
      return Cache.teGobj;
    }


    /// <summary>
    ///   切换选择的角色
    /// </summary>
    public static void SwitchSelectedActor(long actorId)
    {

      if(pool != null)
	{
	  GameObject actorGobj = TS.TS.GetActorGameObject(actorId);
	  if( actorGobj != null )
	    {
	      // 获取选中特效，将特效挂在被选中的人物身上
	      GameObject effectGobj = pool.GetSelectedEffectGobj();
	      effectGobj.transform.parent = actorGobj.transform;
	      effectGobj.transform.localPosition = Vector3.zero;
	      effectGobj.SetActive(true);

	      TS.ActorType actorType = actorGobj.GetComponent<TS.ActorBhvr>().actorType;
	      if( actorType == TS.ActorType.hero )
		{
		  // 如果是英雄，头顶上有特效
		  GameObject heroEffectGobj = pool.GetHeroSelectedEffectGobj();
		  heroEffectGobj.transform.parent = actorGobj.transform;
		  heroEffectGobj.transform.localPosition = new Vector3(0, 5000, 170);
		  heroEffectGobj.SetActive(true);
		  
		}

	    }
	  
	}
      else
	{
	  throw new Exception("TsEffectPool is null");
	}


    }

    /// <summary>
    ///   取消角色选中
    /// </summary>
    public static void CancelSelectActor()
    {

      if(pool != null)
	{
	  GameObject effectGobj = pool.GetSelectedEffectGobj();
	  effectGobj.SetActive(false);

	  GameObject heroEffectGobj = pool.GetHeroSelectedEffectGobj();
	  if( heroEffectGobj.active )
	    {
	      heroEffectGobj.SetActive(false);
	    }
	  
	}
      else
	{
	  throw new Exception("TsEffectPool is null");
	}

    }

    /// <summary>
    ///   角色升级
    /// </summary>
    public static void ActorUpgrade(long actorId)
    {

      if( pool != null )
	{
	  GameObject actorGobj = TS.TS.GetActorGameObject(actorId);
	  if( actorGobj != null )
	    {
	      // 获取特效，将特效挂在被选中的人物身上
	      GameObject effectGobj = pool.GetUpgradeEffectGobj();
	      effectGobj.transform.parent = actorGobj.transform;
	      effectGobj.transform.localPosition = Vector3.zero;
	      effectGobj.SetActive(true);
	    }
	}
      else
	{
	  throw new Exception("TsEffectPool is null");
	}


    }

    /// <summary>
    ///   特效绑定到人物身上
    ///   <param name="targetId">角色ID</param>
    ///   <param name="assetSetId">资源集合ID</param>
    ///   <param name="assetId">资源ID</param>
    /// </summary>

    public static void Binding( long targetId, int assetSetId, int assetId )
    {
      Cache.notificationQueue.Enqueue( new Notification( BindingCmd.NAME,
                                                        new BindingBean(targetId,
                                                                        assetSetId,
                                                                        assetId)));
    }

    /// <summary>
    ///   动作绑定
    ///   <param name="actorId">角色ID</param>
    ///   <param name="assetSetId">资源集合ID</param>
    ///   <param name="assetId">资源ID</param>
    /// </summary>
    public static void ActionBinding(long actorId, int assetSetId, int assetId)
    {
      Cache.notificationQueue.Enqueue( new Notification( ActionBindingCmd.NAME,
                                                        new ActionBindingBean(actorId,
                                                                              assetSetId,
                                                                              assetId) ) );
    }

    /// <summary>
    ///   动作绑定（绑定状态）
    ///   <param name="actorId">目标角色ID</param>
    ///   <param name="status">在此状态下才显示特效，其他状态下特效隐藏</param>
    ///   <param name="assetSetId">资源集合ID</param>
    ///   <param name="assetId">资源ID</param>
    /// </summary>
    public static void ActionBinding(long actorId, TS.CharacterStatus status,
                                     int assetSetId, int assetId)
    {
      Cache.notificationQueue.Enqueue( new Notification(StatusActionBindingCmd.NAME,
                                                        new StatusActionBindingBean(actorId,
                                                                                    status,
                                                                                    assetSetId,
                                                                                    assetId)) );
    }

    /// <summary>
    ///   定向飞行
    ///   <param name="actorId">发出该特效的角色ID</param>
    ///   <param name="direction">方向</param>
    ///   <param name="speed">速度</param>
    ///   <param name="distance">距离，到达这个距离该对象将自我销毁</param>
    ///   <param name="radius">碰撞触发体的半径</param>
    ///   <param name="assetSetId">资源集合ID</param>
    ///   <param name="assetId">资源ID</param>
    /// </summary>
    public static void DirectionalFly(long actorId, Vector3 direction, float speed,
                                      float distance, float radius,
                                      int assetSetId, int assetId)
    {
      Cache.notificationQueue.Enqueue( new Notification(DirectionalFlyCmd.NAME,
                                                        new DirectionalFlyBean( actorId, direction, speed,
                                                                               distance, radius,
                                                                               assetSetId, assetId)));
    }

    /// <summary>
    ///   追踪飞行
    ///   <param name="actorId">发出该特效的角色ID</param>
    ///   <param name="targetId">要追踪的目标角色ID</param>
    ///   <param name="speed">飞行速度</param>
    ///   <param name="lifetime">生存时间，超过这个时间对象将自我销毁</param>
    ///   <param name="radius">碰撞触发体的半径</param>
    ///   <param name="assetSetId">资源集合ID</param>
    ///   <param name="assetId">资源ID</param>
    /// </summary>
    public static void TraceFly(long actorId, long targetId, float speed, float lifetime,
                                float radius, int assetSetId, int assetId, byte tokenCode)
    {
      Cache.notificationQueue.Enqueue( new Notification(TraceFlyCmd.NAME,
                                                        new TraceFlyBean( actorId, targetId,
                                                                         speed, lifetime,
                                                                         radius,
                                                                         assetSetId,
                                                                         assetId,
                                                                         tokenCode) ) );
    }

    /// <summary>
    ///   追踪飞行
    ///   <param name="bean">特效需要的数据</param>
    /// </summary>
    public static void TraceFly( TraceFlyBean bean )
    {
      Cache.notificationQueue.Enqueue( new Notification(TraceFlyCmd.NAME, bean ) );
    }


    /// <summary>
    ///   追踪跑
    ///   <param name="actorId">发出该特效的角色</param>
    ///   <param name="targetId">要追踪的目标</param>
    ///   <param name="speed">速度</param>
    ///   <param name="lifetime">生存时间</param>
    ///   <param name="assetSetId">资源集合ID</param>
    ///   <param name="assetId">资源ID</param>
    /// </summary>
    public static void TraceRun(long actorId, long targetId, float speed, float lifetime,
                                float radius, int assetSetId, int assetId)
    {
      Cache.notificationQueue.Enqueue( new Notification(TraceRunCmd.NAME,
                                                        new TraceRunBean( actorId, targetId,
                                                                         speed, lifetime,
                                                                         radius,
                                                                         assetSetId,
                                                                         assetId)) );
    }

    /// <summary>
    ///   定点播放
    ///   <param name="position">位置</param>
    ///   <param name="lifetime">生存时间</param>
    ///   <param name="assetSetId">资源集合ID</param>
    ///   <param name="assetId">资源ID</param>
    /// </summary>
    public static void FixPoint(Vector3 position, float lifetime, int assetSetId, int assetId)
    {
      Cache.notificationQueue.Enqueue( new Notification( FixPointCmd.NAME ,
                                                        new LifetimeFixPointBean(position, lifetime,
                                                                                 assetSetId, assetId)  ));
    }

    /// <summary>
    ///   定点播放
    ///   <param name="position">位置</param>
    ///   <param name="loop">循环次数，如果是负数则无限次播放，如果是0则播放一次，1则播放2次，如此类推</param>
    ///   <param name="assetSetId">资源集合ID</param>
    ///   <param name="assetId">资源ID</param>
    /// </summary>
    public static void FixPoint(Vector3 position, int loop, int assetSetId, int assetId)
    {
      Cache.notificationQueue.Enqueue( new Notification( FixPointCmd.NAME,
                                                        new LoopFixPointBean( position, loop, assetSetId,
                                                                             assetId)  ));
    }


    private static GameObject NewTEGobj()
    {
      GameObject gobj = new GameObject();
      gobj.name = GOBJ_NAME;
      gobj.AddComponent<TeBhvr>();
      return gobj;
    }


  }
}