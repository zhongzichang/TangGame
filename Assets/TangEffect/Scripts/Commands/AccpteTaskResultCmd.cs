using UnityEngine;
using System.Collections;
using PureMVC.Patterns;
using PureMVC.Interfaces;
using TGN = TangGame.Net;

/// <summary>
/// 接受任务消息处理
/// </summary>
namespace TangGame
{
  public class AccpteTaskResultCmd : SimpleCommand
  {
    public static string NAME = TGN.AccpteTaskResult.NAME;

    public override void Execute (INotification notification)
    {
      TGN.AccpteTaskResult result = notification.Body as TGN.AccpteTaskResult;
      TaskCache.AddOrUpdateHeroTask (result.herotask);
      TaskCache.RefreshMayReceiveTaskIds ();
      //如果接受任务是当前追踪任务则刷新追踪面板
      if (TaskCache.currentTrackingTaskId == result.herotask.taskConfigId) {
        SendNotification (NtftNames.TG_TRACK_CHANGE_TASK);
      }
      //自动追踪接受任务
      SendNotification(NtftNames.TG_AUTO_TRACK_TASK,result.herotask.taskConfigId);
    }
  }
}