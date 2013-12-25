using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
  public class NpcTalkRequest : Request
  {
    private int npcConfigId;
    private int taskConfigId;

    public NpcTalkRequest (int npcConfigId,int taskConfigId)
    {
      this.npcConfigId = npcConfigId;
      this.taskConfigId = taskConfigId;

    }

    public NetData NetData {
      get {
        NetData data = new NetData (NpcProxy.S_TALK);
        data.PutInt (npcConfigId);
        data.PutInt (taskConfigId);
        return data;
      }
    }
  }
}
