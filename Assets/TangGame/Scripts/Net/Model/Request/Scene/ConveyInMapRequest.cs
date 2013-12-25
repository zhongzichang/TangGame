/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/5/24
 * Time: 20:44
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;
using TangUtils;

namespace TangGame.Net
{
/// <summary>
/// 地图内传送
/// </summary>
public class ConveyInMapRequest : Request
{
    private Point end;

    public ConveyInMapRequest(Point end)
    {
        this.end = end;

    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(SceneProxy.S_CONVEY_MAP);
            data.PutShort(end.x);
            data.PutShort(end.y);
            return data;
        }
    }

}
}
