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
	/// ???
	/// create by huxiaobo
	/// </summary>
	public class ExpPanelMediator : Mediator
	{
		public new const string NAME = "ExpPanelMediator";
		protected delegate void Handle(INotification notification);
		protected Dictionary<string, Handle> handleTable = new Dictionary<string, Handle> ();
		protected List<string> interests = new List<string> ();
		private ExpPanel m_ExpPanel;
		/// <summary>
		/// ??????
		/// </summary>
		public ExpPanelMediator (ExpPanel panel) : base(NAME)
		{
			m_ExpPanel = panel;
			handleTable.Add(NotificationIDs.ID_UpdateExpPanel, UpdateExpPanel);
			handleTable.Add(NotificationIDs.ID_ShowExpEffectFinish, ShowExpEffectFinish);
			this.ShowExpEffectFinish(null);//初始化完成后先更新下显示
		}
		/// <summary>
		/// ???????
		/// </summary>
		/// <returns></returns>
		public override IList<string> ListNotificationInterests ()
		{
			if (interests.Count == 0) {
				interests.Add (NotificationIDs.ID_UpdateExpPanel);
				interests.Add(NotificationIDs.ID_ShowExpEffectFinish);
			}
			
			return interests;
		}
		/// <summary>
		/// ????
		/// </summary>
		/// <param name="notification"></param>
		public override void HandleNotification (INotification notification)
		{
			if (handleTable.ContainsKey (notification.Name)) {
				handleTable [notification.Name] (notification);
			}
		}
		private void UpdateExpPanel(INotification notification)
		{
			SendNotification(NotificationIDs.ID_ShowUIEffect, typeof(ExpFlyEffect).Name );
			
		}
		/// <summary>
		/// 显示特效完成后更新经验值
		/// </summary>
		/// <param name="notification">Notification.</param>
		private void ShowExpEffectFinish(INotification notification)
		{
			if (m_ExpPanel != null)
			{
				HeroNew hero = ActorCache.GetLeadingHero();
//				float value = (float)hero.exp / hero.expMax;
				m_ExpPanel.UpdateShow(hero.exp, hero.expMax);
			}
		}
	}
}

