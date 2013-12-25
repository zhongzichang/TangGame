/**
 * Monster Move Command
 *
 * Date: ?
 * Author: hxb
 */
using UnityEngine;
using System.Collections;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TGN = TangGame.Net;
using TS = TangScene;
using TangUtils;

namespace TangGame
{
  /// <summary>
  /// Monster move cmd.
  /// </summary>
  public class MonsterMoveCmd : SimpleCommand
  {
    public static string NAME = TGN.MonsterMovePush.NAME;

    public override void Execute (INotification notification)
    {
      TGN.MonsterMovePush push = notification.Body as TGN.MonsterMovePush;
      //如果场景没有当前怪物数据将从服务器请求
      if (ActorCache.actors.ContainsKey (push.monsterId)) {
        TS.TS.ActorNavigate (new TS.MoveBean (push.monsterId, GridUtil.PointToVector3 (push.x, push.y)));
      } else {
        TangNet.TN.Send (new TGN.GetMonsterInfoRequest (push.monsterId));
      }
    }
  }
}
