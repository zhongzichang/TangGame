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
/// 家族踢人请求
public class ArmsKickRequest : Request
{

    public long id;

    public ArmsKickRequest(long id)
    {
        this.id = id;
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(ArmsProxy.S_DEL_MEMBER);
            data.PutLong(id);
            return data;
        }
    }
}
}
