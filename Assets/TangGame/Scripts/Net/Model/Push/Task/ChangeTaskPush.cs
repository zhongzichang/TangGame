/*
 * 由SharpDevelop创建。
 * 用户： lygg
 * 日期: 2013/4/18
 * 时间: 16:34
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 可接任务信息
/// </summary>
public class ChangeTaskPush : Response
{
    public long id;
    public short state;
    public List<Item> condition=new List<Item>();
    public const string NAME = "changeTask_PUSH";
    public ChangeTaskPush() : base(NAME)
    {

    }
    public static ChangeTaskPush Parse(MsgData data)
    {
        ChangeTaskPush push = new ChangeTaskPush();
        int index=0;
        push.id=(long)data.GetDouble(index++);
        push.state=data.GetShort(index++);
        while(index<data.Size)
        {
            push.condition.Add(Item.Parse(data.GetMsgData(index++)));
        }
        return push;
    }
}
}