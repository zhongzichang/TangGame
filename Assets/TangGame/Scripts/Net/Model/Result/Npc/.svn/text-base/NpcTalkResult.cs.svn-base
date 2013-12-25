/*
 * 由SharpDevelop创建。
 * 用户： lygg
 * 日期: 2013/4/12
 * 时间: 10:09
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */

using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{

/// <summary>
/// 执行脚本
/// </summary>
public class NpcTalkResult : Response
{

    public const string NAME = "npcTalk_RESULT";

    public int id;//NPC的ID
    public string name;//NPC名称
    public string talk;//对话介绍
    public int icon;//头像图标

    public string funcStr;//功能字符串
    public long dareId;//挑战任务ID
    public List<long> taskIdList = new List<long>();//任务ID列表

    public NpcTalkResult() : base(NAME)
    {
    }

    public static NpcTalkResult Parse(MsgData data)
    {
        NpcTalkResult result =new NpcTalkResult();

        int index = 0;
        result.id = data.GetInt(index++);
        result.name = data.GetString(index++);
        result.talk = data.GetString(index++);
        result.icon = data.GetShort(index++);

        MsgData funcData = data.GetMsgData(index++);//功能
        result.funcStr = funcData.GetString(0);

        MsgData dareData = data.GetMsgData(index++);//挑战
        if(dareData.Size > 0)
        {
            result.dareId = dareData.GetLong(0);
        }

        MsgData taskData = data.GetMsgData(index++);//任务
        for(int i = 0; i < taskData.Size; i++)
        {
            result.taskIdList.Add(taskData.GetLong(i));
        }
        return result;
    }


}

}
