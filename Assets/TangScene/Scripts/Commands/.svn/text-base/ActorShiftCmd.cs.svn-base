/**
 * Actor shift command
 * Date: 2013/10/31
 * Author: zzc
 */

using PureMVC.Patterns;
using PureMVC.Interfaces;
using UnityEngine;

namespace TangScene
{
  public class ActorShiftCmd : SimpleCommand
  {
    public const string NAME = "TS_INNER_ACTOR_SHIFT";

    public override void Execute( INotification notification )
    {
      MoveBean bean = notification.Body as MoveBean;
      if( bean != null && Cache.actors.ContainsKey( bean.actorId ) )
	{
	  GameObject gobj = Cache.actors[ bean.actorId ];
	  gobj.transform.localPosition = bean.vector3;
	}
    }
  }
}