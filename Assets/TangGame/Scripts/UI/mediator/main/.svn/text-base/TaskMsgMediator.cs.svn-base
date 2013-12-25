/// <summary>
/// xbhuang
/// 2013/11/21
/// </summary>
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using nh.ui.cache;
using TangGame;

namespace nh.ui.main
{
  public class TaskMsgMediator : Mediator
  {
    TaskMsgPanel panel;
    public new const string NAME = "TASK_MSG_MEDIATOR";
    private delegate void Handle (INotification notification);
    /// <summary>
    /// 我的消息处理映射方法
    /// </summary>
    private Dictionary<string, Handle> handleTable = new Dictionary<string, Handle> ();
    /// <summary>
    ///   感兴趣的消息
    /// </summary>
    private List<string> interests = new List<string> ();
    /// <summary>
    /// 我的构造方法
    /// </summary>
    /// <param name="gameObject"></param>
    public TaskMsgMediator (TaskMsgPanel viewComponent) : base(NAME)
    {
      panel = viewComponent;
      handleTable.Add (NtftNames.TG_TRACK_CHANGE_TASK, HandleChangeTrackTask);
    }

    /// <summary>
    /// 我感兴趣的消息
    /// </summary>
    /// <returns></returns>
    public override IList<string> ListNotificationInterests ()
    {
      if (interests.Count == 0) {
        interests.Add (NtftNames.TG_TRACK_CHANGE_TASK);
      }
      return interests;
    }
    /// <summary>
    /// 处理通知
    /// </summary>
    /// <param name="notification"></param>
    public override void HandleNotification (INotification notification)
    {
      if (handleTable.ContainsKey (notification.Name))
        handleTable [notification.Name] (notification);
    }

//    public TaskMsgMediator (TaskMsgPanel viewComponent)
//    {
//
//    }

    /// <summary>
    /// 监听改变最终任务的消息
    /// </summary>
    /// <param name="notification">Notification.</param>
    public void HandleChangeTrackTask (INotification notification)
    {
      RefreshTrackingTask ();
    }


    /// <summary>
    /// 刷新任务追踪面板
    /// </summary>
    public void RefreshTrackingTask ()
    {
      TangGame.Xml.Task xmlTask;
      //尝试去获取追踪任务
      Config.taskTable.TryGetValue (TaskCache.GetDefaultTrackTaskId (), out xmlTask);
      //如果追踪任务获取失败,则表示没有可接任务
      if (xmlTask == null) {
        //TODO 如果没有任务的话做相关的处理 
        return;
      }
      //设置当前追踪任务ID
      TaskCache.currentTrackingTaskId = xmlTask.Id;

      panel.UpdateTrackTaskPanelInfo (xmlTask);


    }
    /// <summary>
    /// 给按钮对象添加事件
    /// </summary>
    public void AddEvent ()
    {
      this.DelEvent();
      if (panel.taskMsgButton != null)
        UIEventListener.Get (panel.taskMsgButton.gameObject).onClick += OnClickTrackTask;
      if(panel.hideButton != null)
        UIEventListener.Get(panel.hideButton.gameObject).onClick += OnClickHideButton;
      if(panel.ShowBut != null)
        UIEventListener.Get(panel.ShowBut.gameObject).onClick += OnClickShowButton;

    }
    /// <summary>
    /// 给按钮对象移除事件
    /// </summary>
    public void DelEvent ()
    {
      if (panel.taskMsgButton != null)
        UIEventListener.Get (panel.taskMsgButton.gameObject).onClick -= OnClickTrackTask;
      if(panel.hideButton != null)
        UIEventListener.Get(panel.hideButton.gameObject).onClick -= OnClickHideButton;
      if(panel.ShowBut != null)
        UIEventListener.Get(panel.ShowBut.gameObject).onClick -= OnClickShowButton;
    }
    /// <summary>
    /// 点击按钮进行追踪功能的实现
    /// </summary>
    public void OnClickTrackTask (GameObject gameObj)
    {
      //自动追踪当前追踪任务
//      this.AutoTrackTask(TaskCache.currentTrackingTaskId);
      SendNotification(NtftNames.TG_AUTO_TRACK_TASK);

    }
    /// <summary>
    /// 隐藏或者显示任务追踪面板
    /// </summary>
    public void OnClickHideButton(GameObject gameObj){
      if(panel.animator.enabled == false){
        panel.animator.enabled = true;
      }
      if(panel.animator != null){
         panel.animator.SetInteger("Mi",2);
      }
    }
    public void OnClickShowButton(GameObject gameObj){
      if(panel.animator.enabled == false){
        panel.animator.enabled = true;
      }
      if(panel.animator != null){
        panel.animator.SetInteger("Mi",1);
      }
    }
  }
}
