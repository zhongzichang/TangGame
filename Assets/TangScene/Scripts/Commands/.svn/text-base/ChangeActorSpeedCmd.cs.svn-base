/**
 * Change Actor Speed
 * Date: 2013/10/24
 * Author: zzc
 */


using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

namespace TangScene
{
  public class ChangeActorSpeedCmd : SimpleCommand
  {
    public const string NAME = "TS_INNER_CHANGE_ACTOR_SPEED";
    
    public override void Execute( INotification notification )
    {

      ChangeSpeedBean bean =  notification.Body as ChangeSpeedBean;
      if( bean != null )
	{
	  if( Cache.actors.ContainsKey(bean.actorId) )
	    {
	      GameObject gobj = Cache.actors[bean.actorId];
	      Navigable navigable = gobj.GetComponent<Navigable>();
	      if( navigable != null )
		navigable.Speed = bean.speed;
	    }
	}

    }
  }
}