/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/11
 * Time: 16:46
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TangGame.Net
{
/// <summary>
/// 地图角色信息
/// </summary>
public class RoleMsg
{
    public int roleId;
    public bool isNPC;
    public short resId;
    public short currFrame;
    public short x, y;
    public int teamId;
    public bool isShowName;

}
}
