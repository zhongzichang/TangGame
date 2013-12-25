using System;
using System.Text;
using PureMVC.Patterns;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class Reconnect2Request : Request
{
    private string username;
    private string password;
    public Reconnect2Request(string username,string password)
    {
        this.username=username;
        this.password=password;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(LoginProxy.S_RECONNECT_2);
            Debug.Log("LoginProxy.Reconnect2()");
            data.PutString(username);
            data.PutString(password);
            return data;
        }
    }
}
}
