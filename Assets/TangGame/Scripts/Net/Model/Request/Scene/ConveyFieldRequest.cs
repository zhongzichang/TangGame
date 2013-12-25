/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/5/24
 * Time: 21:01
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of ConveyFieldRequest.
/// </summary>
public class ConveyFieldRequest : Request
{
    public NetData NetData
    {
        get
        {
            return new NetData(SceneProxy.S_CONVEY_FIELD);
        }
    }
}
}
