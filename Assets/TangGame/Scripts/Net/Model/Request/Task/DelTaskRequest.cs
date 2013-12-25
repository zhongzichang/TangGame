using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class DelTaskRequest : Request
{
    private int taskId;
    public DelTaskRequest(int taskId)
    {
        this.taskId=taskId;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(TaskProxy.S_TASK_DEL_KNOW);
            data.PutInt(taskId);
            return data;
        }
    }
}
}
