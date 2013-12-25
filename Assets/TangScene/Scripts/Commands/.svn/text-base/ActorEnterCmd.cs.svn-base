/**
 * Created by emacs
 * Date: 2013/10/8
 * Author: zzc
 */

using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

namespace TangScene
{
  public class ActorEnterCmd : SimpleCommand
  {
    public const string NAME = "TS_INNER_SCENE_ACTOR_ENTER";
    
    public override void Execute( INotification notification )
    {

      Actor actor = notification.Body as Actor;
      if( actor != null )
	{
	  if( !Cache.actors.ContainsKey( actor.id ) )
	    {
	      GameObject gobj = GameObjectFactory.Instance.NewGobj( actor );
	      Cache.actors.Add( actor.id, gobj );
	      PureMVC.Patterns.Facade.Instance.SendNotification(NtftNames.ACTOR_CREATED, actor.id);
	    }
	}
    }
  }
}