/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/12
 * Time: 10:46
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Role减少HP
/// </summary>
public class ReduceRoleHpPush : Response
{
    public const string NAME = "reduceRoleHP_PUSH";

    public long roleId;
    public int hp;
    public int val;

    public ReduceRoleHpPush() : base(NAME)
    {
    }
    public static ReduceRoleHpPush Parse(MsgData data)
    {
        ReduceRoleHpPush push = new ReduceRoleHpPush();

        int index = 0;
        push.roleId = (long)data.GetDouble(index++);
        push.hp  = data.GetInt(index++);
        push.val = data.GetInt(index++);

        return push;
    }
}
}
