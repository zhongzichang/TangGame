using UnityEngine;
using System.Collections.Generic;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using TGN = TangGame.Net;
using TS = TangScene;

namespace TangGame
{
	/// <summary>
	/// 清除多个角色的数据
	/// </summary>
	public class RemoveActorsCmd : SimpleCommand
	{
		public static string NAME = "TS_REMOVES_ACTOR";
		public override void Execute (INotification notification)
		{
			List<long> ids = notification.Body as List<long>;
			foreach(long id in ids){
				SendNotification(RemoveActorCmd.NAME,id);
			}
		}

	}
}