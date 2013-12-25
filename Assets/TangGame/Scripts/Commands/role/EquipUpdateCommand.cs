//yc 2013/12/4
using System;
using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TangGame.Net;
using System.Collections.Generic;
namespace TangGame
{	
	public class EquipUpdateCommand : SimpleCommand
	{
		public static string NAME = TangGame.Net.EquipUpdatePush.NAME;		
		public override void Execute (INotification notification)
		{
			EquipUpdatePush push = notification.Body as EquipUpdatePush;
			SendNotification(NotificationIDs.ID_ReSetRoleHeroEquipInSite,push);
			SendNotification(NotificationIDs.ID_ToMakeItemUpLevel,(long)push.goodsId);
//			Debug.Log("~~~~~~~~EquipUpdateCommand~~~~~~~~");
		}
	}
}

