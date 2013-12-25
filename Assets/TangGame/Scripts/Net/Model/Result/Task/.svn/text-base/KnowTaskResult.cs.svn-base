using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
  [Response(NAME)]
  public class KnowTaskResult : Response
  {
    public const string NAME = "taskList_RESULT";
//    public short length;
    public long heroId;
    public Dictionary<long,HeroTask> heroTasks = new Dictionary<long, HeroTask>();

    public KnowTaskResult () : base(NAME)
    {
    }

    public static KnowTaskResult Parse (MsgData data)
    {
      KnowTaskResult result = new KnowTaskResult ();
      result.heroId = data.GetLong(0);
      MsgData heroTasksData = data.GetMsgData(1);
      for(int index = 0;index < heroTasksData.Size;index++){
        HeroTask heroTask = HeroTask.Parse(heroTasksData.GetMsgData(index));
        result.heroTasks.Add(heroTask.id,heroTask);
      }
      return result;
    }
  }
}
