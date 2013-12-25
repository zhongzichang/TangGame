using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using TangUtils;

namespace TangGame.Xml
{
  public class HeroInitialize
  {
    /// <summary>
    /// 索引ID
    /// </summary>
    public int Id;
    /// <summary>
    /// 英雄名称
    /// </summary>
    public string Name;
    /// <summary>
    /// 角色类型
    /// </summary>
    public int Hero_type;
    /// <summary>
    /// 男性角色头像
    /// </summary>
    public string Male_icon;
    /// <summary>
    /// 女性角色头像
    /// </summary>
    public string Female_icon;
    /// <summary>
    /// 男性角色半身像
    /// </summary>
    public string Male_portrait;
    /// <summary>
    /// 女性角色半身像
    /// </summary>
    public string Female_portrait;
    /// <summary>
    /// 该职业攻击力指示
    /// </summary>
    public int Attack;
    /// <summary>
    /// 该职业的防御力指示
    /// </summary>
    public int Defense;
    /// <summary>
    /// 该职业敏捷指数
    /// </summary>
    public int Agility;
    /// <summary>
    /// 该职业信息介绍
    /// </summary>
    public string Info;
    /// <summary>
    /// 初始化技能组
    /// </summary>
    public string Skill;
    /// <summary>
    /// 初始化必杀技组
    /// </summary>
    public string Nirvana;
    /// <summary>
    /// 被动技能组
    /// </summary>
    public string Passive_skill;
    /// <summary>
    /// 初始化职业给予的默认背包数量
    /// </summary>
    public int bag;
    /// <summary>
    /// 初始化角色所在场景
    /// </summary>
    public int Scenes;
    /// <summary>
    /// 初始化角色所在场景坐标
    /// </summary>
    public string Coordinate;
    /// <summary>
    /// 初始化角色赋予的默认任务
    /// </summary>
    public int Mission;
    public int Default_skill;
  }

  [XmlRoot ("root")]
  [XmlLate ("hero_initialize")]
  public class HeroInitializeRoot
  {
    [XmlElement ("value")]
    public List<HeroInitialize> items = new List<HeroInitialize> ();

    public static void LateProcess (object obj)
    {
      HeroInitializeRoot root = obj as HeroInitializeRoot;

      foreach (HeroInitialize item in root.items) {
        Config.heroInitializeTable [item.Hero_type.ToString ()] = item;
      }
    }
  }
}

