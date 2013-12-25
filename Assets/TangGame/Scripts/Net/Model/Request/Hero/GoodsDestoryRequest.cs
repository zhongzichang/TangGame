using System;
using UnityEngine;
using PureMVC.Patterns;
using TangNet;

namespace TangGame.Net
{
public class GoodsDestoryRequest : Request
{
    private short type;
    private long heroGoodsId;
    private short index;
    public GoodsDestoryRequest(short type,long heroGoodsId,short index)
    {
        this.type=type;
        this.heroGoodsId=heroGoodsId;
        this.index=index;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(HeroProxy.DESTROY_GOODS);

            data.PutShort(type);
            data.PutLong(heroGoodsId);
            data.PutShort(index);
            return data;
        }
    }
}
}
