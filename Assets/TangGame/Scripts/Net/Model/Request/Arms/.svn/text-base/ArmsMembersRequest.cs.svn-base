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
/// 家族成员请求
public class ArmsMembersRequest : Request
{

    private int page = 1;// 页数
    private int online = 1;// 1,全部 2,在线

    public ArmsMembersRequest(int page, int online)
    {
        this.page = page;
        this.online = online;
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(ArmsProxy.S_MEMBER_LIST);
            data.PutShort(this.page);
            data.PutShort(this.online);
            return data;
        }
    }
}
}
