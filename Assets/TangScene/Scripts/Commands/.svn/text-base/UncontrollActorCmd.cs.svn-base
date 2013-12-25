/*
 * uncontroll actor
 *
 * Date: 2013/10/30
 * Author: zzc
 */
using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

namespace TangScene
{
  public class UncontrollActorCmd : SimpleCommand
  {

    public const string NAME = "TS_UNCONTROLL_ACTOR";

    public override void Execute (INotification notification)
    {

      // make current controlled actor ControlledBhvr disable
      if (Cache.controlledActorId != 0 
	  && Cache.actors.ContainsKey (Cache.controlledActorId))
	{
	  ControlledBhvr controlledBhvr = Cache.actors [Cache.controlledActorId].GetComponent<ControlledBhvr> (); 
	  if (controlledBhvr != null)
	    {
	      controlledBhvr.enabled = false;
	      Cache.controlledActorId = 0;
	    }

      }
    }
  }
}