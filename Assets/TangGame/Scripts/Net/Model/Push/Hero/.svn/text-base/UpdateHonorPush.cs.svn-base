/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 3:02
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 当前荣誉值/声望/杀戮
/// </summary>
public class UpdateHonorPush : Response
{
    public const string NAME = "updateHonor_PUSH";
    public short honor;
    public int prestige;
    public int slaughter;
    public UpdateHonorPush() : base(NAME)
    {
    }
    public static UpdateHonorPush Parse(MsgData data)
    {
        UpdateHonorPush push = new UpdateHonorPush();
        int index = 0;
        push.honor = data.GetShort(index++);
        push.prestige = data.GetInt(index++);
        push.slaughter = data.GetInt(index++);
        return push;
    }
}
}
