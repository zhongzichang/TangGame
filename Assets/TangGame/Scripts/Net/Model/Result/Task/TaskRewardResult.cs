/// <summary>
/// Task reward result.
/// xbhuang
/// 2013/11/18
/// </summary>
using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
  [Response(NAME)]
  public class TaskRewardResult : Response
  {
    public const string NAME = "taskReward_RESULT";
    /// <summary>
    /// 任务唯一ID
    /// </summary>
    public long heroTaskId;
    /// <summary>
    /// 任务配置表ID
    /// </summary>
    public int configTaskId;
    /// <summary>
    /// 任务完成状态
    /// </summary>
    public TaskState taskState;
    /// <summary>
    /// 任务完成数量
    /// </summary>
    public int num;
    /// <summary>
    /// 满足完成任务的数量
    /// </summary>
    public int numMax;
    public TaskRewardResult () : base(NAME)
    {
    }
    
    public static TaskRewardResult Parse (MsgData data)
    {
      TaskRewardResult result = new TaskRewardResult ();
      int index = 0;
      result.heroTaskId = data.GetLong(index++);
      result.configTaskId = data.GetInt(index++);
      result.taskState = (TaskState)data.GetShort(index++);
      result.num = data.GetInt(index++);
      result.numMax = data.GetInt(index++);
      return result;
    }
  }
}