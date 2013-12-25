/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/12
 * Time: 2:00
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of AddHeroHmPush.
/// </summary>
public class AddHeroHmPush : Response
{
    public const string NAME = "addHeroHM_PUSH";

    public long heroId;
    public int hp;
    public int mp;
    public int hpVal;
    public int mpVal;
    public AddHeroHmPush() : base(NAME)
    {
    }
    public static AddHeroHmPush Parse(MsgData data)
    {
        AddHeroHmPush push = new AddHeroHmPush();

        int index = 0;
        push.heroId = (long) data.GetDouble(index++);
        push.hp  = data.GetInt(index++);
        push.mp = data.GetInt(index++);
        push.hpVal = data.GetInt(index++);
        push.mpVal = data.GetInt(index++);

        return push;
    }
}
}
