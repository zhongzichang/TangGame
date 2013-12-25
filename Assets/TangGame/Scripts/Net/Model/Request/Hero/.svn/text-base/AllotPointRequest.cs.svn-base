using System;
using UnityEngine;
using PureMVC.Patterns;
using TangNet;

namespace TangGame.Net
{
public class AllotPointRequest : Request
{
    private short strength;
    private short stamina;
    private short agility;
    private short savvy;
    public AllotPointRequest(short strength,short stamina,short agility,short savvy)
    {
        this.strength=strength;
        this.stamina=stamina;
        this.agility=agility;
        this.savvy=savvy;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(HeroProxy.HERO_ALLOT_POINT);

            data.PutShort(strength);
            data.PutShort(stamina);
            data.PutShort(agility);
            data.PutShort(savvy);
            return data;
        }
    }
}
}
