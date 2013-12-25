/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/22
 * Time: 10:57
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 赎回物品
/// </summary>
public class RansomGoodsResult : Response
{
    public const string NAME = "ransomGoods_RESULT";

    public long heroGoodsId;

    public RansomGoodsResult() : base(NAME)
    {
    }

    public static RansomGoodsResult Parse(MsgData data)
    {

        RansomGoodsResult result = new RansomGoodsResult();

        result.heroGoodsId = (long) data.GetDouble(0);

        return result;


    }
}
}
