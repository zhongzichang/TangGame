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
/// 家族退出推送
public class GoAwayArmsPush : Response
{
    public const string NAME = "goAwayArms_PUSH";

    public long id;
    public string name;

    public GoAwayArmsPush() : base(NAME)
    {
    }

    public static GoAwayArmsPush Parse(MsgData data)
    {

        GoAwayArmsPush push = new GoAwayArmsPush();
        push.id = data.GetLong(0);
        push.name = data.GetString(1);
        return push;
    }
}
}