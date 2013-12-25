/*
 * yc : 2013/12/3
*/
using System;
using UnityEngine;
using nh.ui.basePanel;
using nh.ui.cache;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using TangGame;
using TangGame.Net;
using System.Collections;
using System.Collections.Generic;
using Tang;
using TangGame.Xml;
using nh.ui.mediator;
namespace nh.ui.main
{
	public class EquUpPanel : MonoBehaviour
	{
		public GameObject Checkbox;         		//是否自动购买材料
		public GameObject ConfirmBut;				//升级按钮
		public GameObject GoldConfirmBut;			//金锭升级按钮
		public GameObject GoldNum;					//金锭升级数量信息
		public GameObject TopIcon;					//装备顶级图标
		public GameObject CurrentIcon;				//装备下一级图标	
		public GameObject goldNum;					//自动购买材料所需的花费
		public GameObject goldIcon;					//自动购买材料所需的货币类型图标
		public GameObject LabelAttribute;			//装备当前属性
		public GameObject LabelAttributeText1;		//装备当前属性数值
		public GameObject LabelItem;				//装备当前名字
		public GameObject LabelItemLevel;			//装备使用等级信息
		public GameObject LabelAttributeText2;		//装备升级后的数值增量
		public GameObject LabelGold;				//升级装备的货币消耗类型obj
		public GameObject LabelGoldNum;				//升级装备的货币消耗数值obj
		public GameObject equUpItem1;					//升级装备的材料1
		public GameObject equUpItem2;					//升级装备的材料2
		public GameObject equUpItem3;					//升级装备的材料3
		public GameObject equUpItem4;					//升级装备的材料4
		public GameObject ItemName1;				//升级装备的材料名字1
		public GameObject ItemName2;				//升级装备的材料名字2
		public GameObject ItemName3;				//升级装备的材料名字3
		public GameObject ItemName4;				//升级装备的材料名字4
		public GameObject ItemNum1;				//升级装备的材料数量1
		public GameObject ItemNum2;				//升级装备的材料数量2
		public GameObject ItemNum3;				//升级装备的材料数量3
		public GameObject ItemNum4;				//升级装备的材料数量4
		
		private UILabel attr;						//装备当前属性Label
		private UILabel attributeLabel;				//装备当前数值Label
		private UILabel attributeUpLabel;			//装备升级后的数值增量Label
		private UILabel itemNameLabel;				//装备名字Label
		private UILabel itemLevelInfoLabel;			//装备等级信息Label
		private UILabel coinLabel;					//装备升级所需铜币数值Label
		private UILabel goldLabel;					//装备升级所需购买所需货币数值Label
		private UILabel equUpItemName1Label;		//装备升级材料1名字label
		private UILabel equUpItemName2Label;		//装备升级材料2名字label
		private UILabel equUpItemName3Label;		//装备升级材料3名字label
		private UILabel equUpItemName4Label	;		//装备升级材料4名字label
		private UILabel equUpItemNum1Label;			//装备升级材料1数量label
		private UILabel equUpItemNum2Label;			//装备升级材料2数量label
		private UILabel equUpItemNum3Label;			//装备升级材料3数量label
		private UILabel equUpItemNum4Label;			//装备升级材料4数量label
		private UILabel goldNumLabel;				//装备金锭升级所需数量label
		
		private UIButton but;						//装备升级按钮uiButton
		private UIButton butGold;					//装备金锭升级按钮uiButton
		private int itemToUpLevel = -1;				//当前要去升级的装备Id
		private bool canUpOrNot = false;
		public EquUpPanel()
		{
		}
		public int ItemToUpLevel{
			set{
				itemToUpLevel = value;
			}
			get{
				return itemToUpLevel;
			}
		}
		void Start(){
			EquUpPanelMediator me= new EquUpPanelMediator(this);
			Facade.Instance.RegisterMediator(me);
			attr = LabelAttribute.GetComponent<UILabel>();
			attr.text = "";
			attributeLabel = LabelAttributeText1.GetComponent<UILabel>();
			attributeLabel.text = "";
			attributeUpLabel = LabelAttributeText2.GetComponent<UILabel>();
			attributeUpLabel.text = "";
			coinLabel = LabelGoldNum.GetComponent<UILabel>();
			coinLabel.text = ""; 
			goldLabel = goldNum.GetComponent<UILabel>();
			goldLabel.text = "";
			itemNameLabel = LabelItem.GetComponent<UILabel>();
			itemNameLabel.text = "";
			itemLevelInfoLabel = LabelItemLevel.GetComponent<UILabel>();
			itemLevelInfoLabel.text = "";
			
			equUpItemName1Label = ItemName1.GetComponent<UILabel>();
			equUpItemName1Label.text = "";
			equUpItemName2Label = ItemName2.GetComponent<UILabel>();
			equUpItemName2Label.text = "";
			equUpItemName3Label = ItemName3.GetComponent<UILabel>();
			equUpItemName3Label.text = "";
			equUpItemName4Label = ItemName4.GetComponent<UILabel>();
			equUpItemName4Label.text = "";
			equUpItemNum1Label = ItemNum1.GetComponent<UILabel>();
			equUpItemNum1Label.text = "";
			equUpItemNum2Label = ItemNum2.GetComponent<UILabel>();
			equUpItemNum2Label.text = "";
			equUpItemNum3Label = ItemNum3.GetComponent<UILabel>();
			equUpItemNum3Label.text = "";
			equUpItemNum4Label = ItemNum4.GetComponent<UILabel>();
			equUpItemNum4Label.text = "";
			goldNumLabel = GoldNum.GetComponent<UILabel>();
			goldNumLabel.text = "0";
			
			if (ConfirmBut)
	    			UIEventListener.Get(ConfirmBut).onClick+= OnEquUpLevelButClick;
			if (GoldConfirmBut)
	    			UIEventListener.Get(GoldConfirmBut).onClick+= OnEquUpLevelGoldButClick;
			butGold = GoldConfirmBut.GetComponent<UIButton>();
//			butGold.isEnabled = false;
			but = ConfirmBut.GetComponent<UIButton>();
//			but.isEnabled = false;
		}
		void Update(){

		}
		//显示选中升级的装备信息
		private void SetCurrentItemInfo(int itemId){
			SetEquItem (itemId,CurrentIcon);
			string[] temp = TangGame.Config.itemTable[itemId].Equipproperty.Split(',');
			string num = "";
			HeroPropertyEnum type = (HeroPropertyEnum)(int.Parse(temp[0]));
			switch(type){
				case HeroPropertyEnum.PHYSICALATTACK:
					num += "物理攻击";
					break;
				case HeroPropertyEnum.PHYSICALDEFENSE:
					num += "物理防御";
					break;
				case HeroPropertyEnum.MAGICATTACK:
					num += "法术攻击";
					break;
				case HeroPropertyEnum.MAGICDEFENSE:
					num += "法术防御";
					break;
				case HeroPropertyEnum.HITRATE:
					num += "命中";
					break;
				case HeroPropertyEnum.DODGE:
					num += "闪避";
					break;
				case HeroPropertyEnum.CRITICALSTRIKE:
					num += "暴击";
					break;
				case HeroPropertyEnum.TENACITY:
					num += "韧性";
					break;	
			}

			itemNameLabel.text = TangGame.Config.GetItemColorName(itemId);
			itemLevelInfoLabel.text = "装备使用等级:" + TangGame.Config.itemTable[itemId].NeedLv;
			attr.text = num;
			attributeLabel.text = "+" + temp[1];
		}
		public void SetTopAndNextItem(int itemId){
			if(!TangGame.Config.equip_upgrade.ContainsKey(itemId)) return;
			ItemToUpLevel = itemId;
			int topItemId = FindTopId(itemId);
			int nextItemId = -1;
			if(TangGame.Config.equip_upgrade[itemId].Next_id > 0){
				nextItemId = TangGame.Config.equip_upgrade[itemId].Next_id;
			}else{
				nextItemId = itemId;
			}	
			SetEquItem (topItemId,TopIcon);
			SetCurrentItemInfo(itemId);
			
			if(itemId == topItemId){
				attributeUpLabel.text = "已升到顶级";	
			}else{
				string[] tempNext = TangGame.Config.itemTable[nextItemId].Equipproperty.Split(',');
				string[] tempCurrent = TangGame.Config.itemTable[itemId].Equipproperty.Split(',');
				attributeUpLabel.text = (int.Parse(tempNext[1]) - int.Parse(tempCurrent[1])).ToString();
			}
			SetCanUpLevel(itemId,CanUpLevel(TangGame.Config.equip_upgrade[itemId]));
			goldNumLabel.text = TangGame.Config.equip_upgrade[nextItemId].Total_gold.ToString();
			
		}
		//判断可否进行装备升级
	    private bool CanUpLevel(Equip_upgrade equ_up){
	    	//装备小于角色等级
//	    	if(TangGame.Config.itemTable[equ_up.Next_id].NeedLv > UIActorCache.myHero.level)
//	    		return false;
	    	//角色身上材料不够
	    	
	    	return true;
	    }
		//可升级的行为
		public void SetCanUpLevel(int itemId,bool canUp){
			Equip_upgrade equ = TangGame.Config.equip_upgrade[itemId];
			coinLabel.text = equ.Money.ToString();
			string[] needs = equ.Upgradenum.Split(';');
			string[] temp;
			int goodsNeed = 0;
			for(int i = 0;i < needs.Length;i++){
				temp = needs[i].Split(',');
				goodsNeed = int.Parse( temp[1]);
				if(i == 0){
					SetNeedGoodsNameAndNum(temp[0],equ,goodsNeed,equUpItem1,equUpItemName1Label,equUpItemNum1Label);
				}else if(i == 1){
					SetNeedGoodsNameAndNum(temp[0],equ,goodsNeed,equUpItem2,equUpItemName2Label,equUpItemNum2Label);
				}else if(i == 2){
					SetNeedGoodsNameAndNum(temp[0],equ,goodsNeed,equUpItem3,equUpItemName3Label,equUpItemNum3Label);
				}else{
					SetNeedGoodsNameAndNum(temp[0],equ,goodsNeed,equUpItem4,equUpItemName4Label,equUpItemNum4Label);
				}
				goodsNeed = 0;
			}
			goldNumLabel.text = TangGame.Config.equip_upgrade[itemId].Money.ToString();  
			ItemToUpLevel = itemId;
//			but.isEnabled = canUp && canUpOrNot;
		}
		private void SetNeedGoodsNameAndNum(string minitype,Equip_upgrade equ,int needNum,GameObject hitem,UILabel nameLabel,UILabel numLabel){
			List<string[]> needs = FindMinitypeItemId(minitype,equ);
			int idToShow = -1;
			int noneToShow = -1;
			int had = 0;
			string name = "";
			string goodsNum = "";
			for(int i = 0;i < needs.Count;i++){
				foreach(string str in needs[i]){
					int goodsId = int.Parse(str);
					if(noneToShow < 0) noneToShow = goodsId;
					int num = TangGame.GoodsCache.GetItemCountFromPack(goodsId);
					if(num > 0){
						idToShow = goodsId;
						had += num;
					}
				}
			}
			if(idToShow > 0){
				name = TangGame.Config.itemTable[idToShow].Name;
				SetEquItem(idToShow,hitem);
			}else{
				name = TangGame.Config.itemTable[noneToShow].Name;
				SetEquItem(noneToShow ,hitem);
			}
			if(had >= needNum){
				goodsNum = had + "/" + needNum;
				canUpOrNot = true;
			}else{
				goodsNum = "[ff0000]" + had + "[-]/[00ff00]" + needNum + "[-]";
				canUpOrNot = false;
			}
			nameLabel.text = name;
			numLabel.text = goodsNum;
		}
		//通过minitype寻找itemId s
		private List<string[]> FindMinitypeItemId(string minitype,Equip_upgrade equ){
			string[] temp = equ.Minitype_id.Split(';');
			string[] temp1;
			string[] temp2;
			List<string[]> toParse = new List<string[]>();
			foreach(string str in temp){
				temp1 = str.Split(':');
				if(minitype.Equals(temp1[0])){
					temp2 = temp1[1].Split(',');
					toParse.Add(temp2);
				}
			}
			return toParse;
		}
		//寻找顶级装备的id
	    private int FindTopId(int goodsId){
	    	int temp = goodsId;
	    	if(TangGame.Config.equip_upgrade.ContainsKey(temp)){
	    		while(TangGame.Config.equip_upgrade[temp].Next_id > 0){
	    			temp = TangGame.Config.equip_upgrade[temp].Next_id;
	    		}
	    	}
	    	return temp;
	    }
		//通过物品id设置精灵图片
		private void SetEquItem(int goodsId,GameObject hItem){
			TangGame.Xml.ItemData item = TangGame.Config.itemTable[goodsId];
			int icon = item.Icon;
			HItem mi = hItem.GetComponent<HItem>();
			mi.UpdateShow(icon,false,0,0, GameConsts.GOODSITEM);
			mi.ItemId = goodsId;
		}
		
		private void OnEquUpLevelButClick(GameObject obj)
		{
	    	Debug.Log("equ level up~~~~~~~");
	    	if(ItemToUpLevel > 0){
//	    		Debug.Log(this.ItemToUpLevel);
	    		TangNet.TN.Send(new EquipUpgradeRequest(ItemToUpLevel,0));
//	    		but.isEnabled = false;
	    		canUpOrNot = false;
	    		ItemToUpLevel = -1;
	    	}
		}
		private void OnEquUpLevelGoldButClick(GameObject obj)
		{
	    	Debug.Log("equ level up~~~~~~~gold");
	    	if(ItemToUpLevel > 0){
//	    		Debug.Log(this.ItemToUpLevel);
	    		TangNet.TN.Send(new EquipUpgradeRequest(this.ItemToUpLevel,1));
//	    		but.isEnabled = false;
	    		canUpOrNot = false;
	    		ItemToUpLevel = -1;
	    	}
		}
		
		private void CleanInfo(){
			attr.text = "";						
			attributeLabel.text = "";				
			attributeUpLabel.text = "";			
			itemNameLabel.text = "";				
			itemLevelInfoLabel.text = "";			
			coinLabel.text = "";					
			goldLabel.text = "";					
			equUpItemName1Label.text = "";		
			equUpItemName2Label.text = "";		
			equUpItemName3Label.text = "";		
			equUpItemName4Label.text = "";		
			equUpItemNum1Label.text = "";			
			equUpItemNum2Label.text = "";			
			equUpItemNum3Label.text = "";			
			equUpItemNum4Label.text = "";			
			goldNumLabel.text = "0";
			equUpItem1.GetComponent<HItem>().ClearData();
			equUpItem2.GetComponent<HItem>().ClearData();
			equUpItem3.GetComponent<HItem>().ClearData();
			equUpItem4.GetComponent<HItem>().ClearData();
		}
	}
}
