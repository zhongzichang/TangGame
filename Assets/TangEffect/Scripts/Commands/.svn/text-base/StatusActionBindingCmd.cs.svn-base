/**
 * Status action binding command
 * Date: 2013/11/8
 * Author: zzc
 */

using PureMVC.Patterns;
using PureMVC.Interfaces;
using UnityEngine;
using TangScene;
using Tang;

namespace TangEffect
{
  public class StatusActionBindingCmd : SimpleCommand
  {

    public const string NAME = "TE_INNER_STATUS_ACTION_BINDING";

    public override void Execute( INotification notification )
    {

      StatusActionBindingBean bean = notification.Body as StatusActionBindingBean;

      if( bean != null )
	{
	  
	  // effect data object
	  TsObject tsobj = new TsObject();

	  tsobj.name = "StatusActionBindingEffect";

	  // animation
	  tsobj.animation = AnimationFactory.SimpleAnimation(false, bean.assetSetId);

	  // effect object
	  GameObject gobj = GameObjectFactory.Instance.NewGobj(tsobj);
	  if( bean.assetId != bean.assetSetId )
	    {
	      // 资源集中包含多种资源
	      SpriteAnimate effectSpriteAnimate = gobj.GetComponent<SpriteAnimate>();
	      effectSpriteAnimate.spriteSetName = bean.assetId.ToString();
	    }
	  
	  // action binding behaviour
	  StatusActionBindingBhvr actionBindingBhvr = gobj.AddComponent<StatusActionBindingBhvr>();
	  actionBindingBhvr.actorId = bean.actorId;
	  actionBindingBhvr.status = bean.status;

	}
    }
  }
}