/*
 * yc 2013/11/12
 */
using System;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TangGame;
using TangGame.Net;
using nh.ui.main;
using UnityEngine;
using nh.ui.basePanel;

namespace nh.ui.mediator
{
	public class RolePanelMediator : BaseMediator
	{
		public new const string NAME = "RolePanelMediator";

	    public RolePanelMediator () : base(NAME)
	    {
	      handleTable.Add (NotificationIDs.ID_OpenOrCloseRolePanel, OpenRolePanel);
	      handleTable.Add (NotificationIDs.ID_RequestMyHeroEqu, UpdateRolePanel);
	      handleTable.Add (NotificationIDs.ID_ReSetHeroPropertyNum, UpdateMyHeroPropertyNum);
	      handleTable.Add (NotificationIDs.ID_ReSetRoleHeroEquipInSite, UpdateEquItem);	
	    }

	    public override IList<string> ListNotificationInterests ()
	    {
	      if (interests.Count == 0) {
	
			interests.Add (NotificationIDs.ID_OpenOrCloseRolePanel);
			interests.Add(NotificationIDs.ID_RequestMyHeroEqu);
			interests.Add(NotificationIDs.ID_ReSetHeroPropertyNum);
			interests.Add(NotificationIDs.ID_ReSetRoleHeroEquipInSite);
		  }
	
	      return interests;
	    
		}

	    private void OpenRolePanel(INotification notification)
	    {
	   		Debug.Log("接收到打开角色面板");
			if (!isLoad)
				this.StartLoadResAndShow(typeof(RolePanel).Name,typeof(MainGamePanel).Name);
			else
				this.Show(!m_Panel.m_IsShow);	
	    
		}
	    private void UpdateRolePanel(INotification notification){
	    	AskForHeroEquResult push = notification.Body as AskForHeroEquResult;
//	    	Debug.Log(push.hp + ":" +push.hpMax + ":" +push.physicalAttack + ":" +push.physicalDefense + ":" +push.hitRate 
//	                  + ":" +push.dodge + ":" + push.criticalStrike + ":" +push.tenacity);
	    	RolePanel rp = m_Panel as RolePanel;
	    	rp.UpdateMyheroEquAndPropertyNum(push);
	    }
	    private void UpdateMyHeroPropertyNum(INotification notification){
	    	if(m_Panel == null) return;
	    	RolePanel rp = m_Panel as RolePanel;
	    	if(rp.m_IsShow)
	    		rp.UpdateMyHeroPropertyNum();
	    }
	    private void UpdateEquItem(INotification notification){
	    	EquipUpdatePush push = notification.Body as EquipUpdatePush;
	    	RolePanel rp = m_Panel as RolePanel;
	    	rp.UpdateEquItem(push.equipSite,push.goodsId);
	    }
		protected override void Show(bool bShow)
		{
			base.Show(bShow);
			if(bShow) {
//				Debug.Log("send info request");
				RolePanel rp = m_Panel as RolePanel;
				TangNet.TN.Send(new AskForHeroEquRequest());

			}
		}
		
	    override protected void AddEvent()
	    {
	    	RolePanel rp = m_Panel as RolePanel;
	    	if (rp != null)
	    	{
//	    		if (rp.equBut)
//	    			UIEventListener.Get(rp.equBut).onClick+= OnEquButClick;
//				if (rp.strengthBut)
//					UIEventListener.Get(rp.strengthBut).onClick+= OnIntensifyButClick;
//	    		if (rp.gemBut)
//	    			UIEventListener.Get(rp.gemBut).onClick+= OnGemButClick;
//	    		if (rp.rageBut)
//	    			UIEventListener.Get(rp.rageBut).onClick+= OnRageButClick;
//	    		if (rp.vipBut)
//	    			UIEventListener.Get(rp.vipBut).onClick+= OnVipButClick;
//	    		if (rp.titleBut)
//	    			UIEventListener.Get(rp.titleBut).onClick+= OnTitleButClick;
	    		if (rp.HItem1)
	    			UIEventListener.Get(rp.HItem1).onClick += OnItemClick;
	    		if (rp.HItem2)
	    			UIEventListener.Get(rp.HItem2).onClick += OnItemClick;
	    		if (rp.HItem3)
	    			UIEventListener.Get(rp.HItem3).onClick += OnItemClick;
	    		if (rp.HItem4)
	    			UIEventListener.Get(rp.HItem4).onClick += OnItemClick;
	    		if (rp.HItem5)
	    			UIEventListener.Get(rp.HItem5).onClick += OnItemClick;
	    		if (rp.HItem6)
	    			UIEventListener.Get(rp.HItem6).onClick += OnItemClick;
	    		if (rp.HItem7)
	    			UIEventListener.Get(rp.HItem7).onClick += OnItemClick;
	    		if (rp.HItem8)
	    			UIEventListener.Get(rp.HItem8).onClick += OnItemClick;
	    		if (rp.HItem9)
	    			UIEventListener.Get(rp.HItem9).onClick += OnItemClick;
	    		if (rp.HItem10)
	    			UIEventListener.Get(rp.HItem10).onClick += OnItemClick;
	    		if (rp.HItem11)
	    			UIEventListener.Get(rp.HItem11).onClick += OnItemClick;
	    		if (rp.HItem12)
	    			UIEventListener.Get(rp.HItem12).onClick += OnItemClick;
	    		if (rp.HItem13)
	    			UIEventListener.Get(rp.HItem13).onClick += OnItemClick;
	    		if (rp.HItem14)
	    			UIEventListener.Get(rp.HItem14).onClick += OnItemClick;
	    	}
	    }
		//升级按钮点击
	    private void OnEquButClick(GameObject obj)
		{
//	    	Debug.Log("equ click");
//	    	RolePanel rp = m_Panel as RolePanel;
//	    	if(rp.prePanel.Equals(NotificationIDs.ID_OpenOrCloseRole1st)) return;
//	    	SendNotification(NotificationIDs.ID_OpenOrCloseRole1st);
		}
		private void OnIntensifyButClick(GameObject obj)
		{
	    	Debug.Log("intensifyBut click");
		}
		private void OnGemButClick(GameObject obj)
		{
	    	Debug.Log("gemBut click");
		}
		private void OnRageButClick(GameObject obj)
		{
	    	Debug.Log("rageBut click");
		}
		private void OnVipButClick(GameObject obj)
		{
	    	Debug.Log("vipBut click");
		}
		private void OnTitleButClick(GameObject obj)
		{
	    	Debug.Log("titleBut click");
		}
		
		//装备点击事件
		private void OnItemClick(GameObject obj){
			RolePanel rp = m_Panel as RolePanel;
			if(rp.SelectedObj) rp.SelectedObj.GetComponent<HItem>().SetSelected(false);
			rp.SelectedObj = obj;
			obj.GetComponent<HItem>().SetSelected(true);
			long itemId = obj.GetComponent<HItem>().ItemId;
			if(itemId > 0){
				Debug.Log(itemId);
				SendNotification(NotificationIDs.ID_ToMakeItemUpLevel,itemId);
			}
		}
	    override protected void RemoveEvent()
	    {
	    	RolePanel rp = m_Panel as RolePanel;
	    	if (rp != null)
	    	{
//	    		if (rp.equBut)
//	    			UIEventListener.Get(rp.equBut).onClick-= OnEquButClick;
//				if (rp.strengthBut)
//					UIEventListener.Get(rp.strengthBut).onClick-= OnIntensifyButClick;
//	    		if (rp.gemBut)
//	    			UIEventListener.Get(rp.gemBut).onClick-= OnGemButClick;
//	    		if (rp.rageBut)
//	    			UIEventListener.Get(rp.rageBut).onClick-= OnRageButClick;
//	    		if (rp.vipBut)
//	    			UIEventListener.Get(rp.vipBut).onClick-= OnVipButClick;
//	    		if (rp.titleBut)
//	    			UIEventListener.Get(rp.titleBut).onClick-= OnTitleButClick;
	    		if (rp.HItem1)
	    			UIEventListener.Get(rp.HItem1).onClick -= OnItemClick;
	    		if (rp.HItem2)
	    			UIEventListener.Get(rp.HItem2).onClick -= OnItemClick;
	    		if (rp.HItem3)
	    			UIEventListener.Get(rp.HItem3).onClick -= OnItemClick;
	    		if (rp.HItem4)
	    			UIEventListener.Get(rp.HItem4).onClick -= OnItemClick;
	    		if (rp.HItem5)
	    			UIEventListener.Get(rp.HItem5).onClick -= OnItemClick;
	    		if (rp.HItem6)
	    			UIEventListener.Get(rp.HItem6).onClick -= OnItemClick;
	    		if (rp.HItem7)
	    			UIEventListener.Get(rp.HItem7).onClick -= OnItemClick;
	    		if (rp.HItem8)
	    			UIEventListener.Get(rp.HItem8).onClick -= OnItemClick;
	    		if (rp.HItem9)
	    			UIEventListener.Get(rp.HItem9).onClick -= OnItemClick;
	    		if (rp.HItem10)
	    			UIEventListener.Get(rp.HItem10).onClick -= OnItemClick;
	    		if (rp.HItem11)
	    			UIEventListener.Get(rp.HItem11).onClick -= OnItemClick;
	    		if (rp.HItem12)
	    			UIEventListener.Get(rp.HItem12).onClick -= OnItemClick;
	    		if (rp.HItem13)
	    			UIEventListener.Get(rp.HItem13).onClick -= OnItemClick;
	    		if (rp.HItem14)
	    			UIEventListener.Get(rp.HItem14).onClick -= OnItemClick;
	    	}
//	    	Debug.Log("Remove Event");
	    }
	}
}
