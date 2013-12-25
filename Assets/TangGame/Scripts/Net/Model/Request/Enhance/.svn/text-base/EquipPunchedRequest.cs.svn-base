/*
 * Created by SharpDevelop.
 * User: Cucumber
 * Date:
 * Time:
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
/// 装备打孔
public class EquipPunchedRequest : Request
{

    private int site;//装备是否在身上
    private int index;//装备位置
    private long id;//装备ID
    private int goodsIndex;//金刚石位置
    private long goodsId;//金刚石ID

    public EquipPunchedRequest(int site,int index,long id,int goodsIndex,long goodsId)
    {
        this.site=site;
        this.index=index;
        this.id=id;
        this.goodsIndex=goodsIndex;
        this.goodsId=goodsId;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(EnhanceProxy.SERVICE_GOODS_PUNCHED);
            data.PutShort(site);//装备是否在身上
            data.PutShort(index);//装备位置
            data.PutLong(id);//装备ID
            data.PutShort(goodsIndex);//强化道具位置
            data.PutLong(goodsId);//强化道具ID
            return data;
        }
    }
}
}
