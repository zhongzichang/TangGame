/*
 * Switch controlled actor
 *
 * Date: 2013/10/10
 * Author: zzc
 */
using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

namespace TangScene
{
  public class SwitchControlledActorCmd : SimpleCommand
  {

    public const string NAME = "TS_SWITCH_CONTROLLED_ACTOR";

    public override void Execute (INotification notification)
    {

      long actorId = (long)notification.Body;

      if (actorId != 0)
      {
        if (Cache.actors.ContainsKey (actorId))
        {

          GameObject ncGobj = Cache.actors [actorId];
          ControlledBhvr newControlledBhvr = ncGobj.GetComponent<ControlledBhvr> ();

          if (newControlledBhvr != null)
          {
            
	    
            // make current controlled actor ControlledBhvr disable
            if (Cache.controlledActorId != 0
                && Cache.actors.ContainsKey (Cache.controlledActorId))
            {


	      // 放弃对当前控制角色的控制
	      GameObject ccGobj = Cache.actors [Cache.controlledActorId];
              ControlledBhvr currentControlledBhvr = ccGobj.GetComponent<ControlledBhvr> ();
              if (currentControlledBhvr != null)
                currentControlledBhvr.enabled = false;

            }

	    // 控制新角色
            // make new controlled actor ControlledBhvr enable
            newControlledBhvr.enabled = true;

	    // 声明控制的新角色
            Cache.controlledActorId = actorId;
            
          }
          else
          {
            ncGobj.AddComponent<ControlledBhvr> ();
          }

          
        }
      }
    }
  }
}