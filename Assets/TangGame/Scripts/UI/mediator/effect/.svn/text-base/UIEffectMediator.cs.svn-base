using UnityEngine;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TangGame.View;
using TangGame;
using TangGame.Net;
using nh.ui.basePanel;
using TangGame.Xml;
using nh.ui.main;
using nh.ui.panel;
using nh.ui.model.vo;
using nh.ui.utils;
namespace nh.ui.mediator
{
	/// <summary>
	/// 背包面板处理相关midiator
	/// create by huxiaobo
	/// </summary>
	public class UIEffectMediator : Mediator
	{
		public new const string NAME = "UIEffectMediator";

		public UIEffectManager m_Manager;
		protected delegate void Handle(INotification notification);
		protected Dictionary<string, Handle> handleTable = new Dictionary<string, Handle> ();
		protected List<string> interests = new List<string> ();
		/// <summary>
		/// 我的构造方法
		/// </summary>
		public UIEffectMediator (UIEffectManager manager) : base(NAME)
		{
			m_Manager = manager;
			handleTable.Add(NotificationIDs.ID_ShowUIEffect, ShowUIEffect);
		}
		/// <summary>
		/// 我感兴趣的消息
		/// </summary>
		/// <returns></returns>
		public override IList<string> ListNotificationInterests ()
		{
			if (interests.Count == 0) {
				interests.Add (TangGame.NotificationIDs.ID_ShowUIEffect);
			}
			
			return interests;
		}
		/// <summary>
		/// 处理通知
		/// </summary>
		/// <param name="notification"></param>
		public override void HandleNotification (INotification notification)
		{
			if (handleTable.ContainsKey (notification.Name)) {
				handleTable [notification.Name] (notification);
			}
		}
		private void ShowUIEffect(INotification notification)
		{
 			string effectName = notification.Body as string;
			m_Manager.showEffect(effectName);

		}
	}
}

