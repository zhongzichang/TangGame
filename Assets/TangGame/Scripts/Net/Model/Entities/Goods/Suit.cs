/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/13
 * Time: 0:12
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace TangGame.Net
{
/// <summary>
/// Description of Suit.
/// </summary>
public class Suit
{
    /** 套装ID */
    public int id;
    /** 套装名称 */
    public string name;
    /** 套装明细(存放道具类型) */
    public HashSet<int> item;
    /** 套装属性(key:装备套装数量 value:引发的属性效果) */
    public Dictionary<int, List<Effect>> attribute;
}
}
