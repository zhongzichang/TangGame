using System;
using UnityEngine;
using PureMVC.Patterns;
using TangNet;

namespace TangGame.Net
{
public class ValidateHeroPointsRequest : Request
{
    private long heroId;
    private short x;
    private short y;
    private int hp;
    public ValidateHeroPointsRequest(long heroId,short x,short y,int hp)
    {
        this.heroId=heroId;
        this.x=x;
        this.y=y;
        this.hp=hp;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(HeroProxy.VALIDATE_HERO_POINTS);
            data.PutLong(heroId);
            data.PutShort(x);
            data.PutShort(y);
            data.PutInt(hp);
            return data;
        }
    }
}
}
