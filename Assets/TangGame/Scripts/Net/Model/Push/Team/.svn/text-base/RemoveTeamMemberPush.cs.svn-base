/*
 * 由SharpDevelop创建。
 * 用户： Sysin
 * 日期: 2013/5/7
 * 时间: 11:55
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using TangNet;

namespace TangGame.Net
{
public class RemoveTeamMemverPush:Response
{
    public long leaderId;//队长ID
    public long removeId;//移除玩家ID
    public const string NAME="removeTeamMember_PUSH";

    public RemoveTeamMemverPush():base(NAME)
    {

    }

    public static RemoveTeamMemverPush Parse(MsgData data)
    {
        RemoveTeamMemverPush push=new RemoveTeamMemverPush();
        int index=0;
        push.leaderId=data.GetLong(index++);
        push.removeId=data.GetLong(index++);
        return push;
    }
}

}