/*
 * 由SharpDevelop创建。
 * 用户： Sysin
 * 日期: 2013/5/7
 * 时间: 16:43
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using TangNet;


namespace TangGame.Net
{
public class UpdateTeamMemberPush:Response
{
    public const string NAME="updateTeamMember_PUSH";
    public TeamMember teamMember=new TeamMember();
    public UpdateTeamMemberPush():base(NAME)
    {

    }

    public static UpdateTeamMemberPush Parse(MsgData data)
    {
        UpdateTeamMemberPush push=new UpdateTeamMemberPush();
        push.teamMember=TeamMember.Parse(data.GetMsgData(0));
        return push;
    }
}
}