using System;
using TGN = TangGame.Net;
using TGX = TangGame.Xml;
using TangScene;
using System.Collections.Generic;
namespace TangGame.View
{
	public class MonsterVo : ActorVo
	{
		public int moveSpeed;
		public string resName = null;
		public MonsterVo (long id, string resName) : base(id)
		{
			this.actorType = ActorType.monster;
			//CurrentSkill = SkillBaseVoNew.BaseAttack;
			this.resName = resName;
		}

		public static MonsterVo FromData (TGN.Monster monster)
		{
			if (!Config.monsterTable.ContainsKey (monster.configurationId)) return null;
			TGX.Monster monsterConfig =  Config.monsterTable [monster.configurationId];
			MonsterVo vo = new MonsterVo (monster.id, monsterConfig.Monster_name);
			vo.position.GamePoint = new TangUtils.Point (monster.x, monster.y);
			vo.remotePosition.GamePoint = new TangUtils.Point (monster.x, monster.y);
			vo.name = monsterConfig.Avatar;
			vo.hp.Val = monster.hp;
			vo.hp.Max = monsterConfig.Hp_c;
			return vo;
		}

	}
}

