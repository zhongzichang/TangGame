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
/// 家族踢人推送
public class RejectMemberArmsPush : Response
{
    public const string NAME = "rejectMemberArms_PUSH";

    public long id;
    public string name;

    public RejectMemberArmsPush() : base(NAME)
    {
    }

    public static RejectMemberArmsPush Parse(MsgData data)
    {

        RejectMemberArmsPush push = new RejectMemberArmsPush();
        push.id = data.GetLong(0);
        push.name = data.GetString(1);
        return push;
    }
}
}