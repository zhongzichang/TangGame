/*
 * Created by SharpDevelop.
 * User: shimudennis
 * Date: 2013/11/4
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
	/// Description of MainGamePanelMediator.
	/// </summary>
	public class MissionTalkPanelMediator : BaseMediator
	{
		public new const string NAME = "MissionTalkPanelMediator";
		MissionTalkPanel mtp;
		MissionTalkBean bean;
		/// <summary>
		/// 我的构造方法
		/// </summary>
		public MissionTalkPanelMediator () : base(NAME)
		{
			handleTable.Add (NotificationIDs.ID_OPEN_MISSION_TALK_PANEL, OpenMissionTalkPanel);
			handleTable.Add (NotificationIDs.ID_CLOSE_MISSION_TALK_PANEL, CloseMissionTalkPanel);
			handleTable.Add (NotificationIDs.ID_UPDATE_MISSION_TALK_PANEL, UpdateMissionTalkPanel);
		}
		/// <summary>
		/// 我感兴趣的消息
		/// </summary>
		/// <returns></returns>
		public override IList<string> ListNotificationInterests ()
		{
			if (interests.Count == 0) {
				
				interests.Add (NotificationIDs.ID_OPEN_MISSION_TALK_PANEL);
				interests.Add (NotificationIDs.ID_CLOSE_MISSION_TALK_PANEL);
				interests.Add (NotificationIDs.ID_UPDATE_MISSION_TALK_PANEL);
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
		private void OpenMissionTalkPanel(INotification notification)
		{
      MissionTalkBean newbean = notification.Body as MissionTalkBean;
      SendNotification(NotificationIDs.ID_DisableSceneClick);
      //如果对话包含任务ID则向服务器反馈任务对话完成
      if(newbean.taskId != 0){
        TangNet.TN.Send(new TangGame.Net.NpcTalkRequest(ActorCache.GetNpcById(newbean.npcId).configId,newbean.taskId));
      }
      //如果是当前面板已经打开和上次重复的话则跳出
      if(bean != null && bean.note == newbean.note){
        if(m_Panel !=null && m_Panel.m_IsShow){
          return;
        }
          
      }
      bean = newbean;
			if (!isLoad)
				this.StartLoadResAndShow(typeof(MissionTalkPanel).Name);
			else
        this.Show(true);


		}
		//// <summary>
		/// 关闭消息对话面板
		/// </summary>
		private void CloseMissionTalkPanel(INotification notification){
			mtp.TalkIndex = 0;
			if(isLoad && m_Panel != null){
				this.Show(false);

        SendNotification(NotificationIDs.ID_EnableSceneClick);
			}
      //如果对话包含任务ID则向服务器反馈任务对话完成
      if(bean.taskId != 0){
        SendNotification(NtftNames.TG_AUTO_TRACK_TASK,bean.taskId);
      }
			//如果回调不为空则回调函数
			if(bean.callback != null){
				bean.callback();
			}
			//如果回调不为空则回调函数
			if(bean.callbackWithObject != null){
				bean.callbackWithObject(bean.NAME,bean.obj);
			}
		}
		/// <summary>
		/// 更新消息对话面板
		/// </summary>
		/// <param name="notification"></param>
		private void UpdateMissionTalkPanel(INotification notification){
			bean = notification.Body as MissionTalkBean;
			mtp = m_Panel as MissionTalkPanel;
		}
		override protected void Show(bool bShow){
			mtp = m_Panel as MissionTalkPanel;
			base.Show(bShow);
			if(bShow)
			{
				if(bean != null){
					//更新数据
					mtp.UpdateMissionTalkPanel(bean);
				}
      }
		}
		
		override protected void AddEvent()
		{
      this.RemoveEvent();
			if (mtp != null)
			{
				if(mtp.missionBut)
					UIEventListener.Get(mtp.missionBut).onClick += OnMissionButClick;
			}
		}
		override protected void RemoveEvent()
		{
			if (mtp != null)
			{
				if(mtp.missionBut)
					UIEventListener.Get(mtp.missionBut).onClick -= OnMissionButClick;
			}
		}
		private void OnMissionButClick(GameObject obj){
			mtp.NextDialogue();
		}
		
		
		
	}
	
}
