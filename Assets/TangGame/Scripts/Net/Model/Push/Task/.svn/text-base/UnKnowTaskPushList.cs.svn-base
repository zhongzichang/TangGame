using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 可接任务信息
/// </summary>
public class UnKnowTaskPushList : Response
{
    public const string NAME = "unknowTaskList_PUSH";

    public List<long> idList = new List<long>();
    public UnKnowTaskPushList() : base(NAME)
    {

    }

    public static UnKnowTaskPushList Parse(MsgData data)
    {
        UnKnowTaskPushList push = new UnKnowTaskPushList();
        int index=0;
        while(index<data.Size)
        {
            push.idList.Add((long)data.GetDouble(index++));
        }
        return push;
    }
}
}