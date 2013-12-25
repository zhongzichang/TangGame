/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/22
 * Time: 0:38
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 英雄的身上装备信息
/// </summary>
public class GetHeroBodyGoodsResult : Response
{

    public const string NAME = "getHeroBodyGoods_PUSH";

    public short type;
    public long heroId;
    public short genre;
    public short level;
    public string name;
    public short sex;

    public List<HeroGoods> heroGoodsList;

    public GetHeroBodyGoodsResult() : base(NAME)
    {
    }

    public static GetHeroBodyGoodsResult Parse(MsgData data)
    {
        GetHeroBodyGoodsResult result = new GetHeroBodyGoodsResult();

        int index = 0;
        result.type = data.GetShort(index++);
        result.heroId = (long)data.GetDouble(index++);
        result.genre = data.GetShort(index++);
        result.level = data.GetShort(index++);
        result.name = data.GetString(index++);
        result.sex = data.GetShort(index++);


        List<HeroGoods> heroGoodsList = new List<HeroGoods>();
        while(index < data.Size)
        {
            MsgData heroGoodsData = data.GetMsgData(index++);
            heroGoodsList.Add(HeroGoods.Parse(heroGoodsData));
        }

        result.heroGoodsList = heroGoodsList;

        return result;

    }
}
}
