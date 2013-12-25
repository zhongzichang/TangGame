/*
 * Created by SharpDevelop.
 * User: shimudennis
 * Date: 2013/11/4
 * Time: 18:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;
using nh.ui.basePanel;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TangGame;

namespace nh.ui.main
{
	/// <summary>
	/// 游戏主面板
	/// </summary>
	public class MainGamePanel : PopupPanel
	{
		public GameObject roleBut;
		public GameObject goodsBut;
		public GameObject skillBut;
		public GameObject exitBut;
		public MainGamePanel()
		{
		}
		void Start(){
			PureMVC.Patterns.Facade.Instance.SendNotification(NotificationIDs.ID_OpenOrCloseRolePanel);
		}
	}
}
