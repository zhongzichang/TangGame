/*
 * 由SharpDevelop创建。
 * 用户： Sysin
 * 日期: 2013/5/7
 * 时间: 14:56
 *
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using TangNet;

namespace TangGame.Net
{
public class OusterTeamPush:Response
{

    public const string NAME="ousterTeam_PUSH";

    public OusterTeamPush():base(NAME)
    {

    }
    public static OusterTeamPush Parse(MsgData data)
    {
        return new OusterTeamPush();
    }
}
}