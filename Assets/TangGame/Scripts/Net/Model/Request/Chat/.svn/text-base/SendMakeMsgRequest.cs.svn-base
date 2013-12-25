using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
public class SendMakeMsgRequest : Request
{
    private int channel;
    private string msg;
    public SendMakeMsgRequest(int channel,string msg)
    {
        this.channel=channel;
        this.msg=msg;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(ChatProxy.S_CHAT_MSG);
            data.PutShort(channel);
            data.PutString(msg);
            Debug.Log(">> SendMakeMsg msg=" + msg);
            return data;
        }
    }
}
}
