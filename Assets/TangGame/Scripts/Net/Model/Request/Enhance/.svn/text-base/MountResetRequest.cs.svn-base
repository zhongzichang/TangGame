using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
/// 坐骑混元
public class MountResetRequest : Request
{
    private int index;
    private long id;
    private int goodsIndex;
    private long goodsId;
    private int num;
    private List<int> property;
    public MountResetRequest(int index,long id,int goodsIndex,long goodsId,int num,List<int> property)
    {
        this.index=index;
        this.id=id;
        this.goodsIndex=goodsIndex;
        this.goodsId=goodsId;
        this.num=num;
        this.property=property;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(EnhanceProxy.ENHANCE_RESET_EFFECT);
            data.PutShort(index);
            data.PutLong(id);//坐骑的
            data.PutShort(goodsIndex);
            data.PutLong(goodsId);//辅助道具的
            data.PutShort(num);//保留属性的数量
            if(num > 0)
            {
                foreach(int i in property) //属性的类型
                {
                    data.PutShort(i);
                }
            }

            Debug.Log(">> HorseReset id=" + id);
            return data;
        }
    }
}
}
