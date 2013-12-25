/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/11
 * Time: 23:33
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of AddHeroHp.
/// </summary>
public class AddHeroHpPush : Response
{
    public const string NAME = "addHeroHP_PUSH";
    public long heroId;
    public int hp;
    public int val;
    public AddHeroHpPush() : base(NAME)
    {
    }
    public static AddHeroHpPush Parse(MsgData data)
    {

        AddHeroHpPush push = new AddHeroHpPush();

        int index = 0;
        push.heroId = (long)data.GetDouble(index++);
        push.hp  = data.GetInt(index++);
        push.val = data.GetInt(index++);

        return push;
    }

}
}
