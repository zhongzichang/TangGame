/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/10
 * Time: 23:23
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace TangGame.Net
{
/// <summary>
/// 历练副本基础对象
/// </summary>
public class Ashram
{
    /** 编号 */
    private int id;
    /** 名称 */
    private string name;
    /** 描述 */
    private string note;
    /** 地图编号 */
    private short mapId;
    /** 类型 */
    private short type;
    /** 使用次数限制次数 */
    private short useTimesType;
    /** 前置副本ID */
    private int limitId;
    /** 奖励集合 */
    private Dictionary<int, List<AshramReward>> rewardMap;
    /** 最大波数 */
    private short maxInning;
    /** 刷新怪物集合 */
    private List<AshramRole> roleList;
    /** 开启等级 */
    private short openLevel;
    /** 刷怪位置 */
    private short x;
    private short y;
    /** 展示物品集合 */
    private HashSet<int> goodsSet;
    /** 跳过后杀怪数量 */
    private int skipNum;
}
}
