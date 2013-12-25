using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 刷新任务星级
/// </summary>
public class RefreshStarTaskResult : Response
{
    public const string NAME = "RefreshStarTask_RESULT";
    public short type;
    public long taskId;
    public long newTaskId;
    public int heroBaseCoin;
    public int coin;

    public RefreshStarTaskResult() : base(NAME)
    {
    }
    public static RefreshStarTaskResult Parse(MsgData data)
    {

        RefreshStarTaskResult result  = new RefreshStarTaskResult();


        int index = 0;
        result.type = data.GetShort(index++);
        result.taskId=(long)data.GetDouble(index++);
        result.newTaskId = (long)data.GetDouble(index++);
        result.heroBaseCoin = data.GetInt(index++);
        result.coin = data.GetInt(index++);


        return result;
    }
}
}