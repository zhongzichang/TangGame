/// <summary>
/// xbhuang
/// 2013/11/7
/// </summary>
using UnityEngine;
using System.Collections;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TGN = TangGame.Net;
using TS = TangScene;
using TangUtils;
namespace TangGame
{
	public class HeroRvisePointCmd : SimpleCommand
	{
		public static string NAME = TGN.HeroRvisePointPush.NAME;
		public override void Execute (INotification notification)
		{
			
			TGN.HeroRvisePointPush push = notification.Body as TGN.HeroRvisePointPush;
			if(ActorCache.actors.ContainsKey(push.heroId)){
				TS.TS.CancelTrace(push.heroId);
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