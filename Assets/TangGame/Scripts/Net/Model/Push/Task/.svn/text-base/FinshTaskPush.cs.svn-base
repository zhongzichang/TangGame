/*
 * 由SharpDevelop创建。
 * 用户： lygg
 * 日期: 2013/4/17
 * 时间: 11:43
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using UnityEngine;
using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 完成任务信息
/// </summary>
public class FinishTaskPush : Response
{
    public const string NAME = "finshTask_PUSH";

    public long finishTaskId;

    public FinishTaskPush() : base(NAME)
    {
    }

    public static FinishTaskPush Parse(MsgData data)
    {
        FinishTaskPush push = new FinishTaskPush();
        push.finishTaskId = data.GetLong(0);
        return push;
    }

}
}