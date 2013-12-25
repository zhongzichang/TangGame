/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/11
 * Time: 16:58
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;


namespace TangGame.Net
{
/// <summary>
/// Description of Synthesis.
/// </summary>
public class Synthesis
{
    //合成id
    public int id ;
    //合成花费的铜币
    public int coin;
    //合成成功后的得到的物品对象
    public  int goodsId;
    //合成物品
    public Dictionary<int, short> useGoodsMap;
    //几率
    public short odds;
    public Goods goods;
}
}
