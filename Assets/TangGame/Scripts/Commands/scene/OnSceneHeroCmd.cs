/// <summary>
/// create
/// xbhuang
/// 2013/10/24
/// </summary>
using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using TGN = TangGame.Net;
using zyhd.TEffect;
namespace TangGame{
	/// <summary>
	/// 装载当前主角附近的英雄到场景
	/// </summary>
	public class OnSceneHeroCmd :  SimpleCommand {
		public static string NAME = TGN.OnSceneHeroResult.NAME;
		public override void Execute(INotification notification)
		{
			TGN.OnSceneHeroResult result = notification.Body as TGN.OnSceneHeroResult;
			if(result.heros == null || result.heros.Count == 0)
				return;
			foreach(TGN.HeroNew hero in result.heros){
				//如果英雄为自己则跳过
				if(hero.id == ActorCache.leadingActorId){
					continue;	
				}
				ActorCache.AddOrUpdateActor(hero.id , hero);
				TangScene.Actor actor = ActorCache.GetActor(hero.id);
				if(actor != null){
					TangScene.TS.ActorEnter(actor);
				}
			}
		}
	}
}
