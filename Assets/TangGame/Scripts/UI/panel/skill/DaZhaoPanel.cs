/// <summary>
/// xbhuang
/// 2013/12/03
/// </summary>
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using nh.ui.basePanel;
using nh.ui.mediator;

namespace nh.ui.panel
{
  public class DaZhaoPanel : MonoBehaviour
  {
    public GameObject gainBut;    //获得按钮
    public GameObject studyBut;   //学习按钮
    public GameObject daZhao1;
    public GameObject daZhao2;
    public GameObject daZhao3;
    /// <summary>
    /// 大招集合
    /// </summary>
    private List<GameObject> daZhaoObjs = new List<GameObject> ();
    
    public List<GameObject> DaZhaoObjs {
      get { return daZhaoObjs; }
    }

    public GameObject daZhaoIcon;
    /// <summary>
    /// 绝学名字
    /// </summary>
    public GameObject daZhaoName;
    /// <summary>
    /// 绝学等级
    /// </summary>
    public GameObject daZhaoLevel;
    /// <summary>
    /// 绝学标签
    /// </summary>
    public GameObject daZhaoTag;
    /// <summary>
    /// 绝学信息
    /// </summary>
    public GameObject daZhaoInfo;
    /// <summary>
    /// 绝学冷却时间
    /// </summary>
    public GameObject daZhaoCd;
    /// <summary>
    /// 绝学所需物品
    /// </summary>
    public GameObject requiredGoodsIcon;
    /// <summary>
    /// 所需物品名称
    /// </summary>
    public GameObject goodsName;
    /// <summary>
    /// 所需物品数量
    /// </summary>
    public GameObject goodsNum;
    private int checkedToggleObjID;
    /// <summary>
    /// 按钮和技能ID的关联关系
    /// </summary>
    private Dictionary<int,int> indexOfSkillIdDictionary = new Dictionary<int, int> ();
    
    public Dictionary<int, int> IndexOfSkillIdDictionary {
      get { return indexOfSkillIdDictionary; }
      set { indexOfSkillIdDictionary = value; }
    }

    private IFacade facade = PureMVC.Patterns.Facade.Instance;
    DaZhaoPanelMediator mediator;
    /// <summary>
    /// 添加或更新按钮和技能ID的关联关系
    /// </summary>
    /// <param name="index"></param>
    /// <param name="skillConfigId"></param>
    public void AddOrUpdateIndexOfSkillIdDictionary (int index, int skillConfigId)
    {
      if (indexOfSkillIdDictionary.ContainsKey (index)) {
        indexOfSkillIdDictionary [index] = skillConfigId;
      } else {
        indexOfSkillIdDictionary.Add (index, skillConfigId);
      }
    }

    void Awake ()
    {
      daZhaoObjs.Add (daZhao1);
      daZhaoObjs.Add (daZhao2);
      daZhaoObjs.Add (daZhao3);
      mediator = new DaZhaoPanelMediator (this);
      facade.RegisterMediator (mediator);
      
    }

    void Start ()
    {
      
    }

    void OnEnable ()
    {
      facade.SendNotification (TangGame.NotificationIDs.ID_UPDATE_DAZHAO_SKILL_PANEL);
    }
    /// <summary>
    /// 刷新技能面板
    /// </summary>
    public void UpdateDaZhaoPanel ()
    {
      if (indexOfSkillIdDictionary.ContainsKey (daZhao1.GetInstanceID ())) {
        this.UpdateDaZhaoItem (daZhao1);
      }
      if (indexOfSkillIdDictionary.ContainsKey (daZhao2.GetInstanceID ())) {
        this.UpdateDaZhaoItem (daZhao2);
      }
      if (indexOfSkillIdDictionary.ContainsKey (daZhao3.GetInstanceID ())) {
        this.UpdateDaZhaoItem (daZhao3);
      }
      int skillConfigId = GetCurrentSkillIdBeChecked ();
      if (skillConfigId != 0) {
        UpdateDaZhaoInfo (skillConfigId);
      }

    }
    /// <summary>
    /// Gets the current skill identifier be checked.;
    /// </summary>
    /// <returns>The current skill identifier be checked. if return zero,current checked was null</returns>
    public int GetCurrentSkillIdBeChecked ()
    {
      foreach (GameObject dazhaoObj in daZhaoObjs) {
        if (dazhaoObj.GetComponent<UIToggle> ().value) {
          int key = dazhaoObj.GetInstanceID ();
          if (indexOfSkillIdDictionary.ContainsKey (key)) {
            return indexOfSkillIdDictionary [key];
          }
        }
      }
      return 0;
    }
    /// <summary>
    /// 刷新绝学技能信息面板
    /// </summary>
    /// <param name="daZhaoGameObject"></param>
    public void UpdateDaZhaoInfo (int skillConfigId)
    {
      if (!TangGame.Config.skillTable.ContainsKey (skillConfigId)) {
        Debug.LogException (new System.Exception ("技能配置表中不包含此技能"));
        return;
      }
      TangGame.Xml.SkillData skillXml = TangGame.Config.skillTable [skillConfigId];
      this.daZhaoIcon.GetComponent<UISprite> ().spriteName = skillXml.Skill_icon;
      this.daZhaoName.GetComponent<UILabel> ().text = skillXml.Name;
      if (TangGame.SkillsCache.skillDic.ContainsKey (skillXml.Sort)) {
        this.daZhaoLevel.GetComponent<UILabel> ().text = "Lv." + skillXml.Level;
      }
      if (skillXml.isMaxLevel ()) {
        this.daZhaoTag.GetComponent<UILabel> ().text = SkillLang.BUT_MAXLEVEL;
        this.daZhaoTag.GetComponent<UILabel> ().color = Color.green;
      }
      this.daZhaoInfo.GetComponent<UILabel> ().text = skillXml.Info;
      this.daZhaoCd.GetComponent<UILabel> ().text = SkillLang.COOD_TIME + skillXml.Cd_time;
      UILabel studyButLabel = this.studyBut.GetComponentInChildren<UILabel> ();
      
      if (studyButLabel != null) {
        if (TangGame.SkillsCache.skillDic.ContainsKey (skillXml.Sort)) {
          studyButLabel.text = SkillLang.BUT_LEVELUP;
        } else {
          studyButLabel.text = SkillLang.BUT_STUDY;
        }
      }
      int goodsNum = TangGame.GoodsCache.GetItemCountFromPack (skillXml.Upgrade_item);
      UILabel goodsNumLabel = this.goodsNum.GetComponent<UILabel> ();
      /// <summary>
      /// 如果当前已经学习
      /// </summary>
      /// <param name="daZhaoGameObject"></param>
      if (TangGame.SkillsCache.skillDic.ContainsKey (skillXml.Sort) && !skillXml.isMaxLevel ()) {
        TangGame.Xml.SkillData nextSkillXml = TangGame.Config.skillTable [skillXml.Next_skill];
        goodsNumLabel.text = nextSkillXml.Item_need + "/" + goodsNum;
        TangGame.Xml.ItemData itemXml = TangGame.Config.itemTable [nextSkillXml.Upgrade_item];
        this.requiredGoodsIcon.GetComponent<UISprite> ().spriteName = itemXml.Icon.ToString ();
        this.goodsName.GetComponent<UILabel> ().text = itemXml.Name;
      } else {
        goodsNumLabel.text = skillXml.Item_need + "/" + goodsNum;
        TangGame.Xml.ItemData itemXml = TangGame.Config.itemTable [skillXml.Upgrade_item];
        this.requiredGoodsIcon.GetComponent<UISprite> ().spriteName = itemXml.Icon.ToString ();
        this.goodsName.GetComponent<UILabel> ().text = itemXml.Name;
      }
      
      if (goodsNum >= skillXml.Item_need) {
        goodsNumLabel.color = Color.green;
      } else {
        goodsNumLabel.color = Color.red;
      }
      
    }

    public void UpdateDaZhaoItem (GameObject daZhaoGameObject)
    {
      int skillid = this.indexOfSkillIdDictionary [daZhaoGameObject.GetInstanceID ()];
      if (!TangGame.Config.skillTable.ContainsKey (skillid)) {
        Debug.LogException (new System.Exception ("技能配置表中不包含此技能"));
        return;
      }
      if (!daZhaoGameObject.activeSelf) {
        daZhaoGameObject.SetActive (true);
      }
      TangGame.Xml.SkillData skillXml = TangGame.Config.skillTable [skillid];
      Transform iconObj = daZhaoGameObject.transform.FindChild ("Icon");
      Transform nameObj = daZhaoGameObject.transform.FindChild ("Name");
      Transform levelObj = daZhaoGameObject.transform.FindChild ("Level");
      
      UISprite iconSprite = iconObj.GetComponent<UISprite> ();
      UILabel nameLabel = nameObj.GetComponent<UILabel> ();
      UILabel levelLabel = levelObj.GetComponent<UILabel> ();
      
      iconSprite.spriteName = skillXml.Skill_icon;
      nameLabel.text = skillXml.Name;
      if (TangGame.SkillsCache.skillDic.ContainsKey (skillXml.Sort)) {
        levelLabel.text = "Lv." + skillXml.Level;
      }
    }
  }
}