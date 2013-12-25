/**
 * Trace Fly command
 * Date: 2013/11/7
 * Author: zzc
 */

using PureMVC.Patterns;
using PureMVC.Interfaces;
using UnityEngine;
using TangScene;
using Tang;

namespace TangEffect
{
  public class TraceFlyCmd : SimpleCommand
  {
    
    public const string NAME = "TE_INNER_TRACE_FLY";

    public override void Execute(INotification notification)
    {
      
      TraceFlyBean bean = notification.Body as TraceFlyBean;

      if( bean != null )
	{

	  TsObject tsobj = new TsObject();
	  tsobj.name = "TraceFlyEffect";

	  // animation
	  tsobj.animation = AnimationFactory.SimpleAnimation(true, bean.assetSetId);

	  // effect object
	  GameObject gobj = GameObjectFactory.Instance.NewGobj(tsobj);
	  if( bean.assetId != bean.assetSetId )
	    {
	      // 资源集合中包含多种资源
	      SpriteAnimate effectSpriteAnimate = gobj.GetComponent<SpriteAnimate>();
	      effectSpriteAnimate.spriteSetName = bean.assetId.ToString();
	    }
	  
	  // trace fly
	  TraceFlyBhvr traceFlyBhvr = gobj.AddComponent<TraceFlyBhvr>();
	  traceFlyBhvr.actorId = bean.actorId;
	  traceFlyBhvr.targetId = bean.targetId;
	  traceFlyBhvr.speed = bean.speed;
	  traceFlyBhvr.tokenCode = bean.tokenCode;

	  // lifetime
	  if( bean.lifetime > 0 )
	    {
	      LifetimeDestroyBhvr lifetimeDestroyBhvr = gobj.AddComponent<LifetimeDestroyBhvr>();
	      lifetimeDestroyBhvr.lifetime = bean.lifetime;
	    }

	  // trigger
	  SphereCollider sc = gobj.AddComponent<SphereCollider>();
	  sc.center = new Vector3(0,3,0);
	  sc.radius = bean.radius;
	  sc.isTrigger = true;
	  
	}
    }
  }
}