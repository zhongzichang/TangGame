/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/12
 * Time: 1:55
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of AddHeroMpPush.
/// </summary>
public class AddHeroMpPush : Response
{
    public const string NAME = "addHeroMP_PUSH";
    public int mp;
    public int val;
    public AddHeroMpPush() : base(NAME)
    {
    }
    public static AddHeroMpPush Parse(MsgData data)
    {

        AddHeroMpPush push = new AddHeroMpPush();

        int index = 0;
        push.mp  = data.GetInt(index++);
        push.val = data.GetInt(index++);

        return push;
    }
}
}
