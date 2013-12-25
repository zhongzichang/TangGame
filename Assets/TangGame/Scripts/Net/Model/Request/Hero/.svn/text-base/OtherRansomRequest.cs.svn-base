using System;
using UnityEngine;
using PureMVC.Patterns;
using TangNet;

namespace TangGame.Net
{
public class OtherRansomRequest : Request
{
    private long heroGoodsId;
    public OtherRansomRequest(long heroGoodsId)
    {
        this.heroGoodsId=heroGoodsId;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(HeroProxy.HERO_OTHER_RANSOM_GOODS);


            data.PutLong(heroGoodsId);

            return data;
        }
    }
}
}
