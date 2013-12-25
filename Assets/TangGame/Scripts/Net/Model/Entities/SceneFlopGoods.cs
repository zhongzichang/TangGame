/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 2:08
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of SceneFloGoods.
/// </summary>
public class SceneFlopGoods
{

    public long id;
    public string name;
    public string type;
    public short x;
    public short y;
    public short grade;

    public static SceneFlopGoods Parse(MsgData data)
    {

        SceneFlopGoods goods = new SceneFlopGoods();
        int index = 0;
        goods.id = (long)data.GetDouble(index++);
        goods.name = data.GetString(index++);
        goods.type = data.GetString(index++);
        goods.x = data.GetShort(index++);
        goods.y = data.GetShort(index++);
        goods.grade = data.GetShort(index++);

        return goods;
    }
}
}
