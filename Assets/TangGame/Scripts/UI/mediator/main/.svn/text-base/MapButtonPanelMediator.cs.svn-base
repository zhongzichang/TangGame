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
using nh.ui.utils;
namespace nh.ui.mediator
{
	/// <summary>
	/// 地图按钮处理mediator
	/// create by huxiaobo
	/// </summary>
	public class MapButtonPanelMediator : Mediator
	{
		public new const string NAME = "MapButtonPanelMediator";
		protected delegate void Handle(INotification notification);
		protected Dictionary<string, Handle> handleTable = new Dictionary<string, Handle> ();
		protected List<string> interests = new List<string> ();
		private MapButtonPanel m_Panel;
		/// <summary>
		/// ??????
		/// </summary>
		public MapButtonPanelMediator (MapButtonPanel panel) : base(NAME)
		{
			m_Panel = panel;
			handleTable.Add(TangScene.NtftNames.SCENE_LOAD_COMPLETED, LoadSceneComplete);
		}
		/// <summary>
		/// ???????
		/// </summary>
		/// <returns></returns>
		public override IList<string> ListNotificationInterests ()
		{
			if (interests.Count == 0) {
				interests.Add(TangScene.NtftNames.SCENE_LOAD_COMPLETED);
			}
			
			return interests;
		}
		/// <summary>
		/// ????
		/// </summary>
		/// <param name="notification"></param>
		public override void HandleNotification (INotification notification)
		{
			if (handleTable.ContainsKey (notification.Name)) {
				handleTable [notification.Name] (notification);
			}
		}
		/// <summary>
		/// Loads the scene complete.
		/// </summary>
		/// <param name="notification">Notification.</param>
		private void LoadSceneComplete(INotification notification)
		{
			HeroNew hero = ActorCache.GetLeadingHero();
			string mapName = "";
			if (hero != null)
				mapName = hero.mapName;
			Debug.LogWarning("当前地图" + mapName);
			m_Panel.UpdateShow(mapName);
		}
	}
}

