using System;
using UnityEngine;
using PureMVC.Patterns;
using TangNet;

namespace TangGame.Net
{
public class PulseHandlerRequest : Request
{
    public NetData NetData
    {
        get
        {
            return new NetData(HeroProxy.PULSE_HANDLE);
        }
    }
}
}
