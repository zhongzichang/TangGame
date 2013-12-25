//yc 2013/12/6
using System;
using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TangGame.Net;
using System.Collections.Generic;
namespace TangGame
{	
	public class EquipUpgradeStatusCommand : SimpleCommand
	{
		public static string NAME = TangGame.Net.EquipUpgradeResult.NAME;		
		public override void Execute (INotification notification)
		{
			EquipUpgradeResult result = notification.Body as EquipUpgradeResult;
			switch(result.StatusCode){
				case HandlerState.NORMAL:
					Debug.Log("装备升级成功");
					break;
				case HandlerState.EQUIP_UPGRADE_CONDITION_NOT_SATISFIED:
					Debug.Log("装备升级的条件不满足");
					break;
				case HandlerState.EQUIP_ALREADY_TOP:
					Debug.Log("装备已为最高级，无法继续升级/强化");
					break;
				case HandlerState.EQUIP_LV_OVER_HERO_LV:
					Debug.Log("装备的使用等级超过了玩家的等级");
					break;
				case HandlerState.EQUIP_STRONG_FAILED:
					Debug.Log("装备强化失败");
					break;
					
			}
//			Debug.Log("~~~~~~~~EquipUpgradeStatusCommand~~~~~~~~");
		}
	}
}

