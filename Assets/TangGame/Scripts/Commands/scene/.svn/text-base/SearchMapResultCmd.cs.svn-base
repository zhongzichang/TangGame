/// <summary>
/// xbhuang
/// 2013/11/22
///
/// 2013/11/23
/// zzc
/// 处理该命令，跨场景自动寻路
/// </summary>
using UnityEngine;
using System.Collections;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TGN = TangGame.Net;

namespace TangGame
{
  public class SearchMapResultCmd : SimpleCommand
  {
    public static string NAME = TGN.SearchMapResult.NAME;

    public override void Execute (INotification notification)
    {
      TGN.SearchMapResult result = notification.Body as TGN.SearchMapResult;
      
      if (result != null && result.portalIds.Count > 0) {
        
        /*
        AutoNavCache.isActive = true;
        AutoNavCache.mode = AutoNavCache.Mode.searchScene;
        foreach (short portalId in result.portalIds) {
          AutoNavCache.portalQueue.Enqueue ((int)portalId);
        }
        AutoNavHelper.Start ();*/
        
        SceneAutoNavBean bean = new SceneAutoNavBean(result.portalIds.ToArray());
        SendNotification(NtftNames.AUTO_NAV, bean);
    
      }

    }
  }
}