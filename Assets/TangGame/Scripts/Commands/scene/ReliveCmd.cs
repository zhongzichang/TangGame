using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using TGN = TangGame.Net;
using TS = TangScene;

namespace TangGame
{
	public class ReliveCmd : SimpleCommand
	{
		public static string NAME = TGN.ReliveResult.NAME;
		public override void Execute (INotification notification)
		{
			TGN.ReliveResult result = notification.Body as TGN.ReliveResult;
			TGN.HeroNew hero = ActorCache.GetLeadingHero();
			//TODO i will write something !
			hero.hp = result.heroHp;
			hero.x = result.x;
			hero.y = result.y;
			GameObject actorObject = TS.TS.GetActorGameObject(hero.id);
			if(actorObject !=null){
				actorObject.GetComponent<NavMeshAgent>().enabled = true;
			}
			if(result.gameMapId != hero.mapId){
				hero.mapId = result.gameMapId;
				TS.TS.LoadScene(result.gameMapId);

			}
			else
			{
			  //TangNet.TN.Send(new TGN.SceneMonsterRequest());
			  //TangNet.TN.Send(new TGN.SceneHeroRequest());
			  TS.TS.ActorRelive( hero.id );

			  //注销场景手势输入操作
			  SendNotification(NtftNames.UN_REGISTER_GESTURE_INPUT);
			  //注册场景手势输入操作
			  SendNotification(NtftNames.ON_REGISTER_GESTURE_INPUT);

			  SendNotification(NtftNames.TG_LEADING_ACTOR_RELIVE);
			  
			}
		}

	}
}