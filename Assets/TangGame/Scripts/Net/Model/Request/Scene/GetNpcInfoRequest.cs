/*
 * Created by SharpDevelop.
 * User: xbhuang
 * Date: 2013/11/13
 * Time: 21:24
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 请求获取一个NPC的详细信息
/// </summary>
public class GetNpcInfoRequest : Request
{
    private long id;

    public GetNpcInfoRequest(long id)
    {
        this.id = id;
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(SceneProxy.S_GET_NPC_BY_ID);
            data.PutLong(id);
            return data;
        }
    }
}
}
