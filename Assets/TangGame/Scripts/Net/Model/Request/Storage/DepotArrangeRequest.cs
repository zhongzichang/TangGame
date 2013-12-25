using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
///仓库整理
public class DepotArrangeRequest : Request
{
    public NetData NetData
    {
        get
        {
            return new NetData(StorageProxy.S_CLEAR_UP);
        }
    }
}
}
