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
using nh.ui.basePanel;

namespace nh.ui.mediator
{
	/// <summary>
	/// Description of MainGamePanelMediator.
	/// </summary>
	public class MissionAwardPanelMediator : BaseMediator
	{
		public new const string NAME = "MissionAwardPanelMediator";
		MissionAwardPanel map;
		MissionAwardBean bean;
    TangGame.Net.Npc npc;
		/// <summary>
		/// 我的构造方法
		/// </summary>
		public MissionAwardPanelMediator () : base(NAME)
		{
			handleTable.Add (NotificationIDs.ID_OPEN_MISSION_AWARD_PANEL,OpenMissionAwardPanel);
			handleTable.Add (NotificationIDs.ID_CLOSE_MISSION_AWARD_PANEL,CloseMissionAwardPanel);
		}
		/// <summary>
		/// 我感兴趣的消息
		/// </summary>
		/// <returns></returns>
		public override IList<string> ListNotificationInterests ()
		{
			if (interests.Count == 0) {
				interests.Add (NotificationIDs.ID_OPEN_MISSION_AWARD_PANEL);
				interests.Add (NotificationIDs.ID_CLOSE_MISSION_AWARD_PANEL);
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
		private void OpenMissionAwardPanel(INotification notification)
		{
			bean = notification.Body as MissionAwardBean;
      //如果数据是空的则不打开面板
      if(bean == null){
        return;
      }
      //如果npcId不为空
      if(bean.npcId != 0){
        npc = ActorCache.GetNpcById(bean.npcId);
      }
			if (!isLoad)
				this.StartLoadResAndShow(typeof(MissionAwardPanel).Name);
			else
				this.Show(true);

      SendNotification(NotificationIDs.ID_DisableSceneClick);
		}
		//// <summary>
		/// 关闭消息对话面板
		/// </summary>
		private void CloseMissionAwardPanel(INotification notification){
			this.Show(false);
			SendNotification(NotificationIDs.ID_EnableSceneClick);
		}
		override protected void Show(bool bShow){
			map = m_Panel as MissionAwardPanel;
			base.Show(bShow);
			if(bShow)
			{
				if(bean != null){
					map.UpdateMissionAwardPanel(bean);
				}
			}else{
				map.expLabel.SetActive(false);
				map.expValue.SetActive(false);
				map.goldLabel.SetActive(false);
				map.goldValue.SetActive(false);
				
				for(int i = 0;i < map.itemGrid.transform.childCount;i++){
					Transform item = map.itemGrid.transform.GetChild(i);
					GameObject.Destroy(item.gameObject);
				}
			}
		}
		
		override protected void AddEvent()
		{
			if (map != null)
			{
				if(map.missionBut){
					UIEventListener.Get(map.missionBut).onClick += OnMissionButClick;
				}
			}
		}
		override protected void RemoveEvent()
		{
			if (map != null)
			{
				if(map.missionBut){
					UIEventListener.Get(map.missionBut).onClick -= OnMissionButClick;
				}
			}
		}
		private void OnMissionButClick(GameObject obj){
			//如果状态是空则接受任务
			if(bean.taskState == TaskState.NONE){
				TangNet.TN.Send(new TangGame.Net.AddTaskRequest(bean.taskId, npc.configId ,ActorCache.GetLeadingHero().mapId));
			}
			//如果状态是完成未交付则完成任务
			if(bean.taskState == TaskState.UNTO){
				TangNet.TN.Send(new TangGame.Net.FinishTaskRequest(bean.taskId));
			}
			//关闭当前面板
			Facade.SendNotification(NotificationIDs.ID_CLOSE_MISSION_AWARD_PANEL);
		}
		
		
	}
	
}
