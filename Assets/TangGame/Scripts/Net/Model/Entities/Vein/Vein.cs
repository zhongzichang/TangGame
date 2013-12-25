/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/11
 * Time: 18:15
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace TangGame.Net
{
/// <summary>
/// Description of Vein.
/// </summary>
public class Vein
{
    /** 经脉编号 */
    public short id;
    /** 经脉名 */
    public string name;
    /** 经脉类型 */
    public short type;
    /** 经脉等级 */
    public short level;
    /** 产出内息时间 */
    public long time;
    /** 耗费内息 */
    public int useBreath;
    /** 玩家等级限制 */
    public short heroLv;
    /** 内息产出 */
    public int outBreath;
    /** 下一级 */
    public short nextId;
    /** 经脉效果描述 */
    public string note;
    /** 筋脉效果 */
    public List<Effect> effectList;
}
}
