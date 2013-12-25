using System;
using UnityEngine;
using TangNet;


namespace TangGame.Net
{
public class SendChatMsgRequest : Request
{
    private int channel;
    private string msg;
    private string secret;
    public SendChatMsgRequest(int channel,string msg,string secret)
    {
        this.channel=channel;
        this.msg=msg;
        this.secret=secret;
    }
    public NetData NetData
    {
        get
        {
            NetData data = new NetData(ChatProxy.S_CHAT_MSG);
            data.PutShort(channel);
            data.PutString(msg);
            if(!string.IsNullOrEmpty(secret))
            {
                data.PutString(secret);
            }
            Debug.Log(">> SendChatMsg msg=" + msg +"----channel"+channel);
            return data;
        }
    }
}
}
