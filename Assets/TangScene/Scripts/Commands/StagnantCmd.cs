/**
 * Stagnant command
 * Date: 2013/11/2
 * Author: zzc
 */


using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

namespace TangScene
{
  public class StagnantCmd : SimpleCommand
  {
    public const string NAME = "TS_INNER_STAGNANT";
    
    public override void Execute( INotification notification )
    {

      StagnantBean bean = notification.Body as StagnantBean;
      
      if( bean != null )
	{
	  
	  foreach( long actorId in bean.actorIds )
	    {
	      if( Cache.actors.ContainsKey( actorId ) )
		{
		  GameObject gobj = Cache.actors[ actorId ];
		  StagnantBhvr stagnantBhvr = gobj.GetComponent<StagnantBhvr>();
		  if( stagnantBhvr == null )
		    stagnantBhvr = gobj.AddComponent<StagnantBhvr>();
		  stagnantBhvr.StagnantTime = bean.secondTime;
		}
	    }
	}
    }
  }
}