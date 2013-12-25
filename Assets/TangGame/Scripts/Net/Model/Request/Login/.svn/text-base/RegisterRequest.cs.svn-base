using System;
using System.Text;
using PureMVC.Patterns;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class RegisterRequest : Request
{
    private string username;
    private string password;
    private string authorizedCode;
    public RegisterRequest(string username,string password,string authorizedCode)
    {
        this.username=username;
        this.password=password;
        this.authorizedCode=authorizedCode;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(LoginProxy.S_REGEDIT_USER);
            Debug.Log("LoginProxy.Register()");
            data.PutString(username);
            data.PutString(password);
            data.PutString(authorizedCode);
            return data;
        }
    }
}
}
