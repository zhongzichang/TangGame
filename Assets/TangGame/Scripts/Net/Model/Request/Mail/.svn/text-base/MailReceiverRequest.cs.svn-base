/*
 * Created by SharpDevelop.
 * User: Cucumber
 * Date:
 * Time:
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{

/// 邮件领取附件
public class MailReceiverRequest : Request
{

    private long id;//邮件ID

    public MailReceiverRequest(long id)
    {
        this.id = id;
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(MailProxy.S_RECEIVER_AFFIX);
            data.PutLong(this.id);
            return data;
        }
    }
}
}
