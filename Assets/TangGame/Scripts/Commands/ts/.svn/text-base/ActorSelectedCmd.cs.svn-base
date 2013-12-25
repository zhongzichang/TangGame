/**
 * Actor selected command
 * 角色选中
 * Date: 2013/11/27
 * Author: zzc
 */


using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using TE = TangEffect;
using TGN=TangGame.Net;


namespace TangGame
{
  public class ActorSelectedCmd : SimpleCommand
  {
    public override void Execute( INotification notification )
    {
      long actorId = (long) notification.Body;

      TE.TE.SwitchSelectedActor(actorId);
			
			//发送选中到服务器，暂时写到这里，因为自动战斗时也会选中
			if (actorId != 0)
				TangNet.TN.Send(new TGN.GetTargetHeadInfoRequest(actorId));


    }
  }
}