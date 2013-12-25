using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class FinishTaskRequest : Request
{
    private int taskId;
    public FinishTaskRequest(int taskId )
    {
        this.taskId=taskId;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(TaskProxy.S_TASK_FINISH);
            data.PutInt(taskId);
            return data;
        }
    }
}
}
