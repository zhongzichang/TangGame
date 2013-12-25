using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using TangUtils;
using TGV = TangGame.View;
namespace TangGame.Xml
{
  public class PassiveSkill
  {
    /// <summary>
    /// skill identity
    /// </summary>
    public int ID;
    /// <summary>
    /// skill name
    /// </summary>
    public string Name;
    /// <summary>
    /// the skill spirte name
    /// </summary>
    public string ICON;
    /// <summary>
    /// hero type,1 warrior,2 archer,3 master,4 pastor
    /// </summary>
    public int Hero_type;
    /// <summary>
    /// The skill level.
    /// </summary>
    public int Skill_level;
    /// <summary>
    /// group where this skill
    /// </summary>
    public int Group;
    /// <summary>
    /// sort where this skill
    /// </summary>
    public int Sort;
    /// <summary>
    /// before skill
    /// </summary>
    public int Befor_skill;
    /// <summary>
    /// next skill.
    /// </summary>
    public int Next_skill;
    /// <summary>
    /// hp addition
    /// </summary>
    public int Hp_up;
    /// <summary>
    /// ATK addition
    /// </summary>
    public int Attack_up;
    /// <summary>
    /// defense addition
    /// </summary>
    public int Def_up;
    /// <summary>
    /// hit rate addition
    /// </summary>
    public int Hit_up;
    /// <summary>
    /// duck addition
    /// </summary>
    public int Duck_up;
    /// <summary>
    /// cirt addition
    /// </summary>
    public int Crit_up;
    /// <summary>
    /// crit resist addition
    /// </summary>
    public int Tough_up;
    /// <summary>
    /// Upgrade Prop id
    /// </summary>
    public int Item_id;
    /// <summary>
    /// Upgrade Props num
    /// </summary>
    public int Item_need;
    /// <summary>
    /// Ises the max level.
    /// </summary>
    /// <returns><c>true</c>, if max level was ised, <c>false</c> otherwise.</returns>
    /// <param name="skillXml">Skill xml.</param>
    public bool isMaxLevel(){
      if(this.Next_skill <= 0 ){
        return true;
      }  
      return false;
    }
  }

  [XmlRoot("root")]
  [XmlLate("passive_skill")]
  public class PassiveSkillRoot
  {
    [XmlElement("value")]
    public List<PassiveSkill> items = new List<PassiveSkill>();
    
    public static void LateProcess(object obj)
    {
      
      PassiveSkillRoot root = obj as PassiveSkillRoot; 
      foreach (PassiveSkill item in root.items)
      {
        if(!Config.passiveSkillSortList.ContainsKey(item.Sort)){
          Config.passiveSkillSortList[item.Sort] = new List<int>();
        }
        Config.passiveSkillSortList[item.Sort].Add(item.ID);
        Config.passiveSkillTable[item.ID] = item;
      }
    }
  }
}