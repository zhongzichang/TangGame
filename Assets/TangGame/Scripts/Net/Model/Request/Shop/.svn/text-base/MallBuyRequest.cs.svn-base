using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
/// 商城购买
public class MallBuyRequest : Request
{
    private int type;
    private int id;
    private int num;
    public MallBuyRequest(int type,int id,int num)
    {
        this.type=type;
        this.id=id;
        this.num=num;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(ShopProxy.BUY_SALEGOODS);
            data.PutShort(type);
            data.PutInt(id);
            data.PutShort(num);
            return data;
        }
    }
}
}
