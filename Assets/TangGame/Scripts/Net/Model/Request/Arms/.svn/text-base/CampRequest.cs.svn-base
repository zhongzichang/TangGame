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
/// 阵营选择，调试阶段使用
public class CampRequest : Request
{

    private int camp;

    public CampRequest(int camp)
    {
        this.camp = camp;
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(0x1301);
            data.PutShort(camp);
            return data;
        }
    }
}
}
