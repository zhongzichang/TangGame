using System;
using UnityEngine;
using PureMVC.Patterns;
using TangNet;

namespace TangGame.Net
{
public class ExecuteScriptRequest : Request
{
    private string funcName;
    public ExecuteScriptRequest(string funcName)
    {
        this.funcName=funcName;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(HeroProxy.EXECUTE_SCRIPT);

            data.PutString(funcName);
            return data;
        }
    }
}
}
