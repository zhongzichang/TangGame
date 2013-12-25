using System;
using UnityEngine;
using PureMVC.Patterns;
using TangNet;

namespace TangGame.Net
{
public class AutoHpRequest : Request
{
    private short autoHp;
    public AutoHpRequest(short autoHp)
    {
        this.autoHp=autoHp;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(HeroProxy.HERO_AUTOHP);

            data.PutShort(autoHp);
            return data;
        }
    }
}
}
