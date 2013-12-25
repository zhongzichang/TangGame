/// <summary>
/// xbhuang
/// 2013
/// </summary>
using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using TGN = TangGame.Net;
namespace TangGame{
	/// <summary>
	/// 追加一个英雄到场景
	/// </summary>
	public class AddHeroOnScenePushCmd : SimpleCommand {
		public static string NAME = TGN.AddHeroOnScenePush.NAME;
		public override void Execute(INotification notification)
		{
			TGN.AddHeroOnScenePush push = notification.Body as TGN.AddHeroOnScenePush;
			TGN.HeroNew hero=push.hero;
			//如果英雄为自己则跳过
			if(ActorCache.GetActor(hero.id)!=null) return;
			ActorCache.AddOrUpdateActor(hero.id , hero);
			TangScene.Actor actor = ActorCache.GetActor(hero.id);
			if(actor != null){
				TangScene.TS.ActorEnter(actor);
			}
			
		}
	}
}
