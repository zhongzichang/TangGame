using System;
using System.Collections.Generic;
using UnityEngine;
using TangNet;
using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace TangGame.Net
{
	public class HeroNew:ActorNo
	{
		public const int SEX_MALE = 1;
		public const int SEX_FEMALE = 2;
		/// 性别
		public short sex = 1;
		/// HP
		public int hp;
		/// MP
		public int mp;
		/// 法力上限
		public int mpMax = 1;
		/// 名称
		public int mapId;
		
		//================================动态基础属性================================
		/// 经验值
		public long exp;
		/// 经验值上限
		public long expMax;
		/// 职业
		public short genre;
		/// 人物模式，如杀戮模式等3:交游模式2:杀戮模式1:普通模式 ，4组队模式 5帮会模式 6和平模式
		public short portraitMode;
		/// <summary>
		/// 铜钱
		/// </summary>
		public long coin;
		/// <summary>
		/// 银锭
		/// </summary>
		public long silver;
		/// <summary>
		/// 金锭
		/// </summary>
		public long ingot;
		/// <summary>
		/// 战斗状态：进入战斗状态\脱离战斗状态
		/// </summary>
		public bool stateOfWar;
		
		//========================战斗属性========================
		/// <summary>
		/// 物理攻击
		/// </summary>
		public int physicalAttack;
		/// <summary>
		/// 物理防御
		/// </summary>
		public int physicalDefense;
		/// <summary>
		/// 莫法攻击
		/// </summary>
		public int magicAttack;
		/// <summary>
		/// 魔法
		/// </summary>
		public int magicDefense;
		public int hitrate;
		public int dodge;
		public int criticalStrike;
		public int tenacity;
		public int zhengYuan;
		/// <summary>
		/// 冷却时间
		/// </summary>
		public double arrangeCooldown;

		//========================新加====================
		/// <summary>
		/// 玩家使用的武器资源ID
		/// </summary>
		public string weaponResourcesId;
		//		public Dictionary<int,Skill> skills = new Dictionary<int,Skill>();
		public string mapName;
		
		public void UpdateHeroData (KeyValuePair<short,object> item)
		{

			switch ((HeroPropertyEnum)item.Key) {
			case HeroPropertyEnum.MONEY:
				this.coin = (long)item.Value;
				break;
			case HeroPropertyEnum.SILVERINGOT:
				this.silver = (long)item.Value;
				break;
			case HeroPropertyEnum.GOLDINGOT:
				this.ingot = (long)item.Value;
				break;
			case HeroPropertyEnum.LV:
				this.level = (int)item.Value;
				break;
			case HeroPropertyEnum.EXP:			
				this.exp = (long)item.Value;
				break;
			case HeroPropertyEnum.EXPMAX:
				this.expMax = (long)item.Value;
				break;
			case HeroPropertyEnum.HP:
				this.hp = (int)item.Value;
				break;
			case HeroPropertyEnum.HPMAX:
				this.hpMax = (int)item.Value;
				break;
			case HeroPropertyEnum.MP:
				this.mp = (int)item.Value;
				break;
			case HeroPropertyEnum.MPMAX:
				this.mpMax = (int)item.Value;
				break;
			case HeroPropertyEnum.PHYSICALATTACK:
				this.physicalAttack = (int)item.Value;
				break;
			case HeroPropertyEnum.PHYSICALDEFENSE:
				this.physicalDefense = (int)item.Value;
				break;
			case HeroPropertyEnum.MAGICATTACK:
				this.magicAttack = (int)item.Value;
				break;
			case HeroPropertyEnum.MAGICDEFENSE:
				this.magicDefense = (int)item.Value;
				break;
			case HeroPropertyEnum.HITRATE:
				this.hitrate = (int)item.Value;
				break;
			case HeroPropertyEnum.DODGE:
				this.dodge = (int)item.Value;
				break;
			case HeroPropertyEnum.CRITICALSTRIKE:
				this.criticalStrike = (int)item.Value;
				break;
			case HeroPropertyEnum.TENACITY:
				this.tenacity = (int)item.Value;
				break;
			case HeroPropertyEnum.REALYUAN:
				this.zhengYuan = (int)item.Value;
				break;
			case HeroPropertyEnum.ARRANGE_COOLDOWN://整理冷却时间
				long cooldown = (long)item.Value;
				if (cooldown != 0)
				{
					double now = GlobalFunction.GetCurrentTime();
					this.arrangeCooldown = now + cooldown;
					Facade.Instance.SendNotification(NotificationIDs.ID_UpdateBagArrangeCoolDown);
				}
				break;
			}
			//更新数据
		}

		public static HeroNew Parse (MsgData data)
		{

			int index = 0;

			HeroNew hero = new HeroNew ();
			hero.id = data.GetLong (index++);
			hero.name = data.GetString (index++);
			hero.sex = data.GetShort (index++);
			hero.hp = data.GetInt (index++);
			hero.mp = data.GetInt (index++);
			hero.hpMax = data.GetInt (index++);
			hero.mpMax = data.GetInt (index++);
			hero.mapId = data.GetInt (index++);
			hero.x = data.GetShort (index++);
			hero.y = data.GetShort (index++);
			
			hero.level = data.GetInt (index++);
			hero.exp = data.GetLong (index++);
			hero.expMax = data.GetLong (index++);
			hero.genre = data.GetShort (index++);
			hero.portraitMode = data.GetShort (index++);
			hero.coin = data.GetLong (index++);
			hero.silver = data.GetLong (index++);
			hero.ingot = data.GetLong (index++);
			hero.speed = data.GetShort (index++);
			hero.stateOfWar = data.GetBool (index++);
			hero.mapName = data.GetString(index++);
			//			hero.skills=Skill.Parse(data.GetMsgData(index++));
			//================临时数据
			//			hero.portraitMode=1;

      hero.resourcesId="hero_001";
      hero.weaponResourcesId="hero_001_weapon";
      hero.helfLengthPhoto = "002";
      hero.stateOfWar=false;
      return hero;
    }

		public static HeroNew ParseSceneData (MsgData data)
		{

			int index = 0;
			HeroNew hero = new HeroNew ();
			hero.id = data.GetLong (index++);
			hero.name = data.GetString (index++);
			hero.x = data.GetShort (index++);
			hero.y = data.GetShort (index++);
			hero.hp = data.GetInt (index++);
			hero.hpMax = data.GetInt (index++);
			hero.sex = data.GetShort (index++);
			hero.genre = data.GetShort (index++);
			hero.speed = data.GetShort (index++);
			//================临时数据
			hero.portraitMode = 1;
			hero.resourcesId = "hero_001";
			hero.weaponResourcesId = "hero_001_weapon";
			hero.stateOfWar = false;
			
			return hero;
		}
	}
}

