/*
 * Created by SharpDevelop.
 * User: Cucumber
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

public class TaskAddKnowRequest : Request
{

    private long taskId;

    public TaskAddKnowRequest(long taskId)
    {
        this.taskId = taskId;
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(TaskProxy.S_TASK_ADD_KNOW);
            data.PutLong(taskId);
            return data;
        }
    }
}
}
