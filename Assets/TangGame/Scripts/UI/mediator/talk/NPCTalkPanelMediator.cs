/*
 * Created by SharpDevelop.
 * User: xbhuang
 * Date: 2013/11/13
 * Time: 20:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TangGame;
using nh.ui.talk;
using UnityEngine;

namespace nh.ui.mediator
{
	/// <summary>
	/// 功能NPC对话面板
	/// </summary>
	public class NPCTalkPanelMediator : BaseMediator
	{
		public new const string NAME = "NPCTalkPanelMediator";
		NPCTalkPanel ntp;
		NPCTalkBean bean;
		/// <summary>
		/// 我的构造方法
		/// </summary>
		public NPCTalkPanelMediator () : base(NAME)
		{
			handleTable.Add (NotificationIDs.ID_OPEN_NPC_TALK_PANEL, OpenNPCTalkPanel);
			handleTable.Add (NotificationIDs.ID_CLOSE_NPC_TALK_PANEL, CloseNPCTalkPanel);
		}
		/// <summary>
		/// 我感兴趣的消息
		/// </summary>
		/// <returns></returns>
		public override IList<string> ListNotificationInterests ()
		{
			if (interests.Count == 0) {
				
				interests.Add (NotificationIDs.ID_OPEN_NPC_TALK_PANEL);
				interests.Add (NotificationIDs.ID_CLOSE_NPC_TALK_PANEL);
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
		/// <summary>
		/// 打开消息对话面板
		/// </summary>
		private void OpenNPCTalkPanel(INotification notification)
		{
			bean = notification.Body as NPCTalkBean;
			if (!isLoad)
				this.StartLoadResAndShow(typeof(NPCTalkPanel).Name);
			else
				this.Show(true);

			SendNotification(NotificationIDs.ID_DisableSceneClick);
		}
		//// <summary>
		/// 关闭消息对话面板
		/// </summary>
		private void CloseNPCTalkPanel(INotification notification){
			this.Show(false);
			SendNotification(NotificationIDs.ID_EnableSceneClick);
		}
		override protected void Show(bool bShow){
			ntp = m_Panel as NPCTalkPanel;
			base.Show(bShow);
			if(bShow)
				ntp.UpdateNPCTalkPanel(bean);
			
		}
		
		override protected void AddEvent()
		{
			if (ntp != null)
			{
				if(ntp.talkBut)
					UIEventListener.Get(ntp.talkBut).onClick += OnTalkButClick;
				if(ntp.npcExitBut)
					UIEventListener.Get(ntp.npcExitBut).onClick += OnNpcExitBut;
				
			}
		}
		override protected void RemoveEvent()
		{
			if (ntp != null)
			{
				if(ntp.talkBut)
					UIEventListener.Get(ntp.talkBut).onClick -= OnTalkButClick;
				if(ntp.npcExitBut)
					UIEventListener.Get(ntp.npcExitBut).onClick -= OnNpcExitBut;
			}
		}
		/// <summary>
		/// 触发点击功能按钮事件并且关闭当前面板
		/// </summary>
		/// <param name='obj'>
		/// Object.
		/// </param>
		private void OnTalkButClick(GameObject obj){
			SendNotification(NotificationIDs.ID_CLOSE_NPC_TALK_PANEL);
		}
		/// <summary>
		/// 关闭当前面板
		/// </summary>
		/// <param name='obj'>
		/// Object.
		/// </param>
		private void OnNpcExitBut(GameObject obj){
			SendNotification(NotificationIDs.ID_CLOSE_NPC_TALK_PANEL);
			
		}
		
	}
	
}
