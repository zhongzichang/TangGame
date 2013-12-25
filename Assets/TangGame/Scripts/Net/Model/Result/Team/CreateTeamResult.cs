/*
 * 由SharpDevelop创建。
 * 用户： Sysin
 * 日期: 2013/5/6
 * 时间: 20:34
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using TangNet;

namespace TangGame.Net
{
public class CreateTeamResult:Response
{
    public long teamid;
    public const string NAME="createTeam_RESULT";
    /// <summary>
    /// 创建队伍返回信息
    /// </summary>
    public CreateTeamResult():base(NAME)
    {

    }
    public static CreateTeamResult Parse(MsgData data)
    {
        CreateTeamResult push=new CreateTeamResult();
        push.teamid=(long)data.GetDouble(0);
        return push;
    }
}
}
