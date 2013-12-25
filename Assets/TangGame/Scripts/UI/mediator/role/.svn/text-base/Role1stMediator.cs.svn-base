/*
 * yc 2013/11/19
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

namespace nh.ui.mediator
{
	public class Role1stMediator : BaseMediator
	{
		public new const string NAME = "Role1stMediator";

	    public Role1stMediator () : base(NAME)
	    {
	      handleTable.Add (NotificationIDs.ID_OpenOrCloseRole1st, OpenRole1st);
		  handleTable.Add (NotificationIDs.ID_ToMakeItemUpLevel, MakeItemUpLevelOrNot);
	    }

	    public override IList<string> ListNotificationInterests ()
	    {
	      if (interests.Count == 0) {
	
//			interests.Add (NotificationIDs.ID_OpenOrCloseRole1st);
//			interests.Add (NotificationIDs.ID_ToMakeItemUpLevel);
		  }
	
	      return interests;
	    
		}

	    private void OpenRole1st(INotification notification)
	    {
	   		Debug.Log("接收到打开装备升级面板");
			if (!isLoad)
				this.StartLoadResAndShow(typeof(Role1st).Name,typeof(RolePanel).Name);
			else
				this.Show(!m_Panel.m_IsShow);	
	    
		}
	    
	    private void MakeItemUpLevelOrNot(INotification notification){
	    	int itemId = (int)((long)notification.Body);
//	    	Debug.Log(itemId + "~~~~~~~");
	    	Role1st rp = m_Panel as Role1st;
	    	rp.SetTopAndNextItem1(itemId);
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
	    
		protected override void Show(bool bShow)
		{
			base.Show(bShow);

		}
		
	    override protected void AddEvent()
	    {
	    	Role1st rp = m_Panel as Role1st;
	    	if (rp != null)
	    	{
	    		if (rp.confirmBut)
	    			UIEventListener.Get(rp.confirmBut).onClick+= OnEquUpLevelButClick;
	    	}
	    }

	    private void OnEquUpLevelButClick(GameObject obj)
		{
//	    	Debug.Log("equ level up~~~~~~~");
	    	Role1st rp = m_Panel as Role1st;
	    	if(rp.ItemToUpLevel > 0){
	    		TangNet.TN.Send(new EquipUpgradeRequest(rp.ItemToUpLevel,0));
	    		rp.but.isEnabled = false;
	    	}
		}

	    override protected void RemoveEvent()
	    {
	    	Role1st rp = m_Panel as Role1st;
	    	if (rp != null)
	    	{
	    		if (rp.confirmBut)
	    			UIEventListener.Get(rp.confirmBut).onClick+= OnEquUpLevelButClick;

	    	}
	    }
	}
}
