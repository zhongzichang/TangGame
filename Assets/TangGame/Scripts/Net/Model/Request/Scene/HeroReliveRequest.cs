/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/5/24
 * Time: 19:52
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of HeroReliveRequest.
/// </summary>
public class HeroReliveRequest : Request
{
    private short type = 0;

    /// <summary>
    /// 英雄复活
    /// </summary>
    /// <param name="type">1.原地复活 2,复活点复活 3.道具复活</param>
    public HeroReliveRequest(short type)
    {
        this.type = type;
    }

    public NetData NetData
    {
        get
        {
            NetData data = new NetData(SceneProxy.S_HERO_RELIVE);
            data.PutShort(type);
            return data;
        }
    }
}
}
