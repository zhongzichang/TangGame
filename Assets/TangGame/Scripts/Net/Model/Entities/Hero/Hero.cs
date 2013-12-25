using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class Hero
{
    public long heroId;
    public string name;

    /** Hero基础对象 */
    public HeroBase heroBase = new HeroBase();
    // maxExp coin bindIngot  attributePoint practice contribution slaughter swordPoint prestige ExploreCount StrengthScore
    public HeroTrendsAttribute bodyAttribute;
    // totalStrength totalStamina agility savvy speed
    public Pack pack = new Pack();
    public Vip vip = new Vip();

    public short level;
    public long exp;
    public int coin;
    public int hp;
    public int maxHp;
    public int mp;
    public int maxMp;
    public int breath;
    public int maxBreath;
    public int minAttack;
    public int maxAttack;
    public int defence;
    public int maxLoaded;
    public int speed;
    public int dodge;
    public int absoluteDefense;
    public int crit;
    public double additionAttack;
    public int hit;
  public string useTimesMap;
    public double addSkillHurt;
    public int hpRegain; // HP regain
    public int mpRegain;
    public double addDritical;
    public List<Buff> buffs = new List<Buff>();
    public List<short> titles = new List<short>();
    public short x;
    public short y;
    public string shortcutkeys;
    public long vipEndTime;
    public short addOnlineLv;
    public int pired;
  public int isAdult;
  public short vipLevel;
  public short isYearVip;
    public string weaponEffect;
  public int featureAddOnline;
  public short featureGetOnline;
    public string mountEffect;
    public string dressEffect;
    public string miscellaneousEffect;


    // extends
    public string armsName;
    public short maxTimeBuff;
    public string titleName;
    public int titleId;
    public List<short> topTitles;
    public short relaxType;
    public string relaxName;

    public static Hero Parse(MsgData data)
    {

        // --- time data ---
        MsgData timeData = data.GetMsgData(0);

        long heroOnlineTime = (long)(timeData.GetDouble(0));
        long firstStartServerTime = (long)(timeData.GetDouble(1));
        long heroCreateTime = (long)(timeData.GetDouble(2));
	if( Config.debug )
	  {
	    Debug.Log( heroOnlineTime );
	    Debug.Log( firstStartServerTime );
	    Debug.Log( heroCreateTime );	    
	  }


        // -- hero data --
        Hero hero = new Hero();
        MsgData heroData = data.GetMsgData(1);
        hero.bodyAttribute = new HeroTrendsAttribute();
        int heroDataIndex = 0;

        hero.heroId = (long)(heroData.GetDouble(heroDataIndex++));
        hero.level = heroData.GetShort(heroDataIndex++);
        hero.name = heroData.GetString(heroDataIndex++);
        hero.heroBase.sex = heroData.GetShort(heroDataIndex++);
        hero.heroBase.genre = heroData.GetShort(heroDataIndex++);
        hero.heroBase.headIndex = heroData.GetShort(heroDataIndex++);
        hero.heroBase.model = heroData.GetShort(heroDataIndex++);
        hero.exp = (long)(heroData.GetDouble(heroDataIndex++));
        hero.coin = heroData.GetInt(heroDataIndex++);
        hero.heroBase.coin = heroData.GetInt(heroDataIndex++);
        hero.heroBase.bindIngot = heroData.GetInt(heroDataIndex++);
        hero.heroBase.attributePoint = heroData.GetShort(heroDataIndex++);
        hero.heroBase.practice = heroData.GetShort(heroDataIndex++);
        hero.heroBase.contribution = heroData.GetInt(heroDataIndex++);
        hero.heroBase.slaughter = heroData.GetInt(heroDataIndex++);
        hero.heroBase.gameMapId = heroData.GetShort(heroDataIndex++);
        hero.x = heroData.GetShort(heroDataIndex++);
        hero.y = heroData.GetShort(heroDataIndex++);
        hero.bodyAttribute.totalStrength = heroData.GetShort(heroDataIndex++);
        hero.bodyAttribute.totalStamina = heroData.GetShort(heroDataIndex++);
        hero.bodyAttribute.totalAgility = heroData.GetShort(heroDataIndex++);
        hero.bodyAttribute.totalSavvy = heroData.GetShort(heroDataIndex++);
        hero.heroBase.swordPoint = heroData.GetShort(heroDataIndex++);

        hero.hp = heroData.GetInt(heroDataIndex++);
        hero.maxHp = heroData.GetInt(heroDataIndex++);
        hero.mp = heroData.GetInt(heroDataIndex++);
        hero.maxMp = heroData.GetInt(heroDataIndex++);
        hero.breath = heroData.GetInt(heroDataIndex++);
        hero.maxBreath = heroData.GetInt(heroDataIndex++);

        hero.heroBase.maxExp = (long)(heroData.GetDouble(heroDataIndex++));
        hero.heroBase.camp = heroData.GetShort(heroDataIndex++);
        hero.minAttack = heroData.GetInt(heroDataIndex++);
        hero.maxAttack = heroData.GetInt(heroDataIndex++);
        hero.defence = heroData.GetInt(heroDataIndex++);

        hero.pack.nowLoaded = heroData.GetShort(heroDataIndex++);
        hero.maxLoaded = heroData.GetShort(heroDataIndex++);
        hero.shortcutkeys = heroData.GetString(heroDataIndex++);
        hero.heroBase.teamId = (long)(heroData.GetDouble(heroDataIndex++));
        hero.heroBase.armsId = (long)(heroData.GetDouble(heroDataIndex++));

        hero.vip.level = heroData.GetShort(heroDataIndex++);
        hero.vipEndTime = (long)(heroData.GetDouble(heroDataIndex++));
        hero.heroBase.titleId = heroData.GetInt(heroDataIndex++);
        hero.speed = heroData.GetInt(heroDataIndex++);

        hero.dodge = heroData.GetInt(heroDataIndex++);
        hero.absoluteDefense = heroData.GetInt(heroDataIndex++);
        hero.crit = heroData.GetInt(heroDataIndex++);
        hero.additionAttack = heroData.GetDouble(heroDataIndex++);
        hero.heroBase.honor = heroData.GetShort(heroDataIndex++);

        hero.weaponEffect = heroData.GetString(heroDataIndex++);

        hero.armsName = heroData.GetString(heroDataIndex++);
        hero.heroBase.prestige = heroData.GetInt(heroDataIndex++);
        hero.featureAddOnline = heroData.GetInt(heroDataIndex++);
        hero.featureGetOnline = heroData.GetShort(heroDataIndex++);
        hero.addOnlineLv = heroData.GetShort(heroDataIndex++);
        hero.mountEffect = heroData.GetString(heroDataIndex++);

        hero.dressEffect = heroData.GetString(heroDataIndex++);

        hero.heroBase.autoHp = heroData.GetShort(heroDataIndex++);
        hero.heroBase.autoMp = heroData.GetShort(heroDataIndex++);
        hero.useTimesMap = heroData.GetString(heroDataIndex++);
        hero.hit = heroData.GetInt(heroDataIndex++);
        hero.addSkillHurt = heroData.GetDouble(heroDataIndex++);
        hero.hpRegain = heroData.GetInt(heroDataIndex++);
        hero.mpRegain = heroData.GetInt(heroDataIndex++);
        hero.bodyAttribute.flopOdds = heroData.GetDouble(heroDataIndex++);
        hero.addDritical = heroData.GetDouble(heroDataIndex++);
        byte wishNumMapSize = heroData.GetByte(heroDataIndex++);
        for(byte i=0; i<wishNumMapSize; i++)
        {
            heroData.GetShort(heroDataIndex++);
            heroData.GetShort(heroDataIndex++);
        }

        // buff
        MsgData buffArrayData = heroData.GetMsgData(heroDataIndex++);
        if(buffArrayData.Size > 0)
        {
            hero.buffs.Clear();
            for(int i=0; i<buffArrayData.Size; i++)
            {

                MsgData buffData = buffArrayData.GetMsgData(i);
                Buff buff = new Buff();
                buff.type = buffData.GetShort(0);
                buff.val = (long)(buffData.GetDouble(1));
                buff.endTime = (long)(buffData.GetDouble(2)) + DateTime.Now.Millisecond;
                hero.buffs.Add(buff);
            }
        }

        hero.pired = heroData.GetInt(heroDataIndex++);
        hero.isAdult = heroData.GetInt(heroDataIndex++);
        hero.vipLevel = heroData.GetShort(heroDataIndex++);
        hero.isYearVip = heroData.GetShort(heroDataIndex++);
        hero.heroBase.exploreCount = heroData.GetInt(heroDataIndex++);
        hero.heroBase.banSpeakTime = (long)(heroData.GetDouble(heroDataIndex++));
        hero.heroBase.strengthScore = (long)(heroData.GetDouble(heroDataIndex++));

        hero.miscellaneousEffect = heroData.GetString(heroDataIndex++);

        if(heroData.Size > heroDataIndex)
        {
            // top-ten title
            MsgData titleArrayData = heroData.GetMsgData(heroDataIndex++);
            if(titleArrayData.Size > 0)
            {
                hero.titles.Clear();
                for(int i=0; i<titleArrayData.Size; i++)
                {
                    hero.titles.Add(titleArrayData.GetShort(i));
                }
            }
        }

        return hero;
    }


    public static Hero ParseSceneData(MsgData data)
    {
        Hero hero = new Hero();

        int index = 0;
        hero.heroId = (long) data.GetDouble(index++);
        hero.name = data.GetString(index++);
        hero.x = data.GetShort(index++);
        hero.y = data.GetShort(index++);
        hero.hp = data.GetInt(index++);
        hero.maxHp = data.GetInt(index++);

        hero.mountEffect = data.GetString(index++);
        hero.dressEffect = data.GetString(index++);
        hero.weaponEffect = data.GetString(index++);
        hero.heroBase.sex = data.GetShort(index++);
        hero.heroBase.genre = data.GetShort(index++);

        hero.relaxType = data.GetShort(index++);
        hero.relaxName = data.GetString(index++);

        hero.maxTimeBuff = data.GetShort(index++);
        hero.vip.level = data.GetShort(index++);
        hero.titleName = data.GetString(index++);
        hero.titleId = data.GetInt(index++);
        hero.heroBase.camp = data.GetShort(index++);
        hero.speed = data.GetInt(index++);
        hero.armsName = data.GetString(index++);
        hero.miscellaneousEffect = data.GetString(index++);

        // 十大
        MsgData topTitleData = data.GetMsgData(index++);
        if(topTitleData.Size > 0)
        {
            hero.topTitles = new List<short>();
            for(int i=0; i<topTitleData.Size; i++)
            {
                hero.topTitles.Add(topTitleData.GetShort(i));
            }
        }

        return hero;
    }

}
}

