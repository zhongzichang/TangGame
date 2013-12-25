/*
 * 由SharpDevelop创建。
 * 用户： Sysin
 * 日期: 2013/5/6
 * 时间: 17:35
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class TeamMsgPush:Response
{
    public const string NAME="teamMsg_PUSH";

    public Team team = new Team();

    public TeamMsgPush():base(NAME)
    {

    }
    public static TeamMsgPush Parse(MsgData data)
    {
        TeamMsgPush push=new TeamMsgPush();
        int index=0;
        push.team.teamId=(long)data.GetDouble(index++);
        push.team.leaderId=(long)data.GetDouble(index++);

        int length = data.Size - index;
        push.team.memberArray = new TeamMember[length];
        for(int i = 0; i < length; i++)
        {
            push.team.memberArray[i] = TeamMember.Parse(data.GetMsgData(index++));
        }
        return push;
    }

}
}