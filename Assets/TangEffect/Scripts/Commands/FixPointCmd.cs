/**
 * Fix-point command
 * Date: 2013/11/7
 * Author: zzc
 */

using PureMVC.Patterns;
using PureMVC.Interfaces;
using Tang;
using TangScene;
using UnityEngine;

namespace TangEffect
{
  public class FixPointCmd : SimpleCommand
  {
    public const string NAME = "TE_INNER_FIX_POINT";

    public override void Execute(INotification notification)
    {

      FixPointBean bean = notification.Body as FixPointBean;

      if( bean != null )
	{

	  // effect data object
	  TsObject tsobj = new TsObject();
	  tsobj.name = "FixPointEffect";
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
	  
	  FixPointBhvr fixPointBhvr = gobj.AddComponent<FixPointBhvr>();
	  //actionBindingBhvr.actorId = bean.actorId;

	  
	}
      
    }

  }
}