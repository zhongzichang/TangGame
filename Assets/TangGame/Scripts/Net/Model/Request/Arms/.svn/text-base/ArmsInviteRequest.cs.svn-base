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
/// 家族邀请
public class ArmsInviteRequest : Request
{

    public string name;
    public ArmsInviteRequest(string name)
    {
        this.name = name;
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(ArmsProxy.S_INVITE_JOIN);
            data.PutString(name);
            return data;
        }
    }
}
}
