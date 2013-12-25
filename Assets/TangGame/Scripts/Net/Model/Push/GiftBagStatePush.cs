/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 10:58
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 发送礼包状态
/// </summary>
public class GiftBagStatePush : Response
{
    public const string NAME = "giftBagState_PUSH";

    public int giftBagId;
    public short state; // 0.可以领取 1.已经领取

    public GiftBagStatePush() : base(NAME)
    {
    }

    public static GiftBagStatePush Parse(MsgData data)
    {

        GiftBagStatePush push = new GiftBagStatePush();
        int index = 0;
        push.giftBagId = data.GetInt(index++);
        push.state = data.GetShort(index++);

        return push;

    }
}
}
