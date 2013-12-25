using System;
using UnityEngine;
using PureMVC.Patterns;
using TangNet;

namespace TangGame.Net
{
public class ChangeHeroModelRequest : Request
{
    private int mode;
    public ChangeHeroModelRequest(int mode)
    {
        this.mode=mode;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(HeroProxy.HERO_CHANGE_MODEL);

            data.PutShort(mode);
            return data;
        }
    }
}
}
