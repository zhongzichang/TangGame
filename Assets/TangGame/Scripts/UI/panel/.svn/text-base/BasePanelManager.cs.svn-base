using System;
using UnityEngine;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections.Generic;
using nh.ui.basePanel;
using TangScene;
using nh.ui.mediator;
using System.Reflection;
namespace nh.ui.panel
{
	/// <summary>
	/// 弹出面板管理类，用于根据弹出面板prefabs的路径来创建面板和进行面板的销毁
	/// create by huxiaobo
	/// 2013.11.1
	/// </summary>
	public class BasePanelManager
	{
		private static BasePanelManager m_Instance = null;
		public static Dictionary<string, BasePanel> m_PanelDic;//所有弹出面板的管理字典//
		public static BasePanelManager Instance {
			get { 
				if (m_Instance == null)
				{
					m_Instance = new BasePanelManager();//GetComponent<BasePanelManager>();
					m_PanelDic = new Dictionary<string, BasePanel>();	
				}
				return m_Instance;			
			}
		}
		/// <summary>
		/// 根据面板名字获取panel
		/// </summary>
		/// <returns>
		/// The panel.
		/// </returns>
		/// <param name='name'>
		/// Name.
		/// </param>
		public BasePanel GetPanel(string name, UnityEngine.Object assets)
		{
			BasePanel bp = null;
			if (!m_PanelDic.ContainsKey(name))
			{	
				if (assets == null)
					return null;
//				GameObject obj = NGUITools.AddChild(this.gameObject, assets as GameObject );
 				GameObject obj = GameObject.Instantiate(assets) as GameObject;
				bp = DynamicBindUtil.BindScriptAndProperty(obj, name) as BasePanel;
//				//动态绑定脚本文件
//				bp = obj.AddComponent(name) as BasePanel;
//				//动态进行组件和脚本变量的绑定
//				FieldInfo[] infos = bp.GetType().GetFields();				
//				foreach(FieldInfo ff in infos)
//				{
////					//如果变量类型是GameObject，则查找对应的组件进行绑定
////					if (ff.FieldType == typeof(GameObject))
////					{
//						Transform[] tfs = obj.GetComponentsInChildren<Transform>(true);
//						bool isFind = false;
//						foreach (Transform tf in tfs)
//						{
//							if (ff.Name.Equals(tf.name))
//							{
//								isFind = true;
//								ff.SetValue(bp, tf.gameObject);
//								break;
//							}
//						}
//						if (isFind == false)
//							Debug.LogWarning("没有找到名字为" + ff.Name + "组件");						
////					}
//				}				
				m_PanelDic.Add(name, bp);
			}
			else
			{
				bp = m_PanelDic[name];
			}
			return bp;
		}
		/// <summary>
		/// 销毁弹出面板
		/// </summary>
		/// <returns>
		/// The panel.
		/// </returns>
		/// <param name='name'>
		/// If set to <c>true</c> name.
		/// </param>
		public bool DestoryPanel(string name)
		{
			if (m_PanelDic.ContainsKey(name))
			{
				BasePanel panel = m_PanelDic[name];
				if (panel != null)
				{
					m_PanelDic.Remove(name);
					GameObject.Destroy(panel.gameObject);
				}
				return true;
			}
			return false;
		}
			
	}
}

