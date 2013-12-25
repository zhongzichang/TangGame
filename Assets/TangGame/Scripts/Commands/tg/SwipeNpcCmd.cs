/**
 *
 * swipe NPC command
 * Date: 2013/12/4
 * Auhtor: zzc
 * 
 */

using UnityEngine;
using System.Collections;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TS = TangScene;
using TGN = TangGame.Net;
using TangUtils;
using TGX = TangGame.Xml;

namespace TangGame
{

  /// <summary>
  ///   手指划过屏幕选中NPC后的处理
  /// </summary>
  public class SwipeNpcCmd : SimpleCommand
  {

    public static string NAME = "TG_SWIPE_NPC";

    public override void Execute (INotification notification)
    {

      TangScene.ActorTouchHit actorTouchHit = notification.Body as TangScene.ActorTouchHit;

      long swipedActorId = actorTouchHit.actorId;
      Gesture gesture = actorTouchHit.extraObject as Gesture;

      ActorCache.AddOrUpdateSwipeActorId(swipedActorId);
      ActorCache.AddOrUpdateSwipeNpcId(swipedActorId);

      if(ActorCache.swipeNpcIds.Count == 1)
      {

        // 设置当前目标ID为滑中NPC中的第一个ID
        ActorCache.targetActorId = swipedActorId;

        // 追踪目标
        BattleHelper.SprintTrace( swipedActorId );

      }
    }
  }
}