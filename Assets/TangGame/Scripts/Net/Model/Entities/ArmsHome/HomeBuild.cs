/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/10
 * Time: 23:22
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TangGame.Net
{
  /// <summary>
  /// Description of HomeBuild.
  /// </summary>
  public class HomeBuild
  {
    /** 建筑编号 */
    private short id;
    /** 当前活跃 */
    private int exp;
    /** 今日获取活跃 */
    private int activeToday;
    /** 升级时间 */
    private long levelUpTime;
    /** 建筑基础对象 */
    private Build build;
  }
}
