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
/// 家族邀请成员推送
public class InviteJoinArmsPush : Response
{
    public const string NAME = "inviteJoinArms_PUSH";

    public long id;
    public string name;
    public long armsId;
    public string armsName;

    public InviteJoinArmsPush() : base(NAME)
    {
    }

    public static InviteJoinArmsPush Parse(MsgData data)
    {
        InviteJoinArmsPush push = new InviteJoinArmsPush();
        if(data.Size > 1)
        {
            push.id = data.GetLong(0);
            push.name = data.GetString(1);
            push.armsId = data.GetLong(2);
            push.armsName = data.GetString(3);
        }
        else
        {
            push.name = data.GetString(0);
        }
        return push;
    }
}
}