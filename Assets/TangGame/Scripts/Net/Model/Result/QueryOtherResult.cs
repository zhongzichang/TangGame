/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/22
 * Time: 15:05
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 查看别人掉落的物品
/// </summary>
public class QueryOtherResult : Response
{
    public const string NAME = "queryOther_RESULT";

    public short page;
    public int pageNum; // 最大页

    public List<RansomGoods> ransomGoodsList;

    public QueryOtherResult() : base(NAME)
    {
    }

    public static QueryOtherResult Parse(MsgData data)
    {

        QueryOtherResult result = new QueryOtherResult();

        int index =  0;
        result.page = data.GetShort(index++);
        result.pageNum = data.GetInt(index++);

        List<RansomGoods> ransomGoodsList = new List<RansomGoods>();
        MsgData listData = data.GetMsgData(index++);

        for(int i=0; i<listData.Size; i++)
        {

            RansomGoods ransomGoods = new RansomGoods();
            ransomGoods.heroGoods = HeroGoods.Parse(listData.GetMsgData(0));
            ransomGoods.endTime = (long) listData.GetDouble(1);
            ransomGoods.overdueTime = (long) listData.GetDouble(2);
            ransomGoods.coin = listData.GetInt(3);
            ransomGoodsList.Add(ransomGoods);

        }

        result.ransomGoodsList = ransomGoodsList;

        return result;

    }
}
}
