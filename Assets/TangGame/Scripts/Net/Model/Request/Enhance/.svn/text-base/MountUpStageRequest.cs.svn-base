using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
/// 坐骑提升段位
public class MountUpStageRequest : Request
{
    private int index;
    private long id;
    private int goodsIndex;
    private long goodsId;
    public MountUpStageRequest(int index,long id,int goodsIndex,long goodsId)
    {
        this.index=index;
        this.id=id;
        this.goodsIndex=goodsIndex;
        this.goodsId=goodsId;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(EnhanceProxy.ENHANCE_UP_STAGE);
            data.PutShort(index);
            data.PutLong(id);//坐骑的
            data.PutShort(goodsIndex);
            data.PutLong(goodsId);//辅助道具的
            Debug.Log(">> HorseUpStage id=" + id);
            return data;
        }
    }
}
}
