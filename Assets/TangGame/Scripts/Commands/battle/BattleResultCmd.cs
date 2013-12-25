/**
 * 接收到战斗结果后的处理
 *
 * Date: ?
 * Author: hxb
 *
 * Date: 2013/11/14
 * Edit: zzc
 * Desc: 整理代码
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TGN = TangGame.Net;
using TS = TangScene;
using zyhd.TEffect;

namespace TangGame
{
  /// <summary>
  /// Battle result cmd.
  /// </summary>
  public class BattleResultCmd : SimpleCommand
  {

    public static string NAME = TGN.BattleResultPush.NAME;

    public override void Execute (INotification notification)
    {

      TGN.BattleResultPush push = notification.Body as TGN.BattleResultPush;

      if (push != null) {
        
        
        if (push.sourceId == ActorCache.leadingActorId) {
          foreach (TGN.BattleMsg msg in push.battleMsgList) {

	    // 如果目标死亡
            if (msg.targetId == ActorCache.targetActorId && msg.hp <= 0) {
              TS.TS.CancelTrace (ActorCache.leadingActorId);
              break;

            }
          }
        }

        AttackToken token = BattleCache.GetAttackToken (push.sourceId, push.tokenCode);

        // 不存在攻击令牌，则显示战斗结果
        // 存在攻击令牌，则保存战斗结果
        if (token == null)
          SendNotification (ShowBattleResultCmd.NAME, token);
        else
          BattleCache.PutBattleResultPush (push);
      }
    }
  }
}