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

public class MailRemoveRequest : Request
{

    private int type;//删除类型，1:普通邮件 2:附件邮件
    private List<long> idList = new List<long>();//邮件ID

    public MailRemoveRequest(int type, long id)
    {
        this.type = type;
        this.idList.Add(id);
    }

    public MailRemoveRequest(int type, List<long> idList)
    {
        this.type = type;
        this.idList = idList;
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(MailProxy.S_REMOVE_ALL_MAIL);
            data.PutShort(this.type);
            data.PutShort(this.idList.Count);
            for(int i = 0; i < idList.Count; i++)
            {
                data.PutLong(idList[i]);
            }
            return data;
        }
    }
}
}
