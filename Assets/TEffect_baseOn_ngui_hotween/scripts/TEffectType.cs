using UnityEngine;
using System.Collections;

namespace zyhd.TEffect{
	public enum TEffectType {
		/// <summary>
		/// 普通伤害
		/// </summary>
		Dmg,
		/// <summary>
		/// 暴击伤害
		/// </summary>
		DmgCrit,
		/// <summary>
		/// 加血
		/// </summary>
		Hp,
		/// <summary>
		/// 加血暴击
		/// </summary>
		HpCrit,
		/// <summary>
		/// 闪避
		/// </summary>
		Avoid,
		/// <summary>
		/// 宠物伤害
		/// </summary>
		PetDmg,
		/// <summary>
		/// 玩家自己受伤效果
		/// </summary>
		SelfHurt,
		/// <summary>
		/// 加经验
		/// </summary>
		Exp,
		/// <summary>
		/// 属性变化
		/// </summary>
		AttributeChange,
		/// <summary>
		/// Npc选中效果
		/// </summary>
		NpcSelected,
		/// <summary>
		/// Npc对话
		/// </summary>
		NpcTalk,
		/// <summary>
		/// 玩家名字
		/// </summary>
		PlayerName,
		/// <summary>
		/// 玩家血条
		/// </summary>
		PlayerHpShow,
		/// <summary>
		/// 特殊属性攻击
		/// </summary>
		OtherDmg,
		///none
		Logo
		//,Buff,Debuff,Logo,Text
	}
}