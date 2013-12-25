/// <summary>
/// xbhuang
/// 2013/11/24
/// </summary>
using UnityEngine;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace TangGame
{
  /// <summary>
  /// 自动追踪指定任务，需要传入任务ID，否则就自动追踪当前追踪的任务
  /// </summary>
  public class AutoTrackTaskCmd :SimpleCommand
  {
    public const string NAME = NtftNames.TG_AUTO_TRACK_TASK;

    public override void Execute (INotification notification)
    {
      //追踪任务ID
      int taskConfigId;
      if (notification == null) {
        return;
      }
      //如果body是空则正在追踪的任务
      if (notification.Body == null) {
        taskConfigId = TaskCache.currentTrackingTaskId;
      } else {
        taskConfigId = (int)notification.Body;
      }

      //如果当前没有追踪任务则跳出此命令
      if (taskConfigId <= 0) {
        return;
      }

      TangGame.Xml.Task xmlTask;
      //如果配置表里面不包含追踪任务ID
      if (!Config.taskTable.ContainsKey (taskConfigId))
        return;

      //当前追踪任务ID
      xmlTask = Config.taskTable [taskConfigId];
      
      //如果任务为空则跳出此方法
      if (xmlTask == null) {
        return;
      }
      //获取当前的任务列表
//      List<TangGame.Net.HeroTask> heroTaskList = new List<TangGame.Net.HeroTask> (TangGame.TaskCache.heroTasks.Values);
//      //根据配置ID反向查找到英雄任务
//      TangGame.Net.HeroTask heroTask = heroTaskList.Find (delegate (TangGame.Net.HeroTask htk) {
//        return htk.taskConfigId == TaskCache.currentTrackingTaskId;
//      });
      TangGame.Net.HeroTask heroTask = TaskCache.GetTaskById(TaskCache.currentTrackingTaskId);
      //如果当前处于挂机则取消挂机
      if(BattleCache.onHook){
        SendNotification(NtftNames.TG_UNHOOK);
      }
      #region 如果英雄任务为空表明这是可接任务
      if (heroTask == null) {
        TangGame.Net.Npc npcNo = ActorCache.GetNpcByConfigId (xmlTask.Accept_npc);
        //如果找到就自己去追踪,否则就向服务器发起请求
        if (npcNo != null) {
          TangScene.TS.ActorTrace (ActorCache.leadingActorId, npcNo.id);
        } else {
          //向服务器发起跨地图NPC追踪
          TangNet.TN.Send (new TangGame.Net.SearchNpcRequest (xmlTask.Accept_npc));
        }
      }
      #endregion
      
      #region 如果英雄任务状态完成未交付
      if (heroTask != null && heroTask.state == TaskState.UNTO) {
        TangGame.Net.Npc npcNo = ActorCache.GetNpcByConfigId (xmlTask.Return_npc);
        //如果找到就自己去追踪,否则就向服务器发起请求
        if (npcNo != null) {
          TangScene.TS.ActorTrace (ActorCache.leadingActorId, npcNo.id);
        } else {
          //向服务器发起跨地图NPC追踪
          TangNet.TN.Send (new TangGame.Net.SearchNpcRequest (xmlTask.Return_npc));
        }
      }
      #endregion
      
      #region 如果英雄任务状态接取未完成
      if (heroTask != null && heroTask.state == TaskState.UNDO) {
        //根据任务条件进行追踪
        TangGame.Net.Npc npcNo = ActorCache.GetNpcByConfigId (xmlTask.Return_npc);
        if (xmlTask.effectItem == null) {
          if (npcNo != null) {
            /*
            AutoNavCache.isActive = true;
            AutoNavCache.mode = AutoNavCache.Mode.searchActor;
            AutoNavCache.targetActorConfigId = npcNo.configId;
            AutoNavHelper.Start();*/
            
            ActorAutoNavBean bean = new ActorAutoNavBean(npcNo.configId, null);
            SendNotification(NtftNames.AUTO_NAV, bean);
            

          } else {
            //向服务器发起跨地图NPC追踪
            TangNet.TN.Send (new TangGame.Net.SearchNpcRequest (xmlTask.Return_npc));
          }
        } else {
          switch (xmlTask.effectItem.trackType) {
          case TrackType.AUTOFINDITSWAY:
            Vector3 targetVector = TangUtils.GridUtil.PointToVector3(xmlTask.effectItem.coordinateX,xmlTask.effectItem.coordinateY);
            //判断当前地图是否为目标的地图
            if(ActorCache.GetLeadingHero().mapId == xmlTask.effectItem.mapId){
              
              /*
              AutoNavCache.isActive = true;
              AutoNavCache.mode = AutoNavCache.Mode.searchScene;
              AutoNavCache.targetPosition = targetVector;
              AutoNavHelper.Start();*/
              
              PosAutoNavBean bean = new PosAutoNavBean(targetVector,null);
              SendNotification(NtftNames.AUTO_NAV, bean);
              
            }else{
              //向服务器发起跨地图寻路到某个地图
              TangNet.TN.Send (new TangGame.Net.SearchMapRequest ((short)xmlTask.effectItem.mapId));
              AutoNavCache.targetPosition = targetVector;
            }
            break;

          case TrackType.OPENPANEL:
             //TODO 先這樣，後期需要進行修改
            if(xmlTask.effectItem.panelId == 101){
							SendNotification(NotificationIDs.ID_OPenMainGamePanel, NotificationIDs.ID_OpenOrCloseSkillPanel);
            }
            break;
            
          }
        }
      }
      #endregion
    }

  }

}