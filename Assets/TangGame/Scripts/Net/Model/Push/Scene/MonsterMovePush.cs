/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/6
 * Time: 13:17
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Monster移动
/// </summary>
[Response(NAME)]
public class MonsterMovePush : Response
{
    public const string NAME = "monsterMove_PUSH";

    public long monsterId;
    public int x;
    public int y;

    public MonsterMovePush() : base(NAME)
    {
    }

    public static MonsterMovePush Parse(MsgData data)
    {

        MonsterMovePush push = new MonsterMovePush();

        int index = 0;

        push.monsterId = data.GetLong(index++);
        push.x = data.GetShort(index++);
        push.y = data.GetShort(index++);

        return push;

    }
}
}
