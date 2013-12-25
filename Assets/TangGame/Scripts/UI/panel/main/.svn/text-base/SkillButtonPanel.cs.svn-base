/// <summary>
/// xbhuang
/// change:2013/11/23
/// </summary>
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using nh.ui.basePanel;
using TangGame;

namespace nh.ui.main
{
  public class SkillButtonPanel : XBPanel
  {
    public new const string NAME="SkillButtonPanel";
    public GameObject SkillBox1;
    public GameObject SkillBox2;
    public GameObject SkillBox3;
    public GameObject SkillBox4;
    public GameObject SkillBox5;
    public List<GameObject> SkillBoxes;
    public List<GameObject> SkillMasks;
    /// <summary>
    /// 技能框的遮罩,key 是技能框的位置，value 是每秒的转速
    /// </summary>
    private Dictionary<int,float> SkillboxMasks;
    SkillButtonMediator skillButtonMediator;
    private IFacade facade = PureMVC.Patterns.Facade.Instance;
    private GameObject prefab;
    public UIAtlas atlas;
    void Start()
    {
      prefab = PrefabCache.getIconPrefabs(GameConsts.SKILL_ATLAS, GameConsts.SKILL_PATH);
      atlas = prefab.GetComponent<UIAtlas>();
      SkillBoxes = new List<GameObject>();
      SkillMasks = new List<GameObject>();
      SkillboxMasks = new Dictionary<int,float>();
      //      SkillBoxes.Add(SkillBox1);
      SkillBox1 = this.transform.FindChild("SkillBox1").gameObject;
      SkillBox2 = this.transform.FindChild("SkillBox2").gameObject;
      SkillBox3 = this.transform.FindChild("SkillBox3").gameObject;
      SkillBox4 = this.transform.FindChild("SkillBox4").gameObject;
      SkillBox5 = this.transform.FindChild("SkillBox5").gameObject;
      SkillBoxes.Add(SkillBox2);
      SkillBoxes.Add(SkillBox3);
      SkillBoxes.Add(SkillBox4);
      SkillBoxes.Add(SkillBox5);
      skillButtonMediator = new SkillButtonMediator(this);
      facade.RegisterMediator(skillButtonMediator);
      //      skillButtonMediator.DelEvent();
      skillButtonMediator.AddEvent();

      List<TangGame.Net.Skill> skillNoes = new List<TangGame.Net.Skill>(SkillsCache.heroUseSkills.Values);
      foreach(TangGame.Net.Skill skill in skillNoes){
        facade.SendNotification(NtftNames.TG_UPDATE_SKILL_BAR,new SkillBarBean(skill.skillBarIndex, skill.id));
      }
      //设置按钮效果
      foreach(GameObject button in SkillBoxes){
        //设置按钮点击缩放
        if(button.GetComponent<UIButtonScale>() == null){
          button.AddComponent<UIButtonScale>();
        }
        //设置按钮点击缩放
        if(button.GetComponent<UIButtonOffset>() == null){
          button.AddComponent<UIButtonOffset>();
        }
      }


      //设置挂机按钮点击缩放
      if(SkillBox1.GetComponent<UIButtonScale>() == null){
        SkillBox1.AddComponent<UIButtonScale>();
      }
      //设置挂机按钮点击缩放
      if(SkillBox1.GetComponent<UIButtonOffset>() == null){
        SkillBox1.AddComponent<UIButtonOffset>();
      }
      
      
      
      //创建技能遮照
      for(int i = 0;i< SkillBoxes.Count;i++){
        UISprite skillSprite = NGUITools.AddSprite(SkillBoxes[i],atlas,"CdIcon");
        skillSprite.width = SkillBoxes[i].GetComponent<UISprite>().width;
        skillSprite.height = SkillBoxes[i].GetComponent<UISprite>().height;
        skillSprite.type = UISprite.Type.Filled;
        skillSprite.fillDirection = UISprite.FillDirection.Radial360;
        skillSprite.fillAmount = 0;
        skillSprite.color = Color.black;
        GameObject skillMask = skillSprite.gameObject;
        SkillMasks.Add(skillMask);
      }
    }
    void Update(){
      
      if(SkillboxMasks != null && SkillboxMasks.Count > 0){
        //刷新技能CD时间
        foreach(int key  in SkillboxMasks.Keys){
          float val = 0;
          SkillboxMasks.TryGetValue(key,out val);
           if (val != 0 && key <= SkillMasks.Count)
          {
            GameObject obj = SkillMasks[key].gameObject;
            if (obj != null)
            {
              UISprite sprite = obj.GetComponent<UISprite>();
              sprite.fillAmount -= (val * Time.deltaTime);
            }
          }
//          skillboxMask.
//          if(SkillMasks[skillboxMask.Key] == null){
//            continue;
//          }
//          UISprite sprite = SkillMasks[skillboxMask.Key].gameObject.GetComponent<UISprite>();
//          sprite.fillAmount -= (skillboxMask.Value * Time.deltaTime);
        }
      }
    }
    /// <summary>
    /// 添加或更新某个UI主面板技能框的技能遮罩
    /// </summary>
    /// <param name="key">技能按钮索引</param>
    /// <param name="val">转多少每秒，0-1</param>
    public void AddOrUpdateSkillboxMasks(int key, float val){
      if(SkillboxMasks.ContainsKey(key)){
        SkillboxMasks[key] = val;
      }else{
        SkillboxMasks.Add(key,val);
      }
      
    }
    /// <summary>
    /// 重置某个技能索引的遮罩
    /// </summary>
    /// <param name="key"></param>
    public void StartSkillBoxMasks(int key){
      SkillMasks[key].GetComponent<UISprite>().fillAmount = 1;
    }
    /// <summary>
    /// 清空某个技能索引的遮罩
    /// </summary>
    /// <param name="key"></param>
    public void ClearSkillBoxMasks(int key){
      SkillMasks[key].GetComponent<UISprite>().fillAmount = 0;
    }
    
      
  }
}
