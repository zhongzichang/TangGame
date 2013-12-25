/**
 * Cancel trace
 *
 * Date: 2013/10/24
 * Author: zzc
 */

using PureMVC.Patterns;
using PureMVC.Interfaces;
using UnityEngine;

namespace TangScene
{
  public class CancelTraceCmd : SimpleCommand
  {

    public const string NAME = "TS_INNER_CANCEL_TRACE";

    public override void Execute(INotification notification)
    {
      long tracerId = (long) notification.Body;
      if( Cache.actors.ContainsKey( tracerId ) )
	{
	  GameObject tracer = Cache.actors[ tracerId ];
	  TracerBhvr tracerBhvr = tracer.GetComponent<TracerBhvr>();
	  if( tracerBhvr != null )
	    {
	      tracerBhvr.enabled = false;
	    }
	}
    }
  }
}