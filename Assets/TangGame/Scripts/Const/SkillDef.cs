/*
 * Created by SharpDevelop.
 * User: shimudennis
 * Date: 2013/11/14
 * Time: 17:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TangGame
{
	/// <summary>
	/// 技能施放消耗类型
	/// </summary>
	public class ReleaseSkillCostType
	{
		public const int COST_HP	 	= 0;//	填0代表释放这个技能消耗HP为单位
		public const int COST_MP	 	= 1;//	填1代表释放这个技能消耗MP为单位
		public const int COST_ANGER = 2;//	填2代表释放这个技能消耗怒气为单位
		
	}
}
