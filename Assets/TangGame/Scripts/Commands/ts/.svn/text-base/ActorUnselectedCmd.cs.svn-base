/**
 * Actor unselected command
 * 角色取消选中
 * Date: 2013/11/27
 * Author: zzc
 */


using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using TE = TangEffect;

namespace TangGame
{
  public class ActorUnselectedCmd : SimpleCommand
  {
    public override void Execute( INotification notification )
    {
      long actorId = (long) notification.Body;
      TE.TE.CancelSelectActor();
			SendNotification(NotificationIDs.ID_ShowOrHideTargetHeadPanel);
    }
  }
}