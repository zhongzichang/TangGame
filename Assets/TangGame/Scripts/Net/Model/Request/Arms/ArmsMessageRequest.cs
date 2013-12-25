using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class ArmsMessageRequest : Request
{
    public NetData NetData
    {
        get
        {
            return new NetData(ArmsProxy.S_ARMS_MESSAGE);
        }
    }
}
}
