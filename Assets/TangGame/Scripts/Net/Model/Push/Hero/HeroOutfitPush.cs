/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/14
 * Time: 15:12
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Hero换装信息
/// </summary>
public class HeroOutfitPush : Response
{
    public const string NAME = "heroOutfit_PUSH";

    public long heroId;
    public string effect;
    public int speed;
    public short type; // //1:武器 2:衣服 3:坐骑 4:杂

    public HeroOutfitPush() : base(NAME)
    {
    }
    public static HeroOutfitPush Parse(MsgData data)
    {

        HeroOutfitPush push = new HeroOutfitPush();
        int index = 0;
        push.heroId = (long) data.GetDouble(index++);
        push.effect = data.GetString(index++);
        push.speed = data.GetInt(index++);
        push.type = data.GetShort(index++);
        return push;

    }
}
}
