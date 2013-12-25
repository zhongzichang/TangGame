/**
 * Loading Panel Mediator
 *
 * Author: zzc
 * Date: 2013/11/29
 *
 */
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

namespace TangGame.View
{
  public class WelcomePanelMediator : Mediator
  {
    private delegate void Handle (INotification notification);

    public new const string NAME = "WELCOME_PANEL_MEDIATOR";

    /// <summary>
    ///   正在加载的面板
    /// </summary>
    private GameObject topUIObject;
    private WelcomePanelBhvr welcomePanel;

    private Dictionary<string, Handle> handleTable = new Dictionary<string, Handle> ();
    private List<string> interests = new List<string> ();

    /// <summary>
    ///   构造方法
    /// </summary>
    public WelcomePanelMediator (GameObject gameObject) : base( NAME )
    {
      welcomePanel = gameObject.GetComponent<WelcomePanelBhvr>();
      this.topUIObject = NGUITools.GetRoot(gameObject);

      handleTable.Add (NtftNames.TG_LOADING_START, HandleLoadingStart);
      handleTable.Add (NtftNames.TG_LOADING_PROGRESS, HandleLoadingProgress);
      handleTable.Add (NtftNames.TG_LOADING_MESSAGE, HandleLoadingMessage);
      handleTable.Add (NtftNames.TG_LOADING_END, HandleLoadingEnd);
      
      handleTable.Add (NtftNames.TG_SHOW_ERROR_MESSAGE, HandleErrorMessage);

    }

    /// <summary>
    ///   感兴趣的消息
    /// </summary>
    public override IList<string> ListNotificationInterests ()
    {
      List<string> interests = new List<string> ();
      foreach(string key in handleTable.Keys){
        interests.Add(key);
      }
      return interests;
    }

    /// <summary>
    ///   处理通知
    /// </summary>
    public override void HandleNotification (INotification notification)
    {
      if (handleTable.ContainsKey (notification.Name)) {
        handleTable [notification.Name] (notification);
      }
    }

    private void HandleErrorMessage (INotification notification)
    {
      ShowTopUIRoot();
      welcomePanel.UpdateErrorMessage((string)notification.Body);
    }

    /// <summary>
    ///   加载开始
    /// </summary>
    private void HandleLoadingStart (INotification notification)
    {
      ShowTopUIRoot();
      welcomePanel.ShowLoadingPanel();
      welcomePanel.UpdateProgress(0f);
    }

    /// <summary>
    ///   加载进度更新
    /// </summary>
    private void HandleLoadingProgress (INotification notification)
    {
      ShowTopUIRoot();
      welcomePanel.UpdateProgress((float)notification.Body);
    }

    /// <summary>
    ///   加载消息更新
    /// </summary>
    private void HandleLoadingMessage (INotification notification)
    {
      ShowTopUIRoot();
      welcomePanel.UpdateMessage((string)notification.Body);
    }

    /// <summary>
    ///   加载结束
    /// </summary>
    private void HandleLoadingEnd (INotification notification)
    {
      if(!topUIObject.activeSelf) return;
      welcomePanel.HideLoadingPanel();
      topUIObject.SetActive(false);
    }

    private void ShowTopUIRoot(){
      if(topUIObject.activeSelf) return;
      topUIObject.SetActive(true);
    }
    
  }
}