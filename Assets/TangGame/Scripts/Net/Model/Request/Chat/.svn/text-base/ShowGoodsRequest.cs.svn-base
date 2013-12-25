using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
//展示物品
public class ShowGoodsRequest : Request
{
    private long playerId;
    private long goodsId;
    public ShowGoodsRequest(long playerId,long goodsId)
    {
        this.playerId=playerId;
        this.goodsId=goodsId;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(ChatProxy.S_SHOW_GOODS);
            data.PutLong(playerId);
            data.PutLong(goodsId);
            return data;
        }
    }
}
}
