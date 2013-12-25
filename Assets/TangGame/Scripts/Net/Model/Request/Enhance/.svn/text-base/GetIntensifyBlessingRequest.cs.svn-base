using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
/// 强化装备获取祝福值
public class GetIntensifyBlessingRequest : Request
{
    private int site;
    private int index;
    private long id;
    public GetIntensifyBlessingRequest(int site,int index,long id)
    {
        this.site=site;
        this.index=index;
        this.id=id;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(EnhanceProxy.ENHANCE_GET_GOODS_BLESSING);
            data.PutShort(site);//标示是否是背包，身上物品，1身上 2背包
            data.PutShort(index);
            data.PutLong(id);
            Debug.Log(">> GetIntensifyBlessing id=" + id);
            return data;
        }
    }
}
}
