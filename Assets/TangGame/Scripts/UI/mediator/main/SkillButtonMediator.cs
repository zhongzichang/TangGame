/// <summary>
/// xbhuang
/// 2013/11/21
/// </summary>
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using nh.ui.cache;
using TangGame;

namespace nh.ui.main
{
  
  
  public class SkillButtonMediator : Mediator
  {
    SkillButtonPanel panel;

    //技能组按钮技能索引ID列表，key代表位置索引，value代表技能ID
    public Dictionary<int,int> skillBarIds = new Dictionary<int, int> ();
    public new const string NAME = "SkillButtonMediator";
    private delegate void Handle (INotification notification);
    /// <summary>
    /// 我的消息处理映射方法
    /// </summary>
    private Dictionary<string, Handle> handleTable = new Dictionary<string, Handle> ();
    /// <summary>
    ///   感兴趣的消息
    /// </summary>
    private List<string> interests = new List<string> ();
    /// <summary>
    /// 我的构造方法
    /// </summary>
    /// <param name="gameObject"></param>
    public SkillButtonMediator (SkillButtonPanel viewComponent) : base(NAME)
    {
      panel = viewComponent;
      handleTable.Add (NtftNames.TG_UPDATE_SKILL_BAR, HandleUpdateSkillBar);
      handleTable.Add (NtftNames.TG_UPDATE_SKILL_BARS, HandleUpdateSkillBars);
      handleTable.Add (NtftNames.TG_SKILL_USEED, HandleSkillUseed);
      //      handleTable.Add (NotificationIDs.ID_UpdateSkillPanel, HandleUpdateSkillInfo);
    }
    /// <summary>
    /// 我感兴趣的消息
    /// </summary>
    /// <returns></returns>
    public override IList<string> ListNotificationInterests ()
    {
      if (interests.Count == 0) {
        interests.Add (NtftNames.TG_UPDATE_SKILL_BAR);
        interests.Add (NtftNames.TG_UPDATE_SKILL_BARS);
        interests.Add (NtftNames.TG_SKILL_USEED);
        interests.Add (NotificationIDs.ID_UpdateSkillPanel);
      }
      return interests;
    }
    /// <summary>
    /// 处理通知
    /// </summary>
    /// <param name="notification"></param>
    public override void HandleNotification (INotification notification)
    {
      if (handleTable.ContainsKey (notification.Name)) {
        handleTable [notification.Name] (notification);
      }
    }
    /// <summary>
    /// 给按钮对象添加事件
    /// </summary>
    public void AddEvent ()
    {
      if (panel.SkillBox1 != null) {
        UIEventListener.Get (panel.SkillBox1.gameObject).onClick += OnHookButton;
      }
      foreach (GameObject skillbox in panel.SkillBoxes) {
        if (skillbox != null) {
          UIEventListener.Get (skillbox.gameObject).onClick += OnClickSkill;
        }
      }
    }
    /// <summary>
    /// 给按钮对象移除事件
    /// </summary>
    public void DelEvent ()
    {
      if (panel.SkillBox1 != null) {
        UIEventListener.Get (panel.SkillBox1.gameObject).onClick -= OnHookButton;
      }
      foreach (GameObject skillbox in panel.SkillBoxes) {
        if (skillbox != null) {
          UIEventListener.Get (skillbox.gameObject).onClick -= OnClickSkill;
        }
      }
    }
    /// <summary>
    /// 刷新技能栏的图标
    /// </summary>
    public void RefreshSkillBar ()
    {
      foreach (KeyValuePair<int ,int> item in skillBarIds) {
        if (item.Value != 0) {
          this.SetSkillBoxes (panel.SkillBoxes [item.Key].gameObject, item.Value);
        }
      }
    }
    /// <summary>
    /// 更新多个技能栏的消息
    /// </summary>
    /// <param name="notification">Notification.</param>
    public void HandleUpdateSkillBars (INotification notification)
    {
      SkillBarBean[] beans = notification.Body as SkillBarBean[];
      if (beans == null || beans.Length <= 0) {
        return;
      }
      foreach (SkillBarBean bean in beans) {
        SendNotification (NtftNames.TG_UPDATE_SKILL_BAR, bean);
      }
    }
    /// <summary>
    /// 更新一个技能栏的消息
    /// </summary>
    /// <param name="obj">Object.</param>
    public void HandleUpdateSkillBar (INotification notification)
    {
      SkillBarBean bean = notification.Body as SkillBarBean;
      if (bean == null || bean.index < 0) {
        return;
      }
      
      skillBarIds [bean.index] = bean.skillId;
      RefreshSkillBar ();

    }
    /// <summary>
    /// 更新技能信息
    /// </summary>
    /// <param name="notification"></param>
    //    public void HandleUpdateSkillInfo (INotification notification)
    //    {
    //      if (skillBarIds != null && skillBarIds.Count > 0) {
//
    //        List<int> keys = new List<int>(skillBarIds.Keys);
    //        for(int i = 0;i<keys.Count;i++){
//
    //          int skillBarKey = keys[i];
    //          int skillBarVal;
    //          if (skillBarIds.TryGetValue (skillBarKey, out skillBarVal)) {
    //            int skillSort = Config.skillTable [skillBarVal].Sort;
    //            if (SkillsCache.skillDic.ContainsKey (skillSort)) {
    //              TangGame.Net.SkillInfo skillInfo = SkillsCache.skillDic [skillSort];
    //              skillBarIds [skillBarKey] = skillInfo.skillIndex;
    //              RefreshSkillBar ();
//
    //            }
    //          }
    //        }
    //      }
    //    }
    
    /// <summary>
    /// 更新单个技能的CD遮罩
    /// </summary>
    /// <param name="notification">Notification.</param>
    public void HandleSkillUseed (INotification notification)
    {
      if (notification.Body == null) {
        return;
      }
      int skillId = int.Parse (notification.Body.ToString ());
      this.SetSkillBoxCdMask (skillId);
    }

    private void SetSkillBoxes (GameObject skillBoxObj, int skillId)
    {
      if (skillId == 0) {
        //TODO 清空当前技能框
        skillBoxObj.GetComponent<UISprite> ().spriteName = "skillButton";
        return;
      }
      TangGame.Xml.SkillData xmlSkill = null;
      TangGame.Net.Skill skillNo = null;
      xmlSkill = Config.skillTable [skillId];
      if (SkillsCache.heroUseSkills .ContainsKey (xmlSkill.Skill_id)) {
        skillNo = SkillsCache.heroUseSkills [xmlSkill.Skill_id];
      }
      //无法找到当前技能
      if (xmlSkill == null)
        return;
      //玩家身上沒有此技能
      if (skillNo == null)
        return;
      
      if (xmlSkill.Skill_icon.Length > 0) {
        skillBoxObj.GetComponent<UISprite> ().atlas = panel.atlas;
        skillBoxObj.GetComponent<UISprite> ().spriteName = xmlSkill.Skill_icon;
      } else {
        skillBoxObj.GetComponent<UISprite> ().spriteName = "skillButton";
      }
    }

    /// <summary>
    /// 点击技能按钮
    /// </summary>
    /// <param name="obj">Object.</param>
    public void OnClickSkill (GameObject obj)
    {
      int index = panel.SkillBoxes.FindIndex (delegate(GameObject obj2) {
                                                return obj2.GetInstanceID () == obj.GetInstanceID ();
                                              });
      //如果冷却条没有转完则不能使用技能
      if (panel.SkillMasks [index].GetComponent<UISprite> ().fillAmount != 0) {
        return;
      }
      //使用技能
      if (skillBarIds.ContainsKey (index)) {
        SkillsCache.currentActorSkillId = skillBarIds [index];
        BattleHelper.AutoTrace ();
      }
    }
    /// <summary>
    /// 点击按钮挂机
    /// </summary>
    /// <param name="obj">Object.</param>
    public void OnHookButton (GameObject obj)
    {
      if(BattleCache.onHook){
        SendNotification(NtftNames.TG_UNHOOK);
      }else{
        SendNotification (HookCmd.NAME);
        
      }
    }
    /// <summary>
    /// 设置技能的遮罩
    /// </summary>
    /// <param name="skillId"></param>
    public void SetSkillBoxCdMask (int skillId)
    {
      int skillBarId = 0;
      //如果技能在技能框上
      if (skillBarIds.ContainsValue (skillId)) {
        foreach (KeyValuePair<int,int> skillBarItem in skillBarIds) {
          if (skillBarItem.Value == skillId) {
            skillBarId = skillBarItem.Key;
          }
        }
        //如果技能缓存中包含技能ID
        if (SkillsCache.heroUseSkills.ContainsKey (skillId)) {
          float cdTime = SkillsCache.heroUseSkills [skillId].cdTime;
          float val = 1 / (cdTime / 1000);
          panel.StartSkillBoxMasks (skillBarId);
          panel.AddOrUpdateSkillboxMasks (skillBarId, val);
        }
      }
    }


  }
}