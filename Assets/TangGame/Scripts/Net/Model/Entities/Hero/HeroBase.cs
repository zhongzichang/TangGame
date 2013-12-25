using System;
using System.Collections.Generic;

namespace TangGame.Net
{
public class HeroBase
{

    public const int SEX_MALE = 1;
    public const int SEX_FEMALE = 2;

    public long maxExp;
    public int coin;
    public int bindIngot;
    public short attributePoint;
    public short practice;
    public int contribution;
    public int slaughter;
    public short swordPoint; // skill points
    public int prestige;
    public int exploreCount;
    public long strengthScore;
    public short model; // 1=>normal, 2=>battle, 3=>travel, 4=>team, 5=>tong
    public short camp;
    public short sex;
    public short headIndex;
    public short genre;
    public short gameMapId;
    public long teamId;
    public long armsId;
    public int titleId;
    public short honor;
    public short autoHp;
    public short autoMp;
    public long banSpeakTime;

    public HeroBase ()
    {

    }
}
}

