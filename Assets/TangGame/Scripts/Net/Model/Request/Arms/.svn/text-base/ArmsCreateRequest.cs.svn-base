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
/// 家族创建
public class ArmsCreateRequest : Request
{

    private string name;

    public ArmsCreateRequest(string name)
    {
        this.name = name;
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(ArmsProxy.S_ARMS_CREATE);
            data.PutString(name);
            return data;
        }
    }
}
}
