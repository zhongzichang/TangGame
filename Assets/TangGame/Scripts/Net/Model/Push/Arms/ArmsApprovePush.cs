/*
 * Created by SharpDevelop.
 * User: Cucumber
 * Date:
 * Time:
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// 玩家被同意加入家族推送
public class ArmsApprovePush : Response
{
    public const string NAME = "armsApprove_PUSH";


    public long id;//玩家ID
    public string name;//玩家名称
    public long armsId;//家族ID



    public ArmsApprovePush() : base(NAME)
    {
    }

    public static ArmsApprovePush Parse(MsgData data)
    {
        ArmsApprovePush push = new ArmsApprovePush();
        push.id = data.GetLong(0);
        push.name = data.GetString(1);
        push.armsId = data.GetLong(2);
        return push;
    }
}
}