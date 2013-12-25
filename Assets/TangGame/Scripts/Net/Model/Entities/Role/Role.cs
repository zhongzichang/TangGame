/*
 * Created by SharpDevelop.
 * User: zzc
 * Date: 2013/5/25
 * Time: 12:10
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using TangNet;

namespace TangGame.Net
{
/// <summary>
/// Description of Role.
/// </summary>
	public class Role : ActorNo
	{
		/// <summary>
		/// The type.
		/// </summary>
		public TangScene.ActorType type;
		/** 等级 */
		public short level;
		/** 当前生命值 */
		public int hp;
		/** 当前体力值 */
		public int mp;
		/** 当前内息值 */
		public int breath;

		/** 游戏地图Id */
		public short gameMapId;
		/** 面向 */
		public short currFrame;
		/** 结束坐标点 */
		public int endX, endY;

		//************************非持久字段**************************//
		/** 状态 */
		//public PlayerState state;
		/** 是否在战斗中 */
		public bool isBattle;
		
		
		
		
		/** 角色基础对象 */
		public RoleMould mould = new RoleMould ();
		/** 是否是NPC */
		public bool isNPC;

		/** 仇恨 */
		//public const List<Hatred> hatredList;
		/** 攻击对象 */
		public HeroNew attackObj;

		/** 技能 */
		public Skill[] skillArray;
		/** 所在网格 */
		public NGrid grid;
		/** 是否通知当前场景 */
		public bool isNotice;

		/** 进入战斗时间 */
		public long inBattleTime;
		/** 发起攻击时间 */
		public long attackTime;
		/** 巡逻移动结束时间 */
		public long endMoveTime;
		/** 死亡时间 */
		public long deadTime;
		/** 是否可以复活 */
		public bool isCanRelive;
		/** 复活点 */
		public short reliveX, reliveY;
		/** 副本ID */
		public long fbId;
		/** buff列表 */
		//public const List<Buff> buffList;

		/** AI */
		public RoleAI ai;
		/** 队伍 */
		public List<long> team;

		/** 是否强制移动 */
		public bool isForceMove;
		/** 当前使用技能 */
		public Skill nowSkill;

		/** 附加闪避 */
		public int addEvade;
		/** 附加暴击 */
		public int addDritical;

		/** 是否被定身 */
		public bool isFreeze;
		/** 伤害减少比例 */
		public double reduceHurt;
		/** 攻击加成 */
		public double addAdditionAttack;
		/** 防御加成 */
		public double addAdditionDefence;

		/** 受到的伤害一定百分比转化为体力恢复 */
		public double transformHurt;
		/** 移动速度 */
		public int moveSpeed;
		/** 自身受到DeBuff无效几率 */
		public double debuffInvalidOdds;

		/** 上次受到的伤害 */
		public int beforeHurt;
		/** 怪种类(1:怪攻城) */
		public int monsterSort;
		/** 移动停止时间 */
		public long stopMoveTime = 0;
		public long armsId;

		public static Role ParseMonsterData (MsgData data)
		{

			Role role = new Role ();
			int index = 0;
			role.id = data.GetLong (index++);
			role.mould.id = data.GetInt (index++);
			role.x = data.GetShort (index++);
			role.y = data.GetShort (index++);
			role.hp = data.GetInt (index++);
			role.level = (short)data.GetInt (index++);
			role.endX = data.GetShort (index++);
			role.endY = data.GetShort (index++);
			role.type = TangScene.ActorType.monster;
			return role;
		}

	}

}
