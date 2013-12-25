
using System;
using UnityEngine;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using nh.ui.panel;
using TangGame;
using TangGame.Net;
using nh.ui.basePanel;
using nh.ui.model.vo;
using TangGame.Xml;

namespace nh.ui.mediator
{
	public class GoodsPackagePanelMediator : Mediator
	{
		public new const string NAME = "GoodsPackagePanelMediator";
		protected delegate void Handle (INotification notification);
		
		protected Dictionary<string, Handle> handleTable = new Dictionary<string, Handle> ();
		protected List<string> interests = new List<string> ();
		private GoodsPackagePanel m_Panel;
		public GoodsPackagePanelMediator (GoodsPackagePanel panel) : base(NAME)
		{
			m_Panel = panel;
			handleTable.Add (NotificationIDs.ID_SynBagGoodsInfo, SynBagGoodsInfo);			
			handleTable.Add (NotificationIDs.ID_DeletePackGoods, DeleteItemInPack);
			handleTable.Add (NotificationIDs.ID_ReflushPackGoods, ReflushPackGoods);
			handleTable.Add (NotificationIDs.ID_DiscardItemConfirm, OnDiscardItemConfirm);
			handleTable.Add (NotificationIDs.ID_UpdateBagArrangeCoolDown, UpdateBagArrangeCoolDown);
		}
		
		public override IList<string> ListNotificationInterests ()
		{
			if (interests.Count == 0) {
				interests.Add (NotificationIDs.ID_SynBagGoodsInfo);
				interests.Add (NotificationIDs.ID_DeletePackGoods);
				interests.Add (NotificationIDs.ID_ReflushPackGoods);
				interests.Add (NotificationIDs.ID_DiscardItemConfirm);
				interests.Add (NotificationIDs.ID_UpdateBagArrangeCoolDown);
			}
			
			return interests;
		}
		
		public override void HandleNotification (INotification notification)
		{
			if (handleTable.ContainsKey (notification.Name)) {
				handleTable [notification.Name] (notification);
			}
		}

		private void SynBagGoodsInfo (INotification notification)
		{
			if (m_Panel == null)
				return;
			GoodsInfo info = notification.Body as GoodsInfo;
			this.UpdateOneItem (info);
		}
		
		private void UpdateOneItem (GoodsInfo  info)
		{
			if (info != null) {
//				GoodsPanel gp = m_Panel as GoodsPanel;
				m_Panel.UpdateItemInfo (info);
			}
			
		}
		private void DeleteItemInPack (INotification notification)
		{
			if (m_Panel == null)
				return;
			int pos = (int)notification.Body;
			if (pos >= 0) {
//				GoodsPanel gp = m_Panel as GoodsPanel;
				m_Panel.DeleteItemByPos (pos);
			}
		}

		private void ReflushPackGoods (INotification notification)
		{
			if (m_Panel == null)
				return;
//			GoodsPanel gp = m_Panel as GoodsPanel;
		
			m_Panel.ClearPanel ();

			List<GoodsInfo> list = notification.Body as List<GoodsInfo>;
			foreach (GoodsInfo info in list) {
				m_Panel.UpdateItemInfo (info);
			}		
		}
		/// <summary>
		/// Updates the bag arrange cool down.
		/// </summary>
		/// <param name="notification">Notification.</param>
		private void UpdateBagArrangeCoolDown (INotification notification)
		{
			if (m_Panel == null)
				return;
			
			HeroNew hero = ActorCache.GetLeadingHero ();
			double now = GlobalFunction.GetCurrentTime ();
			if (hero != null && hero.arrangeCooldown > now) {
//				GoodsPanel gp = m_Panel as GoodsPanel;
				
				m_Panel.UpdateArrangeCooldown (hero.arrangeCooldown);
			}
		}
		private void OnDiscardItemConfirm (INotification notifacation)
		{
			if (m_Panel == null)
				return;
			if (m_Panel.PreClickItemPos >= 0) {
				TangNet.TN.Send (new DiscardItemRequest (m_Panel.PreClickItemPos));
			}
		}
	}
}

