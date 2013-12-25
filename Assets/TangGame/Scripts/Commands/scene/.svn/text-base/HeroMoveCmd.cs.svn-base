using UnityEngine;
using System.Collections;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TGN = TangGame.Net;
using TS = TangScene;
using TangUtils;

namespace TangGame
{
	/// <summary>
	/// 英雄移动处理
	/// </summary>
	public class HeroMoveCmd : SimpleCommand
	{
		public static string NAME = TGN.HeroMovePush.NAME;

		public override void Execute (INotification notification)
		{
			TGN.HeroMovePush push = notification.Body as TGN.HeroMovePush;
			//如果移动英雄等于当前英雄的话则跳过
			if(push.heroId == ActorCache.leadingActorId)
				return;
			
			
			if(ActorCache.actors.ContainsKey(push.heroId)){
				TS.TS.ActorNavigate (new TS.MoveBean (push.heroId, GridUtil.PointToVector3 (push.endx, push.endy)));
			}
			//如果英雄不在场景中则向服务器请求英雄数据
			else
			{
				TangNet.TN.Send(new TGN.GetHeroInfoRequest(push.heroId));
			}
		}
	}
}
