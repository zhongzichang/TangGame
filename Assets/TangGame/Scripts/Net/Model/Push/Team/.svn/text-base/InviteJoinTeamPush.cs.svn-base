/*
 * 由SharpDevelop创建。
 * 用户： Sysin
 * 日期: 2013/5/7
 * 时间: 15:22
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class InviteJoinTeamPush:Response
{
    public long teamid;
    public string name;
    public const string NAME="inviteJoinTeam_PUSH";
    public InviteJoinTeamPush():base(NAME)
    {

    }
    public static InviteJoinTeamPush Parse(MsgData data)
    {
        int index=0;
        Debug.Log(">>InviteJoinTeamPush Parse");
        InviteJoinTeamPush push=new InviteJoinTeamPush();
        push.teamid=(long)data.GetDouble(index++);
        Debug.Log(">>InviteJoinTeamPush Parse push.teamid = " + push.teamid);
        push.name=data.GetString(index++);
        return push;
    }
}
}