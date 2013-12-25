using System;
using UnityEngine;
using PureMVC.Patterns;
using TangNet;

namespace TangGame.Net
{
public class GetHeroBodyGoodsRequest : Request
{
    private short type;
    private long heroId;
    public GetHeroBodyGoodsRequest(short type,long heroId)
    {
        this.type=type;
        this.heroId=heroId;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(HeroProxy.OTHER_HERO_BODY);

            data.PutShort(type);
            data.PutLong(heroId);
            return data;
        }
    }
}
}
