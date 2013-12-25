using System;
using UnityEngine;
using PureMVC.Patterns;
using TangNet;

namespace TangGame.Net
{
public class AutoMpRequest : Request
{
    private short autoMp;
    public AutoMpRequest(short autoMp)
    {
        this.autoMp=autoMp;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(HeroProxy.HERO_AUTOMP);

            data.PutShort(autoMp);
            return data;
        }
    }
}
}
