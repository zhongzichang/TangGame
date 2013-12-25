/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/5/24
 * Time: 21:04
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of ExitFBRequest.
/// </summary>
public class ExitFBRequest : Request
{
    public NetData NetData
    {
        get
        {
            return new NetData(SceneProxy.S_EXIT_FB);
        }
    }
}
}
