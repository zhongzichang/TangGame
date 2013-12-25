/**
 * Actor relive
 * Date: 2013/11/5
 * Author: zzc
 */

using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

namespace TangScene
{
  public class ActorReliveCmd : SimpleCommand
  {
    public const string NAME = "TS_INNER_ACTOR_RELIVE";

    public override void Execute( INotification notification )
    {
      long actorId = (long )notification.Body;

      if( Cache.actors.ContainsKey( actorId ) )
	{
	  GameObject gobj = Cache.actors[ actorId ];
	  CharacterStatusBhvr statusBhvr = gobj.GetComponent<CharacterStatusBhvr>();
	  statusBhvr.Status = CharacterStatus.idle;
	  SpriteAnimate spriteAnimate = gobj.GetComponent<SpriteAnimate>();
	  spriteAnimate.spriteAnimation.Play();
	}
      
    }
  }
}