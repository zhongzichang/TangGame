/// <summary>
/// xbhuang
/// 2013/11/22
/// </summary>
using UnityEngine;
using System.Collections;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TGN = TangGame.Net;

namespace TangGame
{
  public class SearchNpcResultCmd : SimpleCommand
  {
    public static string NAME = TGN.SearchNpcResult.NAME;

    public override void Execute (INotification notification)
    {
      TGN.SearchNpcResult result = notification.Body as TGN.SearchNpcResult;

      if (result != null) {

        /*
        AutoNavCache.isActive = true;
        AutoNavCache.mode = AutoNavCache.Mode.searchActor;
        AutoNavCache.targetActorConfigId = result.npcId;
        foreach (short portalId in result.portalIds) {
          AutoNavCache.portalQueue.Enqueue (portalId);
        }
        AutoNavHelper.Start ();
        */
        ActorAutoNavBean bean = new ActorAutoNavBean(result.npcId, result.portalIds.ToArray());
        SendNotification(NtftNames.AUTO_NAV, bean);
    
      }

    }
  }
}