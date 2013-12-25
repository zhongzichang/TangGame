/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/11
 * Time: 1:00
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// 帮会申请列表对象
/// </summary>
public class Apply
{
    /** 玩家编号 */
    public long id;
    /** 玩家名称 */
    public string name;
    /** 玩家等级 */
    public short level;
    /** 玩家流派 */
    public short genre;
    /** 帮会编号 */
    public long armsId;
    /** 申请时间 */
    public long time;
    /** 是否同意 */
    public bool isAgree;

    public static Apply Parse(MsgData data)
    {
        Apply result = new Apply();
        int index = 0;
        result.id = data.GetLong(index++);
        result.name = data.GetString(index++);
        result.genre = data.GetShort(index++);
        result.level = data.GetShort(index++);
        return result;
    }
}
}
