/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/22
 * Time: 1:36
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 时间道具销毁
/// </summary>
public class GoodsDestoryResult : Response
{
    public const string NAME = "goodsDestory_PUSH";

    public long now;

    public GoodsDestoryResult() : base(NAME)
    {
    }

    public static GoodsDestoryResult Parse(MsgData data)
    {

        GoodsDestoryResult result = new GoodsDestoryResult();

        result.now = (long)data.GetDouble(0);


        return result;

    }
}
}
