/*
 * 由SharpDevelop创建。
 * 用户： Sysin
 * 日期: 2013/5/7
 * 时间: 15:00
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using TangNet;

namespace TangGame.Net
{
public class TeamMemberSatePush:Response
{
    public const string NAME="teamMemberSate_PUSH";
    public long id;
    public short status;
    public TeamMemberSatePush():base(NAME)
    {

    }

    public static TeamMemberSatePush Parse(MsgData data)
    {
        TeamMemberSatePush push=new TeamMemberSatePush();
        int index=0;
        push.id=(long)data.GetDouble(index++);
        push.status=data.GetShort(index++);
        return push;

    }
}
}