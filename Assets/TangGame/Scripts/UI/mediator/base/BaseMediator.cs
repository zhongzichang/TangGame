using System;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using nh.ui.basePanel;
using System.Collections.Generic;
using UnityEngine;
using TS = TangScene;
using TangGame;
using nh.ui.panel;

namespace nh.ui.mediator
{
	/// <summary>
	/// 所有弹出面板相关基类，用于处理面板资源加载已经显示的相关逻辑
	/// create by huxiaobo
	/// 2013.11.1
	/// </summary>
	public class BaseMediator : Mediator
	{
//		public new const string NAME = "BaseMediator";
		protected BasePanel m_Panel;
		protected string m_PanelName;
		protected delegate void Handle(INotification notification);
		protected Dictionary<string, Handle> handleTable = new Dictionary<string, Handle> ();
		protected List<string> interests = new List<string> ();
		protected bool isLoad = false;//当前面板资源是否被加载过
		protected bool isFirstShow = true;
		protected string m_ParentName = null;
		public BaseMediator (string name) : base(name)
	    {
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
		/// 开始加载面板所需的资源文件
		/// </summary>
		/// <param name='panelName'>
		/// Panel name.
		/// </param>
		protected void StartLoadResAndShow(string panelName)
		{
      m_PanelName = panelName;
			m_ParentName = null;
			if (Config.debug)
					LoadResComplete(null);
				else
					TS.TS.LoadAssetBundle(GameConsts.PREFABS_PATH + m_PanelName, LoadResComplete);			
		}
		/// <summary>
		/// 开始加载面板所需的资源文件
		/// </summary>
		/// <param name='panelName'>
		/// <param name='parentName'>父容器名字
		/// Panel name.
		/// </param>
		protected void StartLoadResAndShow(string panelName, string parentName)
		{
      m_PanelName = panelName;
			m_ParentName = parentName;
			if (Config.debug)
					LoadResComplete(null);
				else
					TS.TS.LoadAssetBundle(GameConsts.PREFABS_PATH + m_PanelName, LoadResComplete);			
		}
		/// <summary>
		/// 加载资源完成，根据资源来生成面板对象
		/// </summary>
		/// <param name='www'>
		/// Www.
		/// </param>
		virtual protected void LoadResComplete(WWW www)
		{	
			UnityEngine.Object assets = null;
			if (www == null)//如果www为空，表明当前加载的程序内部prefabs资源文件
				assets = Resources.Load(GameConsts.PREFABS_PATH + m_PanelName);
			else
				assets = www.assetBundle.Load(m_PanelName);			
			m_Panel = BasePanelManager.Instance.GetPanel(m_PanelName, assets);
			isLoad = true;	
			this.Show(true);		
		}
		/// <summary>
		/// 显示或隐藏面板
		/// </summary>
		/// <param name='bShow'>
		/// B show.
		/// </param>
		virtual protected void Show(bool bShow)
		{
			if (m_Panel == null || !isLoad)
				return;
			if (bShow)
			{
				if (isFirstShow == true)//如果是第一次加载显示，需要设置父容器
				{
					GameObject parent = null;
					if (m_ParentName != null)
					{
						BasePanel pbp = BasePanelManager.Instance.GetPanel(m_ParentName, null);
						parent = pbp.gameObject;
						if (parent == null)
							Debug.LogError("将要添加进的"+ m_ParentName +"父容器为空" );
					}
					else//如果没有传父容器名字，直接用根目录容器
					{	
						parent = GlobalFunction.GetRootPanel();
					}
					m_Panel.ShowPanel(parent);
				}
				else
					m_Panel.ShowPanel();
				isFirstShow = false;
				this.AddEvent();
			}
			else
			{
				m_Panel.HidePanel();
				this.RemoveEvent();
			}
		}

//		protected GameObject GetRootPanel(){
//			//						parent = RootPanel.Instance.gameObject;
//			return	GameObject.FindObjectOfType<UICamera>().GetComponentInChildren<UIPanel>().gameObject;
//		}
		/// <summary>
		/// 添加事件监听
		/// </summary>
		virtual protected void AddEvent()
		{
		
		}
		/// <summary>
		/// 移除事件监听
		/// </summary>
		virtual protected void RemoveEvent()
		{
		
		}
	}
}

