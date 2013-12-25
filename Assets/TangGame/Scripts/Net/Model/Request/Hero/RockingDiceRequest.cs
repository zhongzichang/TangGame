using System;
using UnityEngine;
using PureMVC.Patterns;
using TangNet;

namespace TangGame.Net
{
public class RockingDiceRequest : Request
{
    private long goodsId;
    private short isRocking;
    public RockingDiceRequest(long goodsId,short isRocking)
    {
        this.goodsId=goodsId;
        this.isRocking=isRocking;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(HeroProxy.ROCKING_DICE);


            data.PutLong(goodsId);
            data.PutShort(isRocking);

            return data;
        }
    }
}
}
