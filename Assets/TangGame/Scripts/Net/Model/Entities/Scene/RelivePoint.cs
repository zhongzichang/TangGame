/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/11
 * Time: 16:36
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TangGame.Net
{
/// <summary>
/// Description of RelivePoint.
/// </summary>
public class RelivePoint
{
    /** 地图Id */
    private short mapId;
    /** 允许阵营(1:无阵营 2:拥唐 3:反唐) */
    private short acceptCamp;
    /** 复活点 */
    private short x, y;
}
}
