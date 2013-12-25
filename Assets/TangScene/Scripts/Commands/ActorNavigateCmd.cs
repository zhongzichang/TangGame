/*
 * Created by emacs
 * Date: 2013/10/9
 * Author: zzc
 */

using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;


namespace TangScene
{
  public class ActorNavigateCmd : SimpleCommand
  {

    public const string NAME = "TS_ACTOR_NAVIGATE";
    
    public override void Execute( INotification notification )
    {

      MoveBean bean = notification.Body as MoveBean;
      if( bean != null )
	{

	  if( Cache.actors.ContainsKey( bean.actorId ) )
	    {
	      Navigable navigable = Cache.actors[bean.actorId].GetComponent<Navigable>();
	      if( navigable != null )
		{
		  navigable.NavTo( bean.vector3 );
		}
	    }
	}
    }
  }
}