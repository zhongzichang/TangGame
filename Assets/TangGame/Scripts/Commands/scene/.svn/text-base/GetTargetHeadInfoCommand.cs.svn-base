/// <summary>
///获取点击对象头像的信息
/// create by huxiaobo
/// 2013.11.27
/// </summary>
using System;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TangGame.Net;
namespace TangGame
{
	public class GetTargetHeadInfoCommand : SimpleCommand
	{
		public static string NAME = GetTargetHeadInfoResult.NAME;
		
		public override void Execute (INotification notification)
		{
			GetTargetHeadInfoResult result = notification.Body as GetTargetHeadInfoResult;
			HeadInfo info = new HeadInfo();
			info.objId = result.objId;
			info.objName = result.objName;
			info.level = result.level;
			if (result.headIcon.Equals("-1"))
			{
				HeroNew hero = ActorCache.GetHeroById(result.objId);
				if (hero != null)
					info.headIcon = Config.GetHeadIcon(hero.genre, hero.sex);
			}
			else
				info.headIcon  = result.headIcon;

			if (result.curHp == -1)//如果为-1，表示当前为NPC，随便给个值
			{
				info.curHp = 100;
				info.maxHp = 100;
			}
			else
			{
				info.curHp = result.curHp;
				info.maxHp = result.maxHp;
			}
			SendNotification(NotificationIDs.ID_ShowOrHideTargetHeadPanel, info);
		}
	}
}

