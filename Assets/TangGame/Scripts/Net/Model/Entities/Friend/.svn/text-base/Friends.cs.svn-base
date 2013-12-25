using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
public class Friends
{
    /** 编号 */
    public long id;
    /** 关系类型(1好友、2仇人、3黑名单) */
    public short type;
    /** 玩家编号 */
    public long heroId;
    /** 玩家姓名 */
    public string heroName;
    /** 玩家等级 */
    public short heroLv;
    /** 玩家阵营 */
    public short heroCamp;
    /** 对方玩家编号 */
    public long oHeroId;
    /** 对方玩家姓名 */
    public string oHeroName;
    /** 对方玩家等级 */
    public short oheroLv;
    /** 对方玩家阵营 */
    public short oHeroCamp;
    /** 关系值(亲密度、仇恨值) */
    public int val;
    /** 建立关系时间 */
    public long createTime;
    /** 玩家1是否在线(1:在线;2:不在线) */
    public short heroOnLine;
    /** 玩家2是否在线(1:在线;2:不在线) */
    public short oHeroOnLine;

    public static Friends Parse(MsgData data)
    {
        Friends result = new Friends();
        int index = 0;
        result.type = data.GetShort(index++);// 关系类型
        result.id = data.GetLong(index++);// 关系编号
        result.heroId = data.GetLong(index++);// 玩家ID
        result.heroName = data.GetString(index++);// 玩家名称
        result.heroLv = data.GetShort(index++);// 玩家等级
        result.heroCamp = data.GetShort(index++);// 玩家阵营
        result.heroOnLine = data.GetShort(index++);// 在线状态
        result.val = data.GetInt(index++);// 关系度
        result.createTime = data.GetLong(index++);//时间
        return result;

    }


}
}
