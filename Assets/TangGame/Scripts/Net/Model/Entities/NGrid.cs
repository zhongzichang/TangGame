/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/6
 * Time: 21:20
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace TangGame.Net
{
/// <summary>
/// Description of NGrid.
/// </summary>
public class NGrid
{
    /** 网格坐标 */
    public int gX, gY;
    /** Hero容器 */
    public Dictionary<long, HeroNew> heroMap = new Dictionary<long, HeroNew>();
    /** Monster容器 */
    public Dictionary<long, Role> monsterMap = new Dictionary<long, Role>();
    /** NPC容器 */
    public Dictionary<long, Role> npcMap = new Dictionary<long, Role>();
    /** 掉落物品容器 */
    public Dictionary<long, FlopGoods> goodsMap = new Dictionary<long, FlopGoods>();
    /** 宠物容器(key:heroId value:宠物对象) */
    public Dictionary<long, Pet> petMap = new Dictionary<long, Pet>();

    public NGrid()
    {
    }
}
}
