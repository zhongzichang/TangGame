/// <summary>
/// xbhuang
/// 2013-11-28
/// Know task result cmd.
/// </summary>
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TGN = TangGame.Net;

namespace TangGame
{
  public class NpcTaskMarkCmd : SimpleCommand
  {
    public const string NAME = "NpcTaskMarkCmd";

    public override void Execute (INotification notification)
    {
      if (notification.Body == null) {
        Dictionary<long, TangGame.Net.Npc> npcActors = ActorCache.GetNpcActors ();
        foreach (KeyValuePair<long,TangGame.Net.Npc> npcActor in npcActors) {
          UpdateNpcTaskMark (npcActor.Value);
        }
      }else{
        UpdateNpcTaskMark(notification.Body as TangGame.Net.Npc);
      }
    }

    public void UpdateNpcTaskMark (TangGame.Net.Npc npc)
    {
      //        npc.taskIds
      GameObject actorObj = TangScene.TS.GetActorGameObject (npc.id);
      if (actorObj == null)
        return;
      NpcTaskMarkBhvr markBhvr = actorObj.GetComponent<NpcTaskMarkBhvr> ();
      
      if (markBhvr == null||markBhvr.npcTaskMarkObj == null) {
        return;
      }
      foreach (int taskId in npc.taskIds) {
        //如果可完成中包含当前任务ID并且完成任务NPC是当前NPC，则给NPC对象添加一个可完成动画标识
        if (TaskCache.noTransferHasBeenCompletedTaskIds.Contains (taskId) && Config.taskTable[taskId].Return_npc == npc.configId) {
          markBhvr.SetCompleteTag ();
          break;  
        }
        //如果可接中包含当前人物ID并且接受任务NPC是当前NPC，则给NPC对象添加一个可接动画标识
        if (TaskCache.mayReceiveTaskIds.Contains (taskId) && Config.taskTable[taskId].Accept_npc == npc.configId) {
          markBhvr.SetAcceptTag ();
          break;
        }
        //如果已接未完成中包含当前人物ID并且完成NPC是当前NPC，则给完成任务的英雄对象添加一个已接未完成动画标识
        if(TaskCache.receivingUnCompletedTaskIds.Contains(taskId) && Config.taskTable[taskId].Return_npc == npc.configId){
          markBhvr.UnCompletedTag();
          break;
        }
        //如果不包含则清空npc头上的图标
        markBhvr.SetHideAnima ();
      }
    }
  }
}