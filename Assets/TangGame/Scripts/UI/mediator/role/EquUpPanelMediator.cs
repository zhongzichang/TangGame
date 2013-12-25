/*
 * yc 2013/12/3
 */
using System;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TangGame;
using TangGame.Net;
using nh.ui.main;
using UnityEngine;
using TangGame.Xml;
using nh.ui.cache;
using nh.ui.panel;

namespace nh.ui.mediator
{
	public class EquUpPanelMediator : Mediator
	{
		public new const string NAME = "EquUpPanelMediator";
		
		protected delegate void Handle (INotification notification);
		protected Dictionary<string, Handle> handleTable = new Dictionary<string, Handle> ();
		protected List<string> interests = new List<string> ();
		private EquUpPanel m_Panel;
		
	    public EquUpPanelMediator (EquUpPanel m_Panel) : base(NAME)
	    {
	    	this.m_Panel = m_Panel;
//	      handleTable.Add (NotificationIDs.ID_OpenOrCloseRole1st, OpenRole1st);
		  handleTable.Add (NotificationIDs.ID_ToMakeItemUpLevel, MakeItemUpLevelOrNot);
	    }

	    public override IList<string> ListNotificationInterests ()
	    {
	      if (interests.Count == 0) {
	
//			interests.Add (NotificationIDs.ID_OpenOrCloseRole1st);
			interests.Add (NotificationIDs.ID_ToMakeItemUpLevel);
		  }
	
	      return interests;
	    
		}
		public override void HandleNotification (INotification notification)
		{
			if (handleTable.ContainsKey (notification.Name)) {
				handleTable [notification.Name] (notification);
			}
		}
	    private void OpenRole1st(INotification notification)
	    {
	   		Debug.Log("接收到打开装备升级面板");
//			if (!isLoad)
//				this.StartLoadResAndShow(typeof(Role1st).Name,typeof(RolePanel).Name);
//			else
//				this.Show(!m_Panel.m_IsShow);	
	    
		}
	    
	    private void MakeItemUpLevelOrNot(INotification notification){
	    	int itemId = (int)((long)(notification.Body));
//	    	Debug.Log(itemId + "~~~~~~~");
	    	m_Panel.SetTopAndNextItem(itemId);
//	    	if(CanUpLevel(Config.equip_upgrade[itemId])){
//	    		rp.SetCanUpLevel(itemId);
//	    	}else{
//	    	
//	    	}
		}
	    //判断可否进行装备升级
	    private bool CanUpLevel(Equip_upgrade equ_up){
	    	//装备小于角色等级
	    	if(Config.itemTable[equ_up.Next_id].NeedLv > UIActorCache.myHero.level)
	    		return false;
	    	//角色身上材料不够
	    	
	    	return true;
	    }


	}
}
