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
using nh.ui.model.vo;

namespace nh.ui.mediator
{
	/// <summary>
	/// Description of MainGamePanelMediator.
	/// </summary>
	public class MessagePanelMediator : BaseMediator
	{
		public new const string NAME = "MessagePanelMediator";
		private MessageVo msg;
		 /// <summary>
	    /// 我的构造方法
	    /// </summary>
	    public MessagePanelMediator () : base(NAME)
	    {
	      handleTable.Add (NotificationIDs.ID_ShowPopupMessage, ShowPopupMessage);
	    }
	    /// <summary>
	    /// 我感兴趣的消息
	    /// </summary>
	    /// <returns></returns>
	    public override IList<string> ListNotificationInterests ()
	    {
	      if (interests.Count == 0) {
	
			interests.Add (NotificationIDs.ID_ShowPopupMessage);
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
	    private void ShowPopupMessage(INotification notification)
	    {
	    	msg = notification.Body as MessageVo;
	   		Debug.Log("接收到打开消息面板");
			if (!isLoad)
				this.StartLoadResAndShow(typeof(MessagePanel).Name);
			else
			{
				this.Show(true);
			}
	    
		}
	    
	    override protected void Show(bool bShow)
		{
	    	base.Show(bShow);
	    	if (msg != null)
	    	{
	    		MessagePanel mp = m_Panel as MessagePanel;
	    		mp.UpdateMessage(msg);
	    	}
	    	
		}
	    
	    
	    override protected void AddEvent()
	    {
			MessagePanel mp = m_Panel as MessagePanel;
	    	if (mp != null)
	    	{
				if (mp.okBut)
	    			UIEventListener.Get(mp.okBut).onClick+= OnOkButClickHandler;
				if (mp.cancelBut)
	    			UIEventListener.Get(mp.cancelBut).onClick+= OnCancelButClickHandler;
				if (mp.oneOkBut)
	    			UIEventListener.Get(mp.oneOkBut).onClick+= OnCancelButClickHandler;
				
			}
	    }
	    /// <summary>
	    /// 确认按钮点击处理
	    /// </summary>
	    /// <param name="obj"></param>
	    private void OnOkButClickHandler(GameObject obj)
		{
			if (msg != null && msg.callBackId != null)
				SendNotification(msg.callBackId);
			this.Show(false);
		}
	    /// <summary>
	    ///取消按钮按钮点击处理
	    /// </summary>
	    /// <param name="obj"></param>
		private void OnCancelButClickHandler(GameObject obj)
		{
			this.Show(false);
		}
	    override protected void RemoveEvent()
	    {
			MessagePanel mp = m_Panel as MessagePanel;
	    	if (mp != null)
	    	{
				if (mp.okBut)
	    			UIEventListener.Get(mp.okBut).onClick-= OnOkButClickHandler;
				if (mp.cancelBut)
	    			UIEventListener.Get(mp.cancelBut).onClick-= OnCancelButClickHandler;
				if (mp.oneOkBut)
	    			UIEventListener.Get(mp.oneOkBut).onClick-= OnCancelButClickHandler;
			}
	    }
	}
}
