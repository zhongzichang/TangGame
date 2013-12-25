/*
 * 由SharpDevelop创建。
 * 用户： Sysin
 * 日期: 2013/4/26
 * 时间: 11:34
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */

using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 接受任务提示推送
/// </summary>
public class TaskReceivePush : Response
{
    public const string NAME="taskReceive_PUSH";

    public long taskId;
    public int npcId;
    public string npcName;
    public short npcIcon;
    public long time;
    public TaskReceivePush():base(NAME)
    {


    }

    public static TaskReceivePush Parse(MsgData data)
    {
        TaskReceivePush push=new TaskReceivePush();
        int index=0;
        push.taskId=data.GetLong(index++);
        push.npcId = data.GetInt(index++);
        push.npcName=data.GetString(index++);
        push.npcIcon=data.GetShort(index++);
        push.time=data.GetLong(index++);
        return push;
    }
}
}