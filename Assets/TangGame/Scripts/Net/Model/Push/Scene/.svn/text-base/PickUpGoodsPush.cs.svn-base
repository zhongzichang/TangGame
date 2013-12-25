/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/21
 * Time: 17:34
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of PickUpGoodsPush.
/// </summary>
public class PickUpGoodsPush : Response
{

    public const string NAME = "pickUpGoods_PUSH";

    public short type;
    public long goodsId;

    public PickUpGoodsPush() : base(NAME)
    {
    }

    public static PickUpGoodsPush Parse(MsgData data)
    {

        PickUpGoodsPush push = new PickUpGoodsPush();

        int index = 0;
        push.type = data.GetShort(index++);
        push.goodsId = (long) data.GetDouble(index++);

        return push;
    }
}
}
