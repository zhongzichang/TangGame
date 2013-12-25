using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
/// 仓库数据请求
public class GetStorageDataRequest : Request
{
    public NetData NetData
    {
        get
        {
            return new NetData(StorageProxy.S_STORAGE_DATA);
        }
    }
}
}
