using UnityEngine;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace nh.ui.mediator
{
  public class DeadMessageMediator : BaseMediator {
    public new const string NAME = "DeadMessageMediator";
    DeadMessagePanel dmp;
    /// <summary>
    /// 我的构造方法
    /// </summary>
    public DeadMessageMediator () : base(NAME)
    {
      //      handleTable.Add(NotificationIDs.ID_UPDATE_AUTO_PANEL,UpdateAutoPanelSprite);
      handleTable.Add(TangGame.NtftNames.TG_LEADING_ACTOR_DIE,OpenDeadMessagePanel);
      handleTable.Add(TangGame.NtftNames.TG_LEADING_ACTOR_RELIVE,CloseDeadMessagePanel);
    }

    /// <summary>
    /// 我感兴趣的消息
    /// </summary>
    /// <returns></returns>
    public override IList<string> ListNotificationInterests ()
    {
      if (interests.Count == 0) {
        //        interests.Add(NotificationIDs.ID_UPDATE_AUTO_PANEL);
        interests.Add(TangGame.NtftNames.TG_LEADING_ACTOR_DIE);
        interests.Add(TangGame.NtftNames.TG_LEADING_ACTOR_RELIVE);

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
    public void OpenDeadMessagePanel(INotification notification){
      if (!isLoad)
        this.StartLoadResAndShow(typeof(DeadMessagePanel).Name);
      else
        this.Show(true);
      dmp = m_Panel as DeadMessagePanel;
      this.AddEvent();
      //关闭场景输入
      SendNotification(TangGame.NotificationIDs.ID_DisableSceneClick);
    }
    public void CloseDeadMessagePanel(INotification notification){
      this.Show(false);
      //开启场景输入
      SendNotification(TangGame.NotificationIDs.ID_EnableSceneClick);
    }
    
    override protected void AddEvent(){
      this.RemoveEvent();
      if(dmp != null){
        if(dmp.Button){
          UIEventListener.Get(dmp.Button).onClick += OnClickButton;
        }
      }
    }
    override protected void RemoveEvent(){
      if(dmp != null){
        if(dmp.Button){
          UIEventListener.Get(dmp.Button).onClick -= OnClickButton;
        }
      }
    }
    private void OnClickButton(GameObject obj){
      //TODO 发送复活命令暂时使用原地复活。
      TangNet.TN.Send(new TangGame.Net.HeroReliveRequest(1));
    }
  }
}