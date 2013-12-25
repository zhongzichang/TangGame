/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/7
 * Time: 16:23
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;
namespace TangGame.Net
{
/// <summary>
/// Description of Buff.
/// </summary>
public class Buff
{
    /** 类型 */
    public short type;
    /** 值 */
    public long val;
    /** true:buff false:debuff */
    public bool isPositive;
    /** 结束时间 */
    public long endTime;
    /** 间隔时间 */
    public int intervalTime;
    /** 触发时间 */
    public long triggerTime;
    /** 是否清除 */
    public bool isClear;

    public static Buff Parse(MsgData data)
    {
        Buff buff = new Buff();

        int index = 0;
        buff.type = data.GetShort(index++);
        buff.val = (long)data.GetDouble(index++);
        buff.endTime = (long)data.GetDouble(index++);

        return buff;
    }
}
}
