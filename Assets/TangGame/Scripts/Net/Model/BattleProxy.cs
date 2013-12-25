/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/3/25
 * Time: 12:05
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of BattleProxy.
/// </summary>
public class BattleProxy
{

    /** 准备攻击 */
    public const short S_READY_ATTACK = 0x1102;	
    /** 对目标发起攻击 */
    public const short S_ATTACK_TARGET = 0x1101;
    /** 跳跃 */
    public const short S_JUMP = 0x1103;
    /// <summary>
    /// 冲刺
    /// </summary>
    public const short S_SPRINT=0x1104;


//		/// <summary>
//		/// 对目标发起攻击
//		/// </summary>
//		/// <param name="skillSort">技能种类</param>
//		/// <param name="targetId">目标编号</param>
//		/// <param name="direction">方向(Down:1 LeftDown:2 Left:3 LeftUp:4 Up:5 RightUp:6 Right:7 RightDown:8)</param>
//		public static void ReadyAttack(short skillSort, long targetId, short direction){
//
//			NetData data = new NetData(S_READY_ATTACK);
//
//			data.PutShort(skillSort);
//			data.PutLong(targetId);
//			data.PutShort(direction);
//
//			Common.gameClient.SendMessage(data);
//
//		}
//
//		/// <summary>
//		/// 攻击
//		/// </summary>
//		/// <param name="skillSort">技能</param>
//		/// <param name="targetId">目标ID</param>
//		/// <param name="direction">攻击方向</param>
//		public static void Attack(short skillSort, long targetId, short direction) {
//
//			NetData data = new NetData(S_ATTACK_TARGET);
//
//			data.PutShort(skillSort);
//			data.PutLong(targetId);
//			data.PutShort(direction);
//
//			Common.gameClient.SendMessage(data);
//
//		}
//
//
//		public static void Jump(short x, short y){
//
//			NetData data = new NetData(S_JUMP);
//
//			data.PutShort(x);
//			data.PutShort(y);
//
//			Common.gameClient.SendMessage(data);
//
//		}
}
}
