/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/19
 * Time: 17:19
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of RemoveBuffPush.
/// </summary>
public class RemoveBuffPush : Response
{

    public const string NAME = "removeBuff_PUSH";

    public short type;

    public RemoveBuffPush() : base(NAME)
    {
    }

    public static RemoveBuffPush Parse(MsgData data)
    {
        RemoveBuffPush push = new RemoveBuffPush();
        push.type = data.GetShort(0);
        return push;


    }
}
}
