using System;
using UnityEngine;
using PureMVC.Patterns;
using TangNet;

namespace TangGame.Net
{
public class HeroOnlineRewardRequest : Request
{
    public NetData NetData
    {
        get
        {
            return new NetData(HeroProxy.HERO_ONLINE_REWARD);
        }
    }
}
}
