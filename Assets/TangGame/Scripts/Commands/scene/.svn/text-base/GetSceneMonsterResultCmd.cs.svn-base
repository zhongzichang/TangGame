/**
 * Monster Move Command
 *
 * Date: 2013/11/21
 * Author: xbhuang
 */
using UnityEngine;
using System.Collections;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TGN = TangGame.Net;
using TS = TangScene;
using TangUtils;
namespace TangGame{
  public class GetSceneMonsterResultCmd :SimpleCommand{
    public static string NAME = TGN.GetSceneMonsterResult.NAME;
    public override void Execute (INotification notification)
    {
      TGN.GetSceneMonsterResult getSceneMonster = notification as TGN.GetSceneMonsterResult;
      TGN.Monster monster = getSceneMonster.monster;
      ActorCache.AddOrUpdateActor (monster.id, monster);
      TangScene.Actor actor = ActorCache.GetActor (monster.id);
      if (actor != null)
        TangScene.TS.ActorEnter (actor);

    }
  }

}