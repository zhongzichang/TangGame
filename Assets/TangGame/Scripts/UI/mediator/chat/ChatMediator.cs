//yc 2013/11/28
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PureMVC.Patterns;
using TangGame.Net;
using nh.ui.cache;
using TangGame.View;

namespace nh.ui{
	public class ChatMediator : Mediator
	{
		public new const string NAME = "ChatMediator";
		private static List<string> interests = new List<string> ();

		public ChatMediator () : base(NAME)
		{

		}
		public override IList<string> ListNotificationInterests ()
		{
			if (interests.Count == 0) {
				interests.Add (HandleChatMsgPush.NAME);
			}
			return interests;
		}
		public override void HandleNotification (PureMVC.Interfaces.INotification notification)
		{
			
			switch (notification.Name) {
			case HandleChatMsgPush.NAME:
				HandleChatResult (notification.Body as HandleChatMsgPush);
				break;

			}
		}

		private void HandleChatResult (HandleChatMsgPush response)
		{
			Debug.Log(">> Chat content = " + response.content);
			ChatVo chat = new ChatVo();
			chat.channel = response.channel;
			chat.fromName = response.fromName;
			chat.fromId = response.fromId;
			chat.content = response.content;
			chat.vipLevel = response.vipLevel;
			chat.campId = response.campId;
			
			chat.secretName = response.secretName;
			chat.secretId = response.secretId;
			chat.secretVipLevel = response.secretVipLevel;
			chat.secretCampId = response.secretCampId;

			NewChatCache.Add (chat);
		}
	}
}

