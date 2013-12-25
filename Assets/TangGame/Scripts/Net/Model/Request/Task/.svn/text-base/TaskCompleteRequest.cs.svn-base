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

public class TaskCompleteRequest : Request
{

    private long taskId;
    private int goodsId;

    public TaskCompleteRequest(long taskId, int goodsId)
    {
        this.taskId = taskId;
        this.goodsId = goodsId;
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(TaskProxy.S_TASK_FINISH);
            data.PutLong(taskId);
            data.PutInt(goodsId);
            return data;
        }
    }
}
}
