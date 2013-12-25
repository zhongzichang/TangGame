using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
  public class AddTaskRequest : Request
  {
    private int taskId;
    private int npcId;
    private int mapId;

    public AddTaskRequest (int taskId, int npcId, int mapId)
    {
      this.npcId = npcId;
      this.mapId = mapId;
      this.taskId = taskId;
    }

    public NetData NetData {
      get {
        NetData data = new NetData (TaskProxy.S_TASK_ADD_KNOW);
        data.PutInt (taskId);
        data.PutInt(npcId);
        data.PutInt(mapId);
        return data;
      }
    }
  }
}
