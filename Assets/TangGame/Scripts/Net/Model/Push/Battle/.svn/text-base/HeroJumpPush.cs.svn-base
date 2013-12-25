/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/25
 * Time: 18:55
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 英雄跳跃
/// </summary>
public class HeroJumpPush : Response
{

    public const string NAME = "heroJump_PUSH";

    public long heroId;
    public short x;
    public short y;
    public int moveSpeed;
    public int mp;

    public HeroJumpPush() : base(NAME)
    {
    }

    public static HeroJumpPush Parse(MsgData data)
    {

        HeroJumpPush push = new HeroJumpPush();

        int index = 0;
        push.heroId = (long) data.GetDouble(index++);
        push.x = data.GetShort(index++);
        push.y = data.GetShort(index++);
        push.moveSpeed = data.GetInt(index++);
        push.mp = data.GetInt(index++);

        return push;
    }
}
}
