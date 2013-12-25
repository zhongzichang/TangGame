/*
 * 由SharpDevelop创建。
 * 用户： Sysin
 * 日期: 2013/4/26
 * 时间: 11:08
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
public class NpcFinishTaskPush : Response
{

    public const string NAME="npcFinishTask_PUSH";

    public long id;//任务ID
    public int npcId;//NPC ID
    public string npcName;//NPC名称
    public int npcIcon;//NPC 图标
    public long time;//限制时间

    public NpcFinishTaskPush():base(NAME)
    {

    }

    public static NpcFinishTaskPush Parse(MsgData data)
    {
        NpcFinishTaskPush push=new NpcFinishTaskPush();
        int index=0;
        push.id=data.GetLong(index++);
        push.npcId=data.GetInt(index++);
        push.npcName=data.GetString(index++);
        push.npcIcon=data.GetShort(index++);
        push.time=data.GetLong(index++);
        return push;
    }
}
}

