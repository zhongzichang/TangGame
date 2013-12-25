/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/22
 * Time: 2:04
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 领取奖励
/// </summary>
public class HeroOnlineRewardResult : Response
{

    public const string NAME = "heroOnlineReward_RESULT";

    public short times; // level
    public string goodsName; // 领取不到，这个值为空 ""
    public long now;

    public HeroOnlineRewardResult() : base(NAME)
    {
    }


    public static HeroOnlineRewardResult Parse(MsgData data)
    {

        HeroOnlineRewardResult result = new HeroOnlineRewardResult();

        int index = 0;
        result.times = data.GetShort(index++);
        result.goodsName = data.GetString(index++);
        result.now = (long) data.GetDouble(index++);

        return result;

    }
}
}
