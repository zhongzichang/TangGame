/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/4/2
 * Time: 10:59
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UnityEngine;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of NpcProxy.
/// </summary>
public class NpcProxy
{
    /** 购买物品 */
    public const short S_BUY_GOODS = 0x0601;
    /** 出售物品 */
    public const short S_SELL_GOODS = 0x0602;
    /** NPC对话 */
    public const short S_TALK = 0x0907;
    /** 商店信息 */
    public const short S_SHOP_DATA = 0x0690;
    /** 验证怪位置 */
    public const short VALIDATE_ROLE_POINTS = 0x0691;
    /** 一骑当千活动中获得Buff专用 */
    public const short RANDOM_BUFF = 0x0692;


}
}
