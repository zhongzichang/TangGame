/**
 * Created by emacs
 * Date: 2013/10/18
 * Author: zzc
 */
using UnityEngine;
using System.Collections.Generic;
using TangGame.Xml;
using TGV = TangGame.View;
using TangEffect;
using TN = TangGame.Net;
using TangGame;

namespace TangGame
{

  public class Config
  {

    // 技能表定义的常量 ------
    // 近身攻击标识
    public const int CLOSE_ATTACK = 0;
    // 远程攻击标识
    public const int REMOTE_ATTACK = 1;
    
    // 英雄冲刺速度
    public const float SPRINT_SPEED = 1500F;
    
    // 是否调试(暂时没什么用)
    public static bool debug = true;


    // 追踪使用的默认距离，
    public static readonly Vector3 defaultTraceDistance = new Vector3(96,128,25);

    // XML 配置 ------
    // 所有加载后的XML对象
    public static Dictionary<string, object> xmlObjTable = new Dictionary<string, object> ();
    /// <summary>
    /// The passive skill sort list.
    /// </summary>
    public static Dictionary<int,List<int>> passiveSkillSortList = new Dictionary<int,List<int>>();
    /// <summary>
    /// passive skill
    /// </summary>
    public static Dictionary<int,PassiveSkill> passiveSkillTable = new Dictionary<int,PassiveSkill >();
    // 技能表
    public static Dictionary<int, SkillData> skillTable = new Dictionary<int, SkillData> ();
    // 英雄初始数据表
    public static Dictionary<string, HeroInitialize> heroInitializeTable = new Dictionary<string, HeroInitialize> ();
    // 怪物表
    public static Dictionary<int, Monster> monsterTable = new Dictionary<int, Monster> ();
    // 物品表
    public static Dictionary<int, ItemData> itemTable = new Dictionary<int, ItemData> ();
    // 任务表
    public static Dictionary<int, Task> taskTable = new Dictionary<int, Task>();
    // TS特效表
    public static Dictionary<int, TsEffect> tsEffectTable = new Dictionary<int, TsEffect>();
    //装备升级数据表
    public static Dictionary<int, Equip_upgrade> equip_upgrade = new Dictionary<int, Equip_upgrade>();
		/// <summary>
		/// 根据职业获取能够学习的所有技能
		/// </summary>
		/// <param name="prefession"></param>
    public static List<SkillData> GetSkillListByProfession(int prefession)
    {
			List<SkillData> list = new List<SkillData>();
			foreach(SkillData skill in skillTable.Values)
			{
				if (skill.Hero_type == prefession && skill.Level == 1 && (SkillGroupEnum)skill.Skill_Group != SkillGroupEnum.DAZHAO)//选取所有技能为1级并且为当前职业,并且不是大招的技能
					list.Add(skill);
			}
    	return list;
    }
    
    /// <summary>
    /// 根据职业获取能够学习的所有绝学技能
    /// </summary>
    /// <param name="profession"></param>
    /// <returns></returns>
    public static List<SkillData> GetDaZhaoSkillListByProfession(int prefession){
      List<SkillData> list = new List<SkillData>();
      foreach(SkillData skill in skillTable.Values){
        if(skill.Hero_type == prefession && skill.Level == 1&&(SkillGroupEnum)skill.Skill_Group == SkillGroupEnum.DAZHAO){
          list.Add(skill);
        }
      }
      return list;
    }

		public static bool CheckSkillLevelLimit(int skillIndex)
		{
			bool bo = false;
			if (skillTable.ContainsKey(skillIndex))
			{
				SkillData skill = skillTable[skillIndex];
				//判断等级
				TN.HeroNew hero = ActorCache.GetLeadingHero();
				if (skill.Hero_Level <= hero.level)
					bo = true;
			}
			return bo;

		}

//		public static bool IsCanStudySkill (int skillId)
//		{
//			bool bo = false;
//			if (skillTable.ContainsKey(skillId))
//			{
//				SkillData skill = skillTable[skillId];
//				//判断等级
//				TN.HeroNew hero = ActorCache.GetLeadingHero();
//				if (skill.Hero_Level <= hero.level)
//					bo = true;
//				if (skill.Next_skill != -1)
//					bo = true;
//			}
//			return bo;
//		}
		/// <summary>
		/// 获取道具颜色名字
		/// </summary>
		/// <returns>The item color name.</returns>
		/// <param name="itemIndex">Item index.</param>
		public static string GetItemColorName(int itemIndex)
		{
			string str = "";
			if (itemTable.ContainsKey(itemIndex))
			{
				ItemData data = itemTable[itemIndex];
				if (data != null)
				{
					switch (data.Quality)
					{
					case ItemQulity.WHITE:
						str = "[FFFFFF]" + data.Name + "[-]";
						break;
					case ItemQulity.GREEN:
						str = "[00FF00]" + data.Name + "[-]";
						break;
					case ItemQulity.BLUE:
						str = "[0000FF]" + data.Name + "[-]";
						break;
					case ItemQulity.PURPLE:
						str = "[CC00CC]" + data.Name + "[-]";
						break;
					case ItemQulity.RED:
						str = "[FF0000]" + data.Name + "[-]";
						break;
					case ItemQulity.ORANGE:
						str = "[FFFF00]" + data.Name + "[-]";
						break;
					default:
						str = "[FFFFFF]" + data.Name + "[-]";
						break;
					}
				}
			}
			return str;
		}


//    public static int IsCanStudySkill(int skillId)
//    {
//			int code = 0;
//      if (skillTable.ContainsKey(skillId))
//      {
//        SkillData skill = skillTable[skillId];
//        //判断等级
//        TN.HeroNew hero = ActorCache.GetLeadingHero();
//        if (skill.Hero_Level <= hero.level)
//					code = 1;
//        if (skill.neili > hero.mp)
//					code = 2;
//				int itemIndex = skill.Upgrade_item;
//				if (itemIndex != 0)
//				{
//					int count = GoodsCache.GetItemCountFromPack(skill);
//					if (count < skill.Item_need)
//						code = 3;
//				}
//      }
//      return code;
//
//    }
    /// <summary>
    /// 获取技能的消耗类型
    /// </summary>
    /// <param name="skill"></param>
    public static string GetReleaseSkillCostType(SkillData skill)
    {
    	string str = "";
    	switch (skill.Release)
    	{
    		case ReleaseSkillCostType.COST_HP:
    			str = SkillLang.COST_HP;
    			break;
    		case ReleaseSkillCostType.COST_MP:
    			str = SkillLang.COST_MP;
    			break;
    		case ReleaseSkillCostType.COST_ANGER:
    			str = SkillLang.COST_ANGER;
    			break;
    	}
    	return str;
    }
		/// <summary>
		/// 获取道具类型字符串
		/// </summary>
		/// <returns>The item type string.</returns>
		/// <param name="data">Data.</param>
    public static string GetItemTypeString(ItemData data)
		{
			string str = GoodsLang.ITEM_TYPE;
			switch(data.Type)
			{
			case ItemBigType.EQUIP:
				str += GoodsLang.EQUIP_STR;
					break;
			case ItemBigType.MEDICINE:
				str += GoodsLang.MEDICINE_STR;
					break;
			case ItemBigType.MATERIAL:
				str += GoodsLang.MATERIAL_STR;
					break;
			case ItemBigType.TASK:
				str += GoodsLang.TASK_STR;
					break;
			case ItemBigType.GIFT:
				str += GoodsLang.GIFT_STR;
					break;
			case ItemBigType.STONE:
				str += GoodsLang.STONE_STR;
					break;
			case ItemBigType.BOX:
				str += GoodsLang.BOX_STR;
					break;
			}
			return str;
		}
		public static string GetHeadIcon(short genre, short sex)
		{
			if(sex == 1){
				//				return Config.heroInitializeTable[genre.ToString()].Male_icon;
				return "2";
			}else{
				//				return Config.heroInitializeTable[genre.ToString()].Female_icon;
				return "1";
			}
		}
  }
}