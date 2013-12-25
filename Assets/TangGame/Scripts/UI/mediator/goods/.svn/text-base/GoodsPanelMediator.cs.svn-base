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
	/// 背包面板处理相关midiator
	/// create by huxiaobo
	/// </summary>
	public class GoodsPanelMediator : BaseMediator
	{
		public new const string NAME = "GoodsPanelMediator";
		private bool isFirstLoadScene = true;
		/// <summary>
		/// 我的构造方法
		/// </summary>
		public GoodsPanelMediator () : base(NAME)
		{
			handleTable.Add(NotificationIDs.ID_OpenOrCloseGoodsPanel, OpenOrCloseGoodsPanel);
			handleTable.Add(TangScene.NtftNames.SCENE_LOAD_COMPLETED, SceneLoadComplete);
		}
		/// <summary>
		/// 我感兴趣的消息
		/// </summary>
		/// <returns></returns>
		public override IList<string> ListNotificationInterests ()
		{
			if (interests.Count == 0) {
				interests.Add (NotificationIDs.ID_OpenOrCloseGoodsPanel);
				interests.Add (TangScene.NtftNames.SCENE_LOAD_COMPLETED);
			}

			return interests;
		}
		//场景加载完成
		private void SceneLoadComplete(INotification notification)
		{
			if (isFirstLoadScene)//第一次进入场景需要请求面板信息
			{
				TangNet.TN.Send(new SynPackInfoRequest());
				isFirstLoadScene = false;
			}
		}
		/// <summary>
		/// 打开背包面板
		/// </summary>
		/// <param name="notification"></param>
		private void OpenOrCloseGoodsPanel(INotification notification)
		{
			Debug.Log("接收到打开背包面板");
			if (!isLoad)
				this.StartLoadResAndShow(typeof(GoodsPanel).Name, typeof(MainGamePanel).Name);
			else
				this.Show(!m_Panel.m_IsShow);			
		}
	}
}

