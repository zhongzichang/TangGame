/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/10
 * Time: 23:08
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TangGame.Net
{
/// <summary>
/// Description of WorldBoss.
/// </summary>
public class WorldBoss
{
    /** 地图ID */
    private short mapId;
    /** BossID */
    private int bossId;
    /** 投放点 */
    private short[][] standPoint;
    /** 间隔时间 */
    private long intervalTime;
    /** Boss死亡时间 */
    private long bossDeadTime;
    /** Boss是否投放 */
    private bool isShow;
}
}
