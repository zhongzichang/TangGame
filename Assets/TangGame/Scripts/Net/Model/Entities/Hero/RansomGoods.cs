/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/22
 * Time: 3:22
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TangGame.Net
{
/// <summary>
/// Description of RansomGoods.
/// </summary>
public class RansomGoods
{
    /** 掉落玩家ID */
    public long flopHeroId;
    /** 拾取玩家ID */
    public long pickHeroId;
    /** 物品ID */
    public long heroGoodsId;
    /** 物品对象 */
    public HeroGoods heroGoods;
    /** 到期时间 */
    public long endTime;
    /** 领取过期时间 */
    public long overdueTime;
    /** 领取获得游戏币数量 */
    public int coin;
}
}
