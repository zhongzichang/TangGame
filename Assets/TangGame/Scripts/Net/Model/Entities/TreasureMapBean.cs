/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/11
 * Time: 17:47
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace TangGame.Net
{
/// <summary>
/// 宝藏基础信息
/// </summary>
public class TreasureMapBean
{
    //宝藏id
    public int id;
    //宝藏的坐标
    public short x,y;
    //地图id
    public short mapid;
    public List<int[]> typeList;
    public Dictionary<short, List<AshramReward>> awardMap;
}
}
