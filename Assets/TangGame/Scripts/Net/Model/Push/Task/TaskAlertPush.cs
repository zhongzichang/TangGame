/*
 * 由SharpDevelop创建。
 * 用户： Sysin
 * 日期: 2013/4/26
 * 时间: 10:54
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */


using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 任务事件面板
/// </summary>
public class TaskAlertPush : Response
{

    public int id;
    public int type;
    public const string NAME = "taskAlert_PUSH";
    public TaskAlertPush() : base(NAME)
    {
    }

    public static TaskAlertPush Parse(MsgData data)
    {

        TaskAlertPush push = new TaskAlertPush();
        int index=0;
        push.id=data.GetShort(index++);
        push.id=data.GetShort(index++);
        return push;
    }
}
}