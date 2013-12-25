using System;
using UnityEngine;
using PureMVC.Patterns;
using TangNet;

namespace TangGame.Net
{
public class ChangeHeroNameRequest : Request
{
    private string name;
    public ChangeHeroNameRequest(string name)
    {
        this.name=name;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(HeroProxy.CHANGE_HERO_NAME);


            data.PutString(name);

            return data;
        }
    }
}
}
