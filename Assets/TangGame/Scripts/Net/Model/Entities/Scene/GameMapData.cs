/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/11
 * Time: 16:28
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace TangGame.Net
{
/// <summary>
/// Description of GameMapData.
/// </summary>
public class GameMapData
{
    /** 地图Id */
    public short mapId;
    /** 地图名称 */
    public string mapName;
    /** 是否是FB(true:FB) */
    public bool isFB;
    /** 地图数据 */
    public byte[][] mapData;
    /** Role容器 */
    public List<RoleMsg> roleMsgList;
    /** 地图传送点 */
    public List<MapDoor> doorList;
    /** 复活点列表 */
    public List<RelivePoint> relivePointList;
    /** 安全区 */
    public int[][] safety;
    /** 等级限制 */
    public int levelLimit;
}
}
