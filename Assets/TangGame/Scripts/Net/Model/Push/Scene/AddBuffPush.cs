/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/5/29
 * Time: 15:11
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of AddBuffPush.
/// </summary>

[Response("addBuff_PUSH")]
public class AddBuffPush : Response
{

    public const string NAME = "addBuff_PUSH";

    public short type;
    public long val;

    public AddBuffPush() : base(NAME)
    {
    }

    public static AddBuffPush Parse(MsgData data)
    {
        AddBuffPush push = new AddBuffPush();

        push.type = data.GetShort(0);
        push.val = (long) data.GetDouble(1);

        return push;
    }
}
}
