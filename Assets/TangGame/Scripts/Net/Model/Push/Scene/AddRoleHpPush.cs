/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/12
 * Time: 10:43
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of AddRoleHP.
/// </summary>
public class AddRoleHpPush : Response
{
    public const string NAME = "addRoleHP_PUSH";

    public long roleId;
    public int hp;
    public int val;

    public AddRoleHpPush() : base(NAME)
    {
    }

    public static AddRoleHpPush Parse(MsgData data)
    {

        AddRoleHpPush push = new AddRoleHpPush();

        int index = 0;
        push.roleId = (long)data.GetDouble(index++);
        push.hp  = data.GetInt(index++);
        push.val = data.GetInt(index++);

        return push;

    }
}
}
