using System;
using System.Text;
using PureMVC.Patterns;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class LoginRequest : Request
{
    private string username;
    private string password;
    public LoginRequest(string username,string password)
    {
        this.username=username;
        this.password=password;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(LoginProxy.S_INSIDE_LOGIN);
            data.PutString(username);
            data.PutString(password);
            return data;
        }
    }
}
}
