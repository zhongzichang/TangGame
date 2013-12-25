/// <summary>
/// xbhuang
/// 2013-11-22
/// Know task result cmd.
/// </summary>
using UnityEngine;
using System.Collections;
using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace TangGame
{
  /// <summary>
  /// 更新任务的信息
  /// </summary>
  public class TaskUpdatePushCmd : SimpleCommand
  {
    public static string NAME = TangGame.Net.TaskUpdatePush.NAME;
    
    public override void Execute (INotification notification)
    {
      Net.TaskUpdatePush push = notification.Body as Net.TaskUpdatePush;
      if(!TaskCache.HeroTaskDictionary.ContainsKey(push.heroTaskId)){
        //TODO 找不到任务
        return;
      }
      TangGame.Net.HeroTask heroTask = TaskCache.HeroTaskDictionary[push.heroTaskId];
      if(heroTask != null && ActorCache.leadingActorId == push.heroId){
        heroTask.condition.num = push.num;
        heroTask.condition.oldNum = push.numOld;
        heroTask.state = push.taskState;
        TaskCache.RefreshMayReceiveTaskIds();
        //如果是当前追踪任务发生改变
        if(TaskCache.currentTrackingTaskId == heroTask.taskConfigId){
          SendNotification(NtftNames.TG_TRACK_CHANGE_TASK);
          //如果当前完成任务条件不是对话则自动追踪任务
//          if(CompleteTaskConditionType.NPC != Config.taskTable[heroTask.taskConfigId].conditionItem.completeTaskConditionType ){
//            // 中止寻路
//            if( AutoNavCache.isActive )
//              AutoNavHelper.Terminate();
//            SendNotification(NtftNames.TG_AUTO_TRACK_TASK,heroTask.taskConfigId);
//          }
        }
      }

    }
    
  }
}
