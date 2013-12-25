using System;
using UnityEngine;
using PureMVC.Patterns;
using TangNet;

namespace TangGame.Net
{
public class ChangeBreathRequest : Request
{
    private int skillId;
    private short num;
    public ChangeBreathRequest(int skillId,short num)
    {
        this.skillId=skillId;
        this.num=num;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(HeroProxy.HERO_SKILL_CHANGE_BREATH);

            data.PutInt(skillId);
            data.PutShort(num);
            return data;
        }
    }
}
}
