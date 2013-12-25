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

public class MailSendRequest : Request
{

    private string name;//接收人名称
    private string title;//标题
    private string content;//内容
    private int coin;//铜币
    private List<long> idList = new List<long>();//附件物品
    private List<int> indexList = new List<int>();//附件物品

    public MailSendRequest(string name, string title, string content, int coin, List<long> idList, List<int> indexList)
    {
        this.name = name;
        this.title = title;
        this.content = content;
        this.coin = coin;
        this.idList = idList;
        this.indexList = indexList;
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(MailProxy.S_SENDER_MAIL);
            data.PutString(name);
            data.PutString(title);
            data.PutString(content);
            data.PutInt(coin);
            data.PutShort(this.idList.Count);
            for(int i = 0; i < idList.Count; i++)
            {
                data.PutLong(idList[i]);//物品Guid
                data.PutShort(indexList[i]);//物品下标
            }
            return data;
        }
    }
}
}
