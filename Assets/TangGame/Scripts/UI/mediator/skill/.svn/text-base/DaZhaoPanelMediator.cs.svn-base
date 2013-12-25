/// <summary>
/// xbhuang
/// 2013/12/04
/// </summary>
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using nh.ui.panel;
using nh.ui.main;
using TangGame;

namespace nh.ui.mediator{
  public class DaZhaoPanelMediator : Mediator{
    public new const string NAME = "DaZhaoPanelMediator";
    public DaZhaoPanel dzp;
    protected delegate void Handle(INotification notification);
    protected Dictionary<string, Handle> handleTable = new Dictionary<string, Handle> ();
    protected List<string> interests = new List<string> ();
    public DaZhaoPanelMediator (DaZhaoPanel panel) :base(NAME)
    {
      dzp = panel;
      AddEvent();
      handleTable.Add(NotificationIDs.ID_UPDATE_DAZHAO_SKILL_PANEL,HandleUpdateDaZhaoPanel);
      
    }
    public override IList<string> ListNotificationInterests (){
      if(interests.Count == 0){
        interests.Add(NotificationIDs.ID_UPDATE_DAZHAO_SKILL_PANEL);
      }
      return interests;
    }
    /// <summary>
    /// 处理通知
    /// </summary>
    /// <param name="notification"></param>
    public override void HandleNotification (INotification notification)
    {
      if (handleTable.ContainsKey (notification.Name))
        handleTable [notification.Name] (notification);
    }
    /// <summary>
    /// 更新面板显示
    /// </summary>
    /// <param name="notification"></param>
    private void HandleUpdateDaZhaoPanel(INotification notification){
      if(dzp == null)return;
      List<TangGame.Xml.SkillData> skillXmlList = Config.GetDaZhaoSkillListByProfession(ActorCache.GetLeadingHero().genre);
      for(int i = 0; i < skillXmlList.Count;i++){
        //大招技能数量大于如果技能框数量则跳出此方法
        if(dzp.DaZhaoObjs.Count <= i){
          break;
        }
        int skillSort = skillXmlList[i].Sort;
        int dazhaoObjID = dzp.DaZhaoObjs[i].GetInstanceID();
        int skillConfigId;
        if(TangGame.SkillsCache.skillDic.ContainsKey(skillXmlList[i].Sort)){
          skillConfigId = TangGame.SkillsCache.skillDic[skillSort].skillIndex;
        }else{
          skillConfigId = skillXmlList[i].Skill_id;
        }
        dzp.AddOrUpdateIndexOfSkillIdDictionary(dazhaoObjID,skillConfigId);
      }
      //刷新绝学技能面板
      dzp.UpdateDaZhaoPanel();
    }
    
    
    //获取按钮
    private void OnGainButClick(GameObject obj)
    {
      
    }
    //技能学习
    private void OnStudyButClick(GameObject obj){
      int skillConfigId = dzp.GetCurrentSkillIdBeChecked();
      if(DetermineCondition(skillConfigId)){
        //判断是否学习过此技能
        if(TangGame.SkillsCache.skillDic.ContainsKey(Config.skillTable[skillConfigId].Sort)){
          //升级技能
          TangNet.TN.Send(new TangGame.Net.LevelUpSkillRequest(skillConfigId));
        }else{
          //学习技能
          TangNet.TN.Send(new TangGame.Net.StudySkillRequest(skillConfigId));
        }
      }
    }
    /// <summary>
    /// 判断技能学习条件是否满足
    /// </summary>
    /// <param name="skillConfigId"></param>
    /// <returns></returns>
    private bool DetermineCondition(int skillConfigId){
      TangGame.Xml.SkillData skillXml = Config.skillTable[skillConfigId];
      if(!TangGame.SkillsCache.skillDic.ContainsKey(skillXml.Sort)){
        if(skillXml.isMaxLevel()){
          Debug.Log("当前技能已是满级");
        }
        skillXml = Config.skillTable[skillXml.Next_skill];
      }

      if(skillXml.isMaxLevel()){
        Debug.Log("can't fand next skill");
        return false;
      }
      if(skillXml == null){
        Debug.Log("该技能不存在");
        return false;
      }
      if(!CheckGoodsWhetherMeet(skillXml)){
        Debug.Log("升级道具不满足");
        return false;
      }
      return true;
    }
    /// <summary>
    /// 判断物品是否满足升级条件
    /// </summary>
    /// <param name="skillXml"></param>
    /// <returns></returns>
    private bool CheckGoodsWhetherMeet(TangGame.Xml.SkillData skillXml){
      //判断是否满足升级条件
      if(GoodsCache.GetItemCountFromPack(skillXml.Upgrade_item) >= skillXml.Item_need){
        return true;
      }else{
        Debug.Log("不满足升级条件");
        return false;
      }
    }
    
    public void AddEvent(){
      if(dzp != null){
        UIEventListener.Get(dzp.daZhao1).onClick += OnClickDaZhao;
        UIEventListener.Get(dzp.daZhao2).onClick += OnClickDaZhao;
        UIEventListener.Get(dzp.daZhao3).onClick += OnClickDaZhao;
        UIEventListener.Get(dzp.studyBut).onClick += OnStudyButClick;
      }
    }
    /// <summary>
    /// 切换按钮产生的事件
    /// </summary>
    /// <param name="obj"></param>
    public void OnClickDaZhao(GameObject obj){
      int key = obj.GetInstanceID();
      if(dzp.IndexOfSkillIdDictionary.ContainsKey(key)){
        dzp.UpdateDaZhaoInfo(dzp.IndexOfSkillIdDictionary[key]);
      }
    }
  }
}