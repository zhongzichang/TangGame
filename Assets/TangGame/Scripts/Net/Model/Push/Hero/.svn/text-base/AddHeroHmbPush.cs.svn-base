/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/12
 * Time: 2:08
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of AddHeroHmbPush.
/// </summary>
public class AddHeroHmbPush : Response
{
    public const string NAME = "addHeroHMB_PUSH";

    public long heroId;
    public int hp;
    public int mp;
    public int breath;
    public int hpVal;
    public int mpVal;
    public int breathVal;
    public AddHeroHmbPush() : base(NAME)
    {
    }
    public static AddHeroHmbPush Parse(MsgData data)
    {
        AddHeroHmbPush push = new AddHeroHmbPush();

        int index = 0;
        push.heroId = (long)data.GetDouble(index++);
        push.hp  = data.GetInt(index++);
        push.mp = data.GetInt(index++);
        push.breath = data.GetInt(index++);
        push.hpVal = data.GetInt(index++);
        push.mpVal = data.GetInt(index++);
        push.breathVal = data.GetInt(index++);

        return push;
    }
}
}
