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
using nh.ui.main;
using UnityEngine;

namespace nh.ui.mediator
{
	/// <summary>
	/// Description of MainGamePanelMediator.
	/// </summary>
	public class MainGamePanelMediator : BaseMediator
	{
		public new const string NAME = "MainGamePanelMediator";
		private string preOpenNotificationId = NotificationIDs.ID_OpenOrCloseRolePanel;
		 /// <summary>
	    /// 我的构造方法
	    /// </summary>
	    public MainGamePanelMediator () : base(NAME)
	    {
	      handleTable.Add (NotificationIDs.ID_OPenMainGamePanel, OpenMainGamePanel);
	    }
	    /// <summary>
	    /// 我感兴趣的消息
	    /// </summary>
	    /// <returns></returns>
	    public override IList<string> ListNotificationInterests ()
	    {
	      if (interests.Count == 0) {
	
			interests.Add (NotificationIDs.ID_OPenMainGamePanel);
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
	    /// 打开游戏主界面面板
	    /// </summary>
	    private void OpenMainGamePanel(INotification notification)
	    {
			string subNotifi = notification.Body as String;
	   	Debug.Log("接收到打开游戏主面板");
      if (!isLoad)
				this.StartLoadResAndShow(typeof(MainGamePanel).Name);
			else
				this.Show(!m_Panel.m_IsShow);	

			if (!string.IsNullOrEmpty(subNotifi))
			{
				this.OpenOnePanel(subNotifi);
			}
		}
	    override protected void AddEvent()
	    {
	    	MainGamePanel mgp = m_Panel as MainGamePanel;
	    	if (mgp != null)
	    	{
	    		if (mgp.roleBut)
	    			UIEventListener.Get(mgp.roleBut).onClick+= OnRoleButClick;
	    		if (mgp.goodsBut)
	    			UIEventListener.Get(mgp.goodsBut).onClick+= OnGoodsButClick;
				if (mgp.skillBut)
					UIEventListener.Get(mgp.skillBut).onClick+= OnSkillButClick;
	    		if (mgp.exitBut)
	    			UIEventListener.Get(mgp.exitBut).onClick+= OnExitButClick;
	    	}
	    }
	    /// <summary>
	    /// 角色按钮点击事件处理
	    /// </summary>
	    /// <param name="obj"></param>
	    private void OnRoleButClick(GameObject obj)
		{	
//			SendNotification(NotificationIDs.ID_OpenOrCloseRolePanel);
			this.OpenOnePanel(NotificationIDs.ID_OpenOrCloseRolePanel);
		}
	    /// <summary>
	    /// 背包按钮点击事件处理
	    /// </summary>
	    /// <param name="obj"></param>
	    private void OnGoodsButClick(GameObject obj)
		{
//			IFacade facade = PureMVC.Patterns.Facade.Instance;
//			facade.SendNotification(NotificationIDs.ID_OpenOrCloseGoodsPanel);
			this.OpenOnePanel(NotificationIDs.ID_OpenOrCloseGoodsPanel);
		}
		private void OnSkillButClick(GameObject obj)
		{
			this.OpenOnePanel(NotificationIDs.ID_OpenOrCloseSkillPanel);
		}
		/// <summary>
		/// 打开一个面板，这个里面会记录成上次开启的面板，用于开启面板时关闭上一次打开的面板
		/// </summary>
		/// <param name='notificationId'>
		/// Notification identifier.
		/// </param>
		private void OpenOnePanel(string notificationId)
		{
			
			if (preOpenNotificationId != null)
			{
				if (preOpenNotificationId.Equals(notificationId))
					return;
				SendNotification(preOpenNotificationId);
			}
			
			SendNotification(notificationId);
			preOpenNotificationId = notificationId;
		}
		
	    /// <summary>
	    ///退出按钮点击处理
	    /// </summary>
	    /// <param name="obj"></param>
		private void OnExitButClick(GameObject obj)
		{
			IFacade facade = PureMVC.Patterns.Facade.Instance;
			facade.SendNotification(NotificationIDs.ID_OPenMainGamePanel);
		}
	    override protected void RemoveEvent()
	    {
	    	MainGamePanel mgp = m_Panel as MainGamePanel;
	    	if (mgp != null)
	    	{
	    		if (mgp.roleBut)
	    			UIEventListener.Get(mgp.roleBut).onClick-= OnRoleButClick;
	    		if (mgp.exitBut)
	    			UIEventListener.Get(mgp.exitBut).onClick-= OnExitButClick;
	    	}
	    }
		override protected void Show(bool bShow)
		{
			base.Show(bShow);
      if(bShow){
        SendNotification(NotificationIDs.ID_DisableSceneClick);
      }else{
        SendNotification(NotificationIDs.ID_EnableSceneClick);
      }
		}
	}
}
