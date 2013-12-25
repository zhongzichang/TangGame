/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/25
 * Time: 14:43
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using TangNet;
namespace TangGame.Net
{
/// <summary>
/// Description of BattleMsg.
/// </summary>
public class BattleMsg
{
    public short targetType; // 1. hero , 2. monster , 3. npc , 4. pet
    public long targetId;
    public int hurt;
    public int hp;
    public int mp;
    public List<Buff> buffList;
    public bool isCrit;

    public static BattleMsg Parse(MsgData data)
    {

        BattleMsg msg = new BattleMsg();

        int index = 0;
        msg.targetType = data.GetShort(index++);
        msg.targetId = data.GetLong(index++);
        msg.hurt = data.GetInt(index++);
        msg.hp = data.GetInt(index++);
        msg.mp = data.GetInt(index++);

        // buffs

        MsgData buffsData = data.GetMsgData(index++);
        List<Buff> buffList = new List<Buff>();
        for(int i=0; i<buffsData.Size; i++)
        {
            buffList.Add(Buff.Parse(buffsData.GetMsgData(i)));
        }
        msg.buffList = buffList;

        msg.isCrit = data.GetBool(index++);
        return msg;

    }

    public override string ToString()
    {
        return string.Format("[BattleMsg TargetType={0}, TargetId={1}, Hurt={2}, Hp={3}, Mp={4}, BuffList={5}, IsCrit={6}]", targetType, targetId, hurt, hp, mp, buffList, isCrit);
    }



}
}
