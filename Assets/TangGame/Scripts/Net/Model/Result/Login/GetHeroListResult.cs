/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/8
 * Time: 14:32
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of GetHeroListResult.
/// </summary>
public class GetHeroListResult : Response
{
    public const string NAME = "getHeroList_RESULT";

    public List<SimpleHero> heros = new List<SimpleHero>();
    public GetHeroListResult() : base(NAME)
    {
    }
    public static GetHeroListResult Parse(MsgData data)
    {

        GetHeroListResult result = new GetHeroListResult();
        for(int i=0; i<data.Size; i++)
        {

            MsgData heroData = data.GetMsgData(i);

            SimpleHero hero = new SimpleHero();
            hero.heroId = (long)heroData.GetDouble(0);
            hero.name = heroData.GetString(1);
            hero.sex = heroData.GetShort(2);
            hero.genre = heroData.GetShort(3);
            hero.headImg = heroData.GetShort(4);
            hero.level = heroData.GetShort(5);
            hero.index = heroData.GetShort(6);
            hero.exitTime = (long)heroData.GetDouble(7);
            // mapName = heroData.getString(8);
            hero.blokIdTime = (long)heroData.GetDouble(9);

            result.heros.Add(hero);
        }

        return result;
    }
}
}
