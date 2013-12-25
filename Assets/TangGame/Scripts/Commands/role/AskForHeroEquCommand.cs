// yc
// 2013.11.13
using System;
using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TangGame.Net;
using System.Collections.Generic;
namespace TangGame
{

	public class AskForHeroEquCommand : SimpleCommand
	{
		public const string NAME = TangGame.Net.AskForHeroEquResult.NAME;		
		public override void Execute (INotification notification)
		{
			AskForHeroEquResult result = notification.Body as AskForHeroEquResult;
			SendNotification(NotificationIDs.ID_RequestMyHeroEqu,result);

		}
	}
}

