/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/5/24
 * Time: 21:26
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of SceneGoodsRequest.
/// </summary>
public class SceneGoodsRequest : Request
{
    public NetData NetData
    {
        get
        {

            return new NetData(SceneProxy.S_GET_FLOP_GOODS);
        }

    }
}
}
