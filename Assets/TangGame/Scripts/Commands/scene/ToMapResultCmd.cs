using UnityEngine;
using System.Collections;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TGN = TangGame.Net;
using TS = TangScene;

namespace TangGame
{
	public class ToMapResultCmd : SimpleCommand
	{
		public static string NAME = TGN.ToMapResult.NAME;

		public override void Execute (INotification notification)
		{
			TGN.ToMapResult result = notification.Body as TGN.ToMapResult;
			if (result != null && result.mapId != 0) {
				TGN.ActorNo actor = ActorCache.GetLeadingActor ();
				actor.x = result.x;
				actor.y = result.y;
				TGN.HeroNew hero = ActorCache.GetLeadingHero();
				hero.mapName = result.mapName;
        //清空除了主角的其它角色数据
        ActorCache.ClearExceptLeadingActor();
				TS.TS.LoadScene (result.mapId);
				ActorCache.GetLeadingHero ().mapId = result.mapId;
			}
		}
	} 
}