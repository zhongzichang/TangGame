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
/// 家族列表
public class ArmsListRequest : Request
{

    private int pageNum;

    public ArmsListRequest(int pageNum)
    {
        this.pageNum = pageNum;
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(ArmsProxy.S_ARMS_LIST);
            data.PutShort(pageNum);
            return data;
        }
    }
}
}
