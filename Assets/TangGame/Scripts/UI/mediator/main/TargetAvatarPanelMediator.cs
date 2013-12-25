//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18408
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TangGame;
using nh.ui.main;
using UnityEngine;
using TangGame.Net;

namespace nh.ui.mediator
{
		public class TargetAvatarPanelMediator : Mediator
		{
				public new const string NAME = "TargetAvatarPanelMediator";
				protected delegate void Handle (INotification notification);

				protected Dictionary<string, Handle> handleTable = new Dictionary<string, Handle> ();
				protected List<string> interests = new List<string> ();
				private TargetAvatarPanel m_Panel = null;

				public TargetAvatarPanelMediator () : base(NAME)
				{
						handleTable.Add (NotificationIDs.ID_ShowOrHideTargetHeadPanel, ShowOrHideTargetHeadPanel);
						handleTable.Add (NotificationIDs.ID_UpdateTargetHeadPanel, UpdateTargetHeadPanel);
				}

				public override IList<string> ListNotificationInterests ()
				{
						if (interests.Count == 0) {
							interests.Add (TangGame.NotificationIDs.ID_ShowOrHideTargetHeadPanel);
							interests.Add (TangGame.NotificationIDs.ID_UpdateTargetHeadPanel);
						}				
						return interests;
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

				private TargetAvatarPanel getPanel ()
				{
						GameObject root = GlobalFunction.GetRootPanel ();
						if (root) {
								TargetAvatarPanel[] tps = root.GetComponentsInChildren<TargetAvatarPanel> (true);
								int len = tps.Length;
								if (len > 0)
										return tps [0];
						}
						return null;
				}
				/// <summary>
				/// 显示或隐藏目标面板
				/// </summary>
				/// <param name="notification">Notification.</param>
				private void ShowOrHideTargetHeadPanel (INotification notification)
				{
						if (m_Panel == null)
								m_Panel = this.getPanel ();
						if (m_Panel == null)
							return;
						HeadInfo info = notification.Body as HeadInfo;
						if (info != null) {
								if (NGUITools.GetActive (m_Panel.gameObject) != true)
										m_Panel.gameObject.SetActive (true);
						
								m_Panel.UpdateShow (info);

						} else
								m_Panel.gameObject.SetActive (false);

				}
				/// <summary>
				/// 如果服务器发过来的和当前显示是同一个人，更新显示
				/// </summary>
				/// <param name="notification">Notification.</param>
				private void UpdateTargetHeadPanel (INotification notification)
				{
						if (m_Panel == null)
								return;
						if (NGUITools.GetActive(m_Panel.gameObject))
						{
							HeadInfo info = notification.Body as HeadInfo;
							if (m_Panel.ObjId == info.objId)
							{
								m_Panel.UpdateShow (info);
							}

						}

				}
		}
}
