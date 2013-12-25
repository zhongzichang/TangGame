/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/5/24
 * Time: 19:10
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;
using TangUtils;

namespace TangGame.Net
{
/// <summary>
/// Description of HeroMoveRequest.
/// </summary>
public class HeroMoveRequest : Request
{
    private Point point;

    public HeroMoveRequest(Point point)
    {
        this.point = point;
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(SceneProxy.S_HERO_MOVE);
            data.PutShort((short)point.x);
            data.PutShort((short)point.y);
            return data;
        }
    }
}
}
