/**
 * Actor move
 * Date: 2013/10/14
 * Author: zzc
 */

using PureMVC.Patterns;
using PureMVC.Interfaces;

namespace TangScene
{
  public class ActorMoveCmd : SimpleCommand
  {
    public const string NAME = "TS_INNER_ACTOR_MOVE";
    
    public override void Execute( INotification notification )
    {
      MoveBean bean = notification.Body as MoveBean;
      if( bean != null )
	{
	  if( Cache.actors.ContainsKey( bean.actorId ) )
	    {
	      Cache.actors[ bean.actorId ].SendMessage("Move", bean.vector3);
	    }
	}
    }
    
  }
}