/*
 * 由SharpDevelop创建。
 * 用户： Sysin
 * 日期: 2013/11/22
 * 时间: 11:26
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
  [Response(NAME)]
  public class TaskUpdatePush :Response
  {
    public const string NAME="taskUpdate_PUSH";
    public long heroId;
    public long heroTaskId;
    public int taskId;
    public TaskState taskState;
    public int num;
    public int numOld;
    public TaskUpdatePush():base(NAME)
    {
      
    }
    
    public static TaskUpdatePush Parse(MsgData data)
    {
      TaskUpdatePush push=new TaskUpdatePush();
      int index=0;
      push.heroId = data.GetLong(index++);
      push.heroTaskId = data.GetLong(index++);
      push.taskId = data.GetInt(index++);
      push.taskState = (TaskState)data.GetShort(index++);
      push.num = data.GetInt(index++);
      push.numOld = data.GetInt(index++);
      return push;
    }
    
    
  }
}
