/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/11
 * Time: 1:03
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;
namespace TangGame.Net
{
/// <summary>
/// Description of ArmsMember.
/// </summary>
public class ArmsMember
{
    /** 成员ID */
    public long id;
    /** 成员名字 */
    public string name;
    /** 玩家等级 */
    public short level;
    /** 流派(1，无限制 2，凌烟阁 3，信陵客 4，清静楼) */
    public short genre;
    /** 职位 */
    public short officer;
    /** 帮会ID */
    public long armsId;
    /** 是否在线 */
    public bool isOnline;

    public static ArmsMember Parse(MsgData data)
    {
        ArmsMember member = new ArmsMember();
        int index = 0;
        member.id = data.GetLong(index++);
        member.name = data.GetString(index++);
        member.level = data.GetShort(index++);
        member.genre = data.GetShort(index++);
        member.officer = data.GetShort(index++);
        member.isOnline = data.GetShort(index++) == 1;
        return member;
    }
}
}
