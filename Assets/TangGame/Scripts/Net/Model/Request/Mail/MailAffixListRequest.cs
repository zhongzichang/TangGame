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
/// 获取附件
public class MailAffixListRequest : Request
{

    private int pageNum;

    public MailAffixListRequest(int pageNum)
    {
        this.pageNum = pageNum;
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(MailProxy.S_GET_AFFIX_MAIL);
            data.PutShort(pageNum);
            return data;
        }
    }
}
}
