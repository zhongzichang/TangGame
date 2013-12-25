/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/15
 * Time: 1:44
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;
namespace TangGame.Net
{
/// <summary>
/// 场景中的宠物
/// </summary>
public class ScenePet
{

    public long heroId;
    public long id;
    public short x;
    public short y;
    public int hp;
    public int maxHp;
    public short mould;
    public short speed;
    public short type; // 1. 宠物 2.镖车
    public short camp;
    public short startLevel;

    public static ScenePet Parse(MsgData data)
    {

        ScenePet pet = new ScenePet();
        int index = 0;
        pet.heroId = (long)data.GetDouble(index++);
        pet.id = (long)data.GetDouble(index++);
        pet.x = data.GetShort(index++);
        pet.y = data.GetShort(index++);
        pet.hp = data.GetInt(index++);
        pet.maxHp = data.GetInt(index++);
        pet.mould = data.GetShort(index++);
        pet.speed = data.GetShort(index++);
        pet.camp = data.GetShort(index++);
        pet.startLevel = data.GetShort(index++);

        return pet;

    }
}
}
