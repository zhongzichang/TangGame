using System;
using UnityEngine;
using PureMVC.Patterns;
using TangNet;

namespace TangGame.Net
{
public class RansomGoodsRequest : Request
{
    private short type;
    private long heroGoodsId;
    public RansomGoodsRequest(short type,long heroGoodsId)
    {
        this.type=type;
        this.heroGoodsId=heroGoodsId;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(HeroProxy.HERO_RANSOM_GOODS);

            data.PutShort(type);
            data.PutLong(heroGoodsId);
            return data;
        }
    }
}
}
