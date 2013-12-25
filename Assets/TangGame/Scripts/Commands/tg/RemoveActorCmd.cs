/**
 * Remove actor command
 *
 * Date: ?
 * Author: hxb
 */

using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using TGN = TangGame.Net;
using TS = TangScene;

namespace TangGame
{
  /// <summary>
  /// 清除一个角色的数据
  /// </summary>
  public class RemoveActorCmd : SimpleCommand
  {
    public static string NAME = "TS_REMOVE_ACTOR";
    public override void Execute (INotification notification)
    {

      long id  = (long)notification.Body;
      ActorCache.actors.Remove(id);

      // 如果当前目标被删除则清空当前目标
      if(ActorCache.targetActorId == id )
	{
	  ActorCache.targetActorId = 0;
	}
    }

  }
}