/*
 * 由SharpDevelop创建。
 * 用户： Sysin
 * 日期: 2013/5/7
 * 时间: 11:41
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */

using TangNet;

namespace TangGame.Net
{
public class AddTeamMemberPush : Response
{

    public TeamMember teamMember;
    public const string NAME="addTeamMember_PUSH";
    public AddTeamMemberPush():base(NAME)
    {

    }
    public static AddTeamMemberPush Parse(MsgData data)
    {
        AddTeamMemberPush push = new AddTeamMemberPush();
        push.teamMember = TeamMember.Parse(data);
        return push;
    }
}
}