using System;
using TangNet;

namespace TangGame.Net
{
/// 穴位升级
public class AcupointUpRequest : Request
{
    private int type;
    private int id;
    private int index;
    private long goodsId;
    public AcupointUpRequest(int type,int id,int index,long goodsId)
    {
        this.type=type;
        this.id=id;
        this.index=index;
        this.goodsId=goodsId;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(VeinProxy.S_ACUPOINT_UPGRADE);
            data.PutShort(type);//所在经脉类型
            data.PutShort(id);//穴位ID
            data.PutShort(index);//物品index
            data.PutLong(goodsId);//物品唯一ID
            return data;
        }
    }
}
}
