using System;
using UnityEngine;
using PureMVC.Patterns;
using TangNet;

namespace TangGame.Net
{
public class PickUpGoodsRequest : Request
{
    private long goodsId;
    public PickUpGoodsRequest(long goodsId)
    {
        this.goodsId=goodsId;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(HeroProxy.UPDATE_SHORTCUT_KEY);

            data.PutLong(goodsId);
            return data;
        }
    }
}
}
