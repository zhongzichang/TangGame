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
namespace nh.ui.mediator
{
	/// <summary>
	/// 背包面板处理相关midiator
	/// create by huxiaobo
	/// </summary>
	public class InfoPanelMediator : BaseMediator
	{
		public new const string NAME = "InfoPanelMediator";
		private string msgStr;
		/// <summary>
		/// 我的构造方法
		/// </summary>
		public InfoPanelMediator () : base(NAME)
		{
			handleTable.Add(NotificationIDs.ID_ShowInfoMessage, ShowInfoMessage);
		}
		/// <summary>
		/// 我感兴趣的消息
		/// </summary>
		/// <returns></returns>
		public override IList<string> ListNotificationInterests ()
		{
			if (interests.Count == 0) {
				interests.Add (NotificationIDs.ID_ShowInfoMessage);
			}
			
			return interests;
		}

		private void ShowInfoMessage(INotification notification)
		{
			msgStr = notification.Body as string;
			if (!isLoad)
				this.StartLoadResAndShow(typeof(InfoPanel).Name);
			else
				this.Show(true);			
		}
		override protected void Show(bool bShow)
		{
			if (m_Panel == null)
				return;
			InfoPanel panel = m_Panel as InfoPanel;
			if (panel != null && !string.IsNullOrEmpty(msgStr))
				panel.UpdateMessage(msgStr);

			base.Show(bShow);
		}
	}
}

