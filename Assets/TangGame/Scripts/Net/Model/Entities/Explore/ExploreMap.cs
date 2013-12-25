/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/11
 * Time: 12:11
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TangGame.Net
{
/// <summary>
/// 探索地图数据
/// </summary>
public class ExploreMap
{
    /** 前置地图ID(没有填 -1) */
    public int firstId;
    /** 下一地图Id */
    public int nextId;
    /** 地图ID */
    public int id;
    /** 地图宽 */
    public short wide;
    /** 地图高 */
    public short high;
    /** 开始位置 */
    public short startX, startY;
    /** 地图数据 */
    public string[][] data;
}
}
