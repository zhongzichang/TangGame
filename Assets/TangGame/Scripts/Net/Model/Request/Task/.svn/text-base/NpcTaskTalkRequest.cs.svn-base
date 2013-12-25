/*
 * Created by SharpDevelop.
 * User: xbhuang
 * Date:
 * Time:
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
  
  public class NpcTaskTalkRequest : Request
  {
    
    private int taskId;
    
    public NpcTaskTalkRequest(int taskId)
    {
      this.taskId = taskId;
    }
    
    public NetData NetData
    {
      get
      {
        NetData data = new NetData(TaskProxy.S_TASK_ADD_KNOW);
        data.PutInt(taskId);
        return data;
      }
    }
  }
}
