/**
 * Created by emacs
 * Date: 2013/10/10
 * Author: zzc
 */

using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

namespace TangScene
{
  public class SwitchSelectedActorCmd : SimpleCommand
  {
    public const string NAME = "TS_SWITCH_SELECTED_ACTOR";

    public override void Execute( INotification notification )
    {
      long actorId = (long) notification.Body;

      if( actorId != 0 )
	{
	  if( Cache.actors.ContainsKey( actorId ) )
	    {
	      SelectedBhvr newSelectedBhvr = Cache.actors[actorId].GetComponent<SelectedBhvr>();
	      if( newSelectedBhvr != null )
		{
		  
		  // make current selected actor SelectedBhvr disable
		  if( Cache.selectedActorId != 0 
		      && Cache.actors.ContainsKey(Cache.selectedActorId) )
		    {
		      SelectedBhvr currentSelectedBhvr = Cache.actors[Cache.selectedActorId].GetComponent<SelectedBhvr>(); 
		      if(currentSelectedBhvr != null)
			currentSelectedBhvr.enabled = false;

		    }

		  // make new selected actor SelectedBhvr enable
		  newSelectedBhvr.enabled = true;
		}
	      else
		{
		  Cache.actors[actorId].AddComponent<SelectedBhvr>();
		}
	      Cache.selectedActorId = actorId;

	    }
	}
    }
  }
}