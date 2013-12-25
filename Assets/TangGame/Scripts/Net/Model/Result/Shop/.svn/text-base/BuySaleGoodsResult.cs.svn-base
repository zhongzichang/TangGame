using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class BuySaleGoodsResult : Response
{
    public const string NAME = "buySaleGoods_RESULT";

    public int honor;

    public BuySaleGoodsResult() : base(NAME)
    {
    }

    public static BuySaleGoodsResult Parse(MsgData data)
    {
        BuySaleGoodsResult result = new BuySaleGoodsResult();
        result.honor = data.GetShort(0);
        return result;
    }
}
}
