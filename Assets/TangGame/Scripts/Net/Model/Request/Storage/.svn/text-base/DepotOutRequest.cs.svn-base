using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
/// 从仓库取出
public class DepotOutRequest : Request
{
    private int index;
    private long id;
    public DepotOutRequest(int index,long id)
    {
        this.index=index;
        this.id=id;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(StorageProxy.S_MOVE_TO_PACK);
            data.PutShort(index);
            data.PutLong(id);
            Debug.Log(">> DepotOut index=" + index);
            return data;
        }
    }
}
}
