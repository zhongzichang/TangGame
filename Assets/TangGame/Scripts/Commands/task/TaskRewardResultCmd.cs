/// <summary>
/// xbhuang
/// 2013-11-18
/// Know task result cmd.
/// </summary>
using UnityEngine;
using System.Collections;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TGN = TangGame.Net;

namespace TangGame
{
  public class TaskRewardResultCmd : SimpleCommand
  {
    public static string NAME = TGN.TaskRewardResult.NAME;
    
    public override void Execute (INotification notification)
    {
      if (notification.Body == null)
        return;
      Net.TaskRewardResult result = notification.Body as Net.TaskRewardResult;
      if (result.heroTaskId == 0)
        return;
      //完成任务
      TGN.HeroTask heroTask = null;
      heroTask = TaskCache.HeroTaskDictionary [result.heroTaskId];
      //去除已完成未交接集合中的此任务
      TaskCache.noTransferHasBeenCompletedTaskIds.Remove (heroTask.taskConfigId);
      //玩家身上不存在此任务
      if (heroTask == null)
        return;
      heroTask.taskConfigId = result.configTaskId;
      heroTask.state = result.taskState;
      heroTask.condition.num = result.num;
      heroTask.condition.oldNum = result.numMax;
      TaskCache.RefreshMayReceiveTaskIds ();
      //如果完成任务是当前追踪的任务那么就追踪下一个
      if (TaskCache.currentTrackingTaskId == heroTask.taskConfigId) {
        //清空当前追踪
        TaskCache.currentTrackingTaskId = 0;
        for (int i = 0; i < TaskCache.mayReceiveTaskIds.Count; i++) {
          TangGame.Xml.Task xmlTask = Config.taskTable [TaskCache.mayReceiveTaskIds [i]];
          Xml.ObtaincondItem obtaincondItem = xmlTask.obtaincondItem;
          if (obtaincondItem.acceptType == AcceptType.LASTTASK) {
            if (obtaincondItem.taskId == result.configTaskId) {
              TaskCache.currentTrackingTaskId = xmlTask.Id;
            }
          }
        }
        //刷新主UI追踪
        SendNotification (NtftNames.TG_TRACK_CHANGE_TASK);
        SendNotification (NtftNames.TG_AUTO_TRACK_TASK);
      }
    }
    
  }
}