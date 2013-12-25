/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/21
 * Time: 17:29
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of RemoveGoodsFromScenePush.
/// </summary>
public class RemoveGoodsFromScenePush : Response
{
    public const string NAME = "removeGoodsFromScene_PUSH";

    public long goodsId;

    public RemoveGoodsFromScenePush() : base(NAME)
    {
    }

    public static RemoveGoodsFromScenePush Parse(MsgData data)
    {

        RemoveGoodsFromScenePush push = new RemoveGoodsFromScenePush();

        push.goodsId = (long) data.GetDouble(0);

        return push;
    }

}
}
