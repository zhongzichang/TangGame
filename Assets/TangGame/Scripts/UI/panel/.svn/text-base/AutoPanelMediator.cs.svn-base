/*
 * Created by SharpDevelop.
 * User: xbhuang
 * Date: 2013/11/11
 * Time: 14:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;
using nh.ui.basePanel;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections.Generic;
using TangGame;
using nh.ui;

namespace nh.ui.mediator
{
  /// <summary>
  /// 游戏对话面板
  /// </summary>
  public class AutoPanelMediator : BaseMediator
  {
    public new const string NAME = "AutoPanelMediator";
    AutoPanel atp;
    /// <summary>
    /// 我的构造方法
    /// </summary>
    public AutoPanelMediator () : base(NAME)
    {
      handleTable.Add(NotificationIDs.ID_UPDATE_AUTO_PANEL,UpdateAutoPanelSprite);
      handleTable.Add(NtftNames.AUTO_NAV_STARTED,UpdateAutoPanelSprite);
      handleTable.Add(NtftNames.AUTO_NAV_TERMINATED,UpdateAutoPanelSprite);
      handleTable.Add(NtftNames.TG_HOOK,UpdateAutoPanelSprite);
      handleTable.Add(NtftNames.TG_UNHOOK,UpdateAutoPanelSprite);
    }

    /// <summary>
    /// 我感兴趣的消息
    /// </summary>
    /// <returns></returns>
    public override IList<string> ListNotificationInterests ()
    {
      if (interests.Count == 0) {
        interests.Add(NotificationIDs.ID_UPDATE_AUTO_PANEL);
        interests.Add(NtftNames.AUTO_NAV_STARTED);
        interests.Add(NtftNames.AUTO_NAV_TERMINATED);
        interests.Add(NtftNames.TG_HOOK);
        interests.Add(NtftNames.TG_UNHOOK);
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
    /// <summary>
    /// 更改提示图标
    /// </summary>
    /// <param name="notification">Notification.</param>
    private void UpdateAutoPanelSprite(INotification notification){
      if(notification == null){
        return;
      }
      if (!isLoad)
        this.StartLoadResAndShow(typeof(AutoPanel).Name);
      else
        this.Show(true);
      atp = m_Panel as AutoPanel;
      string spriteName = "";
      switch(notification.Name){
      case NtftNames.AUTO_NAV_STARTED:
        spriteName = "AutoWalk";
        break;
      case NtftNames.AUTO_NAV_TERMINATED:
          break;
      case NtftNames.TG_HOOK:
        spriteName = "AutoAttack";
        break;
      case NtftNames.TG_UNHOOK:
        break;
      case NotificationIDs.ID_UPDATE_AUTO_PANEL:
        spriteName = notification.Body.ToString();
        break;
      }
      atp.UpdateAutoSprite(spriteName);
    }

  }
}
