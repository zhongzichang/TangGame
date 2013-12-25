/**
 * Actor die
 * Date: 2013/11/5
 * Author: zzc
 */

using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

namespace TangScene
{
  public class ActorDieCmd : SimpleCommand
  {
    public const string NAME = "TS_INNER_ACTOR_DIE";

    public override void Execute( INotification notification )
    {
      long actorId = (long )notification.Body;

      if( Cache.actors.ContainsKey( actorId ) )
	{
	  CharacterStatusBhvr statusBhvr = Cache.actors[ actorId ].GetComponent<CharacterStatusBhvr>();
	  statusBhvr.Status = CharacterStatus.die;
	}
      
    }
  }
}