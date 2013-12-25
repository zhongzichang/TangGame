/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/5/29
 * Time: 15:16
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of ShowHeroBuffPush.
/// </summary>
public class ShowHeroBuffPush : Response
{

    public const string NAME = "showHeroBuff_PUSH";


    public long heroId;
    public short type;

    public ShowHeroBuffPush() : base(NAME)
    {
    }

    public static ShowHeroBuffPush Parse(MsgData data)
    {
        ShowHeroBuffPush push = new ShowHeroBuffPush();

        push.heroId = (long) data.GetDouble(0);
        push.type = data.GetShort(1);

        return push;
    }
}
}

