using System;
using UnityEngine;
using nh.ui.basePanel;
using TangGame;
using TangGame.Xml;
using System.Collections.Generic;
using TangGame.Net;
using nh.ui.mediator;
using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace nh.ui.panel
{
	/// <summary>
	/// 技能学习面板
	/// create by huxiaobo
	/// 2013.12.2
	/// </summary>
	public class SkillStudyPanel : MonoBehaviour
	{
		public GameObject gainBut;		//获得按钮
		public GameObject studyBut;		//学习按钮
		
		public GameObject skillDesLabel;//技能描述
		public GameObject cdTimeLabel;	//冷却时间
		public GameObject costDesLabel;	//消耗魔法
		public GameObject leaveZhenYuan;//剩余真元
		
		public GameObject costZhenYuanSprite;
		public GameObject costItemSprite;
		public GameObject costZhenYuanNum;//升级消耗真元
		public GameObject costItemNum;
		public GameObject zhenYuanName;  //真元名
		public GameObject itemName;			//道具名

		public GameObject itemGrid;
		public GameObject itemContainer;
		public GameObject levelLimitLabel;//技能要求等级限制
		
		
		private SkillItemPanel preClickItem;//上次点击的元素
		public SkillItemPanel GetPreClickItem ()
		{
			return preClickItem;
		}
		private SkillStudyPanelMediator mediator;
		
		void Awake ()
		{
			//注册mediator
			mediator = new SkillStudyPanelMediator(this);
			Facade.Instance.RegisterMediator(mediator);
		}
		void Start()
		{
			//初始化技能列表显示
			this.InitSkillTabel ();
			
			costZhenYuanSprite.GetComponent<UISprite> ().spriteName = "";
			costItemSprite.GetComponent<UISprite> ().spriteName = "";
			costZhenYuanNum.GetComponent<UILabel> ().text = "";
			costItemNum.GetComponent<UILabel> ().text = "";
			zhenYuanName.GetComponent<UILabel> ().text = "";
			itemName.GetComponent<UILabel> ().text = "";
			//界面启动时向服务器请求数据
			TangNet.TN.Send(new SynSkillListRequest());
			this.AddEvent();
		}
		void OnEnable()
		{
			this.CheckSkillState();
		}
		/// <summary>
		/// 初始化技能列表
		/// </summary>
		public void InitSkillTabel ()
		{

			HeroNew hero = ActorCache.GetLeadingHero ();
			List<SkillData> list = Config.GetSkillListByProfession (hero.genre);
			foreach (SkillData skill in list) {
				SkillItemPanel item = this.CreateItem (skill);
				item.SkillState = GameConsts.UN_STUDY;
				item.SkillIndex = skill.Skill_id;
				
				string stateStr = "";
				bool bo = Config.CheckSkillLevelLimit (skill.Skill_id);
				//检查等级是否可以学习
				if (bo)
					stateStr = SkillLang.CANSTUDY;
				else
					stateStr = SkillLang.UNSTUDY;
				
				item.UpdateShow (skill.Skill_icon, skill.Name, 0, stateStr, skill.Sort);
			}
			itemGrid.GetComponent<UIGrid> ().repositionNow = true;
		}
		/// <summary>
		/// 创建技能列表
		/// </summary>
		/// <param name="table"></param>
		private SkillItemPanel CreateItem (SkillData skill)
		{
			GameObject prefabs = PrefabCache.getPrefabs (typeof(SkillItemPanel).Name);
			GameObject item = NGUITools.AddChild (itemGrid, prefabs);
			UIDragScrollView usc = item.AddComponent<UIDragScrollView> ();
			usc.scrollView = itemContainer.GetComponent<UIScrollView>();
			SkillItemPanel sip = item.GetComponent<SkillItemPanel> ();
			sip.ClearData ();
			UIEventListener.Get (item).onClick += OnItemClick;
			return sip;
		}
		/// <summary>
		/// 技能列表项被点击
		/// </summary>
		/// <param name="obj">Object.</param>
		private void OnItemClick (GameObject obj)
		{
			SkillItemPanel sip = obj.GetComponent<SkillItemPanel> ();
			if (preClickItem != null && preClickItem == sip)
				return;
			sip.SetSelected (true);
			if (preClickItem != null)
				preClickItem.SetSelected (false);
			preClickItem = sip;			
			this.ShowSkillDetail (sip.SkillIndex);
		}
		/// <summary>
		/// 显示技能详细信息
		/// </summary>
		/// <param name="skillIndex"></param>
		private void ShowSkillDetail (int skillIndex)
		{
			bool butEnabel = true;
			if (Config.skillTable.ContainsKey (skillIndex)) {
				SkillData skill = Config.skillTable [skillIndex];
				skillDesLabel.GetComponent<UILabel> ().text = skill.Info;
				skillDesLabel.SetActive (true);
				cdTimeLabel.GetComponent<UILabel> ().text = SkillLang.CD_TIME + skill.Cd_time;
				cdTimeLabel.SetActive (true);
				//消耗类型
				string costStr = Config.GetReleaseSkillCostType (skill);
				int costValue = skill.Release_need;
				costStr += costValue.ToString ();
				costDesLabel.GetComponent<UILabel> ().text = costStr;
				costDesLabel.SetActive (true);
				
				switch (preClickItem.SkillState) {
				case GameConsts.UN_STUDY:
					studyBut.GetComponentInChildren<UILabel> ().text = SkillLang.BUT_STUDY;
					break;
				case GameConsts.STUDYED:
					studyBut.GetComponentInChildren<UILabel> ().text = SkillLang.BUT_LEVELUP;
					break;
				case GameConsts.MAX_LEVEL:
					studyBut.GetComponentInChildren<UILabel> ().text = SkillLang.BUT_MAXLEVEL;
					break;
				}
				if (skill.isMaxLevel()) {
					studyBut.GetComponent<UIButton> ().isEnabled = false;
					skillDesLabel.SetActive (true);
					cdTimeLabel.SetActive (true);
					costDesLabel.SetActive (true);
					costZhenYuanNum.SetActive (false);
					costItemNum.SetActive (false);
					costZhenYuanSprite.SetActive (false);
					costItemSprite.SetActive (false);
					leaveZhenYuan.SetActive (true);
					itemName.SetActive (false);
					zhenYuanName.SetActive (false);
					levelLimitLabel.SetActive(false);
					butEnabel = false;
					//没有满级就找下一级的需要条件
				} else {
					studyBut.GetComponent<UIButton> ().isEnabled = true;
					int index = 0;
					//如果当前是学习阶段，那用当前技能，否则就用下一个技能的限制
					if (preClickItem.SkillState == GameConsts.UN_STUDY)
						index = skill.Skill_id;
					else
						index = skill.Next_skill;
					
					string color = GameConsts.GREEN;
					if (Config.skillTable.ContainsKey (index)) {
						SkillData nextSkill = Config.skillTable [index];
						if (nextSkill != null) {
							string levelLimitStr = "";
							HeroNew hero = ActorCache.GetLeadingHero();
							if (hero != null)
							{
								if (nextSkill.Hero_Level > hero.level)
								{
									color = GameConsts.RED;
									butEnabel = false;
								}
								levelLimitStr = GlobalFunction.GetColorString(string.Concat(SkillLang.LEVEL_LIMIT, nextSkill.Hero_Level, SkillLang.LEVEL_STRING), color);
							}
							levelLimitLabel.GetComponent<UILabel> ().text = levelLimitStr;
							levelLimitLabel.SetActive(true);
							//升级条件//升级需要真元
							if (nextSkill.Really != 0) {
								UISprite itemSprite = costZhenYuanSprite.GetComponent<UISprite> ();
								itemSprite.atlas.name = "";
								itemSprite.spriteName = "";
								costZhenYuanSprite.SetActive (true);
								if (hero.zhengYuan < nextSkill.Really)
								{
									color = GameConsts.RED;
									butEnabel = false;
								}
								else
									color = GameConsts.GREEN;
								costZhenYuanNum.GetComponent<UILabel> ().text = GlobalFunction.GetColorString(string.Concat(nextSkill.Really, "/", hero.zhengYuan), color);
								costZhenYuanNum.SetActive (true);
								zhenYuanName.GetComponent<UILabel> ().text = SkillLang.ZHENG_YUAN;
								zhenYuanName.SetActive (true);
							} else {//如果不需要真元//如果需要道具
								if (skill.Upgrade_item != 0) {
									if (Config.itemTable.ContainsKey (nextSkill.Upgrade_item)) {
										ItemData itemData = Config.itemTable [nextSkill.Upgrade_item];
										UISprite itemSprite = costZhenYuanSprite.GetComponent<UISprite> ();
										GameObject obj = PrefabCache.getIconPrefabs (GameConsts.ITEM_ATLAS, GameConsts.ITEM_PATH);
										UIAtlas itemAtlas = obj.GetComponent<UIAtlas> ();
										itemSprite.atlas = itemAtlas;
										itemSprite.spriteName = itemData.Icon.ToString ();
										costZhenYuanSprite.SetActive (true);
										zhenYuanName.GetComponent<UILabel> ().text = Config.GetItemColorName (itemData.Id);
									}
									int itemCount = GoodsCache.GetItemCountFromPack(nextSkill.Upgrade_item);
									if (itemCount < nextSkill.Item_need)
									{									
										color = GameConsts.RED;
										butEnabel = false;
									}
									else
										color = GameConsts.GREEN;
									string itemNumStr = GlobalFunction.GetColorString(string.Concat(nextSkill.Item_need, "/", itemCount), color);
									costZhenYuanNum.GetComponent<UILabel> ().text = itemNumStr;
									costZhenYuanNum.SetActive (true);
									
									zhenYuanName.SetActive (true);
								} else {
									costZhenYuanSprite.SetActive (false);
									costZhenYuanNum.SetActive (false);
								}
								costItemSprite.SetActive (false);
								costItemNum.SetActive (false);
								itemName.SetActive (false);
								studyBut.GetComponent<UIButton>().isEnabled = butEnabel;
								return;
							}
							//如果需要道具
							if (skill.Upgrade_item != 0) {
								if (Config.itemTable.ContainsKey (nextSkill.Upgrade_item)) {
									ItemData itemData = Config.itemTable [nextSkill.Upgrade_item];
									UISprite itemSprite = costItemSprite.GetComponent<UISprite> ();
									itemSprite.atlas.name = "";
									itemSprite.spriteName = "";
									costItemSprite.SetActive (true);
									itemName.SetActive (true);
									itemName.GetComponent<UILabel> ().text = itemData.Name;
								
									
									int itemCount = GoodsCache.GetItemCountFromPack(nextSkill.Upgrade_item);
									if (itemCount < nextSkill.Item_need)
									{
										color = GameConsts.RED;
										butEnabel = false;
									}
									else
										color = GameConsts.GREEN;
									costItemNum.SetActive (true);
									costItemNum.GetComponent<UILabel> ().text = GlobalFunction.GetColorString(string.Concat(nextSkill.Item_need, "/", itemCount), color);
								}
								
							} else {
								costItemSprite.SetActive (false);
								costItemNum.SetActive (false);
							}
						}
					}
				}
			} else {
				skillDesLabel.SetActive (false);
				cdTimeLabel.SetActive (false);
				costDesLabel.SetActive (false);
				costZhenYuanNum.SetActive (false);
				costItemNum.SetActive (false);
				costZhenYuanSprite.SetActive (false);
				costItemSprite.SetActive (false);
				leaveZhenYuan.SetActive (true);
				itemName.SetActive (false);
				zhenYuanName.SetActive (false);
				levelLimitLabel.SetActive(false);
				butEnabel = false;
			}
			studyBut.GetComponent<UIButton>().isEnabled = butEnabel;
		}
		/// <summary>
		/// 更新技能条目显示
		/// </summary>
		/// <param name="info">Info.</param>
		public void UpdateItem (SkillInfo info)
		{
			int skillIndex = info.skillIndex;
			if (Config.skillTable.ContainsKey (skillIndex)) {
				SkillData skillData = Config.skillTable [skillIndex];

				///如果等于0，代表普通攻击,或者是大招，不显示在技能列表中
				if (skillData.Level == 0 || (SkillGroupEnum)skillData.Skill_Group == SkillGroupEnum.DAZHAO)
					return;
				
				int sort = skillData.Sort;
				bool isFind = false;
				SkillItemPanel[] items = itemGrid.GetComponentsInChildren<SkillItemPanel> ();
				foreach (SkillItemPanel item in items) {
					//如果找到，说明这个技能已经学习了
					if (sort == item.SkillSort) {
						item.SkillIndex = info.skillIndex;
						item.SkillState = GameConsts.STUDYED;
						isFind = true;
						break;
					}
				}
				//如果没有找到
				if (!isFind) {
//					Debug.LogError ("没有找到" + skillData.Sort + "类型的技能组件");
					Debug.LogError(skillData.Sort + "is not found");
				}
				
			}
		}
		/// <summary>
		///检查技能列表中所有技能的状态
		/// </summary>
		public void CheckSkillState()
		{
			if (itemGrid == null)
				return;
			SkillItemPanel[] items = itemGrid.GetComponentsInChildren<SkillItemPanel> ();
			foreach (SkillItemPanel item in items) 
			{
				int skillIndex = item.SkillIndex;
				if (Config.skillTable.ContainsKey (skillIndex))
				{
					SkillData skillData = Config.skillTable [skillIndex];
					///**如果等于0，代表普通攻击，不显示在技能列表中*/
					if (skillData.Level == 0)
						return;
					///*如果没有升级*/
					string stateStr = SkillLang.UNSTUDY;
					int level = 0;
					switch (item.SkillState)
					{
						///**如果还没有学习，看下能不能学习*/
					case GameConsts.UN_STUDY:
						bool bo = Config.CheckSkillLevelLimit (skillIndex);
						if (bo)
						{
							stateStr = SkillLang.CANSTUDY;
						}
						break;
						///**如果已经学习了，看下能不能升级*/
					case GameConsts.STUDYED:
						if (!skillData.isMaxLevel())
						{
							bool boo = Config.CheckSkillLevelLimit (skillData.Next_skill);//检测下一个等级的
							if (boo) 
							{
								stateStr = SkillLang.CANLEVELUP;
							} else
								stateStr = SkillLang.UNLEVLUP;
						} 
						else 
						{
							stateStr = SkillLang.MAXLEVEL;
							item.SkillState = GameConsts.MAX_LEVEL;
						}
						level = skillData.Level;
						break;
					case GameConsts.MAX_LEVEL:
						stateStr = SkillLang.MAXLEVEL;
						item.SkillState = GameConsts.MAX_LEVEL;
						level = skillData.Level;
						break;
					}					

					item.UpdateShow (skillData.Skill_icon, skillData.Name, level, stateStr, skillData.Sort);
					if (preClickItem!= null && preClickItem.SkillSort == item.SkillSort)
						this.ShowSkillDetail (skillData.Skill_id);
					
				}
				else
					Debug.LogError (skillIndex + "is not found");
			}
			
		}
		/// <summary>
		/// 清空面板显示
		/// </summary>
		public void ClearPanel ()
		{
			SkillItemPanel[] items = itemGrid.GetComponents<SkillItemPanel> ();
			foreach (SkillItemPanel item in items) {
				item.ClearData ();
				GameObject.Destroy (item);
			}
			this.ShowSkillDetail (-1);
		}
		private void AddEvent()
		{
			if (gainBut != null)
				UIEventListener.Get(gainBut).onClick += OnGainButClick;
			if (studyBut != null)
				UIEventListener.Get(studyBut).onClick += OnStudyButClick;
		}
		//获取按钮
		private void OnGainButClick(GameObject obj)
		{			
		}
		//技能学习
		private void OnStudyButClick(GameObject obj)
		{
			SkillItemPanel item = GetPreClickItem();
			if (item == null)
				return;
			int skillIndex = item.SkillIndex;
			if (skillIndex > 0)
			{
				SkillData skillData = Config.skillTable[skillIndex];
				if (skillData != null)
				{
					//如果是大招，也不在这里处理，因为大招有单独的界面
					if((SkillGroupEnum)skillData.Skill_Group == SkillGroupEnum.DAZHAO)
					{
						return;
					}
					if (item.SkillState == GameConsts.UN_STUDY)
					{
						if (CheckSkillLimit(skillData))
							TangNet.TN.Send(new StudySkillRequest(skillIndex));
					}
					else
					{
						//如果为-1，表示已经是最高级了，不能再升级了
						if (skillData.isMaxLevel())
						{
							GlobalFunction.ShowInfoAtCenter(SkillLang.MAX_LEVEL);				
						}
						else
						{
							if (Config.skillTable.ContainsKey(skillData.Next_skill))
							{
								SkillData nextSkill = Config.skillTable[skillData.Next_skill];
								if (nextSkill != null)
								{
									if (CheckSkillLimit(nextSkill))
										TangNet.TN.Send(new LevelUpSkillRequest(skillIndex));
								}
							}
							else
								Debug.LogError("next skill config is not found");
						}
						
					}
				}
				
			}
			//			}
		}
		/// <summary>
		/// 检查技能学习或升级条件
		/// </summary>
		/// <returns><c>true</c>, if skill limit was checked, <c>false</c> otherwise.</returns>
		/// <param name="skill">Skill.</param>
		private bool CheckSkillLimit(SkillData skill)
		{
			bool bo = Config.CheckSkillLevelLimit(skill.Skill_id);
			if (bo != true)
			{
				GlobalFunction.ShowInfoAtCenter(SkillLang.STUDY_ERROR_4);
				return false;
			}
			
			//判断真元
			HeroNew hero = ActorCache.GetLeadingHero();
			if (skill.Really < hero.zhengYuan)
			{
				GlobalFunction.ShowInfoAtCenter(SkillLang.NEED_ZHENGYUAN);
				return false;
				
			}
			//判断道具
			int count = GoodsCache.GetItemCountFromPack(skill.Upgrade_item);
			if (count < skill.Item_need)
			{
				GlobalFunction.ShowInfoAtCenter(SkillLang.NEED_ITEM);
				return false;
			}
			return true;
			
		}
	}
}

