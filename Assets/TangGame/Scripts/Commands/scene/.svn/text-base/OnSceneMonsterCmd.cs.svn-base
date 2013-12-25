/**
 * OnSceneMonsterCmd
 *
 * Date: ?
 * Author: hxb
 */
using UnityEngine;
using System.Collections;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TGN = TangGame.Net;
using zyhd.TEffect;

namespace TangGame
{
  /// <summary>
  /// On scene monster cmd.
  /// </summary>
  public class OnSceneMonsterCmd : SimpleCommand
  {
    public static string NAME = TGN.OnSceneMonsterResult.NAME;

    public override void Execute (INotification notification)
    {

      TGN.OnSceneMonsterResult result = notification.Body as TGN.OnSceneMonsterResult;
      foreach (TGN.Monster monster in result.monsters) {
        ActorCache.AddOrUpdateActor (monster.id, monster);
        TangScene.Actor actor = ActorCache.GetActor (monster.id);
        if (actor != null)
          TangScene.TS.ActorEnter (actor);
      }
    }
  }
}
