using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of ShopMsgResult.
/// </summary>
public class BuyResult : Response
{
    public const string NAME = "buy_RESULT";

    public int multiple;
    public List<int> goodsIds = new List<int>();

    public int loaded;//负重
    public int coinType;//钱的类型
    public int coin;//钱的数量
    public List<HeroGoods> list = new List<HeroGoods>();

    public BuyResult() : base(NAME)
    {
    }

    public static BuyResult Parse(MsgData data)
    {
        BuyResult result = new BuyResult();
        int index = 0;

        result.loaded = data.GetShort(index++);
        result.coinType = data.GetShort(index++);
        result.coin = data.GetInt(index++);

        while(index < data.Size)
        {
            result.list.Add(HeroGoods.Parse(data.GetMsgData(index++)));
        }
        return result;
    }
}
}
