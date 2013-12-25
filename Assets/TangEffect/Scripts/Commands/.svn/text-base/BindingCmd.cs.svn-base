/**
 * Binding command
 * Date: 2013/11/18
 * Author: zzc
 */


using PureMVC.Patterns;
using PureMVC.Interfaces;
using UnityEngine;
using TangScene;
using Tang;

namespace TangEffect
{
  public class BindingCmd : SimpleCommand
  {

    public const string NAME = "TE_INNER_BINDING";

    public override void Execute( INotification notification )
    {

      BindingBean bean = notification.Body as BindingBean;

      if( bean != null )
	{
	  
	  // effect data object
	  TsObject tsobj = new TsObject();
	  tsobj.name = "BindingEffect";
	  // animation
	  tsobj.animation = AnimationFactory.SimpleAnimation(0, true, bean.assetSetId);

	  // effect object
	  GameObject gobj = GameObjectFactory.Instance.NewGobj(tsobj);
	  if( bean.assetId != bean.assetSetId )
	    {
	      // 资源集合中包含多种资源
	      SpriteAnimate effectSpriteAnimate = gobj.GetComponent<SpriteAnimate>();
	      effectSpriteAnimate.spriteSetName = bean.assetId.ToString();
	    }
	  
	  BindingBhvr bindingBhvr = gobj.AddComponent<BindingBhvr>();
	  bindingBhvr.targetId = bean.targetId;
	  
	}
    }
  }
}