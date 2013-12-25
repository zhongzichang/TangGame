using System;
using System.Text;
using PureMVC.Patterns;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class EnterGameRequest : Request
{
    private long heroId;
    public EnterGameRequest(long heroId)
    {
        this.heroId=heroId;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(LoginProxy.S_ENTER_GAME);
            Debug.Log("LoginProxy.EnterGame("+heroId+")");
            data.PutLong(heroId);
            return data;
        }
    }
}
}
