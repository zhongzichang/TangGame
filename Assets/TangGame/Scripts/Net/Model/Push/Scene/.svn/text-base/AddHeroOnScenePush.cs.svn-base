/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/5/28
 * Time: 17:34
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of AddHeroOnScenePush.
/// </summary>
[Response(NAME)]
public class AddHeroOnScenePush : Response
{
    public const string NAME = "addHeroOnScene_PUSH";

    public HeroNew hero;

    public AddHeroOnScenePush() : base(NAME)
    {
    }

    public static AddHeroOnScenePush Parse(MsgData data)
    {

        AddHeroOnScenePush push = new AddHeroOnScenePush();

        //int index=0;
        HeroNew hero=HeroNew.ParseSceneData(data);
        
//        hero.id=data.GetLong(index++);
//        hero.name=data.GetString(index++);
//        hero.x=data.GetShort(index++);
//        hero.y=data.GetShort(index++);
//        hero.hp=data.GetInt(index++);
//        hero.hpMax=data.GetInt(index++);
//        hero.sex=data.GetShort(index++);
//        hero.genre=data.GetShort(index++);
//        Hero hero = new Hero();
//        int index = 0;
//        hero.heroId = (long) data.GetDouble(index++);
//        hero.name = data.GetString(index++);
//        hero.x = data.GetShort(index++);
//        hero.y = data.GetShort(index++);
//        hero.hp = data.GetInt(index++);
//        hero.maxHp = data.GetInt(index++);
//
//        hero.mountEffect = data.GetString(index++);
//        hero.dressEffect = data.GetString(index++);
//        hero.weaponEffect = data.GetString(index++);
//        hero.heroBase.sex = data.GetShort(index++);
//        hero.heroBase.genre = data.GetShort(index++);
//
//        hero.relaxType = data.GetShort(index++);
//        hero.relaxName = data.GetString(index++);
//
//        hero.maxTimeBuff = data.GetShort(index++);
//        hero.vip.level = data.GetShort(index++);
//        hero.titleName = data.GetString(index++);
//        hero.titleId = data.GetInt(index++);
//        hero.heroBase.camp = data.GetShort(index++);
//        hero.speed = data.GetInt(index++);
//        hero.armsName = data.GetString(index++);
//        hero.miscellaneousEffect = data.GetString(index++);

        // 十大
//        MsgData topTitleData = data.GetMsgData(index++);
//        if(topTitleData.Size > 0)
//        {
//            hero.topTitles = new List<short>();
//            for(int i=0; i<topTitleData.Size; i++)
//            {
//                hero.topTitles.Add(topTitleData.GetShort(i));
//            }
//        }


        push.hero = hero;

        return push;

    }
}
}
