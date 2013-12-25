///xbhuang
///小伙伴们，来点乐子吧！
using UnityEngine;
using System.Collections;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TGN = TangGame.Net;
using TS = TangScene;

/// <summary>
/// 获取到场景中NPC的详细信息
/// </summary>
namespace TangGame
{
  public class GetSceneNpcInfoCmd : SimpleCommand
  {
    public static string NAME = TGN.GetSceneNpcInfoResult.NAME;
    MissionAwardBean missionAwardBean;
    MissionTalkBean missionTalkBean;
    Xml.Task xmlTask;
    NpcFunctionEnum npcType;
    Net.Npc netNpc;

    public override void Execute (INotification notification)
    {
      TGN.GetSceneNpcInfoResult result = notification.Body as TGN.GetSceneNpcInfoResult;
      //TODO
      //打开功能面板
      //刷新当前角色的任务
      TaskCache.currentNpcDialogueQueue.Clear ();
      npcType = (NpcFunctionEnum)result.npcType;
      netNpc = ActorCache.GetNpcById (result.npcId);
      switch (npcType) {
      case NpcFunctionEnum.TASKNPC:
          
        foreach (int taskId in result.ids) {
          xmlTask = Config.taskTable [taskId];
          GenerateSubmitTaskNpcDialogue (result.npcId, taskId);
        }
        foreach (int taskId in result.ids) {
          xmlTask = Config.taskTable [taskId];
          GenerateCompleteTaskNpcDialogue (result.npcId, taskId);
        }
        foreach (int taskId in result.ids) {
          xmlTask = Config.taskTable [taskId];
          GenerateAcceptTaskNpcDialogue (result.npcId, taskId);
        }
          //如果当前对话队列不为空
        if (TaskCache.currentNpcDialogueQueue.Count > 0) {
          if (TaskCache.currentNpcDialogueQueue.Peek () is MissionTalkBean) {
            SendNotification (NotificationIDs.ID_OPEN_MISSION_TALK_PANEL, TaskCache.currentNpcDialogueQueue.Dequeue ());
          } else if (TaskCache.currentNpcDialogueQueue.Peek () is MissionAwardBean) {
            SendNotification (NotificationIDs.ID_OPEN_MISSION_AWARD_PANEL, TaskCache.currentNpcDialogueQueue.Dequeue ());
          }
        } else {
          //如果npc对话内容不为空的话
          if (result.note != null && result.note.Length > 0) {
            missionTalkBean = new MissionTalkBean (result.npcId, result.note);
            SendNotification (NotificationIDs.ID_OPEN_MISSION_TALK_PANEL, missionTalkBean);
          }
        }
        break;
      default:
        NPCTalkBean bean = new NPCTalkBean (result.npcId, result.ids, npcType);
        SendNotification (NotificationIDs.ID_OPEN_NPC_TALK_PANEL, bean);
        break;
      }
    }
    /// <summary>
    /// 生成任务提交NPC对话队列
    /// </summary>
    /// <param name="npcId"></param>
    /// <param name="taskId"></param>
    private void GenerateSubmitTaskNpcDialogue (long npcId, int taskId)
    {
      //如果当前完成任务NPCid不为当前ID则跳出此方法
      if (xmlTask.Return_npc != ActorCache.GetNpcById (npcId).configId)
        return;
      if (TaskCache.noTransferHasBeenCompletedTaskIds.Contains (taskId)) {
        missionAwardBean = new MissionAwardBean (npcId, taskId, TaskState.UNTO);
        TaskCache.currentNpcDialogueQueue.Enqueue (missionAwardBean);
      }
    }
    /// <summary>
    /// 生成任务条件NPC对话队列
    /// </summary>
    /// <param name="npcId">Npc identifier.</param>
    /// <param name="taskId">Task identifier.</param>
    private void GenerateCompleteTaskNpcDialogue (long npcId, int taskId)
    {
      Xml.ConditionItem conditionItem = xmlTask.conditionItem;
      //如果当前任务有任务对话条件，判断条件是否满足
      if (conditionItem.completeTaskConditionType == CompleteTaskConditionType.NPC) {
        if (conditionItem.npcId != ActorCache.GetNpcById (npcId).configId)
          return;
        if (TaskCache.receivingUnCompletedTaskIds.Contains (taskId)) {
          missionTalkBean = new MissionTalkBean (npcId, xmlTask.Complete_note, taskId);
          TaskCache.currentNpcDialogueQueue.Enqueue (missionTalkBean);
        }
      }
    }


    /// <summary>
    /// 生成接受任务NPC对话队列
    /// </summary>
    /// <param name="npcId"></param>
    /// <param name="taskId"></param>
    private void GenerateAcceptTaskNpcDialogue (long npcId, int taskId)
    {

      //如果当前接受任务NPCid不为当前ID则跳出此方法
      if (xmlTask.Accept_npc != ActorCache.GetNpcById (npcId).configId)
        return;
      if (TaskCache.mayReceiveTaskIds.Contains (taskId)) {

        missionAwardBean = new MissionAwardBean (npcId, taskId, TaskState.NONE);
        missionTalkBean = new MissionTalkBean (npcId, xmlTask.Note, SendNotification,
                                               NotificationIDs.ID_OPEN_MISSION_AWARD_PANEL, missionAwardBean);
        TaskCache.currentNpcDialogueQueue.Enqueue (missionTalkBean);
        
      }
    }
  }
}