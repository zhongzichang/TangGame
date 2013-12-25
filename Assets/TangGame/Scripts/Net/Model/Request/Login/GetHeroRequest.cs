using System;
using System.Text;
using PureMVC.Patterns;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class GetHeroRequest : Request
{
    public NetData NetData
    {
        get
        {
            return new NetData(LoginProxy.S_GET_HERO);
        }
    }
}
}
