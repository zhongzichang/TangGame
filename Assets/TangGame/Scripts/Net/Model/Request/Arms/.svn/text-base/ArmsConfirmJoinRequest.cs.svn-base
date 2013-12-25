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
/// 家族申请批准加入请求
public class ArmsConfirmJoinRequest : Request
{

    private long id;
    private int type;//同意为1,拒绝为2

    public ArmsConfirmJoinRequest(long id, int type)
    {
        this.id = id;
        this.type = type;
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(ArmsProxy.S_CONFIRM_JOIN);
            data.PutLong(id);
            data.PutShort(type);
            return data;
        }
    }
}
}
