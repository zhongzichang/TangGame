/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/11
 * Time: 22:51
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 更新Hero属性
/// </summary>
public class UpdateHeroAttributePush : Response
{

    public const string NAME = "updateHeroAttribute_PUSH";

    public HeroNew hero;

    public UpdateHeroAttributePush() : base(NAME)
    {
    }

    public static UpdateHeroAttributePush Parse(MsgData data)
    {
        UpdateHeroAttributePush push = new UpdateHeroAttributePush();

        HeroNew hero = new HeroNew();
//        hero.heroBase = new HeroBase();
//        hero.bodyAttribute = new HeroTrendsAttribute();
//        hero.pack = new Pack();
//        hero.vip = new Vip();
//
//
//        int index = 0;
//        hero.level = data.GetShort(index++);
//        hero.exp = (long)(data.GetDouble(index++));
//        hero.heroBase.maxExp = (long)(data.GetDouble(index++));
//        hero.coin = data.GetInt(index++);
//
//
//        hero.heroBase.coin = data.GetInt(index++);
//        hero.heroBase.bindIngot = data.GetInt(index++);
//        hero.heroBase.attributePoint = data.GetShort(index++);
//        hero.heroBase.practice = data.GetShort(index++);
//        hero.heroBase.contribution = data.GetInt(index++);
//        hero.heroBase.slaughter = data.GetInt(index++);
//
//
//        hero.bodyAttribute.totalStrength = data.GetShort(index++);
//        hero.bodyAttribute.totalStamina = data.GetShort(index++);
//        hero.bodyAttribute.totalAgility = data.GetShort(index++);
//        hero.bodyAttribute.totalSavvy = data.GetShort(index++);
//        hero.heroBase.swordPoint = data.GetShort(index++);
//
//        hero.hp = data.GetInt(index++);
//        hero.maxHp = data.GetInt(index++);
//        hero.mp = data.GetInt(index++);
//        hero.maxMp = data.GetInt(index++);
//        hero.breath = data.GetInt(index++);
//        hero.maxBreath = data.GetInt(index++);
//
//        hero.minAttack = data.GetInt(index++);
//        hero.maxAttack = data.GetInt(index++);
//        hero.defence = data.GetInt(index++);
//
//        hero.pack.nowLoaded = data.GetShort(index++);
//        hero.maxLoaded = data.GetShort (index++);
//        hero.speed = data.GetInt(index++);
//
//        hero.dodge = data.GetInt(index++);
//        hero.absoluteDefense = data.GetInt(index++);
//        hero.crit = data.GetInt(index++);
//        hero.additionAttack = data.GetDouble(index++);
//        hero.heroBase.prestige = data.GetInt(index++);
//
//        hero.hit = data.GetInt(index++);
//        hero.addSkillHurt = data.GetDouble(index++);
//        hero.hpRegain = data.GetInt(index++);
//        hero.mpRegain = data.GetInt(index++);
//        hero.bodyAttribute.flopOdds = data.GetDouble(index++);
//        hero.addDritical = data.GetDouble(index++);
//        hero.heroBase.exploreCount = data.GetInt(index++);
//        hero.heroBase.strengthScore = (long)(data.GetDouble(index++));
        push.hero = hero;

        return push;
    }
    public static void Update(ref HeroNew hero, HeroNew updated)
    {

//        hero.level = updated.level;
//        hero.exp = updated.exp;
//        hero.heroBase.maxExp = updated.heroBase.maxExp;
//        hero.coin = updated.coin;
//
//        hero.heroBase.coin = updated.heroBase.coin;
//        hero.heroBase.bindIngot = updated.heroBase.bindIngot;
//        hero.heroBase.attributePoint = updated.heroBase.attributePoint;
//        hero.heroBase.practice = updated.heroBase.practice;
//        hero.heroBase.contribution = updated.heroBase.contribution;
//        hero.heroBase.slaughter = updated.heroBase.slaughter;
//
//        hero.bodyAttribute.totalStrength = updated.bodyAttribute.totalStrength;
//        hero.bodyAttribute.totalStamina = updated.bodyAttribute.totalStamina;
//        hero.bodyAttribute.totalAgility = updated.bodyAttribute.totalAgility;
//        hero.bodyAttribute.totalSavvy = updated.bodyAttribute.totalSavvy;
//        hero.heroBase.swordPoint = updated.heroBase.swordPoint;
//
//        hero.hp = updated.hp;
//        hero.maxHp = updated.maxHp;
//        hero.mp = updated.mp;
//        hero.maxMp = updated.maxMp;
//        hero.breath = updated.breath;
//        hero.maxBreath = updated.maxBreath;
//
//        hero.minAttack = updated.minAttack;
//        hero.maxAttack = updated.maxAttack;
//        hero.defence = updated.defence;
//
//        hero.pack.nowLoaded = updated.pack.nowLoaded;
//        hero.maxLoaded = updated.maxLoaded;
//        hero.speed = updated.speed;
//
//        hero.dodge = updated.dodge;
//        hero.absoluteDefense = updated.absoluteDefense;
//        hero.crit = updated.crit;
//        hero.additionAttack = updated.additionAttack;
//        hero.heroBase.prestige = updated.heroBase.prestige;
//
//        hero.hit = updated.hit;
//        hero.addSkillHurt = updated.addSkillHurt;
//        hero.hpRegain = updated.hpRegain;
//        hero.mpRegain = updated.mpRegain;
//        hero.bodyAttribute.flopOdds = updated.bodyAttribute.flopOdds;
//        hero.addDritical = updated.addDritical;
//        hero.heroBase.exploreCount = updated.heroBase.exploreCount;
//        hero.heroBase.strengthScore = updated.heroBase.strengthScore;
    }
}
}
