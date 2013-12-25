/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/12
 * Time: 22:15
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;
namespace TangGame.Net
{
/// <summary>
/// Description of SimpleGoods.
/// </summary>
public class SimpleHeroGoods
{
    public long id;
    public short index;
    public short num;

    public static SimpleHeroGoods Parse(MsgData data)
    {

        int index = 0;
        SimpleHeroGoods goods = new SimpleHeroGoods();
        goods.id = (long)data.GetDouble(index++);
        goods.index = data.GetShort(index++);
        goods.num = data.GetShort(index++);
        return goods;

    }
}
}
