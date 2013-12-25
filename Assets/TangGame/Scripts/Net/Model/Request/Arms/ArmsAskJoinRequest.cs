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
/// 申请加入家族
public class ArmsAskJoinRequest : Request
{

    private long id;

    public ArmsAskJoinRequest(long id)
    {
        this.id = id;
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(ArmsProxy.S_ASK_JOIN);
            data.PutLong(id);
            return data;
        }
    }
}
}
