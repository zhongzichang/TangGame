using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
/// 强化装备
public class IntensifyGoodsRequest : Request
{
    private int site;
    private int index;
    private long id;
    private int goodsIndex;
    private long goodsId;
    private int pay;
    private int times;
    private int auto;
    public IntensifyGoodsRequest(int site,int index,long id,int goodsIndex,long goodsId,int pay,int times,int auto)
    {
        this.site=site;
        this.index=index;
        this.id=id;
        this.goodsIndex=goodsIndex;
        this.goodsId=goodsId;
        this.pay=pay;
        this.times=times;
        this.auto=auto;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(EnhanceProxy.SERVICE_STRENGTHEN_GOODS);
            data.PutShort(site);//装备是否在身上
            data.PutShort(index);//装备位置
            data.PutLong(id);//装备ID
            data.PutShort(goodsIndex);//强化道具位置
            data.PutLong(goodsId);//强化道具ID
            data.PutShort(pay);//是否直接付费 1 付费
            data.PutShort(times);//次数
            data.PutShort(auto);//是否自动升级
            Debug.Log(">> IntensifyGoods id=" + id);
            return data;
        }
    }
}
}
