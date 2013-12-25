/**
 * Actor trace
 *
 * Date: 2013/10/24
 * Author: zzc
 */

using PureMVC.Patterns;
using PureMVC.Interfaces;
using UnityEngine;

namespace TangScene
{
  public class ActorReTraceCmd : SimpleCommand
  {
    
    public const string NAME = "TS_INNER_ACTOR_RE_TRACE";

    public override void Execute(INotification notification)
    {
      long actorId = (long) notification.Body;
      if( actorId != null )
	{
	  if( Cache.actors.ContainsKey( actorId ) )
	    {
	      GameObject tracer = Cache.actors[ actorId ];
	      TracerBhvr tracerBhvr = tracer.GetComponent<TracerBhvr>();
	      if( tracerBhvr == null )
		tracerBhvr = tracer.AddComponent<TracerBhvr>();
	      
	      if( !tracerBhvr.enabled )
		tracerBhvr.enabled = true;
	      else
		tracerBhvr.TraceStart();

	    }
	}
    }
  }
}