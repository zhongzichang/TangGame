/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/5/24
 * Time: 21:07
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of FlyGameMapRequest.
/// </summary>
public class FlyGameMapRequest : Request
{
    private short mapId = 0;

    public FlyGameMapRequest(short mapId)
    {
        this.mapId = mapId;
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(SceneProxy.S_FLY_MAP);
            data.PutShort(mapId);
            return data;
        }
    }
}
}
