using UnityEngine;
using System.Collections;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TGN = TangGame.Net;

namespace TangGame
{
	public class UpdateHeroBattleStateCmd : SimpleCommand
	{
		public static string NAME = TGN.UpdateHeroBattleStatePush.NAME;

		public override void Execute (INotification notification)
		{
			TGN.UpdateHeroBattleStatePush push = notification.Body as TGN.UpdateHeroBattleStatePush;
			TGN.HeroNew hero = ActorCache.GetHeroById(push.heroId);
			//如果英雄获取为空的话则跳出此方法不执行
			if(hero == null)
				return;
			hero.stateOfWar = push.isBattleState;
		}
	}
}