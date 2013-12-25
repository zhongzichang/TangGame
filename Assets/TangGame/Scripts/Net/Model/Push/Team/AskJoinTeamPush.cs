/*
 * 由SharpDevelop创建。
 * 用户： Sysin
 * 日期: 2013/5/7
 * 时间: 16:18
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using TangNet;

namespace TangGame.Net
{
public class AskJoinTeamPush:Response
{
    public const string NAME="askJoinTeam_PUSH";

    public long id;
    public string name;

    public AskJoinTeamPush():base(NAME)
    {

    }
    public static AskJoinTeamPush Prase(MsgData data)
    {
        AskJoinTeamPush push=new AskJoinTeamPush();
        int index=0;
        push.id=(long)data.GetDouble(index++);
        push.name=data.GetString(index++);
        return push;
    }

}
}
