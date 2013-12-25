/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/10
 * Time: 23:19
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace TangGame.Net
{
/// <summary>
/// Description of Home.
/// </summary>
public class Home
{
    /** 家园编号 */
    private long id;
    /** 建筑列表字符串 */
    private string buildStr;
    /** 采集中的角色字符串 */
    private string collectStr;
    /** 建筑列表 */
    private Dictionary<short, HomeBuild> buildDictionary;
    /** 采集中的角色 */
    private Dictionary<long, Object[]> collectDictionary;

}
}
