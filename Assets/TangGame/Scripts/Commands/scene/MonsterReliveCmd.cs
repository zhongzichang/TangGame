using UnityEngine;
using System.Collections;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TGN = TangGame.Net;
using TS = TangScene;

namespace TangGame
{
	/// <summary>
	/// 怪物复活处理
	/// </summary>
	public class MonsterReliveCmd : SimpleCommand
	{
		public static string NAME = TGN.MonsterRelivePush.NAME;

		public override void Execute (INotification notification)
		{
			TGN.MonsterRelivePush push = notification.Body as TGN.MonsterRelivePush;
			ActorCache.AddOrUpdateActor (push.monster.id, push.monster);
			TangScene.Actor actor = ActorCache.GetActor (push.monster.id);
			if (actor != null) {
				//加入到场景中去
				TangScene.TS.ActorEnter (actor);
			}
		}
	}
}
