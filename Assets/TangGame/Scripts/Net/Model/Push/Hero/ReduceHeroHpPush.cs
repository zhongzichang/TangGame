/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/12
 * Time: 10:37
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of ReduceHeroHpPush.
/// </summary>
public class ReduceHeroHpPush : Response
{
    public const string NAME = "reduceHeroHP_PUSH";

    public long heroId;
    public int hp;
    public int val;

    public ReduceHeroHpPush() : base(NAME)
    {
    }
    public static ReduceHeroHpPush Parse(MsgData data)
    {
        ReduceHeroHpPush push = new ReduceHeroHpPush();

        int index = 0;
        push.heroId = (long)data.GetDouble(index++);
        push.hp  = data.GetInt(index++);
        push.val = data.GetInt(index++);

        return push;
    }
}
}
