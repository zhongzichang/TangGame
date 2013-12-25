/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 10:52
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 探索随机移动
/// </summary>
public class RandomMoveInExplorePush : Response
{

    public const string NAME = "randomMoveInExplore_PUSH";

    public short oldx;
    public short oldy;

    public RandomMoveInExplorePush() : base(NAME)
    {
    }

    public static RandomMoveInExplorePush Parse(MsgData data)
    {
        RandomMoveInExplorePush push = new RandomMoveInExplorePush();

        int index = 0;
        push.oldx = data.GetShort(index++);
        push.oldy = data.GetShort(index++);

        return push;

    }
}
}
