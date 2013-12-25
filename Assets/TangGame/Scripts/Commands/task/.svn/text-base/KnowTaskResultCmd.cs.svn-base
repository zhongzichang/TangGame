/// <summary>
/// xbhuang
/// 2013-11-15
/// Know task result cmd.
/// </summary>
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace TangGame
{
  public class KnowTaskResultCmd : SimpleCommand
  {
    public static string NAME = TangGame.Net.KnowTaskResult.NAME;

    public override void Execute (INotification notification)
    {
      Net.KnowTaskResult result = notification.Body as Net.KnowTaskResult;

      //      TaskCache.heroTasks = result.heroTasks;
      foreach(KeyValuePair<long,TangGame.Net.HeroTask> heroTaskPair in result.heroTasks){
        TaskCache.AddOrUpdateHeroTask(heroTaskPair.Value);
      }
      TaskCache.RefreshMayReceiveTaskIds();

    }

  }
}