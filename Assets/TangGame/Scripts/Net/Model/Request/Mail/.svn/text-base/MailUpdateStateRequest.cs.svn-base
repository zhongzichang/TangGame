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

/// 邮件状态
public class MailUpdateStateRequest : Request
{

    private long id;//邮件ID
    private int type;//1:读取 2:删除
    private int mailType;//1:普通邮件 2:含有附件的邮件


    public MailUpdateStateRequest(long id, int type, int mailType)
    {
        this.id = id;
        this.type = type;
        this.mailType = mailType;
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(MailProxy.S_UPDATE_MAIL_STATE);
            data.PutLong(this.id);
            data.PutShort(this.type);
            data.PutShort(this.mailType);
            return data;
        }
    }
}
}
