/*
 * 由SharpDevelop创建。
 * 用户： Sysin
 * 日期: 2013/5/7
 * 时间: 11:33
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class UpdateTeamLeaderPush:Response
{
    public long leaderId;
    public const string NAME="updateTeamLeader_PUSH";
    public UpdateTeamLeaderPush():base(NAME)
    {

    }
    public static UpdateTeamLeaderPush Parse(MsgData data)
    {
        UpdateTeamLeaderPush push=new UpdateTeamLeaderPush();
        int index=0;
        push.leaderId=(long)data.GetDouble(index++);
        return push;
    }
}
}