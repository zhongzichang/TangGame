/*
 * 由SharpDevelop创建。
 * 用户： Sysin
 * 日期: 2013/5/7
 * 时间: 15:13
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using TangNet;

namespace TangGame.Net
{
public class RepelInvitePush:Response
{
    public const string NAME="repelInvite_PUSH";
    public string name;
    public RepelInvitePush():base(NAME)
    {

    }
    public static RepelInvitePush Prase(MsgData data)
    {
        RepelInvitePush push=new RepelInvitePush();
        int index=0;
        push.name=data.GetString(index++);

        return push;
    }

}
}