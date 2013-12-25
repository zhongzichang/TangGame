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
	public class UpdateTargetInfoCmd : SimpleCommand
	{
		public static string NAME = UpdateTargetInfoPush.NAME;
		
		public override void Execute (INotification notification)
		{
			UpdateTargetInfoPush result = notification.Body as UpdateTargetInfoPush;
			HeadInfo info = new HeadInfo();
			info.objId = result.objId;
			info.level = result.level;
			info.curHp = result.curHp;
			info.maxHp = result.maxHp;
			SendNotification(NotificationIDs.ID_UpdateTargetHeadPanel, info);
		}
	}
}

