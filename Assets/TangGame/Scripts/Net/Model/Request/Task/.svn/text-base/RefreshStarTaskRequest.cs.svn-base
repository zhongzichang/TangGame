using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class RefreshStarTaskRequest : Request
{
    private short type;
    private long taskId;
    private short refreshType;
    private short expenseType;
    private short level;
    public RefreshStarTaskRequest(short type,long taskId,short refreshType,short expenseType,short level)
    {
        this.type=type;
        this.taskId=taskId;
        this.refreshType=refreshType;
        this.expenseType=expenseType;
        this.level=level;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(TaskProxy.REFRESH_STAR_TASK);
            data.PutShort(type);
            data.PutLong(taskId);
            data.PutShort(refreshType);
            data.PutShort(expenseType);
            data.PutShort(level);
            return data;
        }
    }
}
}
