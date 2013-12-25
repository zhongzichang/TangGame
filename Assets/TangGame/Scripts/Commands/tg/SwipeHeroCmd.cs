/**
 * swipe hero command
 * Date: ?
 * Auhtor: HuangXiaoBo
 * 
 * Date: 2013/11/7
 * Edit: zzc
 */

using UnityEngine;
using System.Collections;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TS = TangScene;
using TGN = TangGame.Net;

namespace TangGame
{
	/// <summary>
	///   手指划过屏幕选中英雄后的处理
	/// </summary>
	public class SwipeHeroCmd : SimpleCommand
	{
		public static string NAME = "TS_SWIPE_HERO";
		public override void Execute (INotification notification)
		{
			Vector3 traceDis = Config.defaultTraceDistance;
			TangScene.ActorTouchHit actorTouchHit = notification.Body as TangScene.ActorTouchHit;
			long swipedActorId = actorTouchHit.actorId;
			Gesture gesture = actorTouchHit.extraObject as Gesture;
			ActorCache.AddOrUpdateSwipeActorId(swipedActorId);
			ActorCache.AddOrUpdateSwipeHeroId(swipedActorId);
		}
	}
}