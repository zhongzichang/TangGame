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
/// 家族申请列表请求
public class ArmsApplyListRequest : Request
{

    private int page;

    public ArmsApplyListRequest(int page)
    {
        this.page = page;
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(ArmsProxy.S_APPLY_LIST);
            data.PutShort(page);
            return data;
        }
    }
}
}
