/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/22
 * Time: 2:30
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 查看可赎回物品
/// </summary>
public class QueryRansomResult : Response
{
    public const string NAME = "queryRansom_RESULT";

    public short page;
    public int pageNum; // 最大页

    public List<RansomGoods> ransomGoodsList;

    public QueryRansomResult() : base(NAME)
    {
    }

    public static QueryRansomResult Parse(MsgData data)
    {

        QueryRansomResult result = new QueryRansomResult();

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

            ransomGoodsList.Add(ransomGoods);

        }

        result.ransomGoodsList = ransomGoodsList;

        return result;

    }
}
}
