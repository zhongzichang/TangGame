/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/5/24
 * Time: 19:48
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 传送门传送
/// </summary>
public class DeliverDoorRequest : Request
{
    private short doorId = 0;
    public DeliverDoorRequest(short doorId)
    {
        this.doorId = doorId;
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(SceneProxy.S_MAP_DELIVER);
            data.PutShort(doorId);
            return data;
        }
    }
}
}
