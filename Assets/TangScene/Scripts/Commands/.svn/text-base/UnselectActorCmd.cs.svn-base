/**
 * Created by emacs
 * Date: 2013/10/11
 * Author: zzc
 */

using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace TangScene
{
  public class UnselectActorCmd : SimpleCommand
  {

    public const string NAME = "TS_UNSELECT_ACTOR";

    public override void Execute( INotification notification )
    {

      long actorId = Cache.selectedActorId;
      if( actorId != 0 && Cache.actors.ContainsKey( actorId ) )
	{
	  SelectedBhvr bhvr = Cache.actors[actorId].GetComponent<SelectedBhvr>();
	  if( bhvr != null )
	    bhvr.enabled = false;
	  
	  Cache.selectedActorId = 0;
	}
    }
    
  }
}