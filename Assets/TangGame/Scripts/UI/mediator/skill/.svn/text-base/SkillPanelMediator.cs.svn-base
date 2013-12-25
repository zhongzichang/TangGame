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
	/// 技能主面板相关mediator
	/// create by huxiaobo
	/// 2013.12.3
	/// </summary>
	public class SkillPanelMediator : BaseMediator
	{
		public new const string NAME = "SkillPanelMediator";
		public SkillPanelMediator () : base(NAME)
		{
			handleTable.Add(NotificationIDs.ID_OpenOrCloseSkillPanel, OpenOrCloseSkillPanel);
		}
		public override IList<string> ListNotificationInterests ()
		{
			if (interests.Count == 0) {
				interests.Add (NotificationIDs.ID_OpenOrCloseSkillPanel);
			}

			return interests;
		}
		private void OpenOrCloseSkillPanel(INotification notification)
		{
//			Debug.Log("接收到打开技能面板");
			if (!isLoad)
				this.StartLoadResAndShow(typeof(SkillPanel).Name, typeof(MainGamePanel).Name);
			else
				this.Show(!m_Panel.m_IsShow);			
		}
// 		override protected void AddEvent()
//	  {
//			SkillPanel sp = m_Panel as SkillPanel;
//    	if (sp != null)
//    	{
//				if (sp.skillBut)
//	    			UIEventListener.Get(sp.skillBut).onClick += OnSkillButClick;
//				if (sp.cittaBut)
//	    			UIEventListener.Get(sp.cittaBut).onClick += OnCittaClick;
//				if (sp.meridianBut)
//	    			UIEventListener.Get(sp.meridianBut).onClick += OnMeridianButClick;
//    	}
// 		}
//		override protected void RemoveEvent()
//	  {
//	    	SkillPanel sp = m_Panel as SkillPanel;
//    	if (sp != null)
//    	{
//				if (sp.skillBut)
//	    			UIEventListener.Get(sp.skillBut).onClick -= OnSkillButClick;
//				if (sp.cittaBut)
//	    			UIEventListener.Get(sp.cittaBut).onClick -= OnCittaClick;
//				if (sp.meridianBut)
//	    			UIEventListener.Get(sp.meridianBut).onClick -= OnMeridianButClick;
//				if (sp.greatBut)
//	    			UIEventListener.Get(sp.greatBut).onClick -= OnGreatButClick;
//    	}
//	  }
//		//技能按钮
//		private void OnSkillButClick(GameObject obj)
//		{
////			SendNotification(NotificationIDs.ID_OpenOrCloseGoodsPanel);
//		}
//		//心法按钮
//		private void OnCittaClick(GameObject obj)
//		{
//			
//		}
//		//经脉按钮
//		private void OnMeridianButClick(GameObject obj)
//		{
//			
//		}
//		//绝学按钮
//		private void OnGreatButClick(GameObject obj)
//		{
//			
//		}
//	
	}
}

