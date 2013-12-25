/**
 * Action Binding command
 * Date: 2013/11/6
 * Author: zzc
 */

using PureMVC.Patterns;
using PureMVC.Interfaces;
using UnityEngine;
using TangScene;
using Tang;

namespace TangEffect
{
  public class ActionBindingCmd : SimpleCommand
  {

    public const string NAME = "TE_INNER_ACTION_BINDING";

    public override void Execute( INotification notification )
    {

      ActionBindingBean bean = notification.Body as ActionBindingBean;

      if( bean != null )
	{
	  
	  // effect data object
	  TsObject tsobj = new TsObject();
	  tsobj.name = "ActionBindingEffect";
	  // animation
	  tsobj.animation = AnimationFactory.SimpleAnimation(false, bean.assetSetId);

	  // effect object
	  GameObject gobj = GameObjectFactory.Instance.NewGobj(tsobj);
	  if( bean.assetId != bean.assetSetId )
	    {
	      // 资源集合中包含多种资源
	      SpriteAnimate effectSpriteAnimate = gobj.GetComponent<SpriteAnimate>();
	      effectSpriteAnimate.spriteSetName = bean.assetId.ToString();
	    }
	  
	  ActionBindingBhvr actionBindingBhvr = gobj.AddComponent<ActionBindingBhvr>();
	  actionBindingBhvr.actorId = bean.actorId;
	  
	}
    }
  }
}